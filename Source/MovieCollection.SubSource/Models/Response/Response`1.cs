using Newtonsoft.Json;

namespace MovieCollection.SubSource.Models;

public class Response<T> : Response
{
    [JsonProperty("data")]
    public T? Data { get; set; }
}
