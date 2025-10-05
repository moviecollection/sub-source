using Newtonsoft.Json;

namespace MovieCollection.SubSource.Models;

public class PagedResponse<TResult, TFilters> : ListResponse<TResult>
{
    [JsonProperty("pagination")]
    public Pagination Pagination { get; set; }

    [JsonProperty("filters")]
    public TFilters Filters { get; set; }
}