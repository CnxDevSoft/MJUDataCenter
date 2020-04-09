﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MJU.DataCenter.Personnel.Service.Interface;
using MJU.DataCenter.Personnel.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MJU.DataCenter.Personnel.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonnelPositionEducationController : Controller
    {
        private readonly IPersonnelService _personnelService;
        public PersonnelPositionEducationController(IPersonnelService personnelService)
        {
            _personnelService = personnelService;
        }
       
        [HttpGet("{type}")]
        public object Get(int type)
        {
            return _personnelService.GetAllPersonnelPositionEducation(type);
        }

        [HttpGet("DataSource")]
        public List<PersonPostionEducationDataSourceModel> Get()
        {
            return _personnelService.GetAllPersonnelPositionEducationDataSource();
        }


    }
}