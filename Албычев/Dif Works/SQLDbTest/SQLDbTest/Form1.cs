using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

namespace SQLDbTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string connectionString = "Persist Security Info=False;Integrated Security=true;Initial Catalog=DB1;server=ALBICHEV\\SQLEXPRESS";
            string connectionString = "Persist Security Info=False;Integrated Security=true;Initial Catalog=DB1;server=(local)";
            SqlConnection connection = new SqlConnection(connectionString);
            Server server = new Server(new ServerConnection(connection));
            Database db = server.Databases["DB1"];
            //Table newTable = new Table(db, "TestTable1");
            //Column idColumn = new Column(newTable, "ID");
            //idColumn.DataType = DataType.Int;
            //idColumn.Nullable = false;
            //idColumn.Identity = true;
            //idColumn.IdentitySeed = 1;
            //idColumn.IdentityIncrement = 1;
            //Column titleColumn = new Column(newTable, "Title");
            //titleColumn.DataType = DataType.VarChar(50);
            //titleColumn.Nullable = false;
            //// Add Columns to Table Object
            //newTable.Columns.Add(idColumn);
            //newTable.Columns.Add(titleColumn);
            //// Create a PK Index for the table
            //Index index = new Index(newTable, "PK_TestTable");
            //index.IndexKeyType = IndexKeyType.DriPrimaryKey;
            //// The PK index will consist of 1 column, "ID"
            //index.IndexedColumns.Add(new IndexedColumn(index, "ID"));
            //// Add the new index to the table.
            //newTable.Indexes.Add(index);
            //newTable.Create();

            //Column titleColumn = new Column(db.Tables["params"], "Title");
            //Column titleColumn = db.Tables["params"].Columns["Title"];
            //titleColumn.DataType = DataType.Int;
            //MessageBox.Show(titleColumn.DataType.SqlDataType.ToString());
            //titleColumn.Default = "-1";
            //titleColumn.Rename("Caption");
            //titleColumn.Nullable = true;
            //db.Tables["params"].Columns.Add(titleColumn);
            //db.Tables["params"].Alter();

            //Column titleColumn = db.Tables["params"].Columns["Caption"];
            //Index newIndex = new Index(db.Tables["params"], titleColumn.Name);
            //newIndex.IsUnique = true;
            //newIndex.Name = "Idx_Caption";
            //newIndex.IndexedColumns.Add(new IndexedColumn(newIndex, "Caption"));
            //db.Tables["params"].Indexes.Add(newIndex);
            ////db.Tables["params"].Refresh();

            //foreach (Index id in db.Tables["params"].Indexes)
            //{
            //    MessageBox.Show(id.IsUnique.ToString());
            //}


        }
    }
}
