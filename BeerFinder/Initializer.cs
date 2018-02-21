using System;
using BeerFinder.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace BeerFinder
{
    public class Initializer
    {
        public static async void Initialize(IServiceProvider services)
        {
            using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var _manager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var _roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                try
                {
                    await _roleManager.CreateAsync(new IdentityRole("admin"));
                }
                catch
                {
                    Exception e;
                }

                var user = new ApplicationUser()
                {
                    UserName = "hrvoje.maligec@fer.hr",
                    Email = "hrvoje.maligec@fer.hr",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                try
                {
                    await _manager.CreateAsync(user, "$ifrA123");
                    await _manager.AddToRoleAsync(user, "admin");
                }
                catch
                {
                    Exception e;
                }
            }
        }
    }
}