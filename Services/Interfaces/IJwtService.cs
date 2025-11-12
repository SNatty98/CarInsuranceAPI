using InsuranceAPI.Models;

namespace InsuranceAPI.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);
        int? ValidateToken(string token);
    }
}