using Microsoft.AspNetCore.Identity;
using UserRolesMaps.InterFaces;
using UserRolesMaps.Models;

namespace UserRolesMaps.Services
{
    public class RoleSeeder : IRoleSeeder
    {
        public async Task SeedRolesAsync(RoleManager<ApplicationRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new ApplicationRole { Name = "Admin" });
            }
            if (!await roleManager.RoleExistsAsync("User"))
            {
                await roleManager.CreateAsync(new ApplicationRole { Name = "User" });
            }
        }
    }
}
