using BugTracking.Api.DTOs.Auth;
using BugTracking.Api.DTOs.User;
using FluentResults;

namespace BugTracking.Api.Services.AuthService
{
    public interface IAuthService
    {
        Task<Result> ValidateUser(LoginRequestDto request);
    }
}
