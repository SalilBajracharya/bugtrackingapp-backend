using BugTracking.Api.DTOs.Auth;
using BugTracking.Api.Entities;
using BugTracking.Api.Services.JwtService;
using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace BugTracking.Api.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }
        public async Task<Result<string>> ValidateUser(LoginRequestDto request)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.UserName == request.Username
                                || x.Email == request.Email);

            if (user is null)
                return Result.Fail("Invalid username or email");

            var passwordValidate = await _signInManager.PasswordSignInAsync(user, request.Password, false, false);

            if(!passwordValidate.Succeeded)
                return Result.Fail("Invalid password");

            var roles = await _userManager.GetRolesAsync(user);
            var token = await _tokenService.GenerateJwtToken(user, roles);

            return Result.Ok(token);
        }
    }
}
