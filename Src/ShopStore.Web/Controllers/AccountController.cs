using Autofac;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ShopStore.DemoIdentity.Feature.Membership;
using ShopStore.Web.Models;
using ShopStore.Web.Securities.Token;
using System.Security.Policy;
using LoginModel = ShopStore.Web.Models.LoginModel;

namespace ShopStore.Web.Controllers
{
    public class AccountController : Controller
    {

        public SignInManager<User> SignInManager { get; set; }
        public UserManager<User> UserManager { get; set; }
        public ILogger<AccountController> Logger { get; set; }
        public ILifetimeScope lifetimeScope { get; set; }
        public ITokenService tokenService { get; set; }
        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager, 
            ILogger<AccountController> logger, ILifetimeScope lifetimeScope,ITokenService tokenService)
        {
            SignInManager = signInManager;
            UserManager = userManager;
            Logger = logger;
            this.lifetimeScope = lifetimeScope;
            this.tokenService = tokenService;
        }
        public IActionResult Registration()
        {
            RegistrationModel model = new RegistrationModel();


            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> RegistrationAsync(RegistrationModel model)
        {
            model.ReturnUrl ??= Url.Content("~/");
            var newUser = new User()
            {
                Name = model.Name,
                Email = model.Email,
                UserName = model.Email
            };

            var IsCreate =  await UserManager.CreateAsync(newUser, model.Password);
            if (IsCreate.Succeeded)
            {
                await SignInManager.SignInAsync(newUser, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach(var error in IsCreate.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        public IActionResult Login(string returnUrl=null)
        {
            returnUrl ??= Url.Content("~/");
            var  login = lifetimeScope.Resolve<LoginModel>();
            //clear exiting cookies
          HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            login.ReturnUrl = "/dashboard/index";
            return View(login);
        }

        [HttpPost,ValidateAntiForgeryToken]
        public async  Task< IActionResult> LoginAsync( LoginModel login)
        {
            login.ReturnUrl ??= Url.Content("~/");

            if(ModelState.IsValid)
            {
                var result = await SignInManager.PasswordSignInAsync(login.Email, login.Password, false, false);

                if (result.Succeeded)
                {
                    var user=await UserManager.FindByEmailAsync(login.Email);
                    var claims = (await UserManager.GetClaimsAsync(user)).ToArray();
                    var token= await tokenService.GetJwtToken(claims);

                    HttpContext.Session.SetString("token", token);

                    return LocalRedirect(login.ReturnUrl);
                }
                else
                {

                }
            }

            return View();
        }

        [HttpPost]
        public async Task< IActionResult>LogOutAsync(string returnUrl="/Home/Index")
        {
            await SignInManager.SignOutAsync();
          if(returnUrl!= null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
