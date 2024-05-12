using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using onion_architecture.Application.Features.Auth;
using onion_architecture.Application.IService;
using onion_architecture.Infrastructure.Settings;

namespace onion_architecture.Api.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login(LoginDto dto)
        {
            return Ok(_authService.Login(dto));
        }
        [AllowAnonymous]
        [HttpPost("Register")]
        public IActionResult Register(RegisterDto dto)
        {
            return Ok(_authService.Register(dto));
        }
        [Authorize]
        [HttpPost("Refresh_token")]
        public IActionResult Refresh_token([FromBody] RefreshTokenSettings refreshToken)
        {
            return Ok(_authService.Refresh_Token(refreshToken));
        }
    }
}
