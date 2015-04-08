using System;
using System.IO;

namespace PGES.EventLogFile
{
    class EventLogFile
    {
        #region WriteLogFile
        /// <summary>
        /// Record to log file
        /// </summary>
        /// <param name="pathlogFile">Path to log file </param>
        /// <param name="message">Message</param>
        internal static void WriteLogFile(string pathLogFile, string message)
        {
            try
            {
                StreamWriter sw = File.AppendText(pathLogFile);
                sw.WriteLine(DateTime.Now + "  " + message);
                sw.Close();
            }
            catch
            { 
                return;
            }
        }
        #endregion

        #region WriteNewLine
        /// <summary>
        /// New line
        /// </summary>
        /// <param name="pathlogFile">Path to log file </param>
        /// <param name="message">Message</param>
        internal static void WriteNewLine(string pathLogFile)
        {
            try
            {
                StreamWriter sw = File.AppendText(pathLogFile);
                sw.WriteLine("");
                sw.Close();
            }
            catch
            {
                return;
            }
        }
        #endregion
    }
}