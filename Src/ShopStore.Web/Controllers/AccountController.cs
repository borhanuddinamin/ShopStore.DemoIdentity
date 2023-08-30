using Microsoft.AspNetCore.Mvc;

namespace ShopStore.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult LogOut()
        {
            return View();
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
