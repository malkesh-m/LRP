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
using System.Threading.Tasks;

namespace CSCPA.Service
{
    public interface IGLAccountMappingService
    {
        Task<IEnumerable<GLAccountMappingListModel>> GetAll();
        Task<bool> Delete(Guid id);
        Task<GLAccountMappingAddEditModel> Get(Guid id);
        Task<bool> Save(GLAccountMappingAddEditModel model);
        LoadResult GetPage(DataSourceLoadOptionsBase options);
        Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions);
        Task<bool> Update(Guid id, string values);
    }
    public class GLAccountMappingService : BaseService,IGLAccountMappingService
    {
        public GLAccountMappingService(IUnitOfWork uow, UserResolverService userResolverService, IMapper mapper)
            : base(uow, userResolverService, mapper)
        {
        }

        public LoadResult GetPage(DataSourceLoadOptionsBase options)
        {
            var query = _uow.BdgreportGroupBdgglaccountMappingRepository.Query().Where(x => x.IsDeleted == false)
                .Select(s => new GLAccountMappingListModel
                {
                    ObjectUID = s.ObjectUid,
                    Name = s.Name,
                    AccountNo = s.AccountNo,
                    BdgreportGroupId = s.BdgreportGroupId,
                    BdgdepartmentId = s.BdgdepartmentId,
                    BdgaccountGroupId = s.BdgaccountGroupId,
                    BdgaccountGroupSubGroupId = s.BdgaccountGroupSubGroupId,
                    BdgaccountGroupSubGroupSubGroupSubGroupId = s.BdgaccountGroupSubGroupSubGroupSubGroupId,
                    BdgaccountGroupSubGroupSubGroupId = s.BdgaccountGroupSubGroupSubGroupId,

                });

            return DataSourceLoader.Load(query, options);
        }

        public async Task<IEnumerable<GLAccountMappingListModel>> GetAll()
        {
            return _mapper.Map<List<GLAccountMappingListModel>>(await _uow.BdgreportGroupBdgglaccountMappingRepository.GetAll());
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _uow.BdgreportGroupBdgglaccountMappingRepository.Get(id);
            entity.UpdatedOn = DateTime.UtcNow;
            entity.IsDeleted = true;
            await _uow.BdgreportGroupBdgglaccountMappingRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();
        }

        public async Task<GLAccountMappingAddEditModel> Get(Guid id)
        {
            return _mapper.Map<GLAccountMappingAddEditModel>(await _uow.BdgreportGroupBdgglaccountMappingRepository.Get(id));
        }

        public async Task<bool> Save(GLAccountMappingAddEditModel model)
        {
            if (model.ObjectUID == null)
            {
                BdgreportGroupBdgglaccountMapping entity = _mapper.Map<BdgreportGroupBdgglaccountMapping>(model);
                entity.CreatedOn = DateTime.UtcNow;
                entity.NameAlias = entity.Name;
                entity.MaskedAccountNo = entity.AccountNo;
                await _uow.BdgreportGroupBdgglaccountMappingRepository.Add(entity);
            }
            else
            {
                BdgreportGroupBdgglaccountMapping entity = await _uow.BdgreportGroupBdgglaccountMappingRepository.Get(model.ObjectUID.Value);
                entity = _mapper.Map<GLAccountMappingAddEditModel, BdgreportGroupBdgglaccountMapping>(model, entity);
                entity.UpdatedOn = DateTime.UtcNow;
                await _uow.BdgreportGroupBdgglaccountMappingRepository.Update(entity);
                _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            }
            return await _uow.SaveAsync();
        }
        public async Task<bool> Update(Guid id, string values)
        {
            BdgreportGroupBdgglaccountMapping entity = await _uow.BdgreportGroupBdgglaccountMappingRepository.Get(id);
            JsonConvert.PopulateObject(values, entity);

            entity.UpdatedOn = DateTime.UtcNow;
            await _uow.BdgreportGroupBdgglaccountMappingRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();

        }
        public async Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.BdgreportGroupBdgglaccountMappingRepository.Query().Where(x => x.IsDeleted == false).Select(x =>
                new SelectListModel
                {
                    Value = x.ObjectUid,
                    Text = x.AccountNo
                });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }

    }
}
