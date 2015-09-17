using System;

namespace Narkhedegs
{
    /// <summary>
    /// Provides methods to build <see cref="Whistle"/>.
    /// </summary>
    internal class WhistleBuilder : IWhistleBuilder
    {
        private readonly IPhantomJsArgumentsBuilder _phantomJsArgumentsBuilder;

        /// <summary>
        /// Initializes a new instance of <see cref="WhistleBuilder"/>.
        /// </summary>
        public WhistleBuilder(IPhantomJsArgumentsBuilder phantomJsArgumentsBuilder)
        {
            if(phantomJsArgumentsBuilder == null)
                throw new ArgumentNullException(nameof(phantomJsArgumentsBuilder));

            _phantomJsArgumentsBuilder = phantomJsArgumentsBuilder;
        }

        /// <summary>
        /// Build <see cref="Whistle"/>.
        /// </summary>
        /// <param name="phantomOptions"><see cref="PhantomOptions"/> to use while building <see cref="Whistle"/>.</param>
        /// <returns>
        /// Implementation of <see cref="IWhistle"/>.
        /// </returns>
        public IWhistle Build(PhantomOptions phantomOptions)
        {
            var whistleOptions = new WhistleOptions
            {
                ExecutableName = phantomOptions.PhantomJsExecutableName,
                EnvironmentVariables = phantomOptions.EnvironmentVariables,
                ExitTimeout = phantomOptions.ExitTimeout,
                WorkingDirectory = phantomOptions.WorkingDirectory,
                Arguments = _phantomJsArgumentsBuilder.Build(phantomOptions)
            };

            return new Whistle(whistleOptions);
        }
    }
}
