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
    public partial class Supplier : UserControl
    {
        public Supplier()
        {
            InitializeComponent();
        }

        public void Supplier_Load(object sender, EventArgs e)
        {
            populateGrid();
            setId();
            if (GlobalLoginData.userRole == "StoreKeeper")
            {
                addSupplierBtn.Enabled = false;
                addItemBtn.Enabled = false;
                removeSupplierBtn.Enabled = false;
                removeItemBtn.Enabled = false;
                addNewMaterial_btn.Enabled = false;


            }
            else if (GlobalLoginData.userRole == "Accountant") 
            {
                addNewMaterial_btn.Enabled = false;
                addItemBtn.Enabled = true;
            }
           
        }

        private void contactNumTxt_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(contactNumberTxt.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                contactNumberTxt.Text = contactNumberTxt.Text.Remove(contactNumberTxt.Text.Length - 1);
            }
        }

        private void addSupplierBtn_Click(object sender, EventArgs e)
        {
            string supplierName = supplierNameTxt.Text;
            string supplierCode = supplierCodeTxt.Text;
            string contactNumber = contactNumberTxt.Text;
            string email = emailTxt.Text;
            if (String.IsNullOrEmpty(supplierName) || String.IsNullOrEmpty(supplierCode) || String.IsNullOrEmpty(contactNumber) || String.IsNullOrEmpty(email))
            {
                MessageBox.Show("One or more feilds are empty!");
            }
            else if (contactNumber.Length != 10) 
            {
                MessageBox.Show("Incorrect Contact Number!");
            }
            else if (!String.IsNullOrEmpty(supplierName) && !String.IsNullOrEmpty(supplierCode) && !String.IsNullOrEmpty(contactNumber) && !String.IsNullOrEmpty(email))
            {
                try
                {
                    string query = "INSERT INTO SUPPLIER VALUES (@supplierCode,@supplierName,@contactNumber,@email)";
                    List<MySqlParameter> paramList = new List<MySqlParameter>();
                    paramList.Add(new MySqlParameter("@supplierCode", supplierCode));
                    paramList.Add(new MySqlParameter("@supplierName", supplierName));
                    paramList.Add(new MySqlParameter("@contactNumber", contactNumber));
                    paramList.Add(new MySqlParameter("@email", email));

                    int rowsAffected = DatabaseHandler.insertOrDeleteRow(query, paramList);

                    if (rowsAffected != 0)
                    {
                        MessageBox.Show("Supplier Added Successfully!");
                        populateGrid();
                        supplierNameTxt.Text = "";
                        supplierCodeTxt.Text = "";
                        contactNumberTxt.Text = "";
                        emailTxt.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Error Occured! Please check if the Supplier already exists!");
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Error Occured! Please check if the Supplier already exists!");
                }
            }
        }

        private void populateGrid()
        {
            string selectStatement = "SELECT supplier_id as 'Supplier ID', name as 'Supplier Name' , contact_no as 'Contact Number', email as 'Email' FROM SUPPLIER";
            DatabaseHandler.populateViewwithNoParameters(selectStatement, dataGridView1);

            string selectStatement4 = "SELECT raw_material.material_id as 'Material ID', raw_material.name as 'Material Name', raw_material.qty as 'Quantity' FROM raw_material "; 
            DatabaseHandler.populateViewwithNoParameters(selectStatement4, dataGridView2);        
        }

        private void addItemBtn_Click(object sender, EventArgs e)
        {
            string itemSupplierCode = itemSupplierCodeTxt.Text;
            string itemId = itemIdTxt.Text;
            string itemName = itemNameTxt.Text;
            string unitPrice = unitPriceText.Text;
            string lead_time = leadTime_txt.Text;
            if (String.IsNullOrEmpty(itemSupplierCode) || String.IsNullOrEmpty(itemId) || String.IsNullOrEmpty(itemName) || String.IsNullOrEmpty(unitPrice))
            {
                MessageBox.Show("One or more feilds are empty!");
            }
            else if (!String.IsNullOrEmpty(itemSupplierCode) && !String.IsNullOrEmpty(itemId) && !String.IsNullOrEmpty(itemName) && !String.IsNullOrEmpty(unitPrice))
            {
                if (DatabaseHandler.returnRowCountWithoutParams("SELECT * FROM raw_material where material_id='" + itemIdTxt.Text + "'") != 0)
                {
                    try
                    {
                       // MessageBox.Show("Such material exists, it will be added to the supplier mentioned");
                        
                        string query = "INSERT INTO supplier_material(material_id,supplier_id,unit_price,lead_time) VALUES (@itemId,@itemSupplierCode,@unitPrice,@leadTime)";
                        List<MySqlParameter> paramList = new List<MySqlParameter>();
                        paramList.Add(new MySqlParameter("@itemSupplierCode", itemSupplierCode));
                        paramList.Add(new MySqlParameter("@itemId", itemId));
                        paramList.Add(new MySqlParameter("@unitPrice", unitPrice));
                        paramList.Add(new MySqlParameter("@leadTime", lead_time));

                        int rowsAffected = DatabaseHandler.insertOrDeleteRow(query, paramList);

                        if (rowsAffected != 0)
                        {
                            MessageBox.Show("Item Added Successfully!");
                            itemSupplierCodeTxt.Text = "";
                            itemIdTxt.Text = "";
                            itemNameTxt.Text = "";
                            unitPriceText.Text = "";
                            leadTime_txt.Text = "";
                            populateGrid();
                        }
                        else
                        {
                            MessageBox.Show("Error Occured! Please check the Info entered!");

                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error Occured! Please check if the Item already exists with the mentioned supplier!");
                    }
                }
                else
                {
                    MessageBox.Show("Error Occured! No such material exists!");
                }
            }
        }

        private void itemSupplierCodeTxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string selectStatement = "SELECT supplier_id as 'Supplier Code', name as 'Supplier' , contact_no as 'Contact Number', email as 'Email' FROM SUPPLIER WHERE supplier_id like '%" + itemSupplierCodeTxt.Text + "%'";
                DatabaseHandler.populateViewwithNoParameters(selectStatement, dataGridView1);
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }
        }

        private void removeSupplierBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "DELETE FROM SUPPLIER WHERE supplier_id=@supplierCode";
                List<MySqlParameter> paramList = new List<MySqlParameter>();
                paramList.Clear();
                paramList.Add(new MySqlParameter("@supplierCode", removeSupplierId.Text));
                int rowsAffected = DatabaseHandler.insertOrDeleteRow(query, paramList);

                if (rowsAffected != 0)
                {
                    MessageBox.Show("Supplier Removed Successfully!");
                    populateGrid();
                }
                else
                {
                    MessageBox.Show("Error! The supplier may have unremoved items. Remove items first!");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error! The supplier may have unremoved items. Remove items first!");
            }
        }

        private void removeSupplierId_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string selectStatement = "SELECT supplier_id as 'Supplier Code', name as 'Supplier' , contact_no as 'Contact Number', email as 'Email' FROM SUPPLIER WHERE supplier_id like '%" + removeSupplierId.Text + "%'";
                DatabaseHandler.populateViewwithNoParameters(selectStatement, dataGridView1);
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }
        }

        private void findById_TextChanged(object sender, EventArgs e)
        {
            try
            {
 
                string selectStatement = "SELECT supplier_id as 'Supplier Code', name as 'Supplier' , contact_no as 'Contact Number', email as 'Email' FROM SUPPLIER WHERE supplier_id like '%" + findById.Text + "%'";
                DatabaseHandler.populateViewwithNoParameters(selectStatement, dataGridView1);
            
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }
        }

        private void findByName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string selectStatement = "SELECT supplier_id as 'Supplier Code', name as 'Supplier' , contact_no as 'Contact Number', email as 'Email' FROM SUPPLIER WHERE name like '%" + findByName.Text + "%'";
                 DatabaseHandler.populateViewwithNoParameters(selectStatement, dataGridView1);
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }
        }

        private void removeItemBtn_Click(object sender, EventArgs e)
        {
            removeItem();

        }

       

       
        private void removeItem()
        {
            int selectedRowIndex = dataGridView2.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView2.Rows[selectedRowIndex];
            string itemCode = Convert.ToString(selectedRow.Cells["Material ID"].Value);

            try
            {
                string query = "DELETE FROM raw_material WHERE material_id=@itemCode";
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
                MessageBox.Show("Error!");
            }
        }

        private void itemIdTxt_Leave(object sender, EventArgs e)
        {
            if (DatabaseHandler.returnRowCountWithoutParams("SELECT * FROM raw_material where material_id='" + itemIdTxt.Text + "'") != 0)
            {
                String matrialName;
                matrialName = DatabaseHandler.returnOneValueWithoutParams("SELECT name FROM raw_material WHERE material_id='" + itemIdTxt.Text + "'", "name").ToString();
                itemNameTxt.Text = matrialName;
                itemNameTxt.Enabled = false;
                addNewMaterial_btn.Enabled = false;
                addItemBtn.Enabled = true;


            }
            else 
            {
                itemNameTxt.Enabled = true;
                addNewMaterial_btn.Enabled = true;
                addItemBtn.Enabled = false;
            }
        }

        private void addNewMaterial_btn_Click(object sender, EventArgs e)
        {
            string itemId = itemIdTxt.Text;
            string itemName = itemNameTxt.Text;

            if (String.IsNullOrEmpty(itemId) || String.IsNullOrEmpty(itemName))
            {
                MessageBox.Show("One or more feilds are empty!");
            }


            string query = "INSERT INTO raw_material(material_id,name) VALUES (@itemId,@itemName)";
            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@itemId", itemId));
            paramList.Add(new MySqlParameter("@itemName", itemName));

            int rowsAffected = DatabaseHandler.insertOrDeleteRow(query, paramList);

            if (rowsAffected != 0 )
            {
                MessageBox.Show("New material Added Successfully!");
                itemNameTxt.Enabled = false;
                addNewMaterial_btn.Enabled = false;
                addItemBtn.Enabled = true;
                populateGrid();
            }
            else
            {
                MessageBox.Show("Error Occured! Please check if the Info entered!");

            }
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            try
            {
                string val = dataGridView2.SelectedRows[0].Cells["Material ID"].Value.ToString();

                string select = "SELECT material_id as 'Material Code',  supplier_id as 'Supplier ID', unit_price as 'Unit Price', lead_time as 'Lead Time'  FROM supplier_material  WHERE material_id = '" + val + "'";
                DatabaseHandler.populateGridViewWithBinding(select, dataGridView5);
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                string val = dataGridView1.SelectedRows[0].Cells["Supplier ID"].Value.ToString();

                string select = "SELECT material_id as 'Material Code',  supplier_id as 'Supplier ID', unit_price as 'Unit Price', lead_time as 'Lead Time'  FROM supplier_material  WHERE  supplier_id = '" + val + "'";
                DatabaseHandler.populateGridViewWithBinding(select, dataGridView5);
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }
        }
        private void setId()
        {
            string lastId = DatabaseHandler.returnOneValueWithoutParams("SELECT * FROM supplier", "supplier_id");
            string nextId;
            string lastId2 = DatabaseHandler.returnOneValueWithoutParams("SELECT * FROM raw_material", "material_id");
            string nextId2;
            if (lastId == "Null Data!")
            {
                nextId = "&0001";
            }
            else
            {
                var prefix = System.Text.RegularExpressions.Regex.Match(lastId, "^\\&+").Value;
                var number = System.Text.RegularExpressions.Regex.Replace(lastId, "^\\&+", "");
                var i = int.Parse(number) + 1;
                nextId = (prefix + i.ToString(new string('0', number.Length))).ToString();
            }

            supplierCodeTxt.Text = nextId;

            if (lastId2 == "Null Data!")
            {
                nextId2 = "$0001";
            }
            else
            {
                var prefix = System.Text.RegularExpressions.Regex.Match(lastId2, "^\\$+").Value;
                var number = System.Text.RegularExpressions.Regex.Replace(lastId2, "^\\$+", "");
                var i = int.Parse(number) + 1;
                nextId2 = (prefix + i.ToString(new string('0', number.Length))).ToString();
            }
            Console.WriteLine("next material Id"+ nextId2);
            Console.WriteLine("next item Id" + nextId);

            itemIdTxt.Text = "";
            itemIdTxt.Text = nextId2;


        }

        private void unitPriceText_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(unitPriceText.Text, @"^[0-9]*(?:\.[0-9]*)?$"))
            {
                MessageBox.Show("Please enter numbers only..");
                unitPriceText.Text = unitPriceText.Text.Remove(unitPriceText.Text.Length - 1);
            }
        }
        private void leadTime_txt_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(leadTime_txt.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter numbers only..");
                leadTime_txt.Text = leadTime_txt.Text.Remove(leadTime_txt.Text.Length - 1);
            }
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            supplierNameTxt.Text = "";
            supplierCodeTxt.Text = "";
            contactNumberTxt.Text = "";
            emailTxt.Text = "";
        }

        private void itemIdTxt_TextChanged(object sender, EventArgs e)
        {
            if (DatabaseHandler.returnRowCountWithoutParams("SELECT * FROM raw_material where material_id='" + itemIdTxt.Text + "'") != 0)
            {
                String matrialName;
                matrialName = DatabaseHandler.returnOneValueWithoutParams("SELECT name FROM raw_material WHERE material_id='" + itemIdTxt.Text + "'", "name").ToString();
                itemNameTxt.Text = matrialName;
                itemNameTxt.Enabled = false;
                addNewMaterial_btn.Enabled = false;
                addItemBtn.Enabled = true;


            }
            else
            {
                itemNameTxt.Enabled = true;
                addNewMaterial_btn.Enabled = true;
                addItemBtn.Enabled = false;
                itemNameTxt.Text = "";
            }

        }
    }
}
