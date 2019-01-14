using System.ComponentModel;
using LedMessageBoard.ConfigurationPanels;
using LedMessageBoard.DisplayAdapters;
using System;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace LedMessageBoard
{
    /// <summary>
    /// Displays a form from the System Tray for configuring the desired displays
    /// </summary>
    internal partial class ConfigurationForm : Form
    {
        #region Delegates for handling multithreading

        public delegate void NewConfigurationHandler(object sender, EventArgs e);

        public event NewConfigurationHandler OnConfigurationUpdated;

        public delegate void ConfigurationAppliedHandler(object sender, CancelEventArgs e);

        public event ConfigurationAppliedHandler OnConfigurationApplied;

        #endregion

        private readonly IConfigurationPanel[] configurationPanels;

        public ConfigurationForm()
        {
            InitializeComponent();

            this.configurationPanels = GetAllConfigurationPanels();

            SetTrackBar(LedMessageBoard.Properties.Settings.Default.Global_RefreshRate, this.TrackBarRefreshRate, this.LabelRefreshRate);
            SetTrackBar(LedMessageBoard.Properties.Settings.Default.Global_ScrollRate, this.TrackBarScrollRate, this.LabelScrollRate);
            SetTrackBar(LedMessageBoard.Properties.Settings.Default.Global_StaticDisplayDuration, this.TrackBarStaticDisplayDuration, this.LabelStaticDisplayDuration);

            var brightness = LedMessageBoard.Properties.Settings.Default.Global_Brightness;

            var byteItems = this.ComboBoxBrightness.Items.Cast<string>().Select(byte.Parse).ToArray();
            var minBright = byteItems.Min();
            var maxBright = byteItems.Max();

            if (brightness < minBright)
            {
                brightness = minBright;
            }

            if (brightness > maxBright)
            {
                brightness = maxBright;
            }

            this.ComboBoxBrightness.SelectedItem = brightness;
            this.ComboBoxBrightness.Text = brightness.ToString();

            var activeDisplays = LedMessageBoard.Properties.Settings.Default.Global_ActiveDisplays;

            this.CheckedListBoxActiveDisplays.Items.Clear();

            //foreach (var p in this.configurationPanels)
            //{
            //    var isActive = activeDisplays != null && activeDisplays.Contains(p.DisplayAdapter.Title);

            //    p.DisplayAdapter.Active = isActive;
            //    this.CheckedListBoxActiveDisplays.Items.Add(p.DisplayAdapter.Title, isActive);

            //    this.OnConfigurationApplied += p.ToControl().OnApply;

            //    var tabPage = new TabPage(p.DisplayAdapter.Title);
            //    tabPage.Controls.Add(p.ToControl());

            //    this.TabControlConfigurationPanels.TabPages.Add(tabPage);
            //}
        }

        public IDisplayAdapter[] DisplayAdapters
        {
            get { return null; }
            //get { return this.configurationPanels.Select(c => c.DisplayAdapter).ToArray(); }
        }

        public IDisplayAdapter[] ActiveDisplayAdapters
        {
            get { return this.DisplayAdapters.Where(d => d.Active).ToArray(); }
        }

        public IConfigurationPanel[] ActiveConfigurationPanels
        {
            get { return null; }
            //get { return this.configurationPanels.Where(c => c.DisplayAdapter.Active).ToArray(); }
        }

        private static IConfigurationPanel[] GetAllConfigurationPanels()
        {
            var panelTypes = Assembly.GetAssembly(typeof(IConfigurationPanel))
                                     .GetTypes()
                                     .Where(t => t.IsClass && !t.IsAbstract && typeof(IConfigurationPanel).IsAssignableFrom(t))
                                     .ToArray();

            var panels = panelTypes.Select(t => (IConfigurationPanel)Activator.CreateInstance(t)).ToArray();

            //var result = panels.OrderBy(p => p.DisplayAdapter.Title).ToArray();
            return null;
        }

        private static void SetTrackBar(int value, TrackBar trackBar, Label label)
        {
            var result = value;

            if (result < trackBar.Minimum)
            {
                result = trackBar.Minimum;
            }

            if (result > trackBar.Maximum)
            {
                result = trackBar.Maximum;
            }

            trackBar.Value = result;
            label.Text = result.ToString();
        }

        private void TrackBarRefreshRate_Scroll(object sender, EventArgs e)
        {
            this.LabelRefreshRate.Text = this.TrackBarRefreshRate.Value.ToString();
        }

        private void TrackBarScrollRate_Scroll(object sender, EventArgs e)
        {
            this.LabelScrollRate.Text = this.TrackBarScrollRate.Value.ToString();
        }

        private void ButtonApply_Click(object sender, EventArgs e)
        {
            LedMessageBoard.Properties.Settings.Default.Global_RefreshRate = this.TrackBarRefreshRate.Value;
            LedMessageBoard.Properties.Settings.Default.Global_ScrollRate = this.TrackBarScrollRate.Value;
            LedMessageBoard.Properties.Settings.Default.Global_Brightness = byte.Parse(this.ComboBoxBrightness.Text);
            LedMessageBoard.Properties.Settings.Default.Global_StaticDisplayDuration = this.TrackBarStaticDisplayDuration.Value;

            if (this.OnConfigurationApplied != null)
            {
                var cancelArgs = new CancelEventArgs();

                this.OnConfigurationApplied(this, cancelArgs);

                if (cancelArgs.Cancel)
                {
                    LedMessageBoard.Properties.Settings.Default.Reload();
                    return;
                }
            }

            var checkedItems = this.CheckedListBoxActiveDisplays.CheckedItems.Cast<string>().ToArray();

            LedMessageBoard.Properties.Settings.Default.Global_ActiveDisplays = new StringCollection();

            LedMessageBoard.Properties.Settings.Default.Global_ActiveDisplays.AddRange(checkedItems);

            LedMessageBoard.Properties.Settings.Default.Global_ActiveDisplays.AddRange(this.CheckedListBoxActiveDisplays.CheckedItems.Cast<string>().ToArray());

            LedMessageBoard.Properties.Settings.Default.Save();

            foreach (var cp in this.configurationPanels)
            {
                //if (checkedItems.Contains(cp.DisplayAdapter.Title))
                //{
                //    cp.Initialize(true);
                //}
                //else
                //{
                //    cp.DisplayAdapter.Active = false;
                //}
            }

            if (this.OnConfigurationUpdated == null)
            {
                return;
            }

            var args = new EventArgs();
            this.OnConfigurationUpdated(this, args);

            this.Visible = false;
        }

        private void TrackBarStaticDisplayDuration_Scroll(object sender, EventArgs e)
        {
            this.LabelStaticDisplayDuration.Text = this.TrackBarStaticDisplayDuration.Value.ToString();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            LedMessageBoard.Properties.Settings.Default.Reload();

            this.Visible = false;
        }
    }
}
