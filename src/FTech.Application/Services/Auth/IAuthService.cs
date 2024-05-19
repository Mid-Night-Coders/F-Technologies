using FTech.Application.DataTransferObjects.Auth;
using FTech.Application.DataTransferObjects.Auth.Drivers;
using FTech.Application.DataTransferObjects.Auth.Users;

namespace FTech.Application.Services.Auth
{
    public interface IAuthService
    {
        ValueTask<TokenDTO> UserLogin(UserLoginDTO loginDTO);
        ValueTask<TokenDTO> UserRegister(UserRegisterDTO registerDTO);
        ValueTask<TokenDTO> DriverLogin(UserLoginDTO loginDTO);
        ValueTask<TokenDTO> DriverRegister(DriverRegisterDTO registerDTO);
    }
}
