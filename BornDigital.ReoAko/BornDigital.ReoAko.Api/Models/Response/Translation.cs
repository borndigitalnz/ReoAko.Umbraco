using System.Text.Json.Serialization;

namespace BornDigital.ReoAko.Api.Models.Response;

public class Translation
{
    [JsonPropertyName("url")]
    public string? Url { get; set; }
    [JsonPropertyName("en")]
    public string? En { get; set; }
    [JsonPropertyName("mi")]
    public string? Mi { get; set; }
    [JsonPropertyName("function")]
    public string? Function { get; set; }
    [JsonPropertyName("audio_url")]
    public string? AudioUrl { get; set; }
    [JsonPropertyName("slug")]
    public string? Slug { get; set; }
}
