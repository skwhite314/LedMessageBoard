using LedMessageBoard.ConfigurationPanels;
using LedMessageBoard.DisplayAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LedMessageBoard.DisplayAdapterConfiguration
{
    public partial class ConfigureDisplayDialog : Form
    {
        private static IConfigurationPanel[] _panelChoices;

        private static IConfigurationPanel[] PanelChoices
        {
            get
            {
                if (_panelChoices == null)
                {
                    var panelTypes = Assembly.GetAssembly(typeof(IConfigurationPanel))
                         .GetTypes()
                         .Where(t => t.IsClass && !t.IsAbstract && typeof(IConfigurationPanel).IsAssignableFrom(t))
                         .ToArray();

                    _panelChoices = panelTypes.Select(t => (IConfigurationPanel)Activator.CreateInstance(t)).ToArray();
                }

                return _panelChoices;
            }
        }

        private IConfigurationPanel panel;

        public ConfigureDisplayDialog()
        {
            InitializeComponent();
        }

        public ConfigureDisplayDialog(IDisplayAdapter displayAdapter) : this()
        {
            this.panel = null;

            foreach (var p in PanelChoices)
            {
                if (p.PopulateFromDisplayAdapter(displayAdapter))
                {
                    this.panel = p;
                    break;
                }
            }

            if (this.panel == null) throw new ArgumentException("Unknown adapter type");

            var control = this.panel.ToControl();

            this.PanelConfigurations.Controls.Add(control);
            control.Visible = true;
        }

        public IDisplayAdapter GetDisplayAdapter()
        {
            if (this.panel == null) return null;

            return this.panel.CreateDisplayAdapter();
        }
    }
}
