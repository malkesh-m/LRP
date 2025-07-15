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
    public interface ILRPVoucherStatusService
    {
        Task<IEnumerable<LRPVoucherStatusListModel>> GetAll();
        Task<bool> Delete(Guid id);
        Task<LRPVoucherStatusAddEditModel> Get(Guid id);
        Task<bool> Save(LRPVoucherStatusAddEditModel model);
        LoadResult GetPage(DataSourceLoadOptionsBase options);
        Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions);
        Task<bool> Update(Guid id, string values);
    }
    public class LRPVoucherStatusService : BaseService, ILRPVoucherStatusService
    {
        public LRPVoucherStatusService(IUnitOfWork uow, UserResolverService userResolverService, IMapper mapper)
     : base(uow, userResolverService, mapper)
        {
        }

        public LoadResult GetPage(DataSourceLoadOptionsBase options)
        {
            var query = _uow.LRPVoucherStatusRepository.Query().Where(x => x.IsDeleted == false)
                .Select(s => new LRPVoucherStatusListModel
                {
                    ObjectUID = s.ObjectUid,
                    Name = s.Name,
                });

            return DataSourceLoader.Load(query, options);
        }

        public async Task<IEnumerable<LRPVoucherStatusListModel>> GetAll()
        {
            return _mapper.Map<List<LRPVoucherStatusListModel>>(await _uow.LRPVoucherStatusRepository.GetAll());
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _uow.LRPVoucherStatusRepository.Get(id);
            entity.UpdatedOn = DateTime.UtcNow;
            entity.IsDeleted = true;
            await _uow.LRPVoucherStatusRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();
        }

        public async Task<LRPVoucherStatusAddEditModel> Get(Guid id)
        {
            return _mapper.Map<LRPVoucherStatusAddEditModel>(await _uow.LRPVoucherStatusRepository.Get(id));
        }

        public async Task<bool> Save(LRPVoucherStatusAddEditModel model)
        {
            if (model.ObjectUID == null)
            {
                LrpvoucherStatus entity = _mapper.Map<LrpvoucherStatus>(model);
                entity.CreatedOn = DateTime.UtcNow;
                entity.NameAlias = entity.Name;
                await _uow.LRPVoucherStatusRepository.Add(entity);
            }
            else
            {
                LrpvoucherStatus entity = await _uow.LRPVoucherStatusRepository.Get(model.ObjectUID.Value);
                entity = _mapper.Map<LRPVoucherStatusAddEditModel, LrpvoucherStatus>(model, entity);
                entity.UpdatedOn = DateTime.UtcNow;
                await _uow.LRPVoucherStatusRepository.Update(entity);
                _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            }
            return await _uow.SaveAsync();

        }
        public async Task<bool> Update(Guid id, string values)
        {
            LrpvoucherStatus entity = await _uow.LRPVoucherStatusRepository.Get(id);
            JsonConvert.PopulateObject(values, entity);

            entity.UpdatedOn = DateTime.UtcNow;
            await _uow.LRPVoucherStatusRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();

        }
        public async Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.LRPVoucherStatusRepository.Query().Where(x => x.IsDeleted == false).Select(x =>
                new LrpvoucherStatus
                {
                    ObjectUid = x.ObjectUid,
                    Name = x.Name
                });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }
    }
}
