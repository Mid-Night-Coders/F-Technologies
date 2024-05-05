using FTech.Domain.Enums;

namespace FTech.Application.DataTransferObjects.Auth
{
    public class RegisterDTO
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
