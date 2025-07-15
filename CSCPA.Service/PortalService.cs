using AutoMapper;
using CSCPA.Data.Entities;
using CSCPA.Repo;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCPA.Service
{
    public interface IPortalService
    {
        Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions);
    }
    public class PortalService : BaseService, IPortalService
    {
        public PortalService(IUnitOfWork uow, UserResolverService userResolverService, IMapper mapper)
          : base(uow, userResolverService, mapper)
        {
        }
        public async Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.PortalRepository.Query().Where(x => x.IsDeleted == false).Select(x =>
                new Portal
                {
                    ObjectUid = x.ObjectUid,
                    Name = x.Name
                });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }
    }
}
