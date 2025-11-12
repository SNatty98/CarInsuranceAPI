using InsuranceAPI.DTOs.Auth;
using InsuranceAPI.Models;

namespace InsuranceAPI.Services.Interfaces
{
    public interface IAuthService
    {
        Task<User> RegisterAsync(RegisterRequest request);
        Task<User>? LoginRequest(LoginRequest request);
    }
}