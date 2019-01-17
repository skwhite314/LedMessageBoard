using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using HidLibrary;
using LedMessageBoard.DisplayAdapters;

namespace LedMessageBoard
{
    /// <summary>
    /// The "system tray" version of the application
    /// </summary>
    public class TrayApplication : ApplicationContext
    {
        private const int VendorID = 0x1D34;
        private const int ProductID = 0x0013;

        private readonly object _lock = new object();

        private HidDevice device;

        private readonly NotifyIcon trayIcon;

        private readonly BoardConfiguration boardConfiguration;

        private IDisplayAdapter[] adapters;

        private int adapterIndex = 0;

        private System.Timers.Timer timer;

        public TrayApplication()
        {
            // TODO: load displays from configuration
            this.boardConfiguration = new BoardConfiguration();
            this.boardConfiguration.Visible = false;

            this.boardConfiguration.OnConfigurationUpdated += this.ConfigurationUpdateEventHandler;

            var connectMenu = new MenuItem(LedMessageBoard.Properties.Resources.ConnectMenuItem, this.OnConnect);

            var configureMenu = new MenuItem(LedMessageBoard.Properties.Resources.ConfigureMenuItem, this.OnConfigure);

            var exitMenu = new MenuItem(LedMessageBoard.Properties.Resources.ExitMenuItem, this.OnExit);

            var contextMenu = new ContextMenu();
            contextMenu.MenuItems.Add(connectMenu);
            contextMenu.MenuItems.Add("-");
            contextMenu.MenuItems.Add(configureMenu);
            contextMenu.MenuItems.Add(exitMenu);

            this.trayIcon = new NotifyIcon
            {
                Icon = LedMessageBoard.Properties.Resources.LMB,
                Text = LedMessageBoard.Properties.Resources.TrayText,
                ContextMenu = contextMenu,
                Visible = true
            };

            this.InitializeSystem();

            this.ReadDisplayAdapterConfigurations();
        }

        private void InitializeSystem(bool resetIndex = true, bool clearAdapters = true)
        {
            if (this.timer != null) this.timer.Enabled = false;

            if (resetIndex) this.adapterIndex = 0;

            if (clearAdapters) this.adapters = new IDisplayAdapter[0];

            this.timer = new System.Timers.Timer(LedMessageBoard.Properties.Settings.Default.Global_RefreshRate);
            this.timer.Elapsed += this.OnTimerElapsed;
            this.timer.Enabled = true;
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            lock (this._lock)
            {
                if (device == null)
                {
                    return;
                }

                if (this.adapters.Length == 0)
                {
                    return;
                }

                if (this.adapters.All(a => !a.Active))
                {
                    return;
                }

                if (this.adapters[this.adapterIndex].DisplayComplete)
                {
                    do
                    {
                        this.adapterIndex++;
                        if (this.adapterIndex >= this.adapters.Length)
                        {
                            this.adapterIndex = 0;
                        }
                    }
                    while (!this.adapters[this.adapterIndex].Active);

                    this.adapters[this.adapterIndex].Reset();
                }

                this.adapters[this.adapterIndex].Draw(this.device, (byte)LedMessageBoard.Properties.Settings.Default.Global_Brightness);
            }
        }

        private void OnConnect(object sender, EventArgs e)
        {
            if (this.device == null)
            {
                this.device = HidDevices.Enumerate(VendorID, ProductID).FirstOrDefault();

                if (this.device == null)
                {
                    return;
                }

                this.device.OpenDevice();
                this.device.Removed += this.DeviceRemovedHandler;
                this.device.MonitorDeviceEvents = true;

                this.trayIcon.ContextMenu.MenuItems[0].Checked = true;
            }
            else
            {
                this.device.CloseDevice();
                this.device = null;

                this.trayIcon.ContextMenu.MenuItems[0].Checked = false;
            }
        }

        private void OnExit(object sender, EventArgs e)
        {
            if (this.device != null)
            {
                device.CloseDevice();
            }

            this.boardConfiguration.Close();

            this.trayIcon.Visible = false;

            Application.Exit();
        }

        private void OnConfigure(object sender, EventArgs e)
        {
            this.boardConfiguration.Visible = true;
        }

        private void ConfigurationUpdateEventHandler(object sender, EventArgs e)
        {
            lock (this._lock)
            {
                var newAdapterList = this.boardConfiguration.GetDisplayAdapters();

                if (newAdapterList.Length == 0)
                {
                    this.adapterIndex = 0;
                    this.adapters = new IDisplayAdapter[0];
                    return;
                }

                IDisplayAdapter currentAdapter = this.adapterIndex < this.adapters.Length ? this.adapters[this.adapterIndex] : null;

                if (currentAdapter != null) currentAdapter.Reset();

                var newIndex = currentAdapter == null ? 0 : newAdapterList.ToList().IndexOf(currentAdapter);

                this.adapterIndex = newIndex < 0 ? 0 : newIndex;

                this.adapters = newAdapterList;

                this.WriteDisplayAdapterConfigurations();

                this.InitializeSystem(false, false);
            }
        }

        private void ReadDisplayAdapterConfigurations()
        {
            var cdaTuples = SerializeHelper<CountdownDisplayAdapter>.ReadFromSettings();
            var ctdaTuples = SerializeHelper<CustomTextDisplayAdapter>.ReadFromSettings();
            var tdaTuples = SerializeHelper<TimeDisplayAdapter>.ReadFromSettings();

            var displayAdapters = cdaTuples.Union(ctdaTuples).Union(tdaTuples).OrderBy(t => t.Item1).Select(t => t.Item2).ToArray();

            this.adapters = displayAdapters;

            this.boardConfiguration.Brightness = LedMessageBoard.Properties.Settings.Default.Global_Brightness;
            this.boardConfiguration.RefreshRate = LedMessageBoard.Properties.Settings.Default.Global_RefreshRate;
            this.boardConfiguration.ScrollRate = LedMessageBoard.Properties.Settings.Default.Global_ScrollRate;
            this.boardConfiguration.StaticDisplayDuration = LedMessageBoard.Properties.Settings.Default.Global_StaticDisplayDuration;

            this.boardConfiguration.UpdateDisplayAdapters(this.adapters);
            this.InitializeSystem(clearAdapters: false);

        }

        private void WriteDisplayAdapterConfigurations()
        {
            var tupleList = new List<Tuple<int, IDisplayAdapter>>(this.adapters.Length);

            for (var i = 0; i < this.adapters.Length; i++)
            {
                tupleList.Add(new Tuple<int, IDisplayAdapter>(i, this.adapters[i]));
            }

            var tupleArray = tupleList.ToArray();

            var cdaCount = SerializeHelper<CountdownDisplayAdapter>.WriteToSettings(tupleArray);
            var ctdaCount = SerializeHelper<CustomTextDisplayAdapter>.WriteToSettings(tupleArray);
            var tdaCount = SerializeHelper<TimeDisplayAdapter>.WriteToSettings(tupleArray);

            var total = cdaCount + ctdaCount + tdaCount;

            LedMessageBoard.Properties.Settings.Default.Global_Brightness = this.boardConfiguration.Brightness;
            LedMessageBoard.Properties.Settings.Default.Global_RefreshRate = this.boardConfiguration.RefreshRate;
            LedMessageBoard.Properties.Settings.Default.Global_ScrollRate = this.boardConfiguration.ScrollRate;
            LedMessageBoard.Properties.Settings.Default.Global_StaticDisplayDuration = this.boardConfiguration.StaticDisplayDuration;

            LedMessageBoard.Properties.Settings.Default.Save();

            if (total < tupleArray.Length)
            {
                var message = string.Format("{0} display adapters not saved.", tupleArray.Length - total);
                MessageBox.Show(message);
            }
        }

        private void DeviceRemovedHandler()
        {
            this.trayIcon.ContextMenu.MenuItems[0].Checked = false;
            this.device = null;
        }

        public class SerializeHelper<T> where T : class, IDisplayAdapter, new()
        {
            private static readonly Type CountdownDisplayAdapterType = typeof(CountdownDisplayAdapter);
            private static readonly Type CustomTextDisplayAdapterType = typeof(CustomTextDisplayAdapter);
            private static readonly Type TimeDisplayAdapterType = typeof(TimeDisplayAdapter);

            public static int WriteToSettings(Tuple<int, IDisplayAdapter>[] tuples)
            {
                var sharray = Filter(tuples).Select(sh => sh.ToString()).ToArray();

                var jsonSer = new DataContractJsonSerializer(typeof(string[]));

                using (var stream = new MemoryStream())
                {
                    jsonSer.WriteObject(stream, sharray);

                    stream.Position = 0;

                    using (var sr = new StreamReader(stream))
                    {
                        var result = sr.ReadToEnd();

                        LedMessageBoard.Properties.Settings.Default[SettingsName] = result;

                        return sharray.Length;
                    }
                }
            }

            public static Tuple<int, IDisplayAdapter>[] ReadFromSettings()
            {
                var jsonSer = new DataContractJsonSerializer(typeof(string[]));

                var s = LedMessageBoard.Properties.Settings.Default[SettingsName].ToString();

                if (string.IsNullOrWhiteSpace(s)) return new Tuple<int, IDisplayAdapter>[0];

                try
                {
                    using (var stream = new MemoryStream())
                    {
                        using (var sw = new StreamWriter(stream))
                        {
                            sw.Write(s);

                            stream.Position = 0;

                            var stringArray = (string[])jsonSer.ReadObject(stream);

                            var result = stringArray.Select(sa =>
                            {
                                var sh = new SerializeHelper<T>();
                                sh.PopulateFromString(sa);

                                var t = new Tuple<int, IDisplayAdapter>(sh.Index, sh.DisplayAdapter);
                                return t;
                            }).ToArray();

                            foreach (var t in result) t.Item2.Reset();

                            return result;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return new Tuple<int, IDisplayAdapter>[0];
                }
            }

            private static string SettingsName
            {
                get
                {
                    var t = typeof(T);

                    if (t == CountdownDisplayAdapterType && !t.IsSubclassOf(CountdownDisplayAdapterType))
                    {
                        return "CountdownDisplayAdapters";
                    }

                    if (t == CustomTextDisplayAdapterType && !t.IsSubclassOf(CustomTextDisplayAdapterType))
                    {
                        return "CustomTextDisplayAdapters";
                    }

                    if (t == TimeDisplayAdapterType && !t.IsSubclassOf(TimeDisplayAdapterType))
                    {
                        return "TimeDisplayAdapters";
                    }

                    throw new NotImplementedException(string.Format("SettingsName for type {0} not implemented.", t.FullName));
                }
            }

            private static SerializeHelper<T>[] Filter(Tuple<int, IDisplayAdapter>[] tuples)
            {
                var type = typeof(T);

                var result = tuples
                                .Where(t => t.Item2.GetType() == type)
                                .Select(t => new SerializeHelper<T>(t.Item1, (T)t.Item2))
                                .ToArray();

                return result;
            }

            public T DisplayAdapter { get; set; }

            public int Index { get; set; }

            public SerializeHelper() { }

            public SerializeHelper(int index, T displayAdapter)
            {
                this.DisplayAdapter = displayAdapter;
                this.Index = index;
            }

            public override string ToString()
            {
                var da = this.DisplayAdapter.Serialize();

                var result = string.Format("{0},{1}", this.Index, da);

                return result;
            }

            private void PopulateFromString(string s)
            {
                var index = s.IndexOf(',');

                var s1 = s.Substring(0, index);
                var s2 = s.Substring(index + 1);

                this.Index = int.Parse(s1);

                this.DisplayAdapter = new T();

                this.DisplayAdapter.PopulateFromString(s2);
            }
        }
    }
}
