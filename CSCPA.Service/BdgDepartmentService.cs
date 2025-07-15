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
    public interface IBdgDepartmentService
    {
        Task<IEnumerable<BdgDepartmentListModel>> GetAll();
        Task<bool> Delete(Guid id);
        Task<BdgDepartmentAddEditModel> Get(Guid id);
        Task<bool> Save(BdgDepartmentAddEditModel model);
        LoadResult GetPage(DataSourceLoadOptionsBase options);
        Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions);
        Task<LoadResult> GetDropLookup(DataSourceLoadOptionsBase loadOptions);
        Task<bool> Update(Guid id, string values);
        List<SelectListItem> GetJsonLookup();
    }
    public class BdgDepartmentService : BaseService, IBdgDepartmentService
    {
        public BdgDepartmentService(IUnitOfWork uow, UserResolverService userResolverService, IMapper mapper)
         : base(uow, userResolverService, mapper)
        {
        }

        public LoadResult GetPage(DataSourceLoadOptionsBase options)
        {
            var query = _uow.BdgdepartmentRepository.Query().Where(x => x.IsDeleted == false)
                .Select(s => new BdgDepartmentListModel
                {
                    ObjectUID = s.ObjectUid,
                    Name = s.Name,
                }).ToList();

            return DataSourceLoader.Load(query, options);
        }

        public async Task<IEnumerable<BdgDepartmentListModel>> GetAll()
        {
            return _mapper.Map<List<BdgDepartmentListModel>>(await _uow.BdgdepartmentRepository.GetAll());
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _uow.BdgdepartmentRepository.Get(id);
            entity.UpdatedOn = DateTime.UtcNow;
            entity.IsDeleted = true;
            await _uow.BdgdepartmentRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();
        }

        public async Task<BdgDepartmentAddEditModel> Get(Guid id)
        {
            return _mapper.Map<BdgDepartmentAddEditModel>(await _uow.BdgdepartmentRepository.Get(id));
        }

        public async Task<bool> Save(BdgDepartmentAddEditModel model)
        {
            if (model.ObjectUID == null)
            {
                Bdgdepartment entity = _mapper.Map<Bdgdepartment>(model);
                entity.CreatedOn = DateTime.UtcNow;
                entity.NameAlias = entity.Name;
                await _uow.BdgdepartmentRepository.Add(entity);
            }
            else
            {
                Bdgdepartment entity = await _uow.BdgdepartmentRepository.Get(model.ObjectUID.Value);
                entity = _mapper.Map<BdgDepartmentAddEditModel, Bdgdepartment>(model, entity);
                entity.UpdatedOn = DateTime.UtcNow;
                await _uow.BdgdepartmentRepository.Update(entity);
                _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            }
            return await _uow.SaveAsync();

        }
        public async Task<bool> Update(Guid id, string values)
        {
            Bdgdepartment entity = await _uow.BdgdepartmentRepository.Get(id);
            JsonConvert.PopulateObject(values, entity);

            entity.UpdatedOn = DateTime.UtcNow;
            await _uow.BdgdepartmentRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();

        }
        public async Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.BdgdepartmentRepository.Query().Where(x => x.IsDeleted == false).Select(x =>
                new Bdgdepartment
                {
                    ObjectUid = x.ObjectUid,
                    Name = x.Name
                });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }
        public async Task<LoadResult> GetDropLookup(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.BdgdepartmentRepository.Query().Where(x => x.IsDeleted == false).Select(x =>
                new SelectListItem
                {
                    Value = x.ObjectUid.ToString(),
                    Text = x.Name
                });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }
        public List<SelectListItem> GetJsonLookup()
        {
            var query = _uow.BdgdepartmentRepository.Query().Where(x => x.IsDeleted == false).Select(x =>
                new SelectListItem
                {
                    Value = x.ObjectUid.ToString(),
                    Text = x.Name
                }).ToList();
            return query;
        }
    }
}
