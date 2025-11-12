using InsuranceAPI.Services.Interfaces;
using InsuranceAPI.DTOs.Auth;
using InsuranceAPI.Models;
using InsuranceAPI.Data.Enums;
using InsuranceAPI.Data.Repositories.Interfaces;

namespace InsuranceAPI.Services.Implementations
{
    public class AuthService : IAuthService
    {

        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> RegisterAsync(RegisterRequest request)
        {
            if (await _userRepository.EmailAlreadyExistsAsync(request.Email))
            {
                throw new InvalidOperationException("Email already exists.");
            }

            if (request.Password != request.PasswordConfirmation)
            {
                throw new InvalidOperationException("Passwords do not match.");
            }

            var user = new User
            {
                Email = request.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Role = UserRole.Customer
            };

            return await _userRepository.AddAsync(user);
        }

        public async Task<User?> LoginRequest(LoginRequest request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);

            if (user == null)
            {
                return null;
            }

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return null;
            }

            return user;
        }
    }
}