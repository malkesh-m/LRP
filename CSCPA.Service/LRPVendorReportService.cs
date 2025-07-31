using CSCPA.Model;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CSCPA.Repo;
using Microsoft.EntityFrameworkCore;
using CSCPA.Data.Entities;
using Newtonsoft.Json;

namespace CSCPA.Service
{
    public interface ILRPVendorReportService
    {
        Task<IEnumerable<LRPVendorReportListModel>> GetAll();
        Task<bool> Delete(Guid id);
        Task<LRPVendorReportAddEditModel> Get(Guid id);
        Task<bool> Save(LRPVendorReportAddEditModel model);
        Task<bool> Update(Guid id, string values);
        LoadResult GetPage(DataSourceLoadOptionsBase options);
        Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions);
    }

    public class LRPVendorReportService : BaseService,ILRPVendorReportService
    {
        public LRPVendorReportService(IUnitOfWork uow, UserResolverService userResolverService, IMapper mapper)
           : base(uow, userResolverService, mapper)
        {
        }
        public LoadResult GetPage(DataSourceLoadOptionsBase options)
        {
            // Fetch data from database with joins, but no projection into custom class yet
            var query = from s in _uow.LRPVendor_ReportingRepository.Query().IgnoreAutoIncludes()
                        where !s.IsDeleted
                        join country in _uow.CountryRepository.Query().IgnoreAutoIncludes()
                            on s.CountryID equals country.ObjectUid into countryJoin
                        from country in countryJoin.DefaultIfEmpty()
                        join state in _uow.CountryStateRepository.Query().IgnoreAutoIncludes()
                            on s.Country_StateID equals state.ObjectUid into stateJoin
                        from state in stateJoin.DefaultIfEmpty()
                        select new
                        {
                            s,
                            CountryName = country != null ? country.Name : null,
                            StateName = state != null ? state.Name : null
                        };

            // Materialize the query to switch to client-side projection
            var data = query.ToList().Select(x => new LRPVendorReportListModel
            {
                ObjectUID = x.s.ObjectUID,
                AddressI_Reporting = x.s.AddressI_Reporting,
                AddressII_Reporting = x.s.AddressII_Reporting,
                AddressIII_Reporting = x.s.AddressIII_Reporting,
                City_Reporting = x.s.City_Reporting,
                PostalCode_Reporting = x.s.PostalCode_Reporting,
                CountryID = x.s.CountryID,
                CountryName = x.CountryName,
                Country_StateID = x.s.Country_StateID,
                CountryStateName = x.StateName,
                Userdef1_Reporting = x.s.Userdef1_Reporting,
                Userdef2_Reporting = x.s.Userdef2_Reporting,
                Description = x.s.Description
            });

            // Apply DevExtreme DataSourceLoader to the in-memory result
            return DataSourceLoader.Load(data, options);
        }


        public async Task<IEnumerable<LRPVendorReportListModel>> GetAll()
        {
            return _mapper.Map<List<LRPVendorReportListModel>>(await _uow.LRPVendor_ReportingRepository.GetAll());
        }
        public async Task<bool> Delete(Guid id)
        {
            var entity = await _uow.LRPVendor_ReportingRepository.Get(id);
            entity.UpdatedOn = DateTime.UtcNow;
            entity.IsDeleted = true;
            await _uow.LRPVendor_ReportingRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordID).IsModified = false;
            return await _uow.SaveAsync();
        }
        public async Task<LRPVendorReportAddEditModel> Get(Guid id)
        {
            return _mapper.Map<LRPVendorReportAddEditModel>(await _uow.LRPVendor_ReportingRepository.Get(id));
        }

        public async Task<bool> Save(LRPVendorReportAddEditModel model)
        {

            if (model.ObjectUID == null)
            {
                LrpVendor_Reporting entity = _mapper.Map<LrpVendor_Reporting>(model);
                entity.CreatedOn = DateTime.UtcNow;
                await _uow.LRPVendor_ReportingRepository.Add(entity);
            }
            else
            {
                LrpVendor_Reporting entity = await _uow.LRPVendor_ReportingRepository.Get(model.ObjectUID.Value);
                entity = _mapper.Map<LRPVendorReportAddEditModel, LrpVendor_Reporting>(model, entity);
                entity.UpdatedOn = DateTime.UtcNow;
                await _uow.LRPVendor_ReportingRepository.Update(entity);
                _uow.DbContext.Entry(entity).Property(x => x.RecordID).IsModified = false;
            }
            return await _uow.SaveAsync();

        }

        public async Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.LRPVendor_ReportingRepository.Query().Where(x => x.IsDeleted == false).Select(x =>
                 new LrpVendor_Reporting
                 {
                     ObjectUID = x.ObjectUID,
                 });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }
        public async Task<bool> Update(Guid id, string values)
        {
            LrpVendor_Reporting entity = await _uow.LRPVendor_ReportingRepository.Get(id);
            JsonConvert.PopulateObject(values, entity);

            entity.UpdatedOn = DateTime.UtcNow;
            await _uow.LRPVendor_ReportingRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordID).IsModified = false;
            return await _uow.SaveAsync();

        }
    }
}
