namespace rpc_working.CrystalReportsViewer
{
    partial class MaterialStock
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
            this.MaterialStockrptViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // MaterialStockrptViewer
            // 
            this.MaterialStockrptViewer.ActiveViewIndex = -1;
            this.MaterialStockrptViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MaterialStockrptViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.MaterialStockrptViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MaterialStockrptViewer.Location = new System.Drawing.Point(0, 0);
            this.MaterialStockrptViewer.Name = "MaterialStockrptViewer";
            this.MaterialStockrptViewer.Size = new System.Drawing.Size(1149, 703);
            this.MaterialStockrptViewer.TabIndex = 2;
            this.MaterialStockrptViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // MaterialStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 703);
            this.Controls.Add(this.MaterialStockrptViewer);
            this.Name = "MaterialStock";
            this.Text = "Raw Material Inventory Report";
            this.Load += new System.EventHandler(this.MaterialStock_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer MaterialStockrptViewer;
    }
}