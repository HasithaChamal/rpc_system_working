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
        int globalLastPo;
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
            int returnedRowCount2 = DatabaseHandler.returnRowCount("SELECT * FROM bom WHERE pro_id = @poNum", paramList);




            if (returnedRowCount == 1 && returnedRowCount2==0)
            {
               // poText.Enabled = false;
                string select = "SELECT productionorder_item.pro_id as 'Order #', productionorder_item.item_id as 'Item Code', item.name as 'Item Name', productionorder_item.qty as 'Qty' FROM productionorder_item INNER JOIN item ON productionorder_item.item_id = item.item_id WHERE productionorder_item.pro_id = '" + poNum + "'";
                DatabaseHandler.populateGridViewWithBinding(select, dataGridView2);
                 setPoNum();
               

        
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
            string lastPo = DatabaseHandler.returnOneValueWithoutParams("SELECT * FROM bom", "bom_id");
            int lastbomNum;
            if (lastPo == "Null Data!")
            {
                lastbomNum = 0;
            }
            else
            {
                lastbomNum = Int32.Parse(lastPo);
            }

            bom_lbl.Text = (lastbomNum + 1).ToString();
            globalLastPo = lastbomNum;



        }

        private void Clear_btn_Click(object sender, EventArgs e)
        {
            poText.Clear();
            dataGridView2.DataSource = null;
            dataGridView2.Refresh();
            poText.Enabled = true;

        }

        private void Create_bom_btn_Click(object sender, EventArgs e)
        {
            setPoNum();
            try
            {
                string query = "insert into bom( approval ,postedUser, pro_id) values ('Pending',@user, @proId);";
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




            //populate datagridview1
            int i = dataGridView2.DisplayedRowCount(true);
            Console.WriteLine("Special i Value: " + i);
            string itemid;
            string qty;
            string bomId= bom_lbl.Text;
            for (int row = 0; row < i - 1; row++)
            {
               
                itemid = dataGridView2.Rows[row].Cells[1].Value.ToString();
                qty = dataGridView2.Rows[row].Cells[3].Value.ToString();

                Console.WriteLine(itemid + "   " + qty);

                List<MySqlParameter> paramList1 = new List<MySqlParameter>();
                paramList1.Add(new MySqlParameter("@bomId", bomId));
                paramList1.Add(new MySqlParameter("@itemid", itemid));
                int returnedRowCount2 = DatabaseHandler.returnRowCount("SELECT * FROM bom_item WHERE bom_id = @bomId AND material_id= @itemid", paramList1);




            }
        }
        }


}

