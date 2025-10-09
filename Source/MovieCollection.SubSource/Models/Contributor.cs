using Newtonsoft.Json;

namespace MovieCollection.SubSource.Models;

public class Contributor
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("displayname")]
    public string DisplayName { get; set; }
}
