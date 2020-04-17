namespace rpc_working.CrystalReportsViewer
{
    partial class PurchaseOrderViewer
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
            this.porptviewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // porptviewer
            // 
            this.porptviewer.ActiveViewIndex = -1;
            this.porptviewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.porptviewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.porptviewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.porptviewer.Location = new System.Drawing.Point(0, 0);
            this.porptviewer.Name = "porptviewer";
            this.porptviewer.Size = new System.Drawing.Size(1149, 703);
            this.porptviewer.TabIndex = 0;
            this.porptviewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // PurchaseOrderViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 703);
            this.Controls.Add(this.porptviewer);
            this.Name = "PurchaseOrderViewer";
            this.Text = "Purchase Order Report";
            this.Load += new System.EventHandler(this.PurchaseOrderViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer porptviewer;
    }
}