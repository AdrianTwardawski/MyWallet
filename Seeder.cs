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
        public Seeder(ApplicationDbContext dbContext, RoleManager<IdentityRole> roleManager)
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
        }
            public void Seed()
            {
                if (!_dbContext.Roles.Any())
                {
                    _roleManager.CreateAsync(new IdentityRole(Helper.Admin)).GetAwaiter().GetResult();
                    _roleManager.CreateAsync(new IdentityRole(Helper.User)).GetAwaiter().GetResult();
                }
            }
           
        
    }

   
}
