namespace InsuranceAPI.DTOs
{
    public class CreateDriverRequest
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public int YearsOfExperience { get; set; }
        public int NoClaimsYears { get; set; }
        public string LicenceNumber { get; set; } = string.Empty;
    }
}