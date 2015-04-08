using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "ClientCountLimit=NoLimit;UserOrg=ЗАО &quot;ИЦ &quot;Уралтехэнерго&quot;";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = Crypting.Encrypt(textBox1.Text);
            //MessageBox.Show(textBox2.Text.Count().ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Text = Crypting.Decrypt(textBox2.Text);
        }
    }
}
