using Microsoft.AspNetCore.Identity;
using UserRolesMaps.Models;

namespace UserRolesMaps.InterFaces
{
    public interface IUserSeeder
    {
        Task SeedUsersAsync(UserManager<IdentityUser> userManager, Dictionary<string, string> userData, List<string> passwords);
    }
}
