﻿using Microsoft.AspNetCore.Mvc;

namespace ShopStore.Web.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
