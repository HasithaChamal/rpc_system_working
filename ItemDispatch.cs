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
    public partial class ItemDispatch : UserControl
    {
        string selectedClient = null;
        DataRowView selectedRow;
        int globalLastRo;

        public ItemDispatch()
        {
            InitializeComponent();
        }

        public void Dispatch_Load(object sender, EventArgs e)
        {
            if (GlobalLoginData.userRole == "StoreKeeper")
            {
                approveBtn.Enabled = false;
                declineBtn.Enabled = false;
            }
            setReqNum();
            populateDataGrid();
            populateDispatchCombo();
            try
            {
                clientComboBox.SelectedIndex = 0;
            }
            catch (Exception)
            {

            }
            selectComboBoxValue();
            dataViewDesign(dataGridView4);
            dataViewDesign(dataGridView6);

        }

        private void clientComboBox_DropDown(object sender, EventArgs e)
        {
            populateDispatchCombo();
        }

        private void clientComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectComboBoxValue();
        }

        private void populateDispatchCombo()
        {
            string selectStatement = "SELECT client_id as 'Client Id', name as 'Client Name' FROM client";
            DatabaseHandler.populateDispatchCombobox(selectStatement, clientComboBox);
        }

        private void clientComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            selectComboBoxValue();
        }

        private void selectComboBoxValue()
        {
            selectedRow = clientComboBox.SelectedItem as DataRowView;
            if (selectedRow != null)
            {
                selectedClient = selectedRow.Row["Client Id"] as string;
            }
        }

        private void populateDataGrid()
        {
            string selectStatement = "SELECT item.item_id as 'Item Code', item.name as 'Item Name', item.unit_price as 'Item Price', item.qty as 'Available Quantity' FROM item ";
            DatabaseHandler.populateGridViewWithBinding(selectStatement, dataGridView5);

            string selectStatement1 = "SELECT itemorder.io_id as 'Order #', client.name as 'Client Name', itemorder.creation_time as 'Posted Time', itemorder.postedUser as 'User' FROM itemorder inner join client on itemorder.client_id = client.client_id WHERE itemorder.approval = 'Pending' AND itemorder.released='No'";
            DatabaseHandler.populateGridViewWithBinding(selectStatement1, dataGridView1);

            string selectStatement2 = "SELECT itemorder.io_id as 'Order #', client.name as 'Client Name', itemorder.creation_time as 'Posted Time', itemorder.postedUser as 'User' FROM itemorder inner join client on itemorder.client_id = client.client_id WHERE itemorder.approval = 'Approved' AND itemorder.released='No'";
            DatabaseHandler.populateGridViewWithBinding(selectStatement2, dataGridView2);

            string selectStatement3 = "SELECT itemorder.io_id as 'Order #', client.name as 'Client Name', itemorder.creation_time as 'Posted Time', itemorder.postedUser as 'User' FROM itemorder inner join client on itemorder.client_id = client.client_id WHERE itemorder.approval = 'Approved' AND itemorder.released='Yes'";
            DatabaseHandler.populateGridViewWithBinding(selectStatement3, dataGridView3);
            dataGridView6.DataSource = null;
            dataGridView6.Rows.Clear();
        }

        private void itemName_TextChanged(object sender, EventArgs e)
        {
            string selectStatement = "SELECT item.item_id as 'Item Code', item.name as 'Item Name', item.unit_price as 'Item Price', item.qty as 'Available Quantity' FROM item WHERE item.name like '%" + itemNameTxt.Text + "%'";
            DatabaseHandler.populateGridViewWithBinding(selectStatement, dataGridView5);
        }

        private void qtyTxt_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(qtyTxt.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                qtyTxt.Text = qtyTxt.Text.Remove(qtyTxt.Text.Length - 1);
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            string itemCode;
            string itemQty;
            string itemName;
            Console.WriteLine("In Add Btn: Current Index1: " + dataGridView4.DisplayedRowCount(true));
            try
            {
                itemCode = dataGridView5.SelectedRows[0].Cells["Item Code"].Value.ToString();
            }
            catch (Exception)
            {
                itemCode = null;
            }
           
            if(itemCode == null)
            {
                MessageBox.Show("Invalid Selection!");
            }
            else
            {   
                itemQty = qtyTxt.Text;
                itemName = dataGridView5.SelectedRows[0].Cells["Item Name"].Value.ToString();

                List<MySqlParameter> paramlist = new List<MySqlParameter>();
                paramlist.Clear();
                paramlist.Add(new MySqlParameter("@itemCode", itemCode));
                paramlist.Add(new MySqlParameter("@value", itemQty));

                string queryGetQtyCondition = "SELECT IF(qty >= @value,'Yes','No') AS possibility FROM item WHERE item_id = @itemCode";
                string possibility = DatabaseHandler.returnOneValue(queryGetQtyCondition, paramlist, "possibility");

                if (string.Compare(possibility, "Yes") != 0) {
                    List<MySqlParameter> paramlist2 = new List<MySqlParameter>();
                    paramlist2.Clear();
                    paramlist2.Add(new MySqlParameter("@itemCode", itemCode));
                    string query = "SELECT qty FROM item WHERE item_id = @itemCode";
                    string available_qty = DatabaseHandler.returnOneValue(query, paramlist2, "qty");
                    Console.WriteLine("Availabel qty " + available_qty);
                    //Add to dataViewGrid7
                    int index2 = dataGridView7.DisplayedRowCount(true);
                    dataGridView7.Rows.Add();
                    dataGridView7.Rows[index2 - 1].Cells[0].Value = itemCode;
                    dataGridView7.Rows[index2- 1].Cells[1].Value = itemName;
                    dataGridView7.Rows[index2 - 1].Cells[2].Value = Int32.Parse(itemQty)- Int32.Parse(available_qty);



                }


                    //Add to dataViewGrid4
                    int index = dataGridView4.DisplayedRowCount(true);
                    dataGridView4.Rows.Add();
                    dataGridView4.Rows[index - 1].Cells[0].Value = itemCode;
                    dataGridView4.Rows[index - 1].Cells[1].Value = itemName;
                    dataGridView4.Rows[index - 1].Cells[2].Value = itemQty;
                    Console.WriteLine("In Add Btn: Current Index2: " + dataGridView4.DisplayedRowCount(true));
                itemNameTxt.Clear();
                qtyTxt.Clear();

            }
          
        }

        private void dataGridView5_SelectionChanged(object sender, EventArgs e)
        {
           
           
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                itemNameTxt.Text = dataGridView5.SelectedRows[0].Cells["Item Name"].Value.ToString();
                dataGridView6.DataSource = null;
                dataGridView6.Rows.Clear();
            }
            catch (Exception)
            {

            }
        }

        private void setReqNum()
        {
            string lastRo = DatabaseHandler.returnOneValueWithoutParams("SELECT * FROM itemorder", "io_id");
            int lastRoNum;
            if (lastRo == "Null Data!")
            {
                lastRoNum = 0;
            }
            else
            {
                lastRoNum = Int32.Parse(lastRo);
            }

            reqestNum.Text = (lastRoNum + 1).ToString();
            globalLastRo = lastRoNum;
        }

        private void dispatchRequestBtn_Click(object sender, EventArgs e)
        {
            setReqNum();
            int index3 = dataGridView4.DisplayedRowCount(true);
            if (index3 == 1) {

                MessageBox.Show("Update Failed! No items added");
                return;
            }
            try
            {
                string query = "insert into itemorder(client_id, approval,postedUser) values (@clientCode,'Pending',@user)";
                List<MySqlParameter> paramList = new List<MySqlParameter>();
                paramList.Clear();
                paramList.Add(new MySqlParameter("@clientCode", selectedClient));
                paramList.Add(new MySqlParameter("@user", GlobalLoginData.username));

                int rowsAffected = DatabaseHandler.insertOrDeleteRow(query, paramList);

                if (rowsAffected == 1)
                {
                    
                    try
                    {
                        Console.WriteLine("displayed rows" + dataGridView4.DisplayedRowCount(true));
                        int i = dataGridView4.DisplayedRowCount(true);
                        string itemid;
                        string qty;

                        for (int row = 0; row < i - 1; row++)
                        {
                            string lastRo = DatabaseHandler.returnOneValueWithoutParams("SELECT * FROM itemorder", "io_id");
                            Console.WriteLine("lastRo: " + lastRo);
                            itemid = dataGridView4.Rows[row].Cells[0].Value.ToString();
                            qty = dataGridView4.Rows[row].Cells[2].Value.ToString();
                            Console.WriteLine("itemid: " + itemid+" qty: "+qty);
                            string query2 = "INSERT INTO itemorder_item VALUES (@itemCode,@qty,@roNum)";
                            paramList.Clear();
                            paramList.Add(new MySqlParameter("@roNum", lastRo));
                            paramList.Add(new MySqlParameter("@itemCode", itemid));
                            paramList.Add(new MySqlParameter("@qty", qty));

                            rowsAffected = DatabaseHandler.insertOrDeleteRow(query2, paramList);
                            Console.WriteLine("rows affected: "+rowsAffected);
                            if (rowsAffected == 1)
                            {
                            }
                            else
                            {
                                MessageBox.Show("Update Failed! RO Link Broken");
                            }

                        }
                    }
                    catch (Exception)
                    {

                    }

                    
                }
                else
                {
                    MessageBox.Show("Update Failed!");
                    return;
                }
                MessageBox.Show("Item Order : Posted!");
                populateDataGrid();
                itemNameTxt.Clear();
                qtyTxt.Clear();
                dataGridView4.Rows.Clear();
                dataGridView7.Rows.Clear();
            }
            catch (Exception)
            {

            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            populateItemGrid(dataGridView1);
        }

        private void populateItemGrid(DataGridView dataGridView)
        {
            try
            {
                string val = dataGridView.SelectedRows[0].Cells["Order #"].Value.ToString();

                string select = "SELECT itemorder_item.io_id as 'Order #', itemorder_item.item_id as 'Item Code', item.name as 'Item Name', itemorder_item.qty as 'Qty' FROM itemorder_item INNER JOIN item ON itemorder_item.item_id = item.item_id WHERE itemorder_item.io_id = '" + val + "'";
                DatabaseHandler.populateGridViewWithBinding(select, dataGridView6);

                //populate dataGridView7 
                dataGridView7.Rows.Clear();
                string itemCode= null;
                string itemQty= null;
                string itemName = null;
                for (int i = 0; i < dataGridView6.DisplayedRowCount(true) - 1; i++)
                {
                    try
                    {
                        itemCode = dataGridView6.Rows[i].Cells[1].Value.ToString();
                        itemQty = dataGridView6.Rows[i].Cells[3].Value.ToString();
                        itemName= dataGridView6.Rows[i].Cells[2].Value.ToString();
                        List<MySqlParameter> paramlist = new List<MySqlParameter>();
                        paramlist.Clear();
                        paramlist.Add(new MySqlParameter("@itemCode", itemCode));
                        paramlist.Add(new MySqlParameter("@value", itemQty));

                        string queryGetQtyCondition = "SELECT IF(qty >= @value,'Yes','No') AS possibility FROM item WHERE item_id = @itemCode";
                        string possibility = DatabaseHandler.returnOneValue(queryGetQtyCondition, paramlist, "possibility");

                        if (string.Compare(possibility, "Yes") != 0)
                        {
                            List<MySqlParameter> paramlist2 = new List<MySqlParameter>();
                            paramlist2.Clear();
                            paramlist2.Add(new MySqlParameter("@itemCode", itemCode));
                            string query = "SELECT qty FROM item WHERE item_id = @itemCode";
                            string available_qty = DatabaseHandler.returnOneValue(query, paramlist2, "qty");
                            Console.WriteLine("Available qty " + available_qty);
                            //Add to dataViewGrid7
                            int index2 = dataGridView7.DisplayedRowCount(true);
                            dataGridView7.Rows.Add();
                            dataGridView7.Rows[index2 - 1].Cells[0].Value = itemCode;
                            dataGridView7.Rows[index2 - 1].Cells[1].Value = itemName;
                            dataGridView7.Rows[index2 - 1].Cells[2].Value = Int32.Parse(itemQty) - Int32.Parse(available_qty);
                        }
                    }


                    catch (Exception )
                    {
                        

                    }

                    }


                }

            catch (Exception )
            {
            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            populateItemGrid(dataGridView2);
        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            populateItemGrid(dataGridView3);
        }

        private void approveBtn_Click(object sender, EventArgs e)
        {
            string val = dataGridView1.SelectedRows[0].Cells["Order #"].Value.ToString();
            string update = "UPDATE itemorder set approval='Approved' where io_id=@ronum";
            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@ronum", val));

            int rowsAffected = DatabaseHandler.insertOrDeleteRow(update, paramList);

            if (rowsAffected != 0)
            {
                MessageBox.Show("Item Order Confirmed!");
                populateDataGrid();
            }
            else
            {
                MessageBox.Show("Error Occured! Please check Selection!");
            }

           
        }

        private void declineBtn_Click(object sender, EventArgs e)
        {
            string val = dataGridView1.SelectedRows[0].Cells["Order #"].Value.ToString();
            string update = "UPDATE itemorder set approval='Declined' where io_id=@ronum";


       
            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@ronum", val));

            int rowsAffected = DatabaseHandler.insertOrDeleteRow(update, paramList);

            if (rowsAffected != 0)
            {
               
                MessageBox.Show("Purchase Order Declined!");
                populateDataGrid();
            }
            else
            {
                MessageBox.Show("Error Occured! Please check Selection!");
            }
        }

        private void dispatchBtn_Click(object sender, EventArgs e)
        {
            string val = null;
            try
            {
                val = dataGridView2.SelectedRows[0].Cells["Order #"].Value.ToString();
            }
            catch(Exception)
            {
                MessageBox.Show("Nothing Selected");
            }
            if (dataGridView7.DisplayedRowCount(true) != 1) 
            {
                MessageBox.Show("INSUFFICIANT ITEMS IN THE STORE CANNOT DISPATCH ITEMS ");
                return;
            }
            string update = "UPDATE itemorder set released='Yes' where io_id=@ronum";
            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@ronum", val));

            int rowsAffected = DatabaseHandler.insertOrDeleteRow(update, paramList);

            if (rowsAffected != 0)
            {

                 string itemCodeTemp;
                string putout;
               string putoutqty;
                
               for (int i = 0; i < dataGridView6.DisplayedRowCount(true) - 1; i++)
              {
                try
              {
                        itemCodeTemp = dataGridView6.Rows[i].Cells["Item Code"].Value.ToString();
                        putoutqty = dataGridView6.Rows[i].Cells["Qty"].Value.ToString();
                        putout = "UPDATE item SET qty = qty - @putoutQty WHERE item_id = @itemCode";

                        Console.WriteLine("GridView Row Count: " + dataGridView6.DisplayedRowCount(true));
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
        private void dataViewDesign(DataGridView dataGridView)
        {
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView.ColumnHeadersDefaultCellStyle.Font =
                new Font(dataGridView.Font, FontStyle.Bold);
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void DataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Clear_btn_Click(object sender, EventArgs e)
        {

            itemNameTxt.Clear();
            qtyTxt.Clear();
            dataGridView4.Rows.Clear();
            dataGridView7.Rows.Clear();
        }
    }

}
