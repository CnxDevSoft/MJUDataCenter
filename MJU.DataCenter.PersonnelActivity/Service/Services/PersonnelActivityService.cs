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
using MJU.DataCenter.Core.Helpers;

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


        public object GetFacultyActivity(PersonnelActivityInputDto input, List<int> filter)
        {
            var startDate = input.StartDate.ToUtcDateTime();
            var endDate = input.EndDate.ToUtcDateTime();
            var activity = _dcActivityRepository.GetAll().Where(m => input.StartDate != null && input.EndDate != null ? (m.StartDate >= startDate && m.EndDate <= endDate) ||
              (m.StartDate >= startDate && m.StartDate <= endDate) : true);
            if (filter.Any())
            {
                activity = activity.Where(x => filter.Contains(x.FacultyId.GetValueOrDefault()));
            }
            activity = activity.OrderBy(o => o.FacultyId);


            var activityDistinct = activity.Select(s => new { s.FacultyId, s.FacultyName }).Distinct();
            if (input.Type == 1)
            {
                var label = new List<string>();
                var data = new List<int>();
                var value = new List<int?>();
                var index = 0;
                foreach (var pa in activityDistinct)
                {
                    label.Add(pa.FacultyName);
                    data.Add(activity.Where(m => m.FacultyName == pa.FacultyName && m.FacultyId == pa.FacultyId).Count());
                    index++;
                }
                var graphDataSet = new GraphDataSet
                {
                    Data = data,
                };
                var result = new GraphData
                {
                    GraphDataSet = new List<GraphDataSet> {
                     graphDataSet
                    },
                    Label = label
                };
                return result;
            }
            else
            {
                var list = new List<FacultyActivityDataTableModel>();
                foreach (var pa in activityDistinct)
                {
                    var personFacultyActivity = new FacultyActivityDataTableModel
                    {
                        FacultyName = pa.FacultyName,
                        FacultyId = pa.FacultyId,
                        Activity = activity.Where(m => m.FacultyName == pa.FacultyName && m.FacultyId == pa.FacultyId).Count()
                    };
                    list.Add(personFacultyActivity);
                }

                return list;

            }

        }

        public List<FacultyActivityDataSourceModel> GetFacultyActivityDataSource(PersonnelActivityFilterInputDto input, List<int> filter)
        {
            var startDate = input.StartDate.ToUtcDateTime();
            var endDate = input.EndDate.ToUtcDateTime();
            var activity = _dcActivityRepository.GetAll().Where(m => input.StartDate != null && input.EndDate != null ? (m.StartDate >= startDate && m.EndDate <= endDate) ||
              (m.StartDate >= startDate && m.StartDate <= endDate) : true)
                .Where(m => !string.IsNullOrEmpty(input.Type) ? m.FacultyName == input.Type : true);
            if (filter.Any())
            {
                activity = activity.Where(x => filter.Contains(x.FacultyId.GetValueOrDefault()));
            }
            activity = activity.OrderBy(o => o.FacultyId);

            var activityDistinct = activity.Select(s => new { s.FacultyId, s.FacultyName }).Distinct();

            var list = new List<FacultyActivityDataSourceModel>();
            foreach (var pa in activityDistinct)
            {
                var facultyActivity = new FacultyActivityDataSourceModel
                {
                    FacultyName = pa.FacultyName,
                    FacultyId = pa.FacultyId,
                    Activity = activity.Where(m => m.FacultyName == pa.FacultyName && m.FacultyId == pa.FacultyId).Select(
                        s=> new FacultyActivityViewModel {
                            ActivityId = s.ActivityId,
                            ActivityEn = s.ActivityEn,
                            ActivityTh = s.ActivityTh,
                            StartDate = s.StartDate,
                            EndDate = s.EndDate,
                            IsAllDay = s.IsAllDay,
                            WorkLoadQty = s.WorkLoadQty,
                            Location = s.Location,
                            ActivityFacultyId = s.FacultyId,
                            ActivityFacultyName = s.FacultyName,
                            ActivityTypeId = s.ActivityTypeId,
                            ActivityTypeName = s.ActivityTypeName
                        }).ToList()
                };
                list.Add(facultyActivity);
            }
            return list;

        }

        public object GetPersonnelFacultyActivity(PersonnelActivityInputDto input, List<int> filter)
        {
            var startDate = input.StartDate.ToUtcDateTime();
            var endDate = input.EndDate.ToUtcDateTime();
            var activity = _dcActivityRepository.GetAll().Where(m => input.StartDate != null && input.EndDate != null ? (m.StartDate >= startDate && m.EndDate <= endDate) ||
              (m.StartDate >= startDate && m.StartDate <= endDate) : true);
            if (filter.Any())
            {
                activity = activity.Where(x => filter.Contains(x.FacultyId.GetValueOrDefault()));
            }
            activity = activity.OrderBy(o => o.FacultyId);

           
            var personActivity = _dcPersonnelActivityRepository.GetAll();

            var personActiviyFilter = from o in personActivity
                                      join s1 in activity on o.ActivityId equals s1.ActivityId
                                      select new PersonnelActivityViewModel()
                                      {
                                         PersonnelActivityId = o.PersonnelActivityId,
                                         PersonnelId = o.PersonnelId,
                                         ActivityId = o.ActivityId,
                                         ActivityEn = s1.ActivityEn,
                                         ActivityTh = s1.ActivityTh,
                                         StartDate = s1.StartDate,
                                         EndDate = s1.EndDate,
                                         IsAllDay = s1.IsAllDay,
                                         WorkLoadQty = s1.WorkLoadQty,
                                         Location = s1.Location,
                                         ActivityFacultyId = s1.FacultyId,
                                         ActivityFacultyName = s1.FacultyName,
                                         ActivityTypeId = s1.ActivityTypeId,
                                         ActivityTypeName = s1.ActivityTypeName,
                                         CitizenId = o.CitizenId,
                                         PersonnelName = o.PersonnelName,
                                         HourQty = o.HourQty,
                                         FacultyId = o.FacultyId,
                                         FacultyName = o.FacultyName,
                                         PersonnelStatus = o.PersonnelStatus
                                      };

            var personActivityDistinct = personActiviyFilter.Select(s => new { s.ActivityFacultyId, s.ActivityFacultyName }).Distinct();
            if(input.Type == 1)
            {
                var label = new List<string>();
                var data = new List<int>();
                var value = new List<int?>();
                var index = 0;
                foreach (var pa in personActivityDistinct)
                {
                    label.Add(pa.ActivityFacultyName);
                    data.Add(personActiviyFilter.Where(m => m.ActivityFacultyName == pa.ActivityFacultyName && m.ActivityFacultyId == pa.ActivityFacultyId).Count());
                    index++;
                }
                var graphDataSet = new GraphDataSet
                {
                    Data = data,
                };
                var result = new GraphData
                {
                    GraphDataSet = new List<GraphDataSet> {
                     graphDataSet
                    },
                    Label = label
                };
                return result;
            }
            else
            {
                var list = new List<PersonnelFacultyActivityDataTableModel>();
                foreach (var pa in personActivityDistinct)
                {
                    var personFacultyActivity = new PersonnelFacultyActivityDataTableModel
                    {
                        FacultyName = pa.ActivityFacultyName,
                        FacultyId = pa.ActivityFacultyId,
                        Person = personActiviyFilter.Where(m => m.ActivityFacultyName == pa.ActivityFacultyName && m.ActivityFacultyId == pa.ActivityFacultyId).Count()
                    };
                    list.Add(personFacultyActivity);
                }

                return list;

            }

        }

        public List<PersonnelFacultyActivityDataSourceModel> GetPersonnelFacultyActivityDataSource(PersonnelActivityFilterInputDto input, List<int> filter)
        {
            var startDate = input.StartDate.ToUtcDateTime();
            var endDate = input.EndDate.ToUtcDateTime();
            var activity = _dcActivityRepository.GetAll().Where(m => input.StartDate != null && input.EndDate != null ? (m.StartDate >= startDate && m.EndDate <= endDate) ||
              (m.StartDate >= startDate && m.StartDate <= endDate) : true)
                .Where(m=> !string.IsNullOrEmpty(input.Type) ? m.FacultyName == input.Type: true);
            if (filter.Any())
            {
                activity = activity.Where(x => filter.Contains(x.FacultyId.GetValueOrDefault()));
            }
            activity = activity.OrderBy(o => o.FacultyId);
            var personActivity = _dcPersonnelActivityRepository.GetAll();

            var personActiviyFilter = from o in personActivity
                                      join s1 in activity on o.ActivityId equals s1.ActivityId
                                      select new PersonnelActivityViewModel()
                                      {
                                          PersonnelActivityId = o.PersonnelActivityId,
                                          PersonnelId = o.PersonnelId,
                                          ActivityId = o.ActivityId,
                                          ActivityEn = s1.ActivityEn,
                                          ActivityTh = s1.ActivityTh,
                                          StartDate = s1.StartDate,
                                          EndDate = s1.EndDate,
                                          IsAllDay = s1.IsAllDay,
                                          WorkLoadQty = s1.WorkLoadQty,
                                          Location = s1.Location,
                                          ActivityFacultyId = s1.FacultyId,
                                          ActivityFacultyName = s1.FacultyName,
                                          ActivityTypeId = s1.ActivityTypeId,
                                          ActivityTypeName = s1.ActivityTypeName,
                                          CitizenId = o.CitizenId,
                                          PersonnelName = o.PersonnelName,
                                          HourQty = o.HourQty,
                                          FacultyId = o.FacultyId,
                                          FacultyName = o.FacultyName,
                                          PersonnelStatus = o.PersonnelStatus
                                      };

            var personActivityDistinct = personActiviyFilter.Select(s => new { s.ActivityFacultyId, s.ActivityFacultyName }).Distinct();

            var list = new List<PersonnelFacultyActivityDataSourceModel>();
            foreach (var pa in personActivityDistinct)
            {
                var personFacultyActivity = new PersonnelFacultyActivityDataSourceModel
                {
                    FacultyName = pa.ActivityFacultyName,
                    FacultyId = pa.ActivityFacultyId,
                    Person = personActiviyFilter.Where(m => m.ActivityFacultyName == pa.ActivityFacultyName && m.ActivityFacultyId == pa.ActivityFacultyId).ToList()
                };
                list.Add(personFacultyActivity);
            }
            return list;

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
            return personActivity;
        }                                                                                                                            


    }
}
