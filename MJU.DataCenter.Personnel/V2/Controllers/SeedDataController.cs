﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MJU.DataCenter.Personnel.Service.Interface;

namespace MJU.DataCenter.Personnel.V2.Controllers
{
    [ApiVersion("2.0")]
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
            _seedDataPersonService.AddPerson();
            return new string[] { "value1", "value2" };
        }

        // GET: api/SeedData/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
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
