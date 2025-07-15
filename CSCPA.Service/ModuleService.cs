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
    public interface IModuleService
    {
        Task<IEnumerable<ModuleListModel>> GetAll();
        Task<bool> Delete(Guid id);
        Task<ModuleAddEditModel> Get(Guid id);
        Task<bool> Save(ModuleAddEditModel model);
        LoadResult GetPage(DataSourceLoadOptionsBase options);
        Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions);
        Task<bool> Update(Guid id, string values);
        List<ModuleAddEditModel> GetModule(Guid id);
    }
    public class ModuleService : BaseService, IModuleService
    {
        public ModuleService(IUnitOfWork uow, UserResolverService userResolverService, IMapper mapper)
           : base(uow, userResolverService, mapper)
        {
        }

        public LoadResult GetPage(DataSourceLoadOptionsBase options)
        {
            var query = _uow.ModuleRepository.Query().Where(x => x.IsDeleted == false)
                .Select(s => new ModuleListModel
                {
                    ObjectUID = s.ObjectUid,
                    Name = s.Name,
                });

            return DataSourceLoader.Load(query, options);
        }

        public async Task<IEnumerable<ModuleListModel>> GetAll()
        {
            return _mapper.Map<List<ModuleListModel>>(await _uow.ModuleRepository.GetAll());
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _uow.ModuleRepository.Get(id);
            entity.UpdatedOn = DateTime.UtcNow;
            entity.IsDeleted = true;
            await _uow.ModuleRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();
        }

        public async Task<ModuleAddEditModel> Get(Guid id)
        {
            return _mapper.Map<ModuleAddEditModel>(await _uow.ModuleRepository.Get(id));
        }

        public async Task<bool> Save(ModuleAddEditModel model)
        {
            try
            {
                if (model.ObjectUID == null)
                {
                    Module entity = _mapper.Map<Module>(model);
                    entity.CreatedOn = DateTime.UtcNow;
                    entity.NameAlias = entity.Name;
                    await _uow.ModuleRepository.Add(entity);
                }
                else
                {
                    Module entity = await _uow.ModuleRepository.Get(model.ObjectUID.Value);
                    entity = _mapper.Map<ModuleAddEditModel, Module>(model, entity);
                    entity.UpdatedOn = DateTime.UtcNow;
                    await _uow.ModuleRepository.Update(entity);
                    _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
                }
                return await _uow.SaveAsync();
            }
            catch (Exception ex)
            {

                return false;
            }


        }
        public async Task<bool> Update(Guid id, string values)
        {
            Module entity = await _uow.ModuleRepository.Get(id);
            JsonConvert.PopulateObject(values, entity);

            entity.UpdatedOn = DateTime.UtcNow;
            await _uow.ModuleRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();

        }
        public async Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.ModuleRepository.Query().Where(x => x.IsDeleted == false).OrderBy(x=> x.Name).Select(x =>
                new Module
                {
                    ObjectUid = x.ObjectUid,
                    Name = x.Name
                });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }

        public List<ModuleAddEditModel> GetModule(Guid id)
        {
            return _mapper.Map<List<ModuleAddEditModel>>(_uow.ModuleRepository.Query().Where(x => x.ObjectUid == id));
        }
    }
}
