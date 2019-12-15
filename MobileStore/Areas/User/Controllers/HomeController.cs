﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MobileStore.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            ClaimsPrincipal user = this.User;
            if (user.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Product", new { area = "Admin" });
            }
            return View();
        }
    }
}