using System.Data;
using System.Data.OleDb;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Lib64
{
    public class Kosm64
    {
        public void RunKosm()
        {
            var con = new OleDbConnection("Provider=RetroDB.RetroSQL;Data Source=retroServerM");
            con.Open();
            MessageBox.Show("Kosm OK");
            con.Close();
        }
    }
}