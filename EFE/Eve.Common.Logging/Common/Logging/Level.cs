// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Level.cs">
//   All rights reserved.
// </copyright>
// <summary>
//   The level values of a EFE log.
// </summary>
// <author>Jeroen Reijmers</author>
// --------------------------------------------------------------------------------------------------------------------

namespace Eve.Common.Logging
{
    /// <summary>
    /// Holds the level values of a EFE log.
    /// </summary>
    public enum Level
    {
        /// <summary>
        /// Level for logs that contain the most detailed messages. These messages may contain sensitive application data. These messages should not be enabled in a production environment.
        /// </summary>
        Trace = 0,

        /// <summary>
        /// Level for logs that are used for interactive investigation during development. These logs should primarily contain information useful for debugging and have no long-term value.
        /// </summary>
        Debug = 1,

        /// <summary>
        /// Level for logs that track the general flow of the application. These logs should have long-term value.
        /// </summary>
        Information = 2,

        /// <summary>
        /// Level for logs that highlight an abnormal or unexpected event in the application flow, but do not otherwise cause the application execution to stop.
        /// </summary>
        Warning = 3,

        /// <summary>
        /// Level for logs that highlight when the current flow of execution is stopped due to a failure. These should indicate a failure in the current activity, not an application-wide failure.
        /// </summary>
        Error = 4,

        /// <summary>
        /// Level for logs that describe an unrecoverable application or system crash, or a catastrophic failure that requires immediate attention.
        /// </summary>
        Critical = 5,
    }
}