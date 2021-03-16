// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Utils.cs">
//   All rights reserved.
// </copyright>
// <summary>
//   
// </summary>
// <author>Jeroen Reijmers</author>
// --------------------------------------------------------------------------------------------------------------------

namespace Eve.Common.Logging.Log4Net
{
    using System;
    using System.IO;
    using System.Windows.Forms.VisualStyles;
    using System.Xml;
    using System.Xml.Linq;

    public static class Utils
    {
        public const string Log4NetDefaultConfigFileName = "log4net.config";

        public static FileInfo GetDefaultConfigFile()
        {
            var configFile = new FileInfo(Utils.Log4NetDefaultConfigFileName);

            if (!configFile.Exists)
            {
                Utils.CreateRollingFileAppenderConfig();

                configFile.Refresh();
            }

            return configFile;
        }


        public static void CreateRollingFileAppenderConfig()
        {
            File.WriteAllText(Log4NetDefaultConfigFileName, Properties.Resources.log4net_RollingFileAppender_config);
        }

        public static void CreateAsyncRollingFileTPLForwarderConfig()
        {
            File.WriteAllText(Log4NetDefaultConfigFileName, Properties.Resources.log4net_AsyncRollingFileTPLForwarder_config);
        }

        public static log4net.Core.Level ConvertLogLevel(Eve.Common.Logging.Level logLevel)
        {
            log4net.Core.Level log4netLevel;

            switch (logLevel)
            {
                case Level.Trace:
                    log4netLevel = log4net.Core.Level.Trace;
                    break;
                case Level.Debug:
                    log4netLevel = log4net.Core.Level.Debug;
                    break;
                case Level.Information:
                    log4netLevel = log4net.Core.Level.Info;
                    break;
                case Level.Warning:
                    log4netLevel = log4net.Core.Level.Warn;
                    break;
                case Level.Error:
                    log4netLevel = log4net.Core.Level.Error;
                    break;
                case Level.Critical:
                    log4netLevel = log4net.Core.Level.Fatal;
                    break;
                default:
                    log4netLevel = log4net.Core.Level.All;
                    break;
            }

            return log4netLevel;
        }
    }
}