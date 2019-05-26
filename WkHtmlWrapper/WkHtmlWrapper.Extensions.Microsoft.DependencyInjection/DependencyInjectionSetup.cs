using Microsoft.Extensions.DependencyInjection;
using WkHtmlWrapper.Converters;
using WkHtmlWrapper.Converters.Interfaces;
using WkHtmlWrapper.Image.Extensions.Microsoft.DependencyInjection;
using WkHtmlWrapper.Pdf.Extensions.Microsoft.DependencyInjection;

namespace WkHtmlWrapper.Extensions.Microsoft.DependencyInjection
{
    public static class DependencyInjectionSetup
    {
        public static IServiceCollection UseWkHtmlConverter(this IServiceCollection services)
        {
            services.AddScoped<IHtmlConverter, HtmlConverter>();
            services.UseWkHtmlToImageConverter();
            services.UseWkHtmlToPdfConverter();
            return services;
        }
    }
}
