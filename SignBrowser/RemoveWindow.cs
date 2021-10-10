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
    public partial class RemoveWindow : Form
    {
        public RemoveWindow()
        {
            InitializeComponent();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            int countStart = FileAccess.Entries.Count;
            for (int i = FileAccess.Entries.Count - 1; i >= 0; i--)
            {
                if (!this.RecursiveCheckbox.Checked)
                {
                    FileAccess.Entries.RemoveAt(i);

                    break;
                }
                else
                {
                    FileAccess.Entries.RemoveAt(i);
                }
            }

            if (countStart == FileAccess.Entries.Count)
            {
                MessageBox.Show(
                "No such buttons were found!");
            }
            else
            {
                MessageBox.Show(
                "Successfully deleted " + (countStart - FileAccess.Entries.Count) +
                " Button/s.");
            }
        }
    }
}
