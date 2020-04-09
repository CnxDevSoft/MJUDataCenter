using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MJU.DataCenter.ResearchExtension.Service.Interface;
using MJU.DataCenter.ResearchExtension.ViewModels;

namespace MJU.DataCenter.ResearchExtension.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class ResearchGroupDataSourceTableController : ControllerBase
    {
        // GET: api/ResearchGroupDataSourceTable
        private readonly IResearchAndExtensionService _researchAndExtensionService;
        public ResearchGroupDataSourceTableController(IResearchAndExtensionService researchAndExtensionService)
        {
            _researchAndExtensionService = researchAndExtensionService;
        }

        [HttpGet("GetDataSourceTable")]
        public List<ResearchGroupDataSourceModel> Get([FromQuery]InputFilterDataSourceViewModel input,int? researchGroup,string researchGroupName)
        {
            return _researchAndExtensionService.GetResearchGroupDataSourceTable(input, researchGroup, researchGroupName);
        }
    }
}
