using Microsoft.Extensions.DependencyInjection;
using WkHtmlWrapper.Pdf.Converters;
using WkHtmlWrapper.Pdf.Converters.Interfaces;

namespace WkHtmlWrapper.Pdf.Extensions.Microsoft.DependencyInjection
{
    public static class DependencyInjectionSetup
    {
        public static IServiceCollection UseWkHtmlToPdfConverter(this IServiceCollection services)
        {
            services.AddScoped<IHtmlToPdfConverter, HtmlToPdfConverter>();
            return services;
        }
    }
}
