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
    public interface IDuplicateMaskingService
    {
        Task<IEnumerable<DuplicateMaskingListModel>> GetAll();
        Task<bool> Delete(Guid id);
        Task<DuplicateMaskingAddEditModel> Get(Guid id);
        Task<bool> Save(DuplicateMaskingAddEditModel model);
        LoadResult GetPage(DataSourceLoadOptionsBase options);
        Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions);
        Task<bool> Update(Guid id, string values);
    }
    public class DuplicateMaskingService: BaseService, IDuplicateMaskingService
    {
        public DuplicateMaskingService(IUnitOfWork uow, UserResolverService userResolverService, IMapper mapper)
        : base(uow, userResolverService, mapper)
        {
        }

        public LoadResult GetPage(DataSourceLoadOptionsBase options)
        {
            var query = _uow.BdgreportGroupDuplicateMaskingRepository.Query().Where(x => x.IsDeleted == false)
                .Select(s => new DuplicateMaskingListModel
                {
                    ObjectUID = s.ObjectUid,
                    Name = s.Name,
                    Description = s.Description,
                    AccountNo = s.AccountNo
                }).ToList();

            return DataSourceLoader.Load(query, options);
        }

        public async Task<IEnumerable<DuplicateMaskingListModel>> GetAll()
        {
            return _mapper.Map<List<DuplicateMaskingListModel>>(await _uow.BdgreportGroupDuplicateMaskingRepository.GetAll());
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _uow.BdgreportGroupDuplicateMaskingRepository.Get(id);
            entity.UpdatedOn = DateTime.UtcNow;
            entity.IsDeleted = true;
            await _uow.BdgreportGroupDuplicateMaskingRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();
        }

        public async Task<DuplicateMaskingAddEditModel> Get(Guid id)
        {
            return _mapper.Map<DuplicateMaskingAddEditModel>(await _uow.BdgreportGroupDuplicateMaskingRepository.Get(id));
        }

        public async Task<bool> Save(DuplicateMaskingAddEditModel model)
        {
            if (model.ObjectUID == null)
            {
                BdgreportGroupDuplicateMasking entity = _mapper.Map<BdgreportGroupDuplicateMasking>(model);
                entity.CreatedOn = DateTime.UtcNow;
                entity.NameAlias = entity.Name;
                await _uow.BdgreportGroupDuplicateMaskingRepository.Add(entity);
            }
            else
            {
                BdgreportGroupDuplicateMasking entity = await _uow.BdgreportGroupDuplicateMaskingRepository.Get(model.ObjectUID.Value);
                var createdOn = entity.CreatedOn;
                entity = _mapper.Map<DuplicateMaskingAddEditModel, BdgreportGroupDuplicateMasking>(model, entity);
                entity.CreatedOn = createdOn;
                entity.UpdatedOn = DateTime.UtcNow;
                await _uow.BdgreportGroupDuplicateMaskingRepository.Update(entity);
                _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            }

            return await _uow.SaveAsync();
        }
        public async Task<bool> Update(Guid id, string values)
        {
            BdgreportGroupDuplicateMasking entity = await _uow.BdgreportGroupDuplicateMaskingRepository.Get(id);
            JsonConvert.PopulateObject(values, entity);

            entity.UpdatedOn = DateTime.UtcNow;
            await _uow.BdgreportGroupDuplicateMaskingRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();

        }
        public async Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.BdgreportGroupDuplicateMaskingRepository.Query().Where(x => x.IsDeleted == false).Select(x =>
                new SelectListModel
                {
                    Value = x.ObjectUid,
                    Text = x.Name
                });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }
    }
}
