﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using MySql.Data.MySqlClient;

namespace rpc_working.CrystalReportsViewer
{
    public partial class materialUseageVeiwer : Form
    {
        DataTable materialsumtbl = new DataTable();
        DataTable materialtbl = new DataTable();

        public materialUseageVeiwer()
        {
            InitializeComponent();
        }

        private void materialUseageVeiwer_Load(object sender, EventArgs e)
        {  
            //set start date parameter
            
            ParameterFields From = new ParameterFields();
            ParameterField PID = new ParameterField();
            PID.Name = "FromDate";
            ParameterDiscreteValue val = new ParameterDiscreteValue();
            val.Value = Reports.startDate;
            PID.CurrentValues.Add(val);
            From.Add(PID);
            materialUseagerptviewer.ParameterFieldInfo = From;

            //set end date parameter
            ParameterField PID1 = new ParameterField();
            PID1.Name = "ToDate";
            ParameterDiscreteValue val1 = new ParameterDiscreteValue();
            val1.Value = Reports.endDate;
            PID1.CurrentValues.Add(val1);
            From.Add(PID1);
            materialUseagerptviewer.ParameterFieldInfo = From;


            //create data table 
            
            DataTable idtbl = new DataTable();
            DataTable materialtblTemp = new DataTable();
            materialtbl.Columns.Add("id");
            materialtbl.Columns.Add("bom_id");
            materialtbl.Columns.Add("creation_time");
            materialtbl.Columns.Add("material_id");
            materialtbl.Columns.Add("qty");
            materialtbl.Columns.Add("name");

            //create dispatch id table
            try
            {
                String query = "SELECT id , bom_id, creation_time  FROM material_dispatch where  released='yes' AND creation_time between '" + Reports.startDate + "' and '" + Reports.endDate + "'  ";
                var dataAdapter = new MySqlDataAdapter(query, DatabaseHandler.MySQLConnectionString);
                var commandBuilder = new MySqlCommandBuilder(dataAdapter);
                dataAdapter.Fill(idtbl);
                if (idtbl.Rows.Count==0)
                {
                    MessageBox.Show("NO Entries available");
                    this.Close();
                    return;
                     
                }

            }
            catch (Exception er)
            {
                MessageBox.Show("Error Occured! ");
                Console.WriteLine(er.Message);
                return;
            }

            
            int noOfRows = idtbl.Rows.Count;

            for (int i = 0; i < noOfRows; i++)
            {

                try
                {
                    String query = "SELECT bom_item.bom_id ,bom_item.material_id ,bom_item.qty , raw_material.name FROM bom_item INNER JOIN raw_material ON bom_item.material_id = raw_material.material_id  where bom_item.bom_id= '" + idtbl.Rows[i][1].ToString() + "' ";
                    var dataAdapter = new MySqlDataAdapter(query, DatabaseHandler.MySQLConnectionString);
                    var commandBuilder = new MySqlCommandBuilder(dataAdapter);
                    dataAdapter.Fill(materialtblTemp);
                    Console.WriteLine(materialtblTemp.Rows.Count);
                    if (materialtblTemp.Rows.Count == 0)
                    {
                        MessageBox.Show("Error Occured! Please check input details!");
                        return;
                    }

                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
            }
            int noOfRows2 = materialtblTemp.Rows.Count;
            for (int i = 0; i < noOfRows2; i++)
            {
                DataRow rw = materialtbl.NewRow();
                rw["bom_id"] = materialtblTemp.Rows[i][0];
                rw["material_id"] = materialtblTemp.Rows[i][1];
                rw["qty"] = materialtblTemp.Rows[i][2];
                rw["name"] = materialtblTemp.Rows[i][3];
                for (int j = 0; j < noOfRows; j++)
                {
                    if (materialtblTemp.Rows[i][0].ToString() == idtbl.Rows[j][1].ToString())
                    {
                        rw["id"] = idtbl.Rows[j][0];
                        rw["creation_time"] = idtbl.Rows[j][2];
                    }

                }
                materialtbl.Rows.Add(rw);
            }
            Console.WriteLine("material tbl rows" + materialtbl.Rows.Count);

            int noOfRows3 = materialtbl.Rows.Count;
            
            materialsumtbl.Columns.Add("material_id");
            materialsumtbl.Columns.Add("name");
            materialsumtbl.Columns.Add("qty");
            int noOfRows4 = 0;
            for (int i = 0; i < noOfRows3; i++)
            {
                noOfRows4 = materialsumtbl.Rows.Count;
                int count = 0;
                for (int j = 0; j < noOfRows4; j++)
                {
                    if (materialtbl.Rows[i][3].ToString() == materialsumtbl.Rows[j][0].ToString())
                    {
                        materialsumtbl.Rows[j][2] = Convert.ToDouble(materialtbl.Rows[i][4].ToString()) + Convert.ToDouble(materialsumtbl.Rows[j][2].ToString());
                        count++;
                    }
                }
                if (count == 0)
                {
                    DataRow rw = materialsumtbl.NewRow();
                    rw["material_id"] = materialtbl.Rows[i][3];
                    rw["qty"] = materialtbl.Rows[i][4];
                    rw["name"] = materialtbl.Rows[i][5];
                    materialsumtbl.Rows.Add(rw);
                }
            }

            if (Reports.summarize == true)
            {
                CrystalReports.materialUseageSummarizedReport materialsumrpt = new CrystalReports.materialUseageSummarizedReport();

                materialsumrpt.Database.Tables["materialsumtbl"].SetDataSource(materialsumtbl);
                materialUseagerptviewer.ReportSource = null;
                materialUseagerptviewer.ReportSource = materialsumrpt;

            }
            else
            {
                CrystalReports.MaterialUseage materialrpt = new CrystalReports.MaterialUseage();
                materialrpt.Database.Tables["materialtbl"].SetDataSource(materialtbl);


                materialUseagerptviewer.ReportSource = null;
                materialUseagerptviewer.ReportSource = materialrpt;

            }



        }

        private void export_btn_Click(object sender, EventArgs e)
        {
            if (Reports.summarize == true)
            {
                materialsumtbl.ExportToExcel();
            }
            else
            {
                materialtbl.ExportToExcel();
            }
        }
    }
}
