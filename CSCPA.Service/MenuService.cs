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
    public interface IMenuService
    {
        Task<IEnumerable<MenuListModel>> GetAll();
        Task<bool> Delete(Guid id);
        Task<MenuAddEditModel> Get(Guid id);
        Task<bool> Save(MenuAddEditModel model);
        LoadResult GetPage(DataSourceLoadOptionsBase options);
        Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions);
        Task<bool> Update(Guid id, string values);
    }
    public class MenuService : BaseService, IMenuService
    {
        public MenuService(IUnitOfWork uow, UserResolverService userResolverService, IMapper mapper)
           : base(uow, userResolverService, mapper)
        {
        }

        public LoadResult GetPage(DataSourceLoadOptionsBase options)
        {
            var query = _uow.MenuRepository.Query().Where(x => x.IsDeleted == false)
                .Select(s => new MenuListModel
                {
                    ObjectUID = s.ObjectUid,
                    Name = s.Name,
                });

            return DataSourceLoader.Load(query, options);
        }

        public async Task<IEnumerable<MenuListModel>> GetAll()
        {
            return _mapper.Map<List<MenuListModel>>(await _uow.MenuRepository.GetAll());
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _uow.MenuRepository.Get(id);
            entity.UpdatedOn = DateTime.UtcNow;
            entity.IsDeleted = true;
            await _uow.MenuRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();
        }

        public async Task<MenuAddEditModel> Get(Guid id)
        {
            return _mapper.Map<MenuAddEditModel>(await _uow.MenuRepository.Get(id));
        }

        public async Task<bool> Save(MenuAddEditModel model)
        {
            if (model.ObjectUID == null)
            {
                Menu entity = _mapper.Map<Menu>(model);
                entity.CreatedOn = DateTime.UtcNow;
                entity.NameAlias = entity.Name;
                await _uow.MenuRepository.Add(entity);
            }
            else
            {
                Menu entity = await _uow.MenuRepository.Get(model.ObjectUID.Value);
                entity = _mapper.Map<MenuAddEditModel, Menu>(model, entity);
                entity.UpdatedOn = DateTime.UtcNow;
                await _uow.MenuRepository.Update(entity);
                _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            }
            return await _uow.SaveAsync();

        }
        public async Task<bool> Update(Guid id, string values)
        {
            Menu entity = await _uow.MenuRepository.Get(id);
            JsonConvert.PopulateObject(values, entity);

            entity.UpdatedOn = DateTime.UtcNow;
            await _uow.MenuRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();

        }
        public async Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.MenuRepository.Query().Where(x => x.IsDeleted == false).Select(x =>
                new Menu
                {
                    ObjectUid = x.ObjectUid,
                    Name = x.Name
                });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }
    }
}
