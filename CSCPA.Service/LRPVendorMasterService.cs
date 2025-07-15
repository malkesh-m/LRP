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
    public interface ILRPVendorMasterService
    {
        Task<IEnumerable<LRPVendorMasterListModel>> GetAll();
        Task<bool> Delete(Guid id);
        Task<LRPVendorMasterAddEditModel> Get(Guid id);
        Task<bool> Save(LRPVendorMasterAddEditModel model);
        LoadResult GetPage(DataSourceLoadOptionsBase options);
        Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions);
        Task<bool> Update(Guid id, string values);
    }
    public class LRPVendorMasterService : BaseService, ILRPVendorMasterService
    {
        public LRPVendorMasterService(IUnitOfWork uow, UserResolverService userResolverService, IMapper mapper)
         : base(uow, userResolverService, mapper)
        {
        }

        public LoadResult GetPage(DataSourceLoadOptionsBase options)
        {
            var query = _uow.LRPVendorMasterRepository.Query().Where(x => x.IsDeleted == false)
                .Select(s => new LRPVendorMasterListModel
                {
                    ObjectUID = s.ObjectUid,
                    Name = s.Name,
                });

            return DataSourceLoader.Load(query, options);
        }

        public async Task<IEnumerable<LRPVendorMasterListModel>> GetAll()
        {
            return _mapper.Map<List<LRPVendorMasterListModel>>(await _uow.LRPVendorMasterRepository.GetAll());
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _uow.LRPVendorMasterRepository.Get(id);
            entity.UpdatedOn = DateTime.UtcNow;
            entity.IsDeleted = true;
            await _uow.LRPVendorMasterRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();
        }

        public async Task<LRPVendorMasterAddEditModel> Get(Guid id)
        {
            return _mapper.Map<LRPVendorMasterAddEditModel>(await _uow.LRPVendorMasterRepository.Get(id));
        }

        public async Task<bool> Save(LRPVendorMasterAddEditModel model)
        {
            if (model.ObjectUID == null)
            {
                LrpvendorMaster entity = _mapper.Map<LrpvendorMaster>(model);
                entity.CreatedOn = DateTime.UtcNow;
                entity.NameAlias = entity.Name;
                await _uow.LRPVendorMasterRepository.Add(entity);
            }
            else
            {
                LrpvendorMaster entity = await _uow.LRPVendorMasterRepository.Get(model.ObjectUID.Value);
                entity = _mapper.Map<LRPVendorMasterAddEditModel, LrpvendorMaster>(model, entity);
                entity.UpdatedOn = DateTime.UtcNow;
                await _uow.LRPVendorMasterRepository.Update(entity);
                _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            }
            return await _uow.SaveAsync();
        }
        public async Task<bool> Update(Guid id, string values)
        {
            LrpvendorMaster entity = await _uow.LRPVendorMasterRepository.Get(id);
            JsonConvert.PopulateObject(values, entity);

            entity.UpdatedOn = DateTime.UtcNow;
            await _uow.LRPVendorMasterRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();

        }
        public async Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.LRPVendorMasterRepository.Query().Where(x => x.IsDeleted == false).Select(x =>
                new LrpvendorMaster
                {
                    ObjectUid = x.ObjectUid,
                    Name = x.Name
                });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }
    }
}
