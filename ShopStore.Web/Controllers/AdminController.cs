using Microsoft.AspNetCore.Mvc;

namespace ShopStoreWithIdentity.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
