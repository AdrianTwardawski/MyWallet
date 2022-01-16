using Microsoft.AspNetCore.Identity;
using MyWallet.Data;
using MyWallet.Models;
using MyWallet.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWallet
{
    public interface ISeeder
    {
        public void Seed();
    }

    public class Seeder : ISeeder
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public Seeder(ApplicationDbContext dbContext, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
            _userManager = userManager;
        }
            public void Seed()
            {
                if (_dbContext.Roles.Any(r => r.Name == Utility.Helper.Admin)) return;
                {
                    _roleManager.CreateAsync(new IdentityRole(Helper.Admin)).GetAwaiter().GetResult();
                    _roleManager.CreateAsync(new IdentityRole(Helper.Manager)).GetAwaiter().GetResult();
                    _roleManager.CreateAsync(new IdentityRole(Helper.User)).GetAwaiter().GetResult();
                }

                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                    Name = "Admin",
                    EmailConfirmed = true
                }, "Admin123.").GetAwaiter().GetResult();

                ApplicationUser user = _dbContext.Users.FirstOrDefault(u => u.Email == "admin@gmail.com");
                _userManager.AddToRoleAsync(user, Helper.Admin).GetAwaiter().GetResult();

            }
   
    }

   
}
