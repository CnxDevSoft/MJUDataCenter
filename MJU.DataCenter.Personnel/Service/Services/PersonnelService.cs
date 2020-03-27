using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

            var distinctPersonnelTypeId = personnel.Select(s=> s.PersonnelType
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
                var graphDataSet = new GraphDataSet {
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
            else {
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
                    var distinctGenerationBabyBoomber = personnel.Where(s => s.DateOfBirth >= new DateTime(19460101) && s.DateOfBirth <= DateTime.Parse("1964/12/31")).Count();
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
        public async Task<IEnumerable<Person>> GetAllPerson() {
            return await _personnelRepository.GetAllAsync();
        }


    }
}
