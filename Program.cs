using MySqlConnector;
using MySqlConnector.Logging;
using RepoDb;
using ZenoBook.Forms;

namespace ZenoBook
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            MySqlConnectorLogManager.Provider = new Log4netLoggerProvider();
            GlobalConfiguration.Setup().UseMySqlConnector();
            Application.Run(new Login());
        }
    }
}