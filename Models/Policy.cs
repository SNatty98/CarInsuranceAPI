using System.Security.Claims;
using InsuranceAPI.Data.Enums;

namespace InsuranceAPI.Models
{
    public class Policy
    {
        public int Id { get; set; }
        public string PolicyNumber { get; set; } = string.Empty;
        public int UserId { get; set; }
        public int VehicleId { get; set; }
        public int QuoteId { get; set; }
        public decimal Premium { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public PolicyStatus Status { get; set; } = PolicyStatus.Active;

        // Relationships

        public User User { get; set; } = new User();
        public Quote Quote { get; set; } = new Quote();
        public Vehicle Vehicle { get; set; } = new Vehicle();
        public ICollection<PolicyDriver> PolicyDrivers { get; set; } = new List<PolicyDriver>();
        public ICollection<Claim> Claims { get; set; } = new List<Claim>();
    }
}