using System;
using System.Windows.Forms;

namespace Databases
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void butReadAccess_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            string dbName = openFileDialog.FileName;
            var ds = new DbSample();
            ds.ReadAccess(dbName);
        }

        private void butRunAccess_Click(object sender, EventArgs e)
        {
            var ds = new DbSample();
            ds.RunAccess(); 
        }

        private void butInsertAccess_Click(object sender, EventArgs e)
        {
            var ds = new DbSample();
            ds.InsertAccess(); 
        }

        private void butMegaInsertAccess_Click(object sender, EventArgs e)
        {
            var ds = new DbSample();
            ds.MegaInsertAccess();
        }

        private void butUpdateDeleteAccess_Click(object sender, EventArgs e)
        {
            var ds = new DbSample();
            ds.UpdateDeleteAccess();
        }

        private void butReadSQL_Click(object sender, EventArgs e)
        {
            var ds=new DbSample();
            ds.ReadSQL();
        }

        private void butInsertSQL_Click(object sender, EventArgs e)
        {
            var ds=new DbSample();
            ds.InsertSql();
        }

        private void butMegaInsertSQL_Click(object sender, EventArgs e)
        {
            var ds = new DbSample();
            ds.MegaInsertSql();
        }

        private void butSimpleLinkToSQL_Click(object sender, EventArgs e)
        {
            var ds=new DbSample();
            ds.SimpleLinqToSql();
        }

        private void butMegaLinqToSQL_Click(object sender, EventArgs e)
        {
            var ds = new DbSample();
            ds.MegaLinqToSql();
        }

        private void butReadLinq_Click(object sender, EventArgs e)
        {
            var ds=new DbSample();
            ds.ReadLinq();
        }

        private void butUpdateLinq_Click(object sender, EventArgs e)
        {
            var ds =new DbSample();
            ds.UpdateLinq();
        }

        private void butRunSQL_Click(object sender, EventArgs e)
        {
            var ds=new DbSample();
            ds.RunSql();
        }

        private void butReadSQLCompact_Click(object sender, EventArgs e)
        {
            var ds=new DbSample();
            ds.ReadCompact();
        }

        private void butReadLinqContext_Click(object sender, EventArgs e)
        {
            var ds=new DbSample();
            ds.ReadLinqContext();
        }

        private void butInsertDAO_Click(object sender, EventArgs e)
        {
            var ds=new DbSample();
            ds.InsertDao();
        }

        private void butMegaInsertDAO_Click(object sender, EventArgs e)
        {
            var ds = new DbSample();
            ds.MegaInsertDao();
        }

        private void butInsertIDAO_Click(object sender, EventArgs e)
        {
            var ds = new DbSample();
            ds.InsertInteropDao();
        }

        private void butReadOdbcAccess_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            string dbName = openFileDialog.FileName;
            var ds = new DbSample();
            ds.ReadOdbcAccess(dbName);
        }

        private void butInsertOdbcAccess_Click(object sender, EventArgs e)
        {
            var ds =new DbSample();
            ds.InsertOdbcAccess();
        }

        private void butMegaInsertOdbcAccess_Click(object sender, EventArgs e)
        {
            var ds = new DbSample();
            ds.MegaInsertOdbcAccess();
        }

        private void butInsertOdbcSQL_Click_1(object sender, EventArgs e)
        {
            var ds = new DbSample();
            ds.InsertOdbcSql();
        }

        private void butMegaInsertOdbcSQL_Click(object sender, EventArgs e)
        {
            var ds = new DbSample();
            ds.MegaInsertOdbcSql();
        }

        private void butInsertADOSQL_Click(object sender, EventArgs e)
        {
            var ds = new DbSample();
            ds.InsertAdo();
        }

        private void butMegaInsertADOSQL_Click(object sender, EventArgs e)
        {
            var ds = new DbSample();
            ds.MegaInsertAdo();
        }

        private void butMegaInsertCompact_Click(object sender, EventArgs e)
        {
            var ds = new DbSample();
            ds.MegaInsertCompact();
        }

        private void butReadCompactDirect_Click(object sender, EventArgs e)
        {
            var ds = new DbSample();
            ds.ReadCompactDirect();
        }

        private void butMegaInsertCompactDirect_Click(object sender, EventArgs e)
        {
            var ds = new DbSample();
            ds.MegaInsertCompactDirect();
        }
        
    }
}
