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
using DocumentFormat.OpenXml.Drawing;

namespace rpc_working
{
    public partial class Dash : UserControl
    {
        public Dash()
        {
            InitializeComponent();
        
        }


        private void populate_item_order() {

           int pending = DatabaseHandler.returnRowCountWithoutParams("SELECT * from itemorder WHERE approval='Pending'");
           int declined = DatabaseHandler.returnRowCountWithoutParams("SELECT * from itemorder WHERE approval='Declined'");
          
            itemOrder_lbl.Text = pending.ToString();
            declinedOrders_lbl.Text = declined.ToString();
        }


        private void fill_purchase_order()
        {

             int pending = DatabaseHandler.returnRowCountWithoutParams("SELECT * from purchaseorder WHERE approval='Pending'");
          
            purchaseOrder_lbl.Text = pending.ToString();

        }

        private void fill_production_order()
        {

            int pending = DatabaseHandler.returnRowCountWithoutParams("SELECT * from productionorder WHERE approval='Pending'");

            productionOrder_lbl.Text = pending.ToString();
          
        }

        private void fill_materialDispatch_order()
        {

            int pending = DatabaseHandler.returnRowCountWithoutParams("SELECT * from material_dispatch WHERE approval='Pending'");

            materialDispatch_lbl.Text = pending.ToString();

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
        private void setItemOrdersGraph()
        {

            DataTable itemtblTemp = new DataTable();
            DataTable itemtbl = new DataTable();
            DataTable itemsumtbl = new DataTable();

            DataTable idtbl = new DataTable();
            itemtbl.Columns.Add("io_id");
            itemtbl.Columns.Add("client_id");
            itemtbl.Columns.Add("creation_time");
            itemtbl.Columns.Add("item_id");
            itemtbl.Columns.Add("qty");
            itemtbl.Columns.Add("name");
            itemtbl.Columns.Add("released");
            itemtbl.Columns.Add("latest_delivery_time");

           

            //create item id table
            try
            {
                String query;
               

                    query = "SELECT io_id , client_id, creation_time, released , latest_delivery_time  FROM itemorder where  approval='Approved'  ";
                
                var dataAdapter = new MySqlDataAdapter(query, DatabaseHandler.MySQLConnectionString);
                var commandBuilder = new MySqlCommandBuilder(dataAdapter);
                dataAdapter.Fill(idtbl);
                Console.WriteLine("Rows are " + idtbl.Rows.Count);
                if (idtbl.Rows.Count == 0)
                {
                    MessageBox.Show("NO Entries available");
                    
                    return;
                }

            }
            catch (Exception er)
            {
                MessageBox.Show("Error Occured! ");
                Console.WriteLine(er.Message);
                return;
            }


            int noOfRows = idtbl.Rows.Count;

            for (int i = 0; i < noOfRows; i++)
            {

                try
                {

                    String query = "SELECT itemorder_item.io_id, itemorder_item.item_id ,itemorder_item.qty , item.name FROM itemorder_item INNER JOIN item ON itemorder_item.item_id = item.item_id  where itemorder_item.io_id= '" + idtbl.Rows[i][0].ToString() + "' ";
                    var dataAdapter = new MySqlDataAdapter(query, DatabaseHandler.MySQLConnectionString);
                    var commandBuilder = new MySqlCommandBuilder(dataAdapter);
                    dataAdapter.Fill(itemtblTemp);
                    Console.WriteLine(itemtblTemp.Rows.Count);

                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
            }
            if (itemtblTemp.Rows.Count == 0)
            {
                MessageBox.Show("Error Occured! Please check input details!");
                return;
            }
            int noOfRows2 = itemtblTemp.Rows.Count;
            for (int i = 0; i < noOfRows2; i++)
            {
                DataRow rw = itemtbl.NewRow();
                rw["io_id"] = itemtblTemp.Rows[i][0];
                rw["item_id"] = itemtblTemp.Rows[i][1];
                rw["qty"] = itemtblTemp.Rows[i][2];
                rw["name"] = itemtblTemp.Rows[i][3];
                for (int j = 0; j < noOfRows; j++)
                {
                    if (itemtblTemp.Rows[i][0].ToString() == idtbl.Rows[j][0].ToString())
                    {
                        rw["client_id"] = idtbl.Rows[j][1];
                        rw["creation_time"] = idtbl.Rows[j][2];
                        rw["released"] = idtbl.Rows[j][3];
                        rw["latest_delivery_time"] = idtbl.Rows[j][4];
                    }

                }
                itemtbl.Rows.Add(rw);
            }
            Console.WriteLine("item tbl rows" + itemtbl.Rows.Count);
            int noOfRows3 = itemtbl.Rows.Count;


            itemsumtbl.Columns.Add("item_id");
            itemsumtbl.Columns.Add("name");
            itemsumtbl.Columns.Add("qty");
            int noOfRows4 = 0;
            for (int i = 0; i < noOfRows3; i++)
            {
                noOfRows4 = itemsumtbl.Rows.Count;
                int count = 0;
                for (int j = 0; j < noOfRows4; j++)
                {
                    if (itemtbl.Rows[i][3].ToString() == itemsumtbl.Rows[j][0].ToString())
                    {
                        itemsumtbl.Rows[j][2] = Convert.ToInt32(itemtbl.Rows[i][4].ToString()) + Convert.ToInt32(itemsumtbl.Rows[j][2].ToString());
                        count++;
                    }
                }
                if (count == 0)
                {
                    DataRow rw = itemsumtbl.NewRow();
                    rw["item_id"] = itemtbl.Rows[i][3];
                    rw["qty"] = itemtbl.Rows[i][4];
                    rw["name"] = itemtbl.Rows[i][5];
                    itemsumtbl.Rows.Add(rw);
                }
            }

            noOfRows4 = itemsumtbl.Rows.Count;

            for (int i = 0; i < noOfRows4; i++)
            {
                ItemOrderChart.Series["items"].Points.AddXY(itemsumtbl.Rows[i][1].ToString(), Convert.ToInt32(itemsumtbl.Rows[i][2].ToString()));
              
            
            }

            DataTable monthqty = new DataTable();
            monthqty.Columns.Add("month");
            monthqty.Columns.Add("qty");

            for (int i = 0; i < noOfRows3; i++)
            {
                DateTime date = Convert.ToDateTime(itemtbl.Rows[i][2].ToString());
                string month = date.ToString("MMMM");
                int rowcount = monthqty.Rows.Count;
                int count = 0;

                for (int j = 0; j < rowcount; j++) 
                {
                    
                    if (month == monthqty.Rows[j][0].ToString())
                    {
                        monthqty.Rows[j][1] = Convert.ToInt32(monthqty.Rows[j][1].ToString()) + Convert.ToInt32(itemtbl.Rows[i][4].ToString());
                        count++;
                    }
                    
                }

                if (count == 0) 
                {
                    DataRow rw = monthqty.NewRow();
                    rw["month"] = month;
                    rw["qty"] = itemtbl.Rows[i][4];
                    monthqty.Rows.Add(rw);
                }

            }
            int noOfRows5 = monthqty.Rows.Count;
            Console.WriteLine("month table count"+ noOfRows5);

            for (int i = 0; i < noOfRows5; i++)
            {
                monthlyItemOdersChart.Series["items"].Points.AddXY(monthqty.Rows[i][0].ToString(), Convert.ToInt32(monthqty.Rows[i][1].ToString()));
            }


            int count2=0;
            DateTime currentdt = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy"));

            

            for (int i = 0; i < noOfRows3; i++)
            {
                DateTime date1;
                DateTime.TryParse( (itemtbl.Rows[i][7].ToString()),out date1);
                if (date1.Date > currentdt.Date && itemtbl.Rows[i][6].ToString() == "No") 
                {
                    count2++;
                }

            }

            delayedItemOrders_lbl.Text = count2.ToString();

            }

        private void setProductionGraph()
        {
            DataTable itemsumtbl = new DataTable();
            DataTable itemtbl = new DataTable();
            DataTable itemtblTemp = new DataTable();

            DataTable idtbl = new DataTable();
            itemtbl.Columns.Add("pro_id");
            itemtbl.Columns.Add("creation_time");
            itemtbl.Columns.Add("item_id");
            itemtbl.Columns.Add("qty");
            itemtbl.Columns.Add("name");

            //create item id table
            try
            {
                String query = "SELECT pro_id , creation_time  FROM productionorder where  recieved='Yes' ";
                var dataAdapter = new MySqlDataAdapter(query, DatabaseHandler.MySQLConnectionString);
                var commandBuilder = new MySqlCommandBuilder(dataAdapter);
                dataAdapter.Fill(idtbl);
                Console.WriteLine("Rows are " + idtbl.Rows.Count);
               

            }
            catch (Exception er)
            {
                MessageBox.Show("Error Occured! ");
                Console.WriteLine(er.Message);
                return;
            }


            int noOfRows = idtbl.Rows.Count;

            for (int i = 0; i < noOfRows; i++)
            {

                try
                {

                    String query = "SELECT productionorder_item.pro_id, productionorder_item.item_id ,productionorder_item.qty , item.name FROM productionorder_item INNER JOIN item ON productionorder_item.item_id = item.item_id  where productionorder_item.pro_id= '" + idtbl.Rows[i][0].ToString() + "' ";
                    var dataAdapter = new MySqlDataAdapter(query, DatabaseHandler.MySQLConnectionString);
                    var commandBuilder = new MySqlCommandBuilder(dataAdapter);
                    dataAdapter.Fill(itemtblTemp);
                    Console.WriteLine(itemtblTemp.Rows.Count);

                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
            }
            if (itemtblTemp.Rows.Count == 0)
            {
                MessageBox.Show("Error Occured! Please check input details!");
                return;
            }
            int noOfRows2 = itemtblTemp.Rows.Count;
            for (int i = 0; i < noOfRows2; i++)
            {
                DataRow rw = itemtbl.NewRow();
                rw["pro_id"] = itemtblTemp.Rows[i][0];
                rw["item_id"] = itemtblTemp.Rows[i][1];
                rw["qty"] = itemtblTemp.Rows[i][2];
                rw["name"] = itemtblTemp.Rows[i][3];
                for (int j = 0; j < noOfRows; j++)
                {
                    if (itemtblTemp.Rows[i][0].ToString() == idtbl.Rows[j][0].ToString())
                    {
                        rw["creation_time"] = idtbl.Rows[j][1];
                    }

                }
                itemtbl.Rows.Add(rw);
            }
            Console.WriteLine("item tbl rows" + itemtbl.Rows.Count);

            int noOfRows3 = itemtbl.Rows.Count;

            itemsumtbl.Columns.Add("item_id");
            itemsumtbl.Columns.Add("name");
            itemsumtbl.Columns.Add("qty");
            int noOfRows4 = 0;
            for (int i = 0; i < noOfRows3; i++)
            {
                noOfRows4 = itemsumtbl.Rows.Count;
                int count = 0;
                for (int j = 0; j < noOfRows4; j++)
                {
                    if (itemtbl.Rows[i][2].ToString() == itemsumtbl.Rows[j][0].ToString())
                    {
                        itemsumtbl.Rows[j][2] = Convert.ToDouble(itemtbl.Rows[i][3].ToString()) + Convert.ToDouble(itemsumtbl.Rows[j][2].ToString());
                        count++;
                    }
                }
                if (count == 0)
                {
                    DataRow rw = itemsumtbl.NewRow();
                    rw["item_id"] = itemtbl.Rows[i][2];
                    rw["name"] = itemtbl.Rows[i][4];
                    rw["qty"] = itemtbl.Rows[i][3];
                    itemsumtbl.Rows.Add(rw);
                }
            }

            noOfRows4 = itemsumtbl.Rows.Count;

            for (int i = 0; i < noOfRows4; i++)
            {
                productionQtyChart.Series["items"].Points.AddXY(itemsumtbl.Rows[i][1].ToString(), Convert.ToInt32(itemsumtbl.Rows[i][2].ToString()));
            }


            DataTable monthqty = new DataTable();
            monthqty.Columns.Add("month");
            monthqty.Columns.Add("qty");

            for (int i = 0; i < noOfRows3; i++)
            {
                DateTime date = Convert.ToDateTime(itemtbl.Rows[i][1].ToString());
                string month = date.ToString("MMMM");
                int rowcount = monthqty.Rows.Count;
                int count = 0;

                for (int j = 0; j < rowcount; j++)
                {

                    if (month == monthqty.Rows[j][0].ToString())
                    {
                        monthqty.Rows[j][1] = Convert.ToInt32(monthqty.Rows[j][1].ToString()) + Convert.ToInt32(itemtbl.Rows[i][3].ToString());
                        count++;
                    }

                }

                if (count == 0)
                {
                    DataRow rw = monthqty.NewRow();
                    rw["month"] = month;
                    rw["qty"] = itemtbl.Rows[i][3];
                    monthqty.Rows.Add(rw);
                }

            }
            int noOfRows5 = monthqty.Rows.Count;
            Console.WriteLine("month table count" + noOfRows5);

            for (int i = 0; i < noOfRows5; i++)
            {
                productionChart.Series["items"].Points.AddXY(monthqty.Rows[i][0].ToString(), Convert.ToInt32(monthqty.Rows[i][1].ToString()));
            }


        }

        private void Dash_Load(object sender, EventArgs e)
        {
            populate_item_order();
            fill_purchase_order();
            fill_production_order();
            fill_materialDispatch_order();
            setmateriallbl();
            setproductlbl();
            setItemOrdersGraph();
            setProductionGraph();
        }

        private void panel2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Displays the count of low quantity material types", panel2);
        }

        private void panel1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Displays the count of low quantity item types", panel1);
        }

        private void panel3_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Displays the count of pending item dispatch requests", panel3);
        }

        private void panel5_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Displays the count of pending material purchase order requests", panel5);
        }

        private void panel4_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Displays the count of pending production order requests", panel4);
        }

        private void panel6_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Displays the count of pending material dispatch requests", panel6);
        }

        private void ItemOrderChart_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Displays the total quantity of dispatched items by item types", ItemOrderChart);
        }

        private void monthlyItemOdersChart_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Displays the total quantity of dispatched items by name of month", monthlyItemOdersChart);
        }

        private void productionQtyChart_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Displays the total quantity of manufactured items by item types", productionQtyChart);
        }

        private void productionChart_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Displays the total quantity of manufactured items by name of month", productionChart);
        }

        private void panel7_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Displays the count of item orders which has exceeded the latest delivery time", panel7);
        }

        private void panel8_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Displays the count of item orders which has been declined", panel7);
        }
    }



}
