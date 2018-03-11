using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3DNesManager
{
    public partial class ConfigForm : Form
    {

        public string ROMPath { get; private set; }
        public string _3DNPath { get; private set; }

        public ConfigForm()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
        }

        public ConfigForm(string ROMPath, string _3DNPath)
        {
            InitializeComponent();
            this.ROMPath = txtRomPath.Text = ROMPath;
            this._3DNPath = txt3dnPath.Text = _3DNPath;
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnRomPath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog df = new FolderBrowserDialog())
            {
                if (df.ShowDialog() != DialogResult.OK)
                    return;

                txtRomPath.Text = df.SelectedPath;
            }
        }

        private void btn3dnPath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog df = new FolderBrowserDialog())
            {
                if (df.ShowDialog() != DialogResult.OK)
                    return;

                txt3dnPath.Text = df.SelectedPath;
            }
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtRomPath.Text))
                {
                    MessageBox.Show("ROM path is not configured");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txt3dnPath.Text))
                {
                    MessageBox.Show("3dn path is not configured");
                    return;
                }

                if (!Directory.Exists(txtRomPath.Text))
                {
                    MessageBox.Show("Cannot find rom path");
                    return;
                }

                if (!Directory.Exists(txt3dnPath.Text))
                {
                    MessageBox.Show("Cannot find 3dn path");
                    return;
                }

                ROMPath = txtRomPath.Text;
                _3DNPath = txt3dnPath.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch
            {
                MessageBox.Show("Unexpected error");
                return;
            }
        }
    }
}
