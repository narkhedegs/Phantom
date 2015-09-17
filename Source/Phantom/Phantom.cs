using System;

namespace Narkhedegs
{
    /// <summary>
    /// Provides methods to execute PhantomJs binary from within a .NET process.
    /// </summary>
    public class Phantom : IPhantom
    {
        private PhantomOptions _phantomOptions;
        private readonly IScriptFilePathValidator _scriptFilePathValidator;
        private IWhistleBuilder _whistleBuilder;

        /// <summary>
        /// Initializes a new instance of <see cref="Phantom"/> with the given <see cref="PhantomOptions"/>.
        /// </summary>
        /// <param name="phantomOptions">Options that can be passed to <see cref="Phantom"/> to change its behaviour.</param>
        /// <param name="phantomOptionsValidator">Implementation of <see cref="IPhantomOptionsValidator"/></param>
        /// <param name="scriptFilePathValidator">Implementation of <see cref="IScriptFilePathValidator"/></param>
        /// <param name="whistleBuilder">Implementation of <see cref="IWhistleBuilder"/></param>
        internal Phantom(
            PhantomOptions phantomOptions, 
            IPhantomOptionsValidator phantomOptionsValidator,
            IScriptFilePathValidator scriptFilePathValidator,
            IWhistleBuilder whistleBuilder)
        {
            if (phantomOptionsValidator == null)
                throw new ArgumentNullException(nameof(phantomOptionsValidator));

            if (scriptFilePathValidator == null)
                throw new ArgumentNullException(nameof(scriptFilePathValidator));

            if (whistleBuilder == null)
                throw new ArgumentNullException(nameof(whistleBuilder));

            phantomOptionsValidator.Validate(phantomOptions);

            _phantomOptions = phantomOptions;
            _scriptFilePathValidator = scriptFilePathValidator;
            _whistleBuilder = whistleBuilder;
        }
    }
}
