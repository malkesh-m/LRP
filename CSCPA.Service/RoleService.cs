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
    public interface IRoleService
    {
        Task<IEnumerable<RoleListModel>> GetAll();
        Task<bool> Delete(Guid id);
        Task<RoleAddEditModel> Get(Guid id);
        Task<bool> Save(RoleAddEditModel model);
        LoadResult GetPage(DataSourceLoadOptionsBase options);
        Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions);
        RoleAddEditModel RoleExist(string role);
        Task<bool> Update(Guid id, string values);
    }
    public class RoleService : BaseService, IRoleService
    {
        public RoleService(IUnitOfWork uow, UserResolverService userResolverService, IMapper mapper)
           : base(uow, userResolverService, mapper)
        {
        }

        public LoadResult GetPage(DataSourceLoadOptionsBase options)
        {
            var query = _uow.RoleRepository.Query().Where(x => x.IsDeleted == false)
                .Select(s => new RoleListModel
                {
                    ObjectUID = s.ObjectUid,
                    Name = s.Name,
                });

            return DataSourceLoader.Load(query, options);
        }

        public async Task<IEnumerable<RoleListModel>> GetAll()
        {
            return _mapper.Map<List<RoleListModel>>(await _uow.RoleRepository.GetAll());
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _uow.RoleRepository.Get(id);
            entity.UpdatedOn = DateTime.UtcNow;
            entity.IsDeleted = true;
            await _uow.RoleRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();
        }

        public async Task<RoleAddEditModel> Get(Guid id)
        {
            return _mapper.Map<RoleAddEditModel>(await _uow.RoleRepository.Get(id));
        }

        public async Task<bool> Save(RoleAddEditModel model)
        {
            if (model.ObjectUID == null)
            {
                Role entity = _mapper.Map<Role>(model);
                entity.CreatedOn = DateTime.UtcNow;
                entity.NameAlias = entity.Name;
                await _uow.RoleRepository.Add(entity);
            }
            else
            {
                Role entity = await _uow.RoleRepository.Get(model.ObjectUID.Value);
                entity = _mapper.Map<RoleAddEditModel, Role>(model, entity);
                entity.UpdatedOn = DateTime.UtcNow;
                await _uow.RoleRepository.Update(entity);
                _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            }
            return await _uow.SaveAsync();

        }
        public async Task<bool> Update(Guid id, string values)
        {
            Role entity = await _uow.RoleRepository.Get(id);
            JsonConvert.PopulateObject(values, entity);

            entity.UpdatedOn = DateTime.UtcNow;
            await _uow.RoleRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();

        }
        public async Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.RoleRepository.Query().Where(x => x.IsDeleted == false).Select(x =>
                new Role
                {
                    ObjectUid = x.ObjectUid,
                    Name = x.Name
                });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }

        public RoleAddEditModel RoleExist(string role)
        {
            return _mapper.Map<RoleAddEditModel>(_uow.RoleRepository.Query().Where(x => x.Name == role).FirstOrDefault());
        }
    }
}
