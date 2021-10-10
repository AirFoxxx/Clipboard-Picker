
namespace SignBrowser
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.HeaderLabel = new System.Windows.Forms.Label();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.AddButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.UndertextLabel = new System.Windows.Forms.Label();
            this.ScalingTrackbar = new System.Windows.Forms.TrackBar();
            this.RatioTrackbar = new System.Windows.Forms.TrackBar();
            this.OffsetTrackbar = new System.Windows.Forms.TrackBar();
            this.ScalingLabel = new System.Windows.Forms.Label();
            this.RatioLabel = new System.Windows.Forms.Label();
            this.OffsetLabel = new System.Windows.Forms.Label();
            this.DescriptionTextbox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ScalingTrackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RatioTrackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OffsetTrackbar)).BeginInit();
            this.SuspendLayout();
            // 
            // HeaderLabel
            // 
            this.HeaderLabel.AutoSize = true;
            this.HeaderLabel.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.HeaderLabel.Location = new System.Drawing.Point(119, 9);
            this.HeaderLabel.Name = "HeaderLabel";
            this.HeaderLabel.Size = new System.Drawing.Size(270, 33);
            this.HeaderLabel.TabIndex = 0;
            this.HeaderLabel.Text = "Basic ClipBoard Library";
            this.HeaderLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(127, 42);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(255, 15);
            this.DescriptionLabel.TabIndex = 1;
            this.DescriptionLabel.Text = "Click on a sign to copy it, or create a new one...";
            // 
            // MainPanel
            // 
            this.MainPanel.AutoScroll = true;
            this.MainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainPanel.Location = new System.Drawing.Point(10, 75);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(402, 450);
            this.MainPanel.TabIndex = 2;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(10, 46);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(86, 23);
            this.AddButton.TabIndex = 3;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(445, 46);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(84, 23);
            this.DeleteButton.TabIndex = 3;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            // 
            // UndertextLabel
            // 
            this.UndertextLabel.AutoSize = true;
            this.UndertextLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.UndertextLabel.ForeColor = System.Drawing.Color.Gray;
            this.UndertextLabel.Location = new System.Drawing.Point(53, 528);
            this.UndertextLabel.Name = "UndertextLabel";
            this.UndertextLabel.Size = new System.Drawing.Size(297, 13);
            this.UndertextLabel.TabIndex = 4;
            this.UndertextLabel.Text = "© Copyright Andrew Coachman 2021, all rights included";
            // 
            // ScalingTrackbar
            // 
            this.ScalingTrackbar.LargeChange = 2;
            this.ScalingTrackbar.Location = new System.Drawing.Point(426, 125);
            this.ScalingTrackbar.Maximum = 50;
            this.ScalingTrackbar.Minimum = 10;
            this.ScalingTrackbar.Name = "ScalingTrackbar";
            this.ScalingTrackbar.Size = new System.Drawing.Size(113, 45);
            this.ScalingTrackbar.TabIndex = 5;
            this.ScalingTrackbar.Value = 10;
            this.ScalingTrackbar.Scroll += new System.EventHandler(this.ScalingTrackbar_Scroll);
            // 
            // RatioTrackbar
            // 
            this.RatioTrackbar.LargeChange = 2;
            this.RatioTrackbar.Location = new System.Drawing.Point(426, 187);
            this.RatioTrackbar.Maximum = 20;
            this.RatioTrackbar.Minimum = 1;
            this.RatioTrackbar.Name = "RatioTrackbar";
            this.RatioTrackbar.Size = new System.Drawing.Size(113, 45);
            this.RatioTrackbar.TabIndex = 5;
            this.RatioTrackbar.Value = 1;
            this.RatioTrackbar.Scroll += new System.EventHandler(this.RatioTrackbar_Scroll);
            // 
            // OffsetTrackbar
            // 
            this.OffsetTrackbar.Location = new System.Drawing.Point(426, 247);
            this.OffsetTrackbar.Maximum = 25;
            this.OffsetTrackbar.Minimum = 5;
            this.OffsetTrackbar.Name = "OffsetTrackbar";
            this.OffsetTrackbar.Size = new System.Drawing.Size(113, 45);
            this.OffsetTrackbar.TabIndex = 5;
            this.OffsetTrackbar.Value = 5;
            this.OffsetTrackbar.Scroll += new System.EventHandler(this.OffsetTrackbar_Scroll);
            // 
            // ScalingLabel
            // 
            this.ScalingLabel.AutoSize = true;
            this.ScalingLabel.Location = new System.Drawing.Point(426, 104);
            this.ScalingLabel.Name = "ScalingLabel";
            this.ScalingLabel.Size = new System.Drawing.Size(48, 15);
            this.ScalingLabel.TabIndex = 6;
            this.ScalingLabel.Text = "Scaling:";
            // 
            // RatioLabel
            // 
            this.RatioLabel.AutoSize = true;
            this.RatioLabel.Location = new System.Drawing.Point(426, 169);
            this.RatioLabel.Name = "RatioLabel";
            this.RatioLabel.Size = new System.Drawing.Size(37, 15);
            this.RatioLabel.TabIndex = 6;
            this.RatioLabel.Text = "Ratio:";
            // 
            // OffsetLabel
            // 
            this.OffsetLabel.AutoSize = true;
            this.OffsetLabel.Location = new System.Drawing.Point(426, 229);
            this.OffsetLabel.Name = "OffsetLabel";
            this.OffsetLabel.Size = new System.Drawing.Size(42, 15);
            this.OffsetLabel.TabIndex = 6;
            this.OffsetLabel.Text = "Offset:";
            // 
            // DescriptionTextbox
            // 
            this.DescriptionTextbox.Location = new System.Drawing.Point(426, 284);
            this.DescriptionTextbox.Multiline = true;
            this.DescriptionTextbox.Name = "DescriptionTextbox";
            this.DescriptionTextbox.ReadOnly = true;
            this.DescriptionTextbox.Size = new System.Drawing.Size(104, 241);
            this.DescriptionTextbox.TabIndex = 7;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 545);
            this.Controls.Add(this.DescriptionTextbox);
            this.Controls.Add(this.OffsetLabel);
            this.Controls.Add(this.RatioLabel);
            this.Controls.Add(this.ScalingLabel);
            this.Controls.Add(this.OffsetTrackbar);
            this.Controls.Add(this.RatioTrackbar);
            this.Controls.Add(this.ScalingTrackbar);
            this.Controls.Add(this.UndertextLabel);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.HeaderLabel);
            this.Name = "MainWindow";
            this.Text = "Sign library";
            ((System.ComponentModel.ISupportInitialize)(this.ScalingTrackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RatioTrackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OffsetTrackbar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label HeaderLabel;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Label UndertextLabel;
        private System.Windows.Forms.TrackBar ScalingTrackbar;
        private System.Windows.Forms.TrackBar RatioTrackbar;
        private System.Windows.Forms.TrackBar OffsetTrackbar;
        private System.Windows.Forms.Label ScalingLabel;
        private System.Windows.Forms.Label RatioLabel;
        private System.Windows.Forms.Label OffsetLabel;
        private System.Windows.Forms.TextBox DescriptionTextbox;
    }
}

