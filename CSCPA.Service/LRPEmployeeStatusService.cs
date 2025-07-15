using AutoMapper;
using CSCPA.Data.Entities;
using CSCPA.Model;
using CSCPA.Repo;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCPA.Service
{
    public interface ILRPEmployeeStatusService
    {
        Task<IEnumerable<LRPEmployeeStatusListModel>> GetAll();
        Task<bool> Delete(Guid id);
        Task<LRPEmployeeStatusAddEditModel> Get(Guid id);
        Task<bool> Save(LRPEmployeeStatusAddEditModel model);
        LoadResult GetPage(DataSourceLoadOptionsBase options);
        Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions);
        Task<bool> Update(Guid id, string values);
    }
    public class LRPEmployeeStatusService : BaseService, ILRPEmployeeStatusService
    {
        public LRPEmployeeStatusService(IUnitOfWork uow, UserResolverService userResolverService, IMapper mapper)
         : base(uow, userResolverService, mapper)
        {
        }

        public LoadResult GetPage(DataSourceLoadOptionsBase options)
        {
            var query = _uow.LRPEmployeeStatusRepository.Query().Where(x => x.IsDeleted == false)
                .Select(s => new LRPEmployeeStatusListModel
                {
                    ObjectUID = s.ObjectUid,
                    Name = s.Name,
                });

            return DataSourceLoader.Load(query, options);
        }

        public async Task<IEnumerable<LRPEmployeeStatusListModel>> GetAll()
        {
            return _mapper.Map<List<LRPEmployeeStatusListModel>>(await _uow.LRPEmployeeStatusRepository.GetAll());
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _uow.LRPEmployeeStatusRepository.Get(id);
            entity.UpdatedOn = DateTime.UtcNow;
            entity.IsDeleted = true;
            await _uow.LRPEmployeeStatusRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();
        }

        public async Task<LRPEmployeeStatusAddEditModel> Get(Guid id)
        {
            return _mapper.Map<LRPEmployeeStatusAddEditModel>(await _uow.LRPEmployeeStatusRepository.Get(id));
        }

        public async Task<bool> Save(LRPEmployeeStatusAddEditModel model)
        {
            if (model.ObjectUID == null)
            {
                LrpemployeeStatus entity = _mapper.Map<LrpemployeeStatus>(model);
                entity.CreatedOn = DateTime.UtcNow;
                entity.NameAlias = entity.Name;
                await _uow.LRPEmployeeStatusRepository.Add(entity);
            }
            else
            {
                LrpemployeeStatus entity = await _uow.LRPEmployeeStatusRepository.Get(model.ObjectUID.Value);
                entity = _mapper.Map<LRPEmployeeStatusAddEditModel, LrpemployeeStatus>(model, entity);
                entity.UpdatedOn = DateTime.UtcNow;
                await _uow.LRPEmployeeStatusRepository.Update(entity);
                _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            }
            return await _uow.SaveAsync();

        }
        public async Task<bool> Update(Guid id, string values)
        {
            LrpemployeeStatus entity = await _uow.LRPEmployeeStatusRepository.Get(id);
            JsonConvert.PopulateObject(values, entity);

            entity.UpdatedOn = DateTime.UtcNow;
            await _uow.LRPEmployeeStatusRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();

        }
        public async Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.LRPEmployeeStatusRepository.Query().Where(x => x.IsDeleted == false).Select(x =>
                new LrpemployeeStatus
                {
                    ObjectUid = x.ObjectUid,
                    Name = x.Name
                });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }
    }
}
