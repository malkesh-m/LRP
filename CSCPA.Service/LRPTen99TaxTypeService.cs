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
    public interface ILRPTen99TaxTypeService
    {
        Task<IEnumerable<LRPTen99TaxTypeListModel>> GetAll();
        Task<bool> Delete(Guid id);
        Task<LRPTen99TaxTypeAddEditModel> Get(Guid id);
        Task<bool> Save(LRPTen99TaxTypeAddEditModel model);
        LoadResult GetPage(DataSourceLoadOptionsBase options);
        Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions);
        Task<bool> Update(Guid id, string values);
    }
    public class LRPTen99TaxTypeService : BaseService, ILRPTen99TaxTypeService
    {
        public LRPTen99TaxTypeService(IUnitOfWork uow, UserResolverService userResolverService, IMapper mapper)
         : base(uow, userResolverService, mapper)
        {
        }

        public LoadResult GetPage(DataSourceLoadOptionsBase options)
        {
            var query = _uow.LRPTen99TaxTypeRepository.Query().Where(x => x.IsDeleted == false)
                .Select(s => new LRPTen99TaxTypeListModel
                {
                    ObjectUID = s.ObjectUid,
                    Name = s.Name,
                    DescriptionBp = s.DescriptionBp,
                    ValueGp = s.ValueGp
                });

            return DataSourceLoader.Load(query, options);
        }

        public async Task<IEnumerable<LRPTen99TaxTypeListModel>> GetAll()
        {
            return _mapper.Map<List<LRPTen99TaxTypeListModel>>(await _uow.LRPTen99TaxTypeRepository.GetAll());
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _uow.LRPTen99TaxTypeRepository.Get(id);
            entity.UpdatedOn = DateTime.UtcNow;
            entity.IsDeleted = true;
            await _uow.LRPTen99TaxTypeRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();
        }

        public async Task<LRPTen99TaxTypeAddEditModel> Get(Guid id)
        {
            return _mapper.Map<LRPTen99TaxTypeAddEditModel>(await _uow.LRPTen99TaxTypeRepository.Get(id));
        }

        public async Task<bool> Save(LRPTen99TaxTypeAddEditModel model)
        {
            if (model.ObjectUID == null)
            {
                Lrpten99TaxType entity = _mapper.Map<Lrpten99TaxType>(model);
                entity.CreatedOn = DateTime.UtcNow;
                entity.NameAlias = entity.Name;
                await _uow.LRPTen99TaxTypeRepository.Add(entity);
            }
            else
            {
                Lrpten99TaxType entity = await _uow.LRPTen99TaxTypeRepository.Get(model.ObjectUID.Value);
                entity = _mapper.Map<LRPTen99TaxTypeAddEditModel, Lrpten99TaxType>(model, entity);
                entity.UpdatedOn = DateTime.UtcNow;
                await _uow.LRPTen99TaxTypeRepository.Update(entity);
                _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            }
            return await _uow.SaveAsync();

        }
        public async Task<bool> Update(Guid id, string values)
        {
            Lrpten99TaxType entity = await _uow.LRPTen99TaxTypeRepository.Get(id);
            JsonConvert.PopulateObject(values, entity);

            entity.UpdatedOn = DateTime.UtcNow;
            await _uow.LRPTen99TaxTypeRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();

        }
        public async Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.LRPTen99TaxTypeRepository.Query().Where(x => x.IsDeleted == false).Select(x =>
                new Lrpten99TaxType
                {
                    ObjectUid = x.ObjectUid,
                    Name = x.Name
                });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }
    }
}
