using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MJU.DataCenter.Core.Models;
using MJU.DataCenter.PersonnelActivity.Helper;
using MJU.DataCenter.PersonnelActivity.Service.Interface;
using MJU.DataCenter.PersonnelActivity.ViewModels;
using MJU.DataCenter.PersonnelActivity.ViewModels.dtos;

namespace MJU.DataCenter.PersonnelActivity.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyActivityController : ControllerBase
    {

        private readonly IPersonnelActivityService _personnelActivityService;
        private readonly IConfiguration _configuration;

        public FacultyActivityController(IPersonnelActivityService personnelActivityService, IConfiguration configuration)
        {
            _personnelActivityService = personnelActivityService;
            _configuration = configuration;

        }
        private string WebHost => _configuration["App:WebHost"];

        [HttpGet("")]
        public object Get([FromQuery]PersonnelActivityInputDto input, [FromQuery] AuthenticateModel auth)
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
                return _personnelActivityService.GetPersonnelFacultyActivity(input, filter);
            }
            return null;
        }

        [HttpGet("GetDataSource")]
        public List<PersonnelFacultyActivityDataSourceModel> Get([FromQuery]PersonnelActivityFilterInputDto input, [FromQuery] AuthenticateModel auth)
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
                return _personnelActivityService.GetPersonnelFacultyActivityDataSource(input, filter);
            }
            return null;
        }

    }
}
