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
using LedMessageBoard.Exceptions;

namespace LedMessageBoard.ConfigurationPanels
{
    /// <summary>
    /// Collects configuration information for counting down the time to a specified date/time
    /// </summary>
    internal partial class CountdownConfigurationPanel : ConfigurationPanel, IConfigurationPanel
    {
        public CountdownConfigurationPanel() : base()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates a display adapter based on the entered values
        /// </summary>
        /// <exception cref="ConfigurationException"/>
        /// <returns>A countdown display adapter</returns>
        public IDisplayAdapter CreateDisplayAdapter()
        {
            if (string.IsNullOrWhiteSpace(this.TextBoxTitle.Text))
            {
                throw new ConfigurationException("A display title is required.");
            }

            var format = this.TextBoxFormat.Text;

            var timespan = new TimeSpan(0, 0, 1);

            try
            {
                timespan.ToString(format);
            }
            catch (FormatException ex)
            {
                var message = string.Format("Invalid TimeSpan format: {0}", ex.Message);

                throw new ConfigurationException(message, ex);
            }

            var date = this.DateTimePickerDate.Value;
            var time = this.DateTimePickerTime.Value;

            var target = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);

            var result = new CountdownDisplayAdapter(target, format, this.TextBoxTitle.Text);

            return result;
        }

        public ConfigurationPanel ToControl()
        {
            return this;
        }

        public string GetDisplayAdapterType()
        {
            return LedMessageBoard.Properties.Resources.CountdownDisplayType;
        }

        #region Overridden Methods

        public override bool PopulateFromDisplayAdapter(IDisplayAdapter displayAdapter)
        {
            if (displayAdapter is CountdownDisplayAdapter da)
            {
                this.TextBoxTitle.Text = da.Title;
                this.DateTimePickerDate.Value = da.Target;
                this.DateTimePickerTime.Value = da.Target;
                this.TextBoxFormat.Text = da.TimeSpanFormat;

                return true;
            }

            return false;
        }

        #endregion
    }
}
