// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoggerBase.cs">
//   All rights reserved.
// </copyright>
// <summary>
//   
// </summary>
// <author>Jeroen Reijmers</author>
// --------------------------------------------------------------------------------------------------------------------

namespace Eve.Common.Logging.Base
{
    using System;

    public abstract class LoggerBase : ILogger
    {
        public abstract bool IsEnabledFor(Level logLevel);

        public virtual void Log(Level logLevel, int eventId, params object[] args)
        {
            this.Log(logLevel, eventId, null, null, args);
        }

        public virtual void Log(Level logLevel, string message, params object[] args)
        {
            this.Log(logLevel, message, null, args);
        }

        public virtual void Log(Level logLevel, Exception exception, params object[] args)
        {
            this.Log(logLevel, null, exception, args);
        }

        public virtual void Log(Level logLevel, int eventId, string message, params object[] args)
        {
            this.Log(logLevel, eventId, message, null, args);
        }

        public virtual void Log(Level logLevel, int eventId, Exception exception, params object[] args)
        {
            this.Log(logLevel, eventId, null, exception, args);
        }

        public abstract void Log(Level logLevel, string message, Exception exception, params object[] args);

        public abstract void Log(Level logLevel, int eventId, string message, Exception exception, params object[] args);
    }
}