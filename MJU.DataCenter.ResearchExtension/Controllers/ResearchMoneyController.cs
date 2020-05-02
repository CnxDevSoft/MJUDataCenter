using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MJU.DataCenter.Core.Models;
using MJU.DataCenter.ResearchExtension.Helper;
using MJU.DataCenter.ResearchExtension.Service.Interface;
using MJU.DataCenter.ResearchExtension.ViewModels;

namespace MJU.DataCenter.ResearchExtension.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    [DisplayName("งานวิจัยแยกตามหน่วยงาน")]
    public class ResearchMoneyController : ControllerBase
    {
        private readonly IResearchAndExtensionService _researchAndExtensionService;
        private readonly IConfiguration _configuration;
        public ResearchMoneyController(IResearchAndExtensionService researchAndExtensionService, IConfiguration configuration)
        {
            _researchAndExtensionService = researchAndExtensionService;
            _configuration = configuration;
        }


        [HttpGet("")]
        public object Get([FromQuery]InputFilterGraphViewModel input, [FromQuery] AuthenticateModel auth)
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
                return _researchAndExtensionService.GetAllResearchMoney(input,filter);
            }
            return null;
        }

        [HttpGet("GetDataSource")]
        public List<RankResearchRageMoneyDataSourceModel> Get([FromQuery]InputFilterDataSourceViewModel input, [FromQuery] AuthenticateModel auth)
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
                return _researchAndExtensionService.GetAllResearchMoneyDataSource(input,filter);
            }
            return null;
        }

    }
}
