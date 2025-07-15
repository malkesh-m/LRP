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
    public interface ILRPEmployeeTypeService
    {
        Task<IEnumerable<LRPEmployeeTypeListModel>> GetAll();
        Task<bool> Delete(Guid id);
        Task<LRPEmployeeTypeAddEditModel> Get(Guid id);
        Task<bool> Save(LRPEmployeeTypeAddEditModel model);
        LoadResult GetPage(DataSourceLoadOptionsBase options);
        Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions);
        Task<bool> Update(Guid id, string values);
    }
    public class LRPEmployeeTypeService : BaseService, ILRPEmployeeTypeService
    {
        public LRPEmployeeTypeService(IUnitOfWork uow, UserResolverService userResolverService, IMapper mapper)
           : base(uow, userResolverService, mapper)
        {
        }

        public LoadResult GetPage(DataSourceLoadOptionsBase options)
        {
            var query = _uow.LRPEmployeeTypeRepository.Query().Where(x => x.IsDeleted == false)
                .Select(s => new LRPEmployeeTypeListModel
                {
                    ObjectUID = s.ObjectUid,
                    Name = s.Name,
                });

            return DataSourceLoader.Load(query, options);
        }

        public async Task<IEnumerable<LRPEmployeeTypeListModel>> GetAll()
        {
            return _mapper.Map<List<LRPEmployeeTypeListModel>>(await _uow.LRPEmployeeTypeRepository.GetAll());
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _uow.LRPEmployeeTypeRepository.Get(id);
            entity.UpdatedOn = DateTime.UtcNow;
            entity.IsDeleted = true;
            await _uow.LRPEmployeeTypeRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();
        }

        public async Task<LRPEmployeeTypeAddEditModel> Get(Guid id)
        {
            return _mapper.Map<LRPEmployeeTypeAddEditModel>(await _uow.LRPEmployeeTypeRepository.Get(id));
        }

        public async Task<bool> Save(LRPEmployeeTypeAddEditModel model)
        {
            if (model.ObjectUID == null)
            {
                LrpemployeeType entity = _mapper.Map<LrpemployeeType>(model);
                entity.CreatedOn = DateTime.UtcNow;
                entity.NameAlias = entity.Name;
                await _uow.LRPEmployeeTypeRepository.Add(entity);
            }
            else
            {
                LrpemployeeType entity = await _uow.LRPEmployeeTypeRepository.Get(model.ObjectUID.Value);
                entity = _mapper.Map<LRPEmployeeTypeAddEditModel, LrpemployeeType>(model, entity);
                entity.UpdatedOn = DateTime.UtcNow;
                await _uow.LRPEmployeeTypeRepository.Update(entity);
                _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            }
            return await _uow.SaveAsync();

        }
        public async Task<bool> Update(Guid id, string values)
        {
            LrpemployeeType entity = await _uow.LRPEmployeeTypeRepository.Get(id);
            JsonConvert.PopulateObject(values, entity);

            entity.UpdatedOn = DateTime.UtcNow;
            await _uow.LRPEmployeeTypeRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();

        }
        public async Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.LRPEmployeeTypeRepository.Query().Where(x => x.IsDeleted == false).Select(x =>
                new LrpemployeeType
                {
                    ObjectUid = x.ObjectUid,
                    Name = x.Name
                });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }
    }
}
