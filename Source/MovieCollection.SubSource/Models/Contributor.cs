using Newtonsoft.Json;

namespace MovieCollection.SubSource.Models;

public class Contributor
{
    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("displayname")]
    public string DisplayName { get; set; }
}
