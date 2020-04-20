using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

    public class PersonnelResearchDataController : Controller
    {
        private readonly IResearchAndExtensionService _researchAndExtensionService;
        public PersonnelResearchDataController(IResearchAndExtensionService researchAndExtensionService)
        {
            _researchAndExtensionService = researchAndExtensionService;
        }

        [HttpGet("{citizenId}")]
        public PersonResearchDetailModel Get(string citizenId, [FromQuery] AuthenticateModel auth)
        {
            var result = AuthenticationApi.Authenticated(auth);
            if (result.Result.IsSuccess)
            {
                return _researchAndExtensionService.GetPersonResearchDetail(citizenId);
            }
            return null;
        }

        [HttpGet("ResearchDetail/{researchId}")]
        public ResearchDetailViewModel Get(int researchId, [FromQuery] AuthenticateModel auth)
        {
            var result = AuthenticationApi.Authenticated(auth);
            if (result.Result.IsSuccess)
            {
                return _researchAndExtensionService.GetResearchDetail(researchId);
            }
            return null;
        }



    }
}