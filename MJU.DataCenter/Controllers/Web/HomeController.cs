﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MJU.DataCenter.Controllers.Web
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        
        {
            return View();
        }
    }
}