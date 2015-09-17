using System;
using System.IO;

namespace Narkhedegs
{
    /// <summary>
    /// Provides methods to validate <see cref="PhantomOptions"/>.
    /// </summary>
    internal class PhantomOptionsValidator : IPhantomOptionsValidator
    {
        private readonly IScriptFilePathValidator _scriptFilePathValidator;

        /// <summary>
        /// Initializes a new instance of <see cref="PhantomOptionsValidator"/>.
        /// </summary>
        /// <param name="scriptFilePathValidator">Implementation of <see cref="IScriptFilePathValidator"/></param>
        public PhantomOptionsValidator(IScriptFilePathValidator scriptFilePathValidator)
        {
            if(scriptFilePathValidator == null)
                throw new ArgumentNullException(nameof(scriptFilePathValidator));

            _scriptFilePathValidator = scriptFilePathValidator;
        }

        /// <summary>
        /// Validates <see cref="PhantomOptions"/>. This method makes sure that - 
        /// <list type="number">
        ///     <item>
        ///         <description>
        ///         <see cref="PhantomOptions"/> object is not null.
        ///         </description>
        ///     </item> 
        ///     <item>
        ///         <description>
        ///         PhantomJsExecutableName is not null or empty and it is a valid and existing path.
        ///         </description>
        ///     </item>
        ///     <item>
        ///         <description>
        ///         If WorkingDirectory is not null or empty then it is a valid and existing path.
        ///         </description>
        ///     </item>  
        ///     <item>
        ///         <description>
        ///         The ExitTimeout is an integer value greater than zero.
        ///         </description>
        ///     </item>
        ///     <item>
        ///         <description>
        ///         If ScriptFilePath is not null or empty then it is a valid and existing path and the file specified by 
        ///         the ScriptFilePath property is a valid JavaScript file with .js extension.
        ///         </description>
        ///     </item> 
        /// </list>
        /// </summary>
        /// <param name="phantomOptions">
        /// <see cref="PhantomOptions"/> to be validated.
        /// </param>
        public void Validate(PhantomOptions phantomOptions)
        {
            if (phantomOptions == null)
                throw new ArgumentNullException(nameof(phantomOptions));

            if (string.IsNullOrWhiteSpace(phantomOptions.PhantomJsExecutableName))
                throw new ArgumentException("PhantomJsExecutableName cannot be null or empty.",
                    nameof(phantomOptions));

            if (!File.Exists(phantomOptions.PhantomJsExecutableName))
                throw new ArgumentException(
                    "Could not find the executable specified in the PhantomJsExecutableName. Please make sure that the executale exists at the path specified by the PhantomJsExecutableName and user has at least ReadOnly permission for the executable file.");

            if (!string.IsNullOrWhiteSpace(phantomOptions.WorkingDirectory) &&
                !Directory.Exists(phantomOptions.WorkingDirectory))
                throw new ArgumentException(
                    "Could not find directory specified in the WorkingDirectory. Please make sure that a directory exists at the path specified by the WorkingDirectory and user has at least ReadOnly permission for the directory.");

            if (phantomOptions.ExitTimeout != null && phantomOptions.ExitTimeout <= 0)
                throw new ArgumentException("ExitTimeout must be an integer value greater than zero.");

            _scriptFilePathValidator.Validate(phantomOptions.ScriptFilePath);
        }
    }
}
