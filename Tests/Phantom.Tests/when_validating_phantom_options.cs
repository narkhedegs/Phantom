using System;
using Moq;
using Narkhedegs.Tests.Helpers;
using NUnit.Framework;

namespace Narkhedegs.Tests
{
    [TestFixture]
    public class when_validating_phantom_options
    {
        private PhantomOptionsValidator _phantomOptionsValidator;
        private Mock<IScriptFilePathValidator> _scriptFilePathValidator;

        [SetUp]
        public void SetUp()
        {
            _scriptFilePathValidator = new Mock<IScriptFilePathValidator>();

            _phantomOptionsValidator = new PhantomOptionsValidator(_scriptFilePathValidator.Object);
        }

        [Test]
        public void it_should_throw_ArgumentNullException_if_phantomOptions_parameter_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => _phantomOptionsValidator.Validate(null));
        }

        [Test]
        public void it_should_throw_ArgumentException_if_PhantomJsExecutableName_option_is_null()
        {
            Assert.Throws<ArgumentException>(
                () =>
                    _phantomOptionsValidator.Validate(
                        PhantomOptionsGenerator.Default().WithNullPhantomJsExecutableName()));
        }

        [Test]
        public void it_should_throw_ArgumentException_if_PhantomJsExecutableName_option_is_empty()
        {
            Assert.Throws<ArgumentException>(
                () =>
                    _phantomOptionsValidator.Validate(
                        PhantomOptionsGenerator.Default().WithEmptyPhantomJsExecutableName()));
        }

        [Test]
        public void
            it_should_throw_ArgumentException_if_the_value_of_the_PhantomJsExecutableName_option_is_a_non_existent_path()
        {
            Assert.Throws<ArgumentException>(
                () =>
                    _phantomOptionsValidator.Validate(
                        PhantomOptionsGenerator.Default().WithNonExistentPhantomJsExecutableName()));
        }

        [Test]
        public void it_should_throw_ArgumentException_if_the_value_of_the_WorkingDirectory_option_is_a_non_existent_path
            ()
        {
            Assert.Throws<ArgumentException>(
                () =>
                    _phantomOptionsValidator.Validate(
                        PhantomOptionsGenerator.Default().WithNonExistentWorkingDirectory()));
        }

        [Test]
        public void it_should_throw_ArgumentException_if_the_value_of_the_ExitTimeout_option_is_zero()
        {
            Assert.Throws<ArgumentException>(
                () => _phantomOptionsValidator.Validate(PhantomOptionsGenerator.Default().WithExitTimeout(0)));
        }

        [Test]
        public void it_should_throw_ArgumentException_if_the_value_of_the_ExitTimeout_option_is_less_than_zero()
        {
            Assert.Throws<ArgumentException>(
                () => _phantomOptionsValidator.Validate(PhantomOptionsGenerator.Default().WithExitTimeout(-2)));
        }

        [Test]
        public void it_should_call_ScriptFilePathValidator_to_validate_ScriptFilePath_option()
        {
            _phantomOptionsValidator.Validate(PhantomOptionsGenerator.Default());

            _scriptFilePathValidator.Verify(validator => validator.Validate(It.IsAny<string>()), Times.Once);
        }
    }
}
