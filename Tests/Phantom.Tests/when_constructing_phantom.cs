using System;
using Moq;
using Narkhedegs.Tests.Helpers;
using NUnit.Framework;

namespace Narkhedegs.Tests
{
    [TestFixture]
    public class when_constructing_phantom
    {
        private PhantomOptions _phantomOptions;
        private Mock<IPhantomOptionsValidator> _phantomOptionsValidator;
        private Mock<IWhistleBuilder> _whistleBuilder;
        private Mock<IScriptFilePathValidator> _scriptFilePathValidator;

        [SetUp]
        public void SetUp()
        {
            _phantomOptions = PhantomOptionsGenerator.Default();

            _phantomOptionsValidator = new Mock<IPhantomOptionsValidator>();
            _phantomOptionsValidator.Setup(validator => validator.Validate(It.IsAny<PhantomOptions>()));

            _scriptFilePathValidator = new Mock<IScriptFilePathValidator>();
            _whistleBuilder = new Mock<IWhistleBuilder>();
        }

        [Test]
        public void it_should_throw_ArgumentNullException_if_phantomOptionsValidator_parameter_is_null()
        {
            Assert.Throws<ArgumentNullException>(
                () => new Phantom(_phantomOptions, null, _scriptFilePathValidator.Object, _whistleBuilder.Object));
        }

        [Test]
        public void it_should_throw_ArgumentNullException_if_scriptFilePathValidator_parameter_is_null()
        {
            Assert.Throws<ArgumentNullException>(
                () => new Phantom(_phantomOptions, _phantomOptionsValidator.Object, null, _whistleBuilder.Object));
        }

        [Test]
        public void it_should_throw_ArgumentNullException_if_whistleBuilder_parameter_is_null()
        {
            Assert.Throws<ArgumentNullException>(
                () =>
                    new Phantom(_phantomOptions, _phantomOptionsValidator.Object, _scriptFilePathValidator.Object, null));
        }

        [Test]
        public void it_should_call_PhantomOptionsValidator_to_validate_phantom_options()
        {
            var phantom = new Phantom(_phantomOptions, _phantomOptionsValidator.Object, _scriptFilePathValidator.Object,
                _whistleBuilder.Object);

            _phantomOptionsValidator.Verify(validator => validator.Validate(It.IsAny<PhantomOptions>()), Times.Once);
        }
    }
}
