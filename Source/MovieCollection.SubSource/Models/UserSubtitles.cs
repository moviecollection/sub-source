using Newtonsoft.Json;

namespace MovieCollection.SubSource.Models;

public class UserSubtitles : PagedResponse<SubtitleUser>
{
    [JsonProperty("stats")]
    public Stats Stats { get; set; }
}
