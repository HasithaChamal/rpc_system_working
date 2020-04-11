namespace rpc_working.CrystalReportsViewer
{
    partial class materialUseageVeiwer
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
            this.materialUseagerptviewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // materialUseagerptviewer
            // 
            this.materialUseagerptviewer.ActiveViewIndex = -1;
            this.materialUseagerptviewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.materialUseagerptviewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.materialUseagerptviewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialUseagerptviewer.Location = new System.Drawing.Point(0, 0);
            this.materialUseagerptviewer.Name = "materialUseagerptviewer";
            this.materialUseagerptviewer.Size = new System.Drawing.Size(1149, 703);
            this.materialUseagerptviewer.TabIndex = 0;
            this.materialUseagerptviewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // materialUseageVeiwer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 703);
            this.Controls.Add(this.materialUseagerptviewer);
            this.Name = "materialUseageVeiwer";
            this.Text = "Material Useage";
            this.Load += new System.EventHandler(this.materialUseageVeiwer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer materialUseagerptviewer;
    }
}