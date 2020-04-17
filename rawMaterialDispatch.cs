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
    public partial class rawMaterialDispatch : UserControl
    {

        int globalLastRo;

        public rawMaterialDispatch()
        {
            InitializeComponent();

        }


        private void setReqNum()
        {
            string lastRo = DatabaseHandler.returnOneValueWithoutParams("SELECT * FROM material_dispatch", "id");
            int lastRoNum;
            if (lastRo == "Null Data!")
            {
                lastRoNum = 0;
            }
            else
            {
                lastRoNum = Int32.Parse(lastRo);
            }

            dispatchId_lbl.Text = (lastRoNum + 1).ToString();
            globalLastRo = lastRoNum;
        }

        public void RawMaterialDispatch_Load(object sender, EventArgs e)
        {
            if (GlobalLoginData.userRole == "StoreKeeper")
            {
                approveBtn.Enabled = false;
                declineBtn.Enabled = false;
            }
            setReqNum();
            populateDataGrid();
        }


        private void populateDataGrid()
        {
            string selectStatement = "SELECT id as 'Dispatch ID', bom_id as 'BOM ID', creation_time as 'Dispatch Order Creation time', postedUser as 'Posted User' FROM material_dispatch WHERE approval ='Pending' ";
            DatabaseHandler.populateGridViewWithBinding(selectStatement, dataGridView1);

            string selectStatement1 = "SELECT id as 'Dispatch ID', bom_id as 'BOM ID', creation_time as 'Dispatch Order Creation time', postedUser as 'Posted User' FROM material_dispatch WHERE approval ='Approved' AND released='No' ";
            DatabaseHandler.populateGridViewWithBinding(selectStatement1, dataGridView2);

            string selectStatement2 = "SELECT id as 'Dispatch ID', bom_id as 'BOM ID', creation_time as 'Dispatch Order Creation time', postedUser as 'Posted User' FROM material_dispatch WHERE approval ='Approved' AND released='Yes' ";
            DatabaseHandler.populateGridViewWithBinding(selectStatement2, dataGridView3);

            string selectStatement3 = "SELECT bom_id as 'BOM ID', creation_time as 'BOM creation time', postedUser as 'Posted User', pro_id as 'Production Order ID' FROM bom ";
            DatabaseHandler.populateGridViewWithBinding(selectStatement3, dataGridView5);

            dataGridView6.DataSource = null;
            dataGridView6.Rows.Clear();
        }

        private void BomId_txt_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(bomId_txt.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                bomId_txt.Text = bomId_txt.Text.Remove(bomId_txt.Text.Length - 1);
            }
        }

        private void Add_btn_Click(object sender, EventArgs e)
        {
            string bomId;
           
           bomId = bomId_txt.Text;
                
            if (bomId == null)
            {
                MessageBox.Show("Invalid Selection!");
            }
            else
            {
              
                string selectStatement = "SELECT bom_item.material_id as 'Material ID', bom_item.qty as 'Quantity', raw_material.name as 'Material Name', raw_material.unit_price as 'Unit Price' FROM raw_material INNER JOIN bom_item ON bom_item.material_id = raw_material.material_id WHERE bom_item.bom_id = '" + bomId + "' ";
                DatabaseHandler.populateGridViewWithBinding(selectStatement, dataGridView4);

            }       
            
        }

        private void DataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                bomId_txt.Text = dataGridView5.SelectedRows[0].Cells["BOM ID"].Value.ToString();
            }
            catch (Exception)
            {

            }
        }

        private void DispatchRequestBtn_Click(object sender, EventArgs e)
        {
            setReqNum();
            int index3 = dataGridView4.DisplayedRowCount(true);
            string bomId = bomId_txt.Text;
            if (index3 == 1)
            {

                MessageBox.Show("Invalied selection, dispatch request not created!!");
                return;
            }
            try
            {
                string query = "insert into material_dispatch(bom_id, approval,postedUser) values (@bomId,'Pending',@user)";
                List<MySqlParameter> paramList = new List<MySqlParameter>();
                paramList.Clear();
                paramList.Add(new MySqlParameter("@bomId", bomId));
                paramList.Add(new MySqlParameter("@user", GlobalLoginData.username));

                int rowsAffected = DatabaseHandler.insertOrDeleteRow(query, paramList);

                if (rowsAffected == 1)
                {
                    MessageBox.Show("Material dispatch request posted sucessfully!!");
                    populateDataGrid();

                    dataGridView4.DataSource = null;
                    dataGridView4.Rows.Clear();
                    bomId_txt.Clear();
                    setReqNum();
                }
                else {
                    MessageBox.Show("Error!!");
                }

            }
            catch(Exception err)
            {
                Console.WriteLine(err);

            }

        }

       
        private void ApproveBtn_Click(object sender, EventArgs e)
        {
            string val = dataGridView1.SelectedRows[0].Cells["Dispatch ID"].Value.ToString();
            string update = "UPDATE material_dispatch set approval='Approved' where id=@ronum";

            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@ronum", val));

            int rowsAffected = DatabaseHandler.insertOrDeleteRow(update, paramList);

            if (rowsAffected != 0)
            {
                MessageBox.Show("Dispatch Order Approved!");
                populateDataGrid();
            }
            else
            {
                MessageBox.Show("Error Occured! Please check Selection!");
            }

        }

        private void DeclineBtn_Click(object sender, EventArgs e)
        {
            string val = dataGridView1.SelectedRows[0].Cells["Dispatch ID"].Value.ToString();
            string update = "UPDATE material_dispatch set approval='Declined' where id=@ronum";

            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@ronum", val));

            int rowsAffected = DatabaseHandler.insertOrDeleteRow(update, paramList);

            if (rowsAffected != 0)
            {
                MessageBox.Show("Dispatch Order Declined!");
                populateDataGrid();
            }
            else
            {
                MessageBox.Show("Error Occured! Please check Selection!");
            }
        }

        private void Remove_btn_Click(object sender, EventArgs e)
        {
            string val = dataGridView5.SelectedRows[0].Cells["BOM ID"].Value.ToString();
            string update = "DELETE FROM bom  where bom_id=@ronum";

            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@ronum", val));

            int rowsAffected = DatabaseHandler.insertOrDeleteRow(update, paramList);

            if (rowsAffected != 0)
            {
                MessageBox.Show("BOM removed successfuly");
                populateDataGrid();
            }
            else
            {
                MessageBox.Show("Error Occured! Please check Selection!");
            }
        }



        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            populatematerialGrid(dataGridView1);
        }

        private void DataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            populatematerialGrid(dataGridView2);
        }

        private void DataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            populatematerialGrid(dataGridView3);
        }

        private void populatematerialGrid(DataGridView dataGridView)
        {
            try
            {
                string val = dataGridView.SelectedRows[0].Cells["BOM ID"].Value.ToString();

                string selectStatement = "SELECT bom_item.material_id as 'Material ID', bom_item.qty as 'Quantity', raw_material.name as 'Material Name', raw_material.unit_price as 'Unit Price' FROM raw_material INNER JOIN bom_item ON bom_item.material_id = raw_material.material_id WHERE bom_item.bom_id = '" + val + "' ";
                DatabaseHandler.populateGridViewWithBinding(selectStatement, dataGridView6);

               
                dataGridView7.Rows.Clear();
                string itemCode = null;
                string itemQty = null;
                string itemName = null;
                for (int i = 0; i < dataGridView6.DisplayedRowCount(true) - 1; i++)
                {
                    try
                    {
                        itemCode = dataGridView6.Rows[i].Cells[1].Value.ToString();
                        itemQty = dataGridView6.Rows[i].Cells[2].Value.ToString();
                        itemName = dataGridView6.Rows[i].Cells[3].Value.ToString();
                        List<MySqlParameter> paramlist = new List<MySqlParameter>();
                        paramlist.Clear();
                        paramlist.Add(new MySqlParameter("@itemCode", itemCode));
                        paramlist.Add(new MySqlParameter("@value", itemQty));
                        Console.WriteLine("required qty " + itemQty);

                        string queryGetQtyCondition = "SELECT IF(qty >= @value,'Yes','No') AS possibility FROM raw_material WHERE material_id = @itemCode";
                        string possibility = DatabaseHandler.returnOneValue(queryGetQtyCondition, paramlist, "possibility");

                        if (string.Compare(possibility, "Yes") == 0)
                        {
                            List<MySqlParameter> paramlist2 = new List<MySqlParameter>();
                            paramlist2.Clear();
                            paramlist2.Add(new MySqlParameter("@itemCode", itemCode));
                            string query = "SELECT qty FROM raw_material WHERE material_id = @itemCode";
                            string available_qty = DatabaseHandler.returnOneValue(query, paramlist2, "qty");
                            Console.WriteLine("Available qty " + available_qty);
                            //Add to dataViewGrid7
                            int index2 = dataGridView7.DisplayedRowCount(true);
                            dataGridView7.Rows.Add();
                            dataGridView7.Rows[index2 - 1].Cells[0].Value = itemCode;
                            dataGridView7.Rows[index2 - 1].Cells[1].Value = itemName;
                            dataGridView7.Rows[index2 - 1].Cells[2].Value = (Int32.Parse(itemQty) - Int32.Parse(available_qty)).ToString();
                        }
                    }


                    catch (Exception err)
                    {
                        Console.WriteLine(err);

                    }

                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err);

            }

        }

      
        private void DataGridView5_SelectionChanged(object sender, EventArgs e)
        {
            populatematerialGrid(dataGridView5);
        }

        private void Clear_btn_Click(object sender, EventArgs e)
        {
            dataGridView4.DataSource = null;
            dataGridView4.Rows.Clear();
            bomId_txt.Clear();
            setReqNum();

        }

        private void DispatchBtn_Click(object sender, EventArgs e)
        {
            string val = null;
            try
            {
                val = dataGridView2.SelectedRows[0].Cells["Dispatch ID"].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Nothing Selected");
            }
            if (dataGridView7.DisplayedRowCount(true) != 1)
            {
                MessageBox.Show("INSUFFICIANT ITEMS IN THE STORE CANNOT DISPATCH ITEMS ");
                return;
            }
            string update = "UPDATE material_dispatch set released='Yes' where id=@ronum";
            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@ronum", val));

            int rowsAffected = DatabaseHandler.insertOrDeleteRow(update, paramList);

            if (rowsAffected != 0)
            {

                string itemCodeTemp;
                string putout;
                string putoutqty;

                for (int i = 0; i < dataGridView6.RowCount - 1; i++)
                {
                    try
                    {
                        itemCodeTemp = dataGridView6.SelectedRows[i].Cells["Material ID"].Value.ToString();
                        putoutqty = dataGridView6.SelectedRows[i].Cells["Quantity"].Value.ToString();
                        putout = "UPDATE raw_material SET qty = qty - @putoutQty WHERE material_id = @itemCode";

                        Console.WriteLine("GridView Row Count: " + dataGridView6.RowCount);
                        Console.WriteLine("itemCodeTemp: " + itemCodeTemp);
                        Console.WriteLine("putoutqty " + putoutqty);

                        List<MySqlParameter> paramList2 = new List<MySqlParameter>();
                        paramList2.Add(new MySqlParameter("@putoutQty", putoutqty));
                        paramList2.Add(new MySqlParameter("@itemCode", itemCodeTemp));

                        Console.WriteLine("query :" + putout);
                        DatabaseHandler.insertOrDeleteRow(putout, paramList2);
                    }
                    catch (Exception err)
                    {
                        Console.WriteLine(err);
                    }

                }




                MessageBox.Show("Order Dispatched!");
                populateDataGrid();
            }
            else
            {
                MessageBox.Show("Error Occured! Please check Selection!");
            }




        }
    }
}
