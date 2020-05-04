using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MJU.DataCenter.PortalWebApi.Models;
using MJU.DataCenter.PortalWebApi.Services.Interface;
using MJU.DataCenter.PortalWebApi.ViewModels;

namespace MJU.DataCenter.PortalWebApi.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUserDepartmentRoleService _userDepartmentService;
        public HomeController(IUserDepartmentRoleService userDepartmentService
         )
        {
            _userDepartmentService = userDepartmentService;
        }
        public IActionResult Index()
        {
            var model = new HomeViewModel();

            if (User.IsInRole("SuperAdmin"))
            {
                var departmentRoles = _userDepartmentService.GetAllDepartmentRole();
                model.DepartmentRoles = departmentRoles;             
            }
            else
            {
                if (User.FindFirst("UserId") != null) 
                {
                    var id = User.FindFirst("UserId").Value;
                    var currentDepartmentRoles = _userDepartmentService.GetById(int.Parse(id));
                    model.DepartmentRoles = currentDepartmentRoles.Select(x => x.DepartmentRole).ToList();
                }
            }
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}