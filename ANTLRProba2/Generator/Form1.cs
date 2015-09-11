using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Generator.Generator;

namespace Generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ButCondition_Click(object sender, EventArgs e)
        {
            Result.Text = new ConditionParsing("поле", Formula.Text).ToTestString();
        }

        private void ButSubCondition_Click(object sender, EventArgs e)
        {
            Result.Text = new ConditionSubParsing("поле", Formula.Text).ToTestString();
        }
    }
}
