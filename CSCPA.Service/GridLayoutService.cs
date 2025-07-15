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
    public interface IGridLayoutService
    {
        Task<IEnumerable<GridLayoutListModel>> GetAll();
        Task<string> Delete(string id);
        Task<GridLayoutAddEditModel> Get(string id,string userId);
        Task<bool> Add(GridLayoutAddEditModel model,string role);
        Task<bool> Edit(GridLayoutAddEditModel model, string role);
        Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions);
        string GetLayout(string userId, string gridId);
    }

    public class GridLayoutService : BaseService, IGridLayoutService
    {
        public GridLayoutService(IUnitOfWork uow, UserResolverService userResolverService, IMapper mapper)
            : base(uow, userResolverService, mapper)
        {
        }


        public async Task<IEnumerable<GridLayoutListModel>> GetAll()
        {
            return _mapper.Map<List<GridLayoutListModel>>(await _uow.GridLayoutRepository.GetAll());
        }

        public async Task<string> Delete(string id)
        {
            var entity = await _uow.GridLayoutRepository.Get(id);
            if (entity.Layoutname.ToLower() == "default")
                return "Can not delete default layout";
            await _uow.GridLayoutRepository.Delete(entity);
            if (await _uow.SaveAsync())
                return "Success";

            return "fail";
        }

        public async Task<GridLayoutAddEditModel> Get(string id, string userId)
        {
            var layout = await _uow.GridLayoutRepository.Get(id);
            if (!string.IsNullOrEmpty(userId))
            {
                var layout1 = _uow.GridLayoutLoginRepository.Query().Where(x => x.Userid == userId && x.Gridid == layout.Gridid).FirstOrDefault();
                if (layout1 == null)
                {
                    Gridlayout grid = new Gridlayout()
                    {
                        Userid = userId,
                        Layoutname = layout.Layoutname,
                        Layout = layout.Id,
                        Gridid = layout.Gridid
                    };
                    grid.Id = Guid.NewGuid().ToString();
                    await _uow.GridLayoutLoginRepository.Add(grid);
                }
                else
                {
                    Gridlayout entity = layout1;
                    entity.Layout = layout.Id;
                    await _uow.GridLayoutLoginRepository.Update(entity);
                }
                await _uow.SaveAsync();
            }
            return _mapper.Map<GridLayoutAddEditModel>(layout);
        }

        public async Task<bool> Add(GridLayoutAddEditModel model,string role)
        {
            if(model.Layoutname.ToLower() == "default" && role == "SystemAdmin" || model.Layoutname.ToLower() != "default")
            {
                var islayoutExist = _uow.GridLayoutRepository.Query().Where(x =>x.Gridid == model.Gridid && x.Layoutname.ToLower() == model.Layoutname.ToLower()).FirstOrDefault();
                if (model.Id == null && islayoutExist == null)
                {
                    Gridlayouts1 entity = _mapper.Map<Gridlayouts1>(model);
                    entity.Id = Guid.NewGuid().ToString();
                    await _uow.GridLayoutRepository.Add(entity);
                    return await _uow.SaveAsync();
                }
            }
            return false;
        }

        public async Task<bool> Edit(GridLayoutAddEditModel model, string role)
        {
            Gridlayouts1 entity = await _uow.GridLayoutRepository.Get(model.Id);
            if (entity.Layoutname.ToLower() == "default" && role == "SystemAdmin" || entity.Layoutname.ToLower() != "default")
            {
                entity.Layout = model.Layout;
                await _uow.GridLayoutRepository.Update(entity);
                return await _uow.SaveAsync();
            }
            return false;
        }

        public async Task<LoadResult> GetLookup(DataSourceLoadOptionsBase loadOptions)
        {
            var query = _uow.GridLayoutRepository.Query().Select(x =>
                new Gridlayouts1
                {
                    Id = x.Id.ToString().ToLower(),
                    Layoutname = x.Layoutname,
                    Gridid = x.Gridid
                });
            return await DataSourceLoader.LoadAsync(query, loadOptions);
        }

        public string GetLayout(string userId, string gridId)
        {
            if (!string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(gridId))
            {
                var layoutId = _uow.GridLayoutLoginRepository.Query().Where(x => x.Userid == userId && x.Gridid == gridId).Select(x => x.Layout).FirstOrDefault();
                if (layoutId != null)
                {
                   var existId =_uow.GridLayoutRepository.Query().Where(x => x.Id == layoutId).Select(x => x.Id == layoutId).FirstOrDefault();
                    if (existId)
                        return layoutId;
                }
                    
            }
            
            return Layout(gridId);
        }

        private string Layout(string gridId)
        {
            var layout = _uow.GridLayoutRepository.Query().Where(x => x.Gridid == gridId && x.Layoutname.ToLower() == "default").Select(x => x.Id).FirstOrDefault();
            if (layout == null)
                return _uow.GridLayoutRepository.Query().Where(x => x.Gridid == gridId).Select(x => x.Id).FirstOrDefault();
            return layout;
        }
    }
}
