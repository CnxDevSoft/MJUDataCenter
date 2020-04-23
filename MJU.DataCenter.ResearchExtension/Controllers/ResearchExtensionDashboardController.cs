using System;
using System.Collections.Generic;
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
    public class ResearchExtensionDashboardController : ControllerBase
    {
        private readonly IResearchAndExtensionService _researchAndExtensionService;
        public ResearchExtensionDashboardController(IResearchAndExtensionService researchAndExtensionService)
        {
            _researchAndExtensionService = researchAndExtensionService;
        }
        // GET: api/ResearchExtensionDashboard
        [HttpGet("ResearchExtensionCount")]
        public object Get()
        {

            return _researchAndExtensionService.GetResearchDashboard();
        }


    }
}
