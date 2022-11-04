using System.Text.Json.Serialization;

namespace BornDigital.ReoAko.Api.Models.Response;

public class EntriesResultItem
{
    [JsonPropertyName("headword")]
    public string? Headword { get; set; }
    [JsonPropertyName("function")]
    public string? Function { get; set; }
    [JsonPropertyName("definition")]
    public string? Definition { get; set; }
    [JsonPropertyName("translations")]
    public List<Translation>? Translations { get; set; }
}
