using BugTracking.Api.DTOs.Auth;
using BugTracking.Api.Entities;
using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace BugTracking.Api.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<Result> ValidateUser(LoginRequestDto request)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.UserName == request.Username
                                || x.Email == request.Email);

            if (user is null)
                return Result.Fail("Invalid username or email");

            var passwordValidate = await _signInManager.PasswordSignInAsync(user, request.Password, false, false);

            if(!passwordValidate.Succeeded)
                return Result.Fail("Invalid password");

            return Result.Ok();
        }
    }
}
