using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _configuration;

        public PersonnelEducationDetailController(IPersonnelService personnelService, IConfiguration configuration)
        {
            _personnelService = personnelService;
            _configuration = configuration;

        }
        private string WebHost => _configuration["App:WebHost"];

        // GET: api/PersonnelEducationDetail
        [HttpGet("{citizenId}")]
        public object Get(string citizenId, [FromQuery]AuthenticateModel auth)
        {
            var result = AuthenticationApi.Authenticated(auth, WebHost);
            if (result.Result.IsSuccess)
            {
                return _personnelService.GetPersonEducationDetailByCitizenId(citizenId);
            }
            return null;

        }

    }
}
