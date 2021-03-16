// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProcessExtension.cs">
//   All rights reserved.
// </copyright>
// <summary>
//   Contains extension methods for the System.Diagnostics.Process class.
// </summary>
// <author>Jeroen Reijmers</author>
// --------------------------------------------------------------------------------------------------------------------

namespace Eve.Diagnostics.Processes
{
    using System;
    using System.Diagnostics;

    /// <summary>
    ///   Contains extension methods for the <see cref="Process"/> class.
    /// </summary>
    public static class ProcessExtension
    {
        /// <summary>
        /// Check to see if the current process is running.
        /// </summary>
        /// <param name="process">The process to check.</param>
        /// <exception cref="PlatformNotSupportedException">The platform is Windows 98 or Windows Millennium Edition (Windows Me); set the <see cref="ProcessStartInfo.UseShellExecute"/> property to false to access this property on Windows 98 and Windows Me.</exception>
        /// <returns>A boolean value representing whether the process is currently running.</returns>
        public static bool IsRunning(this Process process)
        {
            if (process == null) throw new ArgumentNullException(nameof(process));

            try
            {
                if (Process.GetProcessById(process.Id) != null && !process.HasExited)
                {
                    return true;
                }
            }
            // an exception means the process was not running
            catch (InvalidOperationException)
            {
            }
            catch (ArgumentException)
            {
            }

            return false;
        }
    }
}