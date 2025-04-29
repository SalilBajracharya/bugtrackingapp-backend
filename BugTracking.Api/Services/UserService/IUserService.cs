using BugTracking.Api.DTOs.User;
using FluentResults;

namespace BugTracking.Api.Services.UserService
{
    public interface IUserService
    {
        Task<Result> CreateUserAsync(CreateUserDto request);
        Task<Result> DeleteUserAsync(string userId);
        Task<Result<UserDto>> GetUserByIdAsync(string userId);
        Task<Result<List<UserDto>>> GetAllUsersAsync();
        Task<Result> AssignRoleToUserAsync(string userId, string roleName);
        Task<Result> ChangePasswordAsync(ChangePasswordDto request);
        Task<Result<List<DeveloperDto>>> GetDevelopers();
    }
}
