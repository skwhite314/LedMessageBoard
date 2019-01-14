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
    /// Parent class for all configuration panels. Cannot be abstract as that causes issues with the designer.
    /// </summary>
    internal partial class ConfigurationPanel : UserControl
    {
        public ConfigurationPanel()
        {
            InitializeComponent();
        }

        public virtual bool PopulateFromDisplayAdapter(IDisplayAdapter displayAdapter)
        {
            return false;
        }
    }
}
