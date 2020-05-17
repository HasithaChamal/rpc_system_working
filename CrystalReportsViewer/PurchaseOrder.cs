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
    public partial class PurchaseOrderReportViewer : Form
    {
        public PurchaseOrderReportViewer()
        {
            InitializeComponent();
        }

        private void PurchaseOrderReportViewer_Load(object sender, EventArgs e)
        {

            DataTable potbltemp = new DataTable();
            DataTable potbl = new DataTable();
            potbl.Columns.Add("material_id");
            potbl.Columns.Add("name");
            potbl.Columns.Add("qty");
            potbl.Columns.Add("unit_price");
            

            Console.WriteLine("PO ID " + Purchasing.selectedPONo);
            try
            {
                String query = "SELECT purchaseorder_item.material_id, raw_material.name, purchaseorder_item.qty FROM purchaseorder_item INNER JOIN raw_material ON purchaseorder_item.material_id = raw_material.material_id  WHERE purchaseorder_item.po_id= '" + Purchasing.selectedPONo + "'";
                var dataAdapter = new MySqlDataAdapter(query, DatabaseHandler.MySQLConnectionString);
                var commandBuilder = new MySqlCommandBuilder(dataAdapter);
                dataAdapter.Fill(potbltemp);
                Console.WriteLine(potbltemp.Rows.Count);
                string suppler_id = DatabaseHandler.returnOneValueWithoutParams("SELECT supplier_id FROM purchaseorder WHERE po_id='" + Purchasing.selectedPONo + "'", "supplier_id");
                Console.WriteLine("supplier id"+ suppler_id);
                //adding data to potbl

                int noOfRows2 = potbltemp.Rows.Count;
                for (int i = 0; i < noOfRows2; i++)
                {
                    DataRow rw = potbl.NewRow();
                    rw["material_id"] = potbltemp.Rows[i][0];
                    rw["name"] = potbltemp.Rows[i][1];
                    rw["qty"] = potbltemp.Rows[i][2];
                    string material_id= potbltemp.Rows[i][0].ToString();
                    string unit_price = DatabaseHandler.returnOneValueWithoutParams("SELECT unit_price FROM supplier_material where material_id='" + material_id + "' AND supplier_id='" + suppler_id + "' ", "unit_price").ToString() ;
                    rw["unit_price"] = unit_price;
                    Console.WriteLine("unit_price" + unit_price);
                    potbl.Rows.Add(rw);
                }


                ParameterFields From = new ParameterFields();
                ParameterField PID = new ParameterField();
                PID.Name = "po_id";
                ParameterDiscreteValue val = new ParameterDiscreteValue();
                val.Value = Purchasing.selectedPONo.ToString();
                PID.CurrentValues.Add(val);
                From.Add(PID);
                POrptViewer.ParameterFieldInfo = From;

                String query2 = "SELECT supplier.name as 'Name' FROM purchaseorder INNER JOIN supplier ON purchaseorder.supplier_id = supplier.supplier_id  WHERE purchaseorder.po_id= '" + Purchasing.selectedPONo +"'";
                String supplierName = DatabaseHandler.returnOneValueWithoutParams(query2, "Name");
                Console.WriteLine("supplier Name "+ supplierName);
                ParameterField PID2 = new ParameterField();
                PID2.Name = "SupplierName";
                ParameterDiscreteValue val2 = new ParameterDiscreteValue();
                val2.Value = supplierName;
                PID2.CurrentValues.Add(val2);
                From.Add(PID2);
                POrptViewer.ParameterFieldInfo = From;

            }
            catch (Exception er)
            {
                MessageBox.Show("Error Occured! failed to get PO no");
                Console.WriteLine(er.Message);
                return;
            }
            try
            {
                if (potbl.Rows.Count == 0)
                {
                    MessageBox.Show("Error Occured! Please check input details!");
                    return;
                }
                CrystalReports.PurchaseOrderReport porpt = new CrystalReports.PurchaseOrderReport();
                porpt.Database.Tables["potbl"].SetDataSource(potbl);

                POrptViewer.ReportSource = null;
                POrptViewer.ReportSource = porpt;
            }
            catch (Exception)
            {
                MessageBox.Show("Error Occured! Please check input details!");
            }
        }
    }
}
