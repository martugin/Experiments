using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Memory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var list = new List<MomList>();
            int n = int.Parse(NumLists.Text);
            for (int i = 0; i < n; i++)
            {
                var ml = new MomList();
                list.Add(ml);
                var r = new Random();
                for (int k = 0; k < 1000; k++)
                    ml.List.Add(new Mom(DateTime.Now, r.NextDouble(), r.Next()));
            }
            list = null;
        }
    }
}
