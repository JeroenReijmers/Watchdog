// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Log4NetAdapter.cs">
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

    using Eve.Common.Logging.Base;

    using log4net.Config;

    public class Log4NetAdapter : LoggerBase, ILogger
    {
        private log4net.ILog Log4Net { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Eve.Common.Logging.Log4Net.Log4NetAdapter"/> class.
        ///
        /// This method will create a default log4net XML configuration file if non is present.
        /// </summary>
        public Log4NetAdapter() : this(Utils.GetDefaultConfigFile())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Eve.Common.Logging.Log4Net.Log4NetAdapter"/> class.
        /// </summary>
        /// <param name="configFile">The XML file to load the configuration from.</param>
        public Log4NetAdapter(FileInfo configFile)
        {
            if (!configFile.Exists)
            {
                throw new InvalidOperationException(@"Cannot initialize Log4Net adapter without an existing config file.");
            }

            XmlConfigurator.Configure(configFile);
            this.Log4Net = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        public override bool IsEnabledFor(Level logLevel)
        {
            var log4netLevel = Utils.ConvertLogLevel(logLevel);

            return this.Log4Net.Logger.IsEnabledFor(log4netLevel);
        }

        public override void Log(Level logLevel, string message, Exception exception, params object[] args)
        {
            var log4netLevel = Utils.ConvertLogLevel(logLevel);

            Log4Net.Logger.Log(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType, log4netLevel, message, exception);
        }

        public override void Log(Level logLevel, int eventId, string message, Exception exception, params object[] args)
        {
            const string eventIdProperty = "EventID";

            var oldEventId = log4net.ThreadContext.Properties[eventIdProperty]; // default value should be int 0

            log4net.ThreadContext.Properties[eventIdProperty] = eventId;
            this.Log(logLevel, message, exception, args);
            log4net.ThreadContext.Properties[eventIdProperty] = oldEventId;
        }
    }
}