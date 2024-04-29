using FTech.Domain.Enums;

namespace FTech.Domain.Entities.Auth
{
    public class User
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpireDate { get; set; }

        public Role Roles { get; set; }
    }
}
