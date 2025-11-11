using InsuranceAPI.Data.Enums;

namespace InsuranceAPI.Models
{
    public class Quote
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int VehicleId { get; set; }
        public int MainDriverId { get; set; }
        public CoverageType CoverageType { get; set; }
        public decimal CalculatedPremium { get; set; }
        public QuoteStatus Status { get; set; } = QuoteStatus.Draft;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime ExpiresAt { get; set; }

        // Relationships

        public User User = new User();
        public Vehicle Vehicle = new Vehicle();
        public Driver Driver = new Driver();
        public Policy? Policy = new Policy();
    }
}