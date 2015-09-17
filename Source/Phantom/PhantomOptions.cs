using System.Collections.Generic;

namespace Narkhedegs
{
    /// <summary>
    /// Options that can be passed to <see cref="Phantom"/>. PhantomOptions encapsulate command line options for PhantomJS 
    /// binary.
    /// </summary>
    public class PhantomOptions
    {
        /// <summary>
        /// Creates a new instance of <see cref="PhantomOptions"/> class. 
        /// By default - 
        ///     PhantomJsExecutableName = "phantomjs.exe" and <see cref="Phantom"/> assumes that the phatomjs.exe file is present in the current directory
        /// </summary>
        public PhantomOptions()
        {
            PhantomJsExecutableName = "phantomjs.exe";
            EnvironmentVariables = new Dictionary<string, string>();
        }

        /// <summary>
        /// Gets or sets the PhantomJs executable to start. The PhantomJsExecutableName could be simply phantomjs.exe or 
        /// it could be a path, absolute or relative. For example /path/to/your/phantomjs.exe or 
        /// C:\path\to\your\phantomjs.exe. If nothing is provided the the default value is phantomjs.exe and 
        /// <see cref="Phantom"/> assumes that the phatomjs.exe file is present in the current directory.
        /// </summary>
        public string PhantomJsExecutableName { get; set; }

        /// <summary>
        /// Gets or sets the working directory for the phantomjs executable to be started. If nothing is specified then the default value 
        /// for WorkingDirectory is the Current Directory.
        /// </summary>
        public string WorkingDirectory { get; set; }

        /// <summary>
        /// ExitTimeout is time in milliseconds for which Phantom will wait for the phantomjs executable to exit. If the 
        /// phantomjs executable exceeds the ExitTimeout then Phantom will terminate the executable and raise TimeoutException.
        /// If ExitTimeout is null or is not specified then the default value for ExitTimeout is infinity <see cref="System.Threading.Timeout.Infinite"/>.
        /// </summary>
        public int? ExitTimeout { get; set; }

        /// <summary>
        /// A string dictionary that provides environment variables that apply to the phantomjs executable and child processes. 
        /// </summary>
        public Dictionary<string, string> EnvironmentVariables { get; set; }

        /// <summary>
        /// Path to a JavaScript file. The script code will be executed as if it running in a web browser with an empty page. 
        /// Since PhantomJS is headless, there will not be anything visible shown up on the screen.
        /// </summary>
        public string ScriptFilePath { get; set; }
    }
}
