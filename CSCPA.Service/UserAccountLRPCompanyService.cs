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
    public interface IUserAccountLRPCompanyService
    {
        Task<IEnumerable<UserAccountLRPCompanyListModel>> GetAll();
        Task<bool> Delete(Guid id);
        Task<UserAccountLRPCompanyAddEditModel> Get(Guid id);
        Task<bool> Save(UserAccountLRPCompanyAddEditModel model);
        LoadResult GetPage(DataSourceLoadOptionsBase options);
        Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions);
        Task<bool> Update(Guid id, string values);
        List<string> UserCompanies(Guid userId);
    }
    public class UserAccountLRPCompanyService : BaseService, IUserAccountLRPCompanyService
    {
        public UserAccountLRPCompanyService(IUnitOfWork uow, UserResolverService userResolverService, IMapper mapper)
         : base(uow, userResolverService, mapper)
        {
        }

        public LoadResult GetPage(DataSourceLoadOptionsBase options)
        {
            var query = _uow.UserAccountLrpcompanyRepository.Query().Where(x => x.IsDeleted == false)
                .Select(s => new UserAccountLRPCompanyListModel
                {
                    ObjectUID = s.ObjectUid,
                    Name = s.Name,
                    UserAccountId = s.UserAccountId,
                    LrpcompanyId = s.LrpcompanyId
                }).ToList();

            return DataSourceLoader.Load(query, options);
        }

        public async Task<IEnumerable<UserAccountLRPCompanyListModel>> GetAll()
        {
            return _mapper.Map<List<UserAccountLRPCompanyListModel>>(await _uow.UserAccountLrpcompanyRepository.GetAll());
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _uow.UserAccountLrpcompanyRepository.Get(id);
            entity.UpdatedOn = DateTime.UtcNow;
            entity.IsDeleted = true;
            await _uow.UserAccountLrpcompanyRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();
        }

        public async Task<UserAccountLRPCompanyAddEditModel> Get(Guid id)
        {
            return _mapper.Map<UserAccountLRPCompanyAddEditModel>(await _uow.UserAccountLrpcompanyRepository.Get(id));
        }

        public async Task<bool> Save(UserAccountLRPCompanyAddEditModel model)
        {
            if (model.ObjectUID == null)
            {
                UserAccountLrpcompany entity = _mapper.Map<UserAccountLrpcompany>(model);
                entity.CreatedOn = DateTime.UtcNow;
                entity.NameAlias = entity.Name;
                await _uow.UserAccountLrpcompanyRepository.Add(entity);
            }
            else
            {
                UserAccountLrpcompany entity = await _uow.UserAccountLrpcompanyRepository.Get(model.ObjectUID.Value);
                entity = _mapper.Map<UserAccountLRPCompanyAddEditModel, UserAccountLrpcompany>(model, entity);
                entity.UpdatedOn = DateTime.UtcNow;
                await _uow.UserAccountLrpcompanyRepository.Update(entity);
                _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            }
            return await _uow.SaveAsync();

        }
        public async Task<bool> Update(Guid id, string values)
        {
            UserAccountLrpcompany entity = await _uow.UserAccountLrpcompanyRepository.Get(id);
            JsonConvert.PopulateObject(values, entity);

            entity.UpdatedOn = DateTime.UtcNow;
            await _uow.UserAccountLrpcompanyRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();

        }

        public List<string> UserCompanies(Guid userId)
        {
            return _uow.UserAccountLrpcompanyRepository.Query().Where(x => x.UserAccountId == userId).Select(x => x.LrpcompanyId.ToString()).ToList();
        }

        public async Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.UserAccountLrpcompanyRepository.Query().Where(x => x.IsDeleted == false).Select(x =>
                new UserAccountLrpcompany
                {
                    ObjectUid = x.ObjectUid,
                    Name = x.Name
                });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }
    }
}
