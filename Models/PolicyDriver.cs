namespace InsuranceAPI.Models
{
    public class PolicyDriver
    {
        public int DriverId { get; set; }
        public int PolicyId { get; set; }
        public bool IsMainDriver { get; set; }

        // RelationShips
        public Policy Policy { get; set; } = null!;
        public Driver Driver { get; set; } = null!;
    }
}