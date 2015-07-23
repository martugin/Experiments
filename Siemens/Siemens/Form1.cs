using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BaseLibrary;

namespace Siemens
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var con = new OleDbConnection();
                con = new OleDbConnection(@"Provider=WinCCOLEDBProvider.1;Catalog=CC_SRV_15_03_25_11_21_30R;Data Source=VBOXW7\WINCC");
                con.Open();
                MessageBox.Show(con.State == ConnectionState.Open ? "Open" : ""); 
                using (var res = new RecDao("Siemens", "Archive"))
                {
                    GetSignal(con, res, @"09UHA11CQ001/PV.PV", false);
                    GetSignal(con, res, @"09MAJ40CN901XG02/09MAJ40CN901XG02.OUT", true);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                ex.MessageError();
            }
        }

        private void GetSignal(OleDbConnection con, RecDao res, string code, bool isDiscret)
        {
            var cmd = new OleDbCommand
                {
                    Connection = con,
                    CommandText = @"TAG:R,'SystemArchive\" + code + "#Value', '2015-4-9 8:00:00.000', '2015-4-9 12:00:00.000'",
                    CommandType = CommandType.Text
                };
            var rec = cmd.ExecuteReader();

            while (rec.Read())
            {
                res.AddNew();
                int id = Convert.ToInt32(rec[0]);
                DateTime time = Convert.ToDateTime(rec[1]);
                int quality = Convert.ToInt32(rec[3]);
                int flags = Convert.ToInt32(rec[4]);
                res.Put("Id", id);
                res.Put("Time", time);
                if (isDiscret) res.Put("BoolVal", Convert.ToBoolean(rec[2]));
                else res.Put("Val", Convert.ToDouble(rec[2]));
                res.Put("Quality", quality);
                res.Put("Flags", flags);
                res.Update();
            }
        }
    }
}
