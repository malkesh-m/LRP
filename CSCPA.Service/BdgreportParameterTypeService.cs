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
    public interface IBdgreportParameterTypeService
    {
        Task<IEnumerable<BdgreportParameterTypeListModel>> GetAll();
        Task<bool> Delete(Guid id);
        Task<BdgreportParameterTypeAddEditModel> Get(Guid id);
        Task<bool> Save(BdgreportParameterTypeAddEditModel model);
        LoadResult GetPage(DataSourceLoadOptionsBase options);
        Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions);
        Task<bool> Update(Guid id, string values);
    }
    public class BdgreportParameterTypeService : BaseService, IBdgreportParameterTypeService
    {
        public BdgreportParameterTypeService(IUnitOfWork uow, UserResolverService userResolverService, IMapper mapper)
          : base(uow, userResolverService, mapper)
        {
        }

        public LoadResult GetPage(DataSourceLoadOptionsBase options)
        {
            var query = _uow.BdgreportParameterTypeRepository.Query().Where(x => x.IsDeleted == false)
                .Select(s => new BdgreportParameterTypeListModel
                {
                    ObjectUID = s.ObjectUid,
                    Name = s.Name,
                }).ToList();

            return DataSourceLoader.Load(query, options);
        }

        public async Task<IEnumerable<BdgreportParameterTypeListModel>> GetAll()
        {
            return _mapper.Map<List<BdgreportParameterTypeListModel>>(await _uow.BdgreportParameterTypeRepository.GetAll());
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _uow.BdgreportParameterTypeRepository.Get(id);
            entity.UpdatedOn = DateTime.UtcNow;
            entity.IsDeleted = true;
            await _uow.BdgreportParameterTypeRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();
        }

        public async Task<BdgreportParameterTypeAddEditModel> Get(Guid id)
        {
            return _mapper.Map<BdgreportParameterTypeAddEditModel>(await _uow.BdgreportParameterTypeRepository.Get(id));
        }

        public async Task<bool> Save(BdgreportParameterTypeAddEditModel model)
        {
            if (model.ObjectUID == null)
            {
                BdgreportParameterType entity = _mapper.Map<BdgreportParameterType>(model);
                entity.CreatedOn = DateTime.UtcNow;
                entity.NameAlias = entity.Name;
                await _uow.BdgreportParameterTypeRepository.Add(entity);
            }
            else
            {
                BdgreportParameterType entity = await _uow.BdgreportParameterTypeRepository.Get(model.ObjectUID.Value);
                entity = _mapper.Map<BdgreportParameterTypeAddEditModel, BdgreportParameterType>(model, entity);
                entity.UpdatedOn = DateTime.UtcNow;
                await _uow.BdgreportParameterTypeRepository.Update(entity);
                _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            }
            return await _uow.SaveAsync();

        }
        public async Task<bool> Update(Guid id, string values)
        {
            BdgreportParameterType entity = await _uow.BdgreportParameterTypeRepository.Get(id);
            JsonConvert.PopulateObject(values, entity);

            entity.UpdatedOn = DateTime.UtcNow;
            await _uow.BdgreportParameterTypeRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();

        }
        public async Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.BdgreportParameterTypeRepository.Query().Where(x => x.IsDeleted == false).Select(x =>
                new BdgreportParameterType
                {
                    ObjectUid = x.ObjectUid,
                    Name = x.Name
                });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }
    }
}
