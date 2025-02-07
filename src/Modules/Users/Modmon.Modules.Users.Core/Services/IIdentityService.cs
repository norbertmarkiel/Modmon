using Modmon.Modules.Users.Core.DTO;
using Modmon.Shared.Abstractions.Auth;

namespace Modmon.Modules.Users.Core.Services
{
    public interface IIdentityService
    {
        Task<AccountDto> GetAsync(Guid id);
        Task<JsonWebToken> SignInAsync(SignInDto dto);
        Task SignUpAsync(SignUpDto dto);
    }
}
