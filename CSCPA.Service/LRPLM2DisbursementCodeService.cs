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
    public interface ILRPLM2DisbursementCodeService
    {
        Task<IEnumerable<LRPLM2DisbursementCodeListModel>> GetAll();
        Task<bool> Delete(Guid id);
        Task<LRPLM2DisbursementCodeAddEditModel> Get(Guid id);
        Task<bool> Save(LRPLM2DisbursementCodeAddEditModel model);
        LoadResult GetPage(DataSourceLoadOptionsBase options);
        Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions);
        Task<bool> Update(Guid id, string values);
    }
    public class LRPLM2DisbursementCodeService: BaseService, ILRPLM2DisbursementCodeService
    {
        public LRPLM2DisbursementCodeService(IUnitOfWork uow, UserResolverService userResolverService, IMapper mapper)
         : base(uow, userResolverService, mapper)
        {
        }

        public LoadResult GetPage(DataSourceLoadOptionsBase options)
        {
            var query = _uow.LRPLM2DisbursementCodeRepository.Query().Where(x => x.IsDeleted == false)
                .Select(s => new LRPLM2DisbursementCodeListModel
                {
                    ObjectUID = s.ObjectUid,
                    Name = s.Name,
                });

            return DataSourceLoader.Load(query, options);
        }

        public async Task<IEnumerable<LRPLM2DisbursementCodeListModel>> GetAll()
        {
            return _mapper.Map<List<LRPLM2DisbursementCodeListModel>>(await _uow.LRPLM2DisbursementCodeRepository.GetAll());
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _uow.LRPLM2DisbursementCodeRepository.Get(id);
            entity.UpdatedOn = DateTime.UtcNow;
            entity.IsDeleted = true;
            await _uow.LRPLM2DisbursementCodeRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();
        }

        public async Task<LRPLM2DisbursementCodeAddEditModel> Get(Guid id)
        {
            return _mapper.Map<LRPLM2DisbursementCodeAddEditModel>(await _uow.LRPLM2DisbursementCodeRepository.Get(id));
        }

        public async Task<bool> Save(LRPLM2DisbursementCodeAddEditModel model)
        {
            if (model.ObjectUID == null)
            {
                Lrplm2disbursementCode entity = _mapper.Map<Lrplm2disbursementCode>(model);
                entity.CreatedOn = DateTime.UtcNow;
                entity.NameAlias = entity.Name;
                await _uow.LRPLM2DisbursementCodeRepository.Add(entity);
            }
            else
            {
                Lrplm2disbursementCode entity = await _uow.LRPLM2DisbursementCodeRepository.Get(model.ObjectUID.Value);
                entity = _mapper.Map<LRPLM2DisbursementCodeAddEditModel, Lrplm2disbursementCode>(model, entity);
                entity.UpdatedOn = DateTime.UtcNow;
                await _uow.LRPLM2DisbursementCodeRepository.Update(entity);
                _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            }
            return await _uow.SaveAsync();

        }
        public async Task<bool> Update(Guid id, string values)
        {
            Lrplm2disbursementCode entity = await _uow.LRPLM2DisbursementCodeRepository.Get(id);
            JsonConvert.PopulateObject(values, entity);

            entity.UpdatedOn = DateTime.UtcNow;
            await _uow.LRPLM2DisbursementCodeRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();

        }
        public async Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.LRPLM2DisbursementCodeRepository.Query().Where(x => x.IsDeleted == false).Select(x =>
                new Lrplm2disbursementCode
                {
                    ObjectUid = x.ObjectUid,
                    Name = x.Name
                });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }
    }
}
