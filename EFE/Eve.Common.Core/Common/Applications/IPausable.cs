// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPausable.cs">
//   All rights reserved.
// </copyright>
// <summary>
//   The base interface to any pausable EFE class.
// </summary>
// <author>Jeroen Reijmers</author>
// --------------------------------------------------------------------------------------------------------------------

namespace Eve.Common.Applications
{
    /// <summary>
    /// Represents the base interface to any pausable EFE class.
    /// </summary>
    public interface IPausable : IRunnable
    {
        /// <summary>
        /// Request that the runnable pause(suspend) itself.
        /// </summary>
        void RequestPause();

        /// <summary>
        /// Request that the runnable unpause(resume) itself.
        /// </summary>
        void RequestUnpause();
    }
}