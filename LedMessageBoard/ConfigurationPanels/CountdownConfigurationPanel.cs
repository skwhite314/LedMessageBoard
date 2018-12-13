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
    /// Collects configuration information for counting down the time to a specified date/time
    /// </summary>
    internal partial class CountdownConfigurationPanel : ConfigurationPanel, IConfigurationPanel
    {
        public CountdownConfigurationPanel()
        {
            InitializeComponent();

            this.Reset();
        }

        public IDisplayAdapter DisplayAdapter { get; private set; }

        public void Initialize(bool makeActive)
        {
            var target = LedMessageBoard.Properties.Settings.Default.CountdownConfigurationPanel_Target;
            var format = LedMessageBoard.Properties.Settings.Default.CountdownConfigurationPanel_Format;
            var timespan = new TimeSpan(0, 0, LedMessageBoard.Properties.Settings.Default.Global_StaticDisplayDuration);

            this.DisplayAdapter = new CountdownDisplayAdapter(target, format, timespan);
            this.DisplayAdapter.Active = makeActive;
        }

        public ConfigurationPanel ToControl()
        {
            return this;
        }

        #region Overridden Methods

        public override void Reset()
        {
            if (LedMessageBoard.Properties.Settings.Default.CountdownConfigurationPanel_Target < DateTimePicker.MinimumDateTime ||
                LedMessageBoard.Properties.Settings.Default.CountdownConfigurationPanel_Target > DateTimePicker.MaximumDateTime)
            {
                LedMessageBoard.Properties.Settings.Default.CountdownConfigurationPanel_Target = DateTime.Now + new TimeSpan(365, 0, 0, 0);
                LedMessageBoard.Properties.Settings.Default.Save();
            }

            this.DateTimePickerDate.Value = LedMessageBoard.Properties.Settings.Default.CountdownConfigurationPanel_Target;
            this.DateTimePickerTime.Value = LedMessageBoard.Properties.Settings.Default.CountdownConfigurationPanel_Target;

            this.TextBoxFormat.Text = LedMessageBoard.Properties.Settings.Default.CountdownConfigurationPanel_Format;
        }

        public override void OnApply(object sender, CancelEventArgs e)
        {
            var format = this.TextBoxFormat.Text;

            var timespan = new TimeSpan(0, 0, 1);

            try
            {
                timespan.ToString(format);
            }
            catch (FormatException ex)
            {
                var message = string.Format("Invalid TimeSpan format: {0}", ex.Message);
                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;

                return;
            }

            var date = this.DateTimePickerDate.Value;
            var time = this.DateTimePickerTime.Value;

            var target = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);

            LedMessageBoard.Properties.Settings.Default.CountdownConfigurationPanel_Target = target;
            LedMessageBoard.Properties.Settings.Default.CountdownConfigurationPanel_Format = format;

            LedMessageBoard.Properties.Settings.Default.Save();
        }

        #endregion
    }
}
