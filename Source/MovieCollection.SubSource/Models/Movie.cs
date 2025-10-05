using Newtonsoft.Json;

namespace MovieCollection.SubSource.Models;

public class Movie
{
    [JsonProperty("movieId")]
    public int MovieId { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("alternateTitle")]
    public string AlternateTitle { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("releaseYear")]
    public long ReleaseYear { get; set; }

    [JsonProperty("imdbId")]
    public string ImdbId { get; set; }

    [JsonProperty("tmdbId")]
    public int? TmdbId { get; set; }

    [JsonProperty("season")]
    public int? Season { get; set; }

    [JsonProperty("subtitleCount")]
    public long? SubtitleCount { get; set; }

    [JsonProperty("posters")]
    public Poster Posters { get; set; }
}
