using CSCPA.Core.Constant;
using CSCPA.Data.Entities;
using CSCPA.Model;
using CSCPA.Model.Email;
using CSCPA.Service;
using CSCPA.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CSCPA.Web.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IEmailSender _emailSender;
        private readonly IUserAccountRolePermissionListService _permissionListService;
        private readonly IUserAccountService _UserAccountService;
        private readonly IUserAccountRoleService _UserAccountRoleService;
        private readonly IModuleService _moduleService;
        private readonly IUserAccountLRPCompanyService _companyService;
        private readonly IUserAccountBdgDepartmentService _departmentService;

        /*  public AccountController(UserManager<UserAccount> userManager,
                                SignInManager<UserAccount> signInManager,
                                IWebHostEnvironment environment,
                                IEmailSender emailSender, IUserAccountService UserAccountService)
          {
              _userManager = userManager;
              _signInManager = signInManager;
              
              _UserAccountService = UserAccountService;
          }*/
        public AccountController(IUserAccountService UserAccountService, IModuleService moduleService, IUserAccountLRPCompanyService companyService,
            IUserAccountRoleService userAccountRoleService, IUserAccountRolePermissionListService permissionListService,
            IUserAccountBdgDepartmentService departmentService, IWebHostEnvironment environment,IEmailSender emailSender)
        {
            _UserAccountService = UserAccountService;
            _UserAccountRoleService = userAccountRoleService;
            _permissionListService = permissionListService;
            _moduleService = moduleService;
            _companyService = companyService;
            _departmentService = departmentService;
            _environment = environment;
            _emailSender = emailSender;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {

                /*var user = new UserAccount
                {
                    Username = model.Email,
                    Email = model.Email,
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    var result1 = await _signInManager.PasswordSignInAsync(user.Email, model.Password, false, false);
                    if (result1.Succeeded)
                        return RedirectToAction("index", "Home");
                    else
                        return RedirectToAction("Login", "Account");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");*/

            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                var users = _UserAccountService.ValidUser(user.Email, user.Password);
               
                if (users != null)
                {
                    var company = _companyService.UserCompanies((Guid)users.ObjectUID);
                    var department = _departmentService.GetDepartment((Guid)users.ObjectUID);
                    var role = _UserAccountRoleService.GetUserRole((Guid)users.ObjectUID);
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, users.ObjectUID.ToString()),
                        new Claim(ClaimTypes.Name, users.Name),
                        new Claim("token", string.IsNullOrEmpty(role.ImportedObjectUid) ? "NoToken" : role.ImportedObjectUid ),
                        new Claim("RoleId", role.ObjectUID.ToString())
                    };
                    if (role.Name != null)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role.Name));
                        var roleClaims = await _permissionListService.GetClaims((Guid)role.ObjectUID);
                        foreach (var item in roleClaims)
                        {
                            claims.Add(new Claim(item.Type, item.Value));
                        }
                    }
                    foreach (var item in company)
                    {
                        claims.Add(new Claim("Company", item));
                    }
                    foreach (var item in department)
                    {
                        claims.Add(new Claim("Department", item));
                    }
                    var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        AllowRefresh = true,

                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30),

                        IsPersistent = user.RememberMe,

                        IssuedUtc = DateTimeOffset.UtcNow,

                        RedirectUri = "/"
                        // The full path or absolute URI to be used as an http 
                        // redirect response value.
                    };
                    await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
                }
                ModelState.AddModelError("RememberMe", "Incorrect email address or password.");
                /* var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, user.RememberMe, false);

                 if (result.Succeeded)
                 {
                     return RedirectToAction("Index", "Dashboard");

                 }

                 ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
 */              
            }
            return View(user);
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
             CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user =  _UserAccountService.FindByEmail(model.Email);
            if (user == null)
            {
                ViewBag.ShowAlert = "Invalid email.";
                return View("ForgotPassword", model);
            }

            string FilePath = Path.Combine(_environment.WebRootPath, "HtmlTemplate\\", "ForgotPassword.html");
            StreamReader str = new StreamReader(FilePath);
            string emailText = str.ReadToEnd();
            str.Close();

            var token = await _UserAccountService.GenerateToken(user);
            var callback = Url.Action("ResetPassword", "Account", new { token, email = user.Email }, Request.Scheme);

            emailText = emailText.Replace("{{Link}}", callback);

            var isEmailSent = _emailSender.SendEmail(new EmailModel(user.Email, "Your link to reset password in CSCPA", emailText, true));
            if (!isEmailSent)
                ViewBag.ShowAlert = "Send email failed.";
            else
                ViewBag.ShowAlert = "Password reset link has been sent to your email.";

            return View();
        }

        public IActionResult ResetPassword(string token, string email)
        {
            var model = new ResetPasswordViewModel { Token = token, Email = email };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = _UserAccountService.FindByEmail(model.Email);
            if (user == null)
                RedirectToAction("ResetPassword");

            var result = await _UserAccountService.ResetPassword(model.Email,model.Token,model.Password);
            if (!result)
            {
                return View();
            }

            return RedirectToAction("Index", "Dashboard");
        }

        

        /* 


         [HttpPost]
         public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
         {
             if (!ModelState.IsValid)
             {
                 return View(model);
             }

             var user = await _userManager.FindByEmailAsync(model.Email);
             if (user == null)
             {
                 ViewBag.ShowAlert = "Invalid email.";
                 return View("ForgotPassword", model);
             }

            *//* Fetching Email Body Text from EmailTemplate File.  
             string FilePath = Path.Combine(_environment.WebRootPath, "HtmlTemplate\\", "ForgotPassword.html");
             StreamReader str = new StreamReader(FilePath);
             string emailText = str.ReadToEnd();
             str.Close();

             var token = await _userManager.GeneratePasswordResetTokenAsync(user);
             var callback = Url.Action("ResetPassword", "Account", new { token, email = user.Email }, Request.Scheme);

             emailText = emailText.Replace("{{Link}}", callback);

             var isEmailSent = _emailSender.SendEmail(new EmailModel(user.Email, "Your link to reset password in Time Tracking Soft", emailText, true));
             if (!isEmailSent)
                 ViewBag.ShowAlert = "Send email failed.";
             else
                 ViewBag.ShowAlert = "Password reset link has been sent to your email.";*//*
             return View();

         }

         private void IdentityResultErrors(IdentityResult result)
         {
             if (result.Errors.Count() > 0)
             {
                 foreach (var error in result.Errors)
                 {
                     ViewBag.ShowAlert += error.Description + Environment.NewLine;
                 }
             }
         }

*/
    }
}
