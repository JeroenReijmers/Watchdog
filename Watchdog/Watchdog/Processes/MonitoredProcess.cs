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
    using System.IO;
    using System.Linq;
    using Eve.Diagnostics.Processes;

    public class MonitoredProcess : IDisposable
    {
        /// <summary>
        /// Flag to indicate if dispose method has already been called.
        /// </summary>
        private bool _disposed = false;

        private Process _process;

        public MonitoredProcess(string filePath)
        {
            var file = new FileInfo(filePath);

            if (file.Exists)
            {
                this.ProcessInfo = new ProcessStartInfo { FileName = file.Name, WorkingDirectory = file.DirectoryName };

                var process = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(file.Name))?.FirstOrDefault();

                if (process == null)
                {
                    process = new Process();
                    process.StartInfo = this.ProcessInfo;
                }

                this.Process = process;
            }
            else
            {
                throw new InvalidOperationException($"File at {file.FullName} does not exist.");
            }
        }

        public Process Process
        {
            get
            {
                return _process;
            }
            protected set
            {
                this.Process?.Dispose();
                _process = value;
            }
        }

        protected ProcessStartInfo ProcessInfo { get; set; }

        public virtual bool IsRunning()
        {
            return this.Process.IsRunning();
        }

        public virtual void Start()
        {
            this.Process.Start();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    this.Process?.Dispose();
                }

                _disposed = true;
            }
        }
    }
}