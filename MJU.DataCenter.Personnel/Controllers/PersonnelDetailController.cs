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
    public class PersonnelDetailController : Controller
    {
        private readonly IPersonnelService _personnelService;
        public PersonnelDetailController(IPersonnelService personnelService)
        {
            _personnelService = personnelService;
        }

        [HttpGet("{citizenId}")]
        public object Get(string citizenId, [FromQuery]AuthenticateModel auth)
        {
            var result = AuthenticationApi.Authenticated(auth);
            if (result.Result.IsSuccess)
            {
                return _personnelService.GetPersonDetailByCitizenId(citizenId);
            }
            return null;
               
        }


    }
}
