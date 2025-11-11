namespace InsuranceAPI.Models
{
    public class Driver
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public int YearsOfExperience { get; set; }
        public int NoClaimsYears { get; set; }
        public string LicenceNumber { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Relationships

        public User User { get; set; } = new User();
        public ICollection<PolicyDriver> PolicyDrivers { get; set; } = new List<PolicyDriver>();
    }
}