using BornDigital.ReoAko.Api.Models.Response;

namespace BornDigital.ReoAko.Api
{
    public interface IReoAkoService
    {
        /// <summary>
        /// Performs a search against the ReoAko API
        /// </summary>
        /// <param name="search">The term to search for</param>
        /// <param name="origin">The base URI of the web application making the request</param>
        /// <returns>ReoAko search results</returns>
        Task<EntriesResponse?> SearchAsync(string search, string origin);
    }
}
