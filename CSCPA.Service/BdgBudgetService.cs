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
using System.Text;
using System.Threading.Tasks;

namespace CSCPA.Service
{
    public interface IBdgBudgetService
    {
        Task<IEnumerable<BdgBudgetListModel>> GetAll();
        Task<bool> Delete(Guid id);
        Task<BdgBudgetAddEditModel> Get(Guid id);
        Task<bool> Save(BdgBudgetAddEditModel model);
        LoadResult GetPage(DataSourceLoadOptionsBase options);
        List<BdgBudgetListModel> GetPageList();
        Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions);
        Task<LoadResult> GetLookupYear(DataSourceLoadOptionsBase loadOptions);
        Task<bool> Update(Guid id, string values);
        Task<LoadResult> GetYearList(DataSourceLoadOptionsBase loadOptions);
        Task<bool> BatchSave(List<BdgBudgetAddEditModel> model);
    }
    public class BdgBudgetService : BaseService, IBdgBudgetService
    {
        public BdgBudgetService(IUnitOfWork uow, UserResolverService userResolverService, IMapper mapper)
         : base(uow, userResolverService, mapper)
        {
        }

        public LoadResult GetPage(DataSourceLoadOptionsBase options)
        {
            var query = _uow.BdgbudgetInfoRepository.Query()
                .Select(s => new BdgBudgetListModel
                {
                    ObjectUID = s.ObjectUid,
                    YearSetupId = s.YearSetupId,
                    BdgdepartmentId = s.BdgdepartmentId,
                    AccountName = s.AccountName,
                    AccountCode = s.AccountCode,
                    YtdactualAmount= s.YtdactualAmount,
                    YtdprojectedAmount = s.YtdprojectedAmount,
                    PybudgetAmount = s.PybudgetAmount

                }).ToList();

            return DataSourceLoader.Load(query, options);
        }

        public List<BdgBudgetListModel> GetPageList()
        {
            return _uow.BdgbudgetInfoRepository.Query()
                .Select(s => new BdgBudgetListModel
                {
                    ObjectUID = s.ObjectUid,
                    YearSetupId = s.YearSetupId,
                    BdgdepartmentId = s.BdgdepartmentId,
                    AccountName = s.AccountName,
                    AccountCode = s.AccountCode,
                    YtdactualAmount = s.YtdactualAmount,
                    YtdprojectedAmount = s.YtdprojectedAmount,
                    PybudgetAmount = s.PybudgetAmount

                }).ToList();
        }

        public async Task<IEnumerable<BdgBudgetListModel>> GetAll()
        {
            return _mapper.Map<List<BdgBudgetListModel>>(await _uow.BdgbudgetInfoRepository.GetAll());
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _uow.BdgbudgetInfoRepository.Get(id);
            await _uow.BdgbudgetInfoRepository.Update(entity);
            return await _uow.SaveAsync();
        }

        public async Task<BdgBudgetAddEditModel> Get(Guid id)
        {
            return _mapper.Map<BdgBudgetAddEditModel>(await _uow.BdgbudgetInfoRepository.Get(id));
        }

        public async Task<bool> Save(BdgBudgetAddEditModel model)
        {
            if (model.ObjectUID == null)
            {
                BdgbudgetInfoGrid entity = _mapper.Map<BdgbudgetInfoGrid>(model);
                await _uow.BdgbudgetInfoRepository.Add(entity);
            }
            else
            {
                BdgbudgetInfoGrid entity = await _uow.BdgbudgetInfoRepository.Get(model.ObjectUID.Value);
                entity = _mapper.Map<BdgBudgetAddEditModel, BdgbudgetInfoGrid>(model, entity);
                await _uow.BdgbudgetInfoRepository.Update(entity);
            }
            return await _uow.SaveAsync();

        }

        public async Task<bool> BatchSave(List<BdgBudgetAddEditModel> model)
        {
            try
            {
                List<BdgbudgetInfoGrid> entity = _mapper.Map<List<BdgbudgetInfoGrid>>(model);
                await _uow.BdgbudgetInfoRepository.AddRange(entity);
                foreach (var item in model)
                {
                    await _uow.BdgbudgetInfoRepository.Add(new BdgbudgetInfoGrid() 
                    { 
                        BdgdepartmentId = item.BdgdepartmentId,
                        AccountCode = item.AccountCode,
                        AccountName = item.AccountName,
                        YearSetupId = item.YearSetupId,
                        YtdactualAmount = item.YtdactualAmount,
                        YtdprojectedAmount = item.YtdprojectedAmount,
                        PybudgetAmount = item.PybudgetAmount
                    });
                }
                
                return await _uow.SaveAsync();
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<bool> Update(Guid id, string values)
        {
            BdgbudgetInfoGrid entity = await _uow.BdgbudgetInfoRepository.Get(id);
            JsonConvert.PopulateObject(values, entity);

            await _uow.BdgbudgetInfoRepository.Update(entity);
            return await _uow.SaveAsync();

        }
        public async Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.BdgbudgetInfoRepository.Query().Select(x =>
                new BdgbudgetInfoGrid
                {
                    ObjectUid = x.ObjectUid,
                    AccountName =x.AccountName
                });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }

        public async Task<LoadResult> GetLookupYear(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.YearSetupRepository.Query().Select(m => new SelectListItem
            {
                Text = m.Name,
                Value = m.ObjectUid.ToString()
            });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }

        public List<SelectListItem> GetDepartmentList()
        {
            return _uow.BdgdepartmentRepository.Query().Where(x => x.IsDeleted == false).Select(m => new SelectListItem
            {
                Text = m.Name,
                Value = m.ObjectUid.ToString()
            }).ToList();
        }

        public async Task<LoadResult> GetYearList(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.YearSetupRepository.Query().Where(x => x.IsDeleted == false).Select(m => new YearSetup
            {
                Name = m.Name,
                ObjectUid = m.ObjectUid,
            });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }
    }
}
