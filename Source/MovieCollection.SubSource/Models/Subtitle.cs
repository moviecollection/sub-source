using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MovieCollection.SubSource.Models;

public class Subtitle
{
    [JsonProperty("subtitleId")]
    public long SubtitleId { get; set; }

    [JsonProperty("movieId")]
    public int MovieId { get; set; }

    [JsonProperty("language")]
    public string Language { get; set; }

    [JsonProperty("releaseInfo")]
    public List<string> ReleaseInfo { get; set; }

    [JsonProperty("commentary")]
    public string? Commentary { get; set; }

    [JsonProperty("files")]
    public int? Files { get; set; }

    [JsonProperty("size")]
    public long? Size { get; set; }

    [JsonProperty("hearingImpaired")]
    public bool HearingImpaired { get; set; }

    [JsonProperty("foreignParts")]
    public bool ForeignParts { get; set; }

    [JsonProperty("framerate")]
    public string? Framerate { get; set; }

    [JsonProperty("productionType")]
    public string? ProductionType { get; set; }

    [JsonProperty("releaseType")]
    public string? ReleaseType { get; set; }

    [JsonProperty("downloads")]
    public long Downloads { get; set; }

    [JsonProperty("comments")]
    public long Comments { get; set; }

    [JsonProperty("rating")]
    public Rating Rating { get; set; }

    [JsonProperty("preview")]
    public string? Preview { get; set; }

    [JsonProperty("uploaderId")]
    public int UploaderId { get; set; }

    [JsonProperty("createdAt")]
    public DateTimeOffset CreatedAt { get; set; }

    [JsonProperty("contributors")]
    public List<Contributor> Contributors { get; set; }
}
