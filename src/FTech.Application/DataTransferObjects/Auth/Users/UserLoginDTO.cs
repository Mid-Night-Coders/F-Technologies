using FTech.Domain.Enums;

namespace FTech.Application.DataTransferObjects.Auth.Users
{
    public class UserLoginDTO
    {
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
