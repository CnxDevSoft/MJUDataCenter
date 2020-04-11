using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MJU.DataCenter.Personnel.Helper;
using MJU.DataCenter.Personnel.Service.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MJU.DataCenter.Personnel.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonnelPositionController : Controller
    {
        private readonly IPersonnelService _personnelService;
        public PersonnelPositionController(IPersonnelService personnelService)
        {
            _personnelService = personnelService;
        }
       
        [HttpGet("{type}/{token}/{userName}")]
        public object Get(int type, string token, string userName)
        {
            var result = AuthenticationApi.Authenticated(token, userName);
            if (result.Result.IsSuccess)
            {
                List<int> filter = new List<int>();
                if (result.Result.DepartmentRoleList.Any(x=>x.DepartmentKey != null))
                {
                    filter = result.Result.
                        DepartmentRoleList.Select(x => int.Parse(x.DepartmentKey)).ToList();
                } 
                return _personnelService.GetAllPersonnelPosition(type, filter);
            }
            return null;
        }

        [HttpGet("DataSource")]
        public object Get(string type)
        {
            return _personnelService.GetAllPersonnelPositionDataSource(type);
        }


    }
}
