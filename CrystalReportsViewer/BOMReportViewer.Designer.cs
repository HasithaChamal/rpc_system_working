namespace rpc_working.CrystalReportsViewer
{
    partial class BOMReportViewer
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
            this.bomrptViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // bomrptViewer
            // 
            this.bomrptViewer.ActiveViewIndex = -1;
            this.bomrptViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bomrptViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.bomrptViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bomrptViewer.Location = new System.Drawing.Point(0, 0);
            this.bomrptViewer.Name = "bomrptViewer";
            this.bomrptViewer.Size = new System.Drawing.Size(1149, 703);
            this.bomrptViewer.TabIndex = 0;
            this.bomrptViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.bomrptViewer.Load += new System.EventHandler(this.bomrptViewer_Load);
            // 
            // BOMReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 703);
            this.Controls.Add(this.bomrptViewer);
            this.Name = "BOMReportViewer";
            this.Text = "Bill Of Materials";
            this.Load += new System.EventHandler(this.BOMReportViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer bomrptViewer;
       // private CachedCrystalReport1 cachedCrystalReport11;
    }
}