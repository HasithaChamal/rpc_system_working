﻿namespace rpc_working
{
    partial class Supplier
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.emailTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.contactNumberTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.findById = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.findByName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.addItemBtn = new System.Windows.Forms.Button();
            this.supplierCodeTxt = new System.Windows.Forms.TextBox();
            this.supplierNameTxt = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.itemIdTxt = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.itemSupplierCodeTxt = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.itemGroupBox = new System.Windows.Forms.GroupBox();
            this.addNewMaterial_btn = new System.Windows.Forms.Button();
            this.itemNameTxt = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.unitPriceText = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.addSupplierBtn = new System.Windows.Forms.Button();
            this.items = new System.Windows.Forms.TabPage();
            this.removeItemBtn = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.suppliers = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.supplierTab = new System.Windows.Forms.TabControl();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.removeSupplierId = new System.Windows.Forms.TextBox();
            this.removeSupplierBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView5 = new System.Windows.Forms.DataGridView();
            this.leadTime_txt = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.itemGroupBox.SuspendLayout();
            this.items.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.suppliers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.supplierTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).BeginInit();
            this.SuspendLayout();
            // 
            // emailTxt
            // 
            this.emailTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailTxt.Location = new System.Drawing.Point(259, 204);
            this.emailTxt.Name = "emailTxt";
            this.emailTxt.Size = new System.Drawing.Size(155, 20);
            this.emailTxt.TabIndex = 113;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(98, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 16);
            this.label4.TabIndex = 112;
            this.label4.Text = "Email:";
            // 
            // contactNumberTxt
            // 
            this.contactNumberTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contactNumberTxt.Location = new System.Drawing.Point(259, 160);
            this.contactNumberTxt.Name = "contactNumberTxt";
            this.contactNumberTxt.Size = new System.Drawing.Size(155, 20);
            this.contactNumberTxt.TabIndex = 111;
            this.contactNumberTxt.TextChanged += new System.EventHandler(this.contactNumTxt_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(98, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 16);
            this.label3.TabIndex = 110;
            this.label3.Text = "Contact Number:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(807, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 16);
            this.label10.TabIndex = 107;
            this.label10.Text = "Supplier Code:";
            // 
            // findById
            // 
            this.findById.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findById.Location = new System.Drawing.Point(910, 78);
            this.findById.Name = "findById";
            this.findById.Size = new System.Drawing.Size(155, 20);
            this.findById.TabIndex = 106;
            this.findById.TextChanged += new System.EventHandler(this.findById_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(760, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 20);
            this.label9.TabIndex = 105;
            this.label9.Text = "OR";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(465, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 16);
            this.label8.TabIndex = 103;
            this.label8.Text = "Company Name:";
            // 
            // findByName
            // 
            this.findByName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findByName.Location = new System.Drawing.Point(577, 81);
            this.findByName.Name = "findByName";
            this.findByName.Size = new System.Drawing.Size(155, 20);
            this.findByName.TabIndex = 102;
            this.findByName.TextChanged += new System.EventHandler(this.findByName_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(428, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 20);
            this.label7.TabIndex = 101;
            this.label7.Text = "Find Supplier";
            // 
            // addItemBtn
            // 
            this.addItemBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addItemBtn.Location = new System.Drawing.Point(310, 562);
            this.addItemBtn.Name = "addItemBtn";
            this.addItemBtn.Size = new System.Drawing.Size(75, 23);
            this.addItemBtn.TabIndex = 95;
            this.addItemBtn.Text = "Add";
            this.addItemBtn.UseVisualStyleBackColor = true;
            this.addItemBtn.Click += new System.EventHandler(this.addItemBtn_Click);
            // 
            // supplierCodeTxt
            // 
            this.supplierCodeTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplierCodeTxt.Location = new System.Drawing.Point(259, 122);
            this.supplierCodeTxt.Name = "supplierCodeTxt";
            this.supplierCodeTxt.Size = new System.Drawing.Size(155, 20);
            this.supplierCodeTxt.TabIndex = 92;
            // 
            // supplierNameTxt
            // 
            this.supplierNameTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplierNameTxt.Location = new System.Drawing.Point(259, 92);
            this.supplierNameTxt.Name = "supplierNameTxt";
            this.supplierNameTxt.Size = new System.Drawing.Size(155, 20);
            this.supplierNameTxt.TabIndex = 91;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(98, 125);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(97, 16);
            this.label13.TabIndex = 90;
            this.label13.Text = "Supplier Code:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(98, 92);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(109, 16);
            this.label14.TabIndex = 89;
            this.label14.Text = "Company Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(71, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 88;
            this.label1.Text = "Add Supplier";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(71, 279);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(221, 20);
            this.label11.TabIndex = 114;
            this.label11.Text = "Add Supplier Raw Material";
            // 
            // itemIdTxt
            // 
            this.itemIdTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemIdTxt.Location = new System.Drawing.Point(132, 19);
            this.itemIdTxt.Name = "itemIdTxt";
            this.itemIdTxt.Size = new System.Drawing.Size(155, 20);
            this.itemIdTxt.TabIndex = 116;
            this.itemIdTxt.Leave += new System.EventHandler(this.itemIdTxt_Leave);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(10, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(103, 16);
            this.label12.TabIndex = 115;
            this.label12.Text = "Raw Material Id:";
            // 
            // itemSupplierCodeTxt
            // 
            this.itemSupplierCodeTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemSupplierCodeTxt.Location = new System.Drawing.Point(233, 307);
            this.itemSupplierCodeTxt.Name = "itemSupplierCodeTxt";
            this.itemSupplierCodeTxt.Size = new System.Drawing.Size(155, 20);
            this.itemSupplierCodeTxt.TabIndex = 118;
            this.itemSupplierCodeTxt.TextChanged += new System.EventHandler(this.itemSupplierCodeTxt_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(98, 308);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(97, 16);
            this.label15.TabIndex = 120;
            this.label15.Text = "Supplier Code:";
            // 
            // itemGroupBox
            // 
            this.itemGroupBox.Controls.Add(this.addNewMaterial_btn);
            this.itemGroupBox.Controls.Add(this.itemNameTxt);
            this.itemGroupBox.Controls.Add(this.label16);
            this.itemGroupBox.Controls.Add(this.itemIdTxt);
            this.itemGroupBox.Controls.Add(this.label12);
            this.itemGroupBox.Location = new System.Drawing.Point(101, 346);
            this.itemGroupBox.Name = "itemGroupBox";
            this.itemGroupBox.Size = new System.Drawing.Size(300, 137);
            this.itemGroupBox.TabIndex = 121;
            this.itemGroupBox.TabStop = false;
            this.itemGroupBox.Text = "Raw Material Information";
            // 
            // addNewMaterial_btn
            // 
            this.addNewMaterial_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addNewMaterial_btn.Location = new System.Drawing.Point(49, 98);
            this.addNewMaterial_btn.Name = "addNewMaterial_btn";
            this.addNewMaterial_btn.Size = new System.Drawing.Size(163, 23);
            this.addNewMaterial_btn.TabIndex = 124;
            this.addNewMaterial_btn.Text = "Add New Material";
            this.addNewMaterial_btn.UseVisualStyleBackColor = true;
            this.addNewMaterial_btn.Click += new System.EventHandler(this.addNewMaterial_btn_Click);
            // 
            // itemNameTxt
            // 
            this.itemNameTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemNameTxt.Location = new System.Drawing.Point(132, 56);
            this.itemNameTxt.Name = "itemNameTxt";
            this.itemNameTxt.Size = new System.Drawing.Size(155, 20);
            this.itemNameTxt.TabIndex = 118;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(6, 56);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(129, 16);
            this.label16.TabIndex = 117;
            this.label16.Text = "Raw Material Name:";
            // 
            // unitPriceText
            // 
            this.unitPriceText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitPriceText.Location = new System.Drawing.Point(234, 494);
            this.unitPriceText.Name = "unitPriceText";
            this.unitPriceText.Size = new System.Drawing.Size(155, 20);
            this.unitPriceText.TabIndex = 122;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(108, 494);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(71, 16);
            this.label18.TabIndex = 121;
            this.label18.Text = "Unit Price :";
            // 
            // addSupplierBtn
            // 
            this.addSupplierBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addSupplierBtn.Location = new System.Drawing.Point(313, 245);
            this.addSupplierBtn.Name = "addSupplierBtn";
            this.addSupplierBtn.Size = new System.Drawing.Size(75, 23);
            this.addSupplierBtn.TabIndex = 122;
            this.addSupplierBtn.Text = "Add";
            this.addSupplierBtn.UseVisualStyleBackColor = true;
            this.addSupplierBtn.Click += new System.EventHandler(this.addSupplierBtn_Click);
            // 
            // items
            // 
            this.items.Controls.Add(this.removeItemBtn);
            this.items.Controls.Add(this.dataGridView2);
            this.items.Location = new System.Drawing.Point(4, 22);
            this.items.Name = "items";
            this.items.Padding = new System.Windows.Forms.Padding(3);
            this.items.Size = new System.Drawing.Size(634, 474);
            this.items.TabIndex = 1;
            this.items.Text = "Raw Material";
            this.items.UseVisualStyleBackColor = true;
            // 
            // removeItemBtn
            // 
            this.removeItemBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeItemBtn.Location = new System.Drawing.Point(510, 490);
            this.removeItemBtn.Name = "removeItemBtn";
            this.removeItemBtn.Size = new System.Drawing.Size(118, 23);
            this.removeItemBtn.TabIndex = 124;
            this.removeItemBtn.Text = "Remove Item";
            this.removeItemBtn.UseVisualStyleBackColor = true;
            this.removeItemBtn.Click += new System.EventHandler(this.removeItemBtn_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(6, 8);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(622, 476);
            this.dataGridView2.TabIndex = 110;
            this.dataGridView2.Click += new System.EventHandler(this.dataGridView2_Click);
            // 
            // suppliers
            // 
            this.suppliers.Controls.Add(this.dataGridView1);
            this.suppliers.Location = new System.Drawing.Point(4, 22);
            this.suppliers.Name = "suppliers";
            this.suppliers.Padding = new System.Windows.Forms.Padding(3);
            this.suppliers.Size = new System.Drawing.Size(634, 474);
            this.suppliers.TabIndex = 0;
            this.suppliers.Text = "Suppliers";
            this.suppliers.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 11);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(622, 448);
            this.dataGridView1.TabIndex = 109;
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // supplierTab
            // 
            this.supplierTab.Controls.Add(this.suppliers);
            this.supplierTab.Controls.Add(this.items);
            this.supplierTab.Location = new System.Drawing.Point(432, 122);
            this.supplierTab.Name = "supplierTab";
            this.supplierTab.SelectedIndex = 0;
            this.supplierTab.Size = new System.Drawing.Size(642, 500);
            this.supplierTab.TabIndex = 123;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(71, 602);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 20);
            this.label6.TabIndex = 98;
            this.label6.Text = "Remove Supplier:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(98, 646);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 16);
            this.label5.TabIndex = 99;
            this.label5.Text = "Supplier Code:";
            // 
            // removeSupplierId
            // 
            this.removeSupplierId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeSupplierId.Location = new System.Drawing.Point(233, 646);
            this.removeSupplierId.Name = "removeSupplierId";
            this.removeSupplierId.Size = new System.Drawing.Size(155, 20);
            this.removeSupplierId.TabIndex = 100;
            this.removeSupplierId.TextChanged += new System.EventHandler(this.removeSupplierId_TextChanged);
            // 
            // removeSupplierBtn
            // 
            this.removeSupplierBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeSupplierBtn.Location = new System.Drawing.Point(313, 700);
            this.removeSupplierBtn.Name = "removeSupplierBtn";
            this.removeSupplierBtn.Size = new System.Drawing.Size(75, 23);
            this.removeSupplierBtn.TabIndex = 119;
            this.removeSupplierBtn.Text = "Remove";
            this.removeSupplierBtn.UseVisualStyleBackColor = true;
            this.removeSupplierBtn.Click += new System.EventHandler(this.removeSupplierBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(438, 627);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 20);
            this.label2.TabIndex = 125;
            this.label2.Text = "Item Supplier View :";
            // 
            // dataGridView5
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView5.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView5.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView5.Location = new System.Drawing.Point(442, 650);
            this.dataGridView5.Name = "dataGridView5";
            this.dataGridView5.Size = new System.Drawing.Size(622, 77);
            this.dataGridView5.TabIndex = 124;
            // 
            // leadTime_txt
            // 
            this.leadTime_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leadTime_txt.Location = new System.Drawing.Point(232, 533);
            this.leadTime_txt.Name = "leadTime_txt";
            this.leadTime_txt.Size = new System.Drawing.Size(155, 20);
            this.leadTime_txt.TabIndex = 127;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(106, 533);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(79, 16);
            this.label17.TabIndex = 126;
            this.label17.Text = "Lead Time :";
            // 
            // Supplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.leadTime_txt);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView5);
            this.Controls.Add(this.supplierTab);
            this.Controls.Add(this.unitPriceText);
            this.Controls.Add(this.addSupplierBtn);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.itemGroupBox);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.removeSupplierBtn);
            this.Controls.Add(this.itemSupplierCodeTxt);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.emailTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.contactNumberTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.findById);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.findByName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.removeSupplierId);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.addItemBtn);
            this.Controls.Add(this.supplierCodeTxt);
            this.Controls.Add(this.supplierNameTxt);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label1);
            this.Name = "Supplier";
            this.Size = new System.Drawing.Size(1165, 742);
            this.Load += new System.EventHandler(this.Supplier_Load);
            this.itemGroupBox.ResumeLayout(false);
            this.itemGroupBox.PerformLayout();
            this.items.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.suppliers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.supplierTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox emailTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox contactNumberTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox findById;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox findByName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button addItemBtn;
        private System.Windows.Forms.TextBox supplierCodeTxt;
        private System.Windows.Forms.TextBox supplierNameTxt;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox itemIdTxt;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox itemSupplierCodeTxt;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox itemGroupBox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button addSupplierBtn;
        private System.Windows.Forms.TextBox unitPriceText;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox itemNameTxt;
        private System.Windows.Forms.TabPage items;
        private System.Windows.Forms.Button removeItemBtn;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TabPage suppliers;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabControl supplierTab;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox removeSupplierId;
        private System.Windows.Forms.Button removeSupplierBtn;
        private System.Windows.Forms.Button addNewMaterial_btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView5;
        private System.Windows.Forms.TextBox leadTime_txt;
        private System.Windows.Forms.Label label17;
    }
}
