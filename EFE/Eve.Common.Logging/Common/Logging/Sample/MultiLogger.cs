// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MultiLogger.cs">
//   All rights reserved.
// </copyright>
// <summary>
//   
// </summary>
// <author>Jeroen Reijmers</author>
// --------------------------------------------------------------------------------------------------------------------

namespace Eve.Common.Logging.Sample
{
    using System;
    using System.Collections.Generic;

    using Eve.Common.Logging.Base;

    public class MultiLogger : LoggerBase, ILogger
    {
        public MultiLogger(ICollection<ILogger> loggers)
        {
            this.Loggers = loggers;
        }

        public bool TraceLoggingEnabled { get; set; } = true;
        public bool DebugLoggingEnabled { get; set; } = true;
        public bool InformationLoggingEnabled { get; set; } = true;
        public bool WarningLoggingEnabled { get; set; } = true;
        public bool ErrorLoggingEnabled { get; set; } = true;
        public bool CriticalLoggingEnabled { get; set; } = true;

        private ICollection<ILogger> Loggers { get; }

        public override bool IsEnabledFor(Level logLevel)
        {
            return logLevel switch
            {
                Level.Trace => this.TraceLoggingEnabled,
                Level.Debug => this.DebugLoggingEnabled,
                Level.Information => this.InformationLoggingEnabled,
                Level.Warning => this.WarningLoggingEnabled,
                Level.Error => this.ErrorLoggingEnabled,
                Level.Critical => this.CriticalLoggingEnabled,
                _ => throw new NotImplementedException()
            };
        }

        public override void Log(Level logLevel, string message, params object[] args)
        {
            if (IsEnabledFor(logLevel))
            {
                foreach (var logger in this.Loggers)
                {
                    logger.Log(logLevel, message, args);
                }
            }
        }

        public override void Log(Level logLevel, int eventId, string message, params object[] args)
        {
            if (IsEnabledFor(logLevel))
            {
                foreach (var logger in this.Loggers)
                {
                    logger.Log(logLevel, eventId, message, args);
                }
            }
        }

        public override void Log(Level logLevel, string message, Exception exception, params object[] args)
        {
            if (IsEnabledFor(logLevel))
            {
                foreach (var logger in this.Loggers)
                {
                    logger.Log(logLevel, message, exception, args);
                }
            }
        }

        public override void Log(Level logLevel, int eventId, string message, Exception exception, params object[] args)
        {
            if (IsEnabledFor(logLevel))
            {
                foreach (var logger in this.Loggers)
                {
                    logger.Log(logLevel, eventId, message, exception, args);
                }
            }
        }
    }
}