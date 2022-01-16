using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWallet.Utility
{
    public static class Helper
    {
        public static string Admin = "Admin";
        public static string User = "User";
        public static string Manager = "Manager";

        public static List<SelectListItem> GetRolesForDropDown(bool isAdmin)
        {
            if (isAdmin)
            {
                return new List<SelectListItem>
                {
                    new SelectListItem { Value = Helper.Admin, Text = Helper.Admin }
                };
            }
            else
            {
                return new List<SelectListItem>
                {               
                    new SelectListItem{Value = Helper.Manager, Text = Helper.Manager},
                    new SelectListItem{Value = Helper.User, Text = Helper.User}
                };
            }
        }
    }
}
