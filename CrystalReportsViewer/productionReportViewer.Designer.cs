namespace rpc_working.CrystalReportsViewer
{
    partial class productionReportViewer
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
            this.productionrptViwer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // productionrptViwer
            // 
            this.productionrptViwer.ActiveViewIndex = -1;
            this.productionrptViwer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.productionrptViwer.Cursor = System.Windows.Forms.Cursors.Default;
            this.productionrptViwer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productionrptViwer.Location = new System.Drawing.Point(0, 0);
            this.productionrptViwer.Name = "productionrptViwer";
            this.productionrptViwer.Size = new System.Drawing.Size(1149, 703);
            this.productionrptViwer.TabIndex = 0;
            this.productionrptViwer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // productionReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 703);
            this.Controls.Add(this.productionrptViwer);
            this.Name = "productionReportViewer";
            this.Text = "Production Report ";
            this.Load += new System.EventHandler(this.productionReportViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer productionrptViwer;
    }
}