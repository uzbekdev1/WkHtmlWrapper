using FluentAssertions;
using NUnit.Framework;
using WkHtmlWrapper.Core.Attributes;
using WkHtmlWrapper.Core.Extensions;
using WkHtmlWrapper.Core.Options.Interfaces;

namespace WkHtmlWrapper.UnitTests.WkHtmlWrapperCoreTests.ExtensionsTests
{
    [TestFixture]
    public class OptionsExtensionsTests
    {
        [Test]
        public void OptionsExtensions_OptionsToCommandLineParameters_IntegerProperty_DefaultValue_EmptyStringReturned()
        {
            var options = new OptionsWithOneProperty<int>();

            var result = options.OptionsToCommandLineParameters();

            result.Should().BeEmpty();
        }

        [Test]
        public void OptionsExtensions_OptionsToCommandLineParameters_IntegerProperty_ParameterNameWithValueReturned()
        {
            var options = new OptionsWithOneProperty<int> {Property = 42};

            var result = options.OptionsToCommandLineParameters();

            result.Should().Be("--property 42");
        }

        [Test]
        public void OptionsExtensions_OptionsToCommandLineParameters_BooleanProperty_DefaultValue_EmptyStringReturned()
        {
            var options = new OptionsWithOneProperty<bool>();

            var result = options.OptionsToCommandLineParameters();

            result.Should().BeEmpty();
        }

        [Test]
        public void OptionsExtensions_OptionsToCommandLineParameters_BooleanProperty_OnlyParameterNameReturned()
        {
            var options = new OptionsWithOneProperty<bool> {Property = true};

            var result = options.OptionsToCommandLineParameters();

            result.Should().Be("--property");
        }

        [Test]
        public void OptionsExtensions_OptionsToCommandLineParameters_StringProperty_EmptyString_EmptyStringReturned()
        {
            var options = new OptionsWithOneProperty<string>();

            var result = options.OptionsToCommandLineParameters();

            result.Should().BeEmpty();
        }

        [Test]
        public void OptionsExtensions_OptionsToCommandLineParameters_StringProperty_ParameterNameWithValueReturned()
        {
            var options = new OptionsWithOneProperty<string> {Property = "test"};

            var result = options.OptionsToCommandLineParameters();

            result.Should().Be("--property test");
        }

        [Test]
        public void OptionsExtensions_OptionsToCommandLineParameters_OptionsWithTwoProperty_ParametersNameWithValuesSeparatedBySpaceReturned()
        {
            var options = new OptionsWithTwoProperty
            {
                IntegerProperty = 42,
                StringProperty = "test"
            };

            var result = options.OptionsToCommandLineParameters();

            result.Should().Be("--stringProperty test --integerProperty 42");
        }

        private class OptionsWithOneProperty<TProperty> : IOptions
        {
            [ConsoleLineParameter("--property")]
            public TProperty Property { get; set; }
        }

        private class OptionsWithTwoProperty : IOptions
        {
            [ConsoleLineParameter("--stringProperty")]
            public string StringProperty { get; set; }

            [ConsoleLineParameter("--integerProperty")]
            public int IntegerProperty { get; set; }
        }
    }
}