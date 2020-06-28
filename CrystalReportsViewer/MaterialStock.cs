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
    public partial class MaterialStock : Form
    {
        public MaterialStock()
        {
            InitializeComponent();
        }

        private void MaterialStock_Load(object sender, EventArgs e)
        {

            
            DataTable stocktbl = new DataTable();
            stocktbl.Columns.Add("material_id");
            stocktbl.Columns.Add("name");
            stocktbl.Columns.Add("qty");
         
            try
            {
                String query = "SELECT material_id , name, qty from raw_material ";
                var dataAdapter = new MySqlDataAdapter(query, DatabaseHandler.MySQLConnectionString);
                var commandBuilder = new MySqlCommandBuilder(dataAdapter);
                dataAdapter.Fill(stocktbl);
                Console.WriteLine(stocktbl.Rows.Count);
              
                int noOfRows2 = stocktbl.Rows.Count;
                            
            }
            catch (Exception er)
            {
                MessageBox.Show("Error Occured! Failed to get material stock");
                Console.WriteLine(er.Message);
                return;
            }
            try
            {
                if (stocktbl.Rows.Count == 0)
                {
                    MessageBox.Show("Error Occured! Failed to get material stock");
                    return;
                }
                CrystalReports.materialStockReport materialStockrpt = new CrystalReports.materialStockReport();
                materialStockrpt.Database.Tables["stocktbl"].SetDataSource(stocktbl);

                MaterialStockrptViewer.ReportSource = null;
                MaterialStockrptViewer.ReportSource = materialStockrpt;
            }
            catch (Exception)
            {
                MessageBox.Show("Error Occured! Please check input details!");
            }
        }
    }
}
