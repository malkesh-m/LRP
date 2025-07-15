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
    public interface ICountryStateService
    {
        Task<IEnumerable<CountryStateListModel>> GetAll();
        Task<bool> Delete(Guid id);
        Task<CountryStateAddEditModel> Get(Guid id);
        Task<bool> Save(CountryStateAddEditModel model);
        LoadResult GetPage(DataSourceLoadOptionsBase options);
        Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions);
        Task<bool> Update(Guid id, string values);
    }

    public class CountryStateService : BaseService, ICountryStateService
    {
        public CountryStateService(IUnitOfWork uow, UserResolverService userResolverService, IMapper mapper)
            : base(uow, userResolverService, mapper)
        {
        }

        public LoadResult GetPage(DataSourceLoadOptionsBase options)
        {
            var query = _uow.CountryStateRepository.Query().Where(x => x.IsDeleted == false)
                .Select(s => new CountryStateListModel
                {
                    ObjectUID = s.ObjectUid,
                    Name = s.Name,
                });

            return DataSourceLoader.Load(query, options);
        }

        public async Task<IEnumerable<CountryStateListModel>> GetAll()
        {
            return _mapper.Map<List<CountryStateListModel>>(await _uow.CountryStateRepository.GetAll());
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _uow.CountryStateRepository.Get(id);
            entity.UpdatedOn = DateTime.UtcNow;
            entity.IsDeleted = true;
            await _uow.CountryStateRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();
        }

        public async Task<CountryStateAddEditModel> Get(Guid id)
        {
            return _mapper.Map<CountryStateAddEditModel>(await _uow.CountryStateRepository.Get(id));
        }

        public async Task<bool> Save(CountryStateAddEditModel model)
        {
            if (model.ObjectUID == null)
            {
                CountryState entity = _mapper.Map<CountryState>(model);
                entity.CreatedOn = DateTime.UtcNow;
                entity.NameAlias = entity.Name;
                await _uow.CountryStateRepository.Add(entity);
            }
            else
            {
                CountryState entity = await _uow.CountryStateRepository.Get(model.ObjectUID.Value);
                entity = _mapper.Map<CountryStateAddEditModel, CountryState>(model, entity);
                entity.UpdatedOn = DateTime.UtcNow;
                await _uow.CountryStateRepository.Update(entity);
                _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            }
            return await _uow.SaveAsync();

        }
        public async Task<bool> Update(Guid id, string values)
        {
            CountryState entity = await _uow.CountryStateRepository.Get(id);
            JsonConvert.PopulateObject(values, entity);

            entity.UpdatedOn = DateTime.UtcNow;
            await _uow.CountryStateRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();

        }
        public async Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.CountryStateRepository.Query().Where(x => x.IsDeleted == false).Select(x =>
                new CountryState
                {
                    ObjectUid = x.ObjectUid,
                    CountryId = x.CountryId,
                    Name = x.Name
                });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }
    }
}
