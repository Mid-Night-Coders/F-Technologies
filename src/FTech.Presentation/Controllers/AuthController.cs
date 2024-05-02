using FTech.Application.DataTransferObjects.Auth;
using FTech.Application.Services.Auth;
using Microsoft.AspNetCore.Mvc;

namespace FTech.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
            => _authService = authService;

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            return Ok(await _authService.Login(loginDTO));
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            return Ok(await _authService.Register(registerDTO));
        }
    }
}