using Microsoft.AspNetCore.Mvc;

namespace ShopStore.DemoIdentity.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
