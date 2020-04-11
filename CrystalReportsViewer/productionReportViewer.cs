using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using MySql.Data.MySqlClient;
namespace rpc_working.CrystalReportsViewer
{
    public partial class productionReportViewer : Form
    {
        public productionReportViewer()
        {
            InitializeComponent();
        }

        private void productionReportViewer_Load(object sender, EventArgs e)
        {

            //set start date parameter

            ParameterFields From = new ParameterFields();
            ParameterField PID = new ParameterField();
            PID.Name = "FromDate";
            ParameterDiscreteValue val = new ParameterDiscreteValue();
            val.Value = Reports.startDate;
            PID.CurrentValues.Add(val);
            From.Add(PID);
            productionrptViwer.ParameterFieldInfo = From; 

            //set end date parameter
            ParameterField PID1 = new ParameterField();
            PID1.Name = "ToDate";
            ParameterDiscreteValue val1 = new ParameterDiscreteValue();
            val1.Value = Reports.endDate;
            PID1.CurrentValues.Add(val1);
            From.Add(PID1);
            productionrptViwer.ParameterFieldInfo = From; 




            //create data table 
            DataTable itemtblTemp = new DataTable();
            DataTable itemtbl = new DataTable();
            DataTable idtbl = new DataTable();
            itemtbl.Columns.Add("pro_id");
            itemtbl.Columns.Add("creation_time");
            itemtbl.Columns.Add("item_id");
            itemtbl.Columns.Add("qty");
            itemtbl.Columns.Add("name");

            //create item id table
            try
            {
                String query = "SELECT pro_id , creation_time  FROM productionorder where  recieved='Yes' AND creation_time between '" + Reports.startDate + "' and '" + Reports.endDate + "'  ";
                var dataAdapter = new MySqlDataAdapter(query, DatabaseHandler.MySQLConnectionString);
                var commandBuilder = new MySqlCommandBuilder(dataAdapter);
                dataAdapter.Fill(idtbl);
                Console.WriteLine("Rows are " + idtbl.Rows.Count);
                if (idtbl.Rows.Count == 0)
                {
                    MessageBox.Show("NO Entries available");
                    this.Close();
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

            CrystalReports.ProductionReport productionrpt = new CrystalReports.ProductionReport();

            productionrpt.Database.Tables["itemtbl"].SetDataSource(itemtbl);


            productionrptViwer.ReportSource = null;
            productionrptViwer.ReportSource = productionrpt; 

        }
    }
}
