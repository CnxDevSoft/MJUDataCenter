using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MJU.DataCenter.Personnel.Helper;
using MJU.DataCenter.Personnel.Service.Interface;
using MJU.DataCenter.Personnel.ViewModels.dtos;

namespace MJU.DataCenter.Personnel.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonnelGenderGenerationController : ControllerBase
    {
        private readonly IPersonnelService _personnelService;
        public PersonnelGenderGenerationController(IPersonnelService personnelService)
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
                return _personnelService.GetAllPersonnelGender(type, filter);
            }
            return null;
        }

        [HttpGet("DataSource")]
        public object Get([FromQuery] AuthenticateModel auth)
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
                return _personnelService.GetAllPersonnelGenderDataSource(filter);
            }
            return null;
        }

        [HttpGet("DataSourceByType/{type}/{gender}/{genderName}")]
        public object Get(int type, int gender, string genderName, [FromQuery] AuthenticateModel auth)
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
                return _personnelService.GetAllPersonnelGenderDataSourceByType(type, gender, genderName, filter);
            }
            return null;

        }

    }


}
