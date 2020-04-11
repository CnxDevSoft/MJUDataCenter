using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MJU.DataCenter.Personnel.Service.Interface;
using MJU.DataCenter.Personnel.ViewModels.dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MJU.DataCenter.Personnel.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonnelGroupRetiredYearController : Controller
    {
        private readonly IPersonnelService _personnelService;
        public PersonnelGroupRetiredYearController(IPersonnelService personnelService)
        {
            _personnelService = personnelService;
        }

        [HttpGet("")]
        public object Get([FromQuery]RetiredGraphInputDto input)
        {
            return _personnelService.GetAllPersonnelGroupRetiredYear(input);
        }

        [HttpGet("DataSource")]
        public object Get([FromQuery]RetiredInputDto input)
        {
            return _personnelService.GetAllPersonnelGroupRetiredYearDataSource(input);
        }


    }
}
