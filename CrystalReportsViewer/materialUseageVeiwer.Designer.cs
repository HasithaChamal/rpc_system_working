﻿namespace rpc_working.CrystalReportsViewer
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
            this.export_btn = new System.Windows.Forms.Button();
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
            this.export_btn.TabIndex = 4;
            this.export_btn.Text = "Export ";
            this.export_btn.UseVisualStyleBackColor = false;
            this.export_btn.Click += new System.EventHandler(this.export_btn_Click);
            // 
            // materialUseageVeiwer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 703);
            this.Controls.Add(this.export_btn);
            this.Controls.Add(this.materialUseagerptviewer);
            this.Name = "materialUseageVeiwer";
            this.Text = "Material Useage";
            this.Load += new System.EventHandler(this.materialUseageVeiwer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer materialUseagerptviewer;
        private System.Windows.Forms.Button export_btn;
    }
}