namespace _3DNesManager
{
    partial class MainForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstRoms = new System.Windows.Forms.ListView();
            this.hdrFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hdrROM = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hdrSystem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hdrNes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.prop3DN = new System.Windows.Forms.PropertyGrid();
            this.lst3DN = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.credentialsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.createAccountToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstRoms
            // 
            this.lstRoms.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.hdrFile,
            this.hdrROM,
            this.hdrSystem,
            this.hdrNes});
            this.lstRoms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstRoms.FullRowSelect = true;
            this.lstRoms.HideSelection = false;
            this.lstRoms.Location = new System.Drawing.Point(0, 0);
            this.lstRoms.Name = "lstRoms";
            this.lstRoms.Size = new System.Drawing.Size(550, 513);
            this.lstRoms.TabIndex = 0;
            this.lstRoms.UseCompatibleStateImageBehavior = false;
            this.lstRoms.View = System.Windows.Forms.View.Details;
            this.lstRoms.SelectedIndexChanged += new System.EventHandler(this.lstRoms_SelectedIndexChanged);
            // 
            // hdrFile
            // 
            this.hdrFile.Text = "File";
            this.hdrFile.Width = 207;
            // 
            // hdrROM
            // 
            this.hdrROM.Text = "ROM Name";
            this.hdrROM.Width = 187;
            // 
            // hdrSystem
            // 
            this.hdrSystem.Text = "NTSC/PAL";
            this.hdrSystem.Width = 68;
            // 
            // hdrNes
            // 
            this.hdrNes.Text = "3DN file";
            this.hdrNes.Width = 52;
            // 
            // prop3DN
            // 
            this.prop3DN.DisabledItemForeColor = System.Drawing.SystemColors.ControlText;
            this.prop3DN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prop3DN.HelpVisible = false;
            this.prop3DN.Location = new System.Drawing.Point(0, 0);
            this.prop3DN.Name = "prop3DN";
            this.prop3DN.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
            this.prop3DN.Size = new System.Drawing.Size(271, 212);
            this.prop3DN.TabIndex = 2;
            this.prop3DN.ToolbarVisible = false;
            // 
            // lst3DN
            // 
            this.lst3DN.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lst3DN.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader2});
            this.lst3DN.FullRowSelect = true;
            this.lst3DN.HideSelection = false;
            this.lst3DN.Location = new System.Drawing.Point(3, 3);
            this.lst3DN.Name = "lst3DN";
            this.lst3DN.Size = new System.Drawing.Size(265, 262);
            this.lst3DN.TabIndex = 3;
            this.lst3DN.UseCompatibleStateImageBehavior = false;
            this.lst3DN.View = System.Windows.Forms.View.Details;
            this.lst3DN.SelectedIndexChanged += new System.EventHandler(this.lst3DN_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 153;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Exact";
            this.columnHeader3.Width = 39;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Official";
            this.columnHeader2.Width = 45;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(3, 271);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Download";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(145, 271);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(123, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Upload";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lstRoms);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(825, 513);
            this.splitContainer1.SplitterDistance = 550;
            this.splitContainer1.TabIndex = 6;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lst3DN);
            this.splitContainer2.Panel1.Controls.Add(this.button1);
            this.splitContainer2.Panel1.Controls.Add(this.button2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.prop3DN);
            this.splitContainer2.Size = new System.Drawing.Size(271, 513);
            this.splitContainer2.SplitterDistance = 297;
            this.splitContainer2.TabIndex = 6;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.credentialsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(825, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // credentialsToolStripMenuItem
            // 
            this.credentialsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startSessionToolStripMenuItem,
            this.toolStripMenuItem1,
            this.createAccountToolStripMenuItem1});
            this.credentialsToolStripMenuItem.Name = "credentialsToolStripMenuItem";
            this.credentialsToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.credentialsToolStripMenuItem.Text = "Session";
            // 
            // startSessionToolStripMenuItem
            // 
            this.startSessionToolStripMenuItem.Name = "startSessionToolStripMenuItem";
            this.startSessionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.startSessionToolStripMenuItem.Text = "Start session";
            this.startSessionToolStripMenuItem.Click += new System.EventHandler(this.startSessionToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // createAccountToolStripMenuItem1
            // 
            this.createAccountToolStripMenuItem1.Name = "createAccountToolStripMenuItem1";
            this.createAccountToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.createAccountToolStripMenuItem1.Text = "Create account";
            this.createAccountToolStripMenuItem1.Click += new System.EventHandler(this.createAccountToolStripMenuItem1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 537);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "3DNes Manager";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstRoms;
        private System.Windows.Forms.ColumnHeader hdrFile;
        private System.Windows.Forms.ColumnHeader hdrROM;
        private System.Windows.Forms.ColumnHeader hdrSystem;
        private System.Windows.Forms.ColumnHeader hdrNes;
        private System.Windows.Forms.PropertyGrid prop3DN;
        private System.Windows.Forms.ListView lst3DN;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem credentialsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startSessionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem createAccountToolStripMenuItem1;
    }
}

