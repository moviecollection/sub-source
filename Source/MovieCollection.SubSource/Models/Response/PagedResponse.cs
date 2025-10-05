using Newtonsoft.Json;

namespace MovieCollection.SubSource.Models;

public class PagedResponse<TResult> : ListResponse<TResult>
{
    [JsonProperty("pagination")]
    public Pagination Pagination { get; set; }
}
