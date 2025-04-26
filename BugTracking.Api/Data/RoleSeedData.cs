using BugTracking.Api.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BugTracking.Api.Data
{
    public class RoleSeedData
    {
        public static async Task SeedRolesAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();

            string[] roleNames = { "User", "Developer", "Admin" };
            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            var user = new AppUser
            {
                Fullname = "Super User",
                UserName = "Super",
                Email = "salil.bajracharya911@gmail.com"
            };

            if(await userManager.FindByNameAsync("Super") == null)
            {
                var password = new PasswordHasher<AppUser>();
                var hashed = password.HashPassword(user, "Super@123");
                user.PasswordHash = hashed;

                var userStore = new UserStore<AppUser>(serviceProvider.GetRequiredService<ApplicationDbContext>());
                await userStore.CreateAsync(user);

                await userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}
