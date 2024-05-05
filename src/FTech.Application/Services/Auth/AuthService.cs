using FTech.Application.DataTransferObjects.Auth;
using FTech.Application.Services.Helpers;
using FTech.Application.Services.JWT;
using FTech.Domain.Entities.Auth;
using FTech.Domain.Exceptions;
using FTech.Infrastructure.Repositories.Users;

namespace FTech.Application.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJWTService _jWTService;

        public AuthService(
            IUserRepository userRepository,
            IPasswordHasher passwordHasher,
            IJWTService jWTService)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jWTService = jWTService;
        }

        public async ValueTask<TokenDTO> Login(LoginDTO loginDTO)
        {
            if (String.IsNullOrWhiteSpace(loginDTO.PhoneNumber) && String.IsNullOrWhiteSpace(loginDTO.Password))
                throw new ValidationException("Phone number can not be null or white space.");

            var storedUser = await _userRepository
                .GetByPhoneNumberAsync(loginDTO.PhoneNumber);

            if (storedUser is null)
                throw new ValidationException("User not found");

            return _jWTService.GenerateAccessToken(storedUser);
        }

        public async ValueTask<TokenDTO> Register(RegisterDTO registerDTO)
        {
            if (String.IsNullOrWhiteSpace(registerDTO.PhoneNumber) && String.IsNullOrWhiteSpace(registerDTO.Password))
                throw new ValidationException("Phone number can not be null or white space.");

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

            return _jWTService.GenerateAccessToken(user); ;
        }
    }
}
