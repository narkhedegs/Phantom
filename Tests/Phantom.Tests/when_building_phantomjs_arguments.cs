using System.Linq;
using Moq;
using Narkhedegs.Tests.Helpers;
using NUnit.Framework;

namespace Narkhedegs.Tests
{
    [TestFixture]
    public class when_building_phantomjs_arguments
    {
        private PhantomJsArgumentsBuilder _phantomJsArgumentsBuilder;

        [SetUp]
        public void SetUp()
        {
            _phantomJsArgumentsBuilder = new PhantomJsArgumentsBuilder();
        }

        [Test]
        public void it_should_build_script_argument_from_ScriptFilePath_phantom_option()
        {
            var scriptFilePath = @"Data/JavaScript.js";
            var phantomOptions = PhantomOptionsGenerator.Default().WithScriptFilePath(scriptFilePath);

            var phantomJsArguments = _phantomJsArgumentsBuilder.Build(phantomOptions);

            Assert.That(phantomJsArguments.Contains(scriptFilePath));
        }
    }
}
