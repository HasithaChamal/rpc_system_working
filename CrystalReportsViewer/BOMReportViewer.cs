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
    public partial class BOMReportViewer : Form
    {
        public BOMReportViewer()
        {
            InitializeComponent();
        }

        private void BOMReportViewer_Load(object sender, EventArgs e)
        {
            

               DataTable bomtbl = new DataTable();
  
         
            Console.WriteLine("BOM ID "+BOM.globalLastbom);
            try
            {
                String query = "SELECT bom_item.material_id, raw_material.name, bom_item.qty FROM bom_item INNER JOIN raw_material ON bom_item.material_id = raw_material.material_id  WHERE bom_id= '" + BOM.globalLastbom + "'";
                var dataAdapter = new MySqlDataAdapter(query, DatabaseHandler.MySQLConnectionString);
                var commandBuilder = new MySqlCommandBuilder(dataAdapter);
                dataAdapter.Fill(bomtbl);
                Console.WriteLine(bomtbl.Rows.Count); 

                ParameterFields From = new ParameterFields();
                ParameterField PID = new ParameterField();
                PID.Name = "bom_id";
                ParameterDiscreteValue val = new ParameterDiscreteValue();
                val.Value = BOM.globalLastbom.ToString();
                PID.CurrentValues.Add(val);
                From.Add(PID);
                bomrptViewer.ParameterFieldInfo = From;

            }
            catch (Exception er)
            {
                MessageBox.Show("Error Occured! failed to get bom no");
                Console.WriteLine(er.Message);

            }
            try
            {
                if (bomtbl.Rows.Count == 0)
                {
                    MessageBox.Show("Error Occured! Please check input details!");
                    return;
                }
                CrystalReports.BOMReport bomrpt = new CrystalReports.BOMReport();
                bomrpt.Database.Tables["bomtbl"].SetDataSource(bomtbl);

                bomrptViewer.ReportSource = null;
                bomrptViewer.ReportSource = bomrpt;
            }
            catch (Exception)
            {

                MessageBox.Show("Error Occured! Please check input details!");

            }

        }

        private void bomrptViewer_Load(object sender, EventArgs e)
        {
       
        }
    }
}
