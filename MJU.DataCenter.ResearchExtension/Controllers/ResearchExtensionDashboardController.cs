﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MJU.DataCenter.Core.Models;
using MJU.DataCenter.ResearchExtension.Helper;
using MJU.DataCenter.ResearchExtension.Service.Interface;
using MJU.DataCenter.ResearchExtension.ViewModels;

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
