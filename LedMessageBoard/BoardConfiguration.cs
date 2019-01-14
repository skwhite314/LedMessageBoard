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

namespace LedMessageBoard
{
    internal partial class BoardConfiguration : Form
    {
        public BoardConfiguration()
        {
            InitializeComponent();
        }

        public BoardConfiguration(IDisplayAdapter[] displayAdapters) : this()
        {
            this.CheckedListBoxActiveDisplays.Items.AddRange(displayAdapters);

            for (var i = 0; i < this.CheckedListBoxActiveDisplays.Items.Count; i++)
            {
                if (this.CheckedListBoxActiveDisplays.Items[i] is IDisplayAdapter da)
                    this.CheckedListBoxActiveDisplays.SetItemChecked(i, da.Active);
            }
        }

        public IDisplayAdapter[] GetDisplayAdapters()
        {
            var result = this.CheckedListBoxActiveDisplays.Items.OfType<IDisplayAdapter>().ToArray();
            return result;
        }

        private static void SetButtonEnabled(bool value, params Button[] buttons)
        {
            foreach (var button in buttons) button.Enabled = value;
        }

        #region Event Handlers

        private void TrackBarRefreshRate_Scroll(object sender, EventArgs e)
        {
            this.LabelRefreshRate.Text = this.TrackBarRefreshRate.Value.ToString();
        }

        private void TrackBarScrollRate_Scroll(object sender, EventArgs e)
        {
            this.LabelScrollRate.Text = this.TrackBarScrollRate.Value.ToString();
        }

        private void TrackBarStaticDisplayDuration_Scroll(object sender, EventArgs e)
        {
            this.LabelStaticDisplayDuration.Text = this.TrackBarStaticDisplayDuration.Value.ToString();
        }

        private void CheckedListBoxActiveDisplays_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (this.CheckedListBoxActiveDisplays.Items[e.Index] is IDisplayAdapter da)
                da.Active = (e.NewValue == CheckState.Checked);
        }

        private void CheckedListBoxActiveDisplays_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (this.CheckedListBoxActiveDisplays.SelectedIndex < 0 ||
                this.CheckedListBoxActiveDisplays.SelectedIndex >= this.CheckedListBoxActiveDisplays.Items.Count ||
                this.CheckedListBoxActiveDisplays.Items.Count == 0)
            {
                SetButtonEnabled(false, this.ButtonDelete, this.ButtonMoveDown, this.ButtonMoveUp);
                return;
            }

            if (this.CheckedListBoxActiveDisplays.SelectedIndex == 0)
            {
                SetButtonEnabled(false, this.ButtonMoveUp);
                SetButtonEnabled(true, this.ButtonDelete, this.ButtonMoveDown);
                return;
            }

            if (this.CheckedListBoxActiveDisplays.SelectedIndex == this.CheckedListBoxActiveDisplays.Items.Count - 1)
            {
                SetButtonEnabled(false, this.ButtonMoveDown);
                SetButtonEnabled(true, this.ButtonDelete, this.ButtonMoveUp);
            }
        }

        #endregion
    }
}
