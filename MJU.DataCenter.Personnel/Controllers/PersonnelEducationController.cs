using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MJU.DataCenter.Core.Models;
using MJU.DataCenter.Personnel.Helper;
using MJU.DataCenter.Personnel.Service.Interface;
using MJU.DataCenter.Personnel.ViewModels.dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MJU.DataCenter.Personnel.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonnelEducationController : Controller
    {
        private readonly IPersonnelService _personnelService;
        private readonly IConfiguration _configuration;

        public PersonnelEducationController(IPersonnelService personnelService, IConfiguration configuration)
        {
            _personnelService = personnelService;
            _configuration = configuration;

        }
       

        [HttpGet("{type}")]
        public object Get(int type, [FromQuery]AuthenticateModel auth)
        {
            var webHost = _configuration["App:WebHost"];
            var result = AuthenticationApi.Authenticated(auth, webHost);
            if (result.Result.IsSuccess)
            {
                List<int> filter = new List<int>();
                if (result.Result.DepartmentRoleList.Any(x => x.DepartmentKey != null))
                {
                    filter = result.Result.
                    DepartmentRoleList.Select(x => int.Parse(x.DepartmentKey)).ToList();
                }
                return _personnelService.GetAllPersonnelEducation(type, filter);
            }
            return null;
               
        }

        [HttpGet("DataSource")]
        public object Get(string type, [FromQuery] AuthenticateModel auth)
        {
            var webHost = _configuration["App:WebHost"];
            var result = AuthenticationApi.Authenticated(auth, webHost);
            if (result.Result.IsSuccess)
            {
                List<int> filter = new List<int>();
                if (result.Result.DepartmentRoleList.Any(x => x.DepartmentKey != null))
                {
                    filter = result.Result.
                    DepartmentRoleList.Select(x => int.Parse(x.DepartmentKey)).ToList();
                }
                return _personnelService.GetAllPersonnelEducationDataSource(type, filter);
            }
            return null;
        }

    }
}
