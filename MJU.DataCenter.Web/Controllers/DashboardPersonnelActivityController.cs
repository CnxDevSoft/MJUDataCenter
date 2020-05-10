using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MJU.DataCenter.Web.Controllers
{
    public class DashboardPersonnelActivityController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            ViewData["currentPage"] = "DashboardPersonnelActivity";
            return View();
        }
    }
}