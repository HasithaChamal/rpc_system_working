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
            this.export_btn = new System.Windows.Forms.Button();
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
            // export_btn
            // 
            this.export_btn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.export_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.export_btn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.export_btn.FlatAppearance.BorderSize = 2;
            this.export_btn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.export_btn.Location = new System.Drawing.Point(476, 3);
            this.export_btn.Name = "export_btn";
            this.export_btn.Size = new System.Drawing.Size(75, 23);
            this.export_btn.TabIndex = 5;
            this.export_btn.Text = "Export ";
            this.export_btn.UseVisualStyleBackColor = false;
            this.export_btn.Click += new System.EventHandler(this.export_btn_Click);
            // 
            // PurchaseOrderViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 703);
            this.Controls.Add(this.export_btn);
            this.Controls.Add(this.porptviewer);
            this.Name = "PurchaseOrderViewer";
            this.Text = "Purchase Order Report";
            this.Load += new System.EventHandler(this.PurchaseOrderViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer porptviewer;
        private System.Windows.Forms.Button export_btn;
    }
}