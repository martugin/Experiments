using System.IO;

namespace OhService
{
    class ConfigManager
    {
        public static string GetDataConnectionString
        {
            get { return Properties.Settings.Default.DataConnectionString; }
        }

        public static string GetOHConnectionString
        {
            get { return Properties.Settings.Default.OHConnectionString; }
        }

        public static string GetPathLogFile
        {
            get { return Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory + "\\Log.txt", ""); }
        }
    }
}