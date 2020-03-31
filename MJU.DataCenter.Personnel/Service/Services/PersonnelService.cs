using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MJU.DataCenter.Personnel.Helper;
using MJU.DataCenter.Personnel.Models;
using MJU.DataCenter.Personnel.Repository.Interface;
using MJU.DataCenter.Personnel.Service.Interface;
using MJU.DataCenter.Personnel.ViewModels;

namespace MJU.DataCenter.Personnel.Service.Services
{
    public class PersonnelService : IPersonnelService
    {
        private readonly IPersonnelRepository _personnelRepository;
        private readonly IDcPersonRepository _dcPersonRepository;

        public PersonnelService(IPersonnelRepository personnelRepository,
            IDcPersonRepository dcPersonRepository)
        {
            _personnelRepository = personnelRepository;
            _dcPersonRepository = dcPersonRepository;
        }

        public object GetAllPersonnelGroup(int type)
        {

            var personnel = _dcPersonRepository.GetAll();

            var distinctPersonnelTypeId = personnel.Select(s => s.PersonnelType
            ).Distinct();

            if (type == 1)
            {
                var label = new List<string>();
                var data = new List<int>();

                foreach (var personnelType in distinctPersonnelTypeId)
                {
                    label.Add(personnelType);
                    data.Add(personnel.Where(m => m.PersonnelType == personnelType).Count());
                }
                var graphDataSet = new GraphDataSet
                {
                    Data = data
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
                var list = new List<PersonGroup>();
                foreach (var personnelType in distinctPersonnelTypeId)
                {
                    var personGroup = new PersonGroup
                    {
                        PersonGroupTypeName = personnelType,
                        Person = personnel.Where(m => m.PersonnelType == personnelType).Count()
                    };
                    list.Add(personGroup);
                }
                var result = new PersonGroupViewModel
                {
                    PersonGroup = list
                };
                return result;
            }


        }
        public object GetAllPersonnelPosition(int type)
        {
            var personnel = _dcPersonRepository.GetAll();

            var distinctPosition = personnel.Select(s => s.PositionType
            ).Distinct();

            if (type == 1)
            {
                var label = new List<string>();
                var data = new List<int>();

                foreach (var positionType in distinctPosition)
                {
                    label.Add(positionType);
                    data.Add(personnel.Where(m => m.PositionType == positionType).Count());
                }
                var graphDataSet = new GraphDataSet
                {
                    Data = data
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
                var list = new List<PersonPostion>();
                foreach (var positionType in distinctPosition)
                {
                    var personPosition = new PersonPostion
                    {
                        PersonPosionTypeName = positionType,
                        Person = personnel.Where(m => m.PositionType == positionType).Count()
                    };
                    list.Add(personPosition);
                }
                var result = new PersonPostionViewModel
                {
                    PersonPostion = list
                };
                return result;
            }
        }

        public object GetAllPersonnelEducation(int type)
        {
            var educate = new List<string>() { "ปริญญาเอก", "ปริญญาตรี", "ปริญญาโท" };
            var personnel = _dcPersonRepository.GetAll().Where(m => educate.Contains(m.EducationLevel));
            var lowerBachelor = _dcPersonRepository.GetAll().Where(m => !educate.Contains(m.EducationLevel)).Count();

            var distinctEducationLevel = personnel.Select(s => s.EducationLevel
            ).Distinct();

            if (type == 1)
            {
                var label = new List<string>();
                var data = new List<int>();

                foreach (var educationLevel in distinctEducationLevel)
                {
                    label.Add(educationLevel);
                    data.Add(personnel.Where(m => m.EducationLevel == educationLevel).Count());
                }

                label.Add("ต่ำกว่าปริญญาตรี");
                data.Add(lowerBachelor);

                var graphDataSet = new GraphDataSet
                {
                    Data = data
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
                var list = new List<PersonEducation>();
                foreach (var educationLevel in distinctEducationLevel)
                {
                    var personPosition = new PersonEducation
                    {
                        EducationTypeName = educationLevel,
                        Person = personnel.Where(m => m.EducationLevel == educationLevel).Count()
                    };
                    list.Add(personPosition);
                }
                list.Add(new PersonEducation
                {
                    EducationTypeName = "ต่ำกว่าปริญญาตรี",
                    Person = _dcPersonRepository.GetAll().Where(m => !educate.Contains(m.EducationLevel)).Count()

                });
                return list;
            }
        }
        public object GetAllPersonnelPositionGeneration(int type)
        {
            var personnel = _dcPersonRepository.GetAll();

            var distinctPosition = personnel.Select(s => s.PositionType
            ).Distinct();

            if (type == 1)
            {

                var list = new List<GraphDataSet>();
                var label = new List<string> { "Baby Boomer\n(เกิดปี 2489 - 2507)", "Gen X \n \n (เกิดปี 2508 - 2522)", "Gen Y \n \n (เกิดปี 2523 - 2540)", "Gen Z \n \n (เกิดปี 2541 ขึ้นไป)" };




                foreach (var positionType in distinctPosition)
                {
                    var distinctGenerationBabyBoomber = personnel.Where(s => s.DateOfBirth >= DateTime.Parse("1946/01/01") && s.DateOfBirth <= DateTime.Parse("1964/12/31")).Count();
                    var distinctGenerationGenX = personnel.Where(s => s.PositionType == positionType && s.DateOfBirth >= DateTime.Parse("1967/01/01") && s.DateOfBirth <= DateTime.Parse("1979/12/31")).Count();
                    var distinctGenerationGenY = personnel.Where(s => s.PositionType == positionType && s.DateOfBirth >= DateTime.Parse("1980/01/01") && s.DateOfBirth <= DateTime.Parse("1997/12/31")).Count();
                    var distinctGenerationGenZ = personnel.Where(s => s.PositionType == positionType && s.DateOfBirth >= DateTime.Parse("1998/01/01")).Count();

                    var graphDataSet = new GraphDataSet
                    {
                        Label = positionType,
                        Data = new List<int>{
                        distinctGenerationBabyBoomber,
                        distinctGenerationGenX,
                        distinctGenerationGenY,
                        distinctGenerationGenZ
                        }
                    };
                    list.Add(graphDataSet);
                };

                var result = new GraphData
                {
                    GraphDataSet = list,
                    Label = label
                };
                return result;

            }
            else
            {
                var result = new List<PersonPostionGenertionViewModel>();

                foreach (var positionType in distinctPosition)
                {
                    var distinctGenerationBabyBoomber = personnel.Where(s => s.DateOfBirth >= new DateTime(19460101) && s.DateOfBirth <= new DateTime(19641231)).Count();
                    var distinctGenerationGenX = personnel.Where(s => s.PositionType == positionType && s.DateOfBirth >= new DateTime(19670101) && s.DateOfBirth <= new DateTime(19791231)).Count();
                    var distinctGenerationGenY = personnel.Where(s => s.PositionType == positionType && s.DateOfBirth >= new DateTime(19800101) && s.DateOfBirth <= new DateTime(19971231)).Count();
                    var distinctGenerationGenZ = personnel.Where(s => s.PositionType == positionType && s.DateOfBirth >= new DateTime(19980101)).Count();


                    var personPostionGenertion = new List<PersonPostionGenertion> {
                        new PersonPostionGenertion
                        {
                            PersonGenertionName = "Baby Boomer (เกิดปี 2489 - 2507)",
                            Person = distinctGenerationBabyBoomber
                        },
                        new PersonPostionGenertion
                        {
                            PersonGenertionName = "Gen X (เกิดปี 2508 - 2522)",
                            Person = distinctGenerationGenX
                        },
                        new PersonPostionGenertion
                        {
                            PersonGenertionName = "Gen Y (เกิดปี 2523 - 2540)",
                            Person = distinctGenerationGenY
                        },
                        new PersonPostionGenertion
                        {
                            PersonGenertionName = "Gen Z (เกิดปี 2541 ขึ้นไป)" ,
                            Person = distinctGenerationGenZ
                        }
                    };
                    var personPostionGenertionViewModel = new PersonPostionGenertionViewModel()
                    {
                        PersionPostionName = positionType,
                        PersonPostionGeneration = personPostionGenertion

                    };
                    result.Add(personPostionGenertionViewModel);


                }

                return result;
            }
        }
        public async Task<IEnumerable<Person>> GetAllPerson()
        {
            return await _personnelRepository.GetAllAsync();
        }

        public List<RetiredPersonDataTableModel> GetDataTablePersonRetired(string year, int type)
        {
            var currentDate = DateTime.Parse(string.Format("01/01/{0}", year)).AddYears(-543);
            var startOfYear = currentDate.StartOfYear();
            var endOfYear = currentDate.EndOfYear();
            if (type == 0)
            {

                return _dcPersonRepository.GetAll().Where(m => m.StartDate <= endOfYear && (m.RetiredDate < endOfYear || m.RetiredDate == null))
                    .Select(s => new RetiredPersonDataTableModel
                    {
                        PersonnelId = s.PersonnelId,
                        PersonnelName = string.Format("{0} {1} {2}", s.TitleName, s.FirstName, s.LastName),
                        DateOfBirth = s.DateOfBirth,
                        Age = DateTime.UtcNow.Year - s.DateOfBirth.GetValueOrDefault().Year,
                        PersonnelType = s.PersonnelType,
                        Position = s.Position,
                        PositionType = s.Position,
                        PositionLevel = s.PositionLevel,
                        StartDate = s.StartDate,
                        RetiredDate = s.RetiredDate,
                        RetiredYear = s.RetiredYear,
                        Section = s.Section,
                        Division = s.Division,
                        Faculty = s.Faculty

                    }).ToList();

            }
            else if (type == 1)
            {
                var result =  _dcPersonRepository.GetAll().Where(m => (endOfYear.Year - m.DateOfBirth.GetValueOrDefault().Year) == 60)
                    .Select(s => new RetiredPersonDataTableModel
                    {
                        PersonnelId = s.PersonnelId,
                        PersonnelName = string.Format("{0} {1} {2}", s.TitleName, s.FirstName, s.LastName),
                        DateOfBirth = s.DateOfBirth,
                        Age = DateTime.UtcNow.Year - s.DateOfBirth.GetValueOrDefault().Year,
                        PersonnelType = s.PersonnelType,
                        Position = s.Position,
                        PositionType = s.Position,
                        PositionLevel = s.PositionLevel,
                        StartDate = s.StartDate,
                        RetiredDate = s.RetiredDate,
                        RetiredYear = s.RetiredYear,
                        Section = s.Section,
                        Division = s.Division,
                        Faculty = s.Faculty

                    }).ToList();

                return result;

            }
            else
            {
                return _dcPersonRepository.GetAll().Where(m => m.RetiredDate >= startOfYear && m.RetiredDate <= endOfYear)
                    .Select(s => new RetiredPersonDataTableModel
                    {
                        PersonnelId = s.PersonnelId,
                        PersonnelName = string.Format("{0} {1} {2}", s.TitleName, s.FirstName, s.LastName),
                        DateOfBirth = s.DateOfBirth,
                        Age = DateTime.UtcNow.Year - s.DateOfBirth.GetValueOrDefault().Year,
                        PersonnelType = s.PersonnelType,
                        Position = s.Position,
                        PositionType = s.Position,
                        PositionLevel = s.PositionLevel,
                        StartDate = s.StartDate,
                        RetiredDate = s.RetiredDate,
                        RetiredYear = s.RetiredYear,
                        Section = s.Section,
                        Division = s.Division,
                        Faculty = s.Faculty

                    }).ToList();

            }
        }

        public object GetAllPersonRetired(int total, int type)
        {
            var half = total / 2 - 1;
            var yearBack = DateTime.UtcNow.AddYears(-half);

            var person = _dcPersonRepository.GetAll();

            if (type == 1)
            {
                var label = new List<string>();
                var personData = new List<int>();
                var retiredPersonData = new List<int>();
                var predictRetiredPersondata = new List<int>();
                var retiredPersonView = new RetiredPersonDataModel();

                for (var i = 0; i < total; i++)
                {

                    var currentDate = yearBack.AddYears(i);
                    var startOfYear = currentDate.StartOfYear();
                    var endOfYear = currentDate.EndOfYear();
                    label.Add(currentDate.AddYears(543).Year.ToString());

                    var personCount = person.Where(m => m.StartDate <= endOfYear && (m.RetiredDate < endOfYear || m.RetiredDate == null)).Count();
                    personData.Add(personCount);

                    var retiredPersonCount = person.Where(m => m.RetiredDate >= startOfYear && m.RetiredDate <= endOfYear).Count();
                    if (retiredPersonCount > 0) retiredPersonData.Add(retiredPersonCount);

                    var personRetiredPredict = person.Where(m => (endOfYear.Year - m.DateOfBirth.GetValueOrDefault().Year) == 60).Count();
                    if (personRetiredPredict > 0) predictRetiredPersondata.Add(personRetiredPredict);
                    if (currentDate.Year == DateTime.UtcNow.Year)
                    {
                        retiredPersonView.Person = personCount;
                        retiredPersonView.PersonStart = person.Where(m => m.StartDate >= startOfYear && m.StartDate <= endOfYear).Count();
                        retiredPersonView.PredictionRetiredPersonRate = Math.Round(((decimal)personRetiredPredict / (decimal)personCount) * 100, 2);
                        retiredPersonView.RetiredPersonRate = Math.Round(((decimal)retiredPersonCount / (decimal)personCount) * 100,2);
                    }

                }

                var grapgData = new GraphData
                {
                    Label = label,
                    GraphDataSet = new List<GraphDataSet>{
                      new GraphDataSet
                      {
                        Label = "Person",
                        Data = personData
                      },
                      new GraphDataSet
                      {
                        Label = "PredictionRetired",
                        Data = predictRetiredPersondata
                      },
                      new GraphDataSet
                      {
                        Label = "Retired",
                        Data = retiredPersonData
                      }
                },
                    ViewLabel = retiredPersonView
                };
                return grapgData;
            }
            else
            {
                var result = new List<RetiredPersonViewModel>();
                for (var i = 0; i < total; i++)
                {
                    var currentDate = yearBack.AddYears(i);
                    var startOfYear = currentDate.StartOfYear();
                    var endOfYear = currentDate.EndOfYear();
                    var model = new RetiredPersonViewModel
                    {
                        Year = currentDate.AddYears(543).Year.ToString(),
                        Person = person.Where(m => m.StartDate <= endOfYear && (m.RetiredDate < endOfYear || m.RetiredDate == null)).ToList(),
                        RetiredPerson = person.Where(m => m.RetiredDate >= startOfYear && m.RetiredDate <= endOfYear).ToList(),
                        PredecitionRetiredPerson = person.Where(m => (endOfYear.Year - m.DateOfBirth.GetValueOrDefault().Year) > 60).ToList()
                    };
                    result.Add(model);

                }
                return result.OrderBy(o => o.Year);
            }
        }




    }
}
