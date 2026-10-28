using Newtonsoft.Json;

namespace MovieCollection.SubSource.Models;

public class SubtitleRecent : Subtitle
{
    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("mediaType")]
    public string MediaType { get; set; }

    [JsonProperty("link")]
    public string Link { get; set; }
}
