using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Versioning;
using MJU.DataCenter.PersonnelActivity.Repository.Interface;
using MJU.DataCenter.PersonnelActivity.Service.Interface;

namespace MJU.DataCenter.ResearchExtension.Service.Services
{
    public class PersonnelActivityService : IPersonnelActivityService
    {
        private readonly IDcActivityRepository _dcActivityRepository;
        private readonly IDcPersonnelActivityRepository _dcPersonnelActivityRepository;

        public PersonnelActivityService(IDcActivityRepository dcActivityRepository
            , IDcPersonnelActivityRepository dcPersonnelActivityRepository
)
        {
            _dcActivityRepository = dcActivityRepository;
            _dcPersonnelActivityRepository = dcPersonnelActivityRepository;


        }

      
    }
}
