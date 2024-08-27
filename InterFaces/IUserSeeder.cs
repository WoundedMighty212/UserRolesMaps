using Microsoft.AspNetCore.Identity;
using UserRolesMaps.Models;

namespace UserRolesMaps.InterFaces
{
    public interface IUserSeeder
    {
        Task SeedUsersAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, Dictionary<string, string> userData, List<string> passwords);
    }
}
