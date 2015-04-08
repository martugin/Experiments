using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VersionSynch;

namespace TestVersionSynch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1Click(object sender, EventArgs e)
        {
            var vW = new DbVersion();
            //string er = vW.UpdateProjectVersion("D:\\KosmoTest\\Tep3.accdb", false);
            //string er = vW.UpdateArchiveVersion("D:\\KosmoTest\\ArhAnalyzerArchive.accdb", false);
            //string er = vW.UpdateTestVersion("D:\\KosmoTest\\TestProvider.accdb", false);
            //string er = vW.UpdateProjectVersion("D:\\KosmoTest\\Копия Копия Electro 100.accdb", false);
            string er = vW.UpdateProjectVersion("D:\\KosmoTest\\AnalyzerOvatiouiofynTemplates.accdb", false);
            //MessageBox.Show(er);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var vW = new DbVersion();
            vW.RunOverIndexList("D:\\KosmoTest\\Копия Копия Electro.accdb", "Objects");
            vW.RunOverIndexList("D:\\KosmoTest\\Копия ProjectTemplate.accdb", "Objects");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DbVersion.SetDate();
        }
    }
}
