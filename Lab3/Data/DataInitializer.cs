using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

public class DataInitializer
{
    public static async Task SeedData(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        await SeedRoles(roleManager);
        await SeedUsers(userManager);
    }

    public static async Task SeedUsers(UserManager<IdentityUser> userManager)
    {
        if (await userManager.FindByEmailAsync("admin@admin.com") == null)
        {
            var user = new IdentityUser
            {
                UserName = "admin@admin.com",
                Email = "admin@admin.com",
            };

            var result = await userManager.CreateAsync(user, "test123");

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }

        if (await userManager.FindByEmailAsync("user@user.com") == null)
        {
            var user = new IdentityUser
            {
                UserName = "user@user.com",
                Email = "user@user.com",
            };

            await userManager.CreateAsync(user, "test321");
        }
    }

    public static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
    {
        if (!await roleManager.RoleExistsAsync("Admin"))
        {
            var role = new IdentityRole("Admin");
            await roleManager.CreateAsync(role);
        }
    }
}
