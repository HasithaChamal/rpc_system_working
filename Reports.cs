using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rpc_working
{
    public partial class Reports : UserControl
    {
        public static string startDate;
        public static string endDate;
        public static bool sortbysupclient;
        public static string supclientval;
        public Reports()
        {
            InitializeComponent();
        }

        private void generate_btn_Click(object sender, EventArgs e)
        {
            sortbysupclient = sort_supp_client_checkbx.Checked;


            startDate = from_calander.SelectionRange.Start.ToString("yyyy/MM/dd");
            endDate = to_calander.SelectionRange.Start.ToString("yyyy/MM/dd");
            Console.WriteLine("start date " + startDate);
            Console.WriteLine("End date "+ endDate);
           
            if (rpt_typ_cmb.SelectedIndex == -1) 
            {
                MessageBox.Show("please select a report type!!");
                return;
            }
            else if (rpt_typ_cmb.SelectedIndex == 0)
            {
                if (string.Compare(startDate, endDate) == 0 || DateTime.Compare(from_calander.SelectionRange.Start, to_calander.SelectionRange.Start) > 0)
                {
                    MessageBox.Show("please select a valied date range!!");
                    return;
                }

                CrystalReportsViewer.materialUseageVeiwer materialuse = new CrystalReportsViewer.materialUseageVeiwer();
                materialuse.StartPosition = FormStartPosition.CenterScreen;
                materialuse.Show();
                

            }
            else if (rpt_typ_cmb.SelectedIndex == 1)
            {
                if (string.Compare(startDate, endDate) == 0 || DateTime.Compare(from_calander.SelectionRange.Start, to_calander.SelectionRange.Start) > 0)
                {
                    MessageBox.Show("please select a valied date range!!");
                    return;
                }
                DataRowView selectedRow = supplierClientcmb.SelectedItem as DataRowView;
                if (selectedRow != null)
                {
                    supclientval = selectedRow.Row["Client Id"] as string;
                }
                CrystalReportsViewer.itemOrderReportViewer itemOrders = new CrystalReportsViewer.itemOrderReportViewer();
                itemOrders.StartPosition = FormStartPosition.CenterScreen;
                itemOrders.Show();
               
            }
            else if (rpt_typ_cmb.SelectedIndex == 2) {
                if (string.Compare(startDate, endDate) == 0 || DateTime.Compare(from_calander.SelectionRange.Start, to_calander.SelectionRange.Start) > 0)
                {
                    MessageBox.Show("please select a valied date range!!");
                    return;
                }

                CrystalReportsViewer.productionReportViewer productionOrders = new CrystalReportsViewer.productionReportViewer();
                productionOrders.StartPosition = FormStartPosition.CenterScreen;
                productionOrders.Show();
               
            }
            else if (rpt_typ_cmb.SelectedIndex == 3)
            {
                if (string.Compare(startDate, endDate) == 0 || DateTime.Compare(from_calander.SelectionRange.Start, to_calander.SelectionRange.Start) > 0)
                {
                    MessageBox.Show("please select a valied date range!!");
                    return;
                }
                DataRowView selectedRow = supplierClientcmb.SelectedItem as DataRowView;
                if (selectedRow != null)
                {
                    supclientval = selectedRow.Row["Supplier Code"] as string;
                }
               
                CrystalReportsViewer.PurchaseOrderViewer purchaseOrder = new CrystalReportsViewer.PurchaseOrderViewer();
                purchaseOrder.StartPosition = FormStartPosition.CenterScreen;
                purchaseOrder.Show();
                
            }

            else if (rpt_typ_cmb.SelectedIndex == 4)
            {
                CrystalReportsViewer.MaterialStock materialstock = new CrystalReportsViewer.MaterialStock();
                materialstock.StartPosition = FormStartPosition.CenterScreen;
                materialstock.Show();
            }

            else if (rpt_typ_cmb.SelectedIndex == 5)
            {
                CrystalReportsViewer.ProductStock productStock = new CrystalReportsViewer.ProductStock();
                productStock.StartPosition = FormStartPosition.CenterScreen;
                productStock.Show();
            }
        }

        private void reset_btn_Click(object sender, EventArgs e)
        {
            rpt_typ_cmb.SelectedIndex = -1;
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            from_calander.MaxSelectionCount = 1;
            to_calander.MaxSelectionCount = 1;
            from_calander.MaxDate = DateTime.Today;
            to_calander.MaxDate = DateTime.Today.AddDays(1);
            supplierClientcmb.Enabled = false;
        }

        private void rpt_typ_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rpt_typ_cmb.SelectedIndex == 4 || rpt_typ_cmb.SelectedIndex == 5)
            {
                from_calander.Enabled = false;
                to_calander.Enabled = false;
            }
            else 
            {
                from_calander.Enabled = true;
                to_calander.Enabled = true;
            }
            if (rpt_typ_cmb.SelectedIndex == 1)
            {
                supplierClientcmb.Enabled = true;
                sort_supp_client_checkbx.Enabled = true;
                sort_supp_client_checkbx.Checked = true;
                string selectStatement = "SELECT client_id as 'Client Id', name as 'Client Name' FROM client";
                DatabaseHandler.populateDispatchCombobox(selectStatement, supplierClientcmb);
            }
            else if (rpt_typ_cmb.SelectedIndex == 3)
            {
                supplierClientcmb.Enabled = true;
                sort_supp_client_checkbx.Enabled = true;
                sort_supp_client_checkbx.Checked = true;
                string selectStatement = "SELECT supplier_id as 'Supplier Code', name as 'Supplier' FROM SUPPLIER";
                DatabaseHandler.populateCombobox(selectStatement, supplierClientcmb);
            }
            else 
            {
                supplierClientcmb.DataSource = null;
                supplierClientcmb.Items.Clear();
                supplierClientcmb.Enabled = false;
                sort_supp_client_checkbx.Checked = false;
                sort_supp_client_checkbx.Enabled = false;
            }
        }

        private void sort_supp_client_checkbx_CheckedChanged(object sender, EventArgs e)
        {
            if (sort_supp_client_checkbx.Checked == true)
            {
                supplierClientcmb.Enabled = true;
            }
            else 
            {
                supplierClientcmb.Enabled = false;
            }
        }
    }
}
