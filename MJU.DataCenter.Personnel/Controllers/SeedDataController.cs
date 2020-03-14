using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MJU.DataCenter.Personnel.Models;
using MJU.DataCenter.Personnel.Service.Interface;

namespace MJU.DataCenter.Personnel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedDataController : ControllerBase
    {

        private readonly IPersonnelService _personnelService;
        public SeedDataController(IPersonnelService personnelService)
        {
            _personnelService = personnelService;
        }
        // GET: api/SeedData
        [HttpGet]
        public IEnumerable<string> Get()
        {

            return new string[] { "value1", "value2" };
        }

        // GET: api/SeedData/5
        [HttpGet("{id}", Name = "Get")]
        public Task<IEnumerable<Person>> Get(int id)
        {
            //_personnelService.AddPerson();
            return _personnelService.GetPersonTest(id);
        }

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
