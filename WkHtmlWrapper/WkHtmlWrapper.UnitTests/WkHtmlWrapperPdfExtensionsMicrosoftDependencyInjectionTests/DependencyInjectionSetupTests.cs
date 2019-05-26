using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using WkHtmlWrapper.Pdf.Converters;
using WkHtmlWrapper.Pdf.Converters.Interfaces;
using WkHtmlWrapper.Pdf.Extensions.Microsoft.DependencyInjection;

namespace WkHtmlWrapper.UnitTests.WkHtmlWrapperPdfExtensionsMicrosoftDependencyInjectionTests
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
        public void DependencyInjectionSetup_UseWkHtmlToPdfConverter_HtmlToPdfConverterResolved()
        {
            var provider = serviceCollection.UseWkHtmlToPdfConverter().BuildServiceProvider();

            var result = provider.GetRequiredService<IHtmlToPdfConverter>();

            result.Should().BeOfType<HtmlToPdfConverter>();
        }
    }
}