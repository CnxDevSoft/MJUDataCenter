using System;
using System.Collections.Generic;
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
    public class ResearchDepartmentDataSourceTableController : ControllerBase
    {
        private readonly IResearchAndExtensionService _researchAndExtensionService;
        public ResearchDepartmentDataSourceTableController(IResearchAndExtensionService researchAndExtensionService)
        {
            _researchAndExtensionService = researchAndExtensionService;
        }
        // GET: api/ResearchDepartmentDataSourceTable
        [HttpGet("GetDataSourceTable")]
        public List<ResearchDepartmentDataSourceModel> Get([FromQuery]InputFilterDataSourceViewModel input, int departmentId, string departmentName)
        {
            return _researchAndExtensionService.GetResearchDepartmentDataSourceTable(input, departmentId, departmentName);
        }

        [HttpGet("GetAllDataSourceTable")]
        public List<ResearchDepartmentDataSourceModel> Get([FromQuery]InputFilterDataSourceViewModel input,int type)
        {
            return _researchAndExtensionService.GetAllResearchDepartmentDataSourceTable(input, type);
        }
    }
}
