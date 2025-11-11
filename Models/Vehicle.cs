using InsuranceAPI.Data.Enums;

namespace InsuranceAPI.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int YearRegistered { get; set; }
        public string RegistrationNumber { get; set; } = string.Empty;
        public decimal EngineSize { get; set; }
        public decimal Value { get; set; }
        public int InsuranceGroup { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Relationships
        public User User = new User();
        public ICollection<Quote> Quotes = new List<Quote>();
        public ICollection<Policy> Policies = new List<Policy>();
    }
}