using Newtonsoft.Json;

namespace MovieCollection.SubSource.Models;

public class Response
{
    [JsonProperty("message")]
    public string Message { get; set; }
}
