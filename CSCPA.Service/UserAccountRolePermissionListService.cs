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
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static CSCPA.Core.Constant.Permissions;
using static CSCPA.Core.Constant.ModuleRole;

namespace CSCPA.Service
{
    public interface IUserAccountRolePermissionListService
    {
        Task<IEnumerable<UserAccountRolePermissionListModel>> GetAll();
        Task<bool> Delete(Guid id);
        Task<UserAccountRolePermissionAddEditModel> Get(Guid id);
        Task<bool> Save(UserAccountRolePermissionAddEditModel model);
        LoadResult GetPage(DataSourceLoadOptionsBase options);
        Task<List<Claim>> GetClaims(Guid roleID);
        Task<bool> AddClaim(Guid role, Claim claims);
        Task<bool> Update(Guid id, string values);
        List<Claim> GetClaims(string type,string claims,string issuer);
        //Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions);
    }
    public class UserAccountRolePermissionListService : BaseService, IUserAccountRolePermissionListService
    {
        public UserAccountRolePermissionListService(IUnitOfWork uow, UserResolverService userResolverService, IMapper mapper)
           : base(uow, userResolverService, mapper)
        {
        }

        public LoadResult GetPage(DataSourceLoadOptionsBase options)
        {
            var query = _uow.UserAccountRolePermissionListRepository.Query()
                .Select(s => new UserAccountRolePermissionListModel
                {
                    UserAccountId = s.UserAccountId,
                    ModuleId = s.ModuleId,
                    TableCopy = s.TableCopy,
                    TableDelete = s.TableDelete,
                    TableNew = s.TableNew
                }).ToList();

            return DataSourceLoader.Load(query, options);
        }

        public async Task<IEnumerable<UserAccountRolePermissionListModel>> GetAll()
        {
            return _mapper.Map<List<UserAccountRolePermissionListModel>>(await _uow.UserAccountRolePermissionListRepository.GetAll());
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _uow.UserAccountRolePermissionListRepository.Get(id);
            await _uow.UserAccountRolePermissionListRepository.Update(entity);
            _uow.DbContext.Entry(entity);
            return await _uow.SaveAsync();
        }

        public async Task<UserAccountRolePermissionAddEditModel> Get(Guid id)
        {
            return _mapper.Map<UserAccountRolePermissionAddEditModel>(await _uow.UserAccountRolePermissionListRepository.Get(id));
        }

        public async Task<bool> Save(UserAccountRolePermissionAddEditModel model)
        {
            var user = _uow.UserAccountRolePermissionListRepository.Query().Where(x => x.UserAccountId == model.UserAccountId && x.ModuleId == model.ModuleId).FirstOrDefault();
            if (user == null)
            {
                UserAccountRolePermissionList entity = _mapper.Map<UserAccountRolePermissionList>(model);
                await _uow.UserAccountRolePermissionListRepository.Add(entity);
            }
            else
            {
                UserAccountRolePermissionList entity = user;
                entity = _mapper.Map<UserAccountRolePermissionAddEditModel, UserAccountRolePermissionList>(model, entity);
                await _uow.UserAccountRolePermissionListRepository.Update(entity);
                _uow.DbContext.Entry(entity);
            }
            return await _uow.SaveAsync();

        }
        public async Task<bool> Update(Guid id, string values)
        {
            UserAccountRolePermissionList entity = await _uow.UserAccountRolePermissionListRepository.Get(id);
            JsonConvert.PopulateObject(values, entity);

           // entity.UpdatedOn = DateTime.UtcNow;
            await _uow.UserAccountRolePermissionListRepository.Update(entity);
            //_uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();

        }
        public async Task<List<Claim>> GetClaims(Guid roleID)
        {
            var module = _uow.RoleModuleRepository.Query().Where(x => x.RoleId == roleID).ToList();
           // List<Module> modules = new List<Module>();
            List<Claim> claims = new List<Claim>();
            foreach (var item in module)
            {
                var moduleName = await _uow.ModuleRepository.Get(item.ModuleId);
                if (IsModuleExist().Contains(moduleName.Name))
                {
                    List<string> permisisons = new List<string>();
                    if (item.CustomA)
                        claims.Add(new Claim("Permission", "Permissions." + moduleName.Name + ".View"));
                    if (item.CustomB)
                        claims.Add(new Claim("Permission", "Permissions." + moduleName.Name + ".Create"));
                    if (item.CustomC)
                        claims.Add(new Claim("Permission", "Permissions." + moduleName.Name + ".Edit"));
                    if (item.CustomD)
                        claims.Add(new Claim("Permission", "Permissions." + moduleName.Name + ".Delete"));
                }

            }

            /*foreach(var item in module)
            {
                var module1 = _uow.ModuleRepository.Query().Where(x => x.ObjectUid == item.ModuleId).FirstOrDefault();
                if(modules != null)
                    modules.Add(module1);
            }
            List<Claim> claims = new List<Claim>();
            foreach(var items in modules)
            {
                if (IsModuleExist().Contains(items.Name))
                {
                    List<string> permisisons = new List<string>();
                     permisisons.Add()
                    foreach (var permission in permisisons)
                    {
                        claims.Add(new Claim("Permission", permission));
                    }
                }
            }*/
            return claims;
        }
        public List<Claim> GetClaims(string type, string claim, string issuer)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim("Permission", "Permissions.Products.Create"),
                new Claim("Permission", "Permissions.Products.View"),
                new Claim("Permission", "Permissions.Products.Edit"),
                new Claim("Permission", "Permissions.Products.Delete")
            };
            var isClaim = false;
            foreach(var item in claims)
            {
                if (item.Value == claim)
                    isClaim = true;
            }
            if (type == "Permission" && isClaim && issuer == "LOCAL AUTHORITY")
            {
                return claims;
            }
            return null;
        }
        public async Task<bool> AddClaim(Guid role, Claim claims)
        {
            UserAccountRolePermissionList entity = new UserAccountRolePermissionList();
            entity.UserAccountId = role;
            entity.CustomA = claims.Value == "Permission.Product.Create" ? 1 : 0;
            entity.CustomB = claims.Value == "Permission.Product.View" ? 1 : 0;
            entity.CustomC = claims.Value == "Permission.Product.Edit" ? 1 : 0;
            entity.CustomD = claims.Value == "Permission.Product.Delete" ? 1 : 0;

            await _uow.UserAccountRolePermissionListRepository.Add(entity);
            return await _uow.SaveAsync();
        }

        /*public async Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.UserAccountRolePermissionListRepository.Query().Select(x =>
                new UserAccountRolePermissionList
                {
                    UserAccountId = x.ObjectUid,
                    Name = x.Name
                });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }*/
    }
}
