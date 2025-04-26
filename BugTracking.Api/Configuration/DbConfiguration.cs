using BugTracking.Api.Data;
using BugTracking.Api.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BugTracking.Api.Configuration
{
    public static class DbConfiguration
    {
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration config)
        { 
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("Default")));

            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddDataProtection();
        }

        public static async Task SeedDatabaseAsync(IServiceProvider serviceProvider)
        {
            await RoleSeedData.SeedRolesAsync(serviceProvider);
        }
    }
}
