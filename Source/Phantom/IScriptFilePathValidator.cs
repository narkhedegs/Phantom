namespace Narkhedegs
{
    /// <summary>
    /// Provides methods to validate ScriptFilePath property of <see cref="PhantomOptions"/>.
    /// </summary>
    internal interface IScriptFilePathValidator
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
        void Validate(string scriptFilePath);
    }
}
