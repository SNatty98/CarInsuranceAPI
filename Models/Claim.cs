using InsuranceAPI.Data.Enums;

namespace InsuranceAPI.Models
{
    public class Claim
    {
        public int Id { get; set; }
        public int PolicyId { get; set; }
        public DateTime IncidentTime { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal ClaimAmount { get; set; }
        public ClaimStatus Status { get; set; } = ClaimStatus.Submitted;
        public int? ReviewedByAgentId { get; set; }
        public int? ReviewedByAdminId { get; set; }
        public string? ReviewNotes { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ReviewedAt { get; set; }

        // Relationships
        public Policy Policy = new Policy();
        public User? ReviewedByAgent { get; set; }
        public User? ReviewedByAdmin { get; set; }
    }
}