using BugTracking.Api.Common.Exceptions;
using BugTracking.Api.DTOs.Auth;
using BugTracking.Api.Entities;
using BugTracking.Api.Services.JwtService;
using FluentResults;
using Microsoft.AspNetCore.Http.HttpResults;
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
        public async Task<Result<LoginResponseDto>> ValidateUser(LoginRequestDto request)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.UserName == request.Username
                                || x.Email == request.Username);

            if (user is null)
                throw new BadRequestException("Invalid username or Email");

            var passwordValidate = await _signInManager.PasswordSignInAsync(user, request.Password, false, false);

            if(!passwordValidate.Succeeded)
                throw new BadRequestException("Invalid password");

            var roles = await _userManager.GetRolesAsync(user);
            var token = await _tokenService.GenerateJwtToken(user, roles);

            var response = new LoginResponseDto
            {
                Token = token
            };

            return Result.Ok(response);
        }
    }
}
