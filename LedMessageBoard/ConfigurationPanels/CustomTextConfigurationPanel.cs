using System.ComponentModel;
using LedMessageBoard.DisplayAdapters;
using System;
using System.Windows.Forms;

namespace LedMessageBoard.ConfigurationPanels
{
    /// <summary>
    /// Collects configuration information for displaying custom text
    /// </summary>
    internal partial class CustomTextConfigurationPanel : ConfigurationPanel, IConfigurationPanel
    {
        public IDisplayAdapter DisplayAdapter { get; private set; }

        public CustomTextConfigurationPanel()
        {
            InitializeComponent();

            this.Reset();
        }

        public void Initialize(bool makeActive)
        {
            var timespan = new TimeSpan(0, 0, LedMessageBoard.Properties.Settings.Default.Global_StaticDisplayDuration);
            this.DisplayAdapter = new CustomTextDisplayAdapter(LedMessageBoard.Properties.Settings.Default.CustomTextConfigurationPanel_Message, timespan);
            this.DisplayAdapter.Active = makeActive;
        }

        public ConfigurationPanel ToControl()
        {
            return this;
        }

        #region Overridden Methods

        public override void Reset()
        {
            this.TextBoxMessage.Text = LedMessageBoard.Properties.Settings.Default.CustomTextConfigurationPanel_Message;
        }

        public override void OnApply(object sender, CancelEventArgs e)
        {
            LedMessageBoard.Properties.Settings.Default.CustomTextConfigurationPanel_Message = this.TextBoxMessage.Text;
            LedMessageBoard.Properties.Settings.Default.Save();
        }

        #endregion
    }
}
