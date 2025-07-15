using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CSCPA.Service
{
    //public class AdditionalUserClaimsPrincipalFactory
    //      : UserClaimsPrincipalFactory<User, IdentityRole>
    //{
    //    public AdditionalUserClaimsPrincipalFactory(
    //        UserManager<User> userManager,
    //        RoleManager<IdentityRole> roleManager,
    //        IOptions<IdentityOptions> optionsAccessor)
    //        : base(userManager, roleManager, optionsAccessor)
    //    {
    //    }

    //    public async override Task<ClaimsPrincipal> CreateAsync(User user)
    //    {
    //        var principal = await base.CreateAsync(user);
    //        var identity = (ClaimsIdentity)principal.Identity;

    //        var claims = new List<Claim>
    //        {
    //            new Claim("UserId", user.Id),
    //            new Claim("FullName", user.FirstName + " " + user.LastName),
    //            new Claim("CompanyId",user.CompanyId.ToString())
    //        };

    //        identity.AddClaims(claims);
    //        return principal;
    //    }
    //}
}
