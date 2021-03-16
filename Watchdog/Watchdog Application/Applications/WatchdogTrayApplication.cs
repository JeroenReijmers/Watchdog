// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WatchdogTrayApplication.cs">
//   All rights reserved.
// </copyright>
// <summary>
//   
// </summary>
// <author>Jeroen Reijmers</author>
// --------------------------------------------------------------------------------------------------------------------

namespace Watchdog.Applications
{
    using System.Collections.Generic;
    using System.Drawing;

    using Eve.Common.Logging;
    using Eve.Windows.Forms;

    public class WatchdogTrayApplication : WinFormsTrayApplication
    {
        private static readonly Icon _icon = Properties.Resources.Watchdog;
        private static readonly int _interval = 10;
        private static readonly ICollection<string> _processPaths = new List<string>();

        public WatchdogTrayApplication(ILogger logger) : base(logger, _icon)
        {
            this.WatchdogApplication = new WatchdogApplication(this.Logger, _interval, _processPaths);
        }

        private WatchdogApplication WatchdogApplication { get; }

        public override void Run()
        {
            this.WatchdogApplication.Run();

            base.Run();
        }

        public override void RequestStop()
        {
            this.WatchdogApplication.RequestStop();

            base.RequestStop();
        }
    }
}