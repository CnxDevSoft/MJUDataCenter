using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MJU.DataCenter.ResearchExtension.Service.Interface;
using MJU.DataCenter.ResearchExtension.ViewModels;

namespace MJU.DataCenter.ResearchExtension.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class ResearchMoneyRangeDataSourceTableController : ControllerBase
    {
        // GET: api/ResearchMoneyRangeDataSourceTable
        private readonly IResearchAndExtensionService _researchAndExtensionService;
        public ResearchMoneyRangeDataSourceTableController(IResearchAndExtensionService researchAndExtensionService)
        {
            _researchAndExtensionService = researchAndExtensionService;
        }

        [HttpGet("GetDataSourceTable")]
        public List<RankResearchRageMoneyDataSourceModel> Get([FromQuery]InputFilterDataSourceViewModel input,string type)
        {
            return _researchAndExtensionService.GetResearchMoneyDataSourceTable(input, type);
        }

    }
}
