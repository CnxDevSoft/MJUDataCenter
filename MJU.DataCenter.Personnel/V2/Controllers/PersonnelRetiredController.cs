using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MJU.DataCenter.Personnel.Service.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MJU.DataCenter.Personnel.V2.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonnelRetiredController : Controller
    {
        private readonly IPersonnelService _personnelService;
        public PersonnelRetiredController(IPersonnelService personnelService)
        {
            _personnelService = personnelService;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{type}/{total}")]
        public object Get(int type,int total)
        {
            return _personnelService.GetAllPersonRetired(total,type);
        }

        [HttpGet("GetDataTablePersonRetired/{type}/{year}")]
        public object GetDataTablePersonRetired(int type, string year)
        {
            return _personnelService.GetDataTablePersonRetired(year,type);
        }


        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
