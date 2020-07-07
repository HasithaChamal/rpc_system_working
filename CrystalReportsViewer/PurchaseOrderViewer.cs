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
    public partial class PurchaseOrderViewer : Form
    {
        public PurchaseOrderViewer()
        {
            InitializeComponent();
        }

        private void PurchaseOrderViewer_Load(object sender, EventArgs e)
        {
            //set start date parameter

            ParameterFields From = new ParameterFields();
            ParameterField PID = new ParameterField();
            PID.Name = "FromDate";
            ParameterDiscreteValue val = new ParameterDiscreteValue();
            val.Value = Reports.startDate;
            PID.CurrentValues.Add(val);
            From.Add(PID);
            porptviewer.ParameterFieldInfo = From;

            //set end date parameter
            ParameterField PID1 = new ParameterField();
            PID1.Name = "ToDate";
            ParameterDiscreteValue val1 = new ParameterDiscreteValue();
            val1.Value = Reports.endDate;
            PID1.CurrentValues.Add(val1);
            From.Add(PID1);
            porptviewer.ParameterFieldInfo = From;


            //create data table 
            DataTable materialtbl = new DataTable();
            DataTable idtbl = new DataTable();
            DataTable materialtblTemp = new DataTable();
     
            materialtbl.Columns.Add("po_id");
            materialtbl.Columns.Add("supplier_id");
            materialtbl.Columns.Add("creation_time");
            materialtbl.Columns.Add("material_id");
            materialtbl.Columns.Add("qty");
            materialtbl.Columns.Add("name");

            //create po id table
            try
            {
                String query;
                if (Reports.sortbysupclient == false)
                {
                    query = "SELECT po_id, creation_time, supplier_id  FROM purchaseorder where  approval='Approved' AND creation_time between '" + Reports.startDate + "' and '" + Reports.endDate + "'  ";
                }
                else 
                {
                    query = "SELECT po_id, creation_time, supplier_id  FROM purchaseorder where  approval='Approved' AND creation_time between '" + Reports.startDate + "' and '" + Reports.endDate + "'  AND supplier_id='" + Reports.supclientval + "' ";
                }
                var dataAdapter = new MySqlDataAdapter(query, DatabaseHandler.MySQLConnectionString);
                var commandBuilder = new MySqlCommandBuilder(dataAdapter);
                dataAdapter.Fill(idtbl);
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
            Console.WriteLine("id tbl rows"+ idtbl.Rows.Count);

            int noOfRows = idtbl.Rows.Count;

            for (int i = 0; i < noOfRows; i++)
            {

                try
                {
                    String query = "SELECT purchaseorder_item.po_id ,purchaseorder_item.material_id ,purchaseorder_item.qty , raw_material.name FROM purchaseorder_item INNER JOIN raw_material ON purchaseorder_item.material_id = raw_material.material_id  where purchaseorder_item.po_id= '" + idtbl.Rows[i][0].ToString() + "' ";
                    var dataAdapter = new MySqlDataAdapter(query, DatabaseHandler.MySQLConnectionString);
                    var commandBuilder = new MySqlCommandBuilder(dataAdapter);
                    dataAdapter.Fill(materialtblTemp);
                    Console.WriteLine(materialtblTemp.Rows.Count);
                    if (materialtblTemp.Rows.Count == 0)
                    {
                        MessageBox.Show("Error Occured! Please check input details!");
                        return;
                    }

                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
            }
            int noOfRows2 = materialtblTemp.Rows.Count;
            for (int i = 0; i < noOfRows2; i++)
            {
                DataRow rw = materialtbl.NewRow();
                rw["po_id"] = materialtblTemp.Rows[i][0];
                rw["material_id"] = materialtblTemp.Rows[i][1];
                rw["qty"] = materialtblTemp.Rows[i][2];
                rw["name"] = materialtblTemp.Rows[i][3];
                for (int j = 0; j < noOfRows; j++)
                {
                    if (materialtblTemp.Rows[i][0].ToString() == idtbl.Rows[j][0].ToString())
                    {
                        rw["supplier_id"] = idtbl.Rows[j][2];
                        rw["creation_time"] = idtbl.Rows[j][1];
                    }

                }
                materialtbl.Rows.Add(rw);
            }

            int noOfRows3 = materialtbl.Rows.Count;
            DataTable materialsumtbl = new DataTable();
            materialsumtbl.Columns.Add("material_id");
            materialsumtbl.Columns.Add("name");
            materialsumtbl.Columns.Add("qty");
            int noOfRows4 = 0;
            for (int i = 0; i < noOfRows3; i++)
            {
                noOfRows4 = materialsumtbl.Rows.Count;
                int count = 0;
                for (int j = 0; j < noOfRows4; j++)
                {
                    if (materialtbl.Rows[i][3].ToString() == materialsumtbl.Rows[j][0].ToString())
                    {
                        materialsumtbl.Rows[j][2] = Convert.ToDouble(materialtbl.Rows[i][4].ToString()) + Convert.ToDouble(materialsumtbl.Rows[j][2].ToString());
                        count++;
                    }
                }
                if (count == 0)
                {
                    DataRow rw = materialsumtbl.NewRow();
                    rw["material_id"] = materialtbl.Rows[i][3];
                    rw["qty"] = materialtbl.Rows[i][4];
                    rw["name"] = materialtbl.Rows[i][5];
                    materialsumtbl.Rows.Add(rw);
                }
            }

            if (Reports.summarize == true)
            {
                CrystalReports.purchaseOrderSummarizedReport materialsumrpt = new CrystalReports.purchaseOrderSummarizedReport();

                materialsumrpt.Database.Tables["materialsumtbl"].SetDataSource(materialsumtbl);
                porptviewer.ReportSource = null;
                porptviewer.ReportSource = materialsumrpt;

            }
            else
            {
                CrystalReports.purchaseOrder_rpt po_order_rpt = new CrystalReports.purchaseOrder_rpt();
                po_order_rpt.Database.Tables["materialtbl"].SetDataSource(materialtbl);


                porptviewer.ReportSource = null;
                porptviewer.ReportSource = po_order_rpt;
            }


        }
    }
}
