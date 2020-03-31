using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using LiveCharts; //Core of the library
using LiveCharts.Wpf; //The WPF controls


namespace rpc_working
{
    public partial class Dash : UserControl
    {
        public Dash()
        {
            InitializeComponent();
            item_order_chart.Titles.Add("Item Orders");
            purchase_order_chart.Titles.Add("Purchase Orders");
        }


        private void populate_item_order() {

           int approved = DatabaseHandler.returnRowCountWithoutParams("SELECT * from itemorder WHERE approval='Approved'");
           int pending = DatabaseHandler.returnRowCountWithoutParams("SELECT * from itemorder WHERE approval='Pending'");
           int declined = DatabaseHandler.returnRowCountWithoutParams("SELECT * from itemorder WHERE approval='Approved'");
           int released = DatabaseHandler.returnRowCountWithoutParams("SELECT * from itemorder WHERE released='Yes'");

            item_order_chart.Series["itemOder"].IsValueShownAsLabel = true;
            item_order_chart.Series["itemOder"].Points.AddXY("Approved", approved);
            item_order_chart.Series["itemOder"].Points.AddXY("Pending", pending);
            item_order_chart.Series["itemOder"].Points.AddXY("Declined", declined);
            item_order_chart.Series["itemOder"].Points.AddXY("Released", released);

        }


        private void fill_purchase_order()
        {

            int approved = DatabaseHandler.returnRowCountWithoutParams("SELECT * from purchaseorder WHERE approval='Approved'");
            int pending = DatabaseHandler.returnRowCountWithoutParams("SELECT * from purchaseorder WHERE approval='Pending'");
            int declined = DatabaseHandler.returnRowCountWithoutParams("SELECT * from purchaseorder WHERE approval='Approved'");
            int recieved = DatabaseHandler.returnRowCountWithoutParams("SELECT * from purchaseorder WHERE recieved='Yes'");

            purchase_order_chart.Series["purchaseOrder"].IsValueShownAsLabel = true;
            purchase_order_chart.Series["purchaseOrder"].Points.AddXY("Approved", approved);
            purchase_order_chart.Series["purchaseOrder"].Points.AddXY("Pending", pending);
            purchase_order_chart.Series["purchaseOrder"].Points.AddXY("Declined", declined);
            purchase_order_chart.Series["purchaseOrder"].Points.AddXY("Released", recieved);

        }

        private void fill_production_order()
        {

            int approved = DatabaseHandler.returnRowCountWithoutParams("SELECT * from productionorder WHERE approval='Approved'");
            int pending = DatabaseHandler.returnRowCountWithoutParams("SELECT * from productionorder WHERE approval='Pending'");
            int declined = DatabaseHandler.returnRowCountWithoutParams("SELECT * from productionorder WHERE approval='Approved'");
            int recieved = DatabaseHandler.returnRowCountWithoutParams("SELECT * from productionorder WHERE recieved='Yes'");

            productionOrder_chart.Series["productionOrder"].IsValueShownAsLabel = true;
            productionOrder_chart.Series["productionOrder"].Points.AddXY("Approved", approved);
            productionOrder_chart.Series["productionOrder"].Points.AddXY("Pending", pending);
            productionOrder_chart.Series["productionOrder"].Points.AddXY("Declined", declined);
            productionOrder_chart.Series["productionOrder"].Points.AddXY("Released", recieved);

        }

        private void fill_materialDispatch_order()
        {

            int approved = DatabaseHandler.returnRowCountWithoutParams("SELECT * from material_dispatch WHERE approval='Approved'");
            int pending = DatabaseHandler.returnRowCountWithoutParams("SELECT * from material_dispatch WHERE approval='Pending'");
            int declined = DatabaseHandler.returnRowCountWithoutParams("SELECT * from material_dispatch WHERE approval='Approved'");
            int released = DatabaseHandler.returnRowCountWithoutParams("SELECT * from material_dispatch WHERE released='Yes'");

            raw_materialDispatch_chart.Series["material_dispatch"].IsValueShownAsLabel = true;
            raw_materialDispatch_chart.Series["material_dispatch"].Points.AddXY("Approved", approved);
            raw_materialDispatch_chart.Series["material_dispatch"].Points.AddXY("Pending", pending);
            raw_materialDispatch_chart.Series["material_dispatch"].Points.AddXY("Declined", declined);
            raw_materialDispatch_chart.Series["material_dispatch"].Points.AddXY("Released", released);

        }

        private void setmateriallbl() {

            string querry = "SELECT * FROM raw_material WHERE qty<10 ";
            int count = DatabaseHandler.returnRowCountWithoutParams(querry);
            material_lbl.Text = count.ToString();

        }
        private void setproductlbl()
        {

            string querry = "SELECT * FROM item WHERE qty<50 ";
            int count = DatabaseHandler.returnRowCountWithoutParams(querry);
            products_lbl.Text = count.ToString();

        }


        private void Dash_Load(object sender, EventArgs e)
        {
            populate_item_order();
            fill_purchase_order();
            fill_production_order();
            fill_materialDispatch_order();
            setmateriallbl();
            setproductlbl();
        }




    }



}
