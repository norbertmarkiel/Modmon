using Microsoft.AspNetCore.Mvc;

namespace Modmon.Modules.Speakers.Api.Controllers
{
    [ApiController]
    [Route(SpeakersModule.BasePath + "[controller]")]
    internal class BaseController : ControllerBase
    {
        protected ActionResult<T> OkOrNotFound<T>(T model)
        {
            if (model is null)
            {
                return NotFound();
            }
            return Ok(model);
        }
    }
}
