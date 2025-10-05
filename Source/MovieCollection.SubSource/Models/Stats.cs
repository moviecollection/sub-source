using Newtonsoft.Json;

namespace MovieCollection.SubSource.Models;

public class Stats
{
    [JsonProperty("totalUploaded")]
    public long TotalUploaded { get; set; }

    [JsonProperty("totalContributed")]
    public long TotalContributed { get; set; }

    [JsonProperty("totalAssociated")]
    public long TotalAssociated { get; set; }
}
