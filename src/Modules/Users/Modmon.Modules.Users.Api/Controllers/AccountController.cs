using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modmon.Modules.Users.Core.DTO;
using Modmon.Modules.Users.Core.Services;
using Modmon.Shared.Abstractions.Auth;

namespace Modmon.Modules.Users.Api.Controllers
{
    internal class AccountController : BaseController
    {
        private readonly IIdentityService _identityService;
        private readonly IHttpContext _context;

        public AccountController(IIdentityService identityService, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _identityService = identityService;
            _context = httpContextAccessor.HttpContext;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<AccountDto>> GetAsync()
            => OkOrNotFound(await _identityService.GetAsync());

        [HttpPost("sign-up")]
        public async Task<ActionResult> SignUpAsync(SignUpDto dto)
        {
            await _identityService.SignUpAsync(dto);
            return NoContent();
        }

        [HttpPost("sign-in")]
        public async Task<ActionResult<JsonWebToken>> SignInAsync(SignInDto dto)
            => Ok(await _identityService.SignInAsync(dto));
    }
}
