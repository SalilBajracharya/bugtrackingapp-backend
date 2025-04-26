using BugTracking.Api.Enum;
using Microsoft.AspNetCore.Identity;

namespace BugTracking.Api.Entities
{
    public class Bug
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Severity SeverityLevel { get; set; }
        public BugStatus Status { get; set; }
        public string? ReproductionSteps { get; set; }
        public string? FilePath { get; set; }
        public string CreatedById { get; set; } = string.Empty;
        public AppUser? CreatedBy { get; set; }
        public string? AssignedToId { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
