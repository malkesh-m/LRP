using AutoMapper;
using CSCPA.Data.Entities;
using CSCPA.Model;
using CSCPA.Repo;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSCPA.Service
{
    public interface IGLAccountLookupService
    {
        Task<LoadResult> GetLookupReportGroup(DataSourceLoadOptionsBase loadOptions);
        Task<LoadResult> GetLookupGroup(DataSourceLoadOptionsBase loadOptions);
        Task<LoadResult> GetLookupSub(DataSourceLoadOptionsBase loadOptions);
        Task<LoadResult> GetLookupSubSub(DataSourceLoadOptionsBase loadOptions);
        Task<LoadResult> GetLookupSubSubSub(DataSourceLoadOptionsBase loadOptions);
    }
    public class GLAccountLookupService : BaseService, IGLAccountLookupService
    {
        public GLAccountLookupService(IUnitOfWork uow, UserResolverService userResolverService, IMapper mapper)
           : base(uow, userResolverService, mapper)
        {
        }

        public async Task<LoadResult> GetLookupReportGroup(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.BdgreportGroupRepository.Query().Where(x => x.IsDeleted == false).Select(x =>
               new SelectListModel
               {
                   Value = x.ObjectUid,
                   Text = x.Name
               });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }

        public async Task<LoadResult> GetLookupGroup(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.BdgaccountGroupRepository.Query().Where(x => x.IsDeleted == false).Select(x =>
               new SelectListModel
               {
                   Value = x.ObjectUid,
                   Text = x.Name
               });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }

        public async Task<LoadResult> GetLookupSub(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.BdgaccountGroupSubGroupRepository.Query().Where(x => x.IsDeleted == false).Select(x =>
               new SelectListModel
               {
                   Value = x.ObjectUid,
                   Text = x.Name,
                   FilterValue = x.BdgaccountGroupId
               });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }

        public async Task<LoadResult> GetLookupSubSub(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.BdgaccountGroupSubGroupSubGroupRepository.Query().Where(x => x.IsDeleted == false).Select(x =>
               new SelectListModel
               {
                   Value = x.ObjectUid,
                   Text = x.Name,
                   FilterValue = x.BdgaccountGroupSubGroupId
               });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }

        public async Task<LoadResult> GetLookupSubSubSub(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.BdgaccountGroupSubGroupSubGroupSubGroupRepository.Query().Where(x => x.IsDeleted == false).Select(x =>
               new SelectListModel
               {
                   Value = x.ObjectUid,
                   Text = x.Name,
                   FilterValue = x.BdgaccountGroupSubGroupSubGroupId
               });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }
    }
}
