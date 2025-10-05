namespace MovieCollection.SubSource.Models;

public class NewSubtitleSearch : SubtitleFilters
{
    /// <summary>
    /// Gets or sets the items per page (default: 20, max: 100).
    /// </summary>
    /// <remarks>
    /// Controls how many results to return.
    /// </remarks>
    public int? Limit { get; set; }
}
