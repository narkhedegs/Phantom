using System;
using NUnit.Framework;

namespace Narkhedegs.Tests
{
    [TestFixture]
    public class when_constructing_phantom_options_validator
    {
        [Test]
        public void it_should_throw_ArgumentNullException_if_scriptFilePathValidator_parameter_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => new PhantomOptionsValidator(null));
        }
    }
}
