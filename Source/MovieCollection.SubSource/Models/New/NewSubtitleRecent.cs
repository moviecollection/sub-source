namespace MovieCollection.SubSource.Models;

public class NewSubtitleRecent : RecentFilters
{
    /// <summary>
    /// Gets or sets the page number for pagination (default: 1, max: 20).
    /// </summary>
    public int? Page { get; set; }

    /// <summary>
    /// Gets or sets the items per page (default: 30, max: 100).
    /// </summary>
    public int? Limit { get; set; }
}
