using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MJU.DataCenter.ResearchExtension.Service.Interface;

namespace MJU.DataCenter.ResearchExtension.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedDataController : ControllerBase
    {
        private readonly IFundSeedDataService _fundSeedDataService;
        private readonly IProjectSeedDataService _projectSeedDataService;
        public SeedDataController(IFundSeedDataService fundSeedDataService
            , IProjectSeedDataService projectSeedDataService)
        {
            _fundSeedDataService = fundSeedDataService;
            _projectSeedDataService = projectSeedDataService;
        }
        // GET: api/SeedData
        [HttpGet]
        public IEnumerable<string> Get()
        {
            _fundSeedDataService.AddFund();
            _projectSeedDataService.AddProJect();
            
            return new string[] { "value1", "value2" };
        }

        // GET: api/SeedData/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/SeedData
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/SeedData/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
