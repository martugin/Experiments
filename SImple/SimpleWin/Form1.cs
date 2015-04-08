using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Access.Dao;

namespace SimpleWin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"WinForm");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var db = (new DBEngine()).OpenDatabase(@"D1.accdb");
            var rec = db.OpenRecordset("T");
            rec.MoveFirst();
            rec.Edit();
            rec.Fields["A"].Value = "a";
            rec.Update();
            rec.MoveNext();
            MessageBox.Show(rec.Fields["A"].Value.ToString());
            db.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D1.accdb");
            con.Open();
            var cmd = new OleDbCommand("SELECT * FROM T", con);
            var r = cmd.ExecuteReader();
            r.Read();
            MessageBox.Show(r["A"].ToString());
            r.Close();
            con.Close();
        }
    }
}
