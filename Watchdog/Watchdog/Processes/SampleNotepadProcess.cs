// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MonitoredProcess.cs">
//   All rights reserved.
// </copyright>
// <summary>
//   
// </summary>
// <author>Jeroen Reijmers</author>
// --------------------------------------------------------------------------------------------------------------------

namespace Watchdog.Processes
{
    using System;
    using System.Diagnostics;

    using global::Watchdog.Helpers;

    public class SampleNotepadProcess : MonitoredProcess, IDisposable
    {
        private static readonly string _notepadFilePath = @$"{Environment.GetFolderPath(Environment.SpecialFolder.Windows)}\system32\notepad.exe";

        public SampleNotepadProcess() : base(_notepadFilePath)
        {
            this.Process = new Process();
            this.Process.StartInfo = this.ProcessInfo;
        }

        public override void Start()
        {
            this.Process = new Process { StartInfo = this.ProcessInfo };
            this.Process.Start();

            NotepadHelper.ShowMessage(this.Process, "J. Reijmers Sample Project is running", "Jeroen Reijmers");
        }
    }
}