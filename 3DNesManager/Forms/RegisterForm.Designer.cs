namespace _3DNesManager.Forms
{
    partial class RegisterForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRepeat = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login";
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(108, 12);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(154, 20);
            this.txtLogin.TabIndex = 1;
            this.txtLogin.Enter += new System.EventHandler(this.txtLogin_Enter);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(12, 199);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(162, 23);
            this.btnCreate.TabIndex = 5;
            this.btnCreate.Text = "Create account";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(108, 38);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(154, 20);
            this.txtUser.TabIndex = 2;
            this.txtUser.Enter += new System.EventHandler(this.txtUser_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "User name";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(108, 64);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '⚫';
            this.txtPassword.Size = new System.Drawing.Size(154, 20);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Password";
            // 
            // txtRepeat
            // 
            this.txtRepeat.Location = new System.Drawing.Point(108, 90);
            this.txtRepeat.Name = "txtRepeat";
            this.txtRepeat.PasswordChar = '⚫';
            this.txtRepeat.Size = new System.Drawing.Size(154, 20);
            this.txtRepeat.TabIndex = 4;
            this.txtRepeat.Enter += new System.EventHandler(this.txtRepeat_Enter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Repeat password";
            // 
            // lblInfo
            // 
            this.lblInfo.BackColor = System.Drawing.SystemColors.Control;
            this.lblInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblInfo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblInfo.Location = new System.Drawing.Point(12, 122);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(250, 64);
            this.lblInfo.TabIndex = 11;
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(180, 199);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 234);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.txtRepeat);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Registration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRepeat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnCancel;
    }
}