using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using WkHtmlWrapper.Image.Converters;
using WkHtmlWrapper.Image.Converters.Interfaces;
using WkHtmlWrapper.Image.Extensions.Microsoft.DependencyInjection;

namespace WkHtmlWrapper.UnitTests.WkHtmlWrapperImageExtensionsMicrosoftDependencyInjectionTests
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
        public void DependencyInjectionSetup_UseWkHtmlToImageConverter_HtmlToImageConverterResolved()
        {
            var provider = serviceCollection.UseWkHtmlToImageConverter().BuildServiceProvider();

            var result = provider.GetRequiredService<IHtmlToImageConverter>();

            result.Should().BeOfType<HtmlToImageConverter>();
        }
    }
}