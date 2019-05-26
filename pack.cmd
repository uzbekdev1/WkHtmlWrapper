cd .\WkHtmlWrapper\

SET $version=%1

echo 'Build WkHtmlWrapper...'
dotnet build .\WkHtmlWrapper\WkHtmlWrapper.csproj --configuration Release --force /property:Version=%$version%
echo 'Pack WkHtmlWrapper...'
dotnet pack .\WkHtmlWrapper\WkHtmlWrapper.csproj /p:Version=%$version% --configuration Release --force 

echo 'Build WkHtmlWrapper.Core...'
dotnet build .\WkHtmlWrapper.Core\WkHtmlWrapper.Core.csproj --configuration Release --force /property:Version=%$version%
echo 'Pack WkHtmlWrapper.Core...'
dotnet pack .\WkHtmlWrapper.Core\WkHtmlWrapper.Core.csproj /p:Version=%$version% --configuration Release --force 

echo 'Build WkHtmlWrapper.Extensions.Microsoft.DependencyInjection...'
dotnet build .\WkHtmlWrapper.Extensions.Microsoft.DependencyInjection\WkHtmlWrapper.Extensions.Microsoft.DependencyInjection.csproj --configuration Release --force /property:Version=%$version%
echo 'Pack WkHtmlWrapper.Extensions.Microsoft.DependencyInjection...'
dotnet pack .\WkHtmlWrapper.Extensions.Microsoft.DependencyInjection\WkHtmlWrapper.Extensions.Microsoft.DependencyInjection.csproj /p:Version=%$version% --configuration Release --force 

echo 'Build WkHtmlWrapper.Image...'
dotnet build .\WkHtmlWrapper.Image\WkHtmlWrapper.Image.csproj --configuration Release --force /property:Version=%$version%
echo 'Pack WkHtmlWrapper.Image...'
dotnet pack .\WkHtmlWrapper.Image\WkHtmlWrapper.Image.csproj /p:Version=%$version% --configuration Release --force 

echo 'Build WkHtmlWrapper.Image.Extensions.Microsoft.DependencyInjection...'
dotnet build .\WkHtmlWrapper.Image.Extensions.Microsoft.DependencyInjection\WkHtmlWrapper.Image.Extensions.Microsoft.DependencyInjection.csproj --configuration Release --force /property:Version=%$version%
echo 'Pack WkHtmlWrapper.Image.Extensions.Microsoft.DependencyInjection...'
dotnet pack .\WkHtmlWrapper.Image.Extensions.Microsoft.DependencyInjection\WkHtmlWrapper.Image.Extensions.Microsoft.DependencyInjection.csproj /p:Version=%$version% --configuration Release --force 

echo 'Build WkHtmlWrapper.Pdf...'
dotnet build .\WkHtmlWrapper.Pdf\WkHtmlWrapper.Pdf.csproj --configuration Release --force /property:Version=%$version%
echo 'Pack WkHtmlWrapper.Pdf...'
dotnet pack .\WkHtmlWrapper.Pdf\WkHtmlWrapper.Pdf.csproj /p:Version=%$version% --configuration Release --force 

echo 'Build WkHtmlWrapper.Pdf.Extensions.Microsoft.DependencyInjection...'
dotnet build .\WkHtmlWrapper.Pdf.Extensions.Microsoft.DependencyInjection\WkHtmlWrapper.Pdf.Extensions.Microsoft.DependencyInjection.csproj --configuration Release --force /property:Version=%$version%
echo 'Pack WkHtmlWrapper.Pdf.Extensions.Microsoft.DependencyInjection...'
dotnet pack .\WkHtmlWrapper.Pdf.Extensions.Microsoft.DependencyInjection\WkHtmlWrapper.Pdf.Extensions.Microsoft.DependencyInjection.csproj /p:Version=%$version% --configuration Release --force 