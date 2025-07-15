using CSCPA.Repo;
using CSCPA.Service;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CSCPA.Web.Permission
{
    internal class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
    {
        IUnitOfWork _permissionListService;
        public PermissionAuthorizationHandler(IUnitOfWork permissionListService) 
        {
            _permissionListService = permissionListService;   
        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            if (context.User == null)
            {
                return;
            }
           
            
            var isChanged = _permissionListService.RoleRepository.Query().Where(x=> x.Name == context.User.Identity.GetUserRole()).FirstOrDefault();
            if(context.User.Identity.GetUserRole() == "SystemAdmin")
            {
                context.Succeed(requirement);
                return;
            }
            else if (isChanged != null)
            {
                if (isChanged.ImportedObjectUid == context.User.Claims.FirstOrDefault(x => x.Type == "token").Value || string.IsNullOrEmpty(isChanged.ImportedObjectUid))
                {
                    var claims = context.User.Claims.FirstOrDefault(x => x.Type == "Permission" && x.Value == requirement.Permission && x.Issuer == "LOCAL AUTHORITY");
                    if (claims != null)
                    {
                        context.Succeed(requirement);
                        return;
                    }
                }
            }
           
        }
    }
}
