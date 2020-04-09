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
    [Route("api/[controller]")]
    [ApiController]
    public class ResearchMoneyTypeDataSourceTableController : ControllerBase
    {
        // GET: api/ResearchMoneyTypeDataSourceTable
        private readonly IResearchAndExtensionService _researchAndExtensionService;
        public ResearchMoneyTypeDataSourceTableController(IResearchAndExtensionService researchAndExtensionService)
        {
            _researchAndExtensionService = researchAndExtensionService;
        }

        [HttpGet("GetDataSourceTable")]
        public List<ResearchDataDataSourceModel> Get([FromQuery]InputFilterDataSourceViewModel input,int? researchMoneyTypeId,string moneyTypeName)
        {
            return _researchAndExtensionService.GetResearchMoneyTypeDataSourceTable(input, researchMoneyTypeId, moneyTypeName);
        }
    }
}
