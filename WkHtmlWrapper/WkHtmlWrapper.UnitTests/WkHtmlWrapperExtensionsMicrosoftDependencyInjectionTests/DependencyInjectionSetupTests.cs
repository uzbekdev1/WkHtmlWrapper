using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using WkHtmlWrapper.Converters;
using WkHtmlWrapper.Converters.Interfaces;
using WkHtmlWrapper.Extensions.Microsoft.DependencyInjection;
using WkHtmlWrapper.Image.Converters;
using WkHtmlWrapper.Image.Converters.Interfaces;
using WkHtmlWrapper.Pdf.Converters;
using WkHtmlWrapper.Pdf.Converters.Interfaces;

namespace WkHtmlWrapper.UnitTests.WkHtmlWrapperExtensionsMicrosoftDependencyInjectionTests
{
    [TestFixture]
    public class DependencyInjectionSetupTests
    {
        private IServiceCollection serviceCollection;

        [SetUp]
        public void SetUp()
        {
            serviceCollection = new ServiceCollection();
        }

        [Test]
        public void DependencyInjectionSetup_UseWkHtmlConverter_HtmlConverterResolved()
        {
            var provider = serviceCollection.UseWkHtmlConverter().BuildServiceProvider();

            var result = provider.GetRequiredService<IHtmlConverter>();

            result.Should().BeOfType<HtmlConverter>();
        }

        [Test]
        public void DependencyInjectionSetup_UseWkHtmlConverter_HtmlToImageConverterResolved()
        {
            var provider = serviceCollection.UseWkHtmlConverter().BuildServiceProvider();

            var result = provider.GetRequiredService<IHtmlToImageConverter>();

            result.Should().BeOfType<HtmlToImageConverter>();
        }

        [Test]
        public void DependencyInjectionSetup_UseWkHtmlConverter_HtmlToPdfConverterResolved()
        {
            var provider = serviceCollection.UseWkHtmlConverter().BuildServiceProvider();

            var result = provider.GetRequiredService<IHtmlToPdfConverter>();

            result.Should().BeOfType<HtmlToPdfConverter>();
        }
    }
}