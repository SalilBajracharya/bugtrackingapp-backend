using Microsoft.AspNetCore.Identity;

namespace BugTracking.Api.Entities
{
    public class AppUser : IdentityUser
    {
        public string Fullname { get; set; }
        public DateTime LastLogin { get; set; }
    }
}
