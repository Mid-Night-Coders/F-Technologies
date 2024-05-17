using FTech.Domain.Enums;

namespace FTech.Application.DataTransferObjects.Auth.Users
{
    public class UserRegisterDTO
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
