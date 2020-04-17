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
        public Reports()
        {
            InitializeComponent();
        }

        private void generate_btn_Click(object sender, EventArgs e)
        {
            startDate = from_calander.SelectionRange.Start.ToString("yyyy/MM/dd");
            endDate = to_calander.SelectionRange.Start.ToString("yyyy/MM/dd");
            Console.WriteLine("start date " + startDate);
            Console.WriteLine("End date "+ endDate);
            if (string.Compare(startDate, endDate)==0 || DateTime.Compare(from_calander.SelectionRange.Start, to_calander.SelectionRange.Start)>0)
            {
                MessageBox.Show("please select a valied date range!!");
                return;
            }
            if (rpt_typ_cmb.SelectedIndex == -1) 
            {
                MessageBox.Show("please select a report type!!");
                return;
            }
            else if (rpt_typ_cmb.SelectedIndex == 0)
            {
                CrystalReportsViewer.materialUseageVeiwer materialuse = new CrystalReportsViewer.materialUseageVeiwer();
                materialuse.StartPosition = FormStartPosition.CenterScreen;
                materialuse.Show();

            }
            else if (rpt_typ_cmb.SelectedIndex == 1)
            {
                CrystalReportsViewer.itemOrderReportViewer itemOrders = new CrystalReportsViewer.itemOrderReportViewer();
                itemOrders.StartPosition = FormStartPosition.CenterScreen;
                itemOrders.Show();
            }
            else if (rpt_typ_cmb.SelectedIndex == 2) {
                CrystalReportsViewer.productionReportViewer productionOrders = new CrystalReportsViewer.productionReportViewer();
                productionOrders.StartPosition = FormStartPosition.CenterScreen;
                productionOrders.Show();
            }
            else if (rpt_typ_cmb.SelectedIndex == 3)
            {
                CrystalReportsViewer.PurchaseOrderViewer purchaseOrder = new CrystalReportsViewer.PurchaseOrderViewer();
                purchaseOrder.StartPosition = FormStartPosition.CenterScreen;
                purchaseOrder.Show();
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
            to_calander.MaxDate = DateTime.Today;

        }
    }
}
