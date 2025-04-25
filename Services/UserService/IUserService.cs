using BugTracking.Api.DTOs.User;
using FluentResults;

namespace BugTracking.Api.Services.UserService
{
    public interface IUserService
    {
        Task<Result> CreateUserAsync(CreateUserDto request);
        Task<Result> DeleteUserAsync(string userId);
        Task<Result> GetUserByIdAsync(string userId);
        Task<Result> GetAllUsersAsync();
        Task<Result> AssignRoleToUserAsync(string userId, string roleName);
        Task<Result> RemoveRoleFromUserAsync(string userId, string roleName);
        Task<Result> ChangePasswordAsync(ChangePasswordDto request);
    }
}
