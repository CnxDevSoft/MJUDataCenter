using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public PersonnelDashboardController(IPersonnelService personnelService)
        {
            _personnelService = personnelService;
        }
        // GET: api/PersonnelDashboard
        [HttpGet("PersonnelCount")]
        public object Get()
        {
            
                return _personnelService.GetPersonnelDashboard();
        }

    }
}
