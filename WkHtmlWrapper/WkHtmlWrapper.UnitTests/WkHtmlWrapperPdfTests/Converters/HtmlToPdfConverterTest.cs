using System.IO;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using WkHtmlWrapper.Core.Services.Interfaces;
using WkHtmlWrapper.Pdf.Converters;
using WkHtmlWrapper.Pdf.Options;

namespace WkHtmlWrapper.UnitTests.WkHtmlWrapperPdfTests.Converters
{
    [TestFixture]
    public class HtmlToPdfConverterTest
    {
        private HtmlToPdfConverter htmlToPdfConverter;

        private Mock<IProcessService> processServiceMock;

        [SetUp]
        public void SetUp()
        {
            processServiceMock = new Mock<IProcessService>();
            htmlToPdfConverter = new HtmlToPdfConverter(processServiceMock.Object);
        }
        
        [Test]
        public async Task HtmlToPdfConverter_ConvertAsync_HtmlFromText_PdfMatchedWithStandard()
        {
            var html = "<html><body><h1>Hello world!</h1></body></html>";

            await htmlToPdfConverter.ConvertAsync(html, "converted.pdf");

            processServiceMock.Verify(s => s.StartAsync(It.Is<string>(f => f.Contains("pdf.")),
                It.Is<string>(a => a.Contains("converted.pdf"))));
        }

        [Test]
        public async Task HtmlToPdfConverter_ConvertAsync_HtmlFromTextWithOptions_PdfMatchedWithStandard()
        {
            var html = "<html><body><h1>Hello world!</h1></body></html>";

            await htmlToPdfConverter.ConvertAsync(html, "converted.pdf", new GeneralPdfOptions());

            processServiceMock.Verify(s => s.StartAsync(It.Is<string>(f => f.Contains("pdf.")),
                It.Is<string>(a => a.Contains("converted.pdf"))));
        }

        [Test]
        public async Task HtmlToPdfConverter_ConvertAsync_HtmlFromStream_PdfMatchedWithStandard()
        {
            using (var html = new MemoryStream(Encoding.UTF8.GetBytes("<html><body><h1>Hello world!</h1></body></html>")))
            {
                await htmlToPdfConverter.ConvertAsync(html, "converted.pdf");

                processServiceMock.Verify(s => s.StartAsync(It.Is<string>(f => f.Contains("pdf.")),
                    It.Is<string>(a => a.Contains("converted.pdf"))));
            }
        }

        [Test]
        public async Task HtmlToPdfConverter_ConvertAsync_HtmlFromStreamWithOptions_PdfMatchedWithStandard()
        {
            using (var html = new MemoryStream(Encoding.UTF8.GetBytes("<html><body><h1>Hello world!</h1></body></html>")))
            {
                await htmlToPdfConverter.ConvertAsync(html, "converted.pdf", new GeneralPdfOptions());

                processServiceMock.Verify(s => s.StartAsync(It.Is<string>(f => f.Contains("pdf.")),
                    It.Is<string>(a => a.Contains("converted.pdf"))));
            }
        }
    }
}