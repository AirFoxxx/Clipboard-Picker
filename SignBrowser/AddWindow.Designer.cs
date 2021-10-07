
namespace SignBrowser
{
    partial class AddWindow
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
            this.IdLabel = new System.Windows.Forms.Label();
            this.SignLabel = new System.Windows.Forms.Label();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.IdTextbox = new System.Windows.Forms.TextBox();
            this.SignTextbox = new System.Windows.Forms.TextBox();
            this.DescriptionTextbox = new System.Windows.Forms.TextBox();
            this.AddDBButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // IdLabel
            // 
            this.IdLabel.AutoSize = true;
            this.IdLabel.Location = new System.Drawing.Point(12, 16);
            this.IdLabel.Name = "IdLabel";
            this.IdLabel.Size = new System.Drawing.Size(60, 15);
            this.IdLabel.TabIndex = 0;
            this.IdLabel.Text = "Button ID:";
            // 
            // SignLabel
            // 
            this.SignLabel.AutoSize = true;
            this.SignLabel.Location = new System.Drawing.Point(12, 49);
            this.SignLabel.Name = "SignLabel";
            this.SignLabel.Size = new System.Drawing.Size(76, 15);
            this.SignLabel.TabIndex = 1;
            this.SignLabel.Text = "Sign to copy:";
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(12, 84);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(70, 15);
            this.DescriptionLabel.TabIndex = 2;
            this.DescriptionLabel.Text = "Description:";
            // 
            // IdTextbox
            // 
            this.IdTextbox.Enabled = false;
            this.IdTextbox.Location = new System.Drawing.Point(147, 13);
            this.IdTextbox.Name = "IdTextbox";
            this.IdTextbox.ReadOnly = true;
            this.IdTextbox.Size = new System.Drawing.Size(40, 23);
            this.IdTextbox.TabIndex = 3;
            this.IdTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.IdTextbox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // SignTextbox
            // 
            this.SignTextbox.Location = new System.Drawing.Point(147, 46);
            this.SignTextbox.Name = "SignTextbox";
            this.SignTextbox.Size = new System.Drawing.Size(40, 23);
            this.SignTextbox.TabIndex = 4;
            this.SignTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DescriptionTextbox
            // 
            this.DescriptionTextbox.Location = new System.Drawing.Point(92, 81);
            this.DescriptionTextbox.Name = "DescriptionTextbox";
            this.DescriptionTextbox.Size = new System.Drawing.Size(95, 23);
            this.DescriptionTextbox.TabIndex = 5;
            // 
            // AddDBButton
            // 
            this.AddDBButton.Location = new System.Drawing.Point(59, 125);
            this.AddDBButton.Name = "AddDBButton";
            this.AddDBButton.Size = new System.Drawing.Size(75, 23);
            this.AddDBButton.TabIndex = 6;
            this.AddDBButton.Text = "Add";
            this.AddDBButton.UseVisualStyleBackColor = true;
            this.AddDBButton.Click += new System.EventHandler(this.AddDBButton_Click);
            // 
            // AddWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(197, 173);
            this.Controls.Add(this.AddDBButton);
            this.Controls.Add(this.DescriptionTextbox);
            this.Controls.Add(this.SignTextbox);
            this.Controls.Add(this.IdTextbox);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.SignLabel);
            this.Controls.Add(this.IdLabel);
            this.Name = "AddWindow";
            this.Text = "Add button";
            this.Load += new System.EventHandler(this.AddWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label IdLabel;
        private System.Windows.Forms.Label SignLabel;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.TextBox IdTextbox;
        private System.Windows.Forms.TextBox SignTextbox;
        private System.Windows.Forms.TextBox DescriptionTextbox;
        private System.Windows.Forms.Button AddDBButton;
    }
}