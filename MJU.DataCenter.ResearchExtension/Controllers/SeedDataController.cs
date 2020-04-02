using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MJU.DataCenter.ResearchExtension.Service.Interface;

namespace MJU.DataCenter.ResearchExtension.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class SeedDataController : ControllerBase
    {
        private readonly INewSeedDataService _newSeedDataService;
        public SeedDataController(INewSeedDataService newSeedDataService)
        {
            _newSeedDataService =newSeedDataService;
        }
        // GET: api/SeedData
        [HttpGet]

        public IEnumerable<string> Get()
        {
            _newSeedDataService.GenerateSeed();
            return new string[] { "value1", "value2" };
        }

        // GET: api/SeedData/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //   // _newSeedDataService.GenerateSeed();
        //    return "value";
        //}

        // POST: api/SeedData
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/SeedData/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
