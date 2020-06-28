namespace rpc_working.CrystalReportsViewer
{
    partial class ProductStock
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
            this.ProductStockrptViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // ProductStockrptViewer
            // 
            this.ProductStockrptViewer.ActiveViewIndex = -1;
            this.ProductStockrptViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProductStockrptViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.ProductStockrptViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProductStockrptViewer.Location = new System.Drawing.Point(0, 0);
            this.ProductStockrptViewer.Name = "ProductStockrptViewer";
            this.ProductStockrptViewer.Size = new System.Drawing.Size(1149, 703);
            this.ProductStockrptViewer.TabIndex = 3;
            this.ProductStockrptViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // ProductStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 703);
            this.Controls.Add(this.ProductStockrptViewer);
            this.Name = "ProductStock";
            this.Text = "Product Inventory Report";
            this.Load += new System.EventHandler(this.ProductStock_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer ProductStockrptViewer;
    }
}