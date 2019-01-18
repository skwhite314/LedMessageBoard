using System;
using System.Collections.Generic;
using System.Configuration;
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
using Newtonsoft.Json;

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
            this.boardConfiguration.UpdateDisplayAdapters(this.adapters);
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

                this.WriteDisplayAdapterConfigurations();

                IDisplayAdapter currentAdapter = this.adapterIndex < this.adapters.Length ? this.adapters[this.adapterIndex] : null;

                if (currentAdapter != null) currentAdapter.Reset();

                var newIndex = currentAdapter == null ? 0 : newAdapterList.ToList().IndexOf(currentAdapter);

                this.adapterIndex = newIndex < 0 ? 0 : newIndex;

                this.adapters = newAdapterList;

                this.InitializeSystem(false, false);
            }
        }

        private void ReadDisplayAdapterConfigurations()
        {
            var datypes = GetDisplayAdapterTypes();

            var method = GetDeserializeMethod();

            var dict = new Dictionary<Type, IDictionary<int, IDisplayAdapter>>(datypes.Length);

            foreach (var datype in datypes)
            {
                var propertyName = GenerateDisplayAdapterPropertyName(datype);

                if (LedMessageBoard.Properties.Settings.Default.Properties[propertyName] == null)
                {
                    var prop = CreateProperty(propertyName);

                    LedMessageBoard.Properties.Settings.Default.Properties.Add(prop);

                    LedMessageBoard.Properties.Settings.Default.Reload();
                }

                var json = LedMessageBoard.Properties.Settings.Default[propertyName].ToString().Trim();

                if (string.IsNullOrWhiteSpace(json)) continue;

                var dictType = typeof(Dictionary<,>);

                var genDictType = dictType.MakeGenericType(typeof(int), datype);

                var deserializeMethod = method.MakeGenericMethod(genDictType);

                var obj = deserializeMethod.Invoke(null, new[] { json });

                var indexMethod = genDictType.GetMethod("get_Item");

                var property = genDictType.GetProperty("Keys");

                var keys = (ICollection<int>)property.GetValue(obj);

                var innerDict = new Dictionary<int, IDisplayAdapter>(keys.Count);

                foreach (var key in keys)
                {
                    var da = (IDisplayAdapter)indexMethod.Invoke(obj, new object[] { key });

                    innerDict.Add(key, da);
                }

                dict.Add(datype, innerDict);
            }

            var daArray = dict.SelectMany(kvp => kvp.Value).OrderBy(v => v.Key).Select(v => v.Value).ToArray();

            this.adapters = daArray;

            this.boardConfiguration.Brightness = LedMessageBoard.Properties.Settings.Default.Global_Brightness;
            this.boardConfiguration.RefreshRate = LedMessageBoard.Properties.Settings.Default.Global_RefreshRate;
            this.boardConfiguration.ScrollRate = LedMessageBoard.Properties.Settings.Default.Global_ScrollRate;
            this.boardConfiguration.StaticDisplayDuration = LedMessageBoard.Properties.Settings.Default.Global_StaticDisplayDuration;

            this.boardConfiguration.UpdateDisplayAdapters(this.adapters);
            this.InitializeSystem(clearAdapters: false);

        }

        private void WriteDisplayAdapterConfigurations()
        {
            var tuples = new Tuple<int, IDisplayAdapter>[this.adapters.Length];

            for (var i = 0; i < this.adapters.Length; i++) tuples[i] = new Tuple<int, IDisplayAdapter>(i, this.adapters[i]);

            var dict = FilterDisplayAdapters(tuples);

            foreach (var key in dict.Keys)
            {
                var propertyName = GenerateDisplayAdapterPropertyName(key);

                var prop = LedMessageBoard.Properties.Settings.Default.Properties[propertyName];

                if (prop == null)
                {
                    prop = CreateProperty(propertyName);

                    LedMessageBoard.Properties.Settings.Default.Properties.Add(prop);

                    LedMessageBoard.Properties.Settings.Default.Reload();
                }

                var json = JsonConvert.SerializeObject(dict[key]);

                LedMessageBoard.Properties.Settings.Default[propertyName] = json;
            }

            LedMessageBoard.Properties.Settings.Default.Global_Brightness = this.boardConfiguration.Brightness;
            LedMessageBoard.Properties.Settings.Default.Global_RefreshRate = this.boardConfiguration.RefreshRate;
            LedMessageBoard.Properties.Settings.Default.Global_ScrollRate = this.boardConfiguration.ScrollRate;
            LedMessageBoard.Properties.Settings.Default.Global_StaticDisplayDuration = this.boardConfiguration.StaticDisplayDuration;

            LedMessageBoard.Properties.Settings.Default.Save();
        }

        private void DeviceRemovedHandler()
        {
            this.trayIcon.ContextMenu.MenuItems[0].Checked = false;
            this.device = null;
        }

        private static MethodInfo GetDeserializeMethod()
        {
            var method = typeof(JsonConvert).GetMember("DeserializeObject", MemberTypes.Method, BindingFlags.Static | BindingFlags.Public)
                .Cast<MethodInfo>()
                .First(mi => mi.ContainsGenericParameters);

            return method;
        }

        private static SettingsProperty CreateProperty(string propertyName)
        {
            var prop = new SettingsProperty(propertyName);
            prop.DefaultValue = string.Empty;
            prop.IsReadOnly = false;
            prop.PropertyType = typeof(string);
            prop.Provider = LedMessageBoard.Properties.Settings.Default.Providers["LocalFileSettingsProvider"];
            prop.Attributes.Add(typeof(System.Configuration.UserScopedSettingAttribute), new System.Configuration.UserScopedSettingAttribute());

            return prop;
        }

        private static IDictionary<Type, IDictionary<int, IDisplayAdapter>> FilterDisplayAdapters(Tuple<int, IDisplayAdapter>[] tuples)
        {
            var datypes = GetDisplayAdapterTypes();

            var result = new Dictionary<Type, IDictionary<int, IDisplayAdapter>>(datypes.Length);

            foreach (var datype in datypes)
            {
                IDictionary<int, IDisplayAdapter> dict = tuples.Where(t => t.Item2.GetType() == datype).ToDictionary(t => t.Item1, t => t.Item2);

                result.Add(datype, dict);
            }

            return result;
        }

        private static Type[] GetDisplayAdapterTypes()
        {
            var datypes = Assembly.GetAssembly(typeof(IDisplayAdapter))
                            .GetTypes()
                            .Where(t => t.IsClass && !t.IsAbstract && typeof(IDisplayAdapter).IsAssignableFrom(t))
                            .ToArray();

            return datypes;
        }

        private static string GenerateDisplayAdapterPropertyName(Type type)
        {
            var result = string.Format("DisplayAdapters_{0}", type.Name);

            return result;
        }
    }
}
