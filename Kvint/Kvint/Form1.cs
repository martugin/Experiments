using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

namespace Kvint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private OleDbConnection OpenConnection()
        {
            string location = string.IsNullOrEmpty(Location.Text) ? "" : ";Location=" + Location.Text;
            string user = string.IsNullOrEmpty(User.Text) ? "" : ";User Id=" + User.Text;
            string password = string.IsNullOrEmpty(Password.Text) ? "" : ";Password=" + Password.Text;
            var conn = new OleDbConnection("Provider=Kvint archive OLE DB Provider" + location + user + password);
            conn.Open();
            MessageBox.Show("Соединение: " + conn.State);
            return conn;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            var conn = OpenConnection();
            string paramNo = string.IsNullOrEmpty(ParamNo.Text) ? "" : " and parameter.paramno = " + ParamNo.Text;
            string orderBy = string.IsNullOrEmpty(OrderBy.Text) ? "" : " order by " + OrderBy.Text;
            var com = new OleDbCommand("select card.marka, parameter.ValTime, parameter.value from card, parameter " +
                                       " where card.Marka = \"" + Code.Text + "\" and card.cardid = parameter.CardId " + paramNo +
                                       " and parameter.ValTime > \"" + TimeBegin.Text + "\" and parameter.ValTime < \"" + TimeEnd.Text + "\"" + orderBy , conn);
            MessageBox.Show(com.CommandText);
            //var com = new OleDbCommand("select card.marka, parameter.ValTime, parameter.value from card, parameter " +
            //                           "where card.Marka = \"10MAD01CY001\" and card.cardid = parameter.CardId and parameter.paramno = 1 " +
            //                           "and parameter.ValTime > \"12/2/2017 23:00:00\" and parameter.ValTime < \"13/2/2017 15:00:00\"", conn);
            try
            {
                var reader = com.ExecuteReader();
                reader.Read();
                MessageBox.Show("Записи в parameter: " + reader.HasRows);
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //var conn = new OleDbConnection("Provider=Kvint archive OLE DB Provider;Location=STEND01");
            //var conn = new OleDbConnection("Provider=Kvarcdbprov.KvArcProv.1");
            var conn = OpenConnection();
            var com = new OleDbCommand("select card.marka from card", conn);
            var reader = com.ExecuteReader();
            reader.Read();
            MessageBox.Show(reader.GetValue(0).ToString());
            reader.Close();
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var conn = OpenConnection();
            var com = new OleDbCommand("select * from User_Control", conn);
            try
            {
                var reader = com.ExecuteReader();
                reader.Read();
                MessageBox.Show("Записи в User_Control: " + reader.HasRows);
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
            conn.Close();
        }
    }
}
