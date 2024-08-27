using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using UserRolesMaps.Data;
using UserRolesMaps.InterFaces;
using UserRolesMaps.Models;
using UserRolesMaps.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddRazorPages(); // Add this line to register Razor Pages

//builder.Services.AddDefaultIdentity<IdentityUser>()
//    .AddRoles<IdentityRole>()
//    .AddRoleManager<RoleManager<IdentityRole>>()
//    .AddEntityFrameworkStores<ApplicationDbContext>();

// Configure Identity with roles
builder.Services.AddIdentity<IdentityUser, ApplicationRole>(options =>
{
    // Configure Identity options here if needed
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;

    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = true;
}).AddUserManager<UserManager<IdentityUser>>()
  .AddRoleManager<RoleManager<ApplicationRole>>()
 .AddRoles<ApplicationRole>()
 .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();
// Register the IRoleSeeder implementation
builder.Services.AddTransient<IRoleSeeder, RoleSeeder>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapControllerRoute(
name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    //try
    //{
    var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
    var roleManager = services.GetRequiredService<RoleManager<ApplicationRole>>();
    var roleSeeder = services.GetRequiredService<IRoleSeeder>();
    await roleSeeder.SeedRolesAsync(roleManager);
    //}
    //catch (Exception ex)
    //{
    //    // Handle errors
    //}
}

app.Run();
