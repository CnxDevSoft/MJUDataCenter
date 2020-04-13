using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MJU.DataCenter.Core.Enums;
using MJU.DataCenter.Core.HelperEnum;
using MJU.DataCenter.Personnel.Service.Interface;

namespace MJU.DataCenter.Personnel.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class SeedDataController : ControllerBase
    {
        private readonly ISeedDataPersonService _seedDataPersonService;
        public SeedDataController(ISeedDataPersonService seedDataPersonService)
        {
            _seedDataPersonService = seedDataPersonService;
        }
        // GET: api/SeedData
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var test = EnumHelper.GetDescriptionFromEnumValue(Faculty.Office.Office);
            //_seedDataPersonService.AddPerson();
            return new string[] { "value1", "value2" };
        }

    }
}
