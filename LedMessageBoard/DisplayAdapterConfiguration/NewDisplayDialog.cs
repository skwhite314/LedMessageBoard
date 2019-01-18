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
    internal partial class NewDisplayDialog : Form
    {
        private static Tuple<string, IConfigurationPanel>[] _panelChoices;

        private static Tuple<string, IConfigurationPanel>[] PanelChoices
        {
            get
            {
                if (_panelChoices == null)
                {
                    var panelTypes = Assembly.GetAssembly(typeof(IConfigurationPanel))
                         .GetTypes()
                         .Where(t => t.IsClass && !t.IsAbstract && typeof(IConfigurationPanel).IsAssignableFrom(t))
                         .ToArray();

                    var panels = panelTypes.Select(t => (IConfigurationPanel)Activator.CreateInstance(t)).ToArray();

                    _panelChoices = panels.Select(p => new Tuple<string, IConfigurationPanel>(p.GetDisplayAdapterType(), p)).ToArray();
                }

                return _panelChoices;
            }
        }

        public NewDisplayDialog()
        {
            InitializeComponent();

            this.ListBoxDisplayTypes.DisplayMember = "Item1";
            this.ListBoxDisplayTypes.Items.AddRange(PanelChoices);

            foreach (Control control in PanelChoices.Select(pc => pc.Item2))
            {
                this.PanelConfigurations.Controls.Add(control);
                control.Visible = false;
            }

            this.ShowConfigurationPanel();
        }

        public IDisplayAdapter GetDisplayAdapter()
        {
            if (this.ListBoxDisplayTypes.SelectedItem == null)
            {
                return null;
            }

            var result = ((Tuple<string, IConfigurationPanel>)this.ListBoxDisplayTypes.SelectedItem).Item2.CreateDisplayAdapter();

            return result;
        }

        private void ShowConfigurationPanel()
        {
            this.ButtonOK.Enabled = false;

            foreach (Control control in this.PanelConfigurations.Controls)
            {
                if (control is IConfigurationPanel cp)
                {
                    if (this.ListBoxDisplayTypes.SelectedItem != null &&
                        cp == ((Tuple<string, IConfigurationPanel>)this.ListBoxDisplayTypes.SelectedItem).Item2)
                    {
                        control.Visible = true;
                        control.BringToFront();
                        this.ButtonOK.Enabled = true;
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
