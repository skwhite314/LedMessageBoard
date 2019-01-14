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

namespace LedMessageBoard.DisplayModification
{
    internal partial class NewDisplayDialog : Form
    {
        private static Tuple<string, IConfigurationPanel>[] panelChoices;

        private static Tuple<string, IConfigurationPanel>[] PanelChoices
        {
            get
            {
                if (panelChoices == null)
                {
                    var panelTypes = Assembly.GetAssembly(typeof(IConfigurationPanel))
                         .GetTypes()
                         .Where(t => t.IsClass && !t.IsAbstract && typeof(IConfigurationPanel).IsAssignableFrom(t))
                         .ToArray();

                    var panels = panelTypes.Select(t => (IConfigurationPanel)Activator.CreateInstance(t)).ToArray();

                    panelChoices = panels.Select(p => new Tuple<string, IConfigurationPanel>(p.GetDisplayAdapterType(), p)).ToArray();
                }

                return panelChoices;
            }
        }

        public NewDisplayDialog()
        {
            InitializeComponent();

            this.ListBoxDisplayTypes.DisplayMember = "Item1";
            this.ListBoxDisplayTypes.Items.AddRange(panelChoices);

            foreach (Control control in panelChoices.Select(pc => pc.Item2))
            {
                this.PanelConfigurations.Controls.Add(control);
                control.Visible = false;
            }
        }

        private void ShowConfigurationPanel()
        {
            foreach (Control control in this.PanelConfigurations.Controls)
            {
                if (control is IConfigurationPanel cp)
                {
                    if (cp == this.ListBoxDisplayTypes.SelectedItem)
                    {
                        control.Visible = true;
                        control.BringToFront();
                    }
                    else
                    {
                        control.Visible = false;
                    }
                }
            }
        }

        private void ListBoxDisplayTypes_SelectedValueChanged(object sender, EventArgs e)
        {
            this.ShowConfigurationPanel();
        }
    }
}
