namespace LedMessageBoard
{
    partial class BoardConfiguration
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
            this.TrackBarRefreshRate = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.LabelRefreshRate = new System.Windows.Forms.Label();
            this.LabelStaticDisplayDuration = new System.Windows.Forms.Label();
            this.TrackBarStaticDisplayDuration = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.LabelScrollRate = new System.Windows.Forms.Label();
            this.TrackBarScrollRate = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CheckedListBoxActiveDisplays = new System.Windows.Forms.CheckedListBox();
            this.GroupBoxGlobalSettings = new System.Windows.Forms.GroupBox();
            this.ButtonApply = new System.Windows.Forms.Button();
            this.ButtonClose = new System.Windows.Forms.Button();
            this.ButtonNewDisplay = new System.Windows.Forms.Button();
            this.ButtonMoveUp = new System.Windows.Forms.Button();
            this.ButtonMoveDown = new System.Windows.Forms.Button();
            this.ButtonDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarRefreshRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarStaticDisplayDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarScrollRate)).BeginInit();
            this.GroupBoxGlobalSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 22);
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
            this.ComboBoxBrightness.Location = new System.Drawing.Point(73, 19);
            this.ComboBoxBrightness.Name = "ComboBoxBrightness";
            this.ComboBoxBrightness.Size = new System.Drawing.Size(43, 21);
            this.ComboBoxBrightness.TabIndex = 1;
            // 
            // TrackBarRefreshRate
            // 
            this.TrackBarRefreshRate.LargeChange = 10;
            this.TrackBarRefreshRate.Location = new System.Drawing.Point(145, 59);
            this.TrackBarRefreshRate.Maximum = 100;
            this.TrackBarRefreshRate.Minimum = 10;
            this.TrackBarRefreshRate.Name = "TrackBarRefreshRate";
            this.TrackBarRefreshRate.Size = new System.Drawing.Size(203, 45);
            this.TrackBarRefreshRate.TabIndex = 6;
            this.TrackBarRefreshRate.TickFrequency = 5;
            this.TrackBarRefreshRate.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.TrackBarRefreshRate.Value = 10;
            this.TrackBarRefreshRate.Scroll += new System.EventHandler(this.TrackBarRefreshRate_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Refresh Rate (ms):";
            // 
            // LabelRefreshRate
            // 
            this.LabelRefreshRate.AutoSize = true;
            this.LabelRefreshRate.Location = new System.Drawing.Point(354, 62);
            this.LabelRefreshRate.Name = "LabelRefreshRate";
            this.LabelRefreshRate.Size = new System.Drawing.Size(19, 13);
            this.LabelRefreshRate.TabIndex = 8;
            this.LabelRefreshRate.Text = "10";
            // 
            // LabelStaticDisplayDuration
            // 
            this.LabelStaticDisplayDuration.AutoSize = true;
            this.LabelStaticDisplayDuration.Location = new System.Drawing.Point(307, 161);
            this.LabelStaticDisplayDuration.Name = "LabelStaticDisplayDuration";
            this.LabelStaticDisplayDuration.Size = new System.Drawing.Size(13, 13);
            this.LabelStaticDisplayDuration.TabIndex = 20;
            this.LabelStaticDisplayDuration.Text = "5";
            // 
            // TrackBarStaticDisplayDuration
            // 
            this.TrackBarStaticDisplayDuration.Location = new System.Drawing.Point(145, 161);
            this.TrackBarStaticDisplayDuration.Minimum = 1;
            this.TrackBarStaticDisplayDuration.Name = "TrackBarStaticDisplayDuration";
            this.TrackBarStaticDisplayDuration.Size = new System.Drawing.Size(156, 45);
            this.TrackBarStaticDisplayDuration.TabIndex = 19;
            this.TrackBarStaticDisplayDuration.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.TrackBarStaticDisplayDuration.Value = 1;
            this.TrackBarStaticDisplayDuration.Scroll += new System.EventHandler(this.TrackBarStaticDisplayDuration_Scroll);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Static Display Duration (s):";
            // 
            // LabelScrollRate
            // 
            this.LabelScrollRate.AutoSize = true;
            this.LabelScrollRate.Location = new System.Drawing.Point(351, 116);
            this.LabelScrollRate.Name = "LabelScrollRate";
            this.LabelScrollRate.Size = new System.Drawing.Size(19, 13);
            this.LabelScrollRate.TabIndex = 17;
            this.LabelScrollRate.Text = "10";
            // 
            // TrackBarScrollRate
            // 
            this.TrackBarScrollRate.LargeChange = 100;
            this.TrackBarScrollRate.Location = new System.Drawing.Point(145, 110);
            this.TrackBarScrollRate.Maximum = 2000;
            this.TrackBarScrollRate.Minimum = 10;
            this.TrackBarScrollRate.Name = "TrackBarScrollRate";
            this.TrackBarScrollRate.Size = new System.Drawing.Size(203, 45);
            this.TrackBarScrollRate.TabIndex = 16;
            this.TrackBarScrollRate.TickFrequency = 100;
            this.TrackBarScrollRate.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.TrackBarScrollRate.Value = 10;
            this.TrackBarScrollRate.Scroll += new System.EventHandler(this.TrackBarScrollRate_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Scroll Rate (ms):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 269);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Active Displays:";
            // 
            // CheckedListBoxActiveDisplays
            // 
            this.CheckedListBoxActiveDisplays.CheckOnClick = true;
            this.CheckedListBoxActiveDisplays.FormattingEnabled = true;
            this.CheckedListBoxActiveDisplays.HorizontalScrollbar = true;
            this.CheckedListBoxActiveDisplays.Location = new System.Drawing.Point(15, 285);
            this.CheckedListBoxActiveDisplays.MultiColumn = true;
            this.CheckedListBoxActiveDisplays.Name = "CheckedListBoxActiveDisplays";
            this.CheckedListBoxActiveDisplays.Size = new System.Drawing.Size(317, 199);
            this.CheckedListBoxActiveDisplays.TabIndex = 21;
            this.CheckedListBoxActiveDisplays.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.CheckedListBoxActiveDisplays_ItemCheck);
            this.CheckedListBoxActiveDisplays.SelectedIndexChanged += new System.EventHandler(this.CheckedListBoxActiveDisplays_SelectedIndexChanged);
            // 
            // GroupBoxGlobalSettings
            // 
            this.GroupBoxGlobalSettings.Controls.Add(this.ComboBoxBrightness);
            this.GroupBoxGlobalSettings.Controls.Add(this.label1);
            this.GroupBoxGlobalSettings.Controls.Add(this.TrackBarRefreshRate);
            this.GroupBoxGlobalSettings.Controls.Add(this.label2);
            this.GroupBoxGlobalSettings.Controls.Add(this.LabelRefreshRate);
            this.GroupBoxGlobalSettings.Controls.Add(this.LabelStaticDisplayDuration);
            this.GroupBoxGlobalSettings.Controls.Add(this.TrackBarScrollRate);
            this.GroupBoxGlobalSettings.Controls.Add(this.TrackBarStaticDisplayDuration);
            this.GroupBoxGlobalSettings.Controls.Add(this.label5);
            this.GroupBoxGlobalSettings.Controls.Add(this.label3);
            this.GroupBoxGlobalSettings.Controls.Add(this.LabelScrollRate);
            this.GroupBoxGlobalSettings.Location = new System.Drawing.Point(12, 12);
            this.GroupBoxGlobalSettings.Name = "GroupBoxGlobalSettings";
            this.GroupBoxGlobalSettings.Size = new System.Drawing.Size(409, 228);
            this.GroupBoxGlobalSettings.TabIndex = 25;
            this.GroupBoxGlobalSettings.TabStop = false;
            this.GroupBoxGlobalSettings.Text = "Global Settings";
            // 
            // ButtonApply
            // 
            this.ButtonApply.Location = new System.Drawing.Point(447, 29);
            this.ButtonApply.Name = "ButtonApply";
            this.ButtonApply.Size = new System.Drawing.Size(75, 23);
            this.ButtonApply.TabIndex = 21;
            this.ButtonApply.Text = "Apply";
            this.ButtonApply.UseVisualStyleBackColor = true;
            this.ButtonApply.Click += new System.EventHandler(this.ButtonApply_Click);
            // 
            // ButtonClose
            // 
            this.ButtonClose.Location = new System.Drawing.Point(447, 74);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(75, 23);
            this.ButtonClose.TabIndex = 26;
            this.ButtonClose.Text = "Close";
            this.ButtonClose.UseVisualStyleBackColor = true;
            this.ButtonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // ButtonNewDisplay
            // 
            this.ButtonNewDisplay.Location = new System.Drawing.Point(338, 446);
            this.ButtonNewDisplay.Name = "ButtonNewDisplay";
            this.ButtonNewDisplay.Size = new System.Drawing.Size(83, 23);
            this.ButtonNewDisplay.TabIndex = 27;
            this.ButtonNewDisplay.Text = "New Display...";
            this.ButtonNewDisplay.UseVisualStyleBackColor = true;
            this.ButtonNewDisplay.Click += new System.EventHandler(this.ButtonNewDisplay_Click);
            // 
            // ButtonMoveUp
            // 
            this.ButtonMoveUp.Location = new System.Drawing.Point(338, 304);
            this.ButtonMoveUp.Name = "ButtonMoveUp";
            this.ButtonMoveUp.Size = new System.Drawing.Size(75, 23);
            this.ButtonMoveUp.TabIndex = 28;
            this.ButtonMoveUp.Text = "Move Up";
            this.ButtonMoveUp.UseVisualStyleBackColor = true;
            this.ButtonMoveUp.Click += new System.EventHandler(this.ButtonMoveUp_Click);
            // 
            // ButtonMoveDown
            // 
            this.ButtonMoveDown.Location = new System.Drawing.Point(338, 333);
            this.ButtonMoveDown.Name = "ButtonMoveDown";
            this.ButtonMoveDown.Size = new System.Drawing.Size(75, 23);
            this.ButtonMoveDown.TabIndex = 29;
            this.ButtonMoveDown.Text = "Move Down";
            this.ButtonMoveDown.UseVisualStyleBackColor = true;
            this.ButtonMoveDown.Click += new System.EventHandler(this.ButtonMoveDown_Click);
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.Location = new System.Drawing.Point(338, 403);
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.Size = new System.Drawing.Size(83, 23);
            this.ButtonDelete.TabIndex = 30;
            this.ButtonDelete.Text = "Delete...";
            this.ButtonDelete.UseVisualStyleBackColor = true;
            this.ButtonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // BoardConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 497);
            this.ControlBox = false;
            this.Controls.Add(this.ButtonDelete);
            this.Controls.Add(this.ButtonMoveDown);
            this.Controls.Add(this.ButtonMoveUp);
            this.Controls.Add(this.ButtonNewDisplay);
            this.Controls.Add(this.ButtonClose);
            this.Controls.Add(this.ButtonApply);
            this.Controls.Add(this.GroupBoxGlobalSettings);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CheckedListBoxActiveDisplays);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "BoardConfiguration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LED Message Board";
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarRefreshRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarStaticDisplayDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarScrollRate)).EndInit();
            this.GroupBoxGlobalSettings.ResumeLayout(false);
            this.GroupBoxGlobalSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ComboBoxBrightness;
        private System.Windows.Forms.TrackBar TrackBarRefreshRate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LabelRefreshRate;
        private System.Windows.Forms.Label LabelStaticDisplayDuration;
        private System.Windows.Forms.TrackBar TrackBarStaticDisplayDuration;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LabelScrollRate;
        private System.Windows.Forms.TrackBar TrackBarScrollRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox CheckedListBoxActiveDisplays;
        private System.Windows.Forms.GroupBox GroupBoxGlobalSettings;
        private System.Windows.Forms.Button ButtonApply;
        private System.Windows.Forms.Button ButtonClose;
        private System.Windows.Forms.Button ButtonNewDisplay;
        private System.Windows.Forms.Button ButtonMoveUp;
        private System.Windows.Forms.Button ButtonMoveDown;
        private System.Windows.Forms.Button ButtonDelete;
    }
}