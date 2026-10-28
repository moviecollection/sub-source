using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using MovieCollection.SubSource;
using MovieCollection.SubSource.Models;

namespace Demo;

class Program
{
    // HttpClient lifecycle management best practices:
    // https://learn.microsoft.com/dotnet/fundamentals/networking/http/httpclient-guidelines#recommended-use
    private static readonly HttpClient httpClient = new();

    private static SubSourceOptions options;
    private static SubSourceService service;

    static async Task Main(string[] args)
    {
        options = new SubSourceOptions
        {
            ApiKey = "your-api-key",
        };

        service = new SubSourceService(httpClient, options);

        await InitializeMenu();
    }

    static async Task InitializeMenu()
    {
Start:
        Console.Clear();
        Console.WriteLine("Welcome to the 'SubSource' demo.\n");

        Console.WriteLine("1. Search for Movies & TV Shows");
        Console.WriteLine("2. Get Movie by Id");
        Console.WriteLine("3. Get Recent Subtitles");
        Console.WriteLine("4. Get Subtitles");
        Console.WriteLine("5. Get Subtitle by Id");
        Console.WriteLine("6. Download a Subtitle");
        Console.WriteLine("7. Search for Users");
        Console.WriteLine("8. Get User by Id");
        Console.WriteLine("9. Get User Subtitles");

        Console.Write("\nPlease select an option: ");
        var input = Convert.ToInt32(Console.ReadLine());

        Console.Clear();

        var task = input switch
        {
            1 => SearchMoviesAsync(),
            2 => GetMovieById(),
            3 => GetRecentSubtitles(),
            4 => GetSubtitles(),
            5 => GetSubtitleById(),
            6 => DownloadSubtitle(),
            7 => SearchUsers(),
            8 => GetUserById(),
            9 => GetUserSubtitles(),
            _ => null,
        };

        if (task != null)
        {
            await task;
        }

        Console.WriteLine("\nPress any key to go back to the menu...");
        Console.ReadKey();

        goto Start;
    }

    static async Task SearchMoviesAsync()
    {
        var request = new NewMovieSearch
        {
            Query = "The Phoenician Scheme",
            SearchType = SearchType.Text,
        };

        var result = await service.SearchMoviesAsync(request);

        foreach (var item in result.Response.Data)
        {
            Print(item);
        }
    }

    static async Task GetMovieById()
    {
        // The Phoenician Scheme
        var result = await service.GetMovieByIdAsync(149171);
        Print(result.Response.Data);
    }

    static async Task GetRecentSubtitles()
    {
        var request = new NewSubtitleRecent
        {
            Language = "english",
        };

        var result = await service.GetRecentSubtitlesAsync(request);

        foreach (var item in result.Response.Data)
        {
            Print(item);
        }
    }

    static async Task GetSubtitles()
    {
        var request = new NewSubtitleSearch
        {
            // The Phoenician Scheme
            MovieId = 149171,
            Language = "english",
        };

        var result = await service.GetSubtitlesAsync(request);

        foreach (var item in result.Response.Data)
        {
            Print(item);
        }
    }

    static async Task GetSubtitleById()
    {
        var result = await service.GetSubtitleByIdAsync(10124960);
        Print(result.Response.Data);
    }

    static async Task DownloadSubtitle()
    {
        int subtitleId = 10124960;

        var directory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        var destination = Path.Join(directory, $"subtitle-{subtitleId}.zip");

        await service.DownloadSubtitleAsync(subtitleId, destination);
    }

    static async Task SearchUsers()
    {
        var request = new NewUserSearch
        {
            Query = "ted",
            Limit = 5,
        };

        var result = await service.SearchUsersAsync(request);

        foreach (var item in result.Response.Data)
        {
            Print(item);
        }
    }

    static async Task GetUserById()
    {
        var result = await service.GetUserByIdAsync(887240);
        Print(result.Response.Data);
    }

    static async Task GetUserSubtitles()
    {
        var request = new NewUserSubtitlesSearch
        {
            UserId = 887240,
            Sort = "downloads",
        };

        var result = await service.GetUserSubtitlesAsync(request);

        foreach (var item in result.Response.Data)
        {
            Print(item);
        }
    }

    static void Print(Movie item)
    {
        Console.WriteLine($"MovieId: {item.MovieId}");
        Console.WriteLine($"Title: {item.Title}");
        Console.WriteLine($"AlternateTitle: {item.AlternateTitle}");
        Console.WriteLine($"Type: {item.Type}");
        Console.WriteLine($"ReleaseYear: {item.ReleaseYear}");
        Console.WriteLine();
    }

    static void Print(SubtitleRecent item)
    {
        Console.WriteLine($"SubtitleId: {item.SubtitleId}");
        Console.WriteLine($"MovieId: {item.MovieId}");
        Console.WriteLine($"Title: {item.Title}");
        Console.WriteLine($"MediaType: {item.MediaType}");
        Console.WriteLine($"Language: {item.Language}");
        Console.WriteLine($"ReleaseInfo: {string.Join(", ", item.ReleaseInfo)}");
        Console.WriteLine($"Files: {item.Files}");
        Console.WriteLine($"Size: {item.Size}");
        Console.WriteLine($"HearingImpaired: {item.HearingImpaired}");
        Console.WriteLine($"ForeignParts: {item.ForeignParts}");
        Console.WriteLine($"Framerate: {item.Framerate}");
        Console.WriteLine($"ProductionType: {item.ProductionType}");
        Console.WriteLine($"ReleaseType: {item.ReleaseType}");
        Console.WriteLine($"Downloads: {item.Downloads}");
        Console.WriteLine($"Link: {item.Link}");
        Console.WriteLine();
    }

    static void Print(Subtitle item)
    {
        Console.WriteLine($"SubtitleId: {item.SubtitleId}");
        Console.WriteLine($"MovieId: {item.MovieId}");
        Console.WriteLine($"Language: {item.Language}");
        Console.WriteLine($"ReleaseInfo: {string.Join(", ", item.ReleaseInfo)}");
        Console.WriteLine($"Files: {item.Files}");
        Console.WriteLine($"Size: {item.Size}");
        Console.WriteLine($"HearingImpaired: {item.HearingImpaired}");
        Console.WriteLine($"ForeignParts: {item.ForeignParts}");
        Console.WriteLine($"Framerate: {item.Framerate}");
        Console.WriteLine($"ProductionType: {item.ProductionType}");
        Console.WriteLine($"ReleaseType: {item.ReleaseType}");
        Console.WriteLine($"Downloads: {item.Downloads}");
        Console.WriteLine();
    }

    static void Print(User item)
    {
        Console.WriteLine($"UserId: {item.UserId}");
        Console.WriteLine($"Username: {item.Username}");
        Console.WriteLine($"DisplayName: {item.DisplayName}");
        Console.WriteLine();
    }
}
