﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MJU.DataCenter.Personnel.Service.Interface;

namespace MJU.DataCenter.Personnel.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonnelGenderGenerationController : ControllerBase
    {
        private readonly IPersonnelService _personnelService;
        public PersonnelGenderGenerationController(IPersonnelService personnelService)
        {
            _personnelService = personnelService;
        }

        [HttpGet("{type}")]
        public object Get(int type)
        {
            return _personnelService.GetAllPersonGender(type);
        }

        [HttpGet("DataSource")]
        public object Get()
        {
            return _personnelService.GetAllPersonGenderDataSource();
        }

        [HttpGet("DataSourceByType/{type}/{gender}/{genderName}")]
        public object Get(int type,int gender, string genderName)
        {
            return _personnelService.GetAllPersonGenderDataSourceByType(type, gender, genderName);
        }

    }


}
