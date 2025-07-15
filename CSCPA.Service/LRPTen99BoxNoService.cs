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
    public interface ILRPTen99BoxNoService
    {
        Task<IEnumerable<LRPTen99BoxNoListModel>> GetAll();
        Task<bool> Delete(Guid id);
        Task<LRPTen99BoxNoAddEditModel> Get(Guid id);
        Task<bool> Save(LRPTen99BoxNoAddEditModel model);
        LoadResult GetPage(DataSourceLoadOptionsBase options);
        Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions);
        Task<bool> Update(Guid id, string values);
    }
    public class LRPTen99BoxNoService : BaseService, ILRPTen99BoxNoService
    {
        public LRPTen99BoxNoService(IUnitOfWork uow, UserResolverService userResolverService, IMapper mapper)
       : base(uow, userResolverService, mapper)
        {
        }

        public LoadResult GetPage(DataSourceLoadOptionsBase options)
        {
            var query = _uow.LRPTen99BoxNoRepository.Query().Where(x => x.IsDeleted == false)
                .Select(s => new LRPTen99BoxNoListModel
                {
                    ObjectUID = s.ObjectUid,
                    Name = s.Name,
                    Ten99BoxNo = s.Ten99BoxNo,
                    Ten99BoxText = s.Ten99BoxText,
                    Dolramnt = s.Dolramnt,
                    Lrpten99TaxTypeId = s.Lrpten99TaxTypeId
                });

            return DataSourceLoader.Load(query, options);
        }

        public async Task<IEnumerable<LRPTen99BoxNoListModel>> GetAll()
        {
            return _mapper.Map<List<LRPTen99BoxNoListModel>>(await _uow.LRPTen99BoxNoRepository.GetAll());
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _uow.LRPTen99BoxNoRepository.Get(id);
            entity.UpdatedOn = DateTime.UtcNow;
            entity.IsDeleted = true;
            await _uow.LRPTen99BoxNoRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();
        }

        public async Task<LRPTen99BoxNoAddEditModel> Get(Guid id)
        {
            return _mapper.Map<LRPTen99BoxNoAddEditModel>(await _uow.LRPTen99BoxNoRepository.Get(id));
        }

        public async Task<bool> Save(LRPTen99BoxNoAddEditModel model)
        {
            if (model.ObjectUID == null)
            {
                Lrpten99BoxNo entity = _mapper.Map<Lrpten99BoxNo>(model);
                entity.CreatedOn = DateTime.UtcNow;
                entity.NameAlias = entity.Name;
                await _uow.LRPTen99BoxNoRepository.Add(entity);
            }
            else
            {
                Lrpten99BoxNo entity = await _uow.LRPTen99BoxNoRepository.Get(model.ObjectUID.Value);
                entity = _mapper.Map<LRPTen99BoxNoAddEditModel, Lrpten99BoxNo>(model, entity);
                entity.UpdatedOn = DateTime.UtcNow;
                await _uow.LRPTen99BoxNoRepository.Update(entity);
                _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            }
            return await _uow.SaveAsync();

        }
        public async Task<bool> Update(Guid id, string values)
        {
            Lrpten99BoxNo entity = await _uow.LRPTen99BoxNoRepository.Get(id);
            JsonConvert.PopulateObject(values, entity);

            entity.UpdatedOn = DateTime.UtcNow;
            await _uow.LRPTen99BoxNoRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();

        }
        public async Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.LRPTen99BoxNoRepository.Query().Where(x => x.IsDeleted == false).Select(x =>
                new Lrpten99BoxNo
                {
                    ObjectUid = x.ObjectUid,
                    Name = x.Ten99BoxNo.ToString()
                });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }
    }
}
