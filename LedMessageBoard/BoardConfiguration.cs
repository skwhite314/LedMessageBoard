using LedMessageBoard.ConfigurationPanels;
using LedMessageBoard.DisplayAdapters;
using LedMessageBoard.DisplayModification;
using LedMessageBoard.Exceptions;
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
        #region Delegates for handling multithreading

        public delegate void ConfigurationUpdateHandler(object sender, EventArgs e);

        public event ConfigurationUpdateHandler OnConfigurationUpdated;

        #endregion

        public int Brightness
        {
            get
            {
                return int.Parse(this.ComboBoxBrightness.SelectedItem.ToString());
            }

            set
            {
                this.ComboBoxBrightness.SelectedItem = this.ComboBoxBrightness.Items.Contains(value.ToString())
                    ? value.ToString()
                    : this.ComboBoxBrightness.Items[ComboBoxBrightness.Items.Count - 1];
            }
        }

        public int RefreshRate
        {
            get
            {
                return this.TrackBarRefreshRate.Value;
            }

            set
            {
                if (value >= this.TrackBarRefreshRate.Minimum && value <= this.TrackBarRefreshRate.Maximum)
                {
                    this.TrackBarRefreshRate.Value = value;
                    this.TrackBarRefreshRate_Scroll(null, null);
                }
            }
        }

        public int ScrollRate
        {
            get
            {
                return this.TrackBarScrollRate.Value;
            }

            set
            {
                if (value >= this.TrackBarScrollRate.Minimum && value <= this.TrackBarScrollRate.Maximum)
                {
                    this.TrackBarScrollRate.Value = value;
                    this.TrackBarScrollRate_Scroll(null, null);
                }
            }
        }

        public int StaticDisplayDuration
        {
            get
            {
                return this.TrackBarStaticDisplayDuration.Value;
            }

            set
            {
                if (value >= this.TrackBarStaticDisplayDuration.Minimum && value <= this.TrackBarStaticDisplayDuration.Maximum)
                {
                    this.TrackBarStaticDisplayDuration.Value = value;
                    this.TrackBarStaticDisplayDuration_Scroll(null, null);
                }
            }
        }

        public BoardConfiguration()
        {
            InitializeComponent();

            this.SetButtonEnableds();
        }

        public BoardConfiguration(IDisplayAdapter[] displayAdapters) : this()
        {
            this.Initialize(displayAdapters);
        }

        public IDisplayAdapter[] GetDisplayAdapters()
        {
            var result = this.CheckedListBoxActiveDisplays.Items.OfType<IDisplayAdapter>().ToArray();
            return result;
        }

        public void UpdateDisplayAdapters(IDisplayAdapter[] displayAdapters)
        {
            this.Initialize(displayAdapters);
        }

        private void Initialize(IDisplayAdapter[] displayAdapters)
        {
            this.CheckedListBoxActiveDisplays.Items.Clear();

            this.CheckedListBoxActiveDisplays.Items.AddRange(displayAdapters);

            for (var i = 0; i < this.CheckedListBoxActiveDisplays.Items.Count; i++)
            {
                if (this.CheckedListBoxActiveDisplays.Items[i] is IDisplayAdapter da)
                    this.CheckedListBoxActiveDisplays.SetItemChecked(i, da.Active);
            }

            this.SetButtonEnableds();
        }

        private void SetButtonEnableds()
        {
            var empty = this.CheckedListBoxActiveDisplays.SelectedIndex < 0 ||
                        this.CheckedListBoxActiveDisplays.SelectedIndex >= this.CheckedListBoxActiveDisplays.Items.Count ||
                        this.CheckedListBoxActiveDisplays.Items.Count == 0;

            var attop = this.CheckedListBoxActiveDisplays.SelectedIndex == 0;

            var atbottom = this.CheckedListBoxActiveDisplays.SelectedIndex == this.CheckedListBoxActiveDisplays.Items.Count - 1;

            this.ButtonDelete.Enabled = !empty;

            this.ButtonMoveUp.Enabled = !empty && !attop;

            this.ButtonMoveDown.Enabled = !empty && !atbottom;
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
            this.SetButtonEnableds();
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (this.CheckedListBoxActiveDisplays.SelectedIndex < 0 ||
                this.CheckedListBoxActiveDisplays.SelectedIndex >= this.CheckedListBoxActiveDisplays.Items.Count)
            {
                return;
            }

            var da = (IDisplayAdapter)this.CheckedListBoxActiveDisplays.SelectedItem;

            var message = string.Format("Delete '{0}'?", da.Title);

            if (MessageBox.Show(message, "Question", MessageBoxButtons.OKCancel) == DialogResult.Cancel) return;

            this.CheckedListBoxActiveDisplays.Items.RemoveAt(this.CheckedListBoxActiveDisplays.SelectedIndex);

            this.OnConfigurationUpdated?.Invoke(sender, e);
        }

        private void ButtonNewDisplay_Click(object sender, EventArgs e)
        {
            var newDisplayDialog = new NewDisplayDialog();

            while (true)
            {
                var dialogResult = newDisplayDialog.ShowDialog(this);

                if (dialogResult == DialogResult.Cancel)
                {
                    newDisplayDialog.Close();
                    return;
                }

                try
                {
                    var da = newDisplayDialog.GetDisplayAdapter();

                    newDisplayDialog.Close();

                    this.CheckedListBoxActiveDisplays.Items.Add(da, true);
                    this.CheckedListBoxActiveDisplays.SelectedItem = da;

                    this.OnConfigurationUpdated?.Invoke(sender, e);

                    return;
                }
                catch (ConfigurationException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ButtonMoveUp_Click(object sender, EventArgs e)
        {
            var index = this.CheckedListBoxActiveDisplays.SelectedIndex;
            var da = (IDisplayAdapter)this.CheckedListBoxActiveDisplays.SelectedItem;

            this.CheckedListBoxActiveDisplays.Items.RemoveAt(index--);
            this.CheckedListBoxActiveDisplays.Items.Insert(index, da);
            this.CheckedListBoxActiveDisplays.SetItemChecked(index, da.Active);
            this.CheckedListBoxActiveDisplays.SelectedIndex = index;
        }

        private void ButtonMoveDown_Click(object sender, EventArgs e)
        {
            var index = this.CheckedListBoxActiveDisplays.SelectedIndex;
            var da = (IDisplayAdapter)this.CheckedListBoxActiveDisplays.SelectedItem;

            this.CheckedListBoxActiveDisplays.Items.RemoveAt(index++);
            this.CheckedListBoxActiveDisplays.Items.Insert(index, da);
            this.CheckedListBoxActiveDisplays.SetItemChecked(index, da.Active);
            this.CheckedListBoxActiveDisplays.SelectedIndex = index;
        }

        private void ButtonApply_Click(object sender, EventArgs e)
        {
            if (this.OnConfigurationUpdated != null) this.OnConfigurationUpdated(sender, e);
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            if (this.OnConfigurationUpdated != null) this.OnConfigurationUpdated(sender, e);

            this.Visible = false;
        }

        #endregion
    }
}
