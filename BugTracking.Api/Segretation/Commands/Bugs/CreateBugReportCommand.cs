using BugTracking.Api.DTOs.BugReport;
using BugTracking.Api.Enum;
using BugTracking.Api.Services.BugService;
using FluentResults;
using MediatR;

namespace BugTracking.Api.Segretation.Commands.Bugs
{
    public record CreateBugReportCommand : IRequest<Result<string>>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Severity SeverityLevel { get; set; }
        public string? ReproductionSteps { get; set; }
        public IFormFile? File { get; set; }
    }

    public class CreateBugReportCommandHandler : IRequestHandler<CreateBugReportCommand, Result<string>>
    {
        private readonly IBugService _bugService;
        public CreateBugReportCommandHandler(IBugService bugService)
        {
            _bugService = bugService;
        }
        public async Task<Result<string>> Handle(CreateBugReportCommand request, CancellationToken cancellationToken)
        {
            var createBug = new CreateBug
            {
                Title = request.Title,
                Description = request.Description,
                SeverityLevel = request.SeverityLevel,
                ReproductionSteps = request.ReproductionSteps,
                File = request.File,
            };
            return await _bugService.CreateAsync(createBug);
        }
    }
}
