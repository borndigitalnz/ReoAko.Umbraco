using System.Text.Json.Serialization;
using BornDigital.ReoAko.Api.Models.Response;

namespace BornDigital.ReoAko.Umbraco.Models
{
    public sealed class ReoAkoTranslation
    {
        [JsonPropertyName("en")]
        public string? En { get; }
        [JsonPropertyName("mi")]
        public string? Mi { get; }
        [JsonPropertyName("slug")]
        public string? Slug { get; }

        public ReoAkoTranslation(Translation rawTranslation)
        {
            En = rawTranslation.En;
            Mi = rawTranslation.Mi;
            Slug = rawTranslation.Slug;
        }
    }
}
