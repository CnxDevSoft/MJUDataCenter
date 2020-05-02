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

    public class PersonnelResearchDataController : ControllerBase
    {
        private readonly IResearchAndExtensionService _researchAndExtensionService;
        private readonly IConfiguration _configuration;
        public PersonnelResearchDataController(IResearchAndExtensionService researchAndExtensionService, IConfiguration configuration)
        {
            _researchAndExtensionService = researchAndExtensionService;
            _configuration = configuration;
        }

        [HttpGet("{citizenId}")]
        public PersonResearchDetailModel Get(string citizenId, [FromQuery] AuthenticateModel auth)
        {
            var webHost = _configuration["App:WebHost"];
            var result = AuthenticationApi.Authenticated(auth, webHost);
            if (result.Result.IsSuccess)
            {
                return _researchAndExtensionService.GetPersonResearchDetail(citizenId);
            }
            return null;
        }

        [HttpGet("ResearchDetail/{researchId}")]
        public ResearchDetailViewModel Get(int researchId, [FromQuery] AuthenticateModel auth)
        {
            var webHost = _configuration["App:WebHost"];
            var result = AuthenticationApi.Authenticated(auth, webHost);
            if (result.Result.IsSuccess)
            {
                return _researchAndExtensionService.GetResearchDetail(researchId);
            }
            return null;
        }



    }
}