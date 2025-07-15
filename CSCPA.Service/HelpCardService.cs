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
    public interface IHelpCardService
    {
        Task<IEnumerable<HelpCardListModel>> GetAll();
        Task<bool> Delete(Guid id);
        Task<HelpCardAddEditModel> Get(Guid id);
        Task<bool> Save(HelpCardAddEditModel model);
        LoadResult GetPage(DataSourceLoadOptionsBase options);
        Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions);
        Task<bool> Update(Guid id, string values);
    }
    public class HelpCardService : BaseService, IHelpCardService
    {
        public HelpCardService(IUnitOfWork uow, UserResolverService userResolverService, IMapper mapper)
           : base(uow, userResolverService, mapper)
        {
        }

        public LoadResult GetPage(DataSourceLoadOptionsBase options)
        {
            var query = _uow.HelpCardRepository.Query().Where(x => x.IsDeleted == false)
                .Select(s => new HelpCardListModel
                {
                    ObjectUID = s.ObjectUid,
                    Name = s.Name,
                });

            return DataSourceLoader.Load(query, options);
        }

        public async Task<IEnumerable<HelpCardListModel>> GetAll()
        {
            return _mapper.Map<List<HelpCardListModel>>(await _uow.HelpCardRepository.GetAll());
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _uow.HelpCardRepository.Get(id);
            entity.UpdatedOn = DateTime.UtcNow;
            entity.IsDeleted = true;
            await _uow.HelpCardRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();
        }

        public async Task<HelpCardAddEditModel> Get(Guid id)
        {
            return _mapper.Map<HelpCardAddEditModel>(await _uow.HelpCardRepository.Get(id));
        }

        public async Task<bool> Save(HelpCardAddEditModel model)
        {
            if (model.ObjectUID == null)
            {
                HelpCard entity = _mapper.Map<HelpCard>(model);
                entity.CreatedOn = DateTime.UtcNow;
                entity.NameAlias = entity.Name;
                await _uow.HelpCardRepository.Add(entity);
            }
            else
            {
                HelpCard entity = await _uow.HelpCardRepository.Get(model.ObjectUID.Value);
                entity = _mapper.Map<HelpCardAddEditModel, HelpCard>(model, entity);
                entity.UpdatedOn = DateTime.UtcNow;
                await _uow.HelpCardRepository.Update(entity);
                _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            }
            return await _uow.SaveAsync();

        }
        public async Task<bool> Update(Guid id, string values)
        {
            HelpCard entity = await _uow.HelpCardRepository.Get(id);
            JsonConvert.PopulateObject(values, entity);

            entity.UpdatedOn = DateTime.UtcNow;
            await _uow.HelpCardRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();

        }
        public async Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.HelpCardRepository.Query().Where(x => x.IsDeleted == false).Select(x =>
                new HelpCard
                {
                    ObjectUid = x.ObjectUid,
                    Name = x.Name
                });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }
    }
}
