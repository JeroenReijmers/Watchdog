// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Watchdog.cs">
//   All rights reserved.
// </copyright>
// <summary>
//   
// </summary>
// <author>Jeroen Reijmers</author>
// --------------------------------------------------------------------------------------------------------------------

namespace Watchdog
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using Eve.Diagnostics.Processes;
    using global::Watchdog.Helpers;

    public class Watchdog
    {
        public Watchdog(string filePath)
        {
            var file = new FileInfo(filePath);

            if (file.Exists)
            {
                this.Process = new Process();

                this.ProcessInfo = new ProcessStartInfo { FileName = file.Name, WorkingDirectory = file.DirectoryName };

                this.Process.StartInfo = this.ProcessInfo;
            }
            else
            {
                throw new InvalidOperationException($"File at {file.FullName} does not exist.");
            }
        }

        public ProcessStartInfo ProcessInfo { get; set; }

        public Process Process { get; set; }

        public void StartApplication()
        {
            if (!this.Process.IsRunning())
            {
                this.Process = new Process { StartInfo = this.ProcessInfo };

                this.Process.Start();

                NotepadHelper.ShowMessage(this.Process, "J. Reijmers Sample Project is running", "Jeroen Reijmers");
            }
        }
    }
}