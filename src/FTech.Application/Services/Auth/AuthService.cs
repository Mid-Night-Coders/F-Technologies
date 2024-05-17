using FTech.Application.DataTransferObjects.Auth;
using FTech.Application.DataTransferObjects.Auth.Drivers;
using FTech.Application.DataTransferObjects.Auth.Users;
using FTech.Application.Services.Helpers;
using FTech.Application.Services.JWT;
using FTech.Domain.Entities.Auth;
using FTech.Domain.Exceptions;
using FTech.Infrastructure.Repositories.Drivers;
using FTech.Infrastructure.Repositories.Users;
using FTech.Infrastructure.Services.Files;

namespace FTech.Application.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IDriverRepostory _driverRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IFileService _fileService;
        private readonly IJWTService _jWTService;

        public AuthService(
            IUserRepository userRepository,
            IPasswordHasher passwordHasher,
            IFileService fileService,
            IJWTService jWTService,
            IDriverRepostory driverRepository)
        {
            _driverRepository = driverRepository;
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _fileService = fileService;
            _jWTService = jWTService;
        }

        public async ValueTask<TokenDTO> UserLogin(UserLoginDTO loginDTO)
        {
            if (String.IsNullOrWhiteSpace(loginDTO.PhoneNumber) && String.IsNullOrWhiteSpace(loginDTO.Password))
                throw new ValidationException("Phone number and password cannot be null or whitespace.");

            var storedUser = await _userRepository.GetByPhoneNumberAsync(loginDTO.PhoneNumber);
            if (storedUser is null) 
                throw new ValidationException("User not found");

            return _jWTService.GenerateAccessToken(storedUser);
        }

        public async ValueTask<TokenDTO> UserRegister(UserRegisterDTO registerDTO)
        {
            if (String.IsNullOrWhiteSpace(registerDTO.PhoneNumber) && String.IsNullOrWhiteSpace(registerDTO.Password))
                throw new ValidationException("Phone number and password cannot be null or white space.");

            var storedUser = await _userRepository.GetByPhoneNumberAsync(registerDTO.PhoneNumber);
            if (storedUser is not null) 
                throw new ValidationException("This phone number already registred.");

            var salt = Guid.NewGuid().ToString();
            var passwordHash = _passwordHasher.Encrypt(registerDTO.Password, salt);

            var user = new User()
            {
                Name = registerDTO.Name,
                PhoneNumber = registerDTO.PhoneNumber,
                Role = registerDTO.Role,
                PasswordHash = passwordHash,
                Salt = salt
            };

            user = await _userRepository.AddAsync(user);

            return _jWTService.GenerateAccessToken(user);
        }

        public async ValueTask<TokenDTO> DriverLogin(DriverLoginDTO loginDTO)
        {
            if (String.IsNullOrWhiteSpace(loginDTO.PhoneNumber) && String.IsNullOrWhiteSpace(loginDTO.Password))
                throw new ValidationException("Phone number and password cannot be null or white space.");

            var storedDriver = await _driverRepository.GetByPhoneNumberAsync(loginDTO.PhoneNumber);
            if (storedDriver is null)
                throw new ValidationException("Driver not found");

            return _jWTService.GenerateAccessToken(storedDriver);
        }

        public async ValueTask<TokenDTO> DriverRegister(DriverRegisterDTO registerDTO)
        {
            if (String.IsNullOrWhiteSpace(registerDTO.PhoneNumber) && String.IsNullOrWhiteSpace(registerDTO.Password))
                throw new ValidationException("Phone number and password cannot be null or white space.");


            var driverLicense = await _driverRepository.GetByLicenseNumberAsync(registerDTO.LicenseNumber);
            if (driverLicense is not null)
                throw new ValidationException("This license number already registred.");

            var driverPhone = await _driverRepository.GetByPhoneNumberAsync(registerDTO.PhoneNumber);
            if (driverPhone is not null)
                throw new ValidationException("This phone number already registred.");

            string avatarPath = await _fileService
                .UploadAvatarAsync(registerDTO.DriverAvatar);
            string licenseFrontImagePath = await _fileService
                .UploadImageAsync(registerDTO.LicenseFrontImage);
            string licenseBackImagePath = await _fileService
                .UploadImageAsync(registerDTO.LicenseBackImage);

            var salt = Guid.NewGuid().ToString();
            var passwordHash = _passwordHasher.Encrypt(registerDTO.Password, salt);

            var driver = new Driver()
            {
                FistName = registerDTO.FistName,
                LastName = registerDTO.LastName,
                PhoneNumber = registerDTO.PhoneNumber,
                LicenseNumber = registerDTO.LicenseNumber,
                LicenseIssueDate = registerDTO.LicenseIssueDate,
                Country = registerDTO.Country,
                City = registerDTO.City,
                Salt = salt,
                PasswordHash = passwordHash,
                DriverAvatarPath = avatarPath,
                LicenseBackImagePath = licenseBackImagePath,
                LicenseFrontImagePath = licenseFrontImagePath
            };

            driver = await _driverRepository.AddAsync(driver);

            return _jWTService.GenerateAccessToken(driver);
        }
    }
}