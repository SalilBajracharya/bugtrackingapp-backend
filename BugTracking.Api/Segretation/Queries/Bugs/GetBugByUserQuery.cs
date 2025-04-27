using BugTracking.Api.DTOs.BugReport;
using BugTracking.Api.Services.BugService;
using FluentResults;
using MediatR;

namespace BugTracking.Api.Segretation.Queries.Bugs
{
    public record GetBugByUserQuery : IRequest<Result<List<BugDto>>>
    {
    }

    public class GetBugByUserQueryHandler : IRequestHandler<GetBugByUserQuery, Result<List<BugDto>>>
    {
        private readonly IBugService _bugService;
        public GetBugByUserQueryHandler(IBugService bugService)
        {
            _bugService = bugService;
        }
        public async Task<Result<List<BugDto>>> Handle(GetBugByUserQuery request, CancellationToken cancellationToken)
        {
            return await _bugService.GetBugByUser();
        }
    }
}
