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
using Microsoft.Win32;

namespace Test4
{
    [ProgId("ActiveXTestLibrary.UserControl")]
    [ClassInterface(ClassInterfaceType.AutoDispatch)] 
    public partial class TestGComp : UserControl
    {
        public TestGComp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Lso();
            for (int i = 0; i < 1000; i++)
                chart1.Series[0].Points.AddY(i / 3);
        }

        public delegate void Screamer();
        public static event Screamer Lso;

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

        public void SerWr()
        {
            for (int h = 0; h < 15;h++ )
                chart1.Series[0].Points.AddY(500-h);
        }
    }
}
