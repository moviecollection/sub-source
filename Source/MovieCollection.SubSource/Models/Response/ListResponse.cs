using System.Collections.Generic;
using Newtonsoft.Json;

namespace MovieCollection.SubSource.Models;

public class ListResponse<T> : Response
{
    [JsonProperty("data")]
    public List<T> Data { get; set; }
}
