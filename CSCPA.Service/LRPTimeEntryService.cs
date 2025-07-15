using AutoMapper;
using CSCPA.Data.Entities;
using CSCPA.Model;
using CSCPA.Repo;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSCPA.Service
{
    public interface ILRPTimeEntryService
    {
        Task<IEnumerable<LRPTimeEntryListModel>> GetAll();
        Task<bool> Delete(Guid id);
        Task<LRPTimeEntryAddEditModel> Get(Guid id);
        Task<bool> Save(LRPTimeEntryAddEditModel model);
        Task<bool> Update(Guid id,string values);
        LoadResult GetPage(DataSourceLoadOptionsBase options);
        Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions);
    }

    public class LRPTimeEntryService : BaseService, ILRPTimeEntryService
    {
        public LRPTimeEntryService(IUnitOfWork uow, UserResolverService userResolverService, IMapper mapper)
            : base(uow, userResolverService, mapper)
        {
        }

        public LoadResult GetPage(DataSourceLoadOptionsBase options)
        {
            var query = _uow.LRPTimeEntryRepository.Query().IgnoreAutoIncludes().Where(x => x.IsDeleted == false)
                .Select(s => new LRPTimeEntryListModel
                {
                    ObjectUid = s.ObjectUid,
                    Name = s.Name,
                    LrpcodeId = s.LrpcodeId,
                    LrpemployeeId = s.LrpemployeeId,
                    LrpDateStart = s.LrpDateStart,
                    LrpDateEnd = s.LrpDateEnd,
                    Percentage = s.Percentage,
                    Description = s.Description
                }); ;

            return DataSourceLoader.Load(query, options);
        }

        public async Task<IEnumerable<LRPTimeEntryListModel>> GetAll()
        {
            return _mapper.Map<List<LRPTimeEntryListModel>>(await _uow.LRPTimeEntryRepository.GetAll());
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _uow.LRPTimeEntryRepository.Get(id);
            entity.UpdatedOn = DateTime.UtcNow;
            entity.IsDeleted = true;
            await _uow.LRPTimeEntryRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();
        }

        public async Task<LRPTimeEntryAddEditModel> Get(Guid id)
        {
            return _mapper.Map<LRPTimeEntryAddEditModel>(await _uow.LRPTimeEntryRepository.Get(id));
        }

        public async Task<bool> Save(LRPTimeEntryAddEditModel model)
        {

            if (model.ObjectUid == null)
            {
                LrptimeEntry entity = _mapper.Map<LrptimeEntry>(model);
                entity.CreatedOn = DateTime.UtcNow;
                entity.NameAlias = entity.Name;
                await _uow.LRPTimeEntryRepository.Add(entity);
            }
            else
            {
                LrptimeEntry entity = await _uow.LRPTimeEntryRepository.Get(model.ObjectUid.Value);
                entity = _mapper.Map<LRPTimeEntryAddEditModel, LrptimeEntry>(model, entity);
                entity.UpdatedOn = DateTime.UtcNow;
                await _uow.LRPTimeEntryRepository.Update(entity);
                _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            }
            return await _uow.SaveAsync();

        }

        public async Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.LRPTimeEntryRepository.Query().Where(x => x.IsDeleted == false).Select(x =>
                new SelectListItem
                {
                    Value = x.ObjectUid.ToString().ToLower(),
                    Text = x.Name
                });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }
        public async Task<bool> Update(Guid id, string values)
        {
            LrptimeEntry entity = await _uow.LRPTimeEntryRepository.Get(id);
            JsonConvert.PopulateObject(values, entity);

            entity.UpdatedOn = DateTime.UtcNow;
            await _uow.LRPTimeEntryRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();

        }
    }
}