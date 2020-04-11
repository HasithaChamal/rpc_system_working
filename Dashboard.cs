using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace rpc_working
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            SidePanel.Height = homeBtn.Height;
            SidePanel.Top = homeBtn.Top;
            dash1.BringToFront();
            userName_lbl.Text = GlobalLoginData.Name;

        }

        private void HomeBtn(object sender, EventArgs e)
        {
            sidePanelLocation(homeBtn);
            dash1.BringToFront();
        }

        private void storeBtn_Click(object sender, EventArgs e)
        {
            sidePanelLocation(storeBtn);
            stores1.BringToFront();
            stores1.Stores_Load(sender, e);
        }

        private void recievingBtn_Click(object sender, EventArgs e)
        {
            sidePanelLocation(recievingBtn);
            recieving1.BringToFront();
            recieving1.Recieving_Load(sender,e);
        }

        private void purchasingBtn_Click(object sender, EventArgs e)
        {
            sidePanelLocation(purchasingBtn);
            purchasing1.BringToFront();
            purchasing1.Purchasing_Load(sender, e);
        }

        private void dispatchBtn_Click(object sender, EventArgs e)
        {
            sidePanelLocation(ItemdispatchBtn);
            itemDispatch1.BringToFront();
            itemDispatch1.Dispatch_Load(sender,e);
        }

        private void clientsBtn_Click(object sender, EventArgs e)
        {
            sidePanelLocation(clientsBtn);
            client1.BringToFront();
            client1.Client_Load(sender, e);
        }
        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void userBtn_Click(object sender, EventArgs e)
        {
            sidePanelLocation(userBtn);
            users1.BringToFront();
            users1.Users_Load(sender, e);
           
        }

        private void sidePanelLocation(Button btn)
        {
            SidePanel.Height = btn.Height;
            SidePanel.Top = btn.Top;
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new Login()).Show();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void suppliersBtn_Click(object sender, EventArgs e)
        {
            sidePanelLocation(suppliersBtn);
            supplier1.BringToFront();
            supplier1.Supplier_Load(sender, e);
        }

       
        private void MaterialDispatch_Click(object sender, EventArgs e)
        {
            sidePanelLocation(materialDispatch);
            rawMaterialDispatch1.BringToFront();
            rawMaterialDispatch1.RawMaterialDispatch_Load(sender, e);

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void ItemDispatch1_Load(object sender, EventArgs e)
        {

        }

        private void ProductionOrder_btn_Click(object sender, EventArgs e)
        {
            sidePanelLocation(productionOrder_btn);
            productionOrder1.BringToFront();
            productionOrder1.ProductionOrder_Load(sender, e);



        }

        private void Bom_btn_Click(object sender, EventArgs e)
        {
            sidePanelLocation(bom_btn);
            bom1.BringToFront();
            bom1.BOM_Load(sender, e);
        }

        private void rpt_btn_Click(object sender, EventArgs e)
        {
            sidePanelLocation(rpt_btn);
            reports1.BringToFront();

        }
    }
}
