namespace Narkhedegs
{
    /// <summary>
    /// Provides methods to validate <see cref="PhantomOptions"/>.
    /// </summary>
    internal interface IPhantomOptionsValidator
    {
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
        void Validate(PhantomOptions phantomOptions);
    }
}
