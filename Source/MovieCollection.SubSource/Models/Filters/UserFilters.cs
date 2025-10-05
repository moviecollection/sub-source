using Newtonsoft.Json;

namespace MovieCollection.SubSource.Models;

public class UserFilters
{
    public UserFilters()
    {
        Query = string.Empty;
    }

    /// <summary>
    /// Gets or sets the search query (minimum 2 characters).
    /// </summary>
    /// <remarks>
    /// Search by display name or username.
    /// </remarks>
    [JsonProperty("search")]
    public string Query { get; set; }
}
