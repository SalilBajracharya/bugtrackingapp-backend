using BugTracking.Api.DTOs.BugReport;
using BugTracking.Api.Enum;
using BugTracking.Api.Services.BugService;
using FluentResults;
using MediatR;

namespace BugTracking.Api.Segretation.Commands.Bugs
{
    public class UpdateBugReportCommand : IRequest<Result<string>>
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public BugStatus Status { get; set; }
        public Severity SeverityLevel { get; set; }
        public string? ReproductionSteps { get; set; }
        public string? DeveloperId { get; set; }
        public IFormFile? File { get; set; }
    }

    public class UpdateBugReportCommandHandler : IRequestHandler<UpdateBugReportCommand, Result<string>>
    {
        private readonly IBugService _bugService;
        public UpdateBugReportCommandHandler(IBugService bugService)
        {
            _bugService = bugService;
        }
        public async Task<Result<string>> Handle(UpdateBugReportCommand request, CancellationToken cancellationToken)
        {
            var updateDto = new UpdateBugDto
            {
                Id = request.Id,
                Title = request.Title,
                Description = request.Description,
                Status = request.Status,
                SeverityLevel = request.SeverityLevel,
                ReproductionSteps = request.ReproductionSteps,
                DeveloperId = request.DeveloperId,
                File = request.File
            };
            return await _bugService.UpdateAsync(updateDto);
        }
    }
}
