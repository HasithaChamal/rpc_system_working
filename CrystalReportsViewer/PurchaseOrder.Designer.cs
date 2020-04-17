namespace rpc_working.CrystalReportsViewer
{
    partial class PurchaseOrderReportViewer
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
            this.POrptViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // POrptViewer
            // 
            this.POrptViewer.ActiveViewIndex = -1;
            this.POrptViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.POrptViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.POrptViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.POrptViewer.Location = new System.Drawing.Point(0, 0);
            this.POrptViewer.Name = "POrptViewer";
            this.POrptViewer.Size = new System.Drawing.Size(1149, 703);
            this.POrptViewer.TabIndex = 1;
            this.POrptViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // PurchaseOrderReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 703);
            this.Controls.Add(this.POrptViewer);
            this.Name = "PurchaseOrderReportViewer";
            this.Text = "Purchase Order";
            this.Load += new System.EventHandler(this.PurchaseOrderReportViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer POrptViewer;
    }
}