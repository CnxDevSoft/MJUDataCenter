using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MJU.DataCenter.Personnel.Models;
using MJU.DataCenter.Personnel.Repository.Interface;
using MJU.DataCenter.Personnel.Repository.Repositories;
using MJU.DataCenter.Personnel.Service.Interface;
using MJU.DataCenter.Personnel.SeedData;
using MJU.DataCenter.Personnel.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MJU.DataCenter.Personnel.Controllers
{

    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private readonly IPersonnelService _personnelService;
        public PersonController(IPersonnelService personnelService) {
            _personnelService = personnelService;
        }
        // GET: api/<controller>
        [HttpGet]
        public List<int> Get()
        {
            var a = _personnelService.GetAllPersonnel();
            var b = new List<int>();
            foreach(var s in a)
            {
                b.Add(s.Person);
            }
            return b;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Task<IEnumerable<Person>> Get(int id)
        {
            return  _personnelService.GetAllPerson();
        }      
        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
            _personnelService.AddPerson();
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
