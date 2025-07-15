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
    public interface ILRPLM2ReceiptCodeService
    {
        Task<IEnumerable<LRPLM2ReceiptCodeListModel>> GetAll();
        Task<bool> Delete(Guid id);
        Task<LRPLM2ReceiptCodeAddEditModel> Get(Guid id);
        Task<bool> Save(LRPLM2ReceiptCodeAddEditModel model);
        LoadResult GetPage(DataSourceLoadOptionsBase options);
        Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions);
        Task<bool> Update(Guid id, string values);
    }
    public class LRPLM2ReceiptCodeService: BaseService,ILRPLM2ReceiptCodeService
    {
        public LRPLM2ReceiptCodeService(IUnitOfWork uow, UserResolverService userResolverService, IMapper mapper)
         : base(uow, userResolverService, mapper)
        {
        }

        public LoadResult GetPage(DataSourceLoadOptionsBase options)
        {
            var query = _uow.LRPLM2ReceiptCodeRepository.Query().Where(x => x.IsDeleted == false)
                .Select(s => new LRPLM2ReceiptCodeListModel
                {
                    ObjectUID = s.ObjectUid,
                    Name = s.Name,
                });

            return DataSourceLoader.Load(query, options);
        }

        public async Task<IEnumerable<LRPLM2ReceiptCodeListModel>> GetAll()
        {
            return _mapper.Map<List<LRPLM2ReceiptCodeListModel>>(await _uow.LRPLM2ReceiptCodeRepository.GetAll());
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _uow.LRPLM2ReceiptCodeRepository.Get(id);
            entity.UpdatedOn = DateTime.UtcNow;
            entity.IsDeleted = true;
            await _uow.LRPLM2ReceiptCodeRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();
        }

        public async Task<LRPLM2ReceiptCodeAddEditModel> Get(Guid id)
        {
            return _mapper.Map<LRPLM2ReceiptCodeAddEditModel>(await _uow.LRPLM2ReceiptCodeRepository.Get(id));
        }

        public async Task<bool> Save(LRPLM2ReceiptCodeAddEditModel model)
        {
            if (model.ObjectUID == null)
            {
                Lrplm2receiptCode entity = _mapper.Map<Lrplm2receiptCode>(model);
                entity.CreatedOn = DateTime.UtcNow;
                entity.NameAlias = entity.Name;
                await _uow.LRPLM2ReceiptCodeRepository.Add(entity);
            }
            else
            {
                Lrplm2receiptCode entity = await _uow.LRPLM2ReceiptCodeRepository.Get(model.ObjectUID.Value);
                entity = _mapper.Map<LRPLM2ReceiptCodeAddEditModel, Lrplm2receiptCode>(model, entity);
                entity.UpdatedOn = DateTime.UtcNow;
                await _uow.LRPLM2ReceiptCodeRepository.Update(entity);
                _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            }
            return await _uow.SaveAsync();

        }
        public async Task<bool> Update(Guid id, string values)
        {
            Lrplm2receiptCode entity = await _uow.LRPLM2ReceiptCodeRepository.Get(id);
            JsonConvert.PopulateObject(values, entity);

            entity.UpdatedOn = DateTime.UtcNow;
            await _uow.LRPLM2ReceiptCodeRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();

        }
        public async Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.LRPLM2ReceiptCodeRepository.Query().Where(x => x.IsDeleted == false).Select(x =>
                new Lrplm2receiptCode
                {
                    ObjectUid = x.ObjectUid,
                    Name = x.Name
                });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }
    }
}
