using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MJU.DataCenter.Core.Models;
using MJU.DataCenter.Personnel.Helper;
using MJU.DataCenter.Personnel.Service.Interface;
using MJU.DataCenter.Personnel.ViewModels.dtos;

namespace MJU.DataCenter.Personnel.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonnelDashboardController : ControllerBase
    {

        private readonly IPersonnelService _personnelService;
        private readonly IConfiguration _configuration;

        public PersonnelDashboardController(IPersonnelService personnelService, IConfiguration configuration)
        {
            _personnelService = personnelService;
            _configuration = configuration;

        }
        private string WebHost => _configuration["App:WebHost"];

        // GET: api/PersonnelDashboard
        [HttpGet("PersonnelCount")]
        public object Get()
        {
            
                return _personnelService.GetPersonnelDashboard();
        }

    }
}
