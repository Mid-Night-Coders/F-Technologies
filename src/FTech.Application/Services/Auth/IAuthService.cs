using FTech.Application.DataTransferObjects.Auth;

namespace FTech.Application.Services.Auth
{
    public interface IAuthService
    {
        ValueTask<TokenDTO> Login(LoginDTO loginDTO);
        ValueTask<TokenDTO> Register(RegisterDTO registerDTO);
    }
}
