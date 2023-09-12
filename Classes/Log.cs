using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenoBook.Classes
{
    internal class Log
    {
        private static readonly DirectoryInfo currentDirectoryInfo = new DirectoryInfo(".");

        private static readonly string loggingPath = currentDirectoryInfo + "\\AppLog.txt";

        public static void LogMessage(string message)
        {
            if (!File.Exists(loggingPath)) // Create a file to write to if one doesn't exist
            {
                var file = File.Create(loggingPath);
            }

            using (var writer = File.AppendText(loggingPath)) // Write messages to log
            {
                writer.WriteLine(message + "at " + DateTime.Now + ".\n");
            }
        }
        
        #region Constructors

        public Log() { }

        #endregion
    }
}
