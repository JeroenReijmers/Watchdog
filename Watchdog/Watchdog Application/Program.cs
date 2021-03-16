using System;

namespace Watchdog
{
    using Eve.Common.Logging.Log4Net;

    using global::Watchdog.Applications;

    class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="args">Array of command line arguments passed to the program</param>
        [STAThread]
        static void Main(string[] args)
        {
            var logger = new Log4NetAdapter(Utils.GetDefaultConfigFile());

            var application = new WatchdogTrayApplication(logger);

            application.Run();
        }
    }
}