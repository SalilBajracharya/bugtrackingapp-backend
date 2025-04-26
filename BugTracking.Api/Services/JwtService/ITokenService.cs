using BugTracking.Api.Entities;

namespace BugTracking.Api.Services.JwtService
{
    public interface ITokenService
    {
        Task<string> GenerateJwtToken(AppUser user, IList<string> roles);
    }
}
