using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using CrystalDecisions.Shared;

namespace rpc_working.CrystalReportsViewer
{
    public partial class ProductStock : Form
    {
        public ProductStock()
        {
            InitializeComponent();
        }

        private void ProductStock_Load(object sender, EventArgs e)
        {

            DataTable stocktbl = new DataTable();
            stocktbl.Columns.Add("item_id");
            stocktbl.Columns.Add("name");
            stocktbl.Columns.Add("qty");
            stocktbl.Columns.Add("unit_price");

            try
            {
                String query = "SELECT item_id , name, qty, unit_price from item ";
                var dataAdapter = new MySqlDataAdapter(query, DatabaseHandler.MySQLConnectionString);
                var commandBuilder = new MySqlCommandBuilder(dataAdapter);
                dataAdapter.Fill(stocktbl);
                Console.WriteLine(stocktbl.Rows.Count);

                int noOfRows2 = stocktbl.Rows.Count;

            }
            catch (Exception er)
            {
                MessageBox.Show("Error Occured! Failed to get product stock");
                Console.WriteLine(er.Message);
                return;
            }
            try
            {
                if (stocktbl.Rows.Count == 0)
                {
                    MessageBox.Show("Error Occured! Failed to get product stock");
                    return;
                }
                CrystalReports.productStockReport productStockrpt = new CrystalReports.productStockReport();
                productStockrpt.Database.Tables["stocktbl"].SetDataSource(stocktbl);

                ProductStockrptViewer.ReportSource = null;
                ProductStockrptViewer.ReportSource = productStockrpt;
            }
            catch (Exception)
            {
                MessageBox.Show("Error Occured! Please check input details!");
            }
        }
    }
}
