using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MJU.DataCenter.Core.Models;
using MJU.DataCenter.Personnel.Helper;
using MJU.DataCenter.Personnel.Service.Interface;

namespace MJU.DataCenter.Personnel.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonnelEducationDetailController : ControllerBase
    {
         private readonly IPersonnelService _personnelService;
        public PersonnelEducationDetailController(IPersonnelService personnelService)
        {
            _personnelService = personnelService;
        }
        // GET: api/PersonnelEducationDetail
        [HttpGet("{citizenId}")]
        public object Get(string citizenId, [FromQuery]AuthenticateModel auth)
        {
            var result = AuthenticationApi.Authenticated(auth);
            if (result.Result.IsSuccess)
            {
                return _personnelService.GetPersonEducationDetailByCitizenId(citizenId);
            }
            return null;

        }

    }
}
