using Microsoft.AspNetCore.Identity;

namespace UserRolesMaps.Models
{
    public class ApplicationRole : IdentityRole
    {
        private string roleName;
        public ApplicationRole() { }
        public ApplicationRole(string roleName)
        {
            this.roleName = roleName;
        }
    }
}
