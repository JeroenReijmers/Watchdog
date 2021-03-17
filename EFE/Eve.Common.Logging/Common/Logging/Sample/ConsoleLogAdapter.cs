// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsoleLogAdapter.cs">
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
    using System.Diagnostics;
    using Eve.Common.Logging.Base;

    public class ConsoleLogAdapter : LoggerBase, ILogger
    {
        public bool AddTimestamps { get; set; } = true;

        public bool TraceLoggingEnabled { get; set; } = true;
        public bool DebugLoggingEnabled { get; set; } = true;
        public bool InformationLoggingEnabled { get; set; } = true;
        public bool WarningLoggingEnabled { get; set; } = true;
        public bool ErrorLoggingEnabled { get; set; } = true;
        public bool CriticalLoggingEnabled { get; set; } = true;

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

        public override void Log(Level logLevel, string message, Exception exception, params object[] args)
        {
            LogToConsole(logLevel,null, message, exception);
        }

        public override void Log(Level logLevel, int eventId, string message, Exception exception, params object[] args)
        {
            LogToConsole(logLevel,eventId, message, exception);
        }

        private void LogToConsole(Level logLevel, int? eventId, string message, Exception exception)
        {
            if (IsEnabledFor(logLevel))
            {
                string line = "";

                if (this.AddTimestamps)
                {
                    line += $"{DateTime.Now} ";
                }

                line += $"{logLevel} - ";

                if (eventId != null)
                {
                    line += $"[{eventId}] ";
                }

                if (message != null)
                {
                    line += $"{message}";
                }

                if (exception != null)
                {
                    line += $"{Environment.NewLine}{exception.StackTrace}";
                }

                line += $"{Environment.NewLine}";

                Console.Write(line);
            }
        }
    }
}