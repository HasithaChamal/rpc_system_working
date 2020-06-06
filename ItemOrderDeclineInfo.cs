using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rpc_working
{
    public partial class ItemOrderDeclineInfo : Form
    {
        int selected;
        string clientEmail;
        public ItemOrderDeclineInfo()
        {
            InitializeComponent();
        }

        private void ItemOrderDeclineInfo_Load(object sender, EventArgs e)
        {
            itemOrder_lbl.Text = ItemDispatch.declineOrderNO;
            client_name_lbl.Text = ItemDispatch.declineOrderClient;
            otherInfo_txt.Enabled = false;
            clientEmail = DatabaseHandler.returnOneValueWithoutParams("SELECT email FROM client WHERE name='" + ItemDispatch.declineOrderClient + "'", "email");

        }

        private void reason_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected = reason_cmb.SelectedIndex;
            if (selected == 3)
            {
                otherInfo_txt.Enabled = true;
            }
            else 
            {
                otherInfo_txt.Enabled = false;
            }
        }

        private void submit_btn_Click(object sender, EventArgs e)
        {
            String content = "Null";
            selected = reason_cmb.SelectedIndex;
            if (selected == -1)
            {
                MessageBox.Show("Please Select a valied reason");
                return;
            }
            else if (selected == 1)
            {
                content = "The item order is not feasible to be produced under the current condition.";
                Email.sendIoDeclineMail(content, clientEmail, itemOrder_lbl.Text);
            }

            else if (selected == 2)
            {
                content = "The volume of the item order is not acceptable.";
                Email.sendIoDeclineMail(content, clientEmail, itemOrder_lbl.Text);
            }
            else if (selected == 3)
            {
                content = otherInfo_txt.Text;
                Email.sendIoDeclineMail(content, clientEmail, itemOrder_lbl.Text);
            }
          
            string update = "UPDATE itemorder set approval='Declined' where io_id=@ronum";
            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@ronum", ItemDispatch.declineOrderNO));

            int rowsAffected = DatabaseHandler.insertOrDeleteRow(update, paramList);

            if (rowsAffected != 0)
            {

                MessageBox.Show("Item Order Declined!");
                
            }
            else
            {
                MessageBox.Show("Error Occured! Please check Selection!");
            }
            this.Close();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
