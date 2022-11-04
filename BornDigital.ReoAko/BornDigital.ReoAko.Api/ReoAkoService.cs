using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using BornDigital.ReoAko.Api.Models.Response;
using Microsoft.Extensions.Options;

namespace BornDigital.ReoAko.Api
{
    public class ReoAkoService : IReoAkoService
    {
        private readonly HttpClient _httpClient;

        public ReoAkoService(HttpClient httpClient,
            IOptions<ReoAkoSettings> options)
        {
            _httpClient = httpClient;

            var settings = options.Value;

            _httpClient.BaseAddress = new Uri(settings.BaseUri);
            if (!_httpClient.DefaultRequestHeaders.Contains("Authorization"))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", settings.ApiKey);
            }
        }

        /// <inheritdoc />
        public async Task<EntriesResponse?> SearchAsync(string search, string origin)
        {
            SetOrigin(origin);

            var httpResponse = await _httpClient.GetAsync($"/api/v1/entries/?search={search}", HttpCompletionOption.ResponseHeadersRead);
            httpResponse.EnsureSuccessStatusCode();

            if (httpResponse.Content.Headers.ContentType?.MediaType == "application/json")
            {
                var contentStream = await httpResponse.Content.ReadAsStreamAsync();

                try
                {
                    return await JsonSerializer.DeserializeAsync<EntriesResponse>(contentStream,
                        new JsonSerializerOptions
                        {
                            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                            PropertyNameCaseInsensitive = true
                        });
                }
                catch (JsonException) // Invalid JSON
                {
                    Console.WriteLine("Invalid JSON.");
                }
            }
            else
            {
                Console.WriteLine("HTTP Response was invalid and cannot be deserialised.");
            }

            return null;
        }

        private const string OriginHeaderName = "Origin";
        private void SetOrigin(string origin)
        {
            if (_httpClient.DefaultRequestHeaders.Contains(OriginHeaderName))
            {
                _httpClient.DefaultRequestHeaders.Remove(OriginHeaderName);
            }

            _httpClient.DefaultRequestHeaders.Add(OriginHeaderName, origin);
        }
    }
}
