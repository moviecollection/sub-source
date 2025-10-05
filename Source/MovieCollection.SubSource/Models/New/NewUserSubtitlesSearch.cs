namespace MovieCollection.SubSource.Models;

public class NewUserSubtitlesSearch
{
    /// <summary>
    /// Gets or sets the unique identifier for the user.
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Gets or sets the page number for pagination (default: 1).
    /// </summary>
    public int? Page { get; set; }

    /// <summary>
    /// Gets or sets the items per page (default: 20, max: 100).
    /// </summary>
    /// <remarks>
    /// Controls how many results to return.
    /// </remarks>
    public int? Limit { get; set; }

    /// <summary>
    /// Gets or sets the sort results by: 'latest', 'downloads', 'comments' (default: 'latest').
    /// </summary>
    public string? Sort { get; set; }

    /// <summary>
    /// Gets or sets the filter by movie id.
    /// </summary>
    /// <remarks>
    /// Find subtitles for a specific movie or TV show.
    /// </remarks>
    public int? MovieId { get; set; }

    /// <summary>
    /// Gets or sets the filter by language code (e.g., 'english', 'spanish').
    /// </summary>
    public string? Language { get; set; }

    /// <summary>
    /// Gets or sets the filter by release type (e.g., 'web', 'bluray').
    /// </summary>
    public string? ReleaseType { get; set; }

    /// <summary>
    /// Gets or sets the filter by production type (e.g., 'translated', 'retail').
    /// </summary>
    public string? ProductionType { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether it should filter for hearing impaired subtitles.
    /// </summary>
    public bool? HearingImpaired { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether it should filter for foreign parts subtitles.
    /// </summary>
    public bool? ForeignParts { get; set; }

    /// <summary>
    /// Gets or sets the filter by framerate (e.g., '23.976', '25.00').
    /// </summary>
    public string? Framerate { get; set; }
}
