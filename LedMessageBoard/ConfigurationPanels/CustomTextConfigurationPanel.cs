using System.ComponentModel;
using LedMessageBoard.DisplayAdapters;
using System;
using System.Windows.Forms;
using LedMessageBoard.Exceptions;

namespace LedMessageBoard.ConfigurationPanels
{
    /// <summary>
    /// Collects configuration information for displaying custom text
    /// </summary>
    internal partial class CustomTextConfigurationPanel : ConfigurationPanel, IConfigurationPanel
    {
        public CustomTextConfigurationPanel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates a display adapter based on the entered values
        /// </summary>
        /// <exception cref="DisplayConfigurationException"/>
        /// <returns>A countdown display adapter</returns>
        public IDisplayAdapter CreateDisplayAdapter()
        {
            if (string.IsNullOrWhiteSpace(this.TextBoxTitle.Text))
            {
                throw new DisplayConfigurationException("A display title is required.");
            }

            if (string.IsNullOrWhiteSpace(this.TextBoxMessage.Text))
            {
                throw new DisplayConfigurationException("A message is required.");
            }

            var result = new CustomTextDisplayAdapter(this.TextBoxMessage.Text, this.TextBoxTitle.Text);

            return result;
        }

        public ConfigurationPanel ToControl()
        {
            return this;
        }

        public string GetDisplayAdapterType()
        {
            return LedMessageBoard.Properties.Resources.CustomTextDisplayType;
        }

        #region Overridden Methods

        public override bool PopulateFromDisplayAdapter(IDisplayAdapter displayAdapter)
        {
            if (displayAdapter is CustomTextDisplayAdapter da)
            {
                this.TextBoxTitle.Text = da.Title;
                this.TextBoxMessage.Text = da.Message;

                return true;
            }

            return false;
        }

        #endregion
    }
}
