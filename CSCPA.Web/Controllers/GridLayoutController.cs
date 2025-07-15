using CACPA.Web.Models;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Linq.Expressions;
using CSCPA.Model;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;
using System;
using CSCPA.Service;
using System.Threading.Tasks;
using CSCPA.Core;
using DevExtreme.AspNet.Data.ResponseModel;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CSCPA.Web.Controllers
{
    
    public class GridLayoutController : Controller
    {
        private readonly IGridLayoutService _GridLayoutService;

        public GridLayoutController(IGridLayoutService GridLayoutService)
        {
            _GridLayoutService = GridLayoutService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddEdit(string? id)
        {
            if (id == null)
            {
                return PartialView("~/Views/GridLayout/_AddEdit.cshtml", new GridLayoutAddEditModel());
            }
            else
            {
                var GridLayout = await _GridLayoutService.Get(id,"");
                return PartialView("~/Views/GridLayout/_AddEdit.cshtml", GridLayout);
            }
        }

        [HttpPost]
        public async Task<JsonResult> Add(string layoutName, string gridId, string Layout, bool isPublic)
        {
            var model = new GridLayoutAddEditModel() { Layout = Layout,Layoutname=layoutName,Gridid=gridId,Ispublic=isPublic };
            var result = await _GridLayoutService.Add(model, User.Identity.GetUserRole());
            if (result)
            {
                string returnText = "GridLayout ";
                returnText += GlobalConstant.Created;
                return Json(new JsonResponse(ResponseType.Success, returnText));
            }

            return Json(new JsonResponse(ResponseType.Error, GlobalConstant.Error));
        }

        [HttpPost]
        public async Task<JsonResult> Edit(string id, string Layout)
        {
            var model = new GridLayoutAddEditModel() { Id = id, Layout = Layout };
            var result = await _GridLayoutService.Edit(model, User.Identity.GetUserRole());
            if (result)
            {
                string returnText = "GridLayout ";
                returnText += GlobalConstant.Updated;
                return Json(new JsonResponse(ResponseType.Success, returnText));
            }
            return Json(new JsonResponse(ResponseType.Error, GlobalConstant.Error));
        }



        [HttpDelete]
        public async Task<JsonResult> Delete(string key)
        {
            var result = await _GridLayoutService.Delete(key);
            if (result == "Success")
                return Json(new JsonResponse(ResponseType.Success, "GridLayout " + GlobalConstant.Deleted));
            else
                return Json(new JsonResponse(ResponseType.Error,result, GlobalConstant.Error));
        }

        [HttpGet]
        public async Task<JsonResult> GetById(string layoutId,string gridId)
        {
            var user = User.Claims.Where(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Select(x => x.Value).FirstOrDefault();
            return Json(await _GridLayoutService.Get(layoutId,user));
        }


        [HttpGet]
        public async Task<LoadResult> Lookup(DataSourceLoadOptions options)
        {
            return await _GridLayoutService.GetLookup(options);
        }

        [HttpGet]
        public JsonResult LastLayout(string gridId)
        {
            var user = User.Claims.Where(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Select(x => x.Value).FirstOrDefault();
            var layoutid = _GridLayoutService.GetLayout(user,gridId);
            return Json(layoutid);
        }
    }
}