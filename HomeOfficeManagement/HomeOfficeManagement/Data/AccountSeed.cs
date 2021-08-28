using HomeOfficeManagement.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeOfficeManagement.Data
{
    //public class AccountSeed
    //{
    //}

    public class AccountSeed
    {
        public static async Task SeedRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
            await roleManager.CreateAsync(new IdentityRole("Admin"));
            await roleManager.CreateAsync(new IdentityRole("Employee"));
        }

        public static async Task SeedSuperAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            //var AdminUser = new IdentityUser
            //{
                
            //    Email = "admin@admin.com",
            //    UserName = "admin@admin.com",
            //    EmailConfirmed = true,
            //    PhoneNumberConfirmed = true
            //};
            var defaultUser = new ApplicationUser
            {

                Email = "user@user.com",
                UserName = "user@user.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            IdentityResult result = null;
            if ((await userManager.FindByNameAsync(defaultUser.UserName.ToUpper())) == null)
            {
                result = await userManager.CreateAsync(defaultUser, "Password#123");
                if (result.Succeeded)
                {

                        await userManager.AddToRoleAsync(defaultUser, "SuperAdmin");
                    
                }
            }

            else
            {

            }
                   


            //if ((await _userManager.FindByNameAsync(_adminUser.UserName.ToUpper())) == null)
            //{
            //    result = await _userManager.CreateAsync(_adminUser, "Singularity@123");
            //    if (result.Succeeded)
            //    {
            //        if (await CheckAndCreateRoleAsync(_adminRole))
            //        {
            //            await _userManager.AddToRoleAsync(_adminUser, _adminRole.Name);
            //        }
            //    }
            //}
            //if (userManager.Users.All(u => u.Id != defaultUser.Id))
            //{
            //    var user = await userManager.FindByEmailAsync(defaultUser.Email);
            //    if (user == null)
            //    {
            //        // await userManager.CreateAsync(AdminUser, "Admin@123");
            //        await userManager.CreateAsync(defaultUser, "User@123");

            //        await userManager.AddToRoleAsync(defaultUser, "Employee");
            //        await userManager.AddToRoleAsync(defaultUser, "SuperAdmin");
            //        await userManager.AddToRoleAsync(defaultUser, "Admin");
            //        // await userManager.AddToRoleAsync(AdminUser, "SuperAdmin");
            //        // await userManager.AddToRoleAsync(AdminUser, "Admin");
            //    }                }


        }
    }
}
