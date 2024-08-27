using Microsoft.AspNetCore.Identity;
using UserRolesMaps.InterFaces;
using UserRolesMaps.Models;

namespace UserRolesMaps.Services
{
    public class RoleSeeder : IRoleSeeder
    {
        public async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
            }
            if (!await roleManager.RoleExistsAsync("User"))
            {
                await roleManager.CreateAsync(new IdentityRole { Name = "User" });
            }
        }
    }
}
