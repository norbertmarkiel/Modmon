using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace Modmon.Modules.Users.Api.Controllers
{
    [Route(UsersModule.BasePath)]
    internal class HomeController : BaseController
    {
        [HttpGet]
        public ActionResult<string> Get() => "Users API";
    }
}
