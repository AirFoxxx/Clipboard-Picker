
namespace SignBrowser
{
    partial class RemoveWindow
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
            this.RemoveLabel = new System.Windows.Forms.Label();
            this.SignTextbox = new System.Windows.Forms.TextBox();
            this.RecursiveCheckbox = new System.Windows.Forms.CheckBox();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RemoveLabel
            // 
            this.RemoveLabel.AutoSize = true;
            this.RemoveLabel.Location = new System.Drawing.Point(13, 13);
            this.RemoveLabel.Name = "RemoveLabel";
            this.RemoveLabel.Size = new System.Drawing.Size(128, 15);
            this.RemoveLabel.TabIndex = 0;
            this.RemoveLabel.Text = "Button sign to remove:";
            // 
            // SignTextbox
            // 
            this.SignTextbox.Location = new System.Drawing.Point(157, 10);
            this.SignTextbox.Name = "SignTextbox";
            this.SignTextbox.Size = new System.Drawing.Size(37, 23);
            this.SignTextbox.TabIndex = 1;
            // 
            // RecursiveCheckbox
            // 
            this.RecursiveCheckbox.AutoSize = true;
            this.RecursiveCheckbox.Location = new System.Drawing.Point(42, 49);
            this.RecursiveCheckbox.Name = "RecursiveCheckbox";
            this.RecursiveCheckbox.Size = new System.Drawing.Size(128, 19);
            this.RecursiveCheckbox.TabIndex = 2;
            this.RecursiveCheckbox.Text = "Remove recursively";
            this.RecursiveCheckbox.UseVisualStyleBackColor = true;
            // 
            // RemoveButton
            // 
            this.RemoveButton.Location = new System.Drawing.Point(75, 92);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveButton.TabIndex = 3;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // RemoveWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(219, 127);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.RecursiveCheckbox);
            this.Controls.Add(this.SignTextbox);
            this.Controls.Add(this.RemoveLabel);
            this.Name = "RemoveWindow";
            this.Text = "Remove button";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label RemoveLabel;
        private System.Windows.Forms.TextBox SignTextbox;
        private System.Windows.Forms.CheckBox RecursiveCheckbox;
        private System.Windows.Forms.Button RemoveButton;
    }
}