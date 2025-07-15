using CSCPA.Core.Constant;
using CSCPA.Service;
using CSCPA.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSCPA.Web.Helpers;

namespace CSCPA.Web.Controllers
{
    public class PermissionController : Controller
    {
        /*        private IRoleService _roleService;
                private IUserAccountRolePermissionListService _userRolePerService;
                public PermissionController(IRoleService roleService, IUserAccountRolePermissionListService userRolePerService)
                {
                    _roleService = roleService;
                    _userRolePerService = userRolePerService;
                }
                public IActionResult Index(Guid roleId)
                {
                    var model = new PermissionViewModel();
                    var allPermissions = new List<RoleClaimsViewModel>();
                   // allPermissions.GetPermissions(typeof(Permissions.Products), (Guid)roleId);
                    var role = _roleService.Get(roleId);
                    model.RoleId = roleId;
                    var claims = _userRolePerService.GetClaims(roleId);
                    var allClaimValues = allPermissions.Select(a => a.Value).ToList();
                    var roleClaimValues = claims.Select(a => a.Value).ToList();
                    var authorizedClaims = allClaimValues.Intersect(roleClaimValues).ToList();
                    return View();
                }*/
    }
}
