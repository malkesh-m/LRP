using AutoMapper;
using CSCPA.Repo;

namespace CSCPA.Service
{
    public abstract class BaseService
    {
        protected readonly IUnitOfWork _uow;
        protected readonly IMapper _mapper;
        protected int CompanyId;
        protected string UserId;
        protected string FullName;
        protected string UserRole;

        public BaseService(IUnitOfWork uow, UserResolverService userResolverService, IMapper mapper)
        {
            var userClaim = userResolverService.GetUser();
            CompanyId = userClaim.GetCompanyId();
            UserId = userClaim.GetUserId();
            FullName = userClaim.GetFullName();
            UserRole = userClaim.GetUserRole();
            _uow = uow;
            _mapper = mapper;
        }
    }
}
