// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRunnable.cs">
//   All rights reserved.
// </copyright>
// <summary>
//   The base interface to any runnable EFE class.
// </summary>
// <author>Jeroen Reijmers</author>
// --------------------------------------------------------------------------------------------------------------------

namespace Eve.Common.Applications
{
    /// <summary>
    /// Represents the base interface to any runnable EFE class.
    /// </summary>
    public interface IRunnable
    {
        /// <summary>
        /// Gets the <see cref="State"/> of the runnable.
        /// </summary>
        State State { get; }

        /// <summary>
        /// Request that the runnable starts itself.
        /// </summary>
        void Run();

        /// <summary>
        /// Request that the runnable stop(kill) itself.
        /// </summary>
        void RequestStop();
    }
}