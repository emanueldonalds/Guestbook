using Microsoft.AspNetCore.Identity;
using Novia.Guestbook.Presentation.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Novia.Guestbook.Presentation.Web.Data
{
    public static class GuestbookIdentityDbContextSeeder
    {
        public static async Task SeedAsync(GuestbookIdentityDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Use the Migrate method to automatically create the database and migrat if needed
            context.Database.EnsureCreated();
            var userName = "admin@novia.fi";
            var administratorUser = await userManager.FindByNameAsync (userName);
            bool IsFirstTime = false;

            if (administratorUser == null)
            {
                administratorUser = new ApplicationUser
                {
                    UserName = userName, Email = userName
                };

                await userManager.CreateAsync(administratorUser, "Pass@word1");
                IsFirstTime = true;}var userRole = await roleManager.FindByNameAsync("user");
            if (userRole == null)
            {
                userRole = new IdentityRole("user");
                await roleManager.CreateAsync(userRole);
            }
            var administratorRole = await roleManager.FindByNameAsync("administrator");
            if (administratorRole == null)
            {
                administratorRole = new IdentityRole("administrator");
                await roleManager.CreateAsync(administratorRole);
            }
            if (IsFirstTime == true)
                await userManager.AddToRoleAsync(administratorUser, administratorRole.Name);
            await context.SaveChangesAsync();
        }
    }
}