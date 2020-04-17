namespace rpc_working
{
    partial class Reports
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rpt_typ_cmb = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.from_calander = new System.Windows.Forms.MonthCalendar();
            this.label4 = new System.Windows.Forms.Label();
            this.to_calander = new System.Windows.Forms.MonthCalendar();
            this.reset_btn = new System.Windows.Forms.Button();
            this.generate_btn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.cachedBOMReport1 = new rpc_working.CrystalReports.CachedBOMReport();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(56, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Report Category :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(56, 228);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Duration :";
            // 
            // rpt_typ_cmb
            // 
            this.rpt_typ_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rpt_typ_cmb.FormattingEnabled = true;
            this.rpt_typ_cmb.Items.AddRange(new object[] {
            "Raw Material Useage",
            "Item Orders",
            "Production Orders",
            "Material Purchase Orders"});
            this.rpt_typ_cmb.Location = new System.Drawing.Point(225, 116);
            this.rpt_typ_cmb.Name = "rpt_typ_cmb";
            this.rpt_typ_cmb.Size = new System.Drawing.Size(181, 21);
            this.rpt_typ_cmb.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(338, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "To :";
            // 
            // from_calander
            // 
            this.from_calander.Location = new System.Drawing.Point(81, 47);
            this.from_calander.MaxDate = new System.DateTime(2020, 4, 14, 21, 45, 38, 0);
            this.from_calander.MaxSelectionCount = 1;
            this.from_calander.Name = "from_calander";
            this.from_calander.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(558, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "To :";
            // 
            // to_calander
            // 
            this.to_calander.Location = new System.Drawing.Point(396, 47);
            this.to_calander.MaxDate = new System.DateTime(2020, 4, 14, 22, 40, 5, 0);
            this.to_calander.MaxSelectionCount = 1;
            this.to_calander.Name = "to_calander";
            this.to_calander.TabIndex = 6;
            // 
            // reset_btn
            // 
            this.reset_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reset_btn.Location = new System.Drawing.Point(697, 572);
            this.reset_btn.Name = "reset_btn";
            this.reset_btn.Size = new System.Drawing.Size(89, 34);
            this.reset_btn.TabIndex = 9;
            this.reset_btn.Text = "Reset";
            this.reset_btn.UseVisualStyleBackColor = true;
            this.reset_btn.Click += new System.EventHandler(this.reset_btn_Click);
            // 
            // generate_btn
            // 
            this.generate_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generate_btn.Location = new System.Drawing.Point(238, 572);
            this.generate_btn.Name = "generate_btn";
            this.generate_btn.Size = new System.Drawing.Size(137, 34);
            this.generate_btn.TabIndex = 10;
            this.generate_btn.Text = "Generate Report";
            this.generate_btn.UseVisualStyleBackColor = true;
            this.generate_btn.Click += new System.EventHandler(this.generate_btn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(49, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(223, 29);
            this.label6.TabIndex = 11;
            this.label6.Text = "Report Generation :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.from_calander);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.to_calander);
            this.groupBox1.Location = new System.Drawing.Point(220, 183);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(677, 237);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Time Range";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 17);
            this.label7.TabIndex = 7;
            this.label7.Text = "From :";
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.generate_btn);
            this.Controls.Add(this.reset_btn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rpt_typ_cmb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Reports";
            this.Size = new System.Drawing.Size(1165, 742);
            this.Load += new System.EventHandler(this.Reports_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox rpt_typ_cmb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MonthCalendar from_calander;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MonthCalendar to_calander;
        private System.Windows.Forms.Button reset_btn;
        private System.Windows.Forms.Button generate_btn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private CrystalReports.CachedBOMReport cachedBOMReport1;
    }
}
