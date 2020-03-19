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
        private readonly INewSeedDataService _newSeedDataService;
        public SeedDataController(IFundSeedDataService fundSeedDataService
            , IProjectSeedDataService projectSeedDataService
            , INewSeedDataService newSeedDataService)
        {
            _fundSeedDataService = fundSeedDataService;
            _projectSeedDataService = projectSeedDataService;
            _newSeedDataService =newSeedDataService;
        }
        // GET: api/SeedData
        [HttpGet]
        public IEnumerable<string> Get()
        {
            _newSeedDataService.ResearchDataAdd();
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
