using System.IO;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using WkHtmlWrapper.Converters;
using WkHtmlWrapper.Core.Services.Interfaces;
using WkHtmlWrapper.Image.Options;
using WkHtmlWrapper.Pdf.Options;

namespace WkHtmlWrapper.UnitTests.WkHtmlWrapperTests.Converters
{
    [TestFixture]
    public class HtmlConverterTests
    {
        private HtmlConverter htmlConverter;

        private Mock<IProcessService> processServiceMock;

        [SetUp]
        public void SetUp()
        {
            processServiceMock = new Mock<IProcessService>();
            htmlConverter = new HtmlConverter(processServiceMock.Object);
        }

        [Test]
        public async Task HtmlConverter_ToPdfAsync_HtmlFromText_PdfMatchedWithStandard()
        {
            var html = "<html><body><h1>Hello world!</h1></body></html>";

            await htmlConverter.ToPdfAsync(html, "converted.pdf");

            processServiceMock.Verify(s => s.StartAsync(It.Is<string>(f => f.Contains("pdf.")),
                It.Is<string>(a => a.Contains("converted.pdf"))));
        }

        [Test]
        public async Task HtmlConverter_ToPdfAsync_HtmlFromTextWithOptions_PdfMatchedWithStandard()
        {
            var html = "<html><body><h1>Hello world!</h1></body></html>";

            await htmlConverter.ToPdfAsync(html, "converted.pdf", new GeneralPdfOptions());

            processServiceMock.Verify(s => s.StartAsync(It.Is<string>(f => f.Contains("pdf.")),
                It.Is<string>(a => a.Contains("converted.pdf"))));
        }

        [Test]
        public async Task HtmlConverter_ToPdfAsync_HtmlFromStream_PdfMatchedWithStandard()
        {
            using (var html = new MemoryStream(Encoding.UTF8.GetBytes("<html><body><h1>Hello world!</h1></body></html>")))
            {
                await htmlConverter.ToPdfAsync(html, "converted.pdf");

                processServiceMock.Verify(s => s.StartAsync(It.Is<string>(f => f.Contains("pdf.")),
                    It.Is<string>(a => a.Contains("converted.pdf"))));
            }
        }

        [Test]
        public async Task HtmlConverter_ToPdfAsync_HtmlFromStreamWithOptions_PdfMatchedWithStandard()
        {
            using (var html = new MemoryStream(Encoding.UTF8.GetBytes("<html><body><h1>Hello world!</h1></body></html>")))
            {
                await htmlConverter.ToPdfAsync(html, "converted.pdf", new GeneralPdfOptions());

                processServiceMock.Verify(s => s.StartAsync(It.Is<string>(f => f.Contains("pdf.")),
                    It.Is<string>(a => a.Contains("converted.pdf"))));
            }
        }

        [Test]
        public async Task HtmlConverter_ToImageAsync_HtmlFromText_ImageMatchedWithStandard()
        {
            var html = "<html><body><h1>Hello world!</h1></body></html>";

            await htmlConverter.ToImageAsync(html, "converted.png");

            processServiceMock.Verify(s => s.StartAsync(It.Is<string>(f => f.Contains("image.")),
                It.Is<string>(a => a.Contains("converted.png"))));
        }

        [Test]
        public async Task HtmlConverter_ToImageAsync_HtmlFromTextWithOptions_ImageMatchedWithStandard()
        {
            var html = "<html><body><h1>Hello world!</h1></body></html>";

            await htmlConverter.ToImageAsync(html, "converted.png", new GeneralImageOptions());

            processServiceMock.Verify(s => s.StartAsync(It.Is<string>(f => f.Contains("image.")),
                It.Is<string>(a => a.Contains("converted.png"))));
        }

        [Test]
        public async Task HtmlConverter_ToImageAsync_HtmlFromStream_ImageMatchedWithStandard()
        {
            using (var html = new MemoryStream(Encoding.UTF8.GetBytes("<html><body><h1>Hello world!</h1></body></html>")))
            {
                await htmlConverter.ToImageAsync(html, "converted.png");

                processServiceMock.Verify(s => s.StartAsync(It.Is<string>(f => f.Contains("image.")),
                    It.Is<string>(a => a.Contains("converted.png"))));
            }
        }

        [Test]
        public async Task HtmlConverter_ToImageAsync_HtmlFromStreamWithOptions_ImageMatchedWithStandard()
        {
            using (var html = new MemoryStream(Encoding.UTF8.GetBytes("<html><body><h1>Hello world!</h1></body></html>")))
            {
                await htmlConverter.ToImageAsync(html, "converted.png", new GeneralImageOptions());

                processServiceMock.Verify(s => s.StartAsync(It.Is<string>(f => f.Contains("image.")),
                    It.Is<string>(a => a.Contains("converted.png"))));
            }
        }
    }
}