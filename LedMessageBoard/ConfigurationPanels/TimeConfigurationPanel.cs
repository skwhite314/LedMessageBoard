using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LedMessageBoard.DisplayAdapters;

namespace LedMessageBoard.ConfigurationPanels
{
    /// <summary>
    /// Collects configuration information for displaying the current time
    /// </summary>
    internal partial class TimeConfigurationPanel : ConfigurationPanel, IConfigurationPanel
    {
        public TimeConfigurationPanel()
        {
            InitializeComponent();

            this.Reset();
        }

        public IDisplayAdapter DisplayAdapter { get; private set; }

        public void Initialize(bool makeActive)
        {
            var timespan = new TimeSpan(0, 0, LedMessageBoard.Properties.Settings.Default.Global_StaticDisplayDuration);
            this.DisplayAdapter = new TimeDisplayAdapter(LedMessageBoard.Properties.Settings.Default.TimeConfigurationPanel_Format, timespan);
            this.DisplayAdapter.Active = makeActive;
        }

        public ConfigurationPanel ToControl()
        {
            return this;
        }

        public override void Reset()
        {
            this.TextBoxTimeFormat.Text = LedMessageBoard.Properties.Settings.Default.TimeConfigurationPanel_Format;
        }

        public void OnApply(object sender, CancelEventArgs e)
        {
            try
            {
                DateTime.Now.ToString(this.TextBoxTimeFormat.Text);

                LedMessageBoard.Properties.Settings.Default.TimeConfigurationPanel_Format = this.TextBoxTimeFormat.Text;
                LedMessageBoard.Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                var message = string.Format("Invalid DateTime format: {0}", ex.Message);
                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }
    }
}
