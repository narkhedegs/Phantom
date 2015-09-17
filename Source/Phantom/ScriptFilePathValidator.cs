using System;
using System.IO;

namespace Narkhedegs
{
    /// <summary>
    /// Provides methods to validate ScriptFilePath property of <see cref="PhantomOptions"/>.
    /// </summary>
    internal class ScriptFilePathValidator : IScriptFilePathValidator
    {
        /// <summary>
        /// Validate ScriptFilePath property of <see cref="PhantomOptions"/>. This method makes sure that - 
        /// <list type="number">
        ///     <item>
        ///         <description>
        ///         If ScriptFilePath is not null or empty then it is a valid and existing path and the file specified by 
        ///         the ScriptFilePath property is a valid JavaScript file with .js extension.
        ///         </description>
        ///     </item> 
        /// </list>
        /// </summary>
        /// <param name="scriptFilePath">Script file path to be validated.</param>
        public void Validate(string scriptFilePath)
        {
            if (!string.IsNullOrWhiteSpace(scriptFilePath))
            {
                if (!File.Exists(scriptFilePath))
                {
                    throw new ArgumentException(
                        "Could not find the JavaScript file specified in the ScriptFilePath property. Please make sure that the JavaScript file exists at the path specified by the ScriptFilePath and user has at least ReadOnly permission for the JavaScript file.");
                }

                if (!string.Equals(Path.GetExtension(scriptFilePath), ".js",
                    StringComparison.CurrentCultureIgnoreCase))
                {
                    throw new ArgumentException(
                        "The file specified in the ScriptFilePath property must be a valid JavaScript file.");
                }
            }
        }
    }
}
