using BugTracking.Api.Common.Exceptions;
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
                throw new GenericException("User creation failed", result.Errors.Select(e => new Error(e.Description)).ToList());
            }

            var roleResult = await _userManager.AddToRoleAsync(user, request.Role);
            if (!roleResult.Succeeded)
            {
                throw new GenericException("Role creation failed", result.Errors.Select(e => new Error(e.Description)).ToList());

            }

            return Result.Ok();
        }

        public Task<Result> DeleteUserAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<List<UserDto>>> GetAllUsersAsync()
        {
            var userList = _userManager.Users.ToList();
            var userDtoList = userList.Select(user => new UserDto
            {
                Id = user.Id,
                Fullname = user.Fullname,
                Username = user.UserName,
                Password = user.PasswordHash,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Role = _userManager.GetRolesAsync(user).Result.FirstOrDefault()
            }).ToList();
            return Result.Ok(userDtoList);
        }

        public async Task<Result<UserDto>> GetUserByIdAsync(string userId)
        {
            var user = _userManager.Users.Where(x => x.Id == userId).FirstOrDefault();
            if (user == null)
            {
                throw new NotFoundException("User not found");
            }

            var roles = await _userManager.GetRolesAsync(user);

            var userDto = new UserDto
            {
                Id = user.Id,
                Fullname = user.Fullname,
                Email = user.Email,
                Username = user.UserName,
                Password = user.PasswordHash,
                PhoneNumber = user.PhoneNumber,
                Role = roles.FirstOrDefault()
            };

            return Result.Ok(userDto);
        }

        public Task<Result> RemoveRoleFromUserAsync(string userId, string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
