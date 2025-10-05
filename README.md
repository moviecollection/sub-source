# SubSource API
Unofficial implementation of the SubSource API for .NET

[![NuGet Version][nuget-shield]][nuget]
[![NuGet Downloads][nuget-shield-dl]][nuget]

## Installation
You can install this package via the `Package Manager Console` in Visual Studio.

```powershell
Install-Package MovieCollection.SubSource
```

## Configuration
Get or create a new static `HttpClient` instance if you don't have one already.

```csharp
// HttpClient lifecycle management best practices:
// https://learn.microsoft.com/dotnet/fundamentals/networking/http/httpclient-guidelines#recommended-use
private static readonly HttpClient httpClient = new HttpClient();
```

Then, you need to set your api key and pass it to the service's constructor.

```csharp
// using MovieCollection.SubSource;

var options = new SubSourceOptions
{
    ApiKey = "your-api-key",
};

var service = new SubSourceService(httpClient, options);
```

## Search for Movies
You can search for movies via the `SearchMoviesAsync` method.

```csharp
var request = new NewMovieSearch
{
    Query = "The Phoenician Scheme",
    SearchType = SearchType.Text,
};

var result = await service.SearchMoviesAsync(request);
```

Then, you can get the movie details via the `GetMovieByIdAsync` method:

```csharp
var result = await service.GetMovieByIdAsync(149171);
```

## Subtitles
You can search for subtitles via the `GetSubtitlesAsync` method.

```csharp
var request = new NewSubtitleSearch
{
    // The Phoenician Scheme
    MovieId = 149171,
    Language = "english",
};

var result = await service.GetSubtitlesAsync(request);
```

Then, you can get the subtitle details via the `GetSubtitleByIdAsync` method.

```csharp
var result = await service.GetSubtitleByIdAsync(10124960);
```

## Download a Subtitle
You can download a subtitle via the `DownloadSubtitleAsync` method.

> [!IMPORTANT]  
> If the destination file already exists, it will be overwritten.

```csharp
await service.DownloadSubtitleAsync(10124960, "path/to/a/file.zip");
```

Please see the demo project for more examples.

## Official Resources
- SubSource [API Documentations][service-docs]
- SubSource [Terms and Conditions][service-terms]

## License
This project is licensed under the [MIT License](LICENSE).

[nuget]: https://www.nuget.org/packages/MovieCollection.SubSource
[nuget-shield]: https://img.shields.io/nuget/v/MovieCollection.SubSource.svg?label=NuGet
[nuget-shield-dl]: https://img.shields.io/nuget/dt/MovieCollection.SubSource?label=Downloads&color=red

[service]: https://subsource.net
[service-docs]: https://subsource.net/api-docs
[service-terms]: https://subsource.net/terms