namespace _3DNesManager
{
    partial class ConfigForm
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
            this.txtRomPath = new System.Windows.Forms.TextBox();
            this.btnRomPath = new System.Windows.Forms.Button();
            this.txt3dnPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn3dnPath = new System.Windows.Forms.Button();
            this.btnPath = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ROM path:";
            // 
            // txtRomPath
            // 
            this.txtRomPath.Location = new System.Drawing.Point(74, 12);
            this.txtRomPath.Name = "txtRomPath";
            this.txtRomPath.Size = new System.Drawing.Size(324, 20);
            this.txtRomPath.TabIndex = 1;
            // 
            // btnRomPath
            // 
            this.btnRomPath.Location = new System.Drawing.Point(404, 10);
            this.btnRomPath.Name = "btnRomPath";
            this.btnRomPath.Size = new System.Drawing.Size(75, 23);
            this.btnRomPath.TabIndex = 2;
            this.btnRomPath.Text = "...";
            this.btnRomPath.UseVisualStyleBackColor = true;
            this.btnRomPath.Click += new System.EventHandler(this.btnRomPath_Click);
            // 
            // txt3dnPath
            // 
            this.txt3dnPath.Location = new System.Drawing.Point(74, 38);
            this.txt3dnPath.Name = "txt3dnPath";
            this.txt3dnPath.Size = new System.Drawing.Size(324, 20);
            this.txt3dnPath.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "3DN path:";
            // 
            // btn3dnPath
            // 
            this.btn3dnPath.Location = new System.Drawing.Point(404, 36);
            this.btn3dnPath.Name = "btn3dnPath";
            this.btn3dnPath.Size = new System.Drawing.Size(75, 23);
            this.btn3dnPath.TabIndex = 5;
            this.btn3dnPath.Text = "...";
            this.btn3dnPath.UseVisualStyleBackColor = true;
            this.btn3dnPath.Click += new System.EventHandler(this.btn3dnPath_Click);
            // 
            // btnPath
            // 
            this.btnPath.Location = new System.Drawing.Point(12, 65);
            this.btnPath.Name = "btnPath";
            this.btnPath.Size = new System.Drawing.Size(467, 23);
            this.btnPath.TabIndex = 6;
            this.btnPath.Text = "Save";
            this.btnPath.UseVisualStyleBackColor = true;
            this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 100);
            this.Controls.Add(this.btnPath);
            this.Controls.Add(this.btn3dnPath);
            this.Controls.Add(this.txt3dnPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnRomPath);
            this.Controls.Add(this.txtRomPath);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigForm";
            this.Text = "Path configuration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRomPath;
        private System.Windows.Forms.Button btnRomPath;
        private System.Windows.Forms.TextBox txt3dnPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn3dnPath;
        private System.Windows.Forms.Button btnPath;
    }
}