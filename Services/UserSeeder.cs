using Microsoft.AspNetCore.Identity;
using UserRolesMaps.InterFaces;
using UserRolesMaps.Models;

namespace UserRolesMaps.Services
{
    public class UserSeeder : IUserSeeder
    {
        public async Task SeedUsersAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, Dictionary<string, string> userData, List<string> passwords)
        {
            int i = 0;
            List<IdentityUser> userList = new List<IdentityUser>();
            foreach(var user in userData)
            {
                userList.Add(new IdentityUser() { UserName = user.Key, Email = user.Value});
            }
            foreach(var user in userList)
            {
                if (await userManager.FindByEmailAsync(user.Email) == null)
                {
                    var newUser = new IdentityUser
                    {
                        UserName = user.UserName,
                        Email = user.Email
                    };
                    var result = await userManager.CreateAsync(user, passwords[i++]);
                    if (result.Succeeded)
                    {
                        // Ensure that the "Admin" role exists
                        if (await roleManager.RoleExistsAsync("Admin"))
                        {
                            await userManager.AddToRoleAsync(user, "Admin");
                        }
                        else
                        {
                            // Optionally create the role if it doesn't exist
                            await roleManager.CreateAsync(new IdentityRole("Admin"));
                            await userManager.AddToRoleAsync(user, "Admin");
                        }
                    }
                }
            }
        }
    }
}
