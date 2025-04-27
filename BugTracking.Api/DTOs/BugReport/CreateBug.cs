using BugTracking.Api.Entities;
using BugTracking.Api.Enum;

namespace BugTracking.Api.DTOs.BugReport
{
    public class CreateBug
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Severity SeverityLevel { get; set; }
        public string? ReproductionSteps { get; set; }
        public IFormFile? File { get; set; }
        public Bug MapToBug()
        {
            return new Bug
            {
                Title = Title,
                Description = Description,
                SeverityLevel = SeverityLevel,
                ReproductionSteps = ReproductionSteps,
            };
        }
        
    }
}
