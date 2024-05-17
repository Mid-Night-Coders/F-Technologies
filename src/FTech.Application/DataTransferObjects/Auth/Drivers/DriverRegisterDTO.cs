using FTech.Domain.Enums;

using Microsoft.AspNetCore.Http;

namespace FTech.Application.DataTransferObjects.Auth.Drivers
{
    public class DriverRegisterDTO
    {
        public string FistName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public IFormFile DriverAvatar { get; set; }

        // Additional properties for future use
        public string Country { get; set; }
        public string City { get; set; }
        public string LicenseNumber { get; set; }
        public DateOnly LicenseIssueDate { get; set; }
        public IFormFile LicenseFrontImage { get; set; }
        public IFormFile LicenseBackImage { get; set; }
    }
}
