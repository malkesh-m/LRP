using System;
using System.Security.Claims;
using System.Security.Principal;

namespace CSCPA.Web
{
    public static class ClaimsPrincipalExtensions
    {

        public static string GetFullName(this IIdentity identity)
        {
            Claim claim = ((ClaimsIdentity)identity).FindFirst("FullName");
            return claim != null ? claim.Value : string.Empty;
        }

        public static string GetUserId(this IIdentity identity)
        {
            Claim claim = ((ClaimsIdentity)identity).FindFirst(ClaimTypes.NameIdentifier);
            return claim != null ? claim.Value.ToString() : string.Empty;
        }

        public static Guid GetCompanyId(this IIdentity identity)
        {
            Claim claim = ((ClaimsIdentity)identity).FindFirst("token");
            return claim != null ? Guid.Parse(claim.Value) : Guid.Empty;
        }

        public static string GetUserRole(this IIdentity identity)
        {
            Claim claim = ((ClaimsIdentity)identity).FindFirst(ClaimTypes.Role);
            return claim != null ? Convert.ToString(claim.Value) : string.Empty;
        }
    }
}
