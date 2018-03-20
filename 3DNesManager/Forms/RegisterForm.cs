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
    public partial class RegisterForm : Form
    {
        public string LoginName { get; private set; }
        public string Password { get; private set; }

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void txtLogin_Enter(object sender, EventArgs e)
        {
            lblInfo.Text = "This is the name you will use to log-in to the system. Recommended to use your email address, but not required. It will never be shown publicly.";
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            lblInfo.Text = "This is the name which will be shown along your 3DN files. This info will be public.";
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            lblInfo.Text = "This will be your password, minimum 6 characters, recommended 8 and using capital letters, simbols and numbers.";
        }

        private void txtRepeat_Enter(object sender, EventArgs e)
        {
            lblInfo.Text = "Re-type your password.";
        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtLogin.Text) || string.IsNullOrWhiteSpace(txtUser.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("You must fill all the data fields.");
                return;
            }

            if (txtPassword.Text != txtRepeat.Text)
            {
                MessageBox.Show("Passwords don't match.");
                return;
            }

            btnCreate.Enabled = false;
            btnCancel.Enabled = false;

            lblInfo.Text = "Creating account, please wait...";

            var res = await CommTools.CreateUser(txtUser.Text, txtLogin.Text, txtPassword.Text);

            if (res)
            {
                MessageBox.Show("Account created, you are logged in the system.");
                LoginName = txtLogin.Text;
                Password = txtPassword.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }

            MessageBox.Show("Cannot create account, possibly duplicated user name or login name.");

            btnCreate.Enabled = true;
            btnCancel.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
