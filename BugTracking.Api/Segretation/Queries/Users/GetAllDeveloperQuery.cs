using BugTracking.Api.DTOs.User;
using BugTracking.Api.Services.UserService;
using FluentResults;
using MediatR;

namespace BugTracking.Api.Segretation.Queries.Users
{
    public class GetAllDeveloperQuery : IRequest<Result<List<DeveloperDto>>>
    {
    }

    public class GetAllDeveloperQueryHandler : IRequestHandler<GetAllDeveloperQuery, Result<List<DeveloperDto>>>
    {
        private readonly IUserService _userService;
        public GetAllDeveloperQueryHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<Result<List<DeveloperDto>>> Handle(GetAllDeveloperQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetDevelopers();
        }
    }
}
