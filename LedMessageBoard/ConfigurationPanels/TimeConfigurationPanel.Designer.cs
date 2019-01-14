namespace LedMessageBoard.ConfigurationPanels
{
    partial class TimeConfigurationPanel
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
            this.label1 = new System.Windows.Forms.Label();
            this.TextBoxTimeFormat = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Time Format:";
            // 
            // TextBoxTimeFormat
            // 
            this.TextBoxTimeFormat.Location = new System.Drawing.Point(6, 53);
            this.TextBoxTimeFormat.Name = "TextBoxTimeFormat";
            this.TextBoxTimeFormat.Size = new System.Drawing.Size(198, 20);
            this.TextBoxTimeFormat.TabIndex = 1;
            // 
            // TimeConfigurationPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TextBoxTimeFormat);
            this.Controls.Add(this.label1);
            this.Name = "TimeConfigurationPanel";
            this.Size = new System.Drawing.Size(227, 86);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.TextBoxTimeFormat, 0);
            this.Controls.SetChildIndex(this.TextBoxTitle, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextBoxTimeFormat;
    }
}
