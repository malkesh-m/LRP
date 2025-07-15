using Microsoft.AspNetCore.Http;

namespace CSCPA.Service
{
    public class UserResolverService
    {
        private readonly IHttpContextAccessor _context;

        public UserResolverService(IHttpContextAccessor context)
        {
            _context = context;
        }

        public System.Security.Principal.IIdentity GetUser()
        {
            return _context.HttpContext.User?.Identity;
        }
    }
}