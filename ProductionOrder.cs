
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace rpc_working
{
    public partial class ProductionOrder : UserControl
    {
        int globalLastPo;


        public ProductionOrder()
        {
            InitializeComponent();
        }


        public void ProductionOrder_Load(object sender, EventArgs e)
        {
            if (GlobalLoginData.userRole == "StoreKeeper")
            {
                approveBtn.Enabled = false;
                declineBtn.Enabled = false;
            }

            //Populate dataViewGrid1 (Items by that supplier)
            populateGrid();
            dataViewDesign(dataGridView4);
            setPoNum();
            //Populate Other Grids
            populateNonComboGrids();
        }





        private void populateGrid()
        {
            string selectStatement = "SELECT item.item_id as 'Item Code', item.name as 'Item Name', item.unit_price as 'Item Price', item.qty as 'Quantity' FROM item ";
            DatabaseHandler.populateViewwithNoParameters(selectStatement, dataGridView1);

            populateNonComboGrids();
        }

        private void populateNonComboGrids()
        {
            string approvedSelect = "SELECT productionorder.pro_id as 'Order #',  productionorder.creation_time as 'Order Creation Time', productionorder.postedUser as 'Posted By' FROM productionorder WHERE productionorder.approval = 'Approved' AND productionorder.recieved = 'No'";
            DatabaseHandler.populateGridViewWithBinding(approvedSelect, dataGridView2);

            string pendingSelect = "SELECT productionorder.pro_id as 'Order #', productionorder.creation_time as 'Order Creation Time', productionorder.postedUser as 'Posted By' FROM productionorder WHERE productionorder.approval = 'Pending'";
            DatabaseHandler.populateGridViewWithBinding(pendingSelect, dataGridView3);

            string FinishedSelect = "SELECT productionorder.pro_id as 'Order #', productionorder.creation_time as 'Order Creation Time', productionorder.postedUser as 'Posted By' FROM productionorder WHERE productionorder.approval = 'Approved' AND productionorder.recieved = 'Yes' ";
            DatabaseHandler.populateGridViewWithBinding(FinishedSelect, dataGridView6);

        }

        private void addItemBtn_Click(object sender, EventArgs e)
        {
            string itemCode = addItemCodeTxt.Text;
            string itemQty = addItemQty.Text;

            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@itemCode", itemCode));
            int returnedRowCount = DatabaseHandler.returnRowCount("SELECT*FROM item WHERE item_id=@itemCode", paramList);

            if(returnedRowCount != 0)
            {
                //Get Item Name from DB
                paramList.Clear();
                paramList.Add(new MySqlParameter("@itemCode", itemCode));
                string itemName = DatabaseHandler.returnOneValue("SELECT name as 'Item Name' from item where item_id=@itemCode",paramList,"Item Name");


                //Add to dataViewGrid4
                int index = dataGridView4.DisplayedRowCount(true);
                dataGridView4.Rows.Add(itemCode, itemName, itemQty);
                Console.WriteLine("In Add Btn: Current Index: " + index);
               
            }
            else
            {
                MessageBox.Show("Invalid Item Code!");
            }
        }

        private void addItemQty_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(addItemQty.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                addItemQty.Text = addItemQty.Text.Remove(addItemQty.Text.Length - 1);
            }
        }

        private void dataViewDesign(DataGridView dataGridView)
        {
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView.ColumnHeadersDefaultCellStyle.Font =
                new Font(dataGridView.Font, FontStyle.Bold);
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void createPurchaseOrderBtn_Click(object sender, EventArgs e)
        {

            setPoNum();
            try
            {
                string query = "insert into productionorder(approval,postedUser) values ('Pending',@user);";
                List<MySqlParameter> paramList = new List<MySqlParameter>();
                paramList.Clear();
                paramList.Add(new MySqlParameter("@user", GlobalLoginData.username));

                int rowsAffected = DatabaseHandler.insertOrDeleteRow(query, paramList);

                if (rowsAffected != 0)
                {
                    MessageBox.Show("Production Order Created Successfully!");

                    

                    populateGrid();
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
            int i = dataGridView4.Rows.Count;
            Console.WriteLine("Special i Value: " + i);
            string itemid;
            string qty;
            for(int row = 0; row<i-1; row++)
            {
                string lastPo = DatabaseHandler.returnOneValueWithoutParams("SELECT * FROM productionorder", "pro_id");

                itemid = dataGridView4.Rows[row].Cells[0].Value.ToString();
                qty = dataGridView4.Rows[row].Cells[2].Value.ToString();
                Console.WriteLine(itemid + "   " + qty);
                try
                {
                    string query = "INSERT INTO productionorder_item VALUES (@poNum,@itemCode,@qty)";
                    List<MySqlParameter> paramList = new List<MySqlParameter>();
                    paramList.Add(new MySqlParameter("@poNum", lastPo));
                    paramList.Add(new MySqlParameter("@itemCode", itemid));
                    paramList.Add(new MySqlParameter("@qty", qty));

                    int rowsAffected = DatabaseHandler.insertOrDeleteRow(query, paramList);

                    if (rowsAffected == 0)
                    {

                        MessageBox.Show("Error Occured! PO-Item Link Broken!");
                    }
                    

                }
                catch (Exception)
                {
                    MessageBox.Show("Error Occured! Please check if the Client already exists!");
                }
                finally
                {
                    populateGrid();
                }

                
            }
            Email.sendMail("RPC SYSTEM: Please approve the production order requisition, ID= " + PO.Text);
            setPoNum();
            addItemCodeTxt.Text = "";
            addItemQty.Text = "";
            dataGridView4.Rows.Clear();
            Console.WriteLine("Current Row Count: " + dataGridView4.Rows.Count);
          

        }

        private void setPoNum()
        {
            string lastPo = DatabaseHandler.returnOneValueWithoutParams("SELECT * FROM productionorder", "pro_id");
            int lastPoNum;
            if(lastPo == "Null Data!")
            {
                lastPoNum = 0;
            }
            else
            {
                lastPoNum = Int32.Parse(lastPo);
            }
            
            PO.Text = (lastPoNum+1).ToString();
            globalLastPo = lastPoNum;
        }

        private void dataGridView3_Click(object sender, EventArgs e)
        {
            try
            {
                string val = dataGridView3.SelectedRows[0].Cells["Order #"].Value.ToString();

                string select = "SELECT productionorder_item.pro_id as 'Order #', productionorder_item.item_id as 'Item Code', item.name as 'Item Name', productionorder_item.qty as 'Qty' FROM productionorder_item INNER JOIN item ON productionorder_item.item_id = item.item_id WHERE productionorder_item.pro_id = '" + val + "'";
                DatabaseHandler.populateGridViewWithBinding(select, dataGridView5);
            }catch(Exception err)
            {
                Console.WriteLine(err);
            }
            
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                string val = dataGridView2.SelectedRows[0].Cells["Order #"].Value.ToString();

                string select = "SELECT productionorder_item.pro_id as 'Order #', productionorder_item.item_id as 'Item Code', item.name as 'Item Name',  productionorder_item.qty as 'Qty' FROM productionorder_item INNER JOIN item ON productionorder_item.item_id = item.item_id WHERE productionorder_item.pro_id = '" + val + "'";
                DatabaseHandler.populateGridViewWithBinding(select, dataGridView5);
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }
             
        }

        private void approveBtn_Click(object sender, EventArgs e)
        {
            string val = dataGridView3.SelectedRows[0].Cells["Order #"].Value.ToString();
            string update = "UPDATE productionorder set approval='Approved' where pro_id=@ponum";
            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@ponum", val));

            int rowsAffected = DatabaseHandler.insertOrDeleteRow(update, paramList);

            if (rowsAffected != 0)
            {
                MessageBox.Show("Production Order Confirmed!");
                populateGrid();
            }
            else
            {
                MessageBox.Show("Error Occured! Please check Selection!");
            }

            populateNonComboGrids();
            
        }

        private void declineBtn_Click(object sender, EventArgs e)
        {
            string val = dataGridView3.SelectedRows[0].Cells["Order #"].Value.ToString();
            string update = "UPDATE productionorder set approval='Declined' where pro_id=@ponum";
            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@poNum", val));

            int rowsAffected = DatabaseHandler.insertOrDeleteRow(update, paramList);

            if (rowsAffected != 0)
            {
                MessageBox.Show("Production Order Declined!");
                populateGrid();
            }
            else
            {
                MessageBox.Show("Error Occured! Please check Selection!");
            }

            populateNonComboGrids();
        }

        private void Clear_btn_Click(object sender, EventArgs e)
        {
            addItemCodeTxt.Text = "";
            addItemQty.Text = "";
            dataGridView4.Rows.Clear();
           
        }

        private void Commit_btn_Click(object sender, EventArgs e)
        {
            try
            {
                 string val = dataGridView2.SelectedRows[0].Cells["Order #"].Value.ToString();

                if (val == null)
                {
                    MessageBox.Show("ENTRY NOT SELECTED!");
                    return;
                }

               
                string updateQuery = "update productionorder set recieved = 'Yes' where pro_id=@poNum";
                List<MySqlParameter> paramList = new List<MySqlParameter>();
                paramList.Clear();
                paramList.Add(new MySqlParameter("@poNum",val));

                int rowsAffected = DatabaseHandler.insertOrDeleteRow(updateQuery, paramList);

                int rows = dataGridView5.Rows.Count;
                string itemid = null;
                string qty = null;
                for (int i = 0; i < rows - 1; i++)
                {
                    itemid = dataGridView5.Rows[i].Cells[1].Value.ToString();
                    qty = dataGridView5.Rows[i].Cells[3].Value.ToString();
                    Console.WriteLine(itemid + "   " + qty);
                    try
                    {
                        string query = "UPDATE item SET qty= qty + @qty WHERE item_id=@itemid";
                        List<MySqlParameter> paramList2 = new List<MySqlParameter>();
                        paramList2.Add(new MySqlParameter("@qty", qty));
                        paramList2.Add(new MySqlParameter("@itemid", itemid));


                        int rowsAffected2 = DatabaseHandler.insertOrDeleteRow(query, paramList2);

                        if (rowsAffected2 != 0)
                        {

                            
                        }
                        else
                        {
                            MessageBox.Show("Error Occured! PO-Item Link Broken!");
                        }

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error Occured!");
                    }
                }

                if (rowsAffected != 0)
                {
                    MessageBox.Show("Commited!");
                    populateGrid();
                }
                else
                {
                    MessageBox.Show("Error!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error occured!");
            }

            addItemCodeTxt.Clear();
            dataGridView5.DataSource = null;
            dataGridView5.Refresh();

    

        }

       
    }
}
