using BugTracking.Api.DTOs.BugReport;
using BugTracking.Api.Services.BugService;
using FluentResults;
using MediatR;
using System.Linq;

namespace BugTracking.Api.Segretation.Queries.Bugs
{
    public class GetAllBugQuery : IRequest<Result<List<BugDto>>>
    {
        public string? search { get; set; }
        public int? severity { get; set; }
        public int? status { get; set; }
    }

    public class GetBugQueryHandler : IRequestHandler<GetAllBugQuery, Result<List<BugDto>>>
    {
        private readonly IBugService _bugService;
        public GetBugQueryHandler(IBugService bugService)
        {
            _bugService = bugService;
        }
        public async Task<Result<List<BugDto>>> Handle(GetAllBugQuery request, CancellationToken cancellationToken)
        {
            var result = await _bugService.GetAllBug();
            var bugs = result.Value;

            if (!string.IsNullOrWhiteSpace(request.search))
            {
                var searchLower = request.search.ToLower();
                bugs = bugs.Where(b =>
                    (!string.IsNullOrEmpty(b.Title) && b.Title.ToLower().Contains(searchLower)) ||
                    (!string.IsNullOrEmpty(b.Description) && b.Description.ToLower().Contains(searchLower))
                ).ToList();
            }

            if (request.severity.HasValue)
            {
                bugs = bugs.Where(b => (int)b.SeverityLevel == request.severity.Value).ToList();
            }

            if (request.status.HasValue)
            {
                bugs = bugs.Where(b => (int)b.Status == request.status.Value).ToList();
            }

            return Result.Ok(bugs);
        }
    }
}
