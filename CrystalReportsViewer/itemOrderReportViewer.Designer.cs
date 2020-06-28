namespace rpc_working.CrystalReportsViewer
{
    partial class itemOrderReportViewer
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
            this.itemOrderrptViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // itemOrderrptViewer
            // 
            this.itemOrderrptViewer.ActiveViewIndex = -1;
            this.itemOrderrptViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.itemOrderrptViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.itemOrderrptViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemOrderrptViewer.Location = new System.Drawing.Point(0, 0);
            this.itemOrderrptViewer.Name = "itemOrderrptViewer";
            this.itemOrderrptViewer.Size = new System.Drawing.Size(1149, 703);
            this.itemOrderrptViewer.TabIndex = 0;
            this.itemOrderrptViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // itemOrderReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 703);
            this.Controls.Add(this.itemOrderrptViewer);
            this.Name = "itemOrderReportViewer";
            this.Text = "Item Order Report";
            this.Load += new System.EventHandler(this.itemOrderReportViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer itemOrderrptViewer;
    }
}