using System.IO;
using System.Threading.Tasks;
using WkHtmlWrapper.Image.Options;
using WkHtmlWrapper.Pdf.Options;

namespace WkHtmlWrapper.Converters.Interfaces
{
    public interface IHtmlConverter
    {
        Task ToImageAsync(string html, string outputFile);

        Task ToImageAsync(string html, string outputFile, GeneralImageOptions options);

        Task ToImageAsync(Stream html, string outputFile);

        Task ToImageAsync(Stream html, string outputFile, GeneralImageOptions options);

        Task ToPdfAsync(string html, string outputFile);

        Task ToPdfAsync(string html, string outputFile, GeneralPdfOptions options);

        Task ToPdfAsync(Stream html, string outputFile);

        Task ToPdfAsync(Stream html, string outputFile, GeneralPdfOptions options);
    }
}