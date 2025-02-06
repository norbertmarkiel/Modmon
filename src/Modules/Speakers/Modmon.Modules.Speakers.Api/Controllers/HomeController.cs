using Microsoft.AspNetCore.Mvc;

namespace Modmon.Modules.Speakers.Api.Controllers
{
    [Route(SpeakersModule.BasePath)]
    internal class HomeController : BaseController
    {
        [HttpGet]
        public ActionResult<string> Get() => "Hello World from Modmon Speakers Home internal controller!";
    }
}
