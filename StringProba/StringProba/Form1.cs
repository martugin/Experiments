using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BaseLibrary;

namespace StringProba
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(new StringBuilder("Test").Append(Environment.NewLine).Append("aaa").ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var rec = new RecDao("db.accdb", "Tabl"))
            {
                rec.AddNew();
                rec.Put("S", "test" + Environment.NewLine + "aaa");
                rec.AddNew();
                rec.Put("S", new StringBuilder("Test").Append(Environment.NewLine).Append("aaa").ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var d = DateTime.Now;
            for (int k = 1; k < 100000; k++)
            {
                string s = "";
                for (int i = 0; i < 200; i++)
                {
                    s += ((k*1000 + i).ToString());
                }
            }
            MessageBox.Show(DateTime.Now.Subtract(d).ToString());
            d = DateTime.Now;
            for (int k = 1; k < 100000; k++)
            {
                var ss = new string[200];
                for (int i = 0; i < 200; i++)
                    ss[i] = ((k * 1000 + i).ToString());
                string.Concat(ss);
            }
            MessageBox.Show(DateTime.Now.Subtract(d).ToString());
            d = DateTime.Now;
            for (int k = 1; k < 100000; k++)
            {
                var sb = new StringBuilder();
                for (int i = 0; i < 200; i++)
                    sb.Append(k * 1000 + i);
                sb.ToString();
            }
            MessageBox.Show(DateTime.Now.Subtract(d).ToString());
        }
    }
}
