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
    public partial class Users : UserControl
    {
        public Users()
        {
            InitializeComponent();
        }

        public void Users_Load(object sender, EventArgs e)
        {
            populateGrid();

            if(GlobalLoginData.userRole != "Owner")
            {
                usernameTxt.Enabled = false;
                passwordTxt.Enabled = false;
                retypePasswordTxt.Enabled = false;
                nameTxt.Enabled = false;
                privilageBox.Enabled = false;
                addBtn.Enabled = false;
                removeBtn.Enabled = false;
                removeUsername.Enabled = false;
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            string memberName = nameTxt.Text;
            string username = usernameTxt.Text;
            string password = passwordTxt.Text;
            string retypePassword = retypePasswordTxt.Text;
            string email = emailText.Text;
            string userRole = null;

            if (ownerRadio.Checked)
            {
                userRole = "Owner";
            }
            else if (accountantRadio.Checked)
            {
                userRole = "Accountant";
            }
            else if (storekeeperRadio.Checked) {
                userRole = "StoreKeeper";
            }
            if (String.IsNullOrEmpty(userRole) || String.IsNullOrEmpty(memberName) || String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password) || String.IsNullOrEmpty(email) || !(ownerRadio.Checked || accountantRadio.Checked || storekeeperRadio.Checked))
            {
                MessageBox.Show("One or more fields are Empty!");
            }
           else if ((string.Compare(password, retypePassword)) != 0)
            {
                MessageBox.Show("Password doesn't match!");
            }
           
            else if (!String.IsNullOrEmpty(userRole) && !String.IsNullOrEmpty(memberName) && !String.IsNullOrEmpty(username) && !String.IsNullOrEmpty(password) && ((string.Compare(password, retypePassword)) == 0) && !String.IsNullOrEmpty(email))
            {
                try
                {
                    string query = "INSERT INTO USER VALUES (@memberName,@username,@password,@role,@email)";
                    List<MySqlParameter> paramList = new List<MySqlParameter>();
                    paramList.Add(new MySqlParameter("@memberName", memberName));
                    paramList.Add(new MySqlParameter("@username", username));
                    paramList.Add(new MySqlParameter("@password", password));
                    paramList.Add(new MySqlParameter("@role", userRole));
                    paramList.Add(new MySqlParameter("@email", email));

                    int rowsAffected = DatabaseHandler.insertOrDeleteRow(query, paramList);
                    if (rowsAffected != 0)
                    {
                        MessageBox.Show("User Added Successfully!");
                         populateGrid();
                    }
                    else
                    {
                        MessageBox.Show("Error Occured! Please check if the user already exists!");
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Error Occured! Please check if the user already exists!");
                }
            }



        }

        

        private void removeBtn_Click(object sender, EventArgs e)
        {
            if(removeUsername.Text == GlobalLoginData.username)
            {
                MessageBox.Show("Sorry, you cannot remove the account in use.");
            }
            else
            {
                try
                {
                    string query = "DELETE FROM USER WHERE username=@username";
                    List<MySqlParameter> paramList = new List<MySqlParameter>();
                    paramList.Clear();
                    paramList.Add(new MySqlParameter("@username", removeUsername.Text));
                    int rowsAffected = DatabaseHandler.insertOrDeleteRow(query, paramList);

                    if(rowsAffected != 0)
                    {
                        MessageBox.Show("User Removed Successfully!");
                        populateGrid();
                    }
                    else
                    {
                        MessageBox.Show("No such user found!");
                    }
                    
                }
                catch (Exception)
                {
                    MessageBox.Show("No such user found!");
                }
            
            }
        }

        private void populateGrid()
        {
            string selectStatement = "SELECT member_name as 'Member Name', username as 'Member ID' , role as 'User Role' , email as 'Email' FROM user";
            DatabaseHandler.populateViewwithNoParameters(selectStatement, dataGridView1);
        }

        private void findByName_Click(object sender, EventArgs e)
        {
            try
            {
                string selectStatement = "SELECT member_name as 'Member Name', username as 'Username' , role as 'User Role', email as 'Email' FROM user WHERE member_name like '%" + findMemName.Text + "%'";
                DatabaseHandler.populateViewwithNoParameters(selectStatement, dataGridView1);
            }
            catch(Exception err)
            {
                Console.WriteLine(err);
            }
           
        }

        private void findById_Click(object sender, EventArgs e)
        {
            try
            {
                string selectStatement = "SELECT member_name as 'Member Name', username as 'Username' , role as 'User Role' FROM user WHERE username like '%" + findMemId.Text + "%'";
                DatabaseHandler.populateViewwithNoParameters(selectStatement, dataGridView1);
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }
        }

        private void findMemName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string selectStatement = "SELECT member_name as 'Member Name', username as 'Username' , role as 'User Role' FROM user WHERE member_name like '%" + findMemName.Text + "%'";
                DatabaseHandler.populateViewwithNoParameters(selectStatement, dataGridView1);
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }
        }

        private void findMemId_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string selectStatement = "SELECT member_name as 'Member Name', username as 'Username' , role as 'User Role' FROM user WHERE username like '%" + findMemId.Text + "%'";
                DatabaseHandler.populateViewwithNoParameters(selectStatement, dataGridView1);
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            nameTxt.Text = "";
            passwordTxt.Text = "";
            retypePasswordTxt.Text = "";
            usernameTxt.Text = "";
            emailText.Text = "";
        }
    }
}
