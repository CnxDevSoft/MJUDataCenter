using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
    public class PersonnelPositionGenerationController : Controller
    {
        private readonly IPersonnelService _personnelService;
        public PersonnelPositionGenerationController(IPersonnelService personnelService)
        {
            _personnelService = personnelService;
        }

        [HttpGet("{type}")]
        public object Get(int type, [FromQuery] AuthenticateModel auth)
        {
            var result = AuthenticationApi.Authenticated(auth);
            if (result.Result.IsSuccess)
            {
                List<int> filter = new List<int>();
                if (result.Result.DepartmentRoleList.Any(x => x.DepartmentKey != null))
                {
                    filter = result.Result.
                    DepartmentRoleList.Select(x => int.Parse(x.DepartmentKey)).ToList();
                }
                return _personnelService.GetAllPersonnelPositionGeneration(type, filter);
            }
            return null;
        }

        [HttpGet("DataSource")]
        public object Get(string positionType,int? index,[FromQuery] AuthenticateModel auth)
        {
            var result = AuthenticationApi.Authenticated(auth);
            if (result.Result.IsSuccess)
            {
                List<int> filter = new List<int>();
                if (result.Result.DepartmentRoleList.Any(x => x.DepartmentKey != null))
                {
                    filter = result.Result.
                    DepartmentRoleList.Select(x => int.Parse(x.DepartmentKey)).ToList();
                }
                return _personnelService.GetAllPersonnelPositionGenerationDataSource(positionType,index,filter);
            }
            return null;
        }

    }
}
