using FTech.Domain.Enums;

namespace FTech.Domain.Entities.Auth
{
    public class User
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? PasswordHash { get; set; }
        public string? Salt { get; set; }

        public Role Role { get; set; }

        public Driver? Driver { get; set; }
    }
}
