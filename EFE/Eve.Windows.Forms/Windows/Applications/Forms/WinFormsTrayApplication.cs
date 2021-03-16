// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WinFormsTrayApplication.cs">
//   All rights reserved.
// </copyright>
// <summary>
//   A tray application is a gui-less application that lives on the notification area of the windows taskbar.
// </summary>
// <author>Jeroen Reijmers</author>
// --------------------------------------------------------------------------------------------------------------------

namespace Eve.Windows.Forms
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    using Eve.Common.Applications;
    using Eve.Common.Logging;
    using Eve.Windows.Applications.Forms;

    public class WinFormsTrayApplication : WinFormsTrayApplication<ApplicationContext>, IRunnable, IDisposable
    {
        public WinFormsTrayApplication(ILogger logger, Icon icon) : this(logger, new ApplicationContext(), icon)
        {
        }

        public WinFormsTrayApplication(ILogger logger, ApplicationContext context, Icon icon) : base(logger, context, icon)
        {
        }
    }

    public class WinFormsTrayApplication<TContext> : WinFormsApplication<TContext>, IRunnable, IDisposable
        where TContext : System.Windows.Forms.ApplicationContext
    {
        /// <summary>
        /// Flag to indicate if dispose method has already been called.
        /// </summary>
        private bool _disposed = false;

        public WinFormsTrayApplication(ILogger logger, TContext context, Icon icon) : base(logger, context)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            this.TrayIcon = new NotifyIcon()
            {
                Icon = icon,
                ContextMenuStrip = new ContextMenuStrip(),
                Visible = false
            };

            this.AddContextItem("Exit", null, this.Application_Exit);
        }

        protected NotifyIcon TrayIcon { get; }

        public void AddContextItem(string text, Image image, EventHandler onClick)
        {
            this.TrayIcon.ContextMenuStrip.Items.Add(text, image, onClick);
        }

        public override void Run()
        {
            this.TrayIcon.Visible = true;

            base.Run();
        }

        public override void RequestStop()
        {
            // Hide tray icon, otherwise it will remain shown until user mouses over it
            this.TrayIcon.Visible = false;

            base.RequestStop();
        }

        protected virtual async void Application_Exit(object sender, EventArgs e)
        {
            this.RequestStop();
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    this.TrayIcon?.Dispose();
                }

                _disposed = true;

                base.Dispose(disposing);
            }
        }
    }
}