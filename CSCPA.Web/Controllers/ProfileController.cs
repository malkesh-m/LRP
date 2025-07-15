using CSCPA.Core;
using CSCPA.Model;
using CSCPA.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSCPA.Web.Controllers
{
    public class ProfileController : Controller
    {
        IUserAccountService _userAccountService;
        ICountryService _CountryService;
        public ProfileController(IUserAccountService userAccountService, ICountryService CountryService)
        {
            _userAccountService = userAccountService;
            _CountryService = CountryService;
        }
        public async Task<IActionResult> Index()
        {
           // ViewBag.country = await _CountryService.GetLookup();
            var uid = User.Identity.GetUserId();
            return View( _userAccountService.UserExist(uid));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserAccountAddEditModel model)
        {
            await _userAccountService.UpdateUser(model);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<JsonResult> ChangePassword(Guid id,string password)
        {
            var result = await _userAccountService.ChangePassword((Guid)id, password);
            if (result)
                return Json(new JsonResponse(ResponseType.Success, "Password changed successfully"));
            return Json(new JsonResponse(ResponseType.Error, GlobalConstant.Error));
        }
    }
}
