using BugTracking.Api.Enum;

namespace BugTracking.Api.DTOs.BugReport
{
    public class UpdateBugDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public BugStatus Status { get; set; }
        public Severity SeverityLevel { get; set; }
        public string? ReproductionSteps { get; set; }
        public string DeveloperId { get; set; }
        public IFormFile? File { get; set; }
    }
}
