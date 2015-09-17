using System;
using Moq;
using NUnit.Framework;

namespace Narkhedegs.Tests
{
    [TestFixture]
    public class when_constructing_whistle_builder
    {
        private Mock<IPhantomJsArgumentsBuilder> _phantomJsArgumentsBuilder;

        [SetUp]
        public void SetUp()
        {
            _phantomJsArgumentsBuilder = new Mock<IPhantomJsArgumentsBuilder>();
        }

        [Test]
        public void it_should_throw_ArgumentNullException_if_phantomJsArgumentsBuilder_parameter_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => new WhistleBuilder(null));
        }
    }
}
