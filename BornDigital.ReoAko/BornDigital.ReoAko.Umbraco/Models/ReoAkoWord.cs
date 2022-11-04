using System.Text.Json.Serialization;
using BornDigital.ReoAko.Api.Models.Response;

namespace BornDigital.ReoAko.Umbraco.Models
{
    public sealed class ReoAkoWord
    {
        [JsonPropertyName("headword")]
        public string? Headword { get; }
        [JsonPropertyName("function")]
        public string? Function { get; }
        [JsonPropertyName("definition")]
        public string? Definition { get; }
        [JsonPropertyName("translations")]
        public List<ReoAkoTranslation>? Translations { get; }

        public ReoAkoWord(EntriesResultItem rawResultItem)
        {
            if (rawResultItem.Translations == null || !rawResultItem.Translations.Any()) return;

            Headword = rawResultItem.Headword;
            Function = rawResultItem.Function;
            Definition = rawResultItem.Definition;
            Translations = new List<ReoAkoTranslation> { new(rawResultItem.Translations.First()) };
        }
    }
}
