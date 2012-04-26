using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using Microsoft.Office.Interop.Access.Dao;
using System.Globalization;

namespace HistorianProba
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var db = (new DBEngine()).OpenDatabase(@"C:\InfoTask\Points.accdb");
            var con = new OleDbConnection("Provider=OvHOleDbProv.OvHOleDbProv.1;Persist Security Info=True;User ID='';Data Source=DROP200;Location='';Mode=ReadWrite;Extended Properties=''");
            con.Open();
            var cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "select NAME, ID, DATA_TYPE from CFG_PT_NAME";
            cmd.CommandType = CommandType.Text;
            OleDbDataReader rec = cmd.ExecuteReader();
            db.Execute("DELETE * FROM PointsCodes");
            var res = db.OpenRecordset("PointsCodes");
            while (rec.Read())
            {
                res.AddNew();
                res.Fields["Code"].Value = rec["NAME"]; 
                res.Fields["Id"].Value = Convert.ToInt32(rec["ID"]);
                res.Fields["DataType"].Value = rec["DATA_TYPE"];
                res.Update();
            }
            rec.Close();
            res.Close();

            cmd.CommandText = "select ID, DESCRIPTION, ENGINEERING_UNITS, BOTTOM_SCALE, TOP_SCALE, LOW_LIMIT, HIGH_LIMIT from PT_ATTRIB";
            rec = cmd.ExecuteReader();
            db.Execute("DELETE * FROM PointsNames");
            res = db.OpenRecordset("PointsNames");
            while (rec.Read())
            {
                res.AddNew();
                res.Fields["Id"].Value = Convert.ToInt32(rec["ID"]);
                res.Fields["PointName"].Value = rec["DESCRIPTION"];
                res.Fields["Units"].Value = rec["ENGINEERING_UNITS"];
                if (!DBNull.Value.Equals(rec["BOTTOM_SCALE"]))
                    res.Fields["Min"].Value = Convert.ToDouble(rec["BOTTOM_SCALE"]);
                else res.Fields["Min"].Value = DBNull.Value; 
                if (!DBNull.Value.Equals(rec["TOP_SCALE"]))
                    res.Fields["Max"].Value = Convert.ToDouble(rec["TOP_SCALE"]);
                else res.Fields["Max"].Value = DBNull.Value; 
                res.Fields["Low"].Value = rec["LOW_LIMIT"];
                res.Fields["High"].Value = rec["HIGH_LIMIT"];
                res.Update();
            }
            rec.Close();
            res.Close();


            CultureInfo ci = CultureInfo.CreateSpecificCulture("en-US");
            var beg = "#" + Convert.ToDateTime("15.12.2011 10:00:00").ToString("MM/dd/yyyy HH:mm:ss.fff", ci) + "#";
            var en = "#" + Convert.ToDateTime("15.12.2011 11:00:00").ToString("MM/dd/yyyy HH:mm:ss.fff", ci) + "#";
            MessageBox.Show(beg + "\n" + en);

            cmd.CommandText = "select ID, TIMESTAMP, TIME_NSEC, SAMP_FLAGS, F_VALUE, RAW_VALUE, STS, SAMP_CREATE_SEQ  from PT_HF_HIST where (ID=20) and (TIMESTAMP >= " + beg + ") and (TIMESTAMP <= " + en + ")";         							
            rec = cmd.ExecuteReader();
            db.Execute("DELETE * FROM PointsValues");
            res = db.OpenRecordset("PointsValues");
            while (rec.Read())
            {
                res.AddNew();
                res.Fields["Id"].Value = Convert.ToInt32(rec["ID"]);
                res.Fields["Time"].Value = Convert.ToDateTime(rec["TIMESTAMP"]);
                if (!DBNull.Value.Equals(rec["TIME_NSEC"]))
                    res.Fields["MilSec"].Value = Convert.ToInt32(rec["TIME_NSEC"]);
                else res.Fields["MilSec"].Value = DBNull.Value;
                if (!DBNull.Value.Equals(rec["SAMP_FLAGS"]))
                    res.Fields["Flags"].Value = Convert.ToInt32(rec["SAMP_FLAGS"]);
                else res.Fields["Flags"].Value = DBNull.Value;
                if (!DBNull.Value.Equals(rec["F_VALUE"]))
                    res.Fields["Mean"].Value = Convert.ToDouble(rec["F_VALUE"]);
                else res.Fields["Mean"].Value = DBNull.Value;
                if (!DBNull.Value.Equals(rec["RAW_VALUE"]))
                    res.Fields["Raw"].Value = Convert.ToDouble(rec["RAW_VALUE"]);
                else res.Fields["Raw"].Value = DBNull.Value;
                if (!DBNull.Value.Equals(rec["STS"]))
                    res.Fields["Sts"].Value = Convert.ToInt32(rec["STS"]);
                else res.Fields["Sts"].Value = DBNull.Value;
                if (!DBNull.Value.Equals(rec["SAMP_CREATE_SEQ"]))
                    res.Fields["Seq"].Value = Convert.ToInt32(rec["SAMP_CREATE_SEQ"]);
                else res.Fields["Seq"].Value = DBNull.Value;
                res.Update();
            }
            rec.Close();
            res.Close();        
            con.Close();
            MessageBox.Show("Все!");
        }
    }
}
