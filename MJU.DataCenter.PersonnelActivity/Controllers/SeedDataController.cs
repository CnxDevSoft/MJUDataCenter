using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MJU.DataCenter.PersonnelActivity.Service.Interface;

namespace MJU.DataCenter.PersonnelActivity.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class SeedDataController : ControllerBase
    {
        private readonly ISeedPersonnelActivityService _seedPersonnelActivityService;
        public SeedDataController(ISeedPersonnelActivityService seedPersonnelActivityService)
        {
            _seedPersonnelActivityService = seedPersonnelActivityService;
        }
        // GET: api/SeedData

        [HttpGet]
        public IEnumerable<string> Get()
        {
            _seedPersonnelActivityService.GeneratePersonActivity();
            _seedPersonnelActivityService.GeneratePersonActivity1();
            _seedPersonnelActivityService.GenerateActivity();
            //_seedDataPersonService.AddPerson();
            return new string[] { "value1", "value2" };
        }

    }
}
