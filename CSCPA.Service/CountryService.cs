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
using System.Threading.Tasks;

namespace CSCPA.Service
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryListModel>> GetAll();
        Task<bool> Delete(Guid id);
        Task<CountryAddEditModel> Get(Guid id);
        Task<bool> Save(CountryAddEditModel model);
        LoadResult GetPage(DataSourceLoadOptionsBase options);
        Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions);
        Task<bool> Update(Guid id, string values);
    }

    public class CountryService : BaseService, ICountryService
    {
        public CountryService(IUnitOfWork uow, UserResolverService userResolverService, IMapper mapper)
            : base(uow, userResolverService, mapper)
        {
        }

        public LoadResult GetPage(DataSourceLoadOptionsBase options)
        {
            var query = _uow.CountryRepository.Query().Where(x => x.IsDeleted == false)
                .Select(s => new CountryListModel
                {
                    ObjectUID = s.ObjectUid,
                    Name = s.Name,
                });

            return DataSourceLoader.Load(query, options);
        }

        public async Task<IEnumerable<CountryListModel>> GetAll()
        {
            return _mapper.Map<List<CountryListModel>>(await _uow.CountryRepository.GetAll());
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _uow.CountryRepository.Get(id);
            entity.UpdatedOn = DateTime.UtcNow;
            entity.IsDeleted = true;
            await _uow.CountryRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();
        }

        public async Task<CountryAddEditModel> Get(Guid id)
        {
            return _mapper.Map<CountryAddEditModel>(await _uow.CountryRepository.Get(id));
        }

        public async Task<bool> Save(CountryAddEditModel model)
        {
            if (model.ObjectUID == null)
            {
                Country entity = _mapper.Map<Country>(model);
                entity.CreatedOn = DateTime.UtcNow;
                entity.NameAlias = entity.Name;
                await _uow.CountryRepository.Add(entity);
            }
            else
            {
                Country entity = await _uow.CountryRepository.Get(model.ObjectUID.Value);
                entity = _mapper.Map<CountryAddEditModel, Country>(model, entity);
                entity.UpdatedOn= DateTime.UtcNow;
                await _uow.CountryRepository.Update(entity);
                _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            }
            return await _uow.SaveAsync();
        }
        public async Task<bool> Update(Guid id, string values)
        {
            Country entity = await _uow.CountryRepository.Get(id);
            JsonConvert.PopulateObject(values, entity);

            entity.UpdatedOn = DateTime.UtcNow;
            await _uow.CountryRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();

        }
        public async Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.CountryRepository.Query().Where(x => x.IsDeleted == false).Select(x =>
                new SelectListItem
                {
                    Value = x.ObjectUid.ToString().ToLower(),
                    Text = x.Name
                });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }

    }
}
