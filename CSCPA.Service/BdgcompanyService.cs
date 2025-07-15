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
    public interface IBdgcompanyService
    {
        Task<IEnumerable<BdgcompanyListModel>> GetAll();
        Task<bool> Delete(Guid id);
        Task<BdgcompanyAddEditModel> Get(Guid id);
        Task<bool> Save(BdgcompanyAddEditModel model);
        LoadResult GetPage(DataSourceLoadOptionsBase options);
        Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions);
        Task<bool> Update(Guid id, string values);
    }
    public class BdgcompanyService : BaseService, IBdgcompanyService
    {
        public BdgcompanyService(IUnitOfWork uow, UserResolverService userResolverService, IMapper mapper)
          : base(uow, userResolverService, mapper)
        {
        }

        public LoadResult GetPage(DataSourceLoadOptionsBase options)
        {
            var query = _uow.BdgcompanyRepository.Query().Where(x => x.IsDeleted == false)
                .Select(s => new BdgcompanyListModel
                {
                    ObjectUID = s.ObjectUid,
                    Name = s.Name,
                }).ToList();

            return DataSourceLoader.Load(query, options);
        }

        public async Task<IEnumerable<BdgcompanyListModel>> GetAll()
        {
            return _mapper.Map<List<BdgcompanyListModel>>(await _uow.BdgcompanyRepository.GetAll());
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _uow.BdgcompanyRepository.Get(id);
            entity.UpdatedOn = DateTime.UtcNow;
            entity.IsDeleted = true;
            await _uow.BdgcompanyRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();
        }

        public async Task<BdgcompanyAddEditModel> Get(Guid id)
        {
            return _mapper.Map<BdgcompanyAddEditModel>(await _uow.BdgcompanyRepository.Get(id));
        }

        public async Task<bool> Save(BdgcompanyAddEditModel model)
        {
            if (model.ObjectUID == null)
            {
                Bdgcompany entity = _mapper.Map<Bdgcompany>(model);
                entity.CreatedOn = DateTime.UtcNow;
                entity.NameAlias = entity.Name;
                await _uow.BdgcompanyRepository.Add(entity);
            }
            else
            {
                Bdgcompany entity = await _uow.BdgcompanyRepository.Get(model.ObjectUID.Value);
                entity = _mapper.Map<BdgcompanyAddEditModel, Bdgcompany>(model, entity);
                entity.UpdatedOn = DateTime.UtcNow;
                await _uow.BdgcompanyRepository.Update(entity);
                _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            }
            return await _uow.SaveAsync();

        }
        public async Task<bool> Update(Guid id, string values)
        {
            Bdgcompany entity = await _uow.BdgcompanyRepository.Get(id);
            JsonConvert.PopulateObject(values, entity);

            entity.UpdatedOn = DateTime.UtcNow;
            await _uow.BdgcompanyRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();

        }
        public async Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.BdgcompanyRepository.Query().Where(x => x.IsDeleted == false).Select(x =>
                new Bdgcompany
                {
                    ObjectUid = x.ObjectUid,
                    Name = x.Name
                });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }
    }
}
