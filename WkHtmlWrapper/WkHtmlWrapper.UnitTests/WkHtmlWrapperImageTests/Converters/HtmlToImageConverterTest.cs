using System.IO;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using WkHtmlWrapper.Core.Services.Interfaces;
using WkHtmlWrapper.Image.Converters;
using WkHtmlWrapper.Image.Options;

namespace WkHtmlWrapper.UnitTests.WkHtmlWrapperImageTests.Converters
{
    [TestFixture]
    public class HtmlToImageConverterTest
    {
        private HtmlToImageConverter htmlToImageConverter;

        private Mock<IProcessService> processServiceMock;
        
        [SetUp]
        public void SetUp()
        {
            processServiceMock = new Mock<IProcessService>();
            htmlToImageConverter = new HtmlToImageConverter(processServiceMock.Object);
        }

        [Test]
        public async Task HtmlToImageConverter_ConvertAsync_HtmlFromText_ImageMatchedWithStandard()
        {
            var html = "<html><body><h1>Hello world!</h1></body></html>";

            await htmlToImageConverter.ConvertAsync(html, "converted.png");

            processServiceMock.Verify(s => s.StartAsync(It.Is<string>(f => f.Contains("image.")),
                It.Is<string>(a => a.Contains("converted.png"))));
        }

        [Test]
        public async Task HtmlToImageConverter_ConvertAsync_HtmlFromTextWithOptions_ImageMatchedWithStandard()
        {
            var html = "<html><body><h1>Hello world!</h1></body></html>";

            await htmlToImageConverter.ConvertAsync(html, "converted.png", new GeneralImageOptions());

            processServiceMock.Verify(s => s.StartAsync(It.Is<string>(f => f.Contains("image.")),
                It.Is<string>(a => a.Contains("converted.png"))));
        }

        [Test]
        public async Task HtmlToImageConverter_ConvertAsync_HtmlFromStream_ImageMatchedWithStandard()
        {
            using (var html = new MemoryStream(Encoding.UTF8.GetBytes("<html><body><h1>Hello world!</h1></body></html>")))
            {
                await htmlToImageConverter.ConvertAsync(html, "converted.png");

                processServiceMock.Verify(s => s.StartAsync(It.Is<string>(f => f.Contains("image.")),
                    It.Is<string>(a => a.Contains("converted.png"))));
            }
        }

        [Test]
        public async Task HtmlToImageConverter_ConvertAsync_HtmlFromStreamWithOptions_ImageMatchedWithStandard()
        {
            using (var html = new MemoryStream(Encoding.UTF8.GetBytes("<html><body><h1>Hello world!</h1></body></html>")))
            {
                await htmlToImageConverter.ConvertAsync(html, "converted.png", new GeneralImageOptions());

                processServiceMock.Verify(s => s.StartAsync(It.Is<string>(f => f.Contains("image.")),
                    It.Is<string>(a => a.Contains("converted.png"))));
            }
        }
    }
}