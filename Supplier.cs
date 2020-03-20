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
            if (GlobalLoginData.userRole != "Owner")
            {
                addSupplierBtn.Enabled = false;
                addItemBtn.Enabled = false;
                removeSupplierBtn.Enabled = false;
                removeItemBtn.Enabled = false;
               

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
             else if (!String.IsNullOrEmpty(supplierName) && !String.IsNullOrEmpty(supplierCode) && !String.IsNullOrEmpty(contactNumber)  && !String.IsNullOrEmpty(email))
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

                    if(rowsAffected != 0)
                    {
                        MessageBox.Show("Supplier Added Successfully!");
                        populateGrid();
                        supplierNameTxt.Text="";
                        supplierCodeTxt.Text="";
                        contactNumberTxt.Text="";
                        emailTxt.Text="";
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

            string selectStatement4 = "SELECT raw_material.material_id as 'Material ID', raw_material.name as 'Material Name', raw_material.unit_price as 'Unit Price',  SUPPLIER.supplier_ID as 'Supplier ID', SUPPLIER.name as 'Supplier Name' FROM SUPPLIER INNER JOIN raw_material ON SUPPLIER.supplier_id = raw_material.supplier_id "; 
            DatabaseHandler.populateViewwithNoParameters(selectStatement4, dataGridView2);

            if (!String.IsNullOrEmpty(findById.Text))
            {
                string selectStatement2 = "SELECT raw_material.material_id as 'Material ID',  raw_material.name as 'Material Name', raw_material.unit_price as 'Unit Price', SUPPLIER.supplier_ID as 'Supplier ID', SUPPLIER.name as 'Supplier Name' FROM SUPPLIER INNER JOIN raw_material ON SUPPLIER.supplier_id = raw_material.supplier_id WHERE SUPPLIER.supplier_id like '%" + findById.Text + "%'";
                DatabaseHandler.populateViewwithNoParameters(selectStatement2, dataGridView2);
            }
            else if(!String.IsNullOrEmpty(findByName.Text))
            {
                string selectStatement3 = "SELECT raw_material.material_id as 'Material ID', raw_material.name as 'Material Name',  raw_material.unit_price as 'Unit Price', SUPPLIER.supplier_ID as 'Supplier ID', SUPPLIER.name as 'Supplier Name' FROM SUPPLIER INNER JOIN raw_material ON SUPPLIER.supplier_id = raw_material.supplier_id WHERE SUPPLIER.supplier_name like '%" + findByName.Text + "%'";
                DatabaseHandler.populateViewwithNoParameters(selectStatement3, dataGridView2);
            }
            else
            {
                   DatabaseHandler.populateViewwithNoParameters(selectStatement4, dataGridView2);
            }
           

           
        }

        private void addItemBtn_Click(object sender, EventArgs e)
        {
            string itemSupplierCode = itemSupplierCodeTxt.Text;
            string itemId = itemIdTxt.Text;
            string itemName = itemNameTxt.Text;
            string unitPrice = unitPriceText.Text;
            if (String.IsNullOrEmpty(itemSupplierCode) || String.IsNullOrEmpty(itemId) || String.IsNullOrEmpty(itemName) || String.IsNullOrEmpty(unitPrice))
            {
                MessageBox.Show("One or more feilds are empty!");
            }
            else if (!String.IsNullOrEmpty(itemSupplierCode) && !String.IsNullOrEmpty(itemId) && !String.IsNullOrEmpty(itemName) && !String.IsNullOrEmpty(unitPrice))
            {
                try
                {
                    string query = "INSERT INTO raw_material(supplier_id,material_id,name,unit_price) VALUES (@itemSupplierCode,@itemId,@itemName,@unitPrice)";
                    List<MySqlParameter> paramList = new List<MySqlParameter>();
                    paramList.Add(new MySqlParameter("@itemSupplierCode", itemSupplierCode));
                    paramList.Add(new MySqlParameter("@itemId", itemId));
                    paramList.Add(new MySqlParameter("@itemName", itemName));
                    paramList.Add(new MySqlParameter("@unitPrice", unitPrice));
                    
                    int rowsAffected = DatabaseHandler.insertOrDeleteRow(query, paramList);

                    if(rowsAffected != 0)
                    {
                        MessageBox.Show("Item Added Successfully!");
                        itemSupplierCodeTxt.Text="";
                        itemIdTxt.Text = "";
                        itemNameTxt.Text = "";
                        unitPriceText.Text = "";
                        populateGrid();
                    }
                    else
                    {
                        MessageBox.Show("Error Occured! Please check if the Item already exists/Info entered!");

                    }


                }
                catch (Exception)
                {
                    MessageBox.Show("Error Occured! Please check if the Item already exists/Info entered!");
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

                string selectStatement2 = "SELECT raw_material.material_id as 'Material ID',  raw_material.name as 'Material Name', raw_material.unit_price as 'Unit Price', SUPPLIER.supplier_ID as 'Supplier ID', SUPPLIER.name as 'Supplier Name' FROM SUPPLIER INNER JOIN raw_material ON SUPPLIER.supplier_id = raw_material.supplier_id WHERE SUPPLIER.supplier_id like '%" + findById.Text + "%'";
                DatabaseHandler.populateViewwithNoParameters(selectStatement2, dataGridView2);
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

                string selectStatement2 = "SELECT raw_material.material_id as 'Material ID', raw_material.name as 'Material Name',  raw_material.unit_price as 'Unit Price', SUPPLIER.supplier_ID as 'Supplier ID', SUPPLIER.name as 'Supplier Name' FROM SUPPLIER INNER JOIN raw_material ON SUPPLIER.supplier_id = raw_material.supplier_id WHERE SUPPLIER.supplier_name like '%" + findByName.Text + "%'";
                DatabaseHandler.populateViewwithNoParameters(selectStatement2, dataGridView2);
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

       
    }
}
