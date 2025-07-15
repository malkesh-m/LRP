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
    public interface IUserAccountBdgDepartmentService
    {
        Task<IEnumerable<UserAccountBdgDepartmentListModel>> GetAll();
        Task<bool> Delete(Guid id);
        Task<UserAccountBdgDepartmentAddEditModel> Get(Guid id);
        Task<bool> Save(UserAccountBdgDepartmentAddEditModel model);
        LoadResult GetPage(DataSourceLoadOptionsBase options);
        Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions);
        Task<bool> Update(Guid id, string values);
        List<string> GetDepartment(Guid userId);
    }
    public class UserAccountBdgDepartmentService : BaseService, IUserAccountBdgDepartmentService
    {
        public UserAccountBdgDepartmentService(IUnitOfWork uow, UserResolverService userResolverService, IMapper mapper)
         : base(uow, userResolverService, mapper)
        {
        }

        public LoadResult GetPage(DataSourceLoadOptionsBase options)
        {
            var query = _uow.UserAccountBdgdepartmentRepository.Query().Where(x => x.IsDeleted == false)
                .Select(s => new UserAccountBdgDepartmentListModel
                {
                    ObjectUID = s.ObjectUid,
                    Name = s.Name,
                    UserAccountId = s.UserAccountId,
                    BdgdepartmentId = s.BdgdepartmentId,
                    InstallationUid = s.InstallationUid,
                    CreatedOn = s.CreatedOn
                }).ToList();

            return DataSourceLoader.Load(query, options);
        }

        public async Task<IEnumerable<UserAccountBdgDepartmentListModel>> GetAll()
        {
            return _mapper.Map<List<UserAccountBdgDepartmentListModel>>(await _uow.UserAccountBdgdepartmentRepository.GetAll());
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _uow.UserAccountBdgdepartmentRepository.Get(id);
            entity.UpdatedOn = DateTime.UtcNow;
            entity.IsDeleted = true;
            await _uow.UserAccountBdgdepartmentRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();
        }

        public async Task<UserAccountBdgDepartmentAddEditModel> Get(Guid id)
        {
            return _mapper.Map<UserAccountBdgDepartmentAddEditModel>(await _uow.UserAccountBdgdepartmentRepository.Get(id));
        }

        public async Task<bool> Save(UserAccountBdgDepartmentAddEditModel model)
        {
            if (model.ObjectUID == null)
            {
                UserAccountBdgdepartment entity = _mapper.Map<UserAccountBdgdepartment>(model);
                entity.CreatedOn = DateTime.UtcNow;
                entity.NameAlias = entity.Name;
                await _uow.UserAccountBdgdepartmentRepository.Add(entity);
            }
            else
            {
                UserAccountBdgdepartment entity = await _uow.UserAccountBdgdepartmentRepository.Get(model.ObjectUID.Value);
                entity = _mapper.Map<UserAccountBdgDepartmentAddEditModel, UserAccountBdgdepartment>(model, entity);
                entity.UpdatedOn = DateTime.UtcNow;
                await _uow.UserAccountBdgdepartmentRepository.Update(entity);
                _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            }
            return await _uow.SaveAsync();

        }
        public async Task<bool> Update(Guid id, string values)
        {
            UserAccountBdgdepartment entity = await _uow.UserAccountBdgdepartmentRepository.Get(id);
            JsonConvert.PopulateObject(values, entity);

            entity.UpdatedOn = DateTime.UtcNow;
            await _uow.UserAccountBdgdepartmentRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();

        }
        public async Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.UserAccountBdgdepartmentRepository.Query().Where(x => x.IsDeleted == false).Select(x =>
                new UserAccountBdgdepartment
                {
                    ObjectUid = x.ObjectUid,
                    Name = x.Name
                });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }

        public List<string> GetDepartment(Guid userId)
        {
            var list = _uow.UserAccountBdgdepartmentRepository.Query().Where(x => x.UserAccountId == userId).Select(x => x.BdgdepartmentId.ToString()).ToList();
            //list.AddRange(_uow.UserAccountBdgdepartmentRepository.Query().Where(x => x.UserAccountId == userId).Select(x => x.InstallationUid.ToString()).ToList());
            return list;
        }
    }
}
