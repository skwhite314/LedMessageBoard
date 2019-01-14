namespace LedMessageBoard.DisplayModification
{
    partial class NewDisplayDialog
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
            this.ButtonOK = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.PanelConfigurations = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ListBoxDisplayTypes = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // ButtonOK
            // 
            this.ButtonOK.Location = new System.Drawing.Point(12, 170);
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size(75, 23);
            this.ButtonOK.TabIndex = 1;
            this.ButtonOK.Text = "OK";
            this.ButtonOK.UseVisualStyleBackColor = true;
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(114, 170);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 2;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // PanelConfigurations
            // 
            this.PanelConfigurations.AutoSize = true;
            this.PanelConfigurations.Location = new System.Drawing.Point(237, 26);
            this.PanelConfigurations.Name = "PanelConfigurations";
            this.PanelConfigurations.Size = new System.Drawing.Size(200, 100);
            this.PanelConfigurations.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(234, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Configuration Properties";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Available Display Types:";
            // 
            // ListBoxDisplayTypes
            // 
            this.ListBoxDisplayTypes.FormattingEnabled = true;
            this.ListBoxDisplayTypes.Location = new System.Drawing.Point(12, 26);
            this.ListBoxDisplayTypes.Name = "ListBoxDisplayTypes";
            this.ListBoxDisplayTypes.Size = new System.Drawing.Size(177, 121);
            this.ListBoxDisplayTypes.Sorted = true;
            this.ListBoxDisplayTypes.TabIndex = 6;
            this.ListBoxDisplayTypes.SelectedValueChanged += new System.EventHandler(this.ListBoxDisplayTypes_SelectedValueChanged);
            // 
            // NewDisplayDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.ListBoxDisplayTypes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PanelConfigurations);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "NewDisplayDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create New Display";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonOK;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Panel PanelConfigurations;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox ListBoxDisplayTypes;
    }
}