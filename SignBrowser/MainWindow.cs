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
            InitializeComponent();
            int x = 0;
            int y = 0;
            FileAccess.Entries.ForEach(
                entry =>
                {
                    entry.GraphicsButton.Location = new Point(x, y);
                    //entry.GraphicsButton.Text = entry.Sign;
                    this.MainPanel.Controls.Add(entry.GraphicsButton);
                    x += 50;
                    y += 50;
                });
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var addWindow = new AddWindow();
            addWindow.Show();
        }
    }
}
