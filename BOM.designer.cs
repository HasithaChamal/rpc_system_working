namespace rpc_working
{
    partial class BOM
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
            this.poText = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.create_bom_btn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.material_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.applyBtn = new System.Windows.Forms.Button();
            this.bom_lbl = new System.Windows.Forms.Label();
            this.clear_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 24);
            this.label1.TabIndex = 32;
            this.label1.Text = "Create Bill of Materials :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 16);
            this.label2.TabIndex = 40;
            this.label2.Text = " Production Order ID:";
            // 
            // poText
            // 
            this.poText.Location = new System.Drawing.Point(199, 172);
            this.poText.Name = "poText";
            this.poText.Size = new System.Drawing.Size(108, 20);
            this.poText.TabIndex = 41;
            this.poText.TextChanged += new System.EventHandler(this.PoText_TextChanged);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(23, 339);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(479, 317);
            this.dataGridView2.TabIndex = 59;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 280);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 16);
            this.label4.TabIndex = 53;
            this.label4.Text = "Items View :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(19, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 16);
            this.label7.TabIndex = 60;
            this.label7.Text = "BOM ID:";
            // 
            // create_bom_btn
            // 
            this.create_bom_btn.Location = new System.Drawing.Point(32, 682);
            this.create_bom_btn.Name = "create_bom_btn";
            this.create_bom_btn.Size = new System.Drawing.Size(178, 23);
            this.create_bom_btn.TabIndex = 61;
            this.create_bom_btn.Text = "Generate Bill of Material";
            this.create_bom_btn.UseVisualStyleBackColor = true;
            this.create_bom_btn.Click += new System.EventHandler(this.Create_bom_btn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.material_id,
            this.quantity,
            this.name,
            this.unit_price});
            this.dataGridView1.Location = new System.Drawing.Point(564, 72);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(588, 584);
            this.dataGridView1.TabIndex = 62;
            // 
            // material_id
            // 
            this.material_id.HeaderText = "Material ID";
            this.material_id.Name = "material_id";
            this.material_id.ReadOnly = true;
            // 
            // quantity
            // 
            this.quantity.HeaderText = "Quantity";
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            // 
            // name
            // 
            this.name.HeaderText = "Material Name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // unit_price
            // 
            this.unit_price.HeaderText = "Material Price";
            this.unit_price.Name = "unit_price";
            this.unit_price.ReadOnly = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label8.Location = new System.Drawing.Point(550, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(241, 24);
            this.label8.TabIndex = 63;
            this.label8.Text = "Raw Material Requirement :";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(790, 682);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(194, 23);
            this.button2.TabIndex = 64;
            this.button2.Text = "Print Bill of Materials";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // applyBtn
            // 
            this.applyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applyBtn.Location = new System.Drawing.Point(366, 173);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Size = new System.Drawing.Size(109, 23);
            this.applyBtn.TabIndex = 65;
            this.applyBtn.Text = "Apply";
            this.applyBtn.UseVisualStyleBackColor = true;
            this.applyBtn.Click += new System.EventHandler(this.ApplyBtn_Click);
            // 
            // bom_lbl
            // 
            this.bom_lbl.AutoSize = true;
            this.bom_lbl.Location = new System.Drawing.Point(196, 111);
            this.bom_lbl.Name = "bom_lbl";
            this.bom_lbl.Size = new System.Drawing.Size(35, 13);
            this.bom_lbl.TabIndex = 67;
            this.bom_lbl.Text = "label5";
            // 
            // clear_btn
            // 
            this.clear_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clear_btn.Location = new System.Drawing.Point(366, 682);
            this.clear_btn.Name = "clear_btn";
            this.clear_btn.Size = new System.Drawing.Size(109, 23);
            this.clear_btn.TabIndex = 68;
            this.clear_btn.Text = "Clear";
            this.clear_btn.UseVisualStyleBackColor = true;
            this.clear_btn.Click += new System.EventHandler(this.Clear_btn_Click);
            // 
            // BOM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.clear_btn);
            this.Controls.Add(this.bom_lbl);
            this.Controls.Add(this.applyBtn);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.create_bom_btn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.poText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "BOM";
            this.Size = new System.Drawing.Size(1165, 742);
            this.Load += new System.EventHandler(this.BOM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox poText;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button create_bom_btn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button applyBtn;
        private System.Windows.Forms.Label bom_lbl;
        private System.Windows.Forms.Button clear_btn;
        private System.Windows.Forms.DataGridViewTextBoxColumn material_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit_price;
    }
}
