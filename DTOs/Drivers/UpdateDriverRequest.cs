namespace InsuranceAPI.DTOs
{
    public class UpdateDriverRequest
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int YearsOfExperience { get; set; }
        public int NoClaimsYears { get; set; }
    }
}