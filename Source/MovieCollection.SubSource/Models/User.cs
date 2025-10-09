using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MovieCollection.SubSource.Models;

public class User
{
    [JsonProperty("userId")]
    public int UserId { get; set; }

    [JsonProperty("displayname")]
    public string DisplayName { get; set; }

    [JsonProperty("username")]
    public string Username { get; set; }

    [JsonProperty("badges")]
    public List<object> Badges { get; set; }

    [JsonProperty("avatar")]
    public string Avatar { get; set; }

    [JsonProperty("createdAt")]
    public DateTimeOffset CreatedAt { get; set; }

    [JsonProperty("lastSeen")]
    public string LastSeen { get; set; }
}
