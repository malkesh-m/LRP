using CSCPA.Service;
using CSCPA.Web.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;
using static CSCPA.Core.Constant.Permissions;

namespace CSCPA.Web.Helpers
{
   /* public static class ClaimsHelper
    {
        public static void GetPermissions(this List<RoleClaimsViewModel> allPermissions, Type policy, Guid roleId)
        {
            FieldInfo[] fields = policy.GetFields(BindingFlags.Static | BindingFlags.Public);
            foreach (FieldInfo fi in fields)
            {
                allPermissions.Add(new RoleClaimsViewModel { Value = fi.GetValue(null).ToString(), Type = "Permissions" });
            }
        }
        public static async Task AddPermissionClaim(this IUserAccountRolePermissionListService roleManager, Guid role, string permission)
        {
            var allClaims =  roleManager.GetClaims(role);
            if (!allClaims.Any(a => a.Type == "Permission" && a.Value == permission))
            {
                await roleManager.AddClaim(role, new Claim("Permission", permission));
            }
        }
    }*/
}
