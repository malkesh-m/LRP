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
    public interface IUserAccountRoleService
    {
        Task<IEnumerable<UserAccountRoleListModel>> GetAll();
        Task<bool> Delete(Guid id);
        Task<UserAccountRoleAddEditModel> Get(Guid id);
        Task<bool> Save(UserAccountRoleAddEditModel model);
        LoadResult GetPage(DataSourceLoadOptionsBase options);
        Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions);
        RoleAddEditModel GetUserRole(Guid userId);
        Task<bool> Update(Guid id, string values);
    }
    public class UserAccountRoleService : BaseService, IUserAccountRoleService
    {
        public UserAccountRoleService(IUnitOfWork uow, UserResolverService userResolverService, IMapper mapper)
           : base(uow, userResolverService, mapper)
        {
        }

        public LoadResult GetPage(DataSourceLoadOptionsBase options)
        {
            var query = _uow.UserAccountRoleRepository.Query().Where(x => x.IsDeleted == false)
                .Select(s => new UserAccountRoleListModel
                {
                    ObjectUID = s.ObjectUid,
                    Name = s.Name,
                    UserAccountId = s.UserAccountId,
                    RoleId = s.RoleId,
                }).ToList();

            return DataSourceLoader.Load(query, options);
        }

        public async Task<IEnumerable<UserAccountRoleListModel>> GetAll()
        {
            return _mapper.Map<List<UserAccountRoleListModel>>(await _uow.UserAccountRoleRepository.GetAll());
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _uow.UserAccountRoleRepository.Get(id);
            entity.UpdatedOn = DateTime.UtcNow;
            entity.IsDeleted = true;
            await _uow.UserAccountRoleRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();
        }

        public async Task<UserAccountRoleAddEditModel> Get(Guid id)
        {
            return _mapper.Map<UserAccountRoleAddEditModel>(await _uow.UserAccountRoleRepository.Get(id));
        }

        public async Task<bool> Save(UserAccountRoleAddEditModel model)
        {
            if (model.ObjectUID == null)
            {
                UserAccountRole entity = _mapper.Map<UserAccountRole>(model);
                entity.CreatedOn = DateTime.UtcNow;
                entity.NameAlias = entity.Name;
                await _uow.UserAccountRoleRepository.Add(entity);
            }
            else
            {
                UserAccountRole entity = await _uow.UserAccountRoleRepository.Get(model.ObjectUID.Value);
                entity = _mapper.Map<UserAccountRoleAddEditModel, UserAccountRole>(model, entity);
                entity.UpdatedOn = DateTime.UtcNow;
                await _uow.UserAccountRoleRepository.Update(entity);
                _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            }
            return await _uow.SaveAsync();

        }
        public async Task<bool> Update(Guid id, string values)
        {
            UserAccountRole entity = await _uow.UserAccountRoleRepository.Get(id);
            JsonConvert.PopulateObject(values, entity);

            entity.UpdatedOn = DateTime.UtcNow;
            await _uow.UserAccountRoleRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();

        }
        public async Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.UserAccountRoleRepository.Query().Where(x => x.IsDeleted == false).Select(x =>
                new UserAccountRole
                {
                    ObjectUid = x.ObjectUid,
                    Name = x.Name
                });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }

        public RoleAddEditModel GetUserRole(Guid userId)
        {
            var roleId = _uow.UserAccountRoleRepository.Query().Where(x => x.UserAccountId == userId).FirstOrDefault();
            if(roleId != null)
                return _mapper.Map<RoleAddEditModel>(_uow.RoleRepository.Query().Where(x => x.ObjectUid == roleId.RoleId).FirstOrDefault());

            return new RoleAddEditModel();
        }
    }
}
