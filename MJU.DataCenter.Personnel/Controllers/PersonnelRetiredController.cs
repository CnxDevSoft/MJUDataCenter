using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MJU.DataCenter.Personnel.Service.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MJU.DataCenter.Personnel.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonnelRetiredController : Controller
    {
        private readonly IPersonnelService _personnelService;
        public PersonnelRetiredController(IPersonnelService personnelService)
        {
            _personnelService = personnelService;
        }
      
        [HttpGet("{type}/{total}")]
        public object Get(int type,int total)
        {
            return _personnelService.GetAllPersonnelRetired(total,type);
        }

        [HttpGet("GetDataTablePersonRetired/{type}/{year}")]
        public object GetDataTablePersonRetired(int type, string year)
        {
            return _personnelService.GetDataTablePersonRetired(year,type);
        }

    }
}
