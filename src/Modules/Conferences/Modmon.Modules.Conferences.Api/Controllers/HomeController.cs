using Microsoft.AspNetCore.Mvc;

namespace Modmon.Modules.Conferences.Api.Controllers
{
    [Route("conferences")]
    internal  class HomeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get() => "Hello World from Modmon Home internal controller!";
    }
}
