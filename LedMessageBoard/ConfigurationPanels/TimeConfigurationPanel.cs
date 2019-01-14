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
    /// Collects configuration information for displaying the current time
    /// </summary>
    internal partial class TimeConfigurationPanel : ConfigurationPanel, IConfigurationPanel
    {
        public TimeConfigurationPanel()
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

            if (string.IsNullOrWhiteSpace(this.TextBoxTimeFormat.Text))
            {
                throw new ConfigurationException("A time format is required.");
            }

            try
            {
                DateTime.Now.ToString(this.TextBoxTimeFormat.Text);
            }
            catch (Exception ex)
            {
                var message = string.Format("Invalid DateTime format: {0}", ex.Message);
                throw new ConfigurationException(message, ex);
            }

            var result = new TimeDisplayAdapter(this.TextBoxTimeFormat.Text, this.TextBoxTitle.Text);

            return result;
        }

        public string GetDisplayAdapterType()
        {
            return LedMessageBoard.Properties.Resources.TimeDisplayType;
        }

        public ConfigurationPanel ToControl()
        {
            return this;
        }

        #region Overridden Methods

        public override bool PopulateFromDisplayAdapter(IDisplayAdapter displayAdapter)
        {
            if (displayAdapter is TimeDisplayAdapter da)
            {
                this.TextBoxTitle.Text = da.Title;
                this.TextBoxTimeFormat.Text = da.TimeFormat;

                return true;
            }

            return false;
        }

        #endregion
    }
}
