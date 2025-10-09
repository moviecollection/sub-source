using Newtonsoft.Json;

namespace MovieCollection.SubSource.Models;

public class Stats
{
    [JsonProperty("totalUploaded")]
    public int TotalUploaded { get; set; }

    [JsonProperty("totalContributed")]
    public int TotalContributed { get; set; }

    [JsonProperty("totalAssociated")]
    public int TotalAssociated { get; set; }
}
