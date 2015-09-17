using Moq;
using Narkhedegs.Tests.Helpers;
using NUnit.Framework;

namespace Narkhedegs.Tests
{
    [TestFixture]
    public class when_building_whistle
    {
        private Mock<IPhantomJsArgumentsBuilder> _phantomJsArgumentsBuilder;
        private WhistleBuilder _whistleBuilder;

        [SetUp]
        public void SetUp()
        {
            _phantomJsArgumentsBuilder = new Mock<IPhantomJsArgumentsBuilder>();

            _whistleBuilder = new WhistleBuilder(_phantomJsArgumentsBuilder.Object);
        }

        [Test]
        public void it_should_call_PhantomJsArgumentsBuilder_to_build_arguments_for_phantomjs_binary()
        {
            _whistleBuilder.Build(PhantomOptionsGenerator.Default());

            _phantomJsArgumentsBuilder.Verify(argumentsBuilder => argumentsBuilder.Build(It.IsAny<PhantomOptions>()),
                Times.Once);
        }
    }
}
