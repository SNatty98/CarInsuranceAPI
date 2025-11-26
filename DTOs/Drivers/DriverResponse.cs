namespace InsuranceAPI.DTOs.Drivers
{
    public class DriverResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public int YearsOfExperience { get; set; }
        public int NoClaimsYears { get; set; }
        public string LicenseNumber { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}