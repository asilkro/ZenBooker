using log4net;
using MySqlConnector.Logging;
using RepoDb;
using ZenoBook.Forms;

namespace ZenoBook;

internal static class Program
{
    private static readonly ILog log = log4net.LogManager.GetLogger
        (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    /// <summary>
    ///     The main entry point for the application.
    /// </summary>
    [STAThread]

    private static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        GlobalContext.Properties["LogFileName"] = Application.StartupPath;
        MySqlConnectorLogManager.Provider = new Log4netLoggerProvider();
        GlobalConfiguration.Setup().UseMySqlConnector();
        if (LogManager.Exists("LoggingRepo") == null)
        {
            LogManager.CreateRepository("LoggingRepo");
        }
        Application.Run(new Login());
    }
}