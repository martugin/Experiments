using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using BaseLibrary;
using Microsoft.Win32;

namespace Test4Pt2
{
    [ProgId("ActiveXTestLibrary.UserControl")]
    [ClassInterface(ClassInterfaceType.AutoDispatch)] 
    public partial class TestGComp : UserControl
    {
        public TestGComp()
        {
            InitializeComponent();

        }

        public string LoadList(string stSql)
        {
            try
            {
                using (var reader = new ReaderAdo(ConnectionString, stSql))
                {
                    while (reader.Read())
                    {
                        //switch (reader.GetString("GraficType"))
                        //{
                        //    case "График":
                        //        _graphicType = GraphicType.Graphic;
                        //        //chart1.Series[0].ChartType = SeriesChartType.Line;
                        //        break;
                        //    case "График0":
                        //        _graphicType = GraphicType.Graphic0;
                        //        //chart1.Series[0].ChartType = SeriesChartType.StepLine;
                        //        break;
                        //    case "Диаграмма":
                        //        _graphicType = GraphicType.Diagram;
                        //        //chart1.Series[0].ChartType = SeriesChartType.Point;
                        //        break;
                        //}
                        string uS = "(" + reader.GetString("UnitsX2") + ")";
                        if (uS == "()") uS = "";
                        chart1.ChartAreas[0].AxisX.Title = reader.GetString("NameX2") + uS;
                        uS = "(" + reader.GetString("UnitsX1") + ")";
                        if (uS == "()") uS = "";
                        chart1.ChartAreas[0].AxisY.Title = reader.GetString("NameX1") + uS;
                        chart1.Titles[0].Text = reader.GetString("Code");
                        //_graphicId = int.Parse(reader.GetString("GraficId"));
                        //_dim = reader.GetInt("Dimension");
                        //chart1.Legends[0].Enabled = _dim >= 3;
                    }
                }
                chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
                return "";
            }
            catch (Exception exception)
            {
                Error = new ErrorCommand("Траблы с LoadParams", exception);
                return ErrorMessage;
            }
        }
        internal string ConnectionString { get; set; }

        public string SetDatabase(string databaseFile)
        {
            try
            {
                ConnectionString = databaseFile;
                return "";
            }
            catch (Exception exception)
            {
                Error = new ErrorCommand("SetDatabase error", exception);
                return ErrorMessage;
            }
        }

        public string ErrorMessage
        {
            get { return Error == null ? "" : Error.Text; }
        }
        public string ErrorParams
        {
            get { return Error == null ? "" : Error.Exeption.Message + Error.Exeption.StackTrace; }
        }
        internal ErrorCommand Error;

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 1000; i++)
                chart1.Series[0].Points.AddY(i / 3);
        }

        [ComRegisterFunction()]
        public static void RegisterClass(string key)
        {
            StringBuilder sb = new StringBuilder(key);
            sb.Replace(@"HKEY_CLASSES_ROOT\", "");

            // Open the CLSID\{guid} key for write access  

            RegistryKey k = Registry.ClassesRoot.OpenSubKey(sb.ToString(), true);

            RegistryKey ctrl = k.CreateSubKey("Control");
            ctrl.Close();

            // Next create the CodeBase entry - needed if not string named and GACced.  

            RegistryKey inprocServer32 = k.OpenSubKey("InprocServer32", true);
            inprocServer32.SetValue("CodeBase", Assembly.GetExecutingAssembly().CodeBase);
            inprocServer32.Close();

            k.Close();
        }

        [ComUnregisterFunction()]
        public static void UnregisterClass(string key)
        {
            StringBuilder sb = new StringBuilder(key);
            sb.Replace(@"HKEY_CLASSES_ROOT\", "");

            // Open HKCR\CLSID\{guid} for write access  

            RegistryKey k = Registry.ClassesRoot.OpenSubKey(sb.ToString(), true);

            // Delete the 'Control' key, but don't throw an exception if it does not exist  
            if (k == null)
            {
                return;
            }
            k.DeleteSubKey("Control", false);

            // Next open up InprocServer32  

            RegistryKey inprocServer32 = k.OpenSubKey("InprocServer32", true);

            // And delete the CodeBase key, again not throwing if missing   

            inprocServer32.DeleteSubKey("CodeBase", false);

            // Finally close the main key   

            inprocServer32.Close(); k.Close();
        } 
    }
}
