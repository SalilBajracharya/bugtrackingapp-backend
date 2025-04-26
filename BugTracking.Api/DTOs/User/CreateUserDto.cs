using BugTracking.Api.Entities;

namespace BugTracking.Api.DTOs.User
{
    public class CreateUserDto
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }

        public AppUser MapToAppUser()
        {
            return new AppUser
            {
                Fullname = Fullname,
                Email = Email,
                UserName = Username,
                PhoneNumber = PhoneNumber
            };
        }
    }
}
