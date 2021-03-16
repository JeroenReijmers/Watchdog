// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILogger.cs">
//   All rights reserved.
// </copyright>
// <summary>
//   
// </summary>
// <author>Jeroen Reijmers</author>
// --------------------------------------------------------------------------------------------------------------------

namespace Eve.Common.Logging
{
    using System;

    public interface ILogger
    {
        /// <summary>
        /// Checks if the given log level is enabled
        /// </summary>
        /// <param name="logLevel">The level to be checked.</param>
        /// <returns>Will return true if enabled, otherwise false.</returns>
        bool IsEnabledFor(Eve.Common.Logging.Level logLevel);

        /// <summary>
        /// Logs the given message at the specified log level.
        /// </summary>
        /// <param name="logLevel">The <see cref="Eve.Common.Logging.Level"/> to log the entry on.</param>
        /// <param name="message">The message to write in the log entry.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        void Log(Eve.Common.Logging.Level logLevel, string message, params object[] args);
        /// <summary>
        /// Logs the given message and exception at the specified log level.
        /// </summary>
        /// <param name="logLevel">The <see cref="Eve.Common.Logging.Level"/> to log the entry on.</param>
        /// <param name="eventId">The event id associated with the log entry.</param>
        /// <param name="message">The message to write in the log entry.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        void Log(Eve.Common.Logging.Level logLevel, int eventId, string message, params object[] args);
        /// <summary>
        /// Logs the given message and exception at the specified log level.
        /// </summary>
        /// <param name="logLevel">The <see cref="Eve.Common.Logging.Level"/> to log the entry on.</param>
        /// <param name="message">The message to write in the log entry.</param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        void Log(Eve.Common.Logging.Level logLevel, string message, Exception exception, params object[] args);
        /// <summary>
        /// Logs the given message and exception at the specified log level.
        /// </summary>
        /// <param name="logLevel">The <see cref="Eve.Common.Logging.Level"/> to log the entry on.</param>
        /// <param name="eventId">The event id associated with the log entry.</param>
        /// <param name="message">The message to write in the log entry.</param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        void Log(Eve.Common.Logging.Level logLevel, int eventId, string message, Exception exception, params object[] args);
    }
}