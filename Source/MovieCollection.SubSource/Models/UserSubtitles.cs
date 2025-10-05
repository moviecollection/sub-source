using Newtonsoft.Json;

namespace MovieCollection.SubSource.Models;

public class UserSubtitles : PagedResponse<Subtitle>
{
    [JsonProperty("stats")]
    public Stats Stats { get; set; }
}
