using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LedMessageBoard.ConfigurationPanels
{
    /// <summary>
    /// Parent class for all configuration panels. Cannot be abstract as that causes issues with the designer.
    /// </summary>
    public partial class ConfigurationPanel : UserControl
    {
        public ConfigurationPanel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Resets the configuration panel.
        /// </summary>
        public virtual void Reset()
        {
        }

        /// <summary>
        /// Event handling method for when the user is done making changes to the configuration.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void OnApply(object sender, CancelEventArgs e)
        {
        }
    }
}
