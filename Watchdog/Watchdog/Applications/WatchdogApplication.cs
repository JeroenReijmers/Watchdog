// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WatchdogApplication.cs">
//   All rights reserved.
// </copyright>
// <summary>
//   
// </summary>
// <author>Jeroen Reijmers</author>
// --------------------------------------------------------------------------------------------------------------------

namespace Watchdog.Applications
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Threading;

    using Eve.Common.Applications;
    using Eve.Common.Applications.Base;
    using Eve.Common.Logging;

    using global::Watchdog.Processes;

    public class WatchdogApplication : ApplicationBase
    {
        /// <summary>
        /// Flag to indicate if dispose method has already been called.
        /// </summary>
        private bool _disposed = false;

        public WatchdogApplication(ILogger logger, int interval, ICollection<string> processPaths) : base(logger)
        {
            this.Logger = logger;

            this.Processes = new List<MonitoredProcess>();

            this.Timer = new DispatcherTimer(DispatcherPriority.Background);
            this.Timer.Tick += this.Timer_Tick;
            this.Timer.Interval = new TimeSpan(0, 0, interval);

            this.Processes.Add(new SampleNotepadProcess());

            foreach (var filePath in processPaths)
            {
                try
                {
                    this.Processes.Add(new MonitoredProcess(filePath));
                }
                catch (InvalidOperationException ex)
                {
                    this.Logger.Log(Level.Error, "Error creating new MonitoredProcess.", ex);
                }
            }
        }

        private ICollection<MonitoredProcess> Processes { get; }

        private DispatcherTimer Timer { get; set; }

        public override void Run()
        {
            this.RunAllProcess();

            this.Timer.Start();

            this.State = State.Running;
        }

        public override void RequestStop()
        {
            this.Timer.Stop();

            this.State = State.Stopped;
        }

        protected void RunAllProcess()
        {
            foreach (var process in this.Processes)
            {
                this.TryRun(process);
            }
        }

        protected void TryRun(MonitoredProcess process)
        {
            try
            {
                if (!process.IsRunning())
                {
                    process.Start();
                }
            }
            catch (Exception ex)
            {
                this.Logger.Log(Level.Error, "Error attempting to start a MonitoredProcess.", ex);
            }
        }

        private async void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                this.RunAllProcess();
            }
            catch (Exception ex)
            {
                this.Logger.Log(Level.Error, "An exception occurred.", ex);
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // dispose

                    foreach (var process in this.Processes)
                    {
                        process?.Dispose();
                    }
                }

                _disposed = true;
            }
        }
    }
}