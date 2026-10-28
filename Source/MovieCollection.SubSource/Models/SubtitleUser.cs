using Newtonsoft.Json;

namespace MovieCollection.SubSource.Models;

public class SubtitleUser : Subtitle
{
    [JsonProperty("isCollaboration")]
    public bool IsCollaboration { get; set; }
}
