namespace rpc_working
{
    partial class Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.panel2 = new System.Windows.Forms.Panel();
            this.userName_lbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.logoutBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.homeBtn = new System.Windows.Forms.Button();
            this.storeBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bom_btn = new System.Windows.Forms.Button();
            this.productionOrder_btn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.materialDispatch = new System.Windows.Forms.Button();
            this.ItemdispatchBtn = new System.Windows.Forms.Button();
            this.SidePanel = new System.Windows.Forms.Panel();
            this.clientsBtn = new System.Windows.Forms.Button();
            this.suppliersBtn = new System.Windows.Forms.Button();
            this.userBtn = new System.Windows.Forms.Button();
            this.purchasingBtn = new System.Windows.Forms.Button();
            this.recievingBtn = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.bom1 = new rpc_working.BOM();
            this.productionOrder1 = new rpc_working.ProductionOrder();
            this.itemDispatch1 = new rpc_working.ItemDispatch();
            this.recieving1 = new rpc_working.Recieving();
            this.purchasing1 = new rpc_working.Purchasing();
            this.stores1 = new rpc_working.Stores();
            this.client1 = new rpc_working.Client();
            this.supplier1 = new rpc_working.Supplier();
            this.users1 = new rpc_working.Users();
            this.home1 = new rpc_working.Home();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel2.Controls.Add(this.userName_lbl);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.logoutBtn);
            this.panel2.Controls.Add(this.ExitBtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(210, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1160, 32);
            this.panel2.TabIndex = 1;
            // 
            // userName_lbl
            // 
            this.userName_lbl.AutoSize = true;
            this.userName_lbl.BackColor = System.Drawing.Color.Black;
            this.userName_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userName_lbl.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.userName_lbl.Location = new System.Drawing.Point(812, 6);
            this.userName_lbl.Name = "userName_lbl";
            this.userName_lbl.Size = new System.Drawing.Size(45, 17);
            this.userName_lbl.TabIndex = 12;
            this.userName_lbl.Text = "Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(726, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "WELCOME   ";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(223, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label1.Size = new System.Drawing.Size(306, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "\"RPC System\" - Purelac Coatings Ltd";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // logoutBtn
            // 
            this.logoutBtn.BackColor = System.Drawing.Color.MediumOrchid;
            this.logoutBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.logoutBtn.FlatAppearance.BorderSize = 0;
            this.logoutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logoutBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutBtn.ForeColor = System.Drawing.Color.White;
            this.logoutBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.logoutBtn.Location = new System.Drawing.Point(3, 1);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(140, 26);
            this.logoutBtn.TabIndex = 8;
            this.logoutBtn.Text = "Log Out";
            this.logoutBtn.UseVisualStyleBackColor = false;
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
            // 
            // ExitBtn
            // 
            this.ExitBtn.BackColor = System.Drawing.Color.OrangeRed;
            this.ExitBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ExitBtn.FlatAppearance.BorderSize = 0;
            this.ExitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitBtn.ForeColor = System.Drawing.Color.White;
            this.ExitBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ExitBtn.Location = new System.Drawing.Point(1075, 1);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(85, 24);
            this.ExitBtn.TabIndex = 9;
            this.ExitBtn.Text = "Exit";
            this.ExitBtn.UseVisualStyleBackColor = false;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // homeBtn
            // 
            this.homeBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.homeBtn.FlatAppearance.BorderSize = 0;
            this.homeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.homeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.homeBtn.ForeColor = System.Drawing.Color.White;
            this.homeBtn.Image = ((System.Drawing.Image)(resources.GetObject("homeBtn.Image")));
            this.homeBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.homeBtn.Location = new System.Drawing.Point(11, 12);
            this.homeBtn.Name = "homeBtn";
            this.homeBtn.Padding = new System.Windows.Forms.Padding(10);
            this.homeBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.homeBtn.Size = new System.Drawing.Size(184, 52);
            this.homeBtn.TabIndex = 0;
            this.homeBtn.Text = "     Home";
            this.homeBtn.UseVisualStyleBackColor = true;
            this.homeBtn.Click += new System.EventHandler(this.HomeBtn);
            // 
            // storeBtn
            // 
            this.storeBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.storeBtn.FlatAppearance.BorderSize = 0;
            this.storeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.storeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.storeBtn.ForeColor = System.Drawing.Color.White;
            this.storeBtn.Image = ((System.Drawing.Image)(resources.GetObject("storeBtn.Image")));
            this.storeBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.storeBtn.Location = new System.Drawing.Point(8, 120);
            this.storeBtn.Name = "storeBtn";
            this.storeBtn.Padding = new System.Windows.Forms.Padding(10);
            this.storeBtn.Size = new System.Drawing.Size(182, 52);
            this.storeBtn.TabIndex = 1;
            this.storeBtn.Text = "     Store";
            this.storeBtn.UseVisualStyleBackColor = true;
            this.storeBtn.Click += new System.EventHandler(this.storeBtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.bom_btn);
            this.panel1.Controls.Add(this.productionOrder_btn);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.materialDispatch);
            this.panel1.Controls.Add(this.ItemdispatchBtn);
            this.panel1.Controls.Add(this.SidePanel);
            this.panel1.Controls.Add(this.clientsBtn);
            this.panel1.Controls.Add(this.suppliersBtn);
            this.panel1.Controls.Add(this.userBtn);
            this.panel1.Controls.Add(this.purchasingBtn);
            this.panel1.Controls.Add(this.recievingBtn);
            this.panel1.Controls.Add(this.storeBtn);
            this.panel1.Controls.Add(this.homeBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(210, 749);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // bom_btn
            // 
            this.bom_btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bom_btn.FlatAppearance.BorderSize = 0;
            this.bom_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bom_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bom_btn.ForeColor = System.Drawing.Color.White;
            this.bom_btn.Image = ((System.Drawing.Image)(resources.GetObject("bom_btn.Image")));
            this.bom_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bom_btn.Location = new System.Drawing.Point(14, 670);
            this.bom_btn.Name = "bom_btn";
            this.bom_btn.Padding = new System.Windows.Forms.Padding(10);
            this.bom_btn.Size = new System.Drawing.Size(219, 52);
            this.bom_btn.TabIndex = 14;
            this.bom_btn.Text = "       Bill of Material ";
            this.bom_btn.UseVisualStyleBackColor = true;
            this.bom_btn.Click += new System.EventHandler(this.Bom_btn_Click);
            // 
            // productionOrder_btn
            // 
            this.productionOrder_btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.productionOrder_btn.FlatAppearance.BorderSize = 0;
            this.productionOrder_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.productionOrder_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productionOrder_btn.ForeColor = System.Drawing.Color.White;
            this.productionOrder_btn.Image = ((System.Drawing.Image)(resources.GetObject("productionOrder_btn.Image")));
            this.productionOrder_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.productionOrder_btn.Location = new System.Drawing.Point(14, 601);
            this.productionOrder_btn.Name = "productionOrder_btn";
            this.productionOrder_btn.Padding = new System.Windows.Forms.Padding(10);
            this.productionOrder_btn.Size = new System.Drawing.Size(219, 52);
            this.productionOrder_btn.TabIndex = 13;
            this.productionOrder_btn.Text = "      Production Order";
            this.productionOrder_btn.UseVisualStyleBackColor = true;
            this.productionOrder_btn.Click += new System.EventHandler(this.ProductionOrder_btn_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(8, 70);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(10);
            this.button1.Size = new System.Drawing.Size(182, 52);
            this.button1.TabIndex = 12;
            this.button1.Text = "       Reports";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // materialDispatch
            // 
            this.materialDispatch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.materialDispatch.FlatAppearance.BorderSize = 0;
            this.materialDispatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.materialDispatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialDispatch.ForeColor = System.Drawing.Color.White;
            this.materialDispatch.Image = ((System.Drawing.Image)(resources.GetObject("materialDispatch.Image")));
            this.materialDispatch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.materialDispatch.Location = new System.Drawing.Point(8, 294);
            this.materialDispatch.Name = "materialDispatch";
            this.materialDispatch.Padding = new System.Windows.Forms.Padding(10);
            this.materialDispatch.Size = new System.Drawing.Size(225, 52);
            this.materialDispatch.TabIndex = 11;
            this.materialDispatch.Text = "       Material Dispatch";
            this.materialDispatch.UseVisualStyleBackColor = true;
            this.materialDispatch.Click += new System.EventHandler(this.MaterialDispatch_Click);
            // 
            // ItemdispatchBtn
            // 
            this.ItemdispatchBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ItemdispatchBtn.FlatAppearance.BorderSize = 0;
            this.ItemdispatchBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ItemdispatchBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemdispatchBtn.ForeColor = System.Drawing.Color.White;
            this.ItemdispatchBtn.Image = ((System.Drawing.Image)(resources.GetObject("ItemdispatchBtn.Image")));
            this.ItemdispatchBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ItemdispatchBtn.Location = new System.Drawing.Point(8, 352);
            this.ItemdispatchBtn.Name = "ItemdispatchBtn";
            this.ItemdispatchBtn.Padding = new System.Windows.Forms.Padding(10);
            this.ItemdispatchBtn.Size = new System.Drawing.Size(202, 52);
            this.ItemdispatchBtn.TabIndex = 10;
            this.ItemdispatchBtn.Text = "       Item Dispatch";
            this.ItemdispatchBtn.UseVisualStyleBackColor = true;
            this.ItemdispatchBtn.Click += new System.EventHandler(this.dispatchBtn_Click);
            // 
            // SidePanel
            // 
            this.SidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.SidePanel.Location = new System.Drawing.Point(8, 12);
            this.SidePanel.Name = "SidePanel";
            this.SidePanel.Size = new System.Drawing.Size(12, 52);
            this.SidePanel.TabIndex = 2;
            // 
            // clientsBtn
            // 
            this.clientsBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.clientsBtn.FlatAppearance.BorderSize = 0;
            this.clientsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clientsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientsBtn.ForeColor = System.Drawing.Color.White;
            this.clientsBtn.Image = ((System.Drawing.Image)(resources.GetObject("clientsBtn.Image")));
            this.clientsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.clientsBtn.Location = new System.Drawing.Point(11, 468);
            this.clientsBtn.Name = "clientsBtn";
            this.clientsBtn.Padding = new System.Windows.Forms.Padding(10);
            this.clientsBtn.Size = new System.Drawing.Size(184, 52);
            this.clientsBtn.TabIndex = 7;
            this.clientsBtn.Text = "       Clients";
            this.clientsBtn.UseVisualStyleBackColor = true;
            this.clientsBtn.Click += new System.EventHandler(this.clientsBtn_Click);
            // 
            // suppliersBtn
            // 
            this.suppliersBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.suppliersBtn.FlatAppearance.BorderSize = 0;
            this.suppliersBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.suppliersBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suppliersBtn.ForeColor = System.Drawing.Color.White;
            this.suppliersBtn.Image = ((System.Drawing.Image)(resources.GetObject("suppliersBtn.Image")));
            this.suppliersBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.suppliersBtn.Location = new System.Drawing.Point(12, 410);
            this.suppliersBtn.Name = "suppliersBtn";
            this.suppliersBtn.Padding = new System.Windows.Forms.Padding(10);
            this.suppliersBtn.Size = new System.Drawing.Size(184, 52);
            this.suppliersBtn.TabIndex = 6;
            this.suppliersBtn.Text = "           Suppliers";
            this.suppliersBtn.UseVisualStyleBackColor = true;
            this.suppliersBtn.Click += new System.EventHandler(this.suppliersBtn_Click);
            // 
            // userBtn
            // 
            this.userBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.userBtn.FlatAppearance.BorderSize = 0;
            this.userBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.userBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userBtn.ForeColor = System.Drawing.Color.White;
            this.userBtn.Image = ((System.Drawing.Image)(resources.GetObject("userBtn.Image")));
            this.userBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.userBtn.Location = new System.Drawing.Point(14, 526);
            this.userBtn.Name = "userBtn";
            this.userBtn.Padding = new System.Windows.Forms.Padding(10);
            this.userBtn.Size = new System.Drawing.Size(184, 52);
            this.userBtn.TabIndex = 5;
            this.userBtn.Text = "     Users";
            this.userBtn.UseVisualStyleBackColor = true;
            this.userBtn.Click += new System.EventHandler(this.userBtn_Click);
            // 
            // purchasingBtn
            // 
            this.purchasingBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.purchasingBtn.FlatAppearance.BorderSize = 0;
            this.purchasingBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.purchasingBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.purchasingBtn.ForeColor = System.Drawing.Color.White;
            this.purchasingBtn.Image = ((System.Drawing.Image)(resources.GetObject("purchasingBtn.Image")));
            this.purchasingBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.purchasingBtn.Location = new System.Drawing.Point(14, 236);
            this.purchasingBtn.Name = "purchasingBtn";
            this.purchasingBtn.Padding = new System.Windows.Forms.Padding(10, 10, 0, 10);
            this.purchasingBtn.Size = new System.Drawing.Size(194, 52);
            this.purchasingBtn.TabIndex = 4;
            this.purchasingBtn.Text = "          Purchasing";
            this.purchasingBtn.UseVisualStyleBackColor = true;
            this.purchasingBtn.Click += new System.EventHandler(this.purchasingBtn_Click);
            // 
            // recievingBtn
            // 
            this.recievingBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.recievingBtn.FlatAppearance.BorderSize = 0;
            this.recievingBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.recievingBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recievingBtn.ForeColor = System.Drawing.Color.White;
            this.recievingBtn.Image = ((System.Drawing.Image)(resources.GetObject("recievingBtn.Image")));
            this.recievingBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.recievingBtn.Location = new System.Drawing.Point(8, 178);
            this.recievingBtn.Name = "recievingBtn";
            this.recievingBtn.Padding = new System.Windows.Forms.Padding(10);
            this.recievingBtn.Size = new System.Drawing.Size(184, 52);
            this.recievingBtn.TabIndex = 3;
            this.recievingBtn.Text = "           Recieving";
            this.recievingBtn.UseVisualStyleBackColor = true;
            this.recievingBtn.Click += new System.EventHandler(this.recievingBtn_Click);
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(210, 749);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1160, 0);
            this.panel4.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.Location = new System.Drawing.Point(193, 26);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(0, 0);
            this.panel5.TabIndex = 3;
            // 
            // panel6
            // 
            this.panel6.Location = new System.Drawing.Point(201, 26);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(0, 0);
            this.panel6.TabIndex = 4;
            // 
            // bom1
            // 
            this.bom1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bom1.Location = new System.Drawing.Point(210, 26);
            this.bom1.Name = "bom1";
            this.bom1.Size = new System.Drawing.Size(1160, 723);
            this.bom1.TabIndex = 14;
            // 
            // productionOrder1
            // 
            this.productionOrder1.AutoSize = true;
            this.productionOrder1.BackColor = System.Drawing.Color.White;
            this.productionOrder1.Location = new System.Drawing.Point(210, 27);
            this.productionOrder1.Name = "productionOrder1";
            this.productionOrder1.Size = new System.Drawing.Size(1133, 739);
            this.productionOrder1.TabIndex = 13;
            // 
            // itemDispatch1
            // 
            this.itemDispatch1.BackColor = System.Drawing.Color.White;
            this.itemDispatch1.Location = new System.Drawing.Point(210, 26);
            this.itemDispatch1.Name = "itemDispatch1";
            this.itemDispatch1.Size = new System.Drawing.Size(1165, 742);
            this.itemDispatch1.TabIndex = 12;
            this.itemDispatch1.Load += new System.EventHandler(this.ItemDispatch1_Load);
            // 
            // recieving1
            // 
            this.recieving1.BackColor = System.Drawing.Color.White;
            this.recieving1.Location = new System.Drawing.Point(210, 26);
            this.recieving1.Name = "recieving1";
            this.recieving1.Size = new System.Drawing.Size(1165, 742);
            this.recieving1.TabIndex = 11;
            // 
            // purchasing1
            // 
            this.purchasing1.AutoSize = true;
            this.purchasing1.BackColor = System.Drawing.Color.White;
            this.purchasing1.Location = new System.Drawing.Point(210, 26);
            this.purchasing1.Name = "purchasing1";
            this.purchasing1.Size = new System.Drawing.Size(1133, 719);
            this.purchasing1.TabIndex = 10;
            // 
            // stores1
            // 
            this.stores1.BackColor = System.Drawing.Color.White;
            this.stores1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stores1.Location = new System.Drawing.Point(210, 26);
            this.stores1.Name = "stores1";
            this.stores1.Size = new System.Drawing.Size(1165, 742);
            this.stores1.TabIndex = 9;
            // 
            // client1
            // 
            this.client1.BackColor = System.Drawing.Color.White;
            this.client1.Location = new System.Drawing.Point(210, 26);
            this.client1.Name = "client1";
            this.client1.Size = new System.Drawing.Size(1165, 742);
            this.client1.TabIndex = 8;
            // 
            // supplier1
            // 
            this.supplier1.BackColor = System.Drawing.Color.White;
            this.supplier1.Location = new System.Drawing.Point(210, 26);
            this.supplier1.Name = "supplier1";
            this.supplier1.Size = new System.Drawing.Size(1165, 723);
            this.supplier1.TabIndex = 7;
            // 
            // users1
            // 
            this.users1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.users1.Location = new System.Drawing.Point(210, 26);
            this.users1.Name = "users1";
            this.users1.Size = new System.Drawing.Size(1165, 742);
            this.users1.TabIndex = 6;
            // 
            // home1
            // 
            this.home1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.home1.Location = new System.Drawing.Point(210, 28);
            this.home1.Name = "home1";
            this.home1.Size = new System.Drawing.Size(1165, 742);
            this.home1.TabIndex = 5;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.bom1);
            this.Controls.Add(this.productionOrder1);
            this.Controls.Add(this.itemDispatch1);
            this.Controls.Add(this.recieving1);
            this.Controls.Add(this.purchasing1);
            this.Controls.Add(this.stores1);
            this.Controls.Add(this.client1);
            this.Controls.Add(this.supplier1);
            this.Controls.Add(this.users1);
            this.Controls.Add(this.home1);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button homeBtn;
        private System.Windows.Forms.Button storeBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button purchasingBtn;
        private System.Windows.Forms.Button recievingBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button logoutBtn;
        private System.Windows.Forms.Button clientsBtn;
        private System.Windows.Forms.Button suppliersBtn;
        private System.Windows.Forms.Button userBtn;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.Panel SidePanel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Users users1;
        private Home home1;
        private Supplier supplier1;
        private System.Windows.Forms.Button materialDispatch;
        private System.Windows.Forms.Button ItemdispatchBtn;
        private System.Windows.Forms.Button button1;
        private Client client1;
        private System.Windows.Forms.Label userName_lbl;
        private System.Windows.Forms.Label label4;
        private Stores stores1;
        private Purchasing purchasing1;
        private Recieving recieving1;
        private ItemDispatch itemDispatch1;
        private System.Windows.Forms.Button productionOrder_btn;
        private ProductionOrder productionOrder1;
        private System.Windows.Forms.Button bom_btn;
        private BOM bom1;
    }
}

