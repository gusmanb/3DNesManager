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
            this.lst3DN = new System.Windows.Forms.ListView();
            this.prop3DN = new System.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // lstRoms
            // 
            this.lstRoms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstRoms.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.hdrFile,
            this.hdrROM,
            this.hdrSystem,
            this.hdrNes});
            this.lstRoms.FullRowSelect = true;
            this.lstRoms.Location = new System.Drawing.Point(12, 12);
            this.lstRoms.Name = "lstRoms";
            this.lstRoms.Size = new System.Drawing.Size(548, 603);
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
            // lst3DN
            // 
            this.lst3DN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lst3DN.Location = new System.Drawing.Point(566, 12);
            this.lst3DN.Name = "lst3DN";
            this.lst3DN.Size = new System.Drawing.Size(276, 312);
            this.lst3DN.TabIndex = 1;
            this.lst3DN.UseCompatibleStateImageBehavior = false;
            // 
            // prop3DN
            // 
            this.prop3DN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.prop3DN.Location = new System.Drawing.Point(566, 330);
            this.prop3DN.Name = "prop3DN";
            this.prop3DN.Size = new System.Drawing.Size(276, 285);
            this.prop3DN.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 627);
            this.Controls.Add(this.prop3DN);
            this.Controls.Add(this.lst3DN);
            this.Controls.Add(this.lstRoms);
            this.Name = "MainForm";
            this.Text = "3DNes Manager";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstRoms;
        private System.Windows.Forms.ColumnHeader hdrFile;
        private System.Windows.Forms.ColumnHeader hdrROM;
        private System.Windows.Forms.ColumnHeader hdrSystem;
        private System.Windows.Forms.ColumnHeader hdrNes;
        private System.Windows.Forms.ListView lst3DN;
        private System.Windows.Forms.PropertyGrid prop3DN;
    }
}

