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
    public interface ILRPVendorService
    {
        Task<IEnumerable<LRPVendorListModel>> GetAll();
        Task<bool> Delete(Guid id);
        Task<LRPVendorAddEditModel> Get(Guid id);
        Task<bool> Save(LRPVendorAddEditModel model);
        LoadResult GetPage(DataSourceLoadOptionsBase options, List<string> departments);
        Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions);
        Task<bool> Update(Guid id, string values);
    }
    public class LRPVendorService : BaseService, ILRPVendorService
    {
        public LRPVendorService(IUnitOfWork uow, UserResolverService userResolverService, IMapper mapper)
             : base(uow, userResolverService, mapper)
        {
        }

        public LoadResult GetPage(DataSourceLoadOptionsBase options, List<string> departments)
        {
            var query = _uow.LRPVendorRepository.Query().Where(x => x.IsDeleted == false )
                .Select(s => new LRPVendorListModel
                {
                    ObjectUID = s.ObjectUid,
                    Name = s.Name,
                    VendorNo = s.VendorNo,
                    AddressI = s.AddressI,
                    AddressIi = s.AddressIi,
                    AddressIii = s.AddressIii,
                    City = s.City,
                    PostalCode = s.PostalCode,
                    CountryId = s.CountryId,
                    CountryStateId = s.CountryStateId,
                    LrpvendorClassId = s.LrpvendorClassId,
                    LrpdepartmentId = s.LrpdepartmentId,
                    Userdef1 = s.Userdef1
                });

            return DataSourceLoader.Load(query, options);
        }

        public async Task<IEnumerable<LRPVendorListModel>> GetAll()
        {
            return _mapper.Map<List<LRPVendorListModel>>(await _uow.LRPVendorRepository.GetAll());
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _uow.LRPVendorRepository.Get(id);
            entity.UpdatedOn = DateTime.UtcNow;
            entity.IsDeleted = true;
            await _uow.LRPVendorRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();
        }

        public async Task<LRPVendorAddEditModel> Get(Guid id)
        {
            return _mapper.Map<LRPVendorAddEditModel>(await _uow.LRPVendorRepository.Get(id));
        }

        public async Task<bool> Save(LRPVendorAddEditModel model)
        {
            if (model.ObjectUID == null)
            {
                Lrpvendor entity = _mapper.Map<Lrpvendor>(model);
                entity.CreatedOn = DateTime.UtcNow;
                entity.NameAlias = entity.Name;
                await _uow.LRPVendorRepository.Add(entity);
            }
            else
            {
                Lrpvendor entity = await _uow.LRPVendorRepository.Get(model.ObjectUID.Value);
                entity = _mapper.Map<LRPVendorAddEditModel, Lrpvendor>(model, entity);
                entity.UpdatedOn = DateTime.UtcNow;
                await _uow.LRPVendorRepository.Update(entity);
                _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            }
            return await _uow.SaveAsync();

        }
        public async Task<bool> Update(Guid id, string values)
        {
            Lrpvendor entity = await _uow.LRPVendorRepository.Get(id);
            JsonConvert.PopulateObject(values, entity);

            entity.UpdatedOn = DateTime.UtcNow;
            await _uow.LRPVendorRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();

        }
        public async Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.LRPVendorRepository.Query().Where(x => x.IsDeleted == false).Select(x =>
                new Lrpvendor
                {
                    ObjectUid = x.ObjectUid,
                    Name = x.Name
                });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }
    }
}
