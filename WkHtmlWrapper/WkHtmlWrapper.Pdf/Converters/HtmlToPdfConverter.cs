using System.Runtime.CompilerServices;
using WkHtmlWrapper.Core.Converters;
using WkHtmlWrapper.Core.Enums;
using WkHtmlWrapper.Core.Services.Interfaces;
using WkHtmlWrapper.Pdf.Converters.Interfaces;
using WkHtmlWrapper.Pdf.Options;

[assembly: InternalsVisibleTo("WkHtmlWrapper")]
[assembly: InternalsVisibleTo("WkHtmlWrapper.UnitTests")]
namespace WkHtmlWrapper.Pdf.Converters
{
    public class HtmlToPdfConverter : Converter<GeneralPdfOptions>, IHtmlToPdfConverter
    {
        public HtmlToPdfConverter()
        {
            ConverterType = ConverterType.Pdf;
        }

        internal HtmlToPdfConverter(IProcessService processService) : base(processService)
        {
            ConverterType = ConverterType.Pdf;
        }
    }
}
