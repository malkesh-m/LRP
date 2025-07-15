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
    public interface IBudgetReportService
    {
        Task<IEnumerable<BudgetReportListModel>> GetAll();
        Task<bool> Delete(Guid id);
        Task<BudgetReportAddEditModel> Get(Guid id);
        Task<bool> Save(BudgetReportAddEditModel model);
        LoadResult GetPage(DataSourceLoadOptionsBase options);
        Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions);
        Task<bool> Update(Guid id, string values);
    }
    public class BudgetReportService:BaseService, IBudgetReportService
    {
        public BudgetReportService(IUnitOfWork uow, UserResolverService userResolverService, IMapper mapper)
        : base(uow, userResolverService, mapper)
        {
        }

        public LoadResult GetPage(DataSourceLoadOptionsBase options)
        {
            var query = _uow.BdgreportGroupBdgreportRepository.Query().Where(x => x.IsDeleted == false)
                .Select(s => new BudgetReportListModel
                {
                    ObjectUID = s.ObjectUid,
                    Name = s.Name,
                    Description = s.Description,
                    BdgreportGroupId = s.BdgreportGroupId,
                    BdgreportId = s.BdgreportId
                }).ToList();

            return DataSourceLoader.Load(query, options);
        }

        public async Task<IEnumerable<BudgetReportListModel>> GetAll()
        {
            return _mapper.Map<List<BudgetReportListModel>>(await _uow.BdgreportGroupBdgreportRepository.GetAll());
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _uow.BdgreportGroupBdgreportRepository.Get(id);
            entity.UpdatedOn = DateTime.UtcNow;
            entity.IsDeleted = true;
            await _uow.BdgreportGroupBdgreportRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();
        }

        public async Task<BudgetReportAddEditModel> Get(Guid id)
        {
            return _mapper.Map<BudgetReportAddEditModel>(await _uow.BdgreportGroupBdgreportRepository.Get(id));
        }

        public async Task<bool> Save(BudgetReportAddEditModel model)
        {
            if (model.ObjectUID == null)
            {
                BdgreportGroupBdgreport entity = _mapper.Map<BdgreportGroupBdgreport>(model);
                entity.CreatedOn = DateTime.UtcNow;
                entity.NameAlias = entity.Name;
                await _uow.BdgreportGroupBdgreportRepository.Add(entity);
            }
            else
            {
                BdgreportGroupBdgreport entity = await _uow.BdgreportGroupBdgreportRepository.Get(model.ObjectUID.Value);
                var createdOn = entity.CreatedOn;
                entity = _mapper.Map<BudgetReportAddEditModel, BdgreportGroupBdgreport>(model, entity);
                entity.CreatedOn = createdOn;
                entity.UpdatedOn = DateTime.UtcNow;
                await _uow.BdgreportGroupBdgreportRepository.Update(entity);
                _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            }

            return await _uow.SaveAsync();
        }
        public async Task<bool> Update(Guid id, string values)
        {
            BdgreportGroupBdgreport entity = await _uow.BdgreportGroupBdgreportRepository.Get(id);
            JsonConvert.PopulateObject(values, entity);

            entity.UpdatedOn = DateTime.UtcNow;
            await _uow.BdgreportGroupBdgreportRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();

        }
        public async Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.BdgreportGroupBdgreportRepository.Query().Where(x => x.IsDeleted == false).Select(x =>
                new SelectListModel
                {
                    Value = x.ObjectUid,
                    Text = x.Name
                });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }
    }
}
