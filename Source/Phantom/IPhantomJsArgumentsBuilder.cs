using System.Collections.Generic;

namespace Narkhedegs
{
    /// <summary>
    /// Provides methods to build command line arguments for PhantomJs binary from <see cref="PhantomOptions"/>.
    /// </summary>
    internal interface IPhantomJsArgumentsBuilder
    {
        /// <summary>
        /// Builds command line arguments for PhantomJs binary from the given <see cref="PhantomOptions"/>. 
        /// PhantomJsArgumentsBuilder assumes that the given <see cref="PhantomOptions"/> are already validated.
        /// </summary>
        /// <param name="phantomOptions">Given <see cref="PhantomOptions"/></param>
        /// <returns>
        /// Command line arguments for PhantomJs binary
        /// </returns>
        IEnumerable<string> Build(PhantomOptions phantomOptions);
    }
}
