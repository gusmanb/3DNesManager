using _3DNesManager.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3DNesManager.Forms
{
    public partial class LoginForm : Form
    {
        public string LoginName { get; private set; }
        public string Password { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLogin.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("You must fill all the fields.");
                return;
            }

            btnStart.Enabled = false;
            btnCancel.Enabled = false;

            var user = await CommTools.LoginUser(txtLogin.Text, txtPassword.Text);

            if (string.IsNullOrWhiteSpace(user))
            {
                MessageBox.Show("Cannot start session, check your account data.");
                btnStart.Enabled = true;
                btnCancel.Enabled = true;
                return;
            }

            this.DialogResult = DialogResult.OK;
            LoginName = txtLogin.Text;
            Password = txtPassword.Text;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
