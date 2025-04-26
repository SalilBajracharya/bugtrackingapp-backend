using BugTracking.Api.DTOs.User;
using BugTracking.Api.Services.UserService;
using FluentResults;
using MediatR;

namespace BugTracking.Api.Segretation.Queries.Users
{
    public record GetAllUserQuery : IRequest<Result<List<UserDto>>>
    {
    }

    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, Result<List<UserDto>>>
    {
        private readonly IUserService _userService;
        public GetAllUserQueryHandler(IUserService userService)
        {
            _userService = userService;
        }
        public Task<Result<List<UserDto>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            return _userService.GetAllUsersAsync();
        }
    }
}
