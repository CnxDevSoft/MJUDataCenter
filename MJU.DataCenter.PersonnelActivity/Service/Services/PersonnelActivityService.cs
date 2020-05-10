using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Versioning;
using MJU.DataCenter.PersonnelActivity.Repository.Interface;
using MJU.DataCenter.PersonnelActivity.Service.Interface;
using MJU.DataCenter.PersonnelActivity.ViewModels;
using MJU.DataCenter.PersonnelActivity.ViewModels.dtos;

namespace MJU.DataCenter.ResearchExtension.Service.Services
{
    public class PersonnelActivityService : IPersonnelActivityService
    {
        private readonly IDcActivityRepository _dcActivityRepository;
        private readonly IDcPersonnelActivityRepository _dcPersonnelActivityRepository;

        public PersonnelActivityService(IDcActivityRepository dcActivityRepository
            , IDcPersonnelActivityRepository dcPersonnelActivityRepository)
        {
            _dcActivityRepository = dcActivityRepository;
            _dcPersonnelActivityRepository = dcPersonnelActivityRepository;


        }
        public object GetPersonnelActivity(int type)
        {
            var personActivity = _dcPersonnelActivityRepository.GetAll();

            return personActivity;
        }

        public List<PersonnelViewModel> GetPersonnelActivityByName(PersonnelInputDto input)
        {
            var personActivity = _dcPersonnelActivityRepository.GetAll()
              .Where(m => !string.IsNullOrEmpty(input.FirstName) ? m.PersonnelName.ToLower().Contains(input.FirstName.ToLower()) : true)
                .Where(m => !string.IsNullOrEmpty(input.LastName) ? m.PersonnelName.ToLower().Contains(input.LastName.ToLower()) : true)
                .Where(m => !string.IsNullOrEmpty(input.FacultyName) ? m.FacultyName.ToLower().Contains(input.FacultyName.ToLower()) : true)
                .Select(s => new PersonnelViewModel
                { 
                    PersonnelId = s.PersonnelId,
                    PersonnelName = s.PersonnelName,
                    FacultyName = s.FacultyName,
                    FacultyId = s.FacultyId,
                    CitizenId = s.CitizenId
                }).Distinct().ToList();

            return personActivity;
        }

        public object GetPersonnelActivityByCitizenId(string citizenId)
        {                                                                                                   
            var personActivity = _dcPersonnelActivityRepository.GetAll().Where(m => m.CitizenId == citizenId).ToList();
        }                                                                                                                            s


    }
}
