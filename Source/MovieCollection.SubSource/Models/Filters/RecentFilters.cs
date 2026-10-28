using Newtonsoft.Json;

namespace MovieCollection.SubSource.Models;

public class RecentFilters
{
    /// <summary>
    /// Gets or sets the filter by language code (e.g., 'english', 'spanish').
    /// </summary>
    [JsonProperty("language")]
    public string? Language { get; set; }

    /// <summary>
    /// Gets or sets the filter by media type (e.g., 'movie', 'tvseries').
    /// </summary>
    [JsonProperty("type")]
    public string? Type { get; set; }

    /// <summary>
    /// Gets or sets the sort results by 'latest' (default) or 'popular'. Popular is limited to subtitles uploaded in the last 30 days.
    /// </summary>
    [JsonProperty("sort")]
    public string? Sort { get; set; }
}
