using Newtonsoft.Json;

namespace MovieCollection.SubSource.Models;

public class Pagination
{
    [JsonProperty("page")]
    public int Page { get; set; }

    [JsonProperty("limit")]
    public int Limit { get; set; }

    [JsonProperty("total")]
    public long Total { get; set; }

    [JsonProperty("pages")]
    public int Pages { get; set; }
}
