using BugTracking.Api.DTOs.User;
using BugTracking.Api.Services.UserService;
using FluentResults;
using MediatR;

namespace BugTracking.Api.Segretation.Commands.Users
{
    public record CreateUserCommand : IRequest<Result>
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result>
    {
        private readonly IUserService _userService;
        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }
        public Task<Result> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var createUserDto = new CreateUserDto
            {
                Fullname = request.Fullname,
                Email = request.Email,
                Password = request.Password,
                Username = request.Username,
                PhoneNumber = request.PhoneNumber,
                Role = request.Role
            };
            return _userService.CreateUserAsync(createUserDto);
        }
    }
}
