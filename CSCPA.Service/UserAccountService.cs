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
    public interface IUserAccountService
    {
        Task<IEnumerable<UserAccountListModel>> GetAll();
        Task<bool> Delete(Guid id);
        Task<UserAccountAddEditModel> Get(Guid id);
        Task<bool> Save(UserAccountAddEditModel model);
        LoadResult GetPage(DataSourceLoadOptionsBase options);
        Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions);
        UserAccountAddEditModel ValidUser(string email, string password);
        UserAccountAddEditModel UserExist(string userId);
        Task<bool> Update(Guid id, string values);
        Task<bool> UpdateUser(UserAccountAddEditModel model);
        UserAccountAddEditModel FindByEmail(string email);
        Task<string> GenerateToken(UserAccountAddEditModel model);
        Task<bool> ResetPassword(string email, string token, string password);
        Task<bool> ChangePassword(Guid id, string password);
    }
    public class UserAccountService : BaseService, IUserAccountService
    {
        public UserAccountService(IUnitOfWork uow, UserResolverService userResolverService, IMapper mapper)
           : base(uow, userResolverService, mapper)
        {
        }

        public LoadResult GetPage(DataSourceLoadOptionsBase options)
        {
            var query = _uow.UserAccountRepository.Query().Where(x => x.IsDeleted == false)
                .Select(s => new UserAccountListModel
                {
                    ObjectUID = s.ObjectUid,
                    Name = s.Name,
                    Email = s.Email,
                    AddressLineI = s.AddressLineI,

                }).ToList();

            return DataSourceLoader.Load(query, options);
        }

        public async Task<IEnumerable<UserAccountListModel>> GetAll()
        {
            return _mapper.Map<List<UserAccountListModel>>(await _uow.UserAccountRepository.GetAll());
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _uow.UserAccountRepository.Get(id);
            entity.UpdatedOn = DateTime.UtcNow;
            entity.IsDeleted = true;
            await _uow.UserAccountRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();
        }

        public UserAccountAddEditModel ValidUser(string email, string password)
        {
            var user =  _uow.UserAccountRepository.Query().FirstOrDefault(x => x.Email == email && x.Password == password);
            return _mapper.Map<UserAccountAddEditModel>(user);
        }

        public async Task<UserAccountAddEditModel> Get(Guid id)
        {
            var users = _mapper.Map<UserAccountAddEditModel>(await _uow.UserAccountRepository.Get(id));
            users.Country = _uow.CountryRepository.Query().Where(x => x.ObjectUid == users.CountryId).Select(x=> x.Name).FirstOrDefault();
            users.State = _uow.CountryStateRepository.Query().Where(x => x.ObjectUid == users.CountryStateId).Select(x => x.Name).FirstOrDefault();
            users.Localisation = _uow.LocalisationRepository.Query().Where(x => x.ObjectUid == users.LocalisationId).Select(x => x.Name).FirstOrDefault();

            return users;
        }

        public async Task<bool> Save(UserAccountAddEditModel model)
        {
            model.Country = model.State = model.Localisation = null;
            if (model.ObjectUID == null)
            {
                UserAccount entity = _mapper.Map<UserAccount>(model);
                entity.CreatedOn = DateTime.UtcNow;
                entity.NameAlias = entity.Name;
                await _uow.UserAccountRepository.Add(entity);
            }
            else
            {
                UserAccount entity = await _uow.UserAccountRepository.Get(model.ObjectUID.Value);
                entity = _mapper.Map<UserAccountAddEditModel, UserAccount>(model, entity);
                entity.UpdatedOn = DateTime.UtcNow;
                await _uow.UserAccountRepository.Update(entity);
                _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            }
            return await _uow.SaveAsync();

        }
        public async Task<bool> Update(Guid id, string values)
        {
            UserAccount entity = await _uow.UserAccountRepository.Get(id);
            JsonConvert.PopulateObject(values, entity);

            entity.UpdatedOn = DateTime.UtcNow;
            await _uow.UserAccountRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();

        }
        public async Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.UserAccountRepository.Query().Where(x => x.IsDeleted == false).Select(x =>
                new UserAccount
                {
                    ObjectUid = x.ObjectUid,
                    Name = x.Name
                });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }
        public UserAccountAddEditModel UserExist(string userId)
        {
            var users = _mapper.Map<UserAccountAddEditModel>( _uow.UserAccountRepository.Query().Where(x=> x.ObjectUid.ToString() == userId).FirstOrDefault());
            users.Country = _uow.CountryRepository.Query().Where(x => x.ObjectUid == users.CountryId).Select(x => x.Name).FirstOrDefault();
            users.State = _uow.CountryStateRepository.Query().Where(x => x.ObjectUid == users.CountryStateId).Select(x => x.Name).FirstOrDefault();
            users.Localisation = _uow.LocalisationRepository.Query().Where(x => x.ObjectUid == users.LocalisationId).Select(x => x.Name).FirstOrDefault();

            return users;
        }

        public UserAccountAddEditModel FindByEmail(string email)
        {
            var users = _mapper.Map<UserAccountAddEditModel>(_uow.UserAccountRepository.Query().Where(x => x.Email == email).FirstOrDefault());
            return users;
        }

        public async Task<bool> UpdateUser(UserAccountAddEditModel model)
        {
            model.Country = model.State = model.Localisation = null;
            UserAccount entity = await _uow.UserAccountRepository.Get(model.ObjectUID.Value);
            entity.Name = model.Name;
            entity.City = model.City;
            entity.AddressLineI = model.AddressLineI;
            entity.Phone = model.Phone;
            entity.CountryStateId = model.CountryStateId;
            entity.CountryId = model.CountryId;
            entity.PostalCode = model.PostalCode;
            entity.UpdatedOn = DateTime.UtcNow;
            await _uow.UserAccountRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();
        }

        public async Task<string> GenerateToken(UserAccountAddEditModel model)
        {
            var token = Guid.NewGuid().ToString().Replace("-","");
            UserAccount entity = await _uow.UserAccountRepository.Get(model.ObjectUID.Value);
            entity.UpdatedOn = DateTime.UtcNow;
            entity.Description = token;
            await _uow.UserAccountRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            await _uow.SaveAsync();
            return token;
        }

        public async Task<bool> ResetPassword(string email,string token,string password)
        {
            UserAccount entity = _uow.UserAccountRepository.Query().Where(x => x.Email == email).FirstOrDefault();
            if (entity.Description == token)
            {
                entity.UpdatedOn = DateTime.UtcNow;
                entity.Password = password;
                entity.ConfirmPassword = password;
                entity.Description = "";
                await _uow.UserAccountRepository.Update(entity);
                _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
                return await _uow.SaveAsync();
            }
            
            return false;
        }

        public async Task<bool> ChangePassword(Guid id, string password)
        {
            UserAccount entity = _uow.UserAccountRepository.Query().Where(x => x.ObjectUid == id).FirstOrDefault();
            entity.UpdatedOn = DateTime.UtcNow;
            entity.Password = password;
            entity.ConfirmPassword = password;
            entity.Description = "";
            await _uow.UserAccountRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();
        }
    }
}
