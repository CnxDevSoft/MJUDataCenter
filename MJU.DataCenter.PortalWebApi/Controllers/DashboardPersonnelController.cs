using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace MJU.DataCenter.PortalWebApi.Controllers
{
    [Authorize]
    //[Route("DashboardPerson")]
    public class DashboardPersonnelController : Controller
    {
        public async Task<IActionResult> Index()
        {
            ViewData["currentPage"] = "DashboardPerson";
            return View();
        }
    }
}