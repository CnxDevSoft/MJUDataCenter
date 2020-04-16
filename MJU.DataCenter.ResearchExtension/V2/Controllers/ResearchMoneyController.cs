using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MJU.DataCenter.ResearchExtension.Service.Interface;
using MJU.DataCenter.ResearchExtension.ViewModels;

namespace MJU.DataCenter.ResearchExtension.V2.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class ResearchMoneyController : Controller
    {
        private readonly IResearchAndExtensionService _researchAndExtensionService;
        public ResearchMoneyController(IResearchAndExtensionService researchAndExtensionService)
        {
            _researchAndExtensionService = researchAndExtensionService;
        }
        // GET: api/DcResearchMoney
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //[HttpGet("{type}")]
        //public object Get(int type, string filter)
        //{
        //    var input = new InputFilterGraphViewModel
        //    {
        //        Type = type,
        //    };
        //    return _researchAndExtensionService.GetAllResearchMoney(input);
        //}

        // POST: api/DcResearchMoney

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/DcResearchMoney/5
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