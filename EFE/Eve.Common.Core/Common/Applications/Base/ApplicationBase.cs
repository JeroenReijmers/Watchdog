// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationBase.cs">
//   All rights reserved.
// </copyright>
// <summary>
//   
// </summary>
// <author>Jeroen Reijmers</author>
// --------------------------------------------------------------------------------------------------------------------

namespace Eve.Common.Applications.Base
{
    using System;

    using Eve.Common.Applications;
    using Eve.Common.Logging;

    public abstract class ApplicationBase : IRunnable
    {
        private ILogger _logger;

        protected ApplicationBase(ILogger logger)
        {
            this.Logger = logger;

            this.State = State.Off;
        }

        public State State { get; set; }

        protected ILogger Logger
        {
            get
            {
                return _logger;
            }
            set
            {
                _logger = value;
            }
        }

        public abstract void Run();

        public abstract void RequestStop();
    }
}