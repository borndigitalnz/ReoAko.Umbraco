using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Web.Common.Controllers;

namespace BornDigital.ReoAko.Umbraco.Controllers
{
    public class ReoAkoSearchModalController : UmbracoAuthorizedController
    {
        public IActionResult Index()
        {
            return new ViewResult();
        }
    }
}
