using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //private static SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;

        private void button1_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    //Registry.LocalMachine.SetValue("Software\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\{663E33F1-9558-4256-A9AE-8889C3113B8D}\\NoRemove", 0, RegistryValueKind.DWord);
            //    RegistryKey myKey = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\{663E33F1-9558-4256-A9AE-8889C3113B8D}", true);
            //    myKey.SetValue("NoRemove", 0, RegistryValueKind.DWord);
            //}
            //catch (Exception exception)
            //{
            //    MessageBox.Show(exception.Message + '\n' + exception.StackTrace);
            //}
            //bool serverCaptured = false;
            //string capturedServer = "";
            label1.Text = "";
            DateTime dold = DateTime.Now;
            SqlDataSourceEnumerator instance =
                SqlDataSourceEnumerator.Instance;
            DataTable table = instance.GetDataSources();
            //sqlSources = SqlDataSourceEnumerator.Instance.GetDataSources();
            //DataTable table = SmoApplication.EnumAvailableSqlServers();
            label1.Text += DateTime.Now - dold;
            //foreach (DataRow source in table.Rows)
            //{
            //    string servername;
            //    string instanceName = source["Name"].ToString();

            //    if (!string.IsNullOrEmpty(instanceName))
            //    {
            //        servername = source["Name"].ToString() + '\\' + source["Server"];
            //    }
            //    else
            //    {
            //        servername = source["Server"].ToString() + source["Version"];
            //        //if (!serverCaptured)
            //        //{
            //        //    capturedServer = source["ServerName"].ToString();
            //        //    serverCaptured = true;
            //        //}
            //    }
            //    //MessageBox.Show(string.Format("Server Name:{0}\nVersion:{1}", servername, source["Version"].ToString()));
            //    label1.Text += "\nServer Name: " + servername;
            //}
            DisplayData(table);
            label1.Text += "\n" + (DateTime.Now - dold);
        }
        private void DisplayData(DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn col in table.Columns)
                {
                    label1.Text += col.ColumnName + " = " + row[col] + "\n";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            DateTime dold = DateTime.Now;
            using (var con = new SqlConnection("Data Source=200.0.1.20; User ID=sa;Password=1;"))
            //using (var con = new SqlConnection("Data Source=ALBICHEV\\SQLEXPRESS;Integrated Security=true;Connect Timeout=30;User Instance=True;"))
            {
                con.Open();
                label2.Text += con.ServerVersion;
                DataTable databases = con.GetSchema("Databases");
                foreach (DataRow database in databases.Rows)
                {
                    String databaseName = database.Field<String>("database_name");
                    short dbID = database.Field<short>("dbid");
                    DateTime creationDate = database.Field<DateTime>("create_date");
                    label2.Text += "\nDatabase Name: " + databaseName;
                }
                con.Close();
            }
            label2.Text += "\n" + (DateTime.Now - dold);
        }

        // Pass the path to the back up directory and the name of the .bak file to restore.
        public bool restoreDB(SqlConnection sqlConnection1, string filePath, string fileName)
        {
            //
            bool restoreComplete = false;
            sqlConnection1.Open();
            System.Data.SqlClient.SqlCommand sqlDBrestoreCommand = new System.Data.SqlClient.SqlCommand();
            sqlDBrestoreCommand.Connection = sqlConnection1;

            try
            {
                //sqlDBrestoreCommand.CommandText = "Use Master";
                //sqlDBrestoreCommand.ExecuteNonQuery();
                //sqlDBrestoreCommand.CommandText = "ALTER DATABASE BlackBook SET SINGLE_USER WITH ROLLBACK IMMEDIATE;";
                //sqlDBrestoreCommand.ExecuteNonQuery();
                sqlDBrestoreCommand.CommandText = "RESTORE DATABASE Ptec14_b1 FROM DISK = '" + filePath + fileName +
                    "' WITH MOVE 'PTEC14_BL1_data' TO 'D:\\KosmoTest\\PTEC14_BL1.mdf', MOVE 'PTEC14_BL1_log' TO 'D:\\KosmoTest\\PTEC14_BL1_log.ldf';";
                sqlDBrestoreCommand.ExecuteNonQuery();
                //sqlDBrestoreCommand.CommandText = "Use Master";
                //sqlDBrestoreCommand.ExecuteNonQuery();
                //sqlDBrestoreCommand.CommandText = "ALTER DATABASE BlackBook SET MULTI_USER;";
                //sqlDBrestoreCommand.ExecuteNonQuery();
                restoreComplete = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            sqlConnection1.Close();
            return restoreComplete;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            var con = new SqlConnection("Data Source=ALBICHEV\\SQLEXPRESS;Integrated Security=true;Connect Timeout=30;User Instance=True;");
            restoreDB(con, "D:\\KosmoTest\\", "Ptec14_b1.bak");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //ReaderAdo r1 = new ReaderAdo();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            DateTime dold = DateTime.Now;
            //SqlDataSourceEnumerator instance =
            //    SqlDataSourceEnumerator.Instance;
            //DataTable table = instance.GetDataSources();
            //sqlSources = SqlDataSourceEnumerator.Instance.GetDataSources();
            DataTable table = SmoApplication.EnumAvailableSqlServers();
            label1.Text += DateTime.Now - dold;
            foreach (DataRow source in table.Rows)
            {
                string servername;
                string instanceName = source["Name"].ToString();

                if (!string.IsNullOrEmpty(instanceName))
                {
                    servername = source["Name"].ToString() + '\\' + source["Server"];
                }
                else
                {
                    servername = source["Server"].ToString() + source["Version"];
                    //if (!serverCaptured)
                    //{
                    //    capturedServer = source["ServerName"].ToString();
                    //    serverCaptured = true;
                    //}
                }
                //MessageBox.Show(string.Format("Server Name:{0}\nVersion:{1}", servername, source["Version"].ToString()));
                label1.Text += "\nServer Name: " + servername;
            }
            label1.Text += "\n" + (DateTime.Now - dold);
        }
    }
}
