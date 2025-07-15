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
    public interface ILRPEmployeeService
    {
        Task<IEnumerable<LRPEmployeeListModel>> GetAll();
        Task<bool> Delete(Guid id);
        Task<LRPEmployeeAddEditModel> Get(Guid id);
        Task<bool> Save(LRPEmployeeAddEditModel model);
        LoadResult GetPage(DataSourceLoadOptionsBase options, List<string> departments);
        Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions);
        Task<bool> Update(Guid id, string values);
    }
    public class LRPEmployeeService : BaseService, ILRPEmployeeService
    {
        public LRPEmployeeService(IUnitOfWork uow, UserResolverService userResolverService, IMapper mapper)
        : base(uow, userResolverService, mapper)
        {
        }

        public LoadResult GetPage(DataSourceLoadOptionsBase options, List<string> departments)
        {
            var query = _uow.LRPEmployeeRepository.Query().Where(x => x.IsDeleted == false )
                .Select(s => new LRPEmployeeListModel
                {
                    ObjectUID = s.ObjectUid,
                    Name = s.Name,
                    FirstName = s.FirstName,
                    MiddleName = s.MiddleName,
                    LastName = s.LastName,
                    LrpemployeeTypeId = s.LrpemployeeTypeId,
                    LrpemployeeStatusId = s.LrpemployeeStatusId,
                    LrpcostCenterId = s.LrpcostCenterId,
                    LrpdepartmentId = s.LrpdepartmentId,
                    IsInactive = s.IsInactive,
                    GrantWorker = s.GrantWorker,
                    HireDate = s.HireDate,
                    TermDate = s.TermDate,
                    JobTitle = s.JobTitle,
                    EmployeeNo = s.EmployeeNo
                });

            return DataSourceLoader.Load(query, options);
        }

        public async Task<IEnumerable<LRPEmployeeListModel>> GetAll()
        {
            return _mapper.Map<List<LRPEmployeeListModel>>(await _uow.LRPEmployeeRepository.GetAll());
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _uow.LRPEmployeeRepository.Get(id);
            entity.UpdatedOn = DateTime.UtcNow;
            entity.IsDeleted = true;
            await _uow.LRPEmployeeRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();
        }

        public async Task<LRPEmployeeAddEditModel> Get(Guid id)
        {
            return _mapper.Map<LRPEmployeeAddEditModel>(await _uow.LRPEmployeeRepository.Get(id));
        }

        public async Task<bool> Save(LRPEmployeeAddEditModel model)
        {
            if (model.ObjectUID == null)
            {
                Lrpemployee entity = _mapper.Map<Lrpemployee>(model);
                entity.CreatedOn = DateTime.UtcNow;
                entity.NameAlias = entity.Name;
                await _uow.LRPEmployeeRepository.Add(entity);
            }
            else
            {
                Lrpemployee entity = await _uow.LRPEmployeeRepository.Get(model.ObjectUID.Value);
                entity = _mapper.Map<LRPEmployeeAddEditModel, Lrpemployee>(model, entity);
                entity.UpdatedOn = DateTime.UtcNow;
                await _uow.LRPEmployeeRepository.Update(entity);
                _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            }
            return await _uow.SaveAsync();
        }
        public async Task<bool> Update(Guid id, string values)
        {
            Lrpemployee entity = await _uow.LRPEmployeeRepository.Get(id);
            JsonConvert.PopulateObject(values, entity);

            entity.UpdatedOn = DateTime.UtcNow;
            await _uow.LRPEmployeeRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();

        }
        public async Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.LRPEmployeeRepository.Query().Where(x => x.IsDeleted == false).Select(x =>
                new Lrpemployee
                {
                    ObjectUid = x.ObjectUid,
                    Name = x.Name,
                    EmployeeNo = x.EmployeeNo
                });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }
    }
}