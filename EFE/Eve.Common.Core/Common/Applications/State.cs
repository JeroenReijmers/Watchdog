// --------------------------------------------------------------------------------------------------------------------
// <copyright file="State.cs">
//   All rights reserved.
// </copyright>
// <summary>
//   The state values of a EFE runnable.
// </summary>
// <author>Jeroen Reijmers</author>
// --------------------------------------------------------------------------------------------------------------------

namespace Eve.Common.Applications
{
    /// <summary>
    /// Holds the state values of a EFE runnable.
    /// </summary>
    public enum State
    {
        /// <summary>
        /// The off state indicates that the runnable did not run during its lifecycle.
        /// </summary>
        Off = -1,       // 11111111 11111111 11111111 11111111

        /// <summary>
        /// The stopped state indicates that the runnable has been stopped(killed). This requires the runnable to have been started at some point prior.
        /// </summary>
        Stopped = 0,    // 00000000 00000000 00000000 00000000

        /// <summary>
        /// The running state indicates that the runnable is currently running.
        /// </summary>
        Running = 1,    // 00000000 00000000 00000000 00000001

        /// <summary>
        /// The paused state indicates that the runnable has been paused(suspended). This requires the runnable to have been started at some point prior.
        /// </summary>
        Paused = 3,     // 00000000 00000000 00000000 00000011

        /// <summary>
        /// The stopping state indicates that the runnable has been requested to stop.
        /// </summary>
        Stopping = 4,   // 00000000 00000000 00000000 00000100

        /// <summary>
        /// The starting state indicates that the runnable has been requested to start.
        /// </summary>
        Starting = 5,   // 00000000 00000000 00000000 00000101
    }
}