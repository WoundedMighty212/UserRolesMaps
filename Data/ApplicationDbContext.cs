using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserRolesMaps.Models;

namespace UserRolesMaps.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<UserRolesMaps.Models.CustomUsers> CustomUsers { get; set; } = default!;
        public DbSet<UserRolesMaps.Models.CustomRoles> CustomRoles { get; set; } = default!;
        public DbSet<UserRolesMaps.Models.Catagory> Catagory { get; set; } = default!;
        public DbSet<UserRolesMaps.Models.Events> Events { get; set; } = default!;
    }
}
