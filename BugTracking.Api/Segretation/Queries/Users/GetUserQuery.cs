using BugTracking.Api.DTOs.User;
using BugTracking.Api.Services.UserService;
using FluentResults;
using MediatR;

namespace BugTracking.Api.Segretation.Queries.Users
{
    public record GetUserQuery : IRequest<Result<UserDto>>
    {
        public string UserId { get; set; }
    }

    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, Result<UserDto>>
    {
        private readonly IUserService _userService;
        public GetUserQueryHandler(IUserService userService)
        {
            _userService = userService;
        }
        public Task<Result<UserDto>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            return _userService.GetUserByIdAsync(request.UserId);
        }
    }
}
