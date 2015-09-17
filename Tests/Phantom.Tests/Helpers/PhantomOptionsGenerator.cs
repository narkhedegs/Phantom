namespace Narkhedegs.Tests.Helpers
{
    public static class PhantomOptionsGenerator
    {
        public static PhantomOptions Default()
        {
            return new PhantomOptions
            {
                PhantomJsExecutableName = @"Data/Executable.exe",
                ExitTimeout = null
            };
        }

        public static PhantomOptions WithPhantomJsExecutableName(this PhantomOptions phantomOptions, string phantomJsExecutableName)
        {
            phantomOptions.PhantomJsExecutableName = phantomJsExecutableName;
            return phantomOptions;
        }

        public static PhantomOptions WithNullPhantomJsExecutableName(this PhantomOptions phantomOptions)
        {
            return phantomOptions.WithPhantomJsExecutableName(null);
        }

        public static PhantomOptions WithEmptyPhantomJsExecutableName(this PhantomOptions phantomOptions)
        {
            return phantomOptions.WithPhantomJsExecutableName(string.Empty);
        }

        public static PhantomOptions WithNonExistentPhantomJsExecutableName(this PhantomOptions phantomOptions)
        {
            return phantomOptions.WithPhantomJsExecutableName(@"Data/NonExistentExecutable.exe");
        }

        public static PhantomOptions WithWorkingDirectory(this PhantomOptions phantomOptions, string workingDirectory)
        {
            phantomOptions.WorkingDirectory = workingDirectory;
            return phantomOptions;
        }

        public static PhantomOptions WithNonExistentWorkingDirectory(this PhantomOptions phantomOptions)
        {
            return phantomOptions.WithWorkingDirectory(@"Data/NonExistentWorkingDirectory");
        }

        public static PhantomOptions WithExistentWorkingDirectory(this PhantomOptions phantomOptions)
        {
            return phantomOptions.WithWorkingDirectory(@"Data");
        }

        public static PhantomOptions WithExitTimeout(this PhantomOptions phantomOptions, int? exitTimeout)
        {
            phantomOptions.ExitTimeout = exitTimeout;
            return phantomOptions;
        }

        public static PhantomOptions WithEnvironmentVariable(this PhantomOptions phantomOptions, string key,
            string value)
        {
            phantomOptions.EnvironmentVariables.Add(key, value);
            return phantomOptions;
        }

        public static PhantomOptions WithScriptFilePath(this PhantomOptions phantomOptions, string scriptFilePath)
        {
            phantomOptions.ScriptFilePath = scriptFilePath;
            return phantomOptions;
        }

        public static PhantomOptions WithNonExistentScriptFilePath(this PhantomOptions phantomOptions)
        {
            return phantomOptions.WithScriptFilePath("Data/NonExistentScriptFile.js");
        }
    }
}
