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
            //TODO: Add these scalings as buttons
            //TODO: Add button description somewhere on the form (with lambdas if that works?)
            //TODO: Add proper window resizing feature and scale all elements (google this?)
            InitializeComponent();
            MainWindow.Scaling = 2.0F;
            MainWindow.Ratio = 1F;
            MainWindow.Offset = 5;

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
            int panelWidth = this.MainPanel.Width - MainWindow.Offset * 2;
            int panelHeight = this.MainPanel.Height - MainWindow.Offset * 2;

            int x = (int)(20 * MainWindow.Scaling);
            int y = (int)((20 * MainWindow.Scaling) * MainWindow.Ratio);

            int perRow = (int)System.Math.Floor((double)(panelWidth / (x + MainWindow.Offset)));
            int buttonCounter = 0;

            int startX = 0;
            int startY = 0;

            FileAccess.Entries.ForEach(
                entry =>
                {
                    // Starting on new row...
                    if (buttonCounter > perRow)
                    {
                        startX = 0; startY += y; buttonCounter = 0;
                    }
                    // Last row...
                    else if (buttonCounter == perRow)
                    {
                        entry.GraphicsButton.Location = new Point(startX + MainWindow.Offset, startY + MainWindow.Offset);
                        entry.GraphicsButton.Text = entry.Sign;
                        entry.GraphicsButton.Size = new Size(x, y);
                        this.MainPanel.Controls.Add(entry.GraphicsButton);

                        buttonCounter++;
                    }
                    else // We are somewhere else in the row...
                    {
                        entry.GraphicsButton.Location = new Point(startX + MainWindow.Offset, startY + MainWindow.Offset);
                        entry.GraphicsButton.Text = entry.Sign;
                        entry.GraphicsButton.Size = new Size(x, y);
                        this.MainPanel.Controls.Add(entry.GraphicsButton);
                        // TODO: fix the ugly gap at the end
                        startX += x; buttonCounter++;
                    }
                });
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var addWindow = new AddWindow();
            //TODO: Add positioning to the window to open it on top of this one.
            this.Enabled = false;
            addWindow.FormClosed += (o, e) => { this.Focus(); this.Enabled = true; this.RedrawPanel(); };
            addWindow.Show();
        }
    }
}
