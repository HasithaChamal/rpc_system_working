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



namespace rpc_working
{
    public partial class BOM : UserControl
    {
        public static int globalLastbom;
        public static string bomNo;
        public static DataTable data; 
        public BOM()
        {
            InitializeComponent();
        }

        private void ApplyBtn_Click(object sender, EventArgs e)
        {
            setPoNum();
            string poNum = poText.Text;
            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@poNum", poNum));
            paramList.Add(new MySqlParameter("@recieved", "No"));
            paramList.Add(new MySqlParameter("@approval", "Approved"));

            int returnedRowCount = DatabaseHandler.returnRowCount("SELECT * FROM productionorder WHERE pro_id = @poNum AND recieved=@recieved AND approval=@approval", paramList);

            List<MySqlParameter> paramList2 = new List<MySqlParameter>();
            paramList2.Add(new MySqlParameter("@poNum", poNum));
            int returnedRowCount2 = DatabaseHandler.returnRowCount("SELECT * FROM bom WHERE pro_id = @poNum", paramList2);




            if (returnedRowCount == 1 && returnedRowCount2 == 0)
            {
                // poText.Enabled = false;
                string select = "SELECT productionorder_item.pro_id as 'Order #', productionorder_item.item_id as 'Item Code', item.name as 'Item Name', productionorder_item.qty as 'Qty' FROM productionorder_item INNER JOIN item ON productionorder_item.item_id = item.item_id WHERE productionorder_item.pro_id = '" + poNum + "'";
                DatabaseHandler.populateGridViewWithBinding(select, dataGridView2);
                setPoNum();

            }
            else if (returnedRowCount2 == 1) {

                MessageBox.Show("BOM already created for that production order. Please Try again..");
                
            }

            else
            {
                poText.Enabled = true;
                MessageBox.Show("No such production order exists or the Order may not be approved. Please Try again..");
                poText.Clear();
                dataGridView2.DataSource = null;
                dataGridView2.Refresh();

            }
        }

        private void PoText_TextChanged(object sender, EventArgs e)
        {
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(poText.Text, "[^0-9]"))
                {
                    MessageBox.Show("Please enter only numbers.");
                    poText.Text = poText.Text.Remove(poText.Text.Length - 1);
                }
               
            }
        }

        public void BOM_Load(object sender, EventArgs e)
        {
            setPoNum();
           
        }

        private void setPoNum()
        {
            string lastbom = DatabaseHandler.returnOneValueWithoutParams("SELECT * FROM bom", "bom_id");
            int lastbomNum;
            if (lastbom == "Null Data!")
            {
                lastbomNum = 0;
            }
            else
            {
                lastbomNum = Int32.Parse(lastbom);
            }

            bom_lbl.Text = (lastbomNum + 1).ToString();
            globalLastbom = lastbomNum;
            bomNo = bom_lbl.Text;


        }

        private void Clear_btn_Click(object sender, EventArgs e)
        {
            poText.Clear();
            dataGridView2.DataSource = null;
            dataGridView2.Refresh();
            poText.Enabled = true;
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();

        }

        private void Create_bom_btn_Click(object sender, EventArgs e)
        {
            setPoNum();
            try
            {
                string query = "insert into bom( postedUser, pro_id) values (@user, @proId);";
                List<MySqlParameter> paramList = new List<MySqlParameter>();
                paramList.Clear();
                paramList.Add(new MySqlParameter("@user", GlobalLoginData.username));
                paramList.Add(new MySqlParameter("@proId", poText.Text));

                int rowsAffected = DatabaseHandler.insertOrDeleteRow(query, paramList);

                if (rowsAffected != 0)
                {
                    //MessageBox.Show("BOM Created Successfully!");
                    
                }
                else
                {
                    MessageBox.Show("Error Occured! Please check input details!");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error Occured! Please check input details!");
            }



            int i = dataGridView2.Rows.Count;
            Console.WriteLine("Special i Value: " + i);
            string itemid;
            string qty;
            string bomId= bom_lbl.Text;
            for (int row = 0; row < i - 1; row++)
            {
               
                itemid = dataGridView2.Rows[row].Cells[1].Value.ToString();
                qty = dataGridView2.Rows[row].Cells[3].Value.ToString();

                string querry = "SELECT material_id as 'material_id', quantity as 'quantity' FROM composition WHERE item_id= '" + itemid + "'";

                DatabaseHandler.populatebomDataGridView(querry, dataGridView1, qty);

            }



            int j = dataGridView1.Rows.Count;
            Console.WriteLine("Special j Value: " + j);

            int temp = 0;
            for (int row = 0; row < j-1 ; row++)
            {
               
                itemid = dataGridView1.Rows[row].Cells[0].Value.ToString();
                qty = dataGridView1.Rows[row].Cells[1].Value.ToString();
                Console.WriteLine(itemid + "   " + qty);
                try
                {
                    string query = "INSERT INTO bom_item VALUES (@material_id, @bom_id, @qty)";
                    List<MySqlParameter> paramList = new List<MySqlParameter>();
                    paramList.Add(new MySqlParameter("@material_id", itemid));
                    paramList.Add(new MySqlParameter("@bom_id", bomId));
                    paramList.Add(new MySqlParameter("@qty", qty));

                    int rowsAffected = DatabaseHandler.insertOrDeleteRow(query, paramList);

                    if (rowsAffected != 0)
                    {

                      //  MessageBox.Show("BOM Created Successfully!");
                        temp++;
                    }
                    else
                    {
                        MessageBox.Show("Error Occured! BOM-material Link Broken!");
                        return;
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Error Occured!");
                }
                

            }

            data = GetDataTableFromDGV(dataGridView1);
            if (temp != 0) 
            {
                MessageBox.Show("BOM Created Successfully!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CrystalReportsViewer.BOMReportViewer bomview = new CrystalReportsViewer.BOMReportViewer();
            bomview.ShowDialog();
       
        }

        private DataTable GetDataTableFromDGV(DataGridView dgv)
        {
            var dt = new DataTable();
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (column.Visible)
                {
                       dt.Columns.Add();
                }
            }

            object[] cellValues = new object[dgv.Columns.Count];
            foreach (DataGridViewRow row in dgv.Rows)
            {
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    cellValues[i] = row.Cells[i].Value;
                }
                dt.Rows.Add(cellValues);
            }

            return dt;
        }
    }


}

