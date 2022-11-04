using System.Text.Json.Serialization;

namespace BornDigital.ReoAko.Api.Models.Response
{
    public class EntriesResponse
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }
        [JsonPropertyName("next")]
        public string? Next { get; set; }
        [JsonPropertyName("previous")]
        public string? Previous { get; set; }
        [JsonPropertyName("results")]
        public List<EntriesResultItem>? Results { get; set; }
    }
}
