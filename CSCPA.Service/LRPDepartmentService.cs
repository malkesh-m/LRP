using AutoMapper;
using CSCPA.Data.Entities;
using CSCPA.Model;
using CSCPA.Repo;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;

using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSCPA.Service
{
    public interface ILRPDepartmentService
    {
        Task<IEnumerable<LRPDepartmentListModel>> GetAll();
        Task<bool> Delete(Guid id);
        Task<LRPDepartmentAddEditModel> Get(Guid id);
        Task<bool> Save(LRPDepartmentAddEditModel model);
        Task<bool> Update(Guid id,string values);
        LoadResult GetPage(DataSourceLoadOptionsBase options);
        Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions);
    }

    public class LRPDepartmentService : BaseService, ILRPDepartmentService
    {
        public LRPDepartmentService(IUnitOfWork uow, UserResolverService userResolverService, IMapper mapper)
            : base(uow, userResolverService, mapper)
        {
        }

        public LoadResult GetPage(DataSourceLoadOptionsBase options)
        {
            var query = _uow.LRPDepartmentRepository.Query().IgnoreAutoIncludes().Where(x => x.IsDeleted == false)
                .Select(s => new LRPDepartmentListModel
                {
                    ObjectUID = s.ObjectUid,
                    DepartmentNo = s.DepartmentNo,
                    Name = s.Name,
                    Description = s.Description

                }); ;

            return DataSourceLoader.Load(query, options);
        }

        public async Task<IEnumerable<LRPDepartmentListModel>> GetAll()
        {
            return _mapper.Map<List<LRPDepartmentListModel>>(await _uow.LRPDepartmentRepository.GetAll());
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _uow.LRPDepartmentRepository.Get(id);
            entity.UpdatedOn = DateTime.UtcNow;
            entity.IsDeleted = true;
            await _uow.LRPDepartmentRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();
        }

        public async Task<LRPDepartmentAddEditModel> Get(Guid id)
        {
            return _mapper.Map<LRPDepartmentAddEditModel>(await _uow.LRPDepartmentRepository.Get(id));
        }

        public async Task<bool> Save(LRPDepartmentAddEditModel model)
        {

            if (model.ObjectUID == null)
            {
                Lrpdepartment entity = _mapper.Map<Lrpdepartment>(model);
                entity.CreatedOn = DateTime.UtcNow;
                entity.NameAlias = entity.Name;
                await _uow.LRPDepartmentRepository.Add(entity);
            }
            else
            {
                Lrpdepartment entity = await _uow.LRPDepartmentRepository.Get(model.ObjectUID.Value);
                entity = _mapper.Map<LRPDepartmentAddEditModel, Lrpdepartment>(model, entity);
                entity.UpdatedOn = DateTime.UtcNow;
                await _uow.LRPDepartmentRepository.Update(entity);
                _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            }
            return await _uow.SaveAsync();

        }

        public async Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.LRPDepartmentRepository.Query().Where(x => x.IsDeleted == false).Select(x =>
                new Lrpdepartment
                {
                    ObjectUid = x.ObjectUid,
                    Name = x.Name
                });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }
        public async Task<bool> Update(Guid id, string values)
        {
            Lrpdepartment entity = await _uow.LRPDepartmentRepository.Get(id);
            JsonConvert.PopulateObject(values, entity);

            entity.UpdatedOn = DateTime.UtcNow;
            await _uow.LRPDepartmentRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();

        }
    }
}