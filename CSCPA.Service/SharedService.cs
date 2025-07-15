using AutoMapper;
using CSCPA.Repo;

namespace CSCPA.Service
{
    public interface ISharedService
    {
    }

    public class SharedService : BaseService, ISharedService
    {
        public SharedService(IUnitOfWork uow, UserResolverService userResolverService, IMapper mapper) : base(uow, userResolverService, mapper)
        {
        }
    }
}
