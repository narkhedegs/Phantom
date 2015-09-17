using System;
using Narkhedegs.Tests.Helpers;
using NUnit.Framework;

namespace Narkhedegs.Tests
{
    [TestFixture]
    public class when_validating_script_file_path
    {
        private ScriptFilePathValidator _scriptFilePathValidator;

        [SetUp]
        public void SetUp()
        {
            _scriptFilePathValidator = new ScriptFilePathValidator();
        }

        [Test]
        public void it_should_throw_ArgumentException_if_the_value_of_the_ScriptFilePath_option_is_a_non_existent_path()
        {
            Assert.Throws<ArgumentException>(
                () =>
                    _scriptFilePathValidator.Validate(@"Data/NonExistentScriptFile.js"));
        }

        [Test]
        public void it_should_throw_ArgumentException_if_the_value_of_the_ScriptFilePath_option_is_not_a_JavaScript_file()
        {
            Assert.Throws<ArgumentException>(
                () =>
                    _scriptFilePathValidator.Validate(@"Data/NotAJavaScriptFile.txt"));
        }

    }
}
