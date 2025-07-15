using AutoMapper;
using CSCPA.Data.Entities;
using CSCPA.Model;
using CSCPA.Repo;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;

using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSCPA.Service
{
    public interface ILRPVendorClassService
    {
        Task<IEnumerable<LRPVendorClassListModel>> GetAll();
        Task<bool> Delete(Guid id);
        Task<LRPVendorClassAddEditModel> Get(Guid id);
        Task<bool> Save(LRPVendorClassAddEditModel model);
        LoadResult GetPage(DataSourceLoadOptionsBase options);
        Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions);
        Task<bool> Update(Guid id, string values);
    }
    public class LRPVendorClassService : BaseService,ILRPVendorClassService
    {
        public LRPVendorClassService(IUnitOfWork uow, UserResolverService userResolverService, IMapper mapper)
          : base(uow, userResolverService, mapper)
        {
        }

        public LoadResult GetPage(DataSourceLoadOptionsBase options)
        {
            var query = _uow.LRPVendorClassRepository.Query().Where(x => x.IsDeleted == false)
                .Select(s => new LRPVendorClassListModel
                {
                    ObjectUID = s.ObjectUid,
                    VendorClassNo = s.VendorClassNo,
                });

            return DataSourceLoader.Load(query, options);
        }

        public async Task<IEnumerable<LRPVendorClassListModel>> GetAll()
        {
            return _mapper.Map<List<LRPVendorClassListModel>>(await _uow.LRPVendorClassRepository.GetAll());
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _uow.LRPVendorClassRepository.Get(id);
            entity.UpdatedOn = DateTime.UtcNow;
            entity.IsDeleted = true;
            await _uow.LRPVendorClassRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();
        }

        public async Task<LRPVendorClassAddEditModel> Get(Guid id)
        {
            return _mapper.Map<LRPVendorClassAddEditModel>(await _uow.LRPVendorClassRepository.Get(id));
        }

        public async Task<bool> Save(LRPVendorClassAddEditModel model)
        {
            if (model.ObjectUID == null)
            {
                LrpvendorClass entity = _mapper.Map<LrpvendorClass>(model);
                entity.CreatedOn = DateTime.UtcNow;
                entity.NameAlias = entity.Name;
                await _uow.LRPVendorClassRepository.Add(entity);
            }
            else
            {
                LrpvendorClass entity = await _uow.LRPVendorClassRepository.Get(model.ObjectUID.Value);
                entity = _mapper.Map<LRPVendorClassAddEditModel, LrpvendorClass>(model, entity);
                entity.UpdatedOn = DateTime.UtcNow;
                await _uow.LRPVendorClassRepository.Update(entity);
                _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            }
            return await _uow.SaveAsync();
        }
        public async Task<bool> Update(Guid id, string values)
        {
            LrpvendorClass entity = await _uow.LRPVendorClassRepository.Get(id);
            JsonConvert.PopulateObject(values, entity);

            entity.UpdatedOn = DateTime.UtcNow;
            await _uow.LRPVendorClassRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();

        }
        public async Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.LRPVendorClassRepository.Query().Where(x => x.IsDeleted == false).Select(x =>
                new LrpvendorClass
                {
                    ObjectUid = x.ObjectUid,
                    Name = x.Name
                });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }
    }
}
