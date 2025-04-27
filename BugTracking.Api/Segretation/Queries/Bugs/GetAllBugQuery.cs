using BugTracking.Api.DTOs.BugReport;
using BugTracking.Api.Services.BugService;
using FluentResults;
using MediatR;

namespace BugTracking.Api.Segretation.Queries.Bugs
{
    public class GetAllBugQuery : IRequest<Result<List<BugDto>>>
    {
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
            return await _bugService.GetAllBug();
        }
    }
}
