﻿using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Blog");
        }
    }
}
