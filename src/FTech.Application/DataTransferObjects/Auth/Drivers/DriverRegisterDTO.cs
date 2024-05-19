using Microsoft.AspNetCore.Http;

namespace FTech.Application.DataTransferObjects.Auth.Drivers
{
    public class DriverRegisterDTO
    {
        public int UserId { get; set; }
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
