using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SignLogic;

namespace SignBrowser
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            //TODO: Add button description somewhere on the form (with lambdas if that works?)
            InitializeComponent();

            this.DescriptionTextbox.Text = "Please click" +
                " on a button you want to copy the" +
                " sign from!";

            this.ScalingTrackbar.Value = 30;
            MainWindow.Scaling = this.ScalingTrackbar.Value / 10;
            this.ScalingLabel.Text = "Scaling: " + MainWindow.Scaling.ToString();

            this.RatioTrackbar.Value = 15;
            MainWindow.Ratio = this.RatioTrackbar.Value / 10;
            this.RatioLabel.Text = "Ratio: " + MainWindow.Ratio.ToString();

            this.OffsetTrackbar.Value = 5;
            MainWindow.Offset = this.OffsetTrackbar.Value;
            this.OffsetLabel.Text = "Offset: " + MainWindow.Offset.ToString();

            // What happens when button is clicked:
            FileAccess.Entries.ForEach(entry => entry.GraphicsButton.Click += (o, e) =>
            {
                this.DescriptionTextbox.Text = "Selected sign: " +
                entry.Sign + " \n" +
                "Description: \n" +
                entry.Description;
                System.Windows.Forms.Clipboard.SetText(entry.Sign);
            });

            this.RedrawPanel();
        }

        /// <summary>
        /// Gets or sets the scaling. This determines how big the buttons are.
        /// </summary>
        /// <value>
        /// The scaling.
        /// </value>
        public static float Scaling { get; set; }

        /// <summary>
        /// Gets or sets the ratio of buttons, width is always 1, so if ratio is 2.0F then height is double the width.
        /// </summary>
        /// <value>
        /// The ratio.
        /// </value>
        public static float Ratio { get; set; }

        /// <summary>
        /// Gets or sets the offset in pixels for buttons in the panel.
        /// </summary>
        /// <value>
        /// The offset.
        /// </value>
        public static int Offset { get; set; }

        public void RedrawPanel()
        {
            FileAccess.Entries = FileAccess.Entries.OrderBy(entry => entry.Id).ToList();

            var panelBorders = new PanelBorders();
            panelBorders.xStart = 0 + MainWindow.Offset; panelBorders.yStart = 0 + MainWindow.Offset;
            panelBorders.xEnd = this.MainPanel.Width; panelBorders.yEnd = this.MainPanel.Width;

            int x = (int)(20 * MainWindow.Scaling);
            int y = (int)((20 * MainWindow.Scaling) * MainWindow.Ratio);

            int perRow = (int)System.Math.Floor((double)((panelBorders.xEnd - panelBorders.xStart) / (x + MainWindow.Offset)));

            Point previousStart = new Point(0, 0);
            Point previousEnd = new Point(0, 0);

            int buttonCounter = 1;
            int rowCounter = 0;
            FileAccess.Entries.ForEach(
               entry =>
               {    // Last one in row!
                   if (buttonCounter == perRow && perRow != 1)
                   {
                       entry.locationStart = new Point(previousEnd.X + MainWindow.Offset, MainWindow.Offset + (rowCounter * (x + MainWindow.Offset)));
                       entry.locationEnd = new Point(entry.locationStart.X + x, entry.locationStart.Y + y);

                       // Reset the row!
                       rowCounter++;

                       panelBorders.xStart = 0 + MainWindow.Offset; panelBorders.yStart = MainWindow.Offset + (rowCounter * (x + MainWindow.Offset));

                       buttonCounter = 1;
                   }
                   else if (buttonCounter == 1)
                   {
                       entry.locationStart = new Point(panelBorders.xStart, panelBorders.yStart);
                       entry.locationEnd = new Point(entry.locationStart.X + x, entry.locationStart.Y + y);

                       previousStart = entry.locationStart;
                       previousEnd = entry.locationEnd;

                       buttonCounter++;
                   }
                   else if (buttonCounter < perRow)
                   {
                       entry.locationStart = new Point(previousEnd.X + MainWindow.Offset, MainWindow.Offset + (rowCounter * (x + MainWindow.Offset)));
                       entry.locationEnd = new Point(entry.locationStart.X + x, entry.locationStart.Y + y);

                       previousStart = entry.locationStart;
                       previousEnd = entry.locationEnd;

                       buttonCounter++;
                   }
               });

            FileAccess.Entries.ForEach(
                entry =>
                {
                    entry.GraphicsButton.Location = entry.locationStart;
                    entry.GraphicsButton.Text = entry.Sign;
                    entry.GraphicsButton.Size = new Size(entry.locationEnd.X - entry.locationStart.X, entry.locationEnd.Y - entry.locationStart.Y);
                    this.MainPanel.Controls.Add(entry.GraphicsButton);
                });
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var addWindow = new AddWindow();
            addWindow.StartPosition = FormStartPosition.CenterParent;
            this.Enabled = false;
            addWindow.FormClosed += (o, e) => { this.Focus(); this.Enabled = true; this.RedrawPanel(); };
            addWindow.ShowDialog();
        }

        private void ScalingTrackbar_Scroll(object sender, EventArgs e)
        {
            MainWindow.Scaling = (float)this.ScalingTrackbar.Value / 10F;
            this.ScalingLabel.Text = "Scaling: " + MainWindow.Scaling.ToString();
            this.RedrawPanel();
        }

        private void RatioTrackbar_Scroll(object sender, EventArgs e)
        {
            MainWindow.Ratio = (float)this.RatioTrackbar.Value / 10F;
            this.RatioLabel.Text = "Ratio: " + MainWindow.Ratio.ToString();
            this.RedrawPanel();
        }

        private void OffsetTrackbar_Scroll(object sender, EventArgs e)
        {
            MainWindow.Offset = this.OffsetTrackbar.Value;
            this.OffsetLabel.Text = "Offset: " + MainWindow.Offset.ToString();
            this.RedrawPanel();
        }

        public struct PanelBorders
        {
            public int xStart;
            public int yStart;
            public int xEnd;
            public int yEnd;
        }
    }
}
