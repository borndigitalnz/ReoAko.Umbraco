using System.Net;
using BornDigital.ReoAko.Api;
using BornDigital.ReoAko.Umbraco.Models;
using Umbraco.Cms.Web.Common.Controllers;

namespace BornDigital.ReoAko.Umbraco.Controllers
{
    public class ReoAkoSearchController : UmbracoApiController
    {
        private readonly IReoAkoService _reoAkoService;

        public ReoAkoSearchController(IReoAkoService reoAkoService)
        {
            _reoAkoService = reoAkoService;
        }

        public async Task<IEnumerable<ReoAkoWord>> Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(Request.Headers.Referer.ToString()) ||
                !Request.Headers.Referer.ToString()
                    .Contains("/umbraco/backoffice/reoakosearchmodal", StringComparison.InvariantCultureIgnoreCase))
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return Enumerable.Empty<ReoAkoWord>();
            }

            if (string.IsNullOrWhiteSpace(searchTerm)) return Enumerable.Empty<ReoAkoWord>();

            var origin = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.PathBase}";
            var searchResult = await _reoAkoService.SearchAsync(searchTerm, origin);
            if (searchResult?.Results != null) return searchResult.Results.Select(s => new ReoAkoWord(s));

            return Enumerable.Empty<ReoAkoWord>();
        }
    }
}
