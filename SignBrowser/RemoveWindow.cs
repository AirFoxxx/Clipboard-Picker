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
            if (!this.validateWindow())
            {
                return;
            }
            int countStart = FileAccess.Entries.Count;
            for (int i = FileAccess.Entries.Count - 1; i >= 0; i--)
            {
                if (!this.RecursiveCheckbox.Checked)
                {
                    if (FileAccess.Entries[i].Sign == this.SignTextbox.Text)
                    {
                        // For now we hide the button and on hte next system start it will be gone
                        var buttonToRemove = FileAccess.Entries[i];
                        buttonToRemove.GraphicsButton.Hide();
                        FileAccess.Entries.RemoveAt(i);
                        break;
                    }
                }
                else
                {
                    if (FileAccess.Entries[i].Sign == this.SignTextbox.Text)
                    {
                        // For now we hide the button and on hte next system start it will be gone
                        var buttonToRemove = FileAccess.Entries[i];
                        buttonToRemove.GraphicsButton.Hide();
                        FileAccess.Entries.RemoveAt(i);
                    }
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
                this.SignTextbox.Text = string.Empty;
                this.RecursiveCheckbox.Checked = false;

                // recalculate IDs.
                int indexFix = 1;
                FileAccess.Entries.ForEach(entry => entry.Id = indexFix++);
            }
        }

        private bool validateWindow()
        {
            bool check = true;
            if (this.SignTextbox.Text == string.Empty || this.SignTextbox.Text.Length > 1)
            {
                MessageBox.Show("Sign can only contain one character! Use the other components to add multi character phrases.");
                check = false;
            }
            return check;
        }
    }
}
