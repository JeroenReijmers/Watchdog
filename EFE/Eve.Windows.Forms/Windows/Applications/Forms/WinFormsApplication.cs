// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WinFormsApplication.cs">
//   All rights reserved.
// </copyright>
// <summary>
//   
// </summary>
// <author>Jeroen Reijmers</author>
// --------------------------------------------------------------------------------------------------------------------

namespace Eve.Windows.Applications.Forms
{
    using System;
    using System.Windows.Forms;

    using Eve.Common.Applications;
    using Eve.Common.Applications.Base;
    using Eve.Common.Logging;

    public class WinFormsApplication : WinFormsApplication<ApplicationContext>, IRunnable, IDisposable
    {
        public WinFormsApplication(ILogger logger) : this(logger, new ApplicationContext())
        {
        }

        public WinFormsApplication(ILogger logger, ApplicationContext context) : base(logger, context)
        {
        }
    }

    public class WinFormsApplication<TContext> : ApplicationBase, IRunnable, IDisposable
        where TContext : System.Windows.Forms.ApplicationContext
    {
        /// <summary>
        /// Flag to indicate if dispose method has already been called.
        /// </summary>
        private bool _disposed = false;

        public WinFormsApplication(ILogger logger, TContext context) : base(logger)
        {
            this.Context = context;
        }

        public TContext Context { get; }

        public override void Run()
        {
            try
            {
                this.Logger.Log(Level.Information, @$"Application has started.");

                this.State = State.Running;

                Application.Run(this.Context);
            }
            catch (Exception ex)
            {
                this.Logger.Log(Level.Critical, @"Application encountered a fatal exception.", ex);
                throw;
            }
            finally
            {
                this.State = State.Stopped;
            }
        }

        public override void RequestStop()
        {
            this.Logger.Log(Level.Information, @$"Application has exiting.");

            this.State = State.Stopping;

            Application.Exit();
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

                    this.Context?.Dispose();
                }

                _disposed = true;
            }
        }
    }
}