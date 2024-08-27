using Microsoft.AspNetCore.Identity;
using UserRolesMaps.Models;

namespace UserRolesMaps.InterFaces
{
    public interface IRoleSeeder
    {
        Task SeedRolesAsync(RoleManager<IdentityRole> roleManager);
    }
}
