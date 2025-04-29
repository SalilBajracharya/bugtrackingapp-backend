using BugTracking.Api.DTOs.Auth;
using BugTracking.Api.Services.AuthService;
using FluentResults;
using MediatR;

namespace BugTracking.Api.Segretation.Queries.Auth
{
    public record ValidateUserQuery : IRequest<Result<LoginResponseDto>>
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class ValidateUserQueryHandler : IRequestHandler<ValidateUserQuery, Result<LoginResponseDto>>
    {
        private readonly IAuthService _authService;
        public ValidateUserQueryHandler(IAuthService authService)
        {
            _authService = authService;
        }
        public Task<Result<LoginResponseDto>> Handle(ValidateUserQuery request, CancellationToken cancellationToken)
        {
            var loginRequestDto = new LoginRequestDto
            {
                Username = request.Username,
                Password = request.Password
            };

            return _authService.ValidateUser(loginRequestDto);
        }
    }
}
