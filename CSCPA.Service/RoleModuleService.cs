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
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace CSCPA.Service
{
    public interface IRoleModuleService
    {
        Task<IEnumerable<RoleModuleListModel>> GetAll();
        Task<bool> Delete(Guid id);
        Task<RoleModuleAddEditModel> Get(Guid id);
        Task<bool> Save(RoleModuleAddEditModel model);
        LoadResult GetPage(DataSourceLoadOptionsBase options);
        Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions);
        Task<bool> Update(Guid id, string values);
    }
    public class RoleModuleService: BaseService, IRoleModuleService
    {
        public RoleModuleService(IUnitOfWork uow, UserResolverService userResolverService, IMapper mapper)
           : base(uow, userResolverService, mapper)
        {
        }

        public LoadResult GetPage(DataSourceLoadOptionsBase options)
        {
            var query = _uow.RoleModuleRepository.Query().Where(x => x.IsDeleted == false)
                .Select(s => new RoleModuleListModel
                {
                    ObjectUID = s.ObjectUid,
                    RoleId = s.RoleId,
                    ModuleId = s.ModuleId,
                    Name = s.Name,
                }).ToList();

            return DataSourceLoader.Load(query, options);
        }

        public async Task<IEnumerable<RoleModuleListModel>> GetAll()
        {
            return _mapper.Map<List<RoleModuleListModel>>(await _uow.RoleModuleRepository.GetAll());
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _uow.RoleModuleRepository.Get(id);
            entity.UpdatedOn = DateTime.UtcNow;
            entity.IsDeleted = true;
            await _uow.RoleModuleRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();
        }

        public async Task<RoleModuleAddEditModel> Get(Guid id)
        {
            return _mapper.Map<RoleModuleAddEditModel>(await _uow.RoleModuleRepository.Get(id));
        }

        public async Task<bool> Save(RoleModuleAddEditModel model)
        {
            if (model.ObjectUID == null)
            {
                RoleModule entity = _mapper.Map<RoleModule>(model);
                entity.CreatedOn = DateTime.UtcNow;
                entity.NameAlias = entity.Name;
                await _uow.RoleModuleRepository.Add(entity);
            }
            else
            {
                RoleModule entity = await _uow.RoleModuleRepository.Get(model.ObjectUID.Value);
                entity = _mapper.Map<RoleModuleAddEditModel, RoleModule>(model, entity);
                entity.UpdatedOn = DateTime.UtcNow;
                await _uow.RoleModuleRepository.Update(entity);
                _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            }
            Role role =await _uow.RoleRepository.Get(model.RoleId);
            role.ImportedObjectUid = GenerateRandomString();
            await _uow.RoleRepository.Update(role);
            _uow.DbContext.Entry(role).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();

        }
        public async Task<bool> Update(Guid id, string values)
        {
            RoleModule entity = await _uow.RoleModuleRepository.Get(id);
            JsonConvert.PopulateObject(values, entity);

            entity.UpdatedOn = DateTime.UtcNow;
            await _uow.RoleModuleRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();

        }
        public async Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.RoleModuleRepository.Query().Where(x => x.IsDeleted == false).Select(x =>
                new RoleModule
                {
                    ObjectUid = x.ObjectUid,
                    Name = x.Name
                });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }

        public static string GenerateRandomString()
        {
            var allowableChars = @"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890#$%&*";
            Random random = new Random();
            var length = random.Next(10, 25);
            // Generate random data
            var rnd = new byte[length];
            using (var rng = new RNGCryptoServiceProvider())
                rng.GetBytes(rnd);

            // Generate the output string
            var allowable = allowableChars.ToCharArray();
            var l = allowable.Length;
            var chars = new char[length];
            for (var i = 0; i < length; i++)
                chars[i] = allowable[rnd[i] % l];

            return new string(chars);
        }
    }
}
