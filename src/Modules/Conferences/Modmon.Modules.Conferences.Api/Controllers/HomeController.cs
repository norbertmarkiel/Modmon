using Microsoft.AspNetCore.Mvc;

namespace Modmon.Modules.Conferences.Api.Controllers
{
    [Route(ConferencesModule.BasePath)]
    internal  class HomeController : BaseController
    {
        [HttpGet]
        public ActionResult<string> Get() => "Hello World from Modmon Home internal controller!";
    }
}
