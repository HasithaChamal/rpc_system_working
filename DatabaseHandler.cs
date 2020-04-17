using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Data;

namespace rpc_working
{
    class DatabaseHandler
    {
        public static string MySQLConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=rpc";
        public static MySqlConnection con = new MySqlConnection(MySQLConnectionString);

        //Get 1 value as result from query
        public static string returnOneValue(string query, List<MySqlParameter> paramsCollection, string column)
        {
            string data = null;
            MySqlConnection databaseConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.Parameters.Clear();
            commandDatabase.Parameters.AddRange(paramsCollection.ToArray<MySqlParameter>());
            commandDatabase.CommandTimeout = 60;

            try
            {
                databaseConnection.Open();
                Console.WriteLine("Connection Made");
                MySqlDataReader myReader = commandDatabase.ExecuteReader();

                Console.WriteLine("Reader got data");

                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        data = myReader.GetString(column);
                    }
                }
                else
                {
                    data = "Null Data!";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                databaseConnection.Close();
            }

            return data;
        }

        //Get 1 value as result from query
        public static string returnOneValueWithoutParams(string query, string column)
        {
            string data = null;
            MySqlConnection databaseConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            
            try
            {
                databaseConnection.Open();
                Console.WriteLine("Connection Made");
                MySqlDataReader myReader = commandDatabase.ExecuteReader();

                Console.WriteLine("Reader got data");

                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        data = myReader.GetString(column);
                    }
                }
                else
                {
                    data = "Null Data!";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                databaseConnection.Close();
            }

            return data;
        }

        //Get result row count
        public static int returnRowCount(string query, List<MySqlParameter> paramsCollection)
        {
            int count = 0;
            MySqlConnection databaseConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.Parameters.Clear();
            commandDatabase.Parameters.AddRange(paramsCollection.ToArray<MySqlParameter>());
            commandDatabase.CommandTimeout = 60;

            try
            {
                databaseConnection.Open();
                Console.WriteLine("Connection Made");
                MySqlDataReader myReader = commandDatabase.ExecuteReader();

                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        count++;
                    }
                }
                else
                {
                    count = 0;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                databaseConnection.Close();
            }

            return count;
        }

        //Get Row Count without parameters
        public static int returnRowCountWithoutParams(string query)
        {
            int count = 0;
            MySqlConnection databaseConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
           

            try
            {
                databaseConnection.Open();
                Console.WriteLine("Connection Made");
                MySqlDataReader myReader = commandDatabase.ExecuteReader();

                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        count++;
                    }
                }
                else
                {
                    count = 0;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                databaseConnection.Close();
            }

            return count;
        }




        //Insert data 
        public static int insertOrDeleteRow(string query, List<MySqlParameter> paramsCollection)
        {
            MySqlConnection databaseConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.Parameters.Clear();
            commandDatabase.Parameters.AddRange(paramsCollection.ToArray<MySqlParameter>());
            commandDatabase.CommandTimeout = 60;
            int rowsAffected = 0;
            try
            {
                databaseConnection.Open();
                Console.WriteLine("Connection Made");
                rowsAffected = commandDatabase.ExecuteNonQuery();
                Console.WriteLine("Rows Affected: " + rowsAffected);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                databaseConnection.Close();
                
            }
            return rowsAffected;
        }

        //Populate DataViews
        public static void populateViewwithNoParameters(string query, DataGridView dataGridView)
        {
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView.ColumnHeadersDefaultCellStyle.Font =
                new Font(dataGridView.Font, FontStyle.Bold);
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var dataAdapter = new MySqlDataAdapter(query, MySQLConnectionString);
            var commandBuilder = new MySqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView.ReadOnly = true;
            dataGridView.DataSource = ds.Tables[0];

            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        public static void populateViewwithParameters(string query, List<MySqlParameter> paramsCollection, DataGridView dataGridView)
        {
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView.ColumnHeadersDefaultCellStyle.Font =
                new Font(dataGridView.Font, FontStyle.Bold);
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var dataAdapter = new MySqlDataAdapter(query, MySQLConnectionString);
            var commandBuilder = new MySqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView.ReadOnly = true;
            dataGridView.DataSource = ds.Tables[0];

            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

     
        public static void populateCombobox(string query, ComboBox comboBox)
        {
            
            var dataAdapter = new MySqlDataAdapter(query, MySQLConnectionString);
            var commandBuilder = new MySqlCommandBuilder(dataAdapter);
            var dt = new DataTable();
            dt.Columns.Add("Supplier Code");
            dt.Columns.Add("Supplier");
            dataAdapter.Fill(dt);

            comboBox.DataSource = dt;
            comboBox.DisplayMember = "Supplier";
            comboBox.ValueMember = "Supplier Code";

        }

        //Populate ComboBox
        public static void populateDispatchCombobox(string query, ComboBox comboBox)
        {
            Console.WriteLine("Inside DH");
            Console.WriteLine(query);
            Console.WriteLine(comboBox);
            var dataAdapter = new MySqlDataAdapter(query, MySQLConnectionString);
            var commandBuilder = new MySqlCommandBuilder(dataAdapter);
            var dt = new DataTable();
            dt.Columns.Add("Client Code");
            dt.Columns.Add("Client Name");
            dataAdapter.Fill(dt);

            comboBox.DataSource = dt;
            comboBox.DisplayMember = "Client Name";
            comboBox.ValueMember = "Client Code";

        }

        //Populate GridView with binding
        public static void populateGridViewWithBinding(string query, DataGridView dataGridView)
        {
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView.ColumnHeadersDefaultCellStyle.Font =
                new Font(dataGridView.Font, FontStyle.Bold);
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var dataAdapter = new MySqlDataAdapter(query, MySQLConnectionString);
            var commandBuilder = new MySqlCommandBuilder(dataAdapter);
            var dt = new DataTable();
            try { dataAdapter.Fill(dt); }catch(Exception err)
            {
                MessageBox.Show(err.ToString());
                MessageBox.Show(query);
            }

            dataGridView.DataSource = dt;

            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        public static void populatebomDataGridView(string query, DataGridView dataGridView, string quantity )
        {

            var dataAdapter = new MySqlDataAdapter(query, MySQLConnectionString);
            var commandBuilder = new MySqlCommandBuilder(dataAdapter);
            var dt = new DataTable();
      
           

            dataAdapter.Fill(dt);
            int noOfRows = dt.Rows.Count;
            Console.WriteLine("no of rows"+noOfRows);
            for (int i=0; i<noOfRows; i++)
            {
                string materialId = dt.Rows[i][0].ToString();
                string qty = dt.Rows[i][1].ToString();
                string materialName = returnOneValueWithoutParams("SELECT * FROM raw_material WHERE material_id='" + materialId + "'", "name");
                string materialPrice = returnOneValueWithoutParams("SELECT * FROM raw_material WHERE material_id='" + materialId + "'", "unit_price");

                int val = 0;
                int count = dataGridView.DisplayedRowCount(true);
                Console.WriteLine("BOM no of rows1" + dataGridView.DisplayedRowCount(true));
                for (int row = 0; row < count - 1; row++)
                {

                    string ExsitingMaterialid = dataGridView.Rows[row].Cells[0].Value.ToString();
                    string ExsistingQty = dataGridView.Rows[row].Cells[1].Value.ToString();

                    if (ExsitingMaterialid== materialId)
                    {
                        dataGridView.Rows[row].Cells[1].Value = (Int32.Parse(ExsistingQty) + (Int32.Parse(qty)* Int32.Parse(quantity))).ToString();
                        val++;
                    }

                }

                if (val == 0)
                {
                    dataGridView.Rows.Add();
                    dataGridView.Rows[count - 1].Cells[0].Value = materialId;
                    dataGridView.Rows[count - 1].Cells[1].Value = (Int32.Parse(qty) * Int32.Parse(quantity)).ToString();
                    dataGridView.Rows[count - 1].Cells[2].Value = materialName;
                    dataGridView.Rows[count - 1].Cells[3].Value = materialPrice;

                }
                Console.WriteLine("BOM no of rows2" + dataGridView.DisplayedRowCount(true));

            }



        }


    }
    }
