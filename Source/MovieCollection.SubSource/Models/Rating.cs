using Newtonsoft.Json;

namespace MovieCollection.SubSource.Models;

public class Rating
{
    [JsonProperty("good")]
    public int Good { get; set; }

    [JsonProperty("bad")]
    public int Bad { get; set; }

    [JsonProperty("total")]
    public int Total { get; set; }
}
