using Newtonsoft.Json;

namespace MovieCollection.SubSource.Models;

public class SubtitleFilters
{
    /// <summary>
    /// Gets or sets the unique identifier for the movie or TV show.
    /// </summary>
    /// <remarks>
    /// Required unless <see cref="ReleaseInfo"/> is provided.
    /// </remarks>
    [JsonProperty("movieId")]
    public int? MovieId { get; set; }

    /// <summary>
    /// Gets or sets the filter by language code (e.g., 'english', 'spanish').
    /// </summary>
    [JsonProperty("language")]
    public string? Language { get; set; }

    /// <summary>
    /// Gets or sets the filter by production type (e.g., 'translated', 'retail').
    /// </summary>
    [JsonProperty("productionType")]
    public string? ProductionType { get; set; }

    /// <summary>
    /// Gets or sets the filter by release type (e.g., 'web', 'bluray').
    /// </summary>
    [JsonProperty("releaseType")]
    public string? ReleaseType { get; set; }

    /// <summary>
    /// Gets or sets the filter by exact release info string (e.g., 'BluRay 1080p', 'WEB-DL 720p').
    /// Can be used as alternative to movieId. 
    /// </summary>
    /// <remarks>
    /// Only shows results if movie has that exact release info.
    /// </remarks>
    [JsonProperty("releaseInfo")]
    public string? ReleaseInfo { get; set; }

    /// <summary>
    /// Gets or sets the filter by uploader user id.
    /// </summary>
    /// <remarks>
    /// Find subtitles from specific users.
    /// </remarks>
    [JsonProperty("uploader")]
    public int? UploaderId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether it should filter for hearing impaired subtitles.
    /// </summary>
    [JsonProperty("hearingImpaired")]
    public bool? HearingImpaired { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether it should filter for foreign parts subtitles.
    /// </summary>
    [JsonProperty("foreignParts")]
    public bool? ForeignParts { get; set; }

    /// <summary>
    /// Gets or sets the filter by framerate (e.g., '23.976', '25.00').
    /// </summary>
    [JsonProperty("framerate")]
    public string? Framerate { get; set; }

    /// <summary>
    /// Gets or sets the page number for pagination (default: 1).
    /// </summary>
    public int? Page { get; set; }

    /// <summary>
    /// Gets or sets the sort results by: 'newest', 'oldest', 'popular' (by downloads), 'rating' (default: 'newest').
    /// </summary>
    [JsonProperty("sort")]
    public string? Sort { get; set; }
}
