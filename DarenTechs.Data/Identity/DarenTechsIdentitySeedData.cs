using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarenTechs.Data.Identity
{
    public class DarenTechsIdentitySeedData
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<DarenTechsIdentityContext>();
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();

            context.Database.EnsureCreated();

            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var userName = configuration.GetSection("Admin").GetSection("UserName").Value;
            var email = configuration.GetSection("Admin").GetSection("Email").Value;
            var password = configuration.GetSection("Admin").GetSection("Password").Value;

            var roles = CreateRoles();

            foreach (var role in roles)
            {
                if (!context.Roles.Any(r => r.Name == role.Name))
                {
                    await roleManager.CreateAsync(role).ConfigureAwait(false);
                }
            }

            await context.SaveChangesAsync();

            if (!context.Users.Any(u => u.UserName == userName))
            {
                var user = new ApplicationUser
                {
                    UserName = userName,
                    Email = email,
                    EmailConfirmed = true,
                    NormalizedEmail = email.ToUpper(),
                    NormalizedUserName = userName.ToUpper(),
                    PhoneNumber = null,
                    PhoneNumberConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                var passwordHash = new PasswordHasher<ApplicationUser>();
                user.PasswordHash = passwordHash.HashPassword(user, password);
                var result = await userManager.CreateAsync(user);

                if (result.Succeeded)
                {
                    await userManager.AddToRolesAsync(user, roles.Select(role => role.Name)).ConfigureAwait(false);
                }
                await context.SaveChangesAsync();
            }
        }

        private static IList<IdentityRole> CreateRoles()
        {
            var RoleName = "Administrator";

            var role = new IdentityRole
            {
                Name = RoleName
            };

            var roles = new List<IdentityRole>();
            roles.Add(role);

            return roles;

        }
    }
}
