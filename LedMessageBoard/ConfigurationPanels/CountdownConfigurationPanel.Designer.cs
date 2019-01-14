namespace LedMessageBoard.ConfigurationPanels
{
    partial class CountdownConfigurationPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DateTimePickerDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.DateTimePickerTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TextBoxFormat = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // DateTimePickerDate
            // 
            this.DateTimePickerDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DateTimePickerDate.Location = new System.Drawing.Point(6, 51);
            this.DateTimePickerDate.Name = "DateTimePickerDate";
            this.DateTimePickerDate.Size = new System.Drawing.Size(200, 20);
            this.DateTimePickerDate.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Target Date:";
            // 
            // DateTimePickerTime
            // 
            this.DateTimePickerTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DateTimePickerTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DateTimePickerTime.Location = new System.Drawing.Point(6, 102);
            this.DateTimePickerTime.Name = "DateTimePickerTime";
            this.DateTimePickerTime.ShowUpDown = true;
            this.DateTimePickerTime.Size = new System.Drawing.Size(200, 20);
            this.DateTimePickerTime.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Target Time:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(232, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Display Format:";
            // 
            // TextBoxFormat
            // 
            this.TextBoxFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TextBoxFormat.Location = new System.Drawing.Point(235, 51);
            this.TextBoxFormat.Name = "TextBoxFormat";
            this.TextBoxFormat.Size = new System.Drawing.Size(221, 20);
            this.TextBoxFormat.TabIndex = 5;
            // 
            // CountdownConfigurationPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TextBoxFormat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DateTimePickerTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DateTimePickerDate);
            this.Name = "CountdownConfigurationPanel";
            this.Size = new System.Drawing.Size(469, 138);
            this.Controls.SetChildIndex(this.DateTimePickerDate, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.DateTimePickerTime, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.TextBoxFormat, 0);
            this.Controls.SetChildIndex(this.TextBoxTitle, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DateTimePickerDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DateTimePickerTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TextBoxFormat;
    }
}
