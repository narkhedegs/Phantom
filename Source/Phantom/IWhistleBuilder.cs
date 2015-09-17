namespace Narkhedegs
{
    /// <summary>
    /// Provides methods to build <see cref="Whistle"/>.
    /// </summary>
    internal interface IWhistleBuilder
    {
        /// <summary>
        /// Build <see cref="Whistle"/>. Assumes that the given <see cref="PhantomOptions"/> are already validated.
        /// </summary>
        /// <param name="phantomOptions"><see cref="PhantomOptions"/> to use while building <see cref="Whistle"/>.</param>
        /// <returns>
        /// Implementation of <see cref="IWhistle"/>.
        /// </returns>
        IWhistle Build(PhantomOptions phantomOptions);
    }
}
