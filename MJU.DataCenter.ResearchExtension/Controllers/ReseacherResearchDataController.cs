using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MJU.DataCenter.Core.Models;
using MJU.DataCenter.ResearchExtension.Helper;
using MJU.DataCenter.ResearchExtension.Models;
using MJU.DataCenter.ResearchExtension.Service.Interface;
using MJU.DataCenter.ResearchExtension.ViewModels;

namespace MJU.DataCenter.ResearchExtension.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]

    public class ResearcherResearchDataController : Controller
    {
        private readonly IResearchAndExtensionService _researchAndExtensionService;
        private readonly IConfiguration _configuration;
        public ResearcherResearchDataController(IResearchAndExtensionService researchAndExtensionService, IConfiguration configuration)
        {
            _researchAndExtensionService = researchAndExtensionService;
            _configuration = configuration;
        }

        [HttpGet("")]
        public List<ResearcherResearchDataModel> Get([FromQuery]ResearcherInputDto input, [FromQuery] AuthenticateModel auth)
        {
            var webHost = _configuration["App:WebHost"];
            var result = AuthenticationApi.Authenticated(auth, webHost);
            if (result.Result.IsSuccess)
            {
                List<int> filter = new List<int>();
                if (result.Result.DepartmentRoleList.Any(x => x.DepartmentKey != null))
                {
                    filter = result.Result.
                    DepartmentRoleList.Select(x => int.Parse(x.DepartmentKey)).ToList();
                }
                return _researchAndExtensionService.GetDcResearcherByName(input,filter);
            }
            return null;
        }
        [HttpGet("/Detail/{researcherId}")]
        public ResearcherDetailModel Get(int researcherId, [FromQuery] AuthenticateModel auth)
        {
            var webHost = _configuration["App:WebHost"];
            var result = AuthenticationApi.Authenticated(auth, webHost);
            if (result.Result.IsSuccess)
            {
               
                return _researchAndExtensionService.GetResearcherDetail(researcherId);
            }
            return null;
        }
    }
}