using MJU.DataCenter.PersonnelActivity.Models;
using MJU.DataCenter.PersonnelActivity.Repository.Interface;
using MJU.DataCenter.PersonnelActivity.Service.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MJU.DataCenter.PersonnelActivity.Service.Services
{
    public class SeedPersonnelActivityService : ISeedPersonnelActivityService
    {
        private readonly IDcActivityRepository _dcActivityRepository;
        private readonly IDcPersonnelActivityRepository _dcPersonnelActivityRepository;
        private readonly IPersonnelActivityRepository _personnelActivityRepository;
        private readonly IActivityRepository _activityRepository;

        public SeedPersonnelActivityService(IDcActivityRepository dcActivityRepository
           , IDcPersonnelActivityRepository dcPersonnelActivityRepository
            , IPersonnelActivityRepository personnelActivityRepository,
            IActivityRepository activityRepository)
        {
            _dcActivityRepository = dcActivityRepository;
            _dcPersonnelActivityRepository = dcPersonnelActivityRepository;
            _personnelActivityRepository = personnelActivityRepository;
            _activityRepository = activityRepository;
        }

        public void GeneratePersonActivity()
        {
            var list = new List<Models.PersonnelActivity>();
            for (var i = 0; i < 300; i++)
            {
                Random random = new Random();
                var randomTypeA = random.Next(0,2);
                var randomTypeb = random.Next(1, 7);
                var idcrd = "1234567890000";
                var fact = SeedData.SeedData.Fact(i);
            var aStringBuilder = new StringBuilder(idcrd);
            aStringBuilder.Remove(13 - i.ToString().Length, i.ToString().Length);
            aStringBuilder.Insert(13 - i.ToString().Length, i.ToString());

                var result = new Models.PersonnelActivity
                {
                    CitizenId = aStringBuilder.ToString(),
                    PersonnelId = i,
                    PersonnelName = string.Format("FirstName LastName {0}",i),
                    PersonnelStatus = randomTypeA == 1?true:false,
                    HourQty = randomTypeA == 0?0:randomTypeb,
                    FacultyId = fact.FactId,
                    FacultyName = fact.FactName,
                    PersonnelActivity1 = fact.PersonnelActivityId.GetValueOrDefault()
                };
                list.Add(result);

            }
            _personnelActivityRepository.AddRange(list);
        }

        public void GeneratePersonActivity1()
        {
            var list = new List<Models.PersonnelActivity>();
            for (var i = 0; i < 300; i++)
            {
                Random random = new Random();
                var randomTypeA = random.Next(0, 2);
                var randomTypeb = random.Next(1, 7);
                var idcrd = "1234567890000";
                var fact = SeedData.SeedData.Fact1(i);
                var aStringBuilder = new StringBuilder(idcrd);
                aStringBuilder.Remove(13 - i.ToString().Length, i.ToString().Length);
                aStringBuilder.Insert(13 - i.ToString().Length, i.ToString());

                var result = new Models.PersonnelActivity
                {
                    CitizenId = aStringBuilder.ToString(),
                    PersonnelId = i,
                    PersonnelName = string.Format("FirstName LastName {0}", i),
                    PersonnelStatus = randomTypeA == 1 ? true : false,
                    HourQty = randomTypeA == 0 ? 0 : randomTypeb,
                    FacultyId = fact.FactId,
                    FacultyName = fact.FactName,
                    PersonnelActivity1 = fact.PersonnelActivityId.GetValueOrDefault()
                };
                list.Add(result);

            }
            _personnelActivityRepository.AddRange(list);
        }

        public void GenerateActivity()
        {
            
            var list = new List<Activity>();
            for (var i = 1; i < 10; i++)
            {
                var activity = SeedData.SeedData.randomActivity(i);
                var model = new Activity
                {
                    ActivityEn = string.Format("Activity {0}",i),
                    ActivityTh = string.Format("กิจกรรม {0}", i),
                    ActivityTypeId = activity.ActivityTypeId,
                    ActivityTypeName = activity.ActivityTypeName,
                    StartDate = activity.StartDate,
                    EndDate = activity.EndDate,
                    FacultyId = activity.FacultyId,
                    FacultyName = activity.FacultyName,
                    IsAllDay = activity.IsAllDay,
                    Location = activity.Location,
                    WorkLoadQty = activity.WorkLoadQty
                    
                };
                list.Add(model);
            }
            _activityRepository.AddRange(list);
        }
    }
}
