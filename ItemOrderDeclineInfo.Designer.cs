namespace rpc_working
{
    partial class ItemOrderDeclineInfo
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.itemOrder_lbl = new System.Windows.Forms.Label();
            this.reason_cmb = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.client_name_lbl = new System.Windows.Forms.Label();
            this.otherInfo_txt = new System.Windows.Forms.RichTextBox();
            this.submit_btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reason For Decinling Item Order :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Item Order No:";
            // 
            // itemOrder_lbl
            // 
            this.itemOrder_lbl.AutoSize = true;
            this.itemOrder_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemOrder_lbl.Location = new System.Drawing.Point(183, 22);
            this.itemOrder_lbl.Name = "itemOrder_lbl";
            this.itemOrder_lbl.Size = new System.Drawing.Size(41, 13);
            this.itemOrder_lbl.TabIndex = 2;
            this.itemOrder_lbl.Text = "label3";
            // 
            // reason_cmb
            // 
            this.reason_cmb.FormattingEnabled = true;
            this.reason_cmb.Items.AddRange(new object[] {
            "A FALSE ENTRY",
            "NOT FEASIBLE TO PRODUCE ",
            "UNACCEPTABLE VOLUME",
            "OTHER"});
            this.reason_cmb.Location = new System.Drawing.Point(262, 104);
            this.reason_cmb.Name = "reason_cmb";
            this.reason_cmb.Size = new System.Drawing.Size(392, 21);
            this.reason_cmb.TabIndex = 3;
            this.reason_cmb.SelectedIndexChanged += new System.EventHandler(this.reason_cmb_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "If other Reason Specify :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Item Order No:";
            // 
            // client_name_lbl
            // 
            this.client_name_lbl.AutoSize = true;
            this.client_name_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.client_name_lbl.Location = new System.Drawing.Point(183, 59);
            this.client_name_lbl.Name = "client_name_lbl";
            this.client_name_lbl.Size = new System.Drawing.Size(41, 13);
            this.client_name_lbl.TabIndex = 6;
            this.client_name_lbl.Text = "label3";
            // 
            // otherInfo_txt
            // 
            this.otherInfo_txt.Location = new System.Drawing.Point(262, 141);
            this.otherInfo_txt.Name = "otherInfo_txt";
            this.otherInfo_txt.Size = new System.Drawing.Size(392, 104);
            this.otherInfo_txt.TabIndex = 7;
            this.otherInfo_txt.Text = "";
            // 
            // submit_btn
            // 
            this.submit_btn.Location = new System.Drawing.Point(95, 274);
            this.submit_btn.Name = "submit_btn";
            this.submit_btn.Size = new System.Drawing.Size(139, 23);
            this.submit_btn.TabIndex = 8;
            this.submit_btn.Text = "Submit";
            this.submit_btn.UseVisualStyleBackColor = true;
            this.submit_btn.Click += new System.EventHandler(this.submit_btn_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(470, 274);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(139, 23);
            this.cancel_btn.TabIndex = 9;
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // ItemOrderDeclineInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 334);
            this.ControlBox = false;
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.submit_btn);
            this.Controls.Add(this.otherInfo_txt);
            this.Controls.Add(this.client_name_lbl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.reason_cmb);
            this.Controls.Add(this.itemOrder_lbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ItemOrderDeclineInfo";
            this.ShowIcon = false;
            this.Text = "Item Order Decline Info";
            this.Load += new System.EventHandler(this.ItemOrderDeclineInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label itemOrder_lbl;
        private System.Windows.Forms.ComboBox reason_cmb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label client_name_lbl;
        private System.Windows.Forms.RichTextBox otherInfo_txt;
        private System.Windows.Forms.Button submit_btn;
        private System.Windows.Forms.Button cancel_btn;
    }
}