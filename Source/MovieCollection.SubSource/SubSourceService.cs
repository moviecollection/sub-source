using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MovieCollection.SubSource.Models;
using Newtonsoft.Json;

namespace MovieCollection.SubSource;

/// <summary>
/// The <see cref="SubSourceService"/> class.
/// </summary>
public class SubSourceService
{
    private readonly HttpClient _httpClient;
    private readonly SubSourceOptions _options;

    /// <summary>
    /// Initializes a new instance of the <see cref="SubSourceService"/> class.
    /// </summary>
    /// <param name="httpClient">An instance of <see cref="HttpClient"/>.</param>
    /// <param name="options">An instance of <see cref="SubSourceOptions"/>.</param>
    public SubSourceService(HttpClient httpClient, SubSourceOptions options)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _options = options ?? throw new ArgumentNullException(nameof(options));

        if (string.IsNullOrWhiteSpace(_options.ApiAddress))
        {
            throw new ArgumentException($"'{nameof(_options.ApiAddress)}' cannot be null or whitespace.", nameof(options));
        }

        if (string.IsNullOrWhiteSpace(_options.ApiKey))
        {
            throw new ArgumentException($"'{nameof(_options.ApiKey)}' cannot be null or whitespace.", nameof(options));
        }
    }

    /// <summary>
    /// Search for movies and TV shows using IMDb ID or text queries.
    /// </summary>
    /// <param name="request">An instance of <see cref="NewMovieSearch"/> class.</param>
    /// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentNullException">When <paramref name="request"/> is null.</exception>
    public Task<HttpResponse<ListResponse<Movie>>> SearchMoviesAsync(NewMovieSearch request, CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        if (string.IsNullOrEmpty(request.SearchType))
        {
            throw new ArgumentException($"'{nameof(request.SearchType)}' cannot be null or empty.", nameof(request));
        }

        var parameters = new Dictionary<string, object>
        {
            ["searchType"] = request.SearchType,
        };

        if (!string.IsNullOrEmpty(request.Query))
        {
            parameters.Add("q", request.Query);
        }

        if (!string.IsNullOrEmpty(request.Imdb))
        {
            parameters.Add("imdb", request.Imdb);
        }

        if (request.Year.HasValue)
        {
            parameters.Add("year", request.Year);
        }

        if (!string.IsNullOrEmpty(request.Type))
        {
            parameters.Add("type", request.Type);
        }

        if (request.Season.HasValue)
        {
            parameters.Add("season", request.Season);
        }

        return GetJsonAsync<ListResponse<Movie>>("/api/v1/movies/search", parameters, null, cancellationToken);
    }

    /// <summary>
    /// Get detailed information about a specific movie or TV series by its Id.
    /// </summary>
    /// <param name="movieId">The unique identifier for the movie or series.</param>
    /// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task<HttpResponse<Response<Movie>>> GetMovieByIdAsync(int movieId, CancellationToken cancellationToken = default)
    {
        return GetJsonAsync<Response<Movie>>($"/api/v1/movies/{movieId}", null, null, cancellationToken);
    }

    /// <summary>
    /// Retrieve subtitles for a specific movie or TV show.
    /// </summary>
    /// <param name="request">An instance of <see cref="NewSubtitleSearch"/> class.</param>
    /// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentNullException">When <paramref name="request"/> is null.</exception>
    public Task<HttpResponse<PagedResponse<Subtitle, SubtitleFilters>>> GetSubtitlesAsync(NewSubtitleSearch request, CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var parameters = new Dictionary<string, object>();

        if (request.MovieId.HasValue)
        {
            parameters.Add("movieId", request.MovieId);
        }

        if (!string.IsNullOrEmpty(request.Language))
        {
            parameters.Add("language", request.Language);
        }

        if (!string.IsNullOrEmpty(request.ProductionType))
        {
            parameters.Add("productionType", request.ProductionType);
        }

        if (!string.IsNullOrEmpty(request.ReleaseType))
        {
            parameters.Add("releaseType", request.ReleaseType);
        }

        if (!string.IsNullOrEmpty(request.ReleaseInfo))
        {
            parameters.Add("releaseInfo", request.ReleaseInfo);
        }

        if (request.UploaderId.HasValue)
        {
            parameters.Add("uploader", request.UploaderId);
        }

        if (request.HearingImpaired.HasValue)
        {
            parameters.Add("hearingImpaired", request.HearingImpaired);
        }

        if (request.ForeignParts.HasValue)
        {
            parameters.Add("foreignParts", request.ForeignParts);
        }

        if (!string.IsNullOrEmpty(request.Framerate))
        {
            parameters.Add("framerate", request.Framerate);
        }

        if (request.Page.HasValue)
        {
            parameters.Add("page", request.Page);
        }

        if (request.Limit.HasValue)
        {
            parameters.Add("limit", request.Limit);
        }

        if (!string.IsNullOrEmpty(request.Sort))
        {
            parameters.Add("sort", request.Sort);
        }

        return GetJsonAsync<PagedResponse<Subtitle, SubtitleFilters>>("/api/v1/subtitles", parameters, null, cancellationToken);
    }

    /// <summary>
    /// Retrieve detailed information about a specific subtitle by its Id.
    /// </summary>
    /// <param name="subtitleId">The unique identifier for the subtitle.</param>
    /// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task<HttpResponse<Response<Subtitle>>> GetSubtitleByIdAsync(int subtitleId, CancellationToken cancellationToken = default)
    {
        return GetJsonAsync<Response<Subtitle>>($"/api/v1/subtitles/{subtitleId}", null, null, cancellationToken);
    }

    /// <summary>
    /// Download a specific subtitle file as a Zip Archive.
    /// </summary>
    /// <param name="subtitleId">The unique identifier for the subtitle.</param>
    /// <param name="destination">The destination file path.</param>
    /// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
    public Task DownloadSubtitleAsync(int subtitleId, string destination, CancellationToken cancellationToken = default)
    {
        return DownloadFileAsync($"/api/v1/subtitles/{subtitleId}/download", destination, cancellationToken);
    }

    /// <summary>
    /// Search for users by display name or username.
    /// </summary>
    /// <param name="request">An instance of <see cref="NewUserSearch"/> class.</param>
    /// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentNullException">When <paramref name="request"/> is null.</exception>
    /// <exception cref="ArgumentException">When <paramref name="request"/> search query is null or empty.</exception>
    public Task<HttpResponse<PagedResponse<User, UserFilters>>> SearchUsersAsync(NewUserSearch request, CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        if (string.IsNullOrEmpty(request.Query))
        {
            throw new ArgumentException($"'{nameof(request.Query)}' cannot be null or empty.", nameof(request));
        }

        var parameters = new Dictionary<string, object>
        {
            ["search"] = request.Query,
        };

        if (request.Page.HasValue)
        {
            parameters.Add("page", request.Page);
        }

        if (request.Limit.HasValue)
        {
            parameters.Add("limit", request.Limit);
        }

        return GetJsonAsync<PagedResponse<User, UserFilters>>("/api/v1/users/search", parameters, null, cancellationToken);
    }

    /// <summary>
    /// Retrieve detailed information about a specific user by their id.
    /// </summary>
    /// <param name="userId">The unique identifier for the user.</param>
    /// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task<HttpResponse<Response<User>>> GetUserByIdAsync(int userId, CancellationToken cancellationToken = default)
    {
        return GetJsonAsync<Response<User>>($"/api/v1/users/{userId}", null, null, cancellationToken);
    }

    /// <summary>
    /// Retrieve all subtitles uploaded or contributed by a specific user
    /// </summary>
    /// <param name="request">An instance of <see cref="NewUserSubtitlesSearch"/> class.</param>
    /// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentNullException">When <paramref name="request"/> is null.</exception>
    public Task<HttpResponse<UserSubtitles>> GetUserSubtitlesAsync(NewUserSubtitlesSearch request, CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var parameters = new Dictionary<string, object>();

        if (request.Page.HasValue)
        {
            parameters.Add("page", request.Page);
        }

        if (request.Limit.HasValue)
        {
            parameters.Add("limit", request.Limit);
        }

        if (!string.IsNullOrEmpty(request.Sort))
        {
            parameters.Add("sort", request.Sort);
        }

        if (request.MovieId.HasValue)
        {
            parameters.Add("movieId", request.MovieId);
        }

        if (!string.IsNullOrEmpty(request.Language))
        {
            parameters.Add("language", request.Language);
        }

        if (!string.IsNullOrEmpty(request.ReleaseType))
        {
            parameters.Add("releaseType", request.ReleaseType);
        }

        if (!string.IsNullOrEmpty(request.ProductionType))
        {
            parameters.Add("productionType", request.ProductionType);
        }

        if (request.HearingImpaired.HasValue)
        {
            parameters.Add("hearingImpaired", request.HearingImpaired);
        }

        if (request.ForeignParts.HasValue)
        {
            parameters.Add("foreignParts", request.ForeignParts);
        }

        if (!string.IsNullOrEmpty(request.Framerate))
        {
            parameters.Add("framerate", request.Framerate);
        }

        return GetJsonAsync<UserSubtitles>($"/api/v1/users/{request.UserId}/subtitles", parameters, null, cancellationToken);
    }

    private static string GetParametersString(Dictionary<string, object> parameters)
    {
        var builder = new StringBuilder();

        foreach (var item in parameters)
        {
            builder.Append(builder.Length == 0 ? "?" : "&");
            builder.Append($"{item.Key}={item.Value}");
        }

        return builder.ToString();
    }

    private async Task DownloadFileAsync(string requestUrl, string destination, CancellationToken cancellationToken)
    {
        string url = _options.ApiAddress + requestUrl;

        using var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("X-API-Key", _options.ApiKey);

        using var response = await _httpClient.SendAsync(request, cancellationToken);
        using var fileStream = new FileStream(destination, FileMode.Create, FileAccess.Write);

#if NET5_0_OR_GREATER
        await response.Content.CopyToAsync(fileStream, cancellationToken);
#else
        await response.Content.CopyToAsync(fileStream);
#endif
    }

    private async Task<HttpResponse<T>> GetJsonAsync<T>(string requestUrl, Dictionary<string, object>? parameters, string? token, CancellationToken cancellationToken)
        where T : Response
    {
        string url = _options.ApiAddress + requestUrl;

        if (parameters is not null && parameters.Count != 0)
        {
            url += GetParametersString(parameters);
        }

        using var request = new HttpRequestMessage(HttpMethod.Get, url);

        return await SendRequestAsync<T>(request, token, cancellationToken)
            .ConfigureAwait(false);
    }

    private async Task<HttpResponse<T>> SendRequestAsync<T>(HttpRequestMessage request, string? token, CancellationToken cancellationToken)
        where T : Response
    {
        request.Headers.Add("X-API-Key", _options.ApiKey);

        if (!string.IsNullOrEmpty(token))
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        // Set the user agent if it was explicitly set via the options.
        // This overrides the default request headers.
        if (_options.ProductInformation != null)
        {
            request.Headers.UserAgent.Add(new ProductInfoHeaderValue(_options.ProductInformation));
        }

        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        using var response = await _httpClient.SendAsync(request, cancellationToken)
            .ConfigureAwait(false);

        string json = await response.Content
#if NET5_0_OR_GREATER
            .ReadAsStringAsync(cancellationToken)
#else
            .ReadAsStringAsync()
#endif
            .ConfigureAwait(false);

        return new HttpResponse<T>
        {
            Response = JsonConvert.DeserializeObject<T>(json),
            IsSuccess = response.IsSuccessStatusCode,
            StatusCode = response.StatusCode,
        };
    }
}
