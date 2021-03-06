﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace rpc_working
{
    public partial class Stores : UserControl
    {
        public Stores()
        {
            InitializeComponent();
        }


        public void Stores_Load(object sender, EventArgs e)
        {
            setId();
            populateGrid();
            if (GlobalLoginData.userRole != "Owner")
            {
                addItemBtn.Enabled = false;
                button2.Enabled = false;
                removeProduct_btn.Enabled = false;
                clear_btn.Enabled = false;
                removeMaterialsbtn.Enabled = false; 
            }
        }

        
        private void populateGrid()
        {
            string query = "SELECT item_id as 'Item Code', name as 'Item Name', qty as 'Available Quantity', unit_price as 'Unit Price' FROM item";
            DatabaseHandler.populateGridViewWithBinding(query, dataGridView1);
            string selectStatement4 = "SELECT raw_material.material_id as 'Material ID', raw_material.name as 'Material Name', raw_material.qty as 'Available Quantity' FROM raw_material";
           // DatabaseHandler.populateViewwithNoParameters(selectStatement4, dataGridView2);
           // string query1 = "SELECT material_id as 'Item Code', name as 'Item Name', qty as 'Available Quantity', unit_price as 'Unit Price', supplier as FROM raw_material";
            DatabaseHandler.populateGridViewWithBinding(selectStatement4, dataGridView2);
        }

        private void findProductName_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT item_id as 'Item Code', name as 'Item Name', qty as 'Available Quantity', unit_price as 'Unit Price'FROM item WHERE name like '%" + findProductName.Text + "%'";
            DatabaseHandler.populateGridViewWithBinding(query, dataGridView1);
            string selectStatement = "SELECT raw_material.material_id as 'Material ID',  raw_material.name as 'Material Name', raw_material.qty as 'Available Quantity' FROM raw_material WHERE raw_material.name like '%" + findProductName.Text + "%'";
            DatabaseHandler.populateGridViewWithBinding(selectStatement, dataGridView2);
        }

        private void findProductId_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT item_id as 'Item Code', name as 'Item Name', qty as 'Available Quantity', unit_price as 'Unit Price'FROM item WHERE item_id like '%" + findProductId.Text + "%'";
            DatabaseHandler.populateGridViewWithBinding(query, dataGridView1);
            string selectStatement = "SELECT raw_material.material_id as 'Material ID',  raw_material.name as 'Material Name', raw_material.qty as 'Available Quantity' FROM raw_material WHERE raw_material.material_id like '%" + findProductId.Text + "%'";
            DatabaseHandler.populateGridViewWithBinding(selectStatement, dataGridView2);
        }

        private void manualProductId_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT item_id as 'Item Code', name as 'Item Name', qty as 'Available Quantity', unit_price as 'Unit Price'FROM item WHERE item_id like '%" + findProductId.Text + "%'";
            DatabaseHandler.populateGridViewWithBinding(query, dataGridView1);
            string selectStatement = "SELECT raw_material.material_id as 'Material ID',  raw_material.name as 'Material Name', raw_material.qty as 'Available Quantity' FROM raw_material WHERE raw_material.material_id like '%" + findProductId.Text + "%'";
            DatabaseHandler.populateGridViewWithBinding(selectStatement, dataGridView2);
        }

        private void manualQty_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(manualQty.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter numbers only..");
                manualQty.Text = manualQty.Text.Remove(manualQty.Text.Length - 1);
            }
        }

        private void manualAddBtn_Click(object sender, EventArgs e)
        {

            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Clear();
            paramList.Add(new MySqlParameter("@itemCode", manualProductId.Text));
            int returnedRowCount = DatabaseHandler.returnRowCount("SELECT * FROM item WHERE item_id = @itemCode", paramList);
            int returnedRowCount2 = DatabaseHandler.returnRowCount("SELECT * FROM raw_material WHERE material_id = @itemCode", paramList);

            if (returnedRowCount == 1)
            {
                try
                {
                    List<MySqlParameter> paramList2 = new List<MySqlParameter>();
                    paramList2.Clear();
                    paramList2.Add(new MySqlParameter("@itemQty", manualQty.Text));
                    paramList2.Add(new MySqlParameter("@itemCode", manualProductId.Text));
                    int responseChange = DatabaseHandler.insertOrDeleteRow("UPDATE item SET qty = qty + @itemQty WHERE item_id = @itemCode", paramList2);
                    if (responseChange == 1)
                    {
                        MessageBox.Show("Update Successful");
                    }
                    else
                    {
                        MessageBox.Show("Error Occured!");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error Occured!");
                }
            }
            else if (returnedRowCount2 == 1)
            {
                try
                {
                    List<MySqlParameter> paramList2 = new List<MySqlParameter>();
                    paramList2.Clear();
                    paramList2.Add(new MySqlParameter("@itemQty", manualQty.Text));
                    paramList2.Add(new MySqlParameter("@itemCode", manualProductId.Text));
                    int responseChange = DatabaseHandler.insertOrDeleteRow("UPDATE raw_material SET qty = qty + @itemQty WHERE material_id = @itemCode", paramList2);
                    if (responseChange == 1)
                    {
                        MessageBox.Show("Update Successful");
                    }
                    else
                    {
                        MessageBox.Show("Error Occured!");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error Occured!");
                }


            }

            else {
                    MessageBox.Show("Sorry, Invalid item Code");
                 }

            populateGrid();

        }

        private void manualSubstractBtn_Click(object sender, EventArgs e)
        {
            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Clear();
            paramList.Add(new MySqlParameter("@itemCode", manualProductId.Text));
            int returnedRowCount = DatabaseHandler.returnRowCount("SELECT * FROM item WHERE item_id = @itemCode", paramList);
            int returnedRowCount2 = DatabaseHandler.returnRowCount("SELECT * FROM raw_material WHERE material_id = @itemCode", paramList);

            if (returnedRowCount == 1)
            {

                try
                {
                    List<MySqlParameter> paramList3 = new List<MySqlParameter>();
                    paramList3.Clear();
                    paramList3.Add(new MySqlParameter("@itemCode", manualProductId.Text));
                    paramList3.Add(new MySqlParameter("@value", manualQty.Text));
                    string queryGetQtyCondition = "SELECT IF(qty >= @value,'Yes','No') AS possibility FROM item WHERE item_id = @itemCode";
                    string possibility = DatabaseHandler.returnOneValue(queryGetQtyCondition, paramList3, "possibility");
                    Console.WriteLine("String Possibility " + possibility);
                    if (string.Compare(possibility, "Yes") == 0)
                    {
                        Console.WriteLine("String Possibility Inside If ");
                        try
                        {
                            List<MySqlParameter> paramList2 = new List<MySqlParameter>();
                            paramList2.Clear();
                            paramList2.Add(new MySqlParameter("@itemQty", manualQty.Text));
                            paramList2.Add(new MySqlParameter("@itemCode", manualProductId.Text));
                            int responseChange = DatabaseHandler.insertOrDeleteRow("UPDATE item SET qty = qty - @itemQty WHERE item_id = @itemCode", paramList2);
                            if (responseChange == 1)
                            {
                                MessageBox.Show("Update Successful");
                            }
                            else
                            {
                                MessageBox.Show("Error Occured!");
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Error Occured!");
                        }
                    }
                    else {
                        MessageBox.Show("INSUFFICIANT ITEMS!");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Sorry, Invalid Item Code");
                }

            }
            else if(returnedRowCount2==1)
            {
                try
                {
                    List<MySqlParameter> paramList3 = new List<MySqlParameter>();
                    paramList3.Clear();
                    paramList3.Add(new MySqlParameter("@itemCode", manualProductId.Text));
                    paramList3.Add(new MySqlParameter("@value", manualQty.Text));
                    string queryGetQtyCondition = "SELECT IF(qty >= @value,'Yes','No') AS possibility FROM raw_material WHERE material_id = @itemCode";
                    string possibility = DatabaseHandler.returnOneValue(queryGetQtyCondition, paramList3, "possibility");
                    Console.WriteLine("String Possbility " + possibility);
                    if (string.Compare(possibility, "Yes") == 0)
                    {
                        Console.WriteLine("String Possibility Inside If ");
                        try
                        {
                            List<MySqlParameter> paramList2 = new List<MySqlParameter>();
                            paramList2.Clear();
                            paramList2.Add(new MySqlParameter("@itemQty", manualQty.Text));
                            paramList2.Add(new MySqlParameter("@itemCode", manualProductId.Text));
                            int responseChange = DatabaseHandler.insertOrDeleteRow("UPDATE raw_material SET qty = qty - @itemQty WHERE material_id = @itemCode", paramList2);
                            if (responseChange == 1)
                            {
                                MessageBox.Show("Update Successful");
                            }
                            else
                            {
                                MessageBox.Show("Error Occured!");
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Error Occured!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("INSUFFICIANT ITEMS!");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Sorry, Invalid Item Code");
                }


            }
            else
            {
                MessageBox.Show("Sorry, Invalid Item Code");
            }
            populateGrid();
        }

        private void AddItemBtn_Click(object sender, EventArgs e)
        {
            Console.WriteLine("In Add Btn: Current Index1: " + composition_dataGridView.Rows.Count);

            string itemCode = addmaterialCodeTxt.Text;
            string itemQty = addmaterialQty.Text;

            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@itemCode", itemCode));
            int returnedRowCount = DatabaseHandler.returnRowCount("SELECT*FROM raw_material WHERE material_id=@itemCode", paramList);

            if (returnedRowCount != 0)
            {
                //Get Item Name from DB
                paramList.Clear();
                paramList.Add(new MySqlParameter("@itemCode", itemCode));
                string itemName = DatabaseHandler.returnOneValue("SELECT name as 'Material Name' from raw_material where material_id=@itemCode", paramList, "Material Name");


                //Add to composition_dataGridView
               // int index = composition_dataGridView.DisplayedRowCount(true);
                composition_dataGridView.Rows.Add(itemCode, itemName, itemQty);

               // composition_dataGridView.Rows[index - 1].Cells[0].Value = itemCode;
               // composition_dataGridView.Rows[index - 1].Cells[1].Value = itemName;
                //composition_dataGridView.Rows[index - 1].Cells[2].Value = itemQty;

            }
            else
            {
                MessageBox.Show("Invalid Material Code!");
            }

            Console.WriteLine("In Add Btn: Current Index2: " + composition_dataGridView.Rows.Count);

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            String product_id = prodctId_txt.Text;
            String productName = productName_txt.Text;
            String unitPrice = unitPrice_txt.Text;
            int i = composition_dataGridView.Rows.Count;
            Console.WriteLine("Special i Value: " + i);

            try
            {
                string query = "insert into item(item_id, name , unit_price) values (@product_id,@productName,@unitPrice)";
                List<MySqlParameter> paramList = new List<MySqlParameter>();
                paramList.Clear();
                paramList.Add(new MySqlParameter("@product_id", product_id));
                paramList.Add(new MySqlParameter("@productName", productName));
                paramList.Add(new MySqlParameter("@unitPrice", unitPrice));

                int rowsAffected = DatabaseHandler.insertOrDeleteRow(query, paramList);

                if (rowsAffected != 0)
                {
                   MessageBox.Show("New product added Successfully!");


                    populateGrid();
                }
                else
                {
                    MessageBox.Show("Error Occured! Please check input details!");
                    return;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error Occured! Please check input details!");
            }


          
            string materialId;
            string material_qty;
            string material_name;

            for (int row = 0; row <i - 1; row++)
            {

                materialId = composition_dataGridView.Rows[row].Cells[0].Value.ToString();
               material_name= composition_dataGridView.Rows[row].Cells[1].Value.ToString();
                material_qty = composition_dataGridView.Rows[row].Cells[2].Value.ToString();
                Console.WriteLine(materialId + "   " + material_qty);

                try
                {   
                    string query = "INSERT INTO composition (item_id,material_id,quantity) VALUES (@ItemId,@materialId,@qty)";
                    List<MySqlParameter> paramList2 = new List<MySqlParameter>();
                    paramList2.Add(new MySqlParameter("@ItemId", product_id));
                    paramList2.Add(new MySqlParameter("@materialId", materialId));
                    paramList2.Add(new MySqlParameter("@qty", material_qty));

                    int rowsAffected = DatabaseHandler.insertOrDeleteRow(query, paramList2);

                    if (rowsAffected == 0)
                    {
                        MessageBox.Show("Error Occured! Item-material Link Broken!");
                        
                    }
                    else {
                       // MessageBox.Show("Item added sucsessfully");
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Error Occured! Please check if the Product already exists!");
                }
            


            }
            populateGrid();
            prodctId_txt.Text = "";
            productName_txt.Text = "";
            unitPrice_txt.Text = "";
            addmaterialCodeTxt.Text = "";
            addmaterialQty.Text = "";
            composition_dataGridView.Rows.Clear();
            Console.WriteLine("Current Row Count: " + composition_dataGridView.RowCount);
            Console.WriteLine("Current Displayed Row Count: " + composition_dataGridView.DisplayedRowCount(true));


        }

        private void DataGridView1_Click(object sender, EventArgs e)
        {
             try
                {
                    string val = dataGridView1.SelectedRows[0].Cells["Item Code"].Value.ToString();

                    string select = "SELECT item.item_id as 'Item Code',  composition.material_id as 'Material ID', composition.quantity as 'Quantity'  FROM item INNER JOIN composition ON item.item_id = composition.item_id WHERE item.item_id = '" + val + "'";
                    DatabaseHandler.populateGridViewWithBinding(select, dataGridView5);
                }
                catch (Exception err)
                {  
                    Console.WriteLine(err);
                }

            
        }

        private void RemoveProduct_btn_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedRowIndex];
            string itemCode = Convert.ToString(selectedRow.Cells["Item Code"].Value);

            string query2 = "DELETE FROM item WHERE item_id=@itemCode";

            List<MySqlParameter> paramList2 = new List<MySqlParameter>();
            paramList2.Clear();
            paramList2.Add(new MySqlParameter("@itemCode", itemCode));
            int rowsAffected2 = DatabaseHandler.insertOrDeleteRow(query2, paramList2);

            if (rowsAffected2 == 0)
            {
                MessageBox.Show("Error! Item has existing client order items ! Remove client items first! ");
                return;
            }

            try
            {
                string query = "DELETE FROM composition WHERE item_id=@itemCode";

                List<MySqlParameter> paramList = new List<MySqlParameter>();
                paramList.Clear();
                paramList.Add(new MySqlParameter("@itemCode", itemCode));
                int rowsAffected = DatabaseHandler.insertOrDeleteRow(query, paramList);

                if (rowsAffected != 0)
                {
                    MessageBox.Show("Item Removed Successfully!");
                    populateGrid();
                }
                else
                {
                    MessageBox.Show("Error!");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Item doesn't exist!");
            }

            try
            {
                string query = "DELETE FROM item WHERE item_id=@itemCode";

                List<MySqlParameter> paramList = new List<MySqlParameter>();
                paramList.Clear();
                paramList.Add(new MySqlParameter("@itemCode", itemCode));
                int rowsAffected = DatabaseHandler.insertOrDeleteRow(query, paramList);

                if (rowsAffected != 0)
                {
                    //MessageBox.Show("Item Removed Successfully!");
                    populateGrid();
                }
                else
                {
                    MessageBox.Show("Error!");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Item doesn't exist!");
            }


        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            composition_dataGridView.DataSource = null;
            composition_dataGridView.Rows.Clear();
            prodctId_txt.Clear();
            productName_txt.Clear();
            unitPrice_txt.Clear();
            addmaterialCodeTxt.Clear();
            addmaterialQty.Clear();
        }

        private void setId()
        {
            string lastId = DatabaseHandler.returnOneValueWithoutParams("SELECT * FROM item", "item_id");
            string nextId;
            if (lastId == "Null Data!")
            {
                nextId = "#0001";
            }
            else
            {
                var prefix = System.Text.RegularExpressions.Regex.Match(lastId, "^\\#+").Value;
                var number = System.Text.RegularExpressions.Regex.Replace(lastId, "^\\#+", "");
                var i = int.Parse(number) + 1;
                nextId = (prefix + i.ToString(new string('0', number.Length))).ToString();
            }

            prodctId_txt.Text = nextId;


        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            dataGridView5.DataSource = null;
            
        }

        private void unitPrice_txt_TextChanged(object sender, EventArgs e)
        {

            if (!System.Text.RegularExpressions.Regex.IsMatch(unitPrice_txt.Text, @"^[0-9]*(?:\.[0-9]*)?$"))
            {
                MessageBox.Show("Please enter only numbers.");
                unitPrice_txt.Text = unitPrice_txt.Text.Remove(unitPrice_txt.Text.Length - 1);
            }
        }

        private void addmaterialQty_TextChanged(object sender, EventArgs e)
        {

            if (!System.Text.RegularExpressions.Regex.IsMatch(addmaterialQty.Text, @"^[0-9]*(?:\.[0-9]*)?$"))
            {
                MessageBox.Show("Please enter only numbers.");
                addmaterialQty.Text = addmaterialQty.Text.Remove(addmaterialQty.Text.Length - 1);
            }
        }

        private void removeMaterialsbtn_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = dataGridView2.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView2.Rows[selectedRowIndex];
            string materialCode = Convert.ToString(selectedRow.Cells["Material ID"].Value);
            try
            {
                string query = "DELETE FROM raw_material WHERE material_id=@materialCode";
                List<MySqlParameter> paramList = new List<MySqlParameter>();
                paramList.Clear();
                paramList.Add(new MySqlParameter("@materialCode", materialCode));
                int rowsAffected = DatabaseHandler.insertOrDeleteRow(query, paramList);

                if (rowsAffected != 0)
                {
                    MessageBox.Show("Material Removed Successfully!");
                    populateGrid();
                }
                else
                {
                    MessageBox.Show("Error! The material may have unremoved supplier items. Remove supplier items first!");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error! The material may have unremoved supplier items. Remove supplier items first!");
            }
        }
    }
}
