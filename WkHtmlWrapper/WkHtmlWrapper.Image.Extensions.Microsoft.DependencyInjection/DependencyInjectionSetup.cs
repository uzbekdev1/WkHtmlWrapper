using Microsoft.Extensions.DependencyInjection;
using WkHtmlWrapper.Image.Converters;
using WkHtmlWrapper.Image.Converters.Interfaces;

namespace WkHtmlWrapper.Image.Extensions.Microsoft.DependencyInjection
{
    public static class DependencyInjectionSetup
    {
        public static IServiceCollection UseWkHtmlToImageConverter(this IServiceCollection services)
        {
            services.AddScoped<IHtmlToImageConverter, HtmlToImageConverter>();
            return services;
        }
    }
}
