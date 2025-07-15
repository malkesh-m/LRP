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
    public interface ILRPCompanyService
    {
        Task<IEnumerable<LRPCompanyListModel>> GetAll();
        Task<bool> Delete(Guid id);
        Task<LRPCompanyAddEditModel> Get(Guid id);
        Task<bool> Save(LRPCompanyAddEditModel model);
        Task<bool> Update(Guid id,string values);
        LoadResult GetPage(DataSourceLoadOptionsBase options);
        Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions);
    }

    public class LRPCompanyService : BaseService, ILRPCompanyService
    {
        public LRPCompanyService(IUnitOfWork uow, UserResolverService userResolverService, IMapper mapper)
            : base(uow, userResolverService, mapper)
        {
        }

        public LoadResult GetPage(DataSourceLoadOptionsBase options)
        {
            var query = _uow.LRPCompanyRepository.Query().IgnoreAutoIncludes().Where(x => x.IsDeleted == false)
                .Select(s => new LRPCompanyListModel
                {
                    ObjectUID = s.ObjectUid,
                    Name = s.Name,
                    Code=s.Code,
                    AddressLineI=s.AddressLineI,
                    AddressLineII=s.AddressLineIi,
                    City =s.City,
                    Zipcode=s.PostalCode,
                    CountryId=s.CountryId,
                    CountryStateId=s.CountryStateId,
                    ParentLrpcompanyId=s.ParentLrpcompanyId,
                    Description=s.Description

                });

            return DataSourceLoader.Load(query, options);
        }

        public async Task<IEnumerable<LRPCompanyListModel>> GetAll()
        {
            return _mapper.Map<List<LRPCompanyListModel>>(await _uow.LRPCompanyRepository.GetAll());
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _uow.LRPCompanyRepository.Get(id);
            entity.UpdatedOn = DateTime.UtcNow;
            entity.IsDeleted = true;
            await _uow.LRPCompanyRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();
        }

        public async Task<LRPCompanyAddEditModel> Get(Guid id)
        {
            return _mapper.Map<LRPCompanyAddEditModel>(await _uow.LRPCompanyRepository.Get(id));
        }

        public async Task<bool> Save(LRPCompanyAddEditModel model)
        {

            if (model.ObjectUID == null)
            {
                Lrpcompany entity = _mapper.Map<Lrpcompany>(model);
                entity.CreatedOn = DateTime.UtcNow;
                entity.NameAlias = entity.Name;
                await _uow.LRPCompanyRepository.Add(entity);
            }
            else
            {
                Lrpcompany entity = await _uow.LRPCompanyRepository.Get(model.ObjectUID.Value);
                entity = _mapper.Map<LRPCompanyAddEditModel, Lrpcompany>(model, entity);
                entity.UpdatedOn = DateTime.UtcNow;
                await _uow.LRPCompanyRepository.Update(entity);
                _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            }
            return await _uow.SaveAsync();

        }

        public async Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.LRPCompanyRepository.Query().Where(x => x.IsDeleted == false).Select(x =>
                 new Lrpcompany
                 {
                     ObjectUid = x.ObjectUid,
                     Name = x.Name
                 });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }
        public async Task<bool> Update(Guid id, string values)
        {
            Lrpcompany entity = await _uow.LRPCompanyRepository.Get(id);
            JsonConvert.PopulateObject(values, entity);

            entity.UpdatedOn = DateTime.UtcNow;
            await _uow.LRPCompanyRepository.Update(entity);
            _uow.DbContext.Entry(entity).Property(x => x.RecordId).IsModified = false;
            return await _uow.SaveAsync();

        }


    }
}
