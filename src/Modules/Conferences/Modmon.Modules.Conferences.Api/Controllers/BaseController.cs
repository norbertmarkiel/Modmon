using Microsoft.AspNetCore.Mvc;

namespace Modmon.Modules.Conferences.Api.Controllers
{
    [ApiController]
    [Route(BasePath + "[controller]")]
    internal class BaseController : ControllerBase
    {
        protected const string BasePath = "conferences";


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
