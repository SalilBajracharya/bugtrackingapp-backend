using BugTracking.Api.Entities;
using BugTracking.Api.Enum;

namespace BugTracking.Api.DTOs.BugReport
{
    public class BugDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Severity SeverityLevel { get; set; }
        public BugStatus Status { get; set; } = BugStatus.Open;
        public string? ReproductionSteps { get; set; }
        public string? FilePath { get; set; }
        public string ReporterId { get; set; }
        public AppUser Reporter { get; set; }
        public string? DeveloperId { get; set; }
        public AppUser? Developer { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
