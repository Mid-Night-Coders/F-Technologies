using FTech.Application.DataTransferObjects.Auth;
using FTech.Application.DataTransferObjects.Auth.Drivers;
using FTech.Application.DataTransferObjects.Auth.Users;
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
        public async ValueTask<IActionResult> UserLogin(UserLoginDTO loginDTO)
        {
            return Ok(await _authService.UserLogin(loginDTO));
        }

        [HttpPost]
        public async ValueTask<IActionResult> UserRegister(UserRegisterDTO registerDTO)
        {
            return Ok(await _authService.UserRegister(registerDTO));
        }

        [HttpPost]
        public async ValueTask<IActionResult> DriverLogin(DriverLoginDTO loginDTO)
        {
            return Ok(await _authService.DriverLogin(loginDTO));
        }

        [HttpPost]
        public async ValueTask<IActionResult> DriverRegister(DriverRegisterDTO registerDTO)
        {
            return Ok(await _authService.DriverRegister(registerDTO));
        }
    }
}