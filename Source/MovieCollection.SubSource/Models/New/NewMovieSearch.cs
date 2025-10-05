namespace MovieCollection.SubSource.Models;

public class NewMovieSearch
{
    public NewMovieSearch()
    {
        SearchType = string.Empty;
        Type = string.Empty;
    }

    /// <summary>
    /// Gets or sets the search type: "imdb" or "text".
    /// </summary>
    public string SearchType { get; set; }

    /// <summary>
    /// Gets or sets the search query (required for text search).
    /// </summary>
    public string? Query { get; set; }

    /// <summary>
    /// Gets or sets the IMDb ID or IMDb link (required for IMDb search).
    /// </summary>
    public string? Imdb { get; set; }

    /// <summary>
    /// Gets or sets the filter by release year.
    /// </summary>
    public int? Year { get; set; }

    /// <summary>
    /// Gets or sets the filter by content type: "movie", "series", or "all" (default: "all").
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    /// Gets or sets the filter by season number (for series).
    /// </summary>
    public int? Season { get; set; }
}
