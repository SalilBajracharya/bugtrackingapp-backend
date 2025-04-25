using BugTracking.Api.Data;
using BugTracking.Api.DTOs.User;
using BugTracking.Api.Entities;
using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace BugTracking.Api.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _ctx;
        private readonly UserManager<AppUser> _userManager;
        public UserService(ApplicationDbContext ctx, UserManager<AppUser> userManager)
        {
            _ctx = ctx;
            _userManager = userManager;
        }
        public Task<Result> AssignRoleToUserAsync(string userId, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task<Result> ChangePasswordAsync(ChangePasswordDto request)
        {
            throw new NotImplementedException();
        }

        public async Task<Result> CreateUserAsync(CreateUserDto request)
        {
            var user = request.MapToAppUser();
            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                return Result.Fail("User creation failed")
                    .WithErrors(result.Errors.Select(e => new Error(e.Description)));
            }

            var roleResult = await _userManager.AddToRoleAsync(user, request.Role);
            if (!roleResult.Succeeded)
            {
                return Result.Fail("Role assignment failed")
                    .WithErrors(roleResult.Errors.Select(e => new Error(e.Description)));
            }

            return Result.Ok();
        }

        public Task<Result> DeleteUserAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<Result> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Result> GetUserByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<Result> RemoveRoleFromUserAsync(string userId, string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
