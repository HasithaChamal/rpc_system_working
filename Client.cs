using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using DocumentFormat.OpenXml.Wordprocessing;

namespace rpc_working
{
    public partial class Client : UserControl
    {
        public Client()
        {
            InitializeComponent();
        }

        public void Client_Load(object sender, EventArgs e)
        {
            populateGrid();
            setId();
            if (GlobalLoginData.userRole == "StoreKeeper")
            {
                addBtnTxt.Enabled = false;
                removeBtn.Enabled = false;
            }
           
        }
        private void addBtnTxt_Click(object sender, EventArgs e)
        {
            string name = ClientNameTxt.Text;
            string id = identifierTxt.Text;
            string contactNum = contactNumTxt.Text;
            string email = emailTxt.Text;
            if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(id) || String.IsNullOrEmpty(contactNum) || String.IsNullOrEmpty(email))
            {
                MessageBox.Show("One or more fields empty!");
            }
            else if(contactNum.Length != 10)
            {
                MessageBox.Show("Invalied contact number!");
            }
            else if (!String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(id) && !String.IsNullOrEmpty(contactNum) && !String.IsNullOrEmpty(email))
            {
                try
                {
                    string query = "INSERT INTO CLIENT VALUES (@id,@name,@contactNum,@email)";
                    List<MySqlParameter> paramList = new List<MySqlParameter>();
                    paramList.Add(new MySqlParameter("@id", id));
                    paramList.Add(new MySqlParameter("@name", name));
                    paramList.Add(new MySqlParameter("@contactNum", contactNum));
                    paramList.Add(new MySqlParameter("@email", email));

                    int rowsAffected = DatabaseHandler.insertOrDeleteRow(query, paramList);

                    if (rowsAffected != 0)
                    {
                        MessageBox.Show("Supplier Added Successfully!");
                        ClientNameTxt.Text = "";
                        identifierTxt.Text = "";
                        contactNumTxt.Text = "";
                        emailTxt.Text = "";
                        populateGrid();
                    }
                    else
                    {
                        MessageBox.Show("Error Occured! Please check if the Client already exists!");
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Error Occured! Please check if the Client already exists!");
                }
            }
        }

        private void populateGrid()
        {
            string selectStatement = "SELECT name as 'Client Name', client_id as 'Client ID' , contact_no as 'Contact Number', email as 'Email' FROM CLIENT";
            DatabaseHandler.populateViewwithNoParameters(selectStatement, dataGridView1);
        }

        private void findById_TextChanged(object sender, EventArgs e)
        {

            try
            {
                string selectStatement = "SELECT name as 'Client Name', client_id as 'Client ID' , contact_no as 'Contact Number', email as 'Email' FROM CLIENT WHERE client_id like '%" + findById.Text + "%'";
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
                string selectStatement = "SELECT name as 'Client Name', client_id as 'Client ID' , contact_no as 'Contact Number', email as 'Email' FROM CLIENT WHERE name like '%" + findByName.Text + "%'";
                DatabaseHandler.populateViewwithNoParameters(selectStatement, dataGridView1);
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }
        }

        private void contactNumTxt_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(contactNumTxt.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                contactNumTxt.Text = contactNumTxt.Text.Remove(contactNumTxt.Text.Length - 1);
            }
        }

        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string query1 = "SELECT * FROM client WHERE client_id= '" + removeClient.Text.ToString() + "' ";
               
                int count1= DatabaseHandler.returnRowCountWithoutParams(query1);
                Console.WriteLine("Selected client " + removeClient.Text.ToString());
                Console.WriteLine("Row count" + count1);
                if (count1 == 0) 
                {
                    MessageBox.Show("Error! Client doesn't exist! ");
                    return;
                }
                string query = "DELETE FROM CLIENT WHERE client_id=@ClientCode";
                List<MySqlParameter> paramList = new List<MySqlParameter>();
                
                paramList.Add(new MySqlParameter("@clientCode", removeClient.Text.ToString()));
                
                int rowsAffected = DatabaseHandler.insertOrDeleteRow(query, paramList);
                paramList.Clear();

                if (rowsAffected != 0)
                {
                    MessageBox.Show("Client Removed Successfully!");
                    populateGrid();
                }
                else
                {
                    MessageBox.Show("Error! Client has already intracted with the system! Cannot remove!");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error! Client has already intracted with the system! Cannot remove!");
            }
        }


        private void setId()
        {
            string lastId = DatabaseHandler.returnOneValueWithoutParams("SELECT * FROM client", "client_id");
            string nextId;
            if (lastId == "Null Data!")
            {
                nextId = "#1001";
            }
            else
            {
                var prefix = System.Text.RegularExpressions.Regex.Match(lastId, "^\\#+").Value;
                var number = System.Text.RegularExpressions.Regex.Replace(lastId, "^\\#+", "");
                var i = int.Parse(number) + 1;
                nextId = (prefix + i.ToString(new string('0', number.Length))).ToString();
            }

            identifierTxt.Text = nextId;


        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            ClientNameTxt.Text = "";
            identifierTxt.Text = "";
            contactNumTxt.Text = "";
            emailTxt.Text = "";
        }
    }
}
