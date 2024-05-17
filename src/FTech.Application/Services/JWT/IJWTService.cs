using FTech.Application.DataTransferObjects.Auth;
using FTech.Domain.Entities.Auth;

namespace FTech.Application.Services.JWT
{
    public interface IJWTService
    {
        TokenDTO GenerateAccessToken(User user);
        TokenDTO GenerateAccessToken(Driver driver);
    }
}
