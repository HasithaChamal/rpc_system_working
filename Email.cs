﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace rpc_working
{
    class Email
    {

        public static void sendMail(String subject)
        {
            DataTable mailList = new DataTable();
            String query = "SELECT email from user where role !='StoreKeeper' ";
            var dataAdapter = new MySqlDataAdapter(query, DatabaseHandler.MySQLConnectionString);
            var commandBuilder = new MySqlCommandBuilder(dataAdapter);
            dataAdapter.Fill(mailList);
            Console.WriteLine(mailList.Rows.Count);
            try
            {
                SmtpClient clientDetails = new SmtpClient();
                clientDetails.Port = 587;
                clientDetails.Host = "smtp.gmail.com";
                clientDetails.EnableSsl = true;
                clientDetails.DeliveryMethod = SmtpDeliveryMethod.Network;
                clientDetails.UseDefaultCredentials = false;
                clientDetails.Credentials = new NetworkCredential("rathanayakeh@gmail.com", "evoLove894");

                MailMessage mailDetails = new MailMessage();
                mailDetails.From = new MailAddress("rathanayakeh@gmail.com");
                for (int i = 0; i < mailList.Rows.Count; i++) 
                {
                    mailDetails.To.Add(mailList.Rows[i][0].ToString());
                }
               // mailDetails.To.Add("hasitharathnayake97@gmail.com");
                mailDetails.Subject = subject;
                mailDetails.Body = "Your Workflow inbox in the RPC system , contains the above work item: \n\n Open the 'RPC' system in order to process the work item. \n\n If you have any problems logging on, contact your system adminstrator \n\n";


                clientDetails.Send(mailDetails);
                MessageBox.Show("Request Mail sent");
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            
           }
        }
    }
}
