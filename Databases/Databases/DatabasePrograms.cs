using System;
using System.Data.Linq;
using System.Linq;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Data.Odbc;
using System.Windows.Forms;
using Microsoft.Office.Interop.Access.Dao;
using ADODB;
using Connection=ADODB.Connection;
using LockTypeEnum=ADODB.LockTypeEnum;
using Recordset=ADODB.Recordset;

namespace Databases
{
    class DbSample 
   {
        public void InsertAdo()
        {
            var con = new Connection();
            con.Open("Provider='sqloledb';Data Source='(local)';Initial Catalog='Proba';Integrated Security='SSPI';");
            
            var rec =new Recordset();
            rec.Open("SELECT s1, s2 FROM Tabl1",con, CursorTypeEnum.adOpenStatic,LockTypeEnum.adLockOptimistic,0);
            rec.MoveFirst();
            rec.Fields["s1"].Value = "s";
            rec.Fields["s2"].Value = "s";
            rec.Update("s1", rec.Fields["s1"].Value);
            rec.Close();
            con.Close();
        }

        public void MegaInsertAdo()
        {
            var con = new Connection();
            con.Open("Provider='sqloledb';Data Source='(local)';Initial Catalog='Proba';Integrated Security='SSPI';");

            var rec = new Recordset();
            rec.Open("SELECT s1,s2 FROM Tabl2", con, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockOptimistic, 0);
            for (int i = 1; i <= 10000;++i )
            {
                //string [] f={"s1","s2"};
                int[] f = {0, 1};
                string [] v={"s1","s2"};
                rec.AddNew(f,v);
                //rec.Fields["s2"].Value = i.ToString();
                //rec.Fields["s2"].Value = "new";
                rec.Update(f, v);
            }
            rec.Close();
            con.Close();
        }

        public void ReadAccess(string db)
        {
            var con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + db);
            con.Open();
            var cmd=new OleDbCommand("SELECT s1,s2 FROM Tabl1",con);
            OleDbDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
              MessageBox.Show(dataReader["s1"] + @"  " + dataReader["s2"]);
            }
            dataReader.Close();
            con.Close();
        }

        public void ReadOdbcAccess(string db)
        {
            var con = new OdbcConnection(@"Driver={Microsoft Access Driver (*.mdb)};DBQ=" + db);
            con.Open();
            var cmd = new OdbcCommand("SELECT s1,s2 FROM Tabl1", con);
            OdbcDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                MessageBox.Show(dataReader["s1"] + @"  " + dataReader["s2"]);
            }
            dataReader.Close();
            con.Close();
        }

        public void RunAccess()
        {
            var con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=c:\Projects\С\Databases\Databases\dbproba.mdb;");
            con.Open();
            var cmd = new OleDbCommand("INSERT INTO Tabl3(s1,s2) SELECT s1,s2 FROM Tabl1", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show(@"Данные были добавлены");
            con.Close();
        }

        public void InsertAccess()
        {
            //OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=c:\Projects\С\Databases\Databases\dbproba.mdb;");
            var con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=dbproba.mdb;");
            con.Open();
            var dataAdapter=new OleDbDataAdapter("SELECT s1,s2 FROM Tabl1",con);
            new OleDbCommandBuilder(dataAdapter);
            var dataSet =new DataSet();
            dataAdapter.Fill(dataSet, "Tabl1");
            DataRow dataRow = dataSet.Tables["Tabl1"].NewRow();
            dataRow["s1"] = "new";
            dataRow["s2"] = "n";
            dataSet.Tables["Tabl1"].Rows.Add(dataRow);
            dataAdapter.Update(dataSet, "Tabl1");
            MessageBox.Show(@"Данные были добавлены");

            var dataAdapter3 = new OleDbDataAdapter("SELECT s1,s2 FROM Tabl3", con);
            new OleDbCommandBuilder(dataAdapter3);
            dataAdapter3.Fill(dataSet, "Tabl3");
            DataRow dataRow3 = dataSet.Tables["Tabl3"].NewRow();
            dataRow3["s1"] = "new";
            dataRow3["s2"] = "n";
            dataSet.Tables["Tabl3"].Rows.Add(dataRow3);
            dataAdapter3.Update(dataSet, "Tabl3");
            MessageBox.Show(@"Данные были добавлены");
            con.Close();
        }

        public void MegaInsertAccess()
        {
            var con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=dbproba.mdb;");
            con.Open();
            var dataAdapter = new OleDbDataAdapter("SELECT s1,s2 FROM Tabl3", con);
            new OleDbCommandBuilder(dataAdapter);
            var dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "Tabl3");
            DateTime d = DateTime.Now;
            for (int i = 1; i <= 10000; ++i)
            {
                DataRow dataRow = dataSet.Tables["Tabl3"].NewRow();
                dataRow["s1"] = i.ToString();
                dataRow["s2"] = "n";
                dataSet.Tables["Tabl3"].Rows.Add(dataRow);
            }
            dataAdapter.Update(dataSet, "Tabl3");
            MessageBox.Show(DateTime.Now.Subtract(d).ToString());
        }

        public void UpdateDeleteAccess()
        {
            var con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=dbproba.mdb;");
            con.Open();
            var dataAdapter = new OleDbDataAdapter("SELECT Tabl2.n1,Tabl2.n2 FROM Tabl2 ORDER BY Tabl2.n1", con);
            new OleDbCommandBuilder(dataAdapter);
            var dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "Tabl2");
            if (dataSet.Tables["Tabl2"].Rows.Count > 0)
            {
                DataRow dataRow = dataSet.Tables["Tabl2"].Rows[0];
                dataRow["n1"] = 5;
                dataRow["n2"] = 5;
                dataRow = dataSet.Tables["Tabl2"].Rows[0];
                dataRow.Delete();
                dataAdapter.Update(dataSet, "Tabl2");
                MessageBox.Show(@"Данные были изменены");
            }
        }

        public void InsertDao()
        {
            object objOpt = System.Reflection.Missing.Value;
            var dbEngine = new DAO.DBEngine();
            DAO.Database cdb = dbEngine.OpenDatabase(@"c:\Projects\С\Databases\Databases\dbproba.mdb", objOpt, false, objOpt);
            DAO.Recordset rec = cdb.OpenRecordset("Tabl1", DAO.RecordsetTypeEnum.dbOpenDynaset, DAO.RecordsetOptionEnum.dbSeeChanges, DAO.LockTypeEnum.dbOptimistic);
            rec.MoveFirst();
            MessageBox.Show(rec.Fields["s1"].Value.ToString());
            rec.AddNew();
            rec.Fields["s1"].Value="ssssss";
            rec.Update();
            rec.Close();
            cdb.Close();
        }

        public void InsertInteropDao()
        {
            object objOpt = System.Reflection.Missing.Value;
            var dbEngine = new DBEngine();
            Database cdb = dbEngine.OpenDatabase(@"dbproba.mdb", objOpt, false, objOpt);
            Microsoft.Office.Interop.Access.Dao.Recordset rec = cdb.OpenRecordset("Tabl1", RecordsetTypeEnum.dbOpenDynaset, RecordsetOptionEnum.dbSeeChanges, Microsoft.Office.Interop.Access.Dao.LockTypeEnum.dbOptimistic);
            rec.MoveFirst();
            MessageBox.Show(rec.Fields["s1"].Value.ToString());
            rec.AddNew();
            rec.Fields["s1"].Value = "ssssss";
            rec.Update();
            rec.Close();
            cdb.Close();
        }

        public void MegaInsertDao()
        {
            object objOpt = System.Reflection.Missing.Value;
            var dbEngine = new DAO.DBEngine();
            DAO.Database cdb = dbEngine.OpenDatabase(@"dbproba.mdb", objOpt, false, objOpt);
            DAO.Recordset rec = cdb.OpenRecordset("Tabl3", DAO.RecordsetTypeEnum.dbOpenDynaset, DAO.RecordsetOptionEnum.dbSeeChanges, DAO.LockTypeEnum.dbOptimistic);
            DateTime d = DateTime.Now;
            for (int i = 1; i <= 10000; ++i)
            {
                rec.AddNew();
                rec.Fields["s1"].Value = i.ToString();
                rec.Fields["s2"].Value = "n";
                rec.Update();
            }
            rec.Close();
            cdb.Close();
            MessageBox.Show(DateTime.Now.Subtract(d).ToString());
        }

        public void ReadSQL()
        {
            var con = new SqlConnection(@"Data Source=200.0.1.20;Initial Catalog=Proba;Integrated Security=False;User=sa;Password=1");
            con.Open();
            var cmd = new SqlCommand("SELECT s1,s2,n1 FROM Tabl1", con);
            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader != null)
            {
                while (dataReader.Read())
                {
                    MessageBox.Show(dataReader["s1"] + @"  " + dataReader["s2"] + @"  " + dataReader["n1"]);
                }
                dataReader.Close();
            }
            con.Close();
        }

        public void RunSql()
        {
            var con = new SqlConnection(@"Data Source=MARTYGINPV;Initial Catalog=Proba;Integrated Security=True");
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "StoredProcedure2";
            cmd.Parameters.Add("@par", SqlDbType.Int);
            cmd.Parameters[0].Value = 17;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void InsertSql()
        {
            var con = new SqlConnection(@"Data Source=200.0.1.20;Initial Catalog=Proba;Integrated Security=False;User=sa;Password=1");
            con.Open();
            var dataAdapter = new SqlDataAdapter("SELECT s1,s2,n1 FROM Tabl1", con);
            new SqlCommandBuilder(dataAdapter);var dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "Tabl1");
            DataRow dataRow = dataSet.Tables["Tabl1"].NewRow();
            dataRow["s1"] = "new";
            dataRow["s2"] = "n";
            dataRow["n1"] = 20;
            dataSet.Tables["Tabl1"].Rows.Add(dataRow);
            dataAdapter.Update(dataSet, "Tabl1");
            MessageBox.Show(@"Данные были добавлены");
        }

        public void MegaInsertSql()
        {
            var con = new SqlConnection(@"Data Source=200.0.1.20;Initial Catalog=Proba;Integrated Security=False;User=sa;Password=1");
            con.Open();
            var dataAdapter = new SqlDataAdapter("SELECT s1,s2 FROM Tabl1", con);
            new SqlCommandBuilder(dataAdapter);
            var dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "Tabl1");
            DateTime d = DateTime.Now;
            for (int i = 1; i <= 10000; ++i)
            {
                DataRow dataRow = dataSet.Tables["Tabl1"].NewRow();
                dataRow["s1"] = i.ToString();
                dataRow["s2"] = "n";
                dataSet.Tables["Tabl1"].Rows.Add(dataRow);
            }
            dataAdapter.Update(dataSet, "Tabl1");
            MessageBox.Show(DateTime.Now.Subtract(d).ToString());
        }

        public void ReadLinq()
        {
            var pr = new ProbaDataContext(@"Data Source=MARTYGINPV;Initial Catalog=Proba;Integrated Security=True");
            var ct = from c in pr.Tabl3s
                     where c.n1>2
                     orderby c.n1 descending 
                     select c;
            foreach (var c in ct)
            {
                MessageBox.Show(c.n1 + @" " + c.s1);
            }
        }

        public void ReadLinqContext()
        {
            var pr = new DataContext(@"Data Source=MARTYGINPV;Initial Catalog=Proba;Integrated Security=True");
            var ct = from c in pr.GetTable<Tabl3>()
                     where c.n1 > 2
                     orderby c.n1 descending
                     select c;
            foreach (var c in ct)
            {
                MessageBox.Show(c.n1 + @" " + c.s1);
            }
        }

        public void SimpleLinqToSql()
        {
            var pr = new ProbaDataContext(@"Data Source=MARTYGINPV;Initial Catalog=Proba;Integrated Security=True");
            var tabl3 = new Tabl3
                              {
                                  s1 = "s",
                                  n1 = 3
                              };
            pr.Tabl3s.InsertOnSubmit(tabl3);
            pr.SubmitChanges();
        }

        public void MegaLinqToSql()
        {
            DateTime d = DateTime.Now;
            var pr = new ProbaDataContext();
            for (int i = 10; i <= 10000; ++i)
            {
                var tabl1 = new Tabl1
                                  {
                                      s1 = "aaa",
                                      s2 = "bbb",
                                      n1 = i
                                  };
                pr.Tabl1s.InsertOnSubmit(tabl1);
            }
            pr.SubmitChanges();
            MessageBox.Show(DateTime.Now.Subtract(d).ToString());
        }

        public void UpdateLinq()
        {
            var pr = new ProbaDataContext(@"Data Source=MARTYGINPV;Initial Catalog=Proba;Integrated Security=True");
            var ct = from c in pr.Tabl3s
                     where c.n1 > 2
                     orderby c.n1 descending
                     select c;
            foreach (var c in ct)
            {
                if (c.n1<5)
                {
                    pr.Tabl3s.DeleteOnSubmit(c);
                }
                else
                {
                    c.s1 = "fff";
                }
            }
            pr.SubmitChanges();
        }

        public void ReadCompact()
        {
            //var con = new SqlCeConnection(@"Provider=Microsoft.SQLSERVER.CE.OLEDB.3.5;Data Source=Database1.sdf");
            var con = new SqlCeConnection(@"Data Source=Database1.sdf");
            con.Open();
            var cmd = new SqlCeCommand("SELECT s1,s2 FROM TablSpecial", con);
            SqlCeDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                MessageBox.Show(dataReader["s1"] + @"  " + dataReader["s2"]);
            }
            dataReader.Close();
            con.Close();
        }

        public void MegaInsertCompact()
        {
            var con = new SqlCeConnection(@"Data Source=Database1.sdf");
            con.Open();
            var dataAdapter = new SqlCeDataAdapter("SELECT s1,s2 FROM TablSpecial", con);
            new SqlCeCommandBuilder(dataAdapter);
            var dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "Tabl2");
            DateTime d = DateTime.Now;
            for (int i = 1; i <= 10000; ++i)
            {
                DataRow dataRow = dataSet.Tables["Tabl2"].NewRow();
                dataRow["s1"] = i.ToString();
                dataRow["s2"] = "n";
                dataSet.Tables["Tabl2"].Rows.Add(dataRow);
            }
            dataAdapter.Update(dataSet, "Tabl2");
            MessageBox.Show(DateTime.Now.Subtract(d).ToString());
        }

        public void ReadCompactDirect()
        {
            var con = new SqlCeConnection(@"Data Source=Database1.sdf");
            con.Open();
            var cmd = new SqlCeCommand("SELECT s1,s2 FROM TablSpecial", con);
            SqlCeResultSet rec = cmd.ExecuteResultSet(ResultSetOptions.Updatable);
            while (rec.Read())
            {
                MessageBox.Show(rec["s1"] + @"  " + rec["s2"]);
            }
            rec.Close();
            con.Close();
        }

        public void MegaInsertCompactDirect()
        {
            var con = new SqlCeConnection(@"Data Source=Database1.sdf");
            con.Open();
            var cmd = new SqlCeCommand("SELECT s1,s2 FROM TablSpecial", con);
            SqlCeResultSet rec = cmd.ExecuteResultSet(ResultSetOptions.Updatable);
            DateTime d = DateTime.Now;
            for (int i = 1; i <= 10000;++i )
            {
                var r = rec.CreateRecord();
                r["s1"] = "new";
                r["s2"] = "n";
                rec.Insert(r);
            }
            MessageBox.Show(DateTime.Now.Subtract(d).ToString());
            rec.Close();
            con.Close();
        }


        public void InsertOdbcAccess()
        {
            var con = new OdbcConnection(@"Driver={Microsoft Access Driver (*.mdb)};DBQ=dbproba.mdb;");
            con.Open();
            var dataAdapter = new OdbcDataAdapter("SELECT s1,s2 FROM Tabl1", con);
            new OdbcCommandBuilder(dataAdapter);
            var dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "Tabl1");
            DataRow dataRow = dataSet.Tables["Tabl1"].NewRow();
            dataRow["s1"] = "new";
            dataRow["s2"] = "n";
            dataSet.Tables["Tabl1"].Rows.Add(dataRow);
            dataAdapter.Update(dataSet, "Tabl1");
            MessageBox.Show(@"Данные были добавлены");
            con.Close();
        }

        public void MegaInsertOdbcAccess()
        {
            var con = new OdbcConnection(@"Driver={Microsoft Access Driver (*.mdb)};DBQ=dbproba.mdb;");
            con.Open();
            var dataAdapter = new OdbcDataAdapter("SELECT s1,s2 FROM Tabl3", con);
            new OdbcCommandBuilder(dataAdapter);
            var dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "Tabl3");
            DateTime d = DateTime.Now;
            for (int i = 1; i <= 10000; ++i)
            {
                DataRow dataRow = dataSet.Tables["Tabl3"].NewRow();
                dataRow["s1"] = i.ToString();
                dataRow["s2"] = "n";
                dataSet.Tables["Tabl3"].Rows.Add(dataRow);
            }
            dataAdapter.Update(dataSet, "Tabl3");
            MessageBox.Show(DateTime.Now.Subtract(d).ToString());
        }

        public void InsertOdbcSql()
        {
            var con = new OdbcConnection(@"Driver={SQL Server};Server=(local);Trusted_Connection=Yes;Database=Proba;");
            con.Open();
            var dataAdapter = new OdbcDataAdapter("SELECT s1,s2,n1 FROM Tabl1", con);
            new OdbcCommandBuilder(dataAdapter);
            var dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "Tabl1");
            DataRow dataRow = dataSet.Tables["Tabl1"].NewRow();
            dataRow["s1"] = "new";
            dataRow["s2"] = "n";
            dataRow["n1"] = 20;
            dataSet.Tables["Tabl1"].Rows.Add(dataRow);
            dataAdapter.Update(dataSet, "Tabl1");
            MessageBox.Show(@"Данные были добавлены");
        }

        public void MegaInsertOdbcSql()
        {
            var con = new OdbcConnection(@"Driver={SQL Server};Server=(local);Trusted_Connection=Yes;Database=Proba;");
            con.Open();
            var dataAdapter = new OdbcDataAdapter("SELECT s1,s2 FROM Tabl2", con);
            new OdbcCommandBuilder(dataAdapter);
            var dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "Tabl2");
            DateTime d = DateTime.Now;
            for (int i = 1; i <= 10000; ++i)
            {
                DataRow dataRow = dataSet.Tables["Tabl2"].NewRow();
                dataRow["s1"] = i.ToString();
                dataRow["s2"] = "n";
                dataSet.Tables["Tabl2"].Rows.Add(dataRow);
            }
            dataAdapter.Update(dataSet, "Tabl2");
            MessageBox.Show(DateTime.Now.Subtract(d).ToString());
        }

    }
}
