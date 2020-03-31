using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MJU.DataCenter.ResearchExtension.Models;
using MJU.DataCenter.ResearchExtension.Service.Interface;
using MJU.DataCenter.ResearchExtension.ViewModels;

namespace MJU.DataCenter.ResearchExtension.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]

    public class ResecherResearchDataController : Controller
    {
        private readonly IResearchAndExtensionService _researchAndExtensionService;
        public ResecherResearchDataController(IResearchAndExtensionService researchAndExtensionService)
        {
            _researchAndExtensionService = researchAndExtensionService;
        }

        [HttpGet("")]
        public List<ResearcherResearchDataModel> Get([FromQuery]ResearcherInputDto input)
        {
            return _researchAndExtensionService.GetDcResearcherByName(input);
        }
        [HttpGet("/Detail/{researcherId}")]
        public ResearcherDetailModel Get(int researcherId)
        {
            return _researchAndExtensionService.GetResearcherDetail(researcherId);
        }
    }
}