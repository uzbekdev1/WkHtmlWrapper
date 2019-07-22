# WkHtmlWrapper
[![NuGet](https://img.shields.io/nuget/v/WkHtmlWrapper.svg?color=gree&label=WkHtmlWrapper)](https://www.nuget.org/packages/WkHtmlWrapper/)
[![NuGet](https://img.shields.io/nuget/v/WkHtmlWrapper.Core.svg?color=gree&label=WkHtmlWrapper.Core)](https://www.nuget.org/packages/WkHtmlWrapper.Core/)
[![NuGet](https://img.shields.io/nuget/v/WkHtmlWrapper.Extensions.Microsoft.DependencyInjection.svg?color=gree&label=WkHtmlWrapper.Extensions.Microsoft.DependencyInjection)](https://www.nuget.org/packages/WkHtmlWrapper.Extensions.Microsoft.DependencyInjection/)
[![NuGet](https://img.shields.io/nuget/v/WkHtmlWrapper.Image.svg?color=gree&label=WkHtmlWrapper.Image)](https://www.nuget.org/packages/WkHtmlWrapper.Image/)
[![NuGet](https://img.shields.io/nuget/v/WkHtmlWrapper.Image.Extensions.Microsoft.DependencyInjection.svg?color=gree&label=WkHtmlWrapper.Image.Extensions.Microsoft.DependencyInjection)](https://www.nuget.org/packages/WkHtmlWrapper.Image.Extensions.Microsoft.DependencyInjection/)
[![NuGet](https://img.shields.io/nuget/v/WkHtmlWrapper.Pdf.svg?color=gree&label=WkHtmlWrapper.Pdf)](https://www.nuget.org/packages/WkHtmlWrapper.Pdf/)
[![NuGet](https://img.shields.io/nuget/v/WkHtmlWrapper.Pdf.Extensions.Microsoft.DependencyInjection.svg?color=gree&label=WkHtmlWrapper.Pdf.Extensions.Microsoft.DependencyInjection)](https://www.nuget.org/packages/WkHtmlWrapper.Pdf.Extensions.Microsoft.DependencyInjection/)
---
[![Azure DevOps builds](https://img.shields.io/azure-devops/build/vasilek-1997/WkHtmlWrapper/4.svg)](https://dev.azure.com/vasilek-1997/WkHtmlWrapper/_build?definitionId=4)
[![Azure DevOps tests (compact)](https://img.shields.io/azure-devops/tests/vasilek-1997/WkHtmlWrapper/4.svg?compact_message)](https://dev.azure.com/vasilek-1997/WkHtmlWrapper/_test/analytics?definitionId=4&contextType=build)
---
### Usage HtmlConverter
```
class Program
{
    static async Task Main(string[] args)
    {
        var html = "<html><body><h2>Hello World!</h2></body></html>";
        await new HtmlConverter().ToImageAsync(html, "test.png");
        await new HtmlConverter().ToPdfAsync(html, "test.pdf");
    }
}
```
### Usage HtmlToPdfConverter
```
class Program
{
    static async Task Main(string[] args)
    {
        var html = "<html><body><h2>Hello World!</h2></body></html>";
        await new HtmlToPdfConverter().ConvertAsync(html, "test.pdf");
    }
}
```
### Usage HtmlToImageConverter
```
class Program
{
    static async Task Main(string[] args)
    {
        var html = "<html><body><h2>Hello World!</h2></body></html>";
        await new HtmlToImageConverter().ConvertAsync(html, "test.png");
    }
}
```
### DI
Setup:
```
public void ConfigureServices(IServiceCollection services)
{
    services.UseWkHtmlConverter();
}
```
or
```
public void ConfigureServices(IServiceCollection services)
{
    services.UseWkHtmlToImageConverter();
    services.UseWkHtmlToPdfConverter();
}
```
Injection:
```
public class Test
{
    private readonly IHtmlConverter htmlConverter;
    
    public Test(IHtmlConverter htmlConverter)
    {
        this.htmlConverter = htmlConverter;
    }
}
```
or
```
public class Test
{
    private readonly IHtmlToImageConverter htmlImageConverter;
    
    private readonly IHtmlToPdfConverter htmlPdfConverter;
    
    public Test(IHtmlToImageConverter htmlImageConverter, IHtmlToPdfConverter htmlPdfConverter)
    {
        this.htmlImageConverter = htmlImageConverter;
        this.htmlPdfConverter = htmlPdfConverter;
    }
}
```
