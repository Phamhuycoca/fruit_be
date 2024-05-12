using onion_architecture.Application.Features.Auth;
using onion_architecture.Application.Features.Dto.UserDto;
using onion_architecture.Application.Wrappers.Concrete;
using onion_architecture.Domain.Entity;
using onion_architecture.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onion_architecture.Application.IService
{
    public interface IAuthService
    {
        DataResponse<TokenDTO> Login(LoginDto dto);
        DataResponse<User> Register(RegisterDto dto);
        TokenDTO CreateToken(User user);
        DataResponse<TokenDTO> Refresh_Token(RefreshTokenSettings token);


    }
}
