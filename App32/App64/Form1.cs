using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lib32;
using Lib64;
using LibAny;
using Microsoft.Office.Interop.Access.Dao;

namespace App64
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ButDao_Click(object sender, EventArgs e)
        {
            var en = new DBEngine();
            var db = en.OpenDatabase("Db.accdb");
            db.Close();
            MessageBox.Show("DB OK");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dc = new DaoClass32();
            dc.RunDao();
        }

        private void ButDao64_Click(object sender, EventArgs e)
        {
            var dc = new DaoClass64();
            dc.RunDao();
        }

        private void ButAny_Click(object sender, EventArgs e)
        {
            var dc = new DaoClassAny();
            dc.RunDao();
        }

        private void ButKosmAny_Click(object sender, EventArgs e)
        {
            var k = new KosmAny();
            k.RunKosm();
        }

        private void ButKosm_Click(object sender, EventArgs e)
        {
            var con = new OleDbConnection("Provider=RetroDB.RetroSQL;Data Source=retroServerM");
            con.Open();
            MessageBox.Show("Kosm OK");
            con.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void ButKosmLib32_Click(object sender, EventArgs e)
        {
            var k = new Kosm32();
            k.RunKosm();
        }

        private void ButKosmLib64_Click(object sender, EventArgs e)
        {
            var k = new Kosm64();
            k.RunKosm();
        }
    }
}
