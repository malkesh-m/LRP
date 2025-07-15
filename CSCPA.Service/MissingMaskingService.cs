using AutoMapper;
using CSCPA.Data.Entities;
using CSCPA.Model;
using CSCPA.Repo;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSCPA.Service
{
    public interface IMissingMaskingService
    {
        Task<IEnumerable<MissingMaskingListModel>> GetAll();
        Task<bool> Delete(Guid id);
        Task<MissingMaskingAddEditModel> Get(Guid id);
        Task<bool> Save(MissingMaskingAddEditModel model);
        LoadResult GetPage(DataSourceLoadOptionsBase options);
        Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions);
        Task<bool> Update(Guid id, string values);
    }
    public class MissingMaskingService: BaseService, IMissingMaskingService
    {
        public MissingMaskingService(IUnitOfWork uow, UserResolverService userResolverService, IMapper mapper)
                   : base(uow, userResolverService, mapper)
        {
        }

        public LoadResult GetPage(DataSourceLoadOptionsBase options)
        {
            var query = _uow.BdgreportGroupMissingMaskingRepository.Query().Where(x => x.IsDeleted == false)
                .Select(s => new MissingMaskingListModel
                {
                    ObjectUID = s.ObjectUid,
                    Name = s.Name,
                    AccountNo = s.AccountNo,
                    Description = s.Description,
                    BdgreportGroupId = s.BdgreportGroupId,
                    SumAmount = s.SumAmount
                });

            return DataSourceLoader.Load(query, options);
        }

        public async Task<IEnumerable<MissingMaskingListModel>> GetAll()
        {
            return _mapper.Map<List<MissingMaskingListModel>>(await _uow.BdgreportGroupMissingMaskingRepository.GetAll());
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _uow.BdgreportGroupMissingMaskingRepository.Get(id);
            entity.UpdatedOn = DateTime.UtcNow;
            entity.IsDeleted = true;
            await _uow.BdgreportGroupMissingMaskingRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();
        }

        public async Task<MissingMaskingAddEditModel> Get(Guid id)
        {
            return _mapper.Map<MissingMaskingAddEditModel>(await _uow.BdgreportGroupMissingMaskingRepository.Get(id));
        }

        public async Task<bool> Save(MissingMaskingAddEditModel model)
        {
            if (model.ObjectUID == null)
            {
                BdgreportGroupMissingMasking entity = _mapper.Map<BdgreportGroupMissingMasking>(model);
                entity.CreatedOn = DateTime.UtcNow;
                entity.NameAlias = entity.Name;
                await _uow.BdgreportGroupMissingMaskingRepository.Add(entity);
            }
            else
            {
                BdgreportGroupMissingMasking entity = await _uow.BdgreportGroupMissingMaskingRepository.Get(model.ObjectUID.Value);
                entity = _mapper.Map<MissingMaskingAddEditModel, BdgreportGroupMissingMasking>(model, entity);
                entity.UpdatedOn = DateTime.UtcNow;
                await _uow.BdgreportGroupMissingMaskingRepository.Update(entity);
                _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            }
            return await _uow.SaveAsync();
        }
        public async Task<bool> Update(Guid id, string values)
        {
            BdgreportGroupMissingMasking entity = await _uow.BdgreportGroupMissingMaskingRepository.Get(id);
            JsonConvert.PopulateObject(values, entity);

            entity.UpdatedOn = DateTime.UtcNow;
            await _uow.BdgreportGroupMissingMaskingRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();

        }
        public async Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.BdgreportGroupMissingMaskingRepository.Query().Where(x => x.IsDeleted == false).Select(x =>
                new SelectListModel
                {
                    Value = x.ObjectUid,
                    Text = x.Name
                });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }

    }
}
