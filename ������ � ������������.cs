using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ArhController
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ButSbros_Click(object sender, EventArgs e)
        {
            ProgramInput R = new ProgramInput();
            R.ReadInputParams(@"C:\Projects\С\input.txt");
            this.textBox1.Text = "aaa";
        }

        private void ButBD_Click(object sender, EventArgs e)
        {
            StoreResults S=new StoreResults();
            S.ConnectSQLServer(); 
            //S.ConnectAccess();
        }

      private void ButGrid_Click(object sender, EventArgs e)
      {
        StoreResults S=new StoreResults();
        DataSet ds = S.EditAccess();
        //dataGrid.DataSource = ds.Tables["T1"].DefaultView;
        //dataGrid.Sort(dataGrid.Columns["a"], ListSortDirection.Ascending); 
        DataViewManager DataSetView = ds.DefaultViewManager;
        dataGrid.DataSource = DataSetView;
        dataGrid.DataMember = "T1";
      }

      private void button1_Click(object sender, EventArgs e)
      {
        StoreResults S = new StoreResults();
        //S.EditAccess();
        S.SpeedProba();
        MessageBox.Show("Все");
      }

      private void button2_Click(object sender, EventArgs e)
      {
          ADODB.Connection Cn = new ADODB.Connection();
          Cn.Provider = "OpenSQL Provider";
          Cn.Properties["Data Source"].Value = "c:\\Projects\\Surgut2-6\\Arhive";
          Cn.Properties["Location"].Value = 0;
          Cn.Open("", "", "", -1);

          object Ret = null;
          //ADODB.Recordset Rs = Cn.Execute("Exec RT_ARCHDATE", out Ret, 1);

          ADODB.Command Com = new ADODB.Command();
          Com.CommandText = "Exec RT_ANALOGLIST ? , ? , ?";
          Com.CommandType = ADODB.CommandTypeEnum.adCmdText;
          //object Par = Com.CreateParameter("Sysnums", ADODB.CommandTypeEnum.adCmdUnknown, ADODB.ParameterDirectionEnum.adParamInput,1,null);
          //Com.Parameters.Append(Par);
           
          Com.CommandText = "Exec RT_ARCHDATE";
          
          Com.ActiveConnection = Cn;
          
          object In = null;
          ADODB.Recordset Rs = Com.Execute(out Ret, ref In, 1);
          
          Rs.MoveFirst();
          MessageBox.Show(Rs.Fields[0].Value.ToString());
          MessageBox.Show(Rs.Fields[1].Value.ToString());
          Rs.Close();
          Cn.Close();
      }


      private void button3_Click(object sender, EventArgs e)
      {
        OleDbConnection con = new OleDbConnection("Provider=RetroDB.RetroSQL;Data Source=ArchiveServer");
        //OleDbConnection con = new OleDbConnection("Provider=ArchDB.OpenSQL;Data Source=c:\\Projects\\Surgut2-6\\Arhive\\;Location=0");
        //OleDbCommand cmd = new OleDbCommand("Exec ST_ANALOG ? , ?", con);
        OleDbCommand cmd = new OleDbCommand("Exec RT_ANALOGREAD ? , ? , ?", con);
        //OleDbCommand cmd = new OleDbCommand("Exec RT_DISCRETREAD ? , ? , ?", con);
        //OleDbCommand cmd = new OleDbCommand("Exec ST_DISCRET ? , ?", con);
        //OleDbCommand cmd = new OleDbCommand("Exec VT_OUT ?, ?", con);
        //OleDbCommand cmd = new OleDbCommand("Exec RT_EXTREAD ? , ? , ?", con);
        //OleDbCommand cmd = new OleDbCommand("Exec RT_ARCHDATE", con);
        OleDbParameter parSysNums = new OleDbParameter("Sysnums", OleDbType.Variant);
        OleDbParameter parBeginTime = new OleDbParameter("BeginTime", OleDbType.DBTimeStamp);
        OleDbParameter parEndTime = new OleDbParameter("EndTime", OleDbType.DBTimeStamp);
        parBeginTime.Value = "13.07.2008 10:00:00";              
	    cmd.Parameters.Add(parBeginTime);
        parEndTime.Value = "13.07.2008 10:04:00";
        cmd.Parameters.Add(parEndTime);
        //UInt16[,] SysNums = new UInt16[2, 3];
        UInt16[,] SysNums = new UInt16[2, 2];
        //SysNums[0, 0] = 23442;
        //SysNums[1, 0] = 37100;
        //SysNums[0, 1] = 2;
        //SysNums[1, 1] = 8;
        //SysNums[0, 1] = 3;
        //SysNums[1, 1] = 3;
        SysNums[0, 0] = 10004;
        SysNums[1, 0] = 10390;
        SysNums[0, 1] = 1;
        SysNums[1, 1] = 1;
        //SysNums[0, 2] = 1;
        //SysNums[1, 2] = 1;
        parSysNums.Value = SysNums;
	  	cmd.Parameters.Add(parSysNums);
        con.Open();
        OleDbDataReader rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
            MessageBox.Show(rdr[0].ToString());
            MessageBox.Show(rdr[1].ToString());
            MessageBox.Show(rdr[2].ToString());
            MessageBox.Show(rdr[3].ToString());
            MessageBox.Show(rdr[4].ToString());
            MessageBox.Show(rdr[5].ToString());
            MessageBox.Show(rdr[6].ToString());
            MessageBox.Show(rdr[7].ToString());
            //MessageBox.Show(rdr[8].ToString());
        }
        rdr.Close();
          		
        /*OleDbDataAdapter da = new OleDbDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds, "T1");
        DataTable tbl=ds.Tables["T1"];
        MessageBox.Show(tbl.Rows[0][1].ToString()); */                            
        con.Close();
      }

        public OleDbDataAdapter da;
        public OleDbCommandBuilder cb;
        public DataTable tbl;

        private void button4_Click(object sender, EventArgs e)
        {
            OleDbConnection con= new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=c:\\Projects\\С\\ArhController\\ArhController\\db1.mdb;");
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.Connection = con;

            cmd.CommandText = "SELECT a, b, c, x FROM Tabl1";
            da = new OleDbDataAdapter(cmd);
            cb = new OleDbCommandBuilder(da);
            tbl = new DataTable();
            da.Fill(tbl);
            this.dataGridView2.DataSource = tbl; 

            DataRow row;
            row = tbl.NewRow();
            row["a"] = "sss";
            row["b"] = 10;
            tbl.Rows.Add(row);

            /*MessageBox.Show(tbl.Rows.Count.ToString());
            for (int i = 0; i <= tbl.Rows.Count - 1; ++i)
            {
                row = tbl.Rows[i];
                row["a"] = "kkk";
            }
            */
            da.Update(tbl);

            //con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=c:\\Projects\\С\\ArhController\\ArhController\\db2.mdb;");
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.Connection = con;

            cmd.CommandText = "SELECT a, b, c, x FROM Tabl1";
            da = new OleDbDataAdapter(cmd);
            tbl = new DataTable();
            da.Fill(tbl);
            this.dataGridView2.DataSource = tbl; 
        }

        private void button6_Click(object sender, EventArgs e)
        {
            da.Update(tbl);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form2 F = new Form2();
            F.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

      
   }
}