using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MJU.DataCenter.Web.Models;
using MJU.DataCenter.Web.Services;
using MJU.DataCenter.Web.Services.Interface;
using MJU.DataCenter.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.Web.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LoginApiController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IUserDepartmentRoleService _userDepartmentService;
        public LoginApiController(IUserDepartmentRoleService userDepartmentService,
                        SignInManager<AppUser> signInManager
            )
        {
            _userDepartmentService = userDepartmentService;
            _signInManager = signInManager;
        }
        [HttpPost]
        public async Task<IActionResult> Post(string userName)
        {
            //var userName = "";
            var password = "";

            var result = await _signInManager.PasswordSignInAsync(userName, password, false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                //_logger.LogInformation("User logged in.");
                var data = _userDepartmentService.GetAll();
                //find user role with token
                var model = new LoginApiModel
                {
                    IsSuccess = true,

                };

                // return  status,role[], department, 
                return Ok(model);
            }
            return BadRequest();
            //return _userDepartmentService.GetAll();
        }
    }
}
