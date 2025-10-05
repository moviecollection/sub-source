using Newtonsoft.Json;

namespace MovieCollection.SubSource.Models;

public class Poster
{
    [JsonProperty("small")]
    public string? Small { get; set; }

    [JsonProperty("medium")]
    public string? Medium { get; set; }

    [JsonProperty("large")]
    public string? Large { get; set; }

    [JsonProperty("original")]
    public string? Original { get; set; }
}
