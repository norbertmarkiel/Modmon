using Microsoft.AspNetCore.Mvc;

namespace Modmon.Modules.Conferences.Api.Controllers
{
    [ApiController]
    [Route(ConferencesModule.BasePath + "[controller]")]
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
