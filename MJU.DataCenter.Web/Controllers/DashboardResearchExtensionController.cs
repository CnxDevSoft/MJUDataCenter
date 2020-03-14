using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MJU.DataCenter.Web.Controllers
{
    [Authorize]
   // [Route("DashboardResearchExtension")]
    public class DashboardResearchExtensionController : Controller
    {
        public IActionResult Index()
        {
            ViewData["currentPage"] = "DashboardResearchExtension";
            return View();
        }
    }
}