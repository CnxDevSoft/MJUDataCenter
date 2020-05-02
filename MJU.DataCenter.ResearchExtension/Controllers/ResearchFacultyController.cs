﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MJU.DataCenter.Core.Models;
using MJU.DataCenter.ResearchExtension.Helper;
using MJU.DataCenter.ResearchExtension.Service.Interface;
using MJU.DataCenter.ResearchExtension.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MJU.DataCenter.ResearchExtension.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class ResearchFacultyController : ControllerBase
    {
        private readonly IResearchAndExtensionService _researchAndExtensionService;
        private readonly IConfiguration _configuration;
        public ResearchFacultyController(IResearchAndExtensionService researchAndExtensionService, IConfiguration configuration)
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
                return _researchAndExtensionService.GetResearchFaculty(input,filter);
            }
            return null;
        }

        [HttpGet("GetDataSource")]
        public List<ResearchFacultyDataSourceModel> Get([FromQuery]InputFilterDataSourceViewModel input, [FromQuery] AuthenticateModel auth)
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
                return _researchAndExtensionService.GetResearchFacultyDataSource(input,filter);
            }
            return null;
        }

    }
}
