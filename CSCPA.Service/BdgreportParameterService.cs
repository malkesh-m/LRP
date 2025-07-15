using AutoMapper;
using CSCPA.Data;
using CSCPA.Data.Entities;
using CSCPA.Model;
using CSCPA.Repo;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CSCPA.Service
{
    public interface IBdgreportParameterService
    {
        Task<IEnumerable<BdgreportParameterListModel>> GetAll();
        Task<bool> Delete(Guid id);
        Task<BdgreportParameterAddEditModel> Get(Guid id);
        Task<bool> Save(BdgreportParameterAddEditModel model);
        LoadResult GetPage(DataSourceLoadOptionsBase options);
        Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions);
        Task<bool> Update(Guid id, string values);
        Task<List<ReportParameter>> GetParameters(Guid id);
        LoadResult GetParameters(Guid id,DataSourceLoadOptionsBase options);
        List<SelectListItem> GetLookupTable();
        List<SelectListItem> ParameterData(string tableName, string textName, string valueName);
    }
    public class BdgreportParameterService : BaseService, IBdgreportParameterService
    {
        private readonly IConfiguration _config;
        private readonly AppDbContext _context;
        public BdgreportParameterService(IUnitOfWork uow, UserResolverService userResolverService, IMapper mapper, IConfiguration config, AppDbContext context)
          : base(uow, userResolverService, mapper)
        {
            _config = config;
            _context = context;
        }

        public LoadResult GetPage(DataSourceLoadOptionsBase options)
        {
            var query = _uow.BdgreportParameterRepository.Query().Where(x => x.IsDeleted == false)
                .Select(s => new BdgreportParameterListModel
                {
                    ObjectUID = s.ObjectUid,
                    Name = s.Name,
                    ParameterDisplayName = s.ParameterDisplayName,
                    ParameterDatabaseFieldName = s.ParameterDatabaseFieldName,
                    ParameterDefaultValue = s.ParameterDefaultValue,
                    BdgreportId = s.BdgreportId,
                    BdgreportParameterTypeId = s.BdgreportParameterTypeId,
                    ParameterDefaultStartValue = s.ParameterDefaultStartValue,
                    ParameterDefaultEndValue = s.ParameterDefaultEndValue
                }).ToList();

            return DataSourceLoader.Load(query, options);
        }

        public async Task<IEnumerable<BdgreportParameterListModel>> GetAll()
        {
            return _mapper.Map<List<BdgreportParameterListModel>>(await _uow.BdgreportParameterRepository.GetAll());
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _uow.BdgreportParameterRepository.Get(id);
            entity.UpdatedOn = DateTime.UtcNow;
            entity.IsDeleted = true;
            await _uow.BdgreportParameterRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();
        }

        public async Task<BdgreportParameterAddEditModel> Get(Guid id)
        {
            return _mapper.Map<BdgreportParameterAddEditModel>(await _uow.BdgreportParameterRepository.Get(id));
        }

        public async Task<bool> Save(BdgreportParameterAddEditModel model)
        {
            if (model.ObjectUID == null)
            {
                BdgreportParameter entity = _mapper.Map<BdgreportParameter>(model);
                entity.CreatedOn = DateTime.UtcNow;
                entity.NameAlias = model.NameAlias == null ? "" : model.NameAlias;
                await _uow.BdgreportParameterRepository.Add(entity);
            }
            else
            {
                BdgreportParameter entity = await _uow.BdgreportParameterRepository.Get(model.ObjectUID.Value);
                entity = _mapper.Map<BdgreportParameterAddEditModel, BdgreportParameter>(model, entity);
                entity.UpdatedOn = DateTime.UtcNow;
                await _uow.BdgreportParameterRepository.Update(entity);
                _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            }
            return await _uow.SaveAsync();

        }
        public async Task<bool> Update(Guid id, string values)
        {
            BdgreportParameter entity = await _uow.BdgreportParameterRepository.Get(id);
            JsonConvert.PopulateObject(values, entity);

            entity.UpdatedOn = DateTime.UtcNow;
            await _uow.BdgreportParameterRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();

        }
        public async Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.BdgreportParameterRepository.Query().Where(x => x.IsDeleted == false).Select(x =>
                new BdgreportParameter
                {
                    ObjectUid = x.ObjectUid,
                    ParameterDisplayName = x.ParameterDisplayName
                });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }
        public List<SelectListItem> GetLookupTable()
        {
            var list = _config.GetSection("TableNames").Get<List<string>>();
            return list.Select(x => new SelectListItem
            {
                Text = x,
                Value = x
            }).ToList();
        }

        public async Task<List<ReportParameter>> GetParameters(Guid id)
        {
            var query = await _uow.BdgreportParameterRepository.Query().Where(x => x.BdgreportId == id && x.IsDeleted == false).Select(x =>
                 new ReportParameter
                 {
                     TableName = x.Name,
                     ReportName = _uow.BdgreportRepository.Query()
                     .Where(m => m.ObjectUid == x.BdgreportId && x.IsDeleted == false).Select(w => w.Source).FirstOrDefault(),
                     ParameterName = x.ParameterDatabaseFieldName,
                     ParameterDefaultValue = x.ParameterDefaultValue,
                     ParameterType = _uow.BdgreportParameterTypeRepository.Query()
                     .Where(m => m.ObjectUid == x.BdgreportParameterTypeId && x.IsDeleted == false).Select(w => w.Name).FirstOrDefault(),
                     DropdownText = x.NameAlias,
                 }).ToListAsync();
            return query;
        }

        public LoadResult GetParameters(Guid id, DataSourceLoadOptionsBase options)
        {
                var query = _uow.BdgreportParameterRepository.Query().Where(x => x.BdgreportId == id && x.IsDeleted == false)
                .Select(s => new BdgreportParameterListModel
                {
                    ObjectUID = s.ObjectUid,
                    Name = s.Name,
                    ParameterDisplayName = s.ParameterDisplayName,
                    ParameterDatabaseFieldName = s.ParameterDatabaseFieldName,
                    ParameterDefaultValue = s.ParameterDefaultValue,
                    BdgreportId = s.BdgreportId,
                    BdgreportParameterTypeId = s.BdgreportParameterTypeId,
                    ParameterDefaultStartValue = s.ParameterDefaultStartValue,
                    ParameterDefaultEndValue = s.ParameterDefaultEndValue
                }).ToList();

            return DataSourceLoader.Load(query, options);
        }

        public List<SelectListItem> ParameterData(string tableName, string textName, string valueName)
        {
            var list = new List<SelectListItem>();
            var table = "select * from "+tableName;
            string CS = _config.GetConnectionString("Default");
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM " + tableName, con); ;
                cmd.CommandType = CommandType.Text;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var listData = new SelectListItem();

                    listData.Text = rdr[textName].ToString() != null ? rdr[textName].ToString() : "";
                    listData.Value = rdr[valueName].ToString() != null ? rdr[valueName].ToString() : "";
                    list.Add(listData);
                }
                con.Close();
            }
            return list;
        }
    }
}
