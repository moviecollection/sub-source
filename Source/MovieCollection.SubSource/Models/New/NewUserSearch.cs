namespace MovieCollection.SubSource.Models;

public class NewUserSearch : UserFilters
{
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
}
