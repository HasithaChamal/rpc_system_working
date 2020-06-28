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
    public partial class Purchasing : UserControl
    {
        public static string selectedSupplier = null;
        DataRowView selectedRow;
        int globalLastPo;
        public static string selectedPONo= null;

        public Purchasing()
        {
            InitializeComponent();
        }

        public void Purchasing_Load(object sender, EventArgs e)
        {
            if (GlobalLoginData.userRole == "StoreKeeper")
            {
                approveBtn.Enabled = false;
                declineBtn.Enabled = false;
            }
            setPoNum();
            populateCombo();
            try
            {
                supplierComboBox.SelectedIndex = 0;
            }
            catch(Exception)
            {

            }
            selectedRow = supplierComboBox.SelectedItem as DataRowView;
            if (selectedRow != null)
            {
                selectedSupplier = selectedRow.Row["Supplier Code"] as string;
            }

            //Populate dataViewGrid1 (Items by that supplier)
            //populateGrid();
            dataViewDesign(dataGridView4);

            //Populate Other Grids
            populateNonComboGrids();
        }

        public void populateCombo()
        {
            string selectStatement = "SELECT supplier_id as 'Supplier Code', name as 'Supplier' FROM SUPPLIER";
            DatabaseHandler.populateCombobox(selectStatement, supplierComboBox);
        }

        private void supplierComboBox_DropDown(object sender, EventArgs e)
        {
            populateCombo();
        }

        private void supplierComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            selectedRow = supplierComboBox.SelectedItem as DataRowView;
            if(selectedRow != null){
                selectedSupplier = selectedRow.Row["Supplier Code"] as string;
            }
            populateGrid();
        }

        private void populateGrid()
        {
            string selectStatement = "SELECT supplier_material.material_id as 'Material Code', raw_material.name as 'Material Name', raw_material.qty as 'Available Quantity', supplier_material.unit_price as 'Unit Price' FROM supplier_material INNER JOIN raw_material ON raw_material.material_id = supplier_material.material_id WHERE supplier_material.supplier_id = '" + selectedSupplier+"'";
            DatabaseHandler.populateViewwithNoParameters(selectStatement, dataGridView1);

            populateNonComboGrids();
        }

        private void populateNonComboGrids()
        {
            string approvedSelect = "SELECT purchaseorder.po_id as 'Order #', supplier.name as 'Supplier', purchaseorder.creation_time as 'Order Creation Time', purchaseorder.postedUser as 'Posted By' FROM purchaseorder INNER JOIN supplier ON purchaseorder.supplier_id = supplier.supplier_id WHERE purchaseorder.approval = 'Approved'";
            DatabaseHandler.populateGridViewWithBinding(approvedSelect, dataGridView2);

            string pendingSelect = "SELECT purchaseorder.po_id as 'Order #', supplier.name as 'Supplier', purchaseorder.creation_time as 'Order Creation Time', purchaseorder.postedUser as 'Posted By' FROM purchaseorder INNER JOIN supplier ON purchaseorder.supplier_id = supplier.supplier_id WHERE purchaseorder.approval = 'Pending'";
            DatabaseHandler.populateGridViewWithBinding(pendingSelect, dataGridView3);

        }

        private void addItemBtn_Click(object sender, EventArgs e)
        {
            string itemCode = addItemCodeTxt.Text;
            string itemQty = addItemQty.Text;
           
            int i = dataGridView4.Rows.Count;
            for (int row = 0; row < i - 1; row++)
            {
                if (dataGridView4.Rows[row].Cells[0].Value.ToString() == itemCode)
                {
                    MessageBox.Show("Item already entered !!!");
                    return;
                }

            }
            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@itemCode", itemCode));
            int returnedRowCount = DatabaseHandler.returnRowCount("SELECT * FROM raw_material WHERE material_id = @itemCode", paramList);
            int returnedRowCount2 = DatabaseHandler.returnRowCountWithoutParams("SELECT * FROM supplier_material WHERE material_id='" + itemCode + "' AND supplier_id='" + selectedSupplier + "'");
            if (returnedRowCount != 0 && returnedRowCount2 != 0)
            {
                //Get Item Name from DB
                paramList.Clear();
                paramList.Add(new MySqlParameter("@itemCode", itemCode));
                string itemName = DatabaseHandler.returnOneValue("SELECT name as 'Material Name' from raw_material where material_id=@itemCode", paramList, "Material Name");
                String unitPrice = DatabaseHandler.returnOneValueWithoutParams("SELECT unit_price as 'Material Price' from supplier_material where material_id='" + itemCode + "' AND supplier_id='" + selectedSupplier + "'", "Material Price");

                //Add to dataViewGrid4
                int index = dataGridView4.Rows.Count;
                dataGridView4.Rows.Add(itemCode, itemName, itemQty, unitPrice);
                Console.WriteLine("In Add Btn: Current Index: " + index);
               
                supplierComboBox.Enabled = false;
            }
            else if (returnedRowCount == 0)
            {
                MessageBox.Show("Invalid Item Code!");
            }
            else {
                MessageBox.Show("Selected supplier doesn't offer that item!");
            }
            Console.WriteLine("In Add Btn: Current Index2: " + dataGridView4.DisplayedRowCount(true));

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
                string query = "insert into purchaseorder(supplier_id ,approval ,postedUser) values (@supplierCode,'Pending',@user);";
                List<MySqlParameter> paramList = new List<MySqlParameter>();
                paramList.Clear();
                paramList.Add(new MySqlParameter("@supplierCode", selectedSupplier));
                paramList.Add(new MySqlParameter("@user", GlobalLoginData.username));

                int rowsAffected = DatabaseHandler.insertOrDeleteRow(query, paramList);

                if (rowsAffected != 0)
                {
                    MessageBox.Show("Purchase Order Created Successfully!");
                    supplierComboBox.Enabled = true;
                    

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
                string lastPo = DatabaseHandler.returnOneValueWithoutParams("SELECT * FROM purchaseorder", "po_id");

                itemid = dataGridView4.Rows[row].Cells[0].Value.ToString();
                qty = dataGridView4.Rows[row].Cells[2].Value.ToString();
                Console.WriteLine(itemid + "   " + qty);
                try
                {
                    string query = "INSERT INTO purchaseorder_item VALUES (@itemCode, @poNum, @qty)";
                    List<MySqlParameter> paramList = new List<MySqlParameter>();
                    paramList.Add(new MySqlParameter("@poNum", lastPo));
                    paramList.Add(new MySqlParameter("@itemCode", itemid));
                    paramList.Add(new MySqlParameter("@qty", qty));

                    int rowsAffected = DatabaseHandler.insertOrDeleteRow(query, paramList);

                    if (rowsAffected != 0)
                    {
                        
                        //populateGrid();
                    }
                    else
                    {
                        MessageBox.Show("Error Occured! PO-material Link Broken!");
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Error Occured!");
                }
                finally
                {
                    populateGrid();
                }

                
            }
            Email.sendMail("RPC SYSTEM: Please approve the purchase order requisition, ID= "+ poNumLbl.Text);
            setPoNum();
            addItemCodeTxt.Text = "";
            addItemQty.Text = "";
            dataGridView4.Rows.Clear();
            Console.WriteLine("Current Row Count: " + dataGridView4.RowCount);
            Console.WriteLine("Current Displayed Row Count: " + dataGridView4.DisplayedRowCount(true));

        }

        private void setPoNum()
        {
            string lastPo = DatabaseHandler.returnOneValueWithoutParams("SELECT * FROM purchaseorder", "po_id");
            int lastPoNum;
            if(lastPo == "Null Data!")
            {
                lastPoNum = 0;
            }
            else
            {
                lastPoNum = Int32.Parse(lastPo);
            }
            
            poNumLbl.Text = (lastPoNum+1).ToString();
            globalLastPo = lastPoNum;
        }

        private void dataGridView3_Click(object sender, EventArgs e)
        {
            try
            {
                string val = dataGridView3.SelectedRows[0].Cells["Order #"].Value.ToString();

                string select = "SELECT purchaseorder_item.po_id as 'Order #', purchaseorder_item.material_id as 'Material Code', raw_material.name as 'Material Name', purchaseorder_item.qty as 'Qty' FROM purchaseorder_item INNER JOIN raw_material ON purchaseorder_item.material_id = raw_material.material_id WHERE purchaseorder_item.po_id = '" + val + "'";
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

                string select = "SELECT purchaseorder_item.po_id as 'Order #', purchaseorder_item.material_id as 'Material Code', raw_material.name as 'Material Name', purchaseorder_item.qty as 'Qty' FROM purchaseorder_item INNER JOIN raw_material ON purchaseorder_item.material_id = raw_material.material_id WHERE purchaseorder_item.po_id = '" + val + "'";
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
            string update = "UPDATE purchaseorder set approval='Approved' where po_id=@ponum";
            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@ponum", val));

            int rowsAffected = DatabaseHandler.insertOrDeleteRow(update, paramList);

            if (rowsAffected != 0)
            {
                MessageBox.Show("Purchase Order Confirmed!");
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
            string val = null;
            try
            {
                 val = dataGridView3.SelectedRows[0].Cells["Order #"].Value.ToString();
            }
            catch 
            {
                MessageBox.Show("Error Occured! Please check Selection!");
                return;
            }
            string update = "UPDATE purchaseorder set approval='Declined' where po_id=@ponum";
            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@poNum", val));

            int rowsAffected = DatabaseHandler.insertOrDeleteRow(update, paramList);

            if (rowsAffected != 0)
            {
                MessageBox.Show("Purchase Order Declined!");
                populateGrid();
            }
            else
            {
                MessageBox.Show("Error Occured! Please check Selection!");
            }

            populateNonComboGrids();
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            addItemCodeTxt.Clear();
            addItemQty.Clear();
            dataGridView4.DataSource = null;
            dataGridView4.Rows.Clear();
            setPoNum();
            supplierComboBox.Enabled = true;
        }

        private void print_btn_Click(object sender, EventArgs e)
        {
            try
            {
                selectedPONo = dataGridView2.SelectedRows[0].Cells["Order #"].Value.ToString();
            }
            catch 
            {
                MessageBox.Show("Please select an Purchase Order");
                return;
            }
            if (selectedPONo == null)
            {
                MessageBox.Show("Please select an Purchase Order");
                return;
            }
            else 
            {
                CrystalReportsViewer.PurchaseOrderReportViewer poview = new CrystalReportsViewer.PurchaseOrderReportViewer();
                poview.ShowDialog();
            }
           
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            dataGridView5.DataSource = null;
        }
    }
}
