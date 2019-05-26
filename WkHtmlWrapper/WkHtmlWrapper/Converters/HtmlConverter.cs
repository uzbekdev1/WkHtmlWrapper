using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using WkHtmlWrapper.Converters.Interfaces;
using WkHtmlWrapper.Core.Services.Interfaces;
using WkHtmlWrapper.Image.Converters;
using WkHtmlWrapper.Image.Converters.Interfaces;
using WkHtmlWrapper.Image.Options;
using WkHtmlWrapper.Pdf.Converters;
using WkHtmlWrapper.Pdf.Converters.Interfaces;
using WkHtmlWrapper.Pdf.Options;

[assembly: InternalsVisibleTo("WkHtmlWrapper.UnitTests")]
namespace WkHtmlWrapper.Converters
{
    public class HtmlConverter : IHtmlConverter
    {
        private readonly IHtmlToPdfConverter _htmlToPdfConverter;

        private readonly IHtmlToImageConverter _htmlToImageConverter;

        public HtmlConverter()
        {
            _htmlToPdfConverter = new HtmlToPdfConverter();
            _htmlToImageConverter = new HtmlToImageConverter();
        }

        internal HtmlConverter(IProcessService processService)
        {
            _htmlToPdfConverter = new HtmlToPdfConverter(processService);
            _htmlToImageConverter = new HtmlToImageConverter(processService);
        }

        public HtmlConverter(IHtmlToPdfConverter htmlToPdfConverter, IHtmlToImageConverter htmlToImageConverter)
        {
            this._htmlToPdfConverter = htmlToPdfConverter;
            this._htmlToImageConverter = htmlToImageConverter;
        }

        public async Task ToImageAsync(string html, string outputFile) =>
            await _htmlToImageConverter.ConvertAsync(html, outputFile);

        public async Task ToImageAsync(string html, string outputFile, GeneralImageOptions options) =>
            await _htmlToImageConverter.ConvertAsync(html, outputFile, options);

        public async Task ToImageAsync(Stream html, string outputFile) =>
            await _htmlToImageConverter.ConvertAsync(html, outputFile);

        public async Task ToImageAsync(Stream html, string outputFile, GeneralImageOptions options) =>
            await _htmlToImageConverter.ConvertAsync(html, outputFile, options);

        public async Task ToPdfAsync(string html, string outputFile) =>
            await _htmlToPdfConverter.ConvertAsync(html, outputFile);

        public async Task ToPdfAsync(string html, string outputFile, GeneralPdfOptions options) =>
            await _htmlToPdfConverter.ConvertAsync(html, outputFile, options);

        public async Task ToPdfAsync(Stream html, string outputFile) =>
            await _htmlToPdfConverter.ConvertAsync(html, outputFile);

        public async Task ToPdfAsync(Stream html, string outputFile, GeneralPdfOptions options) =>
            await _htmlToPdfConverter.ConvertAsync(html, outputFile, options);
    }
}