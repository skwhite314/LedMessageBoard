namespace LedMessageBoard
{
    partial class ConfigurationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.ComboBoxBrightness = new System.Windows.Forms.ComboBox();
            this.ButtonApply = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TrackBarRefreshRate = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.TrackBarScrollRate = new System.Windows.Forms.TrackBar();
            this.LabelRefreshRate = new System.Windows.Forms.Label();
            this.LabelScrollRate = new System.Windows.Forms.Label();
            this.CheckedListBoxActiveDisplays = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TabControlConfigurationPanels = new System.Windows.Forms.TabControl();
            this.label5 = new System.Windows.Forms.Label();
            this.TrackBarStaticDisplayDuration = new System.Windows.Forms.TrackBar();
            this.LabelStaticDisplayDuration = new System.Windows.Forms.Label();
            this.ButtonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarRefreshRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarScrollRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarStaticDisplayDuration)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Brightness:";
            // 
            // ComboBoxBrightness
            // 
            this.ComboBoxBrightness.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxBrightness.FormattingEnabled = true;
            this.ComboBoxBrightness.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.ComboBoxBrightness.Location = new System.Drawing.Point(77, 6);
            this.ComboBoxBrightness.Name = "ComboBoxBrightness";
            this.ComboBoxBrightness.Size = new System.Drawing.Size(43, 21);
            this.ComboBoxBrightness.TabIndex = 1;
            // 
            // ButtonApply
            // 
            this.ButtonApply.Location = new System.Drawing.Point(464, 170);
            this.ButtonApply.Name = "ButtonApply";
            this.ButtonApply.Size = new System.Drawing.Size(75, 23);
            this.ButtonApply.TabIndex = 2;
            this.ButtonApply.Text = "Apply";
            this.ButtonApply.UseVisualStyleBackColor = true;
            this.ButtonApply.Click += new System.EventHandler(this.ButtonApply_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(126, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Refresh Rate (ms):";
            // 
            // TrackBarRefreshRate
            // 
            this.TrackBarRefreshRate.LargeChange = 10;
            this.TrackBarRefreshRate.Location = new System.Drawing.Point(227, 6);
            this.TrackBarRefreshRate.Maximum = 100;
            this.TrackBarRefreshRate.Minimum = 10;
            this.TrackBarRefreshRate.Name = "TrackBarRefreshRate";
            this.TrackBarRefreshRate.Size = new System.Drawing.Size(203, 45);
            this.TrackBarRefreshRate.TabIndex = 4;
            this.TrackBarRefreshRate.TickFrequency = 5;
            this.TrackBarRefreshRate.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.TrackBarRefreshRate.Value = 10;
            this.TrackBarRefreshRate.Scroll += new System.EventHandler(this.TrackBarRefreshRate_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(461, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Scroll Rate (ms):";
            // 
            // TrackBarScrollRate
            // 
            this.TrackBarScrollRate.LargeChange = 100;
            this.TrackBarScrollRate.Location = new System.Drawing.Point(551, 6);
            this.TrackBarScrollRate.Maximum = 2000;
            this.TrackBarScrollRate.Minimum = 10;
            this.TrackBarScrollRate.Name = "TrackBarScrollRate";
            this.TrackBarScrollRate.Size = new System.Drawing.Size(203, 45);
            this.TrackBarScrollRate.TabIndex = 6;
            this.TrackBarScrollRate.TickFrequency = 100;
            this.TrackBarScrollRate.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.TrackBarScrollRate.Value = 10;
            this.TrackBarScrollRate.Scroll += new System.EventHandler(this.TrackBarScrollRate_Scroll);
            // 
            // LabelRefreshRate
            // 
            this.LabelRefreshRate.AutoSize = true;
            this.LabelRefreshRate.Location = new System.Drawing.Point(436, 9);
            this.LabelRefreshRate.Name = "LabelRefreshRate";
            this.LabelRefreshRate.Size = new System.Drawing.Size(19, 13);
            this.LabelRefreshRate.TabIndex = 7;
            this.LabelRefreshRate.Text = "10";
            // 
            // LabelScrollRate
            // 
            this.LabelScrollRate.AutoSize = true;
            this.LabelScrollRate.Location = new System.Drawing.Point(760, 9);
            this.LabelScrollRate.Name = "LabelScrollRate";
            this.LabelScrollRate.Size = new System.Drawing.Size(19, 13);
            this.LabelScrollRate.TabIndex = 8;
            this.LabelScrollRate.Text = "10";
            // 
            // CheckedListBoxActiveDisplays
            // 
            this.CheckedListBoxActiveDisplays.CheckOnClick = true;
            this.CheckedListBoxActiveDisplays.FormattingEnabled = true;
            this.CheckedListBoxActiveDisplays.HorizontalScrollbar = true;
            this.CheckedListBoxActiveDisplays.Location = new System.Drawing.Point(12, 54);
            this.CheckedListBoxActiveDisplays.MultiColumn = true;
            this.CheckedListBoxActiveDisplays.Name = "CheckedListBoxActiveDisplays";
            this.CheckedListBoxActiveDisplays.Size = new System.Drawing.Size(418, 139);
            this.CheckedListBoxActiveDisplays.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Active Displays:";
            // 
            // TabControlConfigurationPanels
            // 
            this.TabControlConfigurationPanels.Location = new System.Drawing.Point(12, 214);
            this.TabControlConfigurationPanels.Name = "TabControlConfigurationPanels";
            this.TabControlConfigurationPanels.SelectedIndex = 0;
            this.TabControlConfigurationPanels.Size = new System.Drawing.Size(822, 436);
            this.TabControlConfigurationPanels.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(461, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Static Display Duration (s):";
            // 
            // TrackBarStaticDisplayDuration
            // 
            this.TrackBarStaticDisplayDuration.Location = new System.Drawing.Point(598, 54);
            this.TrackBarStaticDisplayDuration.Minimum = 1;
            this.TrackBarStaticDisplayDuration.Name = "TrackBarStaticDisplayDuration";
            this.TrackBarStaticDisplayDuration.Size = new System.Drawing.Size(156, 45);
            this.TrackBarStaticDisplayDuration.TabIndex = 13;
            this.TrackBarStaticDisplayDuration.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.TrackBarStaticDisplayDuration.Value = 1;
            this.TrackBarStaticDisplayDuration.Scroll += new System.EventHandler(this.TrackBarStaticDisplayDuration_Scroll);
            // 
            // LabelStaticDisplayDuration
            // 
            this.LabelStaticDisplayDuration.AutoSize = true;
            this.LabelStaticDisplayDuration.Location = new System.Drawing.Point(760, 54);
            this.LabelStaticDisplayDuration.Name = "LabelStaticDisplayDuration";
            this.LabelStaticDisplayDuration.Size = new System.Drawing.Size(13, 13);
            this.LabelStaticDisplayDuration.TabIndex = 14;
            this.LabelStaticDisplayDuration.Text = "5";
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(575, 170);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 15;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // ConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 662);
            this.ControlBox = false;
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.LabelStaticDisplayDuration);
            this.Controls.Add(this.TrackBarStaticDisplayDuration);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TabControlConfigurationPanels);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CheckedListBoxActiveDisplays);
            this.Controls.Add(this.LabelScrollRate);
            this.Controls.Add(this.LabelRefreshRate);
            this.Controls.Add(this.TrackBarScrollRate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TrackBarRefreshRate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ButtonApply);
            this.Controls.Add(this.ComboBoxBrightness);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigurationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LED Message Board";
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarRefreshRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarScrollRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarStaticDisplayDuration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ComboBoxBrightness;
        private System.Windows.Forms.Button ButtonApply;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar TrackBarRefreshRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar TrackBarScrollRate;
        private System.Windows.Forms.Label LabelRefreshRate;
        private System.Windows.Forms.Label LabelScrollRate;
        private System.Windows.Forms.CheckedListBox CheckedListBoxActiveDisplays;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl TabControlConfigurationPanels;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar TrackBarStaticDisplayDuration;
        private System.Windows.Forms.Label LabelStaticDisplayDuration;
        private System.Windows.Forms.Button ButtonCancel;
    }
}