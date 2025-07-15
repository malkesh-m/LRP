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
    public interface ILocalisationService
    {
        Task<IEnumerable<LocalisationListModel>> GetAll();
        Task<bool> Delete(Guid id);
        Task<LocalisationAddEditModel> Get(Guid id);
        Task<bool> Save(LocalisationAddEditModel model);
        LoadResult GetPage(DataSourceLoadOptionsBase options);
        Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions);
        Task<bool> Update(Guid id, string values);
    }
    public class LocalisationService : BaseService, ILocalisationService
    {
        public LocalisationService(IUnitOfWork uow, UserResolverService userResolverService, IMapper mapper)
           : base(uow, userResolverService, mapper)
        {
        }

        public LoadResult GetPage(DataSourceLoadOptionsBase options)
        {
            var query = _uow.LocalisationRepository.Query().Where(x => x.IsDeleted == false)
                .Select(s => new LocalisationListModel
                {
                    ObjectUID = s.ObjectUid,
                    Name = s.Name,
                });

            return DataSourceLoader.Load(query, options);
        }

        public async Task<IEnumerable<LocalisationListModel>> GetAll()
        {
            return _mapper.Map<List<LocalisationListModel>>(await _uow.LocalisationRepository.GetAll());
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _uow.LocalisationRepository.Get(id);
            entity.UpdatedOn = DateTime.UtcNow;
            entity.IsDeleted = true;
            await _uow.LocalisationRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();
        }

        public async Task<LocalisationAddEditModel> Get(Guid id)
        {
            return _mapper.Map<LocalisationAddEditModel>(await _uow.LocalisationRepository.Get(id));
        }

        public async Task<bool> Save(LocalisationAddEditModel model)
        {
            if (model.ObjectUID == null)
            {
                Localisation entity = _mapper.Map<Localisation>(model);
                entity.CreatedOn = DateTime.UtcNow;
                entity.NameAlias = entity.Name;
                await _uow.LocalisationRepository.Add(entity);
            }
            else
            {
                Localisation entity = await _uow.LocalisationRepository.Get(model.ObjectUID.Value);
                entity = _mapper.Map<LocalisationAddEditModel, Localisation>(model, entity);
                entity.UpdatedOn = DateTime.UtcNow;
                await _uow.LocalisationRepository.Update(entity);
                _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            }
            return await _uow.SaveAsync();

        }
        public async Task<bool> Update(Guid id, string values)
        {
            Localisation entity = await _uow.LocalisationRepository.Get(id);
            JsonConvert.PopulateObject(values, entity);

            entity.UpdatedOn = DateTime.UtcNow;
            await _uow.LocalisationRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();

        }
        public async Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.LocalisationRepository.Query().Where(x => x.IsDeleted == false).Select(x =>
                new Localisation
                {
                    ObjectUid = x.ObjectUid,
                    Name = x.Name
                });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }
    }
}
