using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Globalization;
using System.ServiceProcess;
using System.Threading;
using PGES.EventLogFile;

namespace OhService {
    public partial class OhService : ServiceBase {

        private Thread thread = null;
        private static ManualResetEvent exitEvent = new ManualResetEvent(false);

        public OhService() {
            InitializeComponent();
        }

        protected override void OnStart(string[] args) {
            if ((thread == null) || ((thread.ThreadState & (System.Threading.ThreadState.Unstarted | System.Threading.ThreadState.Stopped)) != 0)) {
                thread = new Thread(new ThreadStart(ServiceThread));
                thread.Start();
                EventLogFile.WriteLogFile(ConfigManager.GetPathLogFile, "Start Service");
            }
        }

        protected override void OnStop() {
            this.RequestAdditionalTime(10000);
            if ((thread != null) && (thread.IsAlive)) {
                exitEvent.Set();
                Thread.Sleep(10000);
                thread.Abort();
            }
            this.ExitCode = 0;
        }

        protected static void OnInfoMessage(object sender, SqlInfoMessageEventArgs args) {
            foreach (SqlError err in args.Errors) {
                EventLogFile.WriteLogFile(ConfigManager.GetPathLogFile, err.Procedure + " - " + err.Message);
            }
        }

        private static void ServiceThread() {
            while (true) {
                try {
                    using (OleDbConnection connOH = new OleDbConnection(ConfigManager.GetOHConnectionString))
                    using (SqlConnection connData = new SqlConnection(ConfigManager.GetDataConnectionString)) {

                        connData.InfoMessage += new SqlInfoMessageEventHandler(OnInfoMessage);

                        connData.Open();

                        OleDbCommand cmdOH = new OleDbCommand();
                        cmdOH.Connection = connOH;

                        SqlCommand cmdGetTS = new SqlCommand("OvationHistory_GetMaxTS", connData);
                        cmdGetTS.CommandType = CommandType.StoredProcedure;
                        SqlParameter parGetTS_ID = cmdGetTS.Parameters.Add("@ID", SqlDbType.Int);

                        SqlCommand cmdSet = new SqlCommand("OvationHistory_Set", connData);
                        cmdSet.CommandType = CommandType.StoredProcedure;
                        SqlParameter parSet_ID = cmdSet.Parameters.Add("@ID", SqlDbType.Int);
                        SqlParameter parSet_TS = cmdSet.Parameters.Add("@TS", SqlDbType.DateTime);
                        SqlParameter parSet_Value = cmdSet.Parameters.Add("@Value", SqlDbType.Float);

                        SqlCommand cmdAggr = new SqlCommand("Ovation_Aggregate", connData);
                        cmdAggr.CommandType = CommandType.StoredProcedure;
                        SqlParameter parAggr_ID = cmdAggr.Parameters.Add("@ID", SqlDbType.Int);
                        SqlParameter parAggr_TS = cmdAggr.Parameters.Add("@TS", SqlDbType.DateTime);

                        DataSet ds = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT [ID] FROM [Attr_Point] WHERE [Enabled]=1", connData);
                        da.Fill(ds, "Point");
                        DataTable points = ds.Tables["Point"];

                        CultureInfo ci = CultureInfo.CreateSpecificCulture("en-US");

                        foreach (DataRow dr in points.Rows) {
                            int id = (int)dr["ID"];

                            DateTime now = DateTime.UtcNow;
                            DateTime nowHour = new DateTime(now.Year, now.Month, now.Day, now.Hour, 0, 0);
                            DateTime minDate = now.AddDays(-40).Date;

                            DateTime start = minDate;
                            parGetTS_ID.Value = id;
                            Object o = cmdGetTS.ExecuteScalar();
                            if (!o.Equals(DBNull.Value)) {
                                start = (DateTime)o;
                                if (start < minDate) start = minDate;
                            }

                            DateTime end = (new DateTime(start.Year, start.Month, start.Day, start.Hour, 0, 0)).AddHours(2);
                            if (end > now) end = now;

                            while (start < now) {
                                EventLogFile.WriteLogFile(ConfigManager.GetPathLogFile, "select OH " + id.ToString() + " - " + start.ToString("dd.MM.yyyy HH:mm") + " - " + end.ToString("dd.MM.yyyy HH:mm"));
                                cmdOH.CommandText = String.Format("select TIMESTAMP, F_VALUE from PT_HF_HIST where ID={0} and TIMESTAMP>#{1}# and TIMESTAMP<=#{2}#", id, start.ToString("MM/dd/yyyy HH:mm:ss.fff", ci), end.ToString("MM/dd/yyyy HH:mm:ss.fff", ci));
                                connOH.Open();
                                OleDbDataReader reader = cmdOH.ExecuteReader();
                                while (reader.Read()) {
                                    parSet_ID.Value = id;
                                    parSet_TS.Value = (DateTime)reader["TIMESTAMP"];
                                    parSet_Value.Value = (double)reader["F_VALUE"];
                                    cmdSet.ExecuteNonQuery();
                                }
                                reader.Close();
                                connOH.Close();

                                if (start <= nowHour) {
                                    parAggr_ID.Value = id;
                                    parAggr_TS.Value = new DateTime(end.Year, end.Month, end.Day, end.Hour, 0, 0);
                                    EventLogFile.WriteLogFile(ConfigManager.GetPathLogFile, "select OH " + id.ToString() + " - " + ((DateTime)parAggr_TS.Value).ToString("dd.MM.yyyy HH:mm"));
                                    cmdAggr.ExecuteNonQuery();
                                }

                                start = end;
                                end = start.AddHours(1);
                                if ((now - end).Hours == 0) end = now;
                            }
                        }
                        connOH.Close();
                        connData.Close();
                    }
                }
                catch (Exception ex) {
                    EventLogFile.WriteLogFile(ConfigManager.GetPathLogFile, ex.Message + " ! " + ex.StackTrace);
                }
                if (exitEvent.WaitOne(600000)) break;
            }
        }
    }
}
