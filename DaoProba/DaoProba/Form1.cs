using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Access.Dao;


namespace DaoProba
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var en = new DBEngine();
            var d = DateTime.Now;
            for (int i = 1; i <= 100; i++)
            {
                var db = en.OpenDatabase("Clon.accdb");
                db.Close();
            }
            MessageBox.Show(DateTime.Now.Subtract(d).ToString());
            GC.Collect();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var en = new DBEngine();
            double t = 0, t2 = 0;
            for (int i = 1; i <= 100; i++)
            {
                var d = DateTime.Now;
                var db = en.OpenDatabase("Clon.accdb");
                t += DateTime.Now.Subtract(d).TotalMilliseconds;
                d = DateTime.Now;
                var rec = db.OpenRecordset("T");
                rec.AddNew();
                rec.Fields["a"].Value = "aaa";
                rec.Fields["b"].Value = i.ToString();
                rec.Update();
                rec.Close();
                t2 += DateTime.Now.Subtract(d).TotalMilliseconds;
                d = DateTime.Now;
                db.Close();
                t += DateTime.Now.Subtract(d).TotalMilliseconds;
            }
            MessageBox.Show(t + "  " + t2);
            GC.Collect();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var en = new DBEngine();
            var db = en.OpenDatabase("Clon.accdb");
            var d = DateTime.Now;
            for (int i = 1; i <= 100; i++)
            {
                var rec = db.OpenRecordset("T");
                rec.AddNew();
                rec.Fields["a"].Value = "aaa";
                rec.Fields["b"].Value = i.ToString();
                rec.Update();
                rec.Close();
            }
            db.Close();
            MessageBox.Show(DateTime.Now.Subtract(d).TotalMilliseconds.ToString());
            GC.Collect();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var en = new DBEngine();
            double t = 0, t2 = 0;
            for (int i = 1; i <= 5; i++)
            {
                var d = DateTime.Now;
                var db = en.OpenDatabase("Clon.accdb");
                t += DateTime.Now.Subtract(d).TotalMilliseconds;
                d = DateTime.Now;
                db.Execute("UPDATE T SET b=" + i);
                t2 += DateTime.Now.Subtract(d).TotalMilliseconds;
                d = DateTime.Now;
                db.Close();
                t += DateTime.Now.Subtract(d).TotalMilliseconds;
            }
            MessageBox.Show(t + "  " + t2);
            GC.Collect();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var en = new DBEngine();
            var d = DateTime.Now;
            double t = 0, t2 = 0;
            var db = en.OpenDatabase("Clon.accdb");
            for (int i = 1; i <= 5; i++)
            {
                d = DateTime.Now;
                db.Execute("UPDATE T SET b=" + i);
                t2 += DateTime.Now.Subtract(d).TotalMilliseconds;
            }
            db.Close();
            MessageBox.Show(t2.ToString());
            GC.Collect();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var d = DateTime.Now;
            for (int i = 1; i <= 100; i++)
            {
                var con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Clon.accdb");
                con.Open();
                con.Close();
            }
            MessageBox.Show(DateTime.Now.Subtract(d).ToString());
            GC.Collect();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var d = DateTime.Now;
            for (int i = 1; i <= 100; i++)
            {
                var con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Clon.accdb");
                con.Open();
                var cmd = new OleDbCommand("SELECT * FROM SysTabl", con);
                var r = cmd.ExecuteReader();
                var cmdo = new OleDbCommand("SELECT * FROM T", con);
                var ro = cmdo.ExecuteReader();
                while (ro.Read()) ;
                ro.Close();
                r.Close();
                con.Close();
            }
            MessageBox.Show(DateTime.Now.Subtract(d).ToString());
            GC.Collect();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var d = DateTime.Now;
            var con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Clon.accdb");
            con.Open();
            for (int i = 1; i <= 100; i++)
            {
                var cmd = new OleDbCommand("SELECT * FROM SysTabl", con);
                var r = cmd.ExecuteReader();
                var cmdo = new OleDbCommand("SELECT * FROM T", con);
                var ro = cmdo.ExecuteReader();
                while (ro.Read());
                ro.Close();
                r.Close();
            }
            con.Close();
            MessageBox.Show(DateTime.Now.Subtract(d).ToString());
            GC.Collect();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var d = DateTime.Now;
            for (int i = 1; i <= 1000; i++)
            {
                var con = new SqlConnection(@"Data Source=MARTYGINP3\SQLEXPRESS;Initial Catalog=CalcArchive;Integrated Security=True");
                con.Open();
                con.Close();
            }
            MessageBox.Show(DateTime.Now.Subtract(d).ToString());
            GC.Collect();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var d = DateTime.Now;
            for (int i = 1; i <= 1000; i++)
            {
                var con = new SqlConnection(@"Data Source=MARTYGINP3\SQLEXPRESS;Initial Catalog=CalcArchive;Integrated Security=True");
                con.Open();
                var cmd = new SqlCommand("SELECT * FROM BaseValues", con);
                var r = cmd.ExecuteReader();
                r.Close();
                var cmdo = new SqlCommand("SELECT * FROM DayValues", con);
                var ro = cmdo.ExecuteReader();
                ro.Close();
                con.Close();
            }
            MessageBox.Show(DateTime.Now.Subtract(d).ToString());
            GC.Collect();
        }
    }
}
