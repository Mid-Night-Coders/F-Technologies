using FTech.Domain.Enums;

namespace FTech.Domain.Entities.Auth
{
    public class Driver
    {
        public int Id { get; set; }
        public string? FistName { get; set; }
        public string? LastName { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? LicenseNumber { get; set; }
        public DateOnly? LicenseIssueDate { get; set; }
        public string? PhoneNumber { get; set; }
        public string? PasswordHash { get; set; }
        public string? Salt { get; set; }
        public string? LicenseFrontImagePath { get; set; }
        public string? LicenseBackImagePath { get; set; }
        public string? DriverAvatarPath { get; set; }
    }
}
