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
using MJU.DataCenter.Personnel.ViewModels.dtos;

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

            var personnel = _dcPersonRepository.GetAll().OrderBy(o => o.PersonnelTypeId);

            var distinctPersonnelTypeId = personnel.Select(s => new { s.PersonnelType, s.PersonnelTypeId }).Distinct();

            if (type == 1)
            {
                var label = new List<string>();
                var data = new List<int>();

                foreach (var personnelType in distinctPersonnelTypeId)
                {
                    label.Add(personnelType.PersonnelType);
                    data.Add(personnel.Where(m => m.PersonnelType == personnelType.PersonnelType && m.PersonnelTypeId == personnelType.PersonnelTypeId).Count());
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
                var list = new List<PersonGroupDataTableModel>();
                foreach (var personnelType in distinctPersonnelTypeId)
                {
                    var personGroup = new PersonGroupDataTableModel
                    {
                        PersonGroupTypeId = personnelType.PersonnelTypeId,
                        PersonGroupTypeName = personnelType.PersonnelType,
                        Person = personnel.Where(m => m.PersonnelType == personnelType.PersonnelType && m.PersonnelTypeId == personnelType.PersonnelTypeId).Count()
                    };
                    list.Add(personGroup);
                }

                return list;
            }


        }

        public List<PersonGroupDataSourceModel> GetAllPersonnelGroupDataSource()
        {

            var personnel = _dcPersonRepository.GetAll().OrderBy(o => o.PersonnelTypeId);

            var distinctPersonnelTypeId = personnel.Select(s => new { s.PersonnelType, s.PersonnelTypeId }).Distinct();

            var list = new List<PersonGroupDataSourceModel>();
            foreach (var personnelType in distinctPersonnelTypeId)
            {
                var personGroup = new PersonGroupDataSourceModel
                {
                    PersonGroupTypeId = personnelType.PersonnelTypeId,
                    PersonGroupTypeName = personnelType.PersonnelType,
                    Person = personnel.Where(m => m.PersonnelType == personnelType.PersonnelType && m.PersonnelTypeId == personnelType.PersonnelTypeId)
                    .Select(s => new PersonnelDataSourceViewModel
                    {
                        AdminPosition = s.AdminPosition,
                        AdminPositionType = s.AdminPositionType,
                        BloodType = s.BloodType,
                        Country = s.Country,
                        DateOfBirth = s.DateOfBirth,
                        Division = s.Division,
                        Education = s.Education,
                        EducationLevel = s.EducationLevel,
                        Faculty = s.Faculty,
                        Gender = s.Gender,
                        GraduateDate = s.GraduateDate,
                        IdCard = s.IdCard,
                        Major = s.Major,
                        Nation = s.Nation,
                        PersonName = string.Format("{0} {1} {2}", s.TitleName, s.FirstName, s.LastName),
                        PersonnelId = s.PersonnelId,
                        PersonnelType = s.PersonnelType,
                        Position = s.Position,
                        PositionLevel = s.PositionLevel,
                        PositionType = s.PositionType,
                        Province = s.Province,
                        RetiredDate = s.RetiredDate,
                        RetiredYear = s.RetiredYear,
                        Salary = s.Salary,
                        Section = s.Section,
                        StartDate = s.StartDate,
                        StartEducationDate = s.StartEducationDate,
                        TitleEducation = s.TitleEducation,
                        University = s.University,
                        ZipCode = s.ZipCode

                    }).ToList()
                };
                list.Add(personGroup);
            }

            return list;



        }

        public object GetAllPersonnelPosition(int type)
        {
            var personnel = _dcPersonRepository.GetAll();

            var distinctPosition = personnel.Select(s => new { s.PositionType, s.PositionTypeId }).Distinct();

            if (type == 1)
            {
                var label = new List<string>();
                var data = new List<int>();

                foreach (var positionType in distinctPosition)
                {
                    label.Add(positionType.PositionType);
                    data.Add(personnel.Where(m => m.PositionType == positionType.PositionType && m.PositionTypeId == m.PositionTypeId).Count());
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
                var list = new List<PersonPostionDataTableModel>();
                foreach (var positionType in distinctPosition)
                {
                    var personPosition = new PersonPostionDataTableModel
                    {
                        PersonPosionTypeName = positionType.PositionType,
                        Person = personnel.Where(m => m.PositionType == positionType.PositionType && m.PositionTypeId == m.PositionTypeId).Count()
                    };
                    list.Add(personPosition);
                }
                return list;
            }
        }

        public List<PersonPostionDataSourceModel> GetAllPersonnelPositionDataSource()
        {
            var personnel = _dcPersonRepository.GetAll();

            var distinctPosition = personnel.Select(s => new { s.PositionType, s.PositionTypeId }).Distinct();

            var list = new List<PersonPostionDataSourceModel>();
            foreach (var positionType in distinctPosition)
            {
                var personPosition = new PersonPostionDataSourceModel
                {
                    PersonPosionTypeName = positionType.PositionType,
                    Person = personnel.Where(m => m.PositionType == positionType.PositionType && m.PositionTypeId == m.PositionTypeId).
                    Select(s => new PersonnelDataSourceViewModel
                    {
                        AdminPosition = s.AdminPosition,
                        AdminPositionType = s.AdminPositionType,
                        BloodType = s.BloodType,
                        Country = s.Country,
                        DateOfBirth = s.DateOfBirth,
                        Division = s.Division,
                        Education = s.Education,
                        EducationLevel = s.EducationLevel,
                        Faculty = s.Faculty,
                        Gender = s.Gender,
                        GraduateDate = s.GraduateDate,
                        IdCard = s.IdCard,
                        Major = s.Major,
                        Nation = s.Nation,
                        PersonName = string.Format("{0} {1} {2}", s.TitleName, s.FirstName, s.LastName),
                        PersonnelId = s.PersonnelId,
                        PersonnelType = s.PersonnelType,
                        Position = s.Position,
                        PositionLevel = s.PositionLevel,
                        PositionType = s.PositionType,
                        Province = s.Province,
                        RetiredDate = s.RetiredDate,
                        RetiredYear = s.RetiredYear,
                        Salary = s.Salary,
                        Section = s.Section,
                        StartDate = s.StartDate,
                        StartEducationDate = s.StartEducationDate,
                        TitleEducation = s.TitleEducation,
                        University = s.University,
                        ZipCode = s.ZipCode
                    }).ToList()
                };
                list.Add(personPosition);
            }
            return list;

        }

        public object GetAllPersonnelEducation(int type)
        {
            var educate = new List<string>() { "ปริญญาเอก", "ปริญญาตรี", "ปริญญาโท" };
            var personnel = _dcPersonRepository.GetAll().Where(m => educate.Contains(m.EducationLevel));
            var lowerBachelor = _dcPersonRepository.GetAll().Where(m => !educate.Contains(m.EducationLevel)).Count();

            var distinctEducationLevel = personnel.Select(s => new { s.EducationLevel, s.EducationLevelId }
            ).Distinct();

            if (type == 1)
            {
                var label = new List<string>();
                var data = new List<int>();

                foreach (var educationLevel in distinctEducationLevel)
                {
                    label.Add(educationLevel.EducationLevel);
                    data.Add(personnel.Where(m => m.EducationLevel == educationLevel.EducationLevel && m.EducationLevelId == educationLevel.EducationLevelId).Count());
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
                var list = new List<PersonEducationDataTableModel>();
                foreach (var educationLevel in distinctEducationLevel)
                {
                    var personPosition = new PersonEducationDataTableModel
                    {
                        EducationTypeName = educationLevel.EducationLevel,
                        Person = personnel.Where(m => m.EducationLevel == educationLevel.EducationLevel && m.EducationLevelId == educationLevel.EducationLevelId).Count()
                    };
                    list.Add(personPosition);
                }
                list.Add(new PersonEducationDataTableModel
                {
                    EducationTypeName = "ต่ำกว่าปริญญาตรี",
                    Person = _dcPersonRepository.GetAll().Where(m => !educate.Contains(m.EducationLevel)).Count()

                });
                return list;
            }
        }

        public List<PersonEducationDataSourceModel> GetAllPersonnelEducationDataSource()
        {
            var educate = new List<string>() { "ปริญญาเอก", "ปริญญาตรี", "ปริญญาโท" };
            var personnel = _dcPersonRepository.GetAll().Where(m => educate.Contains(m.EducationLevel));
            var lowerBachelor = _dcPersonRepository.GetAll().Where(m => !educate.Contains(m.EducationLevel)).Count();

            var distinctEducationLevel = personnel.Select(s => new { s.EducationLevel, s.EducationLevelId }
            ).Distinct();


            var list = new List<PersonEducationDataSourceModel>();
            foreach (var educationLevel in distinctEducationLevel)
            {
                var personPosition = new PersonEducationDataSourceModel
                {
                    EducationTypeName = educationLevel.EducationLevel,
                    Person = personnel.Where(m => m.EducationLevel == educationLevel.EducationLevel && m.EducationLevelId == educationLevel.EducationLevelId)
                    .Select(s => new PersonnelDataSourceViewModel
                    {
                        AdminPosition = s.AdminPosition,
                        AdminPositionType = s.AdminPositionType,
                        BloodType = s.BloodType,
                        Country = s.Country,
                        DateOfBirth = s.DateOfBirth,
                        Division = s.Division,
                        Education = s.Education,
                        EducationLevel = s.EducationLevel,
                        Faculty = s.Faculty,
                        Gender = s.Gender,
                        GraduateDate = s.GraduateDate,
                        IdCard = s.IdCard,
                        Major = s.Major,
                        Nation = s.Nation,
                        PersonName = string.Format("{0} {1} {2}", s.TitleName, s.FirstName, s.LastName),
                        PersonnelId = s.PersonnelId,
                        PersonnelType = s.PersonnelType,
                        Position = s.Position,
                        PositionLevel = s.PositionLevel,
                        PositionType = s.PositionType,
                        Province = s.Province,
                        RetiredDate = s.RetiredDate,
                        RetiredYear = s.RetiredYear,
                        Salary = s.Salary,
                        Section = s.Section,
                        StartDate = s.StartDate,
                        StartEducationDate = s.StartEducationDate,
                        TitleEducation = s.TitleEducation,
                        University = s.University,
                        ZipCode = s.ZipCode

                    }).ToList()
                };
                list.Add(personPosition);
            }
            list.Add(new PersonEducationDataSourceModel
            {
                EducationTypeName = "ต่ำกว่าปริญญาตรี",
                Person = _dcPersonRepository.GetAll().Where(m => !educate.Contains(m.EducationLevel))
                .Select(s => new PersonnelDataSourceViewModel
                {
                    AdminPosition = s.AdminPosition,
                    AdminPositionType = s.AdminPositionType,
                    BloodType = s.BloodType,
                    Country = s.Country,
                    DateOfBirth = s.DateOfBirth,
                    Division = s.Division,
                    Education = s.Education,
                    EducationLevel = s.EducationLevel,
                    Faculty = s.Faculty,
                    Gender = s.Gender,
                    GraduateDate = s.GraduateDate,
                    IdCard = s.IdCard,
                    Major = s.Major,
                    Nation = s.Nation,
                    PersonName = string.Format("{0} {1} {2}", s.TitleName, s.FirstName, s.LastName),
                    PersonnelId = s.PersonnelId,
                    PersonnelType = s.PersonnelType,
                    Position = s.Position,
                    PositionLevel = s.PositionLevel,
                    PositionType = s.PositionType,
                    Province = s.Province,
                    RetiredDate = s.RetiredDate,
                    RetiredYear = s.RetiredYear,
                    Salary = s.Salary,
                    Section = s.Section,
                    StartDate = s.StartDate,
                    StartEducationDate = s.StartEducationDate,
                    TitleEducation = s.TitleEducation,
                    University = s.University,
                    ZipCode = s.ZipCode

                }).ToList()

            });
            return list;

        }

        public object GetAllPersonnelPositionGeneration(int type)
        {
            var personnel = _dcPersonRepository.GetAll();

            var distinctPosition = personnel.Select(s => new { s.PositionType, s.PositionTypeId }).Distinct();

            if (type == 1)
            {

                var list = new List<GraphDataSet>();
                var label = new List<string> { "Baby Boomer\n(เกิดปี 2489 - 2507)", "Gen X \n \n (เกิดปี 2508 - 2522)", "Gen Y \n \n (เกิดปี 2523 - 2540)", "Gen Z \n \n (เกิดปี 2541 ขึ้นไป)" };




                foreach (var positionType in distinctPosition)
                {
                    var distinctGenerationBabyBoomber = personnel.Where(s => s.DateOfBirth >= DateTime.Parse("1946/01/01") && s.DateOfBirth <= DateTime.Parse("1964/12/31")).Count();
                    var distinctGenerationGenX = personnel.Where(s => s.PositionType == positionType.PositionType && s.PositionTypeId == positionType.PositionTypeId && s.DateOfBirth >= DateTime.Parse("1967/01/01") && s.DateOfBirth <= DateTime.Parse("1979/12/31")).Count();
                    var distinctGenerationGenY = personnel.Where(s => s.PositionType == positionType.PositionType && s.PositionTypeId == positionType.PositionTypeId && s.DateOfBirth >= DateTime.Parse("1980/01/01") && s.DateOfBirth <= DateTime.Parse("1997/12/31")).Count();
                    var distinctGenerationGenZ = personnel.Where(s => s.PositionType == positionType.PositionType && s.PositionTypeId == positionType.PositionTypeId && s.DateOfBirth >= DateTime.Parse("1998/01/01")).Count();

                    var graphDataSet = new GraphDataSet
                    {
                        Label = positionType.PositionType,
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
                    var distinctGenerationGenX = personnel.Where(s => s.PositionType == positionType.PositionType && s.PositionTypeId == positionType.PositionTypeId && s.DateOfBirth >= new DateTime(19670101) && s.DateOfBirth <= new DateTime(19791231)).Count();
                    var distinctGenerationGenY = personnel.Where(s => s.PositionType == positionType.PositionType && s.PositionTypeId == positionType.PositionTypeId && s.DateOfBirth >= new DateTime(19800101) && s.DateOfBirth <= new DateTime(19971231)).Count();
                    var distinctGenerationGenZ = personnel.Where(s => s.PositionType == positionType.PositionType && s.PositionTypeId == positionType.PositionTypeId && s.DateOfBirth >= new DateTime(19980101)).Count();


                    var personPostionGenertion = new List<PersonPostionGenertionDataTableModel> {
                        new PersonPostionGenertionDataTableModel
                        {
                            PersonGenertionName = "Baby Boomer (เกิดปี 2489 - 2507)",
                            Person = distinctGenerationBabyBoomber
                        },
                        new PersonPostionGenertionDataTableModel
                        {
                            PersonGenertionName = "Gen X (เกิดปี 2508 - 2522)",
                            Person = distinctGenerationGenX
                        },
                        new PersonPostionGenertionDataTableModel
                        {
                            PersonGenertionName = "Gen Y (เกิดปี 2523 - 2540)",
                            Person = distinctGenerationGenY
                        },
                        new PersonPostionGenertionDataTableModel
                        {
                            PersonGenertionName = "Gen Z (เกิดปี 2541 ขึ้นไป)" ,
                            Person = distinctGenerationGenZ
                        }
                    };
                    var personPostionGenertionViewModel = new PersonPostionGenertionViewModel()
                    {
                        PersionPostionName = positionType.PositionType,
                        PersonPostionGeneration = personPostionGenertion

                    };
                    result.Add(personPostionGenertionViewModel);


                }

                return result;
            }
        }

        public List<PersonPostionGenertionDataSourceViewModel> GetAllPersonnelPositionGenerationDataSource()
        {
            var personnel = _dcPersonRepository.GetAll();

            var distinctPosition = personnel.Select(s => new { s.PositionType, s.PositionTypeId }).Distinct();


            var result = new List<PersonPostionGenertionDataSourceViewModel>();
            foreach (var positionType in distinctPosition)
            {
                var generationBabyBoomber = personnel.Where(s => s.DateOfBirth >= new DateTime(19460101) && s.DateOfBirth <= new DateTime(19641231))
                .Select(s => new PersonnelDataSourceViewModel
                {
                    AdminPosition = s.AdminPosition,
                    AdminPositionType = s.AdminPositionType,
                    BloodType = s.BloodType,
                    Country = s.Country,
                    DateOfBirth = s.DateOfBirth,
                    Division = s.Division,
                    Education = s.Education,
                    EducationLevel = s.EducationLevel,
                    Faculty = s.Faculty,
                    Gender = s.Gender,
                    GraduateDate = s.GraduateDate,
                    IdCard = s.IdCard,
                    Major = s.Major,
                    Nation = s.Nation,
                    PersonName = string.Format("{0} {1} {2}", s.TitleName, s.FirstName, s.LastName),
                    PersonnelId = s.PersonnelId,
                    PersonnelType = s.PersonnelType,
                    Position = s.Position,
                    PositionLevel = s.PositionLevel,
                    PositionType = s.PositionType,
                    Province = s.Province,
                    RetiredDate = s.RetiredDate,
                    RetiredYear = s.RetiredYear,
                    Salary = s.Salary,
                    Section = s.Section,
                    StartDate = s.StartDate,
                    StartEducationDate = s.StartEducationDate,
                    TitleEducation = s.TitleEducation,
                    University = s.University,
                    ZipCode = s.ZipCode

                }).ToList();
                var generationGenX = personnel.Where(s => s.PositionType == positionType.PositionType && s.PositionTypeId == positionType.PositionTypeId && s.DateOfBirth >= new DateTime(19670101) && s.DateOfBirth <= new DateTime(19791231))
                .Select(s => new PersonnelDataSourceViewModel
                {
                    AdminPosition = s.AdminPosition,
                    AdminPositionType = s.AdminPositionType,
                    BloodType = s.BloodType,
                    Country = s.Country,
                    DateOfBirth = s.DateOfBirth,
                    Division = s.Division,
                    Education = s.Education,
                    EducationLevel = s.EducationLevel,
                    Faculty = s.Faculty,
                    Gender = s.Gender,
                    GraduateDate = s.GraduateDate,
                    IdCard = s.IdCard,
                    Major = s.Major,
                    Nation = s.Nation,
                    PersonName = string.Format("{0} {1} {2}", s.TitleName, s.FirstName, s.LastName),
                    PersonnelId = s.PersonnelId,
                    PersonnelType = s.PersonnelType,
                    Position = s.Position,
                    PositionLevel = s.PositionLevel,
                    PositionType = s.PositionType,
                    Province = s.Province,
                    RetiredDate = s.RetiredDate,
                    RetiredYear = s.RetiredYear,
                    Salary = s.Salary,
                    Section = s.Section,
                    StartDate = s.StartDate,
                    StartEducationDate = s.StartEducationDate,
                    TitleEducation = s.TitleEducation,
                    University = s.University,
                    ZipCode = s.ZipCode
                }).ToList();
                var generationGenY = personnel.Where(s => s.PositionType == positionType.PositionType && s.PositionTypeId == positionType.PositionTypeId && s.DateOfBirth >= new DateTime(19800101) && s.DateOfBirth <= new DateTime(19971231))
                    .Select(s => new PersonnelDataSourceViewModel
                    {
                        AdminPosition = s.AdminPosition,
                        AdminPositionType = s.AdminPositionType,
                        BloodType = s.BloodType,
                        Country = s.Country,
                        DateOfBirth = s.DateOfBirth,
                        Division = s.Division,
                        Education = s.Education,
                        EducationLevel = s.EducationLevel,
                        Faculty = s.Faculty,
                        Gender = s.Gender,
                        GraduateDate = s.GraduateDate,
                        IdCard = s.IdCard,
                        Major = s.Major,
                        Nation = s.Nation,
                        PersonName = string.Format("{0} {1} {2}", s.TitleName, s.FirstName, s.LastName),
                        PersonnelId = s.PersonnelId,
                        PersonnelType = s.PersonnelType,
                        Position = s.Position,
                        PositionLevel = s.PositionLevel,
                        PositionType = s.PositionType,
                        Province = s.Province,
                        RetiredDate = s.RetiredDate,
                        RetiredYear = s.RetiredYear,
                        Salary = s.Salary,
                        Section = s.Section,
                        StartDate = s.StartDate,
                        StartEducationDate = s.StartEducationDate,
                        TitleEducation = s.TitleEducation,
                        University = s.University,
                        ZipCode = s.ZipCode
                    }).ToList();
                var generationGenZ = personnel.Where(s => s.PositionType == positionType.PositionType && s.PositionTypeId == positionType.PositionTypeId && s.DateOfBirth >= new DateTime(19980101))
                    .Select(s => new PersonnelDataSourceViewModel
                    {
                        AdminPosition = s.AdminPosition,
                        AdminPositionType = s.AdminPositionType,
                        BloodType = s.BloodType,
                        Country = s.Country,
                        DateOfBirth = s.DateOfBirth,
                        Division = s.Division,
                        Education = s.Education,
                        EducationLevel = s.EducationLevel,
                        Faculty = s.Faculty,
                        Gender = s.Gender,
                        GraduateDate = s.GraduateDate,
                        IdCard = s.IdCard,
                        Major = s.Major,
                        Nation = s.Nation,
                        PersonName = string.Format("{0} {1} {2}", s.TitleName, s.FirstName, s.LastName),
                        PersonnelId = s.PersonnelId,
                        PersonnelType = s.PersonnelType,
                        Position = s.Position,
                        PositionLevel = s.PositionLevel,
                        PositionType = s.PositionType,
                        Province = s.Province,
                        RetiredDate = s.RetiredDate,
                        RetiredYear = s.RetiredYear,
                        Salary = s.Salary,
                        Section = s.Section,
                        StartDate = s.StartDate,
                        StartEducationDate = s.StartEducationDate,
                        TitleEducation = s.TitleEducation,
                        University = s.University,
                        ZipCode = s.ZipCode
                    }).ToList();


                var personPostionGenertion = new List<PersonPostionGenertionDataSourceModel> {
                        new PersonPostionGenertionDataSourceModel
                        {
                            PersonGenertionName = "Baby Boomer (เกิดปี 2489 - 2507)",
                            Person = generationBabyBoomber
                        },
                        new PersonPostionGenertionDataSourceModel
                        {
                            PersonGenertionName = "Gen X (เกิดปี 2508 - 2522)",
                            Person = generationGenX
                        },
                        new PersonPostionGenertionDataSourceModel
                        {
                            PersonGenertionName = "Gen Y (เกิดปี 2523 - 2540)",
                            Person = generationGenY
                        },
                        new PersonPostionGenertionDataSourceModel
                        {
                            PersonGenertionName = "Gen Z (เกิดปี 2541 ขึ้นไป)" ,
                            Person = generationGenZ
                        }
                    };
                var personPostionGenertionViewModel = new PersonPostionGenertionDataSourceViewModel()
                {
                    PersionPostionName = positionType.PositionType,
                    PersonPostionGeneration = personPostionGenertion

                };
                result.Add(personPostionGenertionViewModel);


            }

            return result;

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
                var result = _dcPersonRepository.GetAll().Where(m => (endOfYear.Year - m.DateOfBirth.GetValueOrDefault().Year) == 60)
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
                        retiredPersonView.RetiredPersonRate = Math.Round(((decimal)retiredPersonCount / (decimal)personCount) * 100, 2);
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
                        Label = "PredictionRetired" ,
                        Data = predictRetiredPersondata
                      },
                      new GraphDataSet
                      {
                        Label = "Retired" ,
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

        public object GetAllPersonnelGroupWorkDuration(int type)
        {

            var personnel = _dcPersonRepository.GetAll().OrderBy(o => o.PersonnelTypeId);
            var distinctPersonnelTypeId = personnel.Select(s => new { s.PersonnelType, s.PersonnelTypeId }).Distinct();
            if (type == 1)
            {
                var label = new List<string>();

                foreach (var personnelType in distinctPersonnelTypeId)
                {

                    label.Add(personnelType.PersonnelType);
                }

                var result = new GraphData
                {
                    GraphDataSet = this.GetPersonWorkDurationGraphDataSet(personnel),
                    Label = label
                };
                return result;
            }
            else
            {
                var list = new List<PersonGroupWorkDurationDataTableModel>();
                foreach (var personnelType in distinctPersonnelTypeId)
                {
                    var person = personnel.Where(m => m.PersonnelType == personnelType.PersonnelType && m.PersonnelTypeId == personnelType.PersonnelTypeId);
                    var personGroup = new PersonGroupWorkDurationDataTableModel
                    {
                        PersonGroupTypeId = personnelType.PersonnelTypeId,
                        PersonGroupTypeName = personnelType.PersonnelType,
                        PersonGroupWorkDuration = new List<PersonGroupWorkDurationDataTable>
                        {
                           new PersonGroupWorkDurationDataTable
                           {
                               WorkDuration = "น้อยกว่า 3 ปี",
                               Person =  person.Where(m => (DateTime.UtcNow.Year - m.StartDate.Value.Year) < 3).Count()
                           } ,
                           new PersonGroupWorkDurationDataTable
                           {
                               WorkDuration = "3 - 5 ปี",
                               Person =  person.Where(m => (DateTime.UtcNow.Year - m.StartDate.Value.Year) >= 3 && (DateTime.UtcNow.Year - m.StartDate.Value.Year) <= 5).Count()
                           },
                           new PersonGroupWorkDurationDataTable
                           {
                               WorkDuration = "6 - 9 ปี",
                               Person =  person.Where(m => (DateTime.UtcNow.Year - m.StartDate.Value.Year) >= 6 && (DateTime.UtcNow.Year - m.StartDate.Value.Year) <= 9).Count()
                            },
                            new PersonGroupWorkDurationDataTable
                           {
                               WorkDuration = "10 - 15 ปี",
                               Person =  person.Where(m => (DateTime.UtcNow.Year - m.StartDate.Value.Year) >= 10 && (DateTime.UtcNow.Year - m.StartDate.Value.Year) <= 15).Count()
                           },
                            new PersonGroupWorkDurationDataTable
                           {
                               WorkDuration = "16 - 20 ปี",
                               Person =  person.Where(m => (DateTime.UtcNow.Year - m.StartDate.Value.Year) >= 16 && (DateTime.UtcNow.Year - m.StartDate.Value.Year) <= 20).Count()
                           },
                            new PersonGroupWorkDurationDataTable
                           {
                               WorkDuration = "20 ปีขึ้นไป",
                               Person =  person.Where(m => (DateTime.UtcNow.Year - m.StartDate.Value.Year) > 20).Count()
                           }

                        }

                    };
                    list.Add(personGroup);
                }
                return list;
            }


        }

        private List<GraphDataSet> GetPersonWorkDurationGraphDataSet(IEnumerable<DC_Person> personnel)
        {

            var lessThanThree = personnel.Where(m => (DateTime.UtcNow.Year - m.StartDate.Value.Year) < 3).Select(s => new { s.PersonnelType, s.PersonnelTypeId }).OrderBy(o => o.PersonnelTypeId).Distinct();
            var dataCoutLessThanThree = new List<int>();
            var index = 0;
            foreach (var model in lessThanThree)
            {
                var count = personnel.Where(m => (DateTime.UtcNow.Year - m.StartDate.Value.Year) < 3 && m.PersonnelTypeId == model.PersonnelTypeId && m.PersonnelType == model.PersonnelType).Count();
                dataCoutLessThanThree.Add(count);
            }
            var dataLessThanThree = new GraphDataSet
            {
                Label = "น้อยกว่า 3 ปี",
                Data = dataCoutLessThanThree,
                BackgroundColor = index.BackgroundColor(),
                BorderColor = index.BorderColor()

            };
            index++;

            var threeToFive = personnel.Where(m => (DateTime.UtcNow.Year - m.StartDate.Value.Year) >= 3 && (DateTime.UtcNow.Year - m.StartDate.Value.Year) <= 5).Select(s => new { s.PersonnelType, s.PersonnelTypeId }).OrderBy(o => o.PersonnelTypeId).Distinct();
            var dataCoutThreeToFive = new List<int>();
            foreach (var model in threeToFive)
            {
                var count = personnel.Where(m => (DateTime.UtcNow.Year - m.StartDate.Value.Year) >= 3 && (DateTime.UtcNow.Year - m.StartDate.Value.Year) <= 5 && m.PersonnelTypeId == model.PersonnelTypeId && m.PersonnelType == model.PersonnelType).Count();
                dataCoutThreeToFive.Add(count);
            }
            var dataThreeToFive = new GraphDataSet
            {
                Label = "3 - 5 ปี",
                Data = dataCoutThreeToFive,
                BackgroundColor = index.BackgroundColor(),
                BorderColor = index.BorderColor()

            };
            index++;

            var sixToNine = personnel.Where(m => (DateTime.UtcNow.Year - m.StartDate.Value.Year) >= 6 && (DateTime.UtcNow.Year - m.StartDate.Value.Year) <= 9).Select(s => new { s.PersonnelType, s.PersonnelTypeId }).OrderBy(o => o.PersonnelTypeId).Distinct();
            var dataCoutSixToNine = new List<int>();
            foreach (var model in sixToNine)
            {
                var count = personnel.Where(m => (DateTime.UtcNow.Year - m.StartDate.Value.Year) >= 6 && (DateTime.UtcNow.Year - m.StartDate.Value.Year) <= 9 && m.PersonnelTypeId == model.PersonnelTypeId && m.PersonnelType == model.PersonnelType).Count();
                dataCoutSixToNine.Add(count);
            }
            var dataSixToNine = new GraphDataSet
            {
                Label = "6 - 9 ปี",
                Data = dataCoutSixToNine,
                BackgroundColor = index.BackgroundColor(),
                BorderColor = index.BorderColor()

            };
            index++;

            var tenToFifteen = personnel.Where(m => (DateTime.UtcNow.Year - m.StartDate.Value.Year) >= 10 && (DateTime.UtcNow.Year - m.StartDate.Value.Year) <= 15).Select(s => new { s.PersonnelType, s.PersonnelTypeId }).OrderBy(o => o.PersonnelTypeId).Distinct();
            var dataCoutTenToFifteen = new List<int>();
            foreach (var model in tenToFifteen)
            {
                var count = personnel.Where(m => (DateTime.UtcNow.Year - m.StartDate.Value.Year) >= 10 && (DateTime.UtcNow.Year - m.StartDate.Value.Year) <= 15 && m.PersonnelTypeId == model.PersonnelTypeId && m.PersonnelType == model.PersonnelType).Count();
                dataCoutTenToFifteen.Add(count);
            }
            var dataTenToFifteen = new GraphDataSet
            {
                Label = "10 - 15 ปี",
                Data = dataCoutTenToFifteen,
                BackgroundColor = index.BackgroundColor(),
                BorderColor = index.BorderColor()

            };
            index++;

            var sixteenToTwenty = personnel.Where(m => (DateTime.UtcNow.Year - m.StartDate.Value.Year) >= 16 && (DateTime.UtcNow.Year - m.StartDate.Value.Year) <= 20).Select(s => new { s.PersonnelType, s.PersonnelTypeId }).OrderBy(o => o.PersonnelTypeId).Distinct();
            var dataCoutSixteenToTwenty = new List<int>();
            foreach (var model in sixteenToTwenty)
            {
                var count = personnel.Where(m => (DateTime.UtcNow.Year - m.StartDate.Value.Year) >= 16 && (DateTime.UtcNow.Year - m.StartDate.Value.Year) <= 20 && m.PersonnelTypeId == model.PersonnelTypeId && m.PersonnelType == model.PersonnelType).Count();
                dataCoutSixteenToTwenty.Add(count);
            }
            var dataSixteenToTwenty = new GraphDataSet
            {
                Label = "16 - 20 ปี",
                Data = dataCoutSixteenToTwenty,
                BackgroundColor = index.BackgroundColor(),
                BorderColor = index.BorderColor()

            };
            index++;
            var morethanTwenty = personnel.Where(m => (DateTime.UtcNow.Year - m.StartDate.Value.Year) > 20).Select(s => new { s.PersonnelType, s.PersonnelTypeId }).OrderBy(o => o.PersonnelTypeId).Distinct();
            var dataCoutMorethanTwenty = new List<int>();
            foreach (var model in morethanTwenty)
            {
                var count = personnel.Where(m => (DateTime.UtcNow.Year - m.StartDate.Value.Year) > 20 && m.PersonnelTypeId == model.PersonnelTypeId && m.PersonnelType == model.PersonnelType).Count();
                dataCoutMorethanTwenty.Add(count);
            }
            var dataMorethanTwenty = new GraphDataSet
            {
                Label = "20 ปีขึ้นไป",
                Data = dataCoutMorethanTwenty,
                BackgroundColor = index.BackgroundColor(),
                BorderColor = index.BorderColor()

            };
            var listGraphDataSet = new List<GraphDataSet> {
            dataLessThanThree,
            dataThreeToFive,
            dataSixToNine,
            dataTenToFifteen,
            dataSixteenToTwenty,
            dataMorethanTwenty
            };

            return listGraphDataSet;
        }

        public List<PersonGroupWorkDurationDataSourceModel> GetAllPersonnelGroupWorkDurationDataSource()
        {

            var personnel = _dcPersonRepository.GetAll().OrderBy(o => o.PersonnelTypeId);

            var distinctPersonnelTypeId = personnel.Select(s => new { s.PersonnelType, s.PersonnelTypeId }).Distinct();

            var list = new List<PersonGroupWorkDurationDataSourceModel>();
            foreach (var personnelType in distinctPersonnelTypeId)
            {
                var personData = personnel.Where(m => m.PersonnelType == personnelType.PersonnelType && m.PersonnelTypeId == personnelType.PersonnelTypeId)
                   .Select(s => new PersonnelDataSourceViewModel
                   {
                       AdminPosition = s.AdminPosition,
                       AdminPositionType = s.AdminPositionType,
                       BloodType = s.BloodType,
                       Country = s.Country,
                       DateOfBirth = s.DateOfBirth,
                       Division = s.Division,
                       Education = s.Education,
                       EducationLevel = s.EducationLevel,
                       Faculty = s.Faculty,
                       Gender = s.Gender,
                       GraduateDate = s.GraduateDate,
                       IdCard = s.IdCard,
                       Major = s.Major,
                       Nation = s.Nation,
                       PersonName = string.Format("{0} {1} {2}", s.TitleName, s.FirstName, s.LastName),
                       PersonnelId = s.PersonnelId,
                       PersonnelType = s.PersonnelType,
                       Position = s.Position,
                       PositionLevel = s.PositionLevel,
                       PositionType = s.PositionType,
                       Province = s.Province,
                       RetiredDate = s.RetiredDate,
                       RetiredYear = s.RetiredYear,
                       Salary = s.Salary,
                       Section = s.Section,
                       StartDate = s.StartDate,
                       StartEducationDate = s.StartEducationDate,
                       TitleEducation = s.TitleEducation,
                       University = s.University,
                       ZipCode = s.ZipCode

                   });
                var personGroup = new PersonGroupWorkDurationDataSourceModel
                {

                    PersonGroupTypeId = personnelType.PersonnelTypeId,
                    PersonGroupTypeName = personnelType.PersonnelType,
                    PersonGroupWorkDuration = new List<PersonGroupWorkDurationDataSource>
                    {
                            new PersonGroupWorkDurationDataSource
                           {
                               WorkDuration = "น้อยกว่า 3 ปี",
                               Person =  personData.Where(m => (DateTime.UtcNow.Year - m.StartDate.Value.Year) < 3).ToList()
                           } ,
                           new PersonGroupWorkDurationDataSource
                           {
                               WorkDuration = "3 - 5 ปี",
                               Person =  personData.Where(m => (DateTime.UtcNow.Year - m.StartDate.Value.Year) >= 3 && (DateTime.UtcNow.Year - m.StartDate.Value.Year) <= 5).ToList()
                           },
                           new PersonGroupWorkDurationDataSource
                           {
                               WorkDuration = "6 - 9 ปี",
                               Person =  personData.Where(m => (DateTime.UtcNow.Year - m.StartDate.Value.Year) >= 6 && (DateTime.UtcNow.Year - m.StartDate.Value.Year) <= 9).ToList()
                            },
                            new PersonGroupWorkDurationDataSource
                           {
                               WorkDuration = "10 - 15 ปี",
                               Person =  personData.Where(m => (DateTime.UtcNow.Year - m.StartDate.Value.Year) >= 10 && (DateTime.UtcNow.Year - m.StartDate.Value.Year) <= 15).ToList()
                           },
                            new PersonGroupWorkDurationDataSource
                           {
                               WorkDuration = "16 - 20 ปี",
                               Person =  personData.Where(m => (DateTime.UtcNow.Year - m.StartDate.Value.Year) >= 16 && (DateTime.UtcNow.Year - m.StartDate.Value.Year) <= 20).ToList()
                           },
                            new PersonGroupWorkDurationDataSource
                           {
                               WorkDuration = "20 ปีขึ้นไป",
                               Person =  personData.Where(m => (DateTime.UtcNow.Year - m.StartDate.Value.Year) > 20).ToList()
                           }
                    }
                };
                list.Add(personGroup);
            }

            return list;



        }

        public List<PersonnelDataSourceViewModel> GetAllPersonnelGroupWorkDurationDataSourceByType(string personGroupType, string personGroupTypeId, int type)
        {

            var personnel = _dcPersonRepository.GetAll().Where(m => m.PersonnelType == personGroupType && m.PersonnelTypeId == personGroupTypeId);

            switch (type)
            {
                case 0:
                    personnel = personnel.Where(m => (DateTime.UtcNow.Year - m.StartDate.Value.Year) < 3);
                    break;
                case 1:
                    personnel = personnel.Where(m => (DateTime.UtcNow.Year - m.StartDate.Value.Year) >= 3 && (DateTime.UtcNow.Year - m.StartDate.Value.Year) <= 5);
                    break;
                case 2:
                    personnel = personnel.Where(m => (DateTime.UtcNow.Year - m.StartDate.Value.Year) >= 6 && (DateTime.UtcNow.Year - m.StartDate.Value.Year) <= 9);
                    break;
                case 3:
                    personnel = personnel.Where(m => (DateTime.UtcNow.Year - m.StartDate.Value.Year) >= 10 && (DateTime.UtcNow.Year - m.StartDate.Value.Year) <= 15);
                    break;
                case 4:
                    personnel = personnel.Where(m => (DateTime.UtcNow.Year - m.StartDate.Value.Year) >= 16 && (DateTime.UtcNow.Year - m.StartDate.Value.Year) <= 20);
                    break;
                case 5:
                    personnel = personnel.Where(m => (DateTime.UtcNow.Year - m.StartDate.Value.Year) > 20);
                    break;
            }
            var personData = personnel
               .Select(s => new PersonnelDataSourceViewModel
               {
                   AdminPosition = s.AdminPosition,
                   AdminPositionType = s.AdminPositionType,
                   BloodType = s.BloodType,
                   Country = s.Country,
                   DateOfBirth = s.DateOfBirth,
                   Division = s.Division,
                   Education = s.Education,
                   EducationLevel = s.EducationLevel,
                   Faculty = s.Faculty,
                   Gender = s.Gender,
                   GraduateDate = s.GraduateDate,
                   IdCard = s.IdCard,
                   Major = s.Major,
                   Nation = s.Nation,
                   PersonName = string.Format("{0} {1} {2}", s.TitleName, s.FirstName, s.LastName),
                   PersonnelId = s.PersonnelId,
                   PersonnelType = s.PersonnelType,
                   Position = s.Position,
                   PositionLevel = s.PositionLevel,
                   PositionType = s.PositionType,
                   Province = s.Province,
                   RetiredDate = s.RetiredDate,
                   RetiredYear = s.RetiredYear,
                   Salary = s.Salary,
                   Section = s.Section,
                   StartDate = s.StartDate,
                   StartEducationDate = s.StartEducationDate,
                   TitleEducation = s.TitleEducation,
                   University = s.University,
                   ZipCode = s.ZipCode

               }).ToList();

            return personData;

        }

        public object GetAllPersonGroupAdminPositionType(int type)
        {
            var personnel = _dcPersonRepository.GetAll().OrderBy(o => o.AdminPositionType);
            if (type == 1)
            {

                var label = new List<string>();
                var distinctPersonnelType = personnel.Select(s => new { s.PersonnelTypeId, s.PersonnelType }).Distinct();
                var graphDatasetList = new List<GraphDataSet>();

                var index = 0;
                foreach (var p in distinctPersonnelType)
                {
                    var data = new List<int>();
                    var adminPositionTypeByPersonnelType = personnel.Where(m => m.PersonnelType == p.PersonnelType && m.PersonnelTypeId == p.PersonnelTypeId);
                    var distinctAdminPositionTypeByPersonnelType = adminPositionTypeByPersonnelType.Select(s => s.AdminPositionType).Distinct();

                    foreach (var ap in distinctAdminPositionTypeByPersonnelType)
                    {
                        data.Add(adminPositionTypeByPersonnelType.Where(m => m.AdminPositionType == ap).Count());
                        label.Add(ap);
                    }
                    var graphDataset = new GraphDataSet
                    {
                        Label = p.PersonnelType,
                        Data = data,
                        BackgroundColor = index.BackgroundColor(),
                        BorderColor = index.BorderColor()


                    };
                    graphDatasetList.Add(graphDataset);
                    index++;
                }
                var graphData = new GraphData
                {
                    Label = label.Distinct().ToList(),
                    GraphDataSet = graphDatasetList
                };

                return graphData;

            }
            else
            {
                var adminPositionType = personnel.Select(s => s.AdminPositionType).Distinct();
                var datatableList = new List<PersonGroupAdminPositionDataTableModel>();
                foreach (var ap in adminPositionType)
                {

                    var personnelType = personnel.Where(m => m.AdminPositionType == ap);
                    var distinctPersonnelType = personnelType.Select(s => new { s.PersonnelTypeId, s.PersonnelType }).Distinct();
                    var dataList = new List<PersonGroupAdminPositionDataTable>();
                    foreach (var p in distinctPersonnelType)
                    {
                        var data = new PersonGroupAdminPositionDataTable
                        {
                            PersonGroupTypeId = p.PersonnelTypeId,
                            PersonGroupTypeName = p.PersonnelType,
                            Person = personnelType.Where(m => m.PersonnelType == p.PersonnelType && m.PersonnelTypeId == p.PersonnelTypeId).Count()
                        };
                        dataList.Add(data);

                    }
                    var dataTable = new PersonGroupAdminPositionDataTableModel
                    {
                        AdminPositionType = ap,
                        PersonGroupAdminPosition = dataList
                    };
                    datatableList.Add(dataTable);

                }

                return datatableList;
            }
        }
        public List<PersonGroupAdminPositionDataSourceModel> GetAllPersonGroupAdminPositionTypeDataSource()
        {
            var personnel = _dcPersonRepository.GetAll().OrderBy(o => o.AdminPositionType);
            var adminPositionTypeBy = personnel.Select(s => s.AdminPositionType).Distinct();
            var datatableList = new List<PersonGroupAdminPositionDataSourceModel>();
            foreach (var ap in adminPositionTypeBy)
            {

                var personnelType = personnel.Where(m => m.AdminPositionType == ap);
                var distinctPersonnelType = personnelType.Select(s => new { s.PersonnelTypeId, s.PersonnelType }).Distinct();
                var dataList = new List<PersonGroupAdminPositionDataSource>();
                foreach (var p in distinctPersonnelType)
                {
                    var data = new PersonGroupAdminPositionDataSource
                    {
                        PersonGroupTypeId = p.PersonnelTypeId,
                        PersonGroupTypeName = p.PersonnelType,
                        Person = personnelType.Where(m => m.PersonnelType == p.PersonnelType && m.PersonnelTypeId == p.PersonnelTypeId)
                         .Select(s => new PersonnelDataSourceViewModel
                         {
                             AdminPosition = s.AdminPosition,
                             AdminPositionType = s.AdminPositionType,
                             BloodType = s.BloodType,
                             Country = s.Country,
                             DateOfBirth = s.DateOfBirth,
                             Division = s.Division,
                             Education = s.Education,
                             EducationLevel = s.EducationLevel,
                             Faculty = s.Faculty,
                             Gender = s.Gender,
                             GraduateDate = s.GraduateDate,
                             IdCard = s.IdCard,
                             Major = s.Major,
                             Nation = s.Nation,
                             PersonName = string.Format("{0} {1} {2}", s.TitleName, s.FirstName, s.LastName),
                             PersonnelId = s.PersonnelId,
                             PersonnelType = s.PersonnelType,
                             Position = s.Position,
                             PositionLevel = s.PositionLevel,
                             PositionType = s.PositionType,
                             Province = s.Province,
                             RetiredDate = s.RetiredDate,
                             RetiredYear = s.RetiredYear,
                             Salary = s.Salary,
                             Section = s.Section,
                             StartDate = s.StartDate,
                             StartEducationDate = s.StartEducationDate,
                             TitleEducation = s.TitleEducation,
                             University = s.University,
                             ZipCode = s.ZipCode

                         }).ToList()
                    };
                    dataList.Add(data);

                }
                var dataTable = new PersonGroupAdminPositionDataSourceModel
                {
                    AdminPositionType = ap,
                    PersonGroupAdminPosition = dataList
                };
                datatableList.Add(dataTable);

            }

            return datatableList;
        }

        public object GetAllPersonGroupFaculty(int type)
        {
            var personnel = _dcPersonRepository.GetAll().OrderBy(o => o.FacultyId);
            if (type == 1)
            {

                var label = new List<string>();
                var distinctPersonnelType = personnel.Select(s => new { s.PersonnelTypeId, s.PersonnelType }).Distinct();
                var graphDatasetList = new List<GraphDataSet>();
                var index = 0;
                foreach (var p in distinctPersonnelType)
                {
                    var data = new List<int>();
                    var facultyByPersonnelType = personnel.Where(m => m.PersonnelType == p.PersonnelType && m.PersonnelTypeId == p.PersonnelTypeId);
                    var distinctfacultyByPersonnelType = facultyByPersonnelType.Select(s => new { s.FacultyId, s.Faculty }).Distinct();

                    foreach (var fc in distinctfacultyByPersonnelType)
                    {
                        data.Add(facultyByPersonnelType.Where(m => m.Faculty == fc.Faculty && m.FacultyId == fc.FacultyId).Count());
                        label.Add(fc.Faculty);
                    }
                    var graphDataset = new GraphDataSet
                    {
                        Label = p.PersonnelType,
                        Data = data,
                        BackgroundColor = index.BackgroundColor(),
                        BorderColor = index.BorderColor()

                    };
                    graphDatasetList.Add(graphDataset);
                    index++;
                }
                var graphData = new GraphData
                {
                    Label = label.Distinct().ToList(),
                    GraphDataSet = graphDatasetList
                };

                return graphData;

            }
            else
            {
                var facultyByPersonnelType = personnel.Select(s => new { s.Faculty, s.FacultyId }).Distinct();
                var datatableList = new List<PersonGroupFacultyDataTableModel>();
                foreach (var fc in facultyByPersonnelType)
                {

                    var personnelType = personnel.Where(m => m.Faculty == fc.Faculty && m.FacultyId == fc.FacultyId);
                    var distinctPersonnelType = personnelType.Select(s => new { s.PersonnelTypeId, s.PersonnelType }).Distinct();
                    var dataList = new List<PersonGroupFacultyDataTable>();
                    foreach (var p in distinctPersonnelType)
                    {
                        var data = new PersonGroupFacultyDataTable
                        {
                            PersonGroupTypeId = p.PersonnelTypeId,
                            PersonGroupTypeName = p.PersonnelType,
                            Person = personnelType.Where(m => m.PersonnelType == p.PersonnelType && m.PersonnelTypeId == p.PersonnelTypeId).Count()
                        };
                        dataList.Add(data);

                    }
                    var dataTable = new PersonGroupFacultyDataTableModel
                    {
                        FacultyId = fc.FacultyId,
                        Faculty = fc.Faculty,
                        PersonGroupFaculty = dataList
                    };
                    datatableList.Add(dataTable);

                }

                return datatableList;
            }
        }

        public List<PersonGroupFacultyDataSourceModel> GetAllPersonGroupFacultyDataSource()
        {
            var personnel = _dcPersonRepository.GetAll().OrderBy(o => o.FacultyId);
            var facultyByPersonnelType = personnel.Select(s => new { s.Faculty, s.FacultyId }).Distinct();
            var datatableList = new List<PersonGroupFacultyDataSourceModel>();
            foreach (var fc in facultyByPersonnelType)
            {

                var personnelType = personnel.Where(m => m.Faculty == fc.Faculty && m.FacultyId == fc.FacultyId);
                var distinctPersonnelType = personnelType.Select(s => new { s.PersonnelTypeId, s.PersonnelType }).Distinct();
                var dataList = new List<PersonGroupFacultyDataSource>();
                foreach (var p in distinctPersonnelType)
                {
                    var data = new PersonGroupFacultyDataSource
                    {
                        PersonGroupTypeId = p.PersonnelTypeId,
                        PersonGroupTypeName = p.PersonnelType,
                        Person = personnelType.Where(m => m.PersonnelType == p.PersonnelType && m.PersonnelTypeId == p.PersonnelTypeId)
                        .Select(s => new PersonnelDataSourceViewModel
                        {
                            AdminPosition = s.AdminPosition,
                            AdminPositionType = s.AdminPositionType,
                            BloodType = s.BloodType,
                            Country = s.Country,
                            DateOfBirth = s.DateOfBirth,
                            Division = s.Division,
                            Education = s.Education,
                            EducationLevel = s.EducationLevel,
                            Faculty = s.Faculty,
                            Gender = s.Gender,
                            GraduateDate = s.GraduateDate,
                            IdCard = s.IdCard,
                            Major = s.Major,
                            Nation = s.Nation,
                            PersonName = string.Format("{0} {1} {2}", s.TitleName, s.FirstName, s.LastName),
                            PersonnelId = s.PersonnelId,
                            PersonnelType = s.PersonnelType,
                            Position = s.Position,
                            PositionLevel = s.PositionLevel,
                            PositionType = s.PositionType,
                            Province = s.Province,
                            RetiredDate = s.RetiredDate,
                            RetiredYear = s.RetiredYear,
                            Salary = s.Salary,
                            Section = s.Section,
                            StartDate = s.StartDate,
                            StartEducationDate = s.StartEducationDate,
                            TitleEducation = s.TitleEducation,
                            University = s.University,
                            ZipCode = s.ZipCode

                        }).ToList()
                    };
                    dataList.Add(data);

                }
                var dataTable = new PersonGroupFacultyDataSourceModel
                {
                    FacultyId = fc.FacultyId,
                    Faculty = fc.Faculty,
                    PersonGroupFaculty = dataList
                };
                datatableList.Add(dataTable);

            }

            return datatableList;
        }

        public object GetAllPersonPositionFaculty(int type)
        {
            var personnel = _dcPersonRepository.GetAll().OrderBy(o => o.FacultyId);
            if (type == 1)
            {

                var label = new List<string>();
                var distinctPersonPosition = personnel.Select(s => s.Position).Distinct();
                var graphDatasetList = new List<GraphDataSet>();
                var index = 0;
                foreach (var position in distinctPersonPosition)
                {
                    var data = new List<int>();
                    var facultyByPosition = personnel.Where(m => m.Position == position);
                    var distinctFacultyByPosition = facultyByPosition.Select(s => new { s.FacultyId, s.Faculty }).Distinct();

                    foreach (var fp in distinctFacultyByPosition)
                    {
                        data.Add(facultyByPosition.Where(m => m.Faculty == fp.Faculty && m.FacultyId == fp.FacultyId).Count());
                        label.Add(fp.Faculty);
                    }
                    var graphDataset = new GraphDataSet
                    {
                        Label = position,
                        Data = data,
                        BackgroundColor = index.BackgroundColor(),
                        BorderColor = index.BorderColor()

                    };
                    graphDatasetList.Add(graphDataset);
                    index++;
                }
                var graphData = new GraphData
                {
                    Label = label.Distinct().ToList(),
                    GraphDataSet = graphDatasetList
                };

                return graphData;

            }
            else
            {
                var facultyByPersonnelType = personnel.Select(s => new { s.Faculty, s.FacultyId }).Distinct();
                var datatableList = new List<PersonPositionFacultyDataTableModel>();
                foreach (var fc in facultyByPersonnelType)
                {

                    var personnelType = personnel.Where(m => m.Faculty == fc.Faculty && m.FacultyId == fc.FacultyId);
                    var distinctPosition = personnelType.Select(s => s.Position).Distinct();
                    var dataList = new List<PersonPositionFacultyDataTable>();
                    foreach (var position in distinctPosition)
                    {
                        var data = new PersonPositionFacultyDataTable
                        {
                            PersonPosition = position,
                            Person = personnelType.Where(m => m.Position == position).Count()
                        };
                        dataList.Add(data);

                    }
                    var dataTable = new PersonPositionFacultyDataTableModel
                    {
                        FacultyId = fc.FacultyId,
                        Faculty = fc.Faculty,
                        PersonPositionFaculty = dataList
                    };
                    datatableList.Add(dataTable);

                }

                return datatableList;
            }
        }

        public List<PersonPositionFacultyDataSourceModel> GetAllPersonPositionFacultyDataSource()
        {
            var personnel = _dcPersonRepository.GetAll().OrderBy(o => o.FacultyId);
            var facultyByPersonnelType = personnel.Select(s => new { s.Faculty, s.FacultyId }).Distinct();
            var datatableList = new List<PersonPositionFacultyDataSourceModel>();
            foreach (var fc in facultyByPersonnelType)
            {

                var personnelType = personnel.Where(m => m.Faculty == fc.Faculty && m.FacultyId == fc.FacultyId);
                var distinctPosition = personnelType.Select(s => s.Position).Distinct();
                var dataList = new List<PersonPosiotionFacultyDataSource>();
                foreach (var position in distinctPosition)
                {
                    var data = new PersonPosiotionFacultyDataSource
                    {
                        PersonPosition = position,
                        Person = personnelType.Where(m => m.Position == position)
                        .Select(s => new PersonnelDataSourceViewModel
                        {
                            AdminPosition = s.AdminPosition,
                            AdminPositionType = s.AdminPositionType,
                            BloodType = s.BloodType,
                            Country = s.Country,
                            DateOfBirth = s.DateOfBirth,
                            Division = s.Division,
                            Education = s.Education,
                            EducationLevel = s.EducationLevel,
                            Faculty = s.Faculty,
                            Gender = s.Gender,
                            GraduateDate = s.GraduateDate,
                            IdCard = s.IdCard,
                            Major = s.Major,
                            Nation = s.Nation,
                            PersonName = string.Format("{0} {1} {2}", s.TitleName, s.FirstName, s.LastName),
                            PersonnelId = s.PersonnelId,
                            PersonnelType = s.PersonnelType,
                            Position = s.Position,
                            PositionLevel = s.PositionLevel,
                            PositionType = s.PositionType,
                            Province = s.Province,
                            RetiredDate = s.RetiredDate,
                            RetiredYear = s.RetiredYear,
                            Salary = s.Salary,
                            Section = s.Section,
                            StartDate = s.StartDate,
                            StartEducationDate = s.StartEducationDate,
                            TitleEducation = s.TitleEducation,
                            University = s.University,
                            ZipCode = s.ZipCode

                        }).ToList()
                    };
                    dataList.Add(data);

                }
                var dataTable = new PersonPositionFacultyDataSourceModel
                {
                    FacultyId = fc.FacultyId,
                    Faculty = fc.Faculty,
                    PersonPositionFaculty = dataList
                };
                datatableList.Add(dataTable);

            }

            return datatableList;
        }

        public object GetAllPersonGroupRetiredYear(RetiredGraphInputDto input)
        {
            var personnel = _dcPersonRepository.GetAll().Where(m =>input.StartDate != null && input.EndDate !=null ?  
            m.RetiredDate >= input.StartDate.ToUtcDateTime() && m.RetiredDate <= input.EndDate.ToUtcDateTime() &&
            m.RetiredYear >= input.StartDate.ToUtcRetiredYear() && m.RetiredYear <= input.EndDate.ToUtcRetiredYear()
            : m.RetiredYear <= DateTime.UtcNow.Year).OrderBy(o => o.RetiredYear);
            if (input.Type == 1)
            {
                var distinctPersonnelType = personnel.Select(s => new { s.PersonnelTypeId, s.PersonnelType }).Distinct();

                var label = personnel.Select(s => s.RetiredYear.Value.ToLocalYear().ToString()).Distinct();

                var graphDatasetList = new List<GraphDataSet>();
                var index = 0;
                foreach (var p in distinctPersonnelType)
                {
                    var data = new List<int>();
                    var retiredYearByPersonnelType = personnel.Where(m => m.PersonnelType == p.PersonnelType && m.PersonnelTypeId == p.PersonnelTypeId);
                    var distinctretiredYearByPersonnelType = personnel.Select(s => s.RetiredYear).Distinct();
                    foreach (var ry in distinctretiredYearByPersonnelType)
                    {
                        data.Add(retiredYearByPersonnelType.Where(m => m.RetiredYear == ry).Count());
                    }
                    var graphDataset = new GraphDataSet
                    {
                        Label = p.PersonnelType,
                        Data = data,
                        BackgroundColor = index.BackgroundColor(),
                        BorderColor = index.BorderColor()

                    };
                    graphDatasetList.Add(graphDataset);
                    index++;
                }
                var graphData = new GraphData
                {
                    Label = label.ToList(),
                    GraphDataSet = graphDatasetList
                };

                return graphData;

            }
            else
            {
                var distinctretiredYear = personnel.Select(s => s.RetiredYear).Distinct();
                var datatableList = new List<PersonGroupRetiredYearDataTableModel>();
                foreach (var ry in distinctretiredYear)
                {

                    var personnelType = personnel.Where(m => m.RetiredYear == ry);
                    var distinctPersonnelType = personnelType.Select(s => new { s.PersonnelTypeId, s.PersonnelType }).Distinct();
                    var dataList = new List<PersonGroupRetiredYearDataTable>();
                    foreach (var p in distinctPersonnelType)
                    {
                        var data = new PersonGroupRetiredYearDataTable
                        {
                            PersonGroupTypeId = p.PersonnelTypeId,
                            PersonGroupTypeName = p.PersonnelType,
                            Person = personnelType.Where(m => m.PersonnelType == p.PersonnelType && m.PersonnelTypeId == p.PersonnelTypeId).Count()
                        };
                        dataList.Add(data);

                    }
                    var dataTable = new PersonGroupRetiredYearDataTableModel
                    {
                        ReitredYear = ry.Value.ToLocalYear(),
                        PersonGroupRetiredYear = dataList
                    };
                    datatableList.Add(dataTable);

                }

                return datatableList;
            }
        }

        public List<PersonGroupRetiredYearDataSourceModel> GetAllPersonGroupRetiredYearDataSource(RetiredInputDto input)
        {
            var personnel = _dcPersonRepository.GetAll().Where(m => input.StartDate != null && input.EndDate != null ?
                        m.RetiredDate >= input.StartDate.ToUtcDateTime() && m.RetiredDate <= input.EndDate.ToUtcDateTime() &&
                        m.RetiredYear >= input.StartDate.ToUtcRetiredYear() && m.RetiredYear <= input.EndDate.ToUtcRetiredYear()
                        : m.RetiredYear <= DateTime.UtcNow.Year).OrderBy(o => o.RetiredYear);

            var distinctretiredYear = personnel.Select(s => s.RetiredYear).Distinct();
            var datatableList = new List<PersonGroupRetiredYearDataSourceModel>();
            foreach (var ry in distinctretiredYear)
            {

                var personnelType = personnel.Where(m => m.RetiredYear == ry);
                var distinctPersonnelType = personnelType.Select(s => new { s.PersonnelTypeId, s.PersonnelType }).Distinct();
                var dataList = new List<PersonGroupRetiredYearDataSource>();
                foreach (var p in distinctPersonnelType)
                {
                    var data = new PersonGroupRetiredYearDataSource
                    {
                        PersonGroupTypeId = p.PersonnelTypeId,
                        PersonGroupTypeName = p.PersonnelType,
                        Person = personnelType.Where(m => m.PersonnelType == p.PersonnelType && m.PersonnelTypeId == p.PersonnelTypeId)
                         .Select(s => new PersonnelDataSourceViewModel
                         {
                             AdminPosition = s.AdminPosition,
                             AdminPositionType = s.AdminPositionType,
                             BloodType = s.BloodType,
                             Country = s.Country,
                             DateOfBirth = s.DateOfBirth,
                             Division = s.Division,
                             Education = s.Education,
                             EducationLevel = s.EducationLevel,
                             Faculty = s.Faculty,
                             Gender = s.Gender,
                             GraduateDate = s.GraduateDate,
                             IdCard = s.IdCard,
                             Major = s.Major,
                             Nation = s.Nation,
                             PersonName = string.Format("{0} {1} {2}", s.TitleName, s.FirstName, s.LastName),
                             PersonnelId = s.PersonnelId,
                             PersonnelType = s.PersonnelType,
                             Position = s.Position,
                             PositionLevel = s.PositionLevel,
                             PositionType = s.PositionType,
                             Province = s.Province,
                             RetiredDate = s.RetiredDate,
                             RetiredYear = s.RetiredYear,
                             Salary = s.Salary,
                             Section = s.Section,
                             StartDate = s.StartDate,
                             StartEducationDate = s.StartEducationDate,
                             TitleEducation = s.TitleEducation,
                             University = s.University,
                             ZipCode = s.ZipCode

                         }).ToList()
                    };
                    dataList.Add(data);

                }
                var dataTable = new PersonGroupRetiredYearDataSourceModel
                {
                    ReitredYear = ry.Value.ToLocalYear(),
                    PersonGroupRetiredYear = dataList
                };
                datatableList.Add(dataTable);

            }

            return datatableList;
        }

        public object GetAllPersonGroupPositionLevel(int type)
        {
            var personnel = _dcPersonRepository.GetAll().Where(m => m.PositionTypeId == "ค" && m.PositionType == "ประเภทสนับสนุน").OrderBy(o => o.PersonnelId);
            if (type == 1)
            {

                var label = new List<string>();
                var distinctPositionLevel = personnel.Select(s => new { s.PositionLevelId, s.PositionLevel }).Distinct();
                var graphDatasetList = new List<GraphDataSet>();
                var index = 0;
                foreach (var pl in distinctPositionLevel)
                {
                    var data = new List<int>();
                    var personnelTypeByPositionLevel = personnel.Where(m => m.PositionLevelId == pl.PositionLevelId && m.PositionLevel == pl.PositionLevel);
                    var distinctPersonnelTypeByPositionLevel = personnelTypeByPositionLevel.Select(s => new { s.PersonnelType, s.PersonnelTypeId }).Distinct();

                    foreach (var pp in distinctPersonnelTypeByPositionLevel)
                    {
                        data.Add(personnelTypeByPositionLevel.Where(m => m.PersonnelTypeId == pp.PersonnelTypeId && m.PersonnelType == pp.PersonnelType).Count());
                        label.Add(pp.PersonnelType);
                    }
                    var graphDataset = new GraphDataSet
                    {
                        Label = pl.PositionLevel,
                        Data = data,
                        BackgroundColor = index.BackgroundColor(),
                        BorderColor = index.BorderColor()

                    };
                    graphDatasetList.Add(graphDataset);
                    index++;
                }
                var graphData = new GraphData
                {
                    Label = label.Distinct().ToList(),
                    GraphDataSet = graphDatasetList
                };

                return graphData;

            }
            else
            {
                var distinctPersonnelType = personnel.Select(s => new { s.PersonnelType, s.PersonnelTypeId }).Distinct();
                var datatableList = new List<PersonGroupPositionLevelDataTableModel>();
                foreach (var pt in distinctPersonnelType)
                {

                    var positionLevelByPersonnelType = personnel.Where(m => m.PersonnelTypeId == pt.PersonnelTypeId && m.PersonnelType == pt.PersonnelType);
                    var distinctPositionLevelByPersonnelType = positionLevelByPersonnelType.Select(s => new { s.PositionLevelId, s.PositionLevel }).Distinct();
                    var dataList = new List<PersonGroupPositionLevelDataTable>();
                    foreach (var pp in distinctPositionLevelByPersonnelType)
                    {
                        var data = new PersonGroupPositionLevelDataTable
                        {
                            PositionLevelId = pp.PositionLevelId,
                            PositionLevel = pp.PositionLevel,
                            Person = positionLevelByPersonnelType.Where(m => m.PositionLevelId == pp.PositionLevelId && m.PositionLevel == pp.PositionLevel).Count()
                        };
                        dataList.Add(data);

                    }
                    var dataTable = new PersonGroupPositionLevelDataTableModel
                    {
                        PersonGroupTypeId = pt.PersonnelTypeId,
                        PersonGroupTypeName = pt.PersonnelType,
                        PersonGroupPosition = dataList
                    };
                    datatableList.Add(dataTable);

                }

                return datatableList;
            }
        }

        public List<PersonGroupPositionLevelDataSourceModel> GetAllPersonGroupPositionLevelDataSource()
        {
            var personnel = _dcPersonRepository.GetAll().Where(m => m.PositionTypeId == "ค" && m.PositionType == "ประเภทสนับสนุน").OrderBy(o => o.PersonnelId);
            var distinctPersonnelType = personnel.Select(s => new { s.PersonnelType, s.PersonnelTypeId }).Distinct();
            var datatableList = new List<PersonGroupPositionLevelDataSourceModel>();
            foreach (var pt in distinctPersonnelType)
            {

                var positionLevelByPersonnelType = personnel.Where(m => m.PersonnelTypeId == pt.PersonnelTypeId && m.PersonnelType == pt.PersonnelType);
                var distinctPositionLevelByPersonnelType = positionLevelByPersonnelType.Select(s => new { s.PositionLevelId, s.PositionLevel }).Distinct();
                var dataList = new List<PersonGroupPositionLevelDataSource>();
                foreach (var pp in distinctPositionLevelByPersonnelType)
                {
                    var data = new PersonGroupPositionLevelDataSource
                    {
                        PositionLevelId = pp.PositionLevelId,
                        PositionLevel = pp.PositionLevel,
                        Person = positionLevelByPersonnelType.Where(m => m.PositionLevelId == pp.PositionLevelId && m.PositionLevel == pp.PositionLevel)
                         .Select(s => new PersonnelDataSourceViewModel
                         {
                             AdminPosition = s.AdminPosition,
                             AdminPositionType = s.AdminPositionType,
                             BloodType = s.BloodType,
                             Country = s.Country,
                             DateOfBirth = s.DateOfBirth,
                             Division = s.Division,
                             Education = s.Education,
                             EducationLevel = s.EducationLevel,
                             Faculty = s.Faculty,
                             Gender = s.Gender,
                             GraduateDate = s.GraduateDate,
                             IdCard = s.IdCard,
                             Major = s.Major,
                             Nation = s.Nation,
                             PersonName = string.Format("{0} {1} {2}", s.TitleName, s.FirstName, s.LastName),
                             PersonnelId = s.PersonnelId,
                             PersonnelType = s.PersonnelType,
                             Position = s.Position,
                             PositionLevel = s.PositionLevel,
                             PositionType = s.PositionType,
                             Province = s.Province,
                             RetiredDate = s.RetiredDate,
                             RetiredYear = s.RetiredYear,
                             Salary = s.Salary,
                             Section = s.Section,
                             StartDate = s.StartDate,
                             StartEducationDate = s.StartEducationDate,
                             TitleEducation = s.TitleEducation,
                             University = s.University,
                             ZipCode = s.ZipCode

                         }).ToList()
                    };
                    dataList.Add(data);

                }
                var dataTable = new PersonGroupPositionLevelDataSourceModel
                {
                    PersonGroupTypeId = pt.PersonnelTypeId,
                    PersonGroupTypeName = pt.PersonnelType,
                    PersonGroupPosition = dataList
                };
                datatableList.Add(dataTable);

            }

            return datatableList;
        }

        public object GetAllPersonnelPositionEducation(int type)
        {
            var personnel = _dcPersonRepository.GetAll();

            var distinctPosition = personnel.Select(s => new { s.PositionType, s.PositionTypeId }).Distinct();
            
            if (type == 1)
            {
                var label = new List<string>();
                var data = new List<int>();
                var listViewData = new List<ViewData>();

                foreach (var positionType in distinctPosition)
                {
                    var educate = new List<string>() { "ปริญญาเอก", "ปริญญาตรี", "ปริญญาโท" };
                    var personPosition = personnel.Where(m => m.PositionType == positionType.PositionType && m.PositionTypeId == m.PositionTypeId
                    && educate.Contains(m.EducationLevel));
                    label.Add(positionType.PositionType);
                    data.Add(personPosition.Count());

                    var distinctEducationLevel = personPosition.Select(s => new { s.EducationLevel, s.EducationLevelId }).Distinct();
                    var lowerBachelor = personPosition.Where(m => !educate.Contains(m.EducationLevel)).Count();

                    var labelInPosition = new List<string>();
                    var dataInPosition = new List<int>();
                    foreach (var educationLevel in distinctEducationLevel)
                    {
                        labelInPosition.Add(educationLevel.EducationLevel);
                        dataInPosition.Add(personPosition.Where(m => m.EducationLevel == educationLevel.EducationLevel && m.EducationLevelId == educationLevel.EducationLevelId).Count());
                    }

                    labelInPosition.Add("ต่ำกว่าปริญญาตรี");
                    dataInPosition.Add(lowerBachelor);
                    var graphDataSetPosition = new GraphDataSet
                    {
                        Data = dataInPosition
                    };

                    var graphDataPosition = new GraphData
                    {
                        GraphDataSet = new List<GraphDataSet> {
                                        graphDataSetPosition
                        },
                        Label = labelInPosition
                    };

                    listViewData.Add(new ViewData
                    {
                        index = 0,
                        ListViewData = graphDataPosition

                    });

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
                    Label = label,
                    ViewData = listViewData
                };
                return result;
            }
            else
            {
                var list = new List<PersonPostionEducationDataTableModel>();
                foreach (var positionType in distinctPosition)
                {
                    var listEducation = new List<PersonPostionEducationDataTable>();
                    var educate = new List<string>() { "ปริญญาเอก", "ปริญญาตรี", "ปริญญาโท" };
                    var personPosition = personnel.Where(m => m.PositionType == positionType.PositionType && m.PositionTypeId == m.PositionTypeId
                    && educate.Contains(m.EducationLevel));
                    var distinctEducationLevel = personPosition.Select(s => new { s.EducationLevel, s.EducationLevelId }).Distinct();
                    var lowerBachelor = personPosition.Where(m => !educate.Contains(m.EducationLevel)).Count();

                    var dataInPosition = new List<int>();
                    foreach (var educationLevel in distinctEducationLevel)
                    {
                        var model = new PersonPostionEducationDataTable
                        {
                            EducationLevel = educationLevel.EducationLevel,
                            EducationLevelId = educationLevel.EducationLevelId,
                            Person = personPosition.Where(m => m.EducationLevel == educationLevel.EducationLevel && m.EducationLevelId == educationLevel.EducationLevelId).Count()
                        };
                        listEducation.Add(model);
                    }
                    var personPositionEducation = new PersonPostionEducationDataTableModel
                    {
                        PersonPosionTypeName = positionType.PositionType,
                        PersonPosionTypeId = positionType.PositionTypeId,
                        PersonPostionEducation = listEducation
                    };
                    list.Add(personPositionEducation);
                }
                return list;
            }
        }

        public List<PersonPostionEducationDataSourceModel> GetAllPersonnelPositionEducationDataSource()
        {
            var personnel = _dcPersonRepository.GetAll();

            var distinctPosition = personnel.Select(s => new { s.PositionType, s.PositionTypeId }).Distinct();

            var list = new List<PersonPostionEducationDataSourceModel>();
            foreach (var positionType in distinctPosition)
            {
                var listEducation = new List<PersonPostionEducationDataSource>();
                var educate = new List<string>() { "ปริญญาเอก", "ปริญญาตรี", "ปริญญาโท" };
                var personPosition = personnel.Where(m => m.PositionType == positionType.PositionType && m.PositionTypeId == m.PositionTypeId
                && educate.Contains(m.EducationLevel));
                var distinctEducationLevel = personPosition.Select(s => new { s.EducationLevel, s.EducationLevelId }).Distinct();
                var lowerBachelor = personPosition.Where(m => !educate.Contains(m.EducationLevel)).Count();

                var dataInPosition = new List<int>();
                foreach (var educationLevel in distinctEducationLevel)
                {
                    var model = new PersonPostionEducationDataSource
                    {
                        EducationLevel = educationLevel.EducationLevel,
                        EducationLevelId = educationLevel.EducationLevelId,
                        Person = personPosition.Where(m => m.EducationLevel == educationLevel.EducationLevel && m.EducationLevelId == educationLevel.EducationLevelId)
                          .Select(s => new PersonnelDataSourceViewModel
                          {
                              AdminPosition = s.AdminPosition,
                              AdminPositionType = s.AdminPositionType,
                              BloodType = s.BloodType,
                              Country = s.Country,
                              DateOfBirth = s.DateOfBirth,
                              Division = s.Division,
                              Education = s.Education,
                              EducationLevel = s.EducationLevel,
                              Faculty = s.Faculty,
                              Gender = s.Gender,
                              GraduateDate = s.GraduateDate,
                              IdCard = s.IdCard,
                              Major = s.Major,
                              Nation = s.Nation,
                              PersonName = string.Format("{0} {1} {2}", s.TitleName, s.FirstName, s.LastName),
                              PersonnelId = s.PersonnelId,
                              PersonnelType = s.PersonnelType,
                              Position = s.Position,
                              PositionLevel = s.PositionLevel,
                              PositionType = s.PositionType,
                              Province = s.Province,
                              RetiredDate = s.RetiredDate,
                              RetiredYear = s.RetiredYear,
                              Salary = s.Salary,
                              Section = s.Section,
                              StartDate = s.StartDate,
                              StartEducationDate = s.StartEducationDate,
                              TitleEducation = s.TitleEducation,
                              University = s.University,
                              ZipCode = s.ZipCode

                          }).ToList()
                    };
                    listEducation.Add(model);
                }
                var personPositionEducation = new PersonPostionEducationDataSourceModel
                {
                    PersonPosionTypeName = positionType.PositionType,
                    PersonPosionTypeId = positionType.PositionTypeId,
                    PersonPostionEducation = listEducation
                };
                list.Add(personPositionEducation);
            }
            return list;

        }

        public List<PersonnelGenderDataTableViewModel> GetAllPersonGender(int type)
        {
            var personnel = _dcPersonRepository.GetAll();
            var distinctPersonGender = personnel.Select(s =>
            new { s.GenderId, s.Gender }).OrderBy(o => o.GenderId).Distinct();

            var result = new List<PersonnelGenderDataTableViewModel>();
            foreach (var PersonGender in distinctPersonGender)
            {
                var genderGenerationBabyBoomberCount = personnel.Where(s => s.DateOfBirth >= DateTime.Parse("1946/01/01")
                && s.DateOfBirth <= DateTime.Parse("1964/12/31") && s.GenderId == PersonGender.GenderId && s.Gender == PersonGender.Gender).Count();
                var genderGenerationGenXCount = personnel.Where(s => s.DateOfBirth >= DateTime.Parse("1967/01/01")
                && s.DateOfBirth <= DateTime.Parse("1979/12/31") && s.GenderId == PersonGender.GenderId && s.Gender == PersonGender.Gender).Count();
                var genderGenerationGenYCount = personnel.Where(s => s.DateOfBirth >= DateTime.Parse("1980/01/01")
                && s.DateOfBirth <= DateTime.Parse("1997/12/31") && s.GenderId == PersonGender.GenderId && s.Gender == PersonGender.Gender).Count();
                var genderGenerationGenZCount = personnel.Where(s => s.DateOfBirth >= DateTime.Parse("1998/01/01") && s.GenderId == PersonGender.GenderId
                && s.Gender == PersonGender.Gender).Count();

                var data = new List<PersonnelGenderDataTable>
                    {
                        new PersonnelGenderDataTable
                        {
                            Generetion = "Baby Boomer (เกิดปี 2489 - 2507)",
                            Person = genderGenerationBabyBoomberCount
                        },
                         new PersonnelGenderDataTable
                        {
                            Generetion = "Gen X (เกิดปี 2508 - 2522)",
                            Person = genderGenerationGenXCount
                        },
                          new PersonnelGenderDataTable
                        {
                            Generetion = "Gen Y (เกิดปี 2523 - 2540)",
                            Person = genderGenerationGenYCount
                        },
                          new PersonnelGenderDataTable
                        {
                            Generetion = "Gen Z (เกิดปี 2541 ขึ้นไป)",
                            Person = genderGenerationGenZCount
                        }


                     };
                var model = new PersonnelGenderDataTableViewModel
                {
                    GenderId = PersonGender.GenderId,
                    Gender = PersonGender.Gender,
                    PersonGenderGeneration = data
                };
                result.Add(model);
            }
            return result;
        }

        public List<PersonnelGenderDataSourceViewModel> GetAllPersonGenderDataSource()
        {
            var personnel = _dcPersonRepository.GetAll();
            var distinctPersonGender = personnel.Select(s => new { s.Gender, s.GenderId }).Distinct().OrderBy(o => o.GenderId);

            var result = new List<PersonnelGenderDataSourceViewModel>();
            foreach (var personGender in distinctPersonGender)
            {
                var genderGenerationBabyBoomber = personnel.Where(s => s.DateOfBirth >= DateTime.Parse("1946/01/01")
                    && s.DateOfBirth <= DateTime.Parse("1964/12/31")
                    && s.GenderId == personGender.GenderId && s.Gender == personGender.Gender)
                    .Select(s => new PersonnelDataSourceViewModel
                    {
                        AdminPosition = s.AdminPosition,
                        AdminPositionType = s.AdminPositionType,
                        BloodType = s.BloodType,
                        Country = s.Country,
                        DateOfBirth = s.DateOfBirth,
                        Division = s.Division,
                        Education = s.Education,
                        EducationLevel = s.EducationLevel,
                        Faculty = s.Faculty,
                        Gender = s.Gender,
                        GraduateDate = s.GraduateDate,
                        IdCard = s.IdCard,
                        Major = s.Major,
                        Nation = s.Nation,
                        PersonName = string.Format("{0} {1} {2}", s.TitleName, s.FirstName, s.LastName),
                        PersonnelId = s.PersonnelId,
                        PersonnelType = s.PersonnelType,
                        Position = s.Position,
                        PositionLevel = s.PositionLevel,
                        PositionType = s.PositionType,
                        Province = s.Province,
                        RetiredDate = s.RetiredDate,
                        RetiredYear = s.RetiredYear,
                        Salary = s.Salary,
                        Section = s.Section,
                        StartDate = s.StartDate,
                        StartEducationDate = s.StartEducationDate,
                        TitleEducation = s.TitleEducation,
                        University = s.University,
                        ZipCode = s.ZipCode
                    }).ToList();
                var genderGenerationGenX = personnel.Where(s => s.DateOfBirth >= DateTime.Parse("1967/01/01")
                    && s.DateOfBirth <= DateTime.Parse("1979/12/31") && s.GenderId == personGender.GenderId && s.Gender == personGender.Gender)
                    .Select(s => new PersonnelDataSourceViewModel
                    {
                        AdminPosition = s.AdminPosition,
                        AdminPositionType = s.AdminPositionType,
                        BloodType = s.BloodType,
                        Country = s.Country,
                        DateOfBirth = s.DateOfBirth,
                        Division = s.Division,
                        Education = s.Education,
                        EducationLevel = s.EducationLevel,
                        Faculty = s.Faculty,
                        Gender = s.Gender,
                        GraduateDate = s.GraduateDate,
                        IdCard = s.IdCard,
                        Major = s.Major,
                        Nation = s.Nation,
                        PersonName = string.Format("{0} {1} {2}", s.TitleName, s.FirstName, s.LastName),
                        PersonnelId = s.PersonnelId,
                        PersonnelType = s.PersonnelType,
                        Position = s.Position,
                        PositionLevel = s.PositionLevel,
                        PositionType = s.PositionType,
                        Province = s.Province,
                        RetiredDate = s.RetiredDate,
                        RetiredYear = s.RetiredYear,
                        Salary = s.Salary,
                        Section = s.Section,
                        StartDate = s.StartDate,
                        StartEducationDate = s.StartEducationDate,
                        TitleEducation = s.TitleEducation,
                        University = s.University,
                        ZipCode = s.ZipCode
                    }).ToList();
                var genderGenerationGenY = personnel.Where(s => s.DateOfBirth >= DateTime.Parse("1980/01/01")
                   && s.DateOfBirth <= DateTime.Parse("1997/12/31") && s.GenderId == personGender.GenderId && s.Gender == personGender.Gender)
                    .Select(s => new PersonnelDataSourceViewModel
                    {
                        AdminPosition = s.AdminPosition,
                        AdminPositionType = s.AdminPositionType,
                        BloodType = s.BloodType,
                        Country = s.Country,
                        DateOfBirth = s.DateOfBirth,
                        Division = s.Division,
                        Education = s.Education,
                        EducationLevel = s.EducationLevel,
                        Faculty = s.Faculty,
                        Gender = s.Gender,
                        GraduateDate = s.GraduateDate,
                        IdCard = s.IdCard,
                        Major = s.Major,
                        Nation = s.Nation,
                        PersonName = string.Format("{0} {1} {2}", s.TitleName, s.FirstName, s.LastName),
                        PersonnelId = s.PersonnelId,
                        PersonnelType = s.PersonnelType,
                        Position = s.Position,
                        PositionLevel = s.PositionLevel,
                        PositionType = s.PositionType,
                        Province = s.Province,
                        RetiredDate = s.RetiredDate,
                        RetiredYear = s.RetiredYear,
                        Salary = s.Salary,
                        Section = s.Section,
                        StartDate = s.StartDate,
                        StartEducationDate = s.StartEducationDate,
                        TitleEducation = s.TitleEducation,
                        University = s.University,
                        ZipCode = s.ZipCode
                    }).ToList();
                var genderGenerationGenZ = personnel.Where(s => s.DateOfBirth >= DateTime.Parse("1998/01/01") && s.GenderId == personGender.GenderId
                    && s.Gender == personGender.Gender)
                    .Select(s => new PersonnelDataSourceViewModel
                    {
                        AdminPosition = s.AdminPosition,
                        AdminPositionType = s.AdminPositionType,
                        BloodType = s.BloodType,
                        Country = s.Country,
                        DateOfBirth = s.DateOfBirth,
                        Division = s.Division,
                        Education = s.Education,
                        EducationLevel = s.EducationLevel,
                        Faculty = s.Faculty,
                        Gender = s.Gender,
                        GraduateDate = s.GraduateDate,
                        IdCard = s.IdCard,
                        Major = s.Major,
                        Nation = s.Nation,
                        PersonName = string.Format("{0} {1} {2}", s.TitleName, s.FirstName, s.LastName),
                        PersonnelId = s.PersonnelId,
                        PersonnelType = s.PersonnelType,
                        Position = s.Position,
                        PositionLevel = s.PositionLevel,
                        PositionType = s.PositionType,
                        Province = s.Province,
                        RetiredDate = s.RetiredDate,
                        RetiredYear = s.RetiredYear,
                        Salary = s.Salary,
                        Section = s.Section,
                        StartDate = s.StartDate,
                        StartEducationDate = s.StartEducationDate,
                        TitleEducation = s.TitleEducation,
                        University = s.University,
                        ZipCode = s.ZipCode
                    }).ToList();

                var model = new List<PersonnelDataGenderDataSource>
                {
                    new PersonnelDataGenderDataSource
                    {
                        Generetion = "Baby Boomer (เกิดปี 2489 - 2507)",
                        Person = genderGenerationBabyBoomber
                    },
                    new PersonnelDataGenderDataSource
                    {
                        Generetion = "Gen X (เกิดปี 2508 - 2522)",
                        Person = genderGenerationGenX
                    },
                    new PersonnelDataGenderDataSource
                    {
                        Generetion = "Gen Y (เกิดปี 2523 - 2540)",
                        Person = genderGenerationGenY
                    },
                    new PersonnelDataGenderDataSource
                    {
                        Generetion = "Gen Z (เกิดปี 2541 ขึ้นไป)",
                        Person = genderGenerationGenZ
                    },
                };

                var personDataSet = new PersonnelGenderDataSourceViewModel
                {
                    GenderId = personGender.GenderId,
                    Gender = personGender.Gender,
                    PersonGenderGeneration = model
                };
                result.Add(personDataSet);
            }
            return result;
        }
        public List<PersonnelGenderDataSourceViewModel> GetAllPersonGenderDataSourceByType(int type, int gender, string genderName)
        {
            var personnel = _dcPersonRepository.GetAll().Where(s => s.GenderId == gender);
            var distinctPersonGender = personnel.Select(s => new { s.Gender, s.GenderId }).Distinct().OrderBy(o => o.GenderId);
            var generation = "";
            switch (type)
            {
                case 0:
                    personnel = personnel.Where(s => s.DateOfBirth >= DateTime.Parse("1946/01/01")
                    && s.DateOfBirth <= DateTime.Parse("1964/12/31"));
                    generation = "Baby Boomer (เกิดปี 2489 - 2507)";
                    break;
                case 1:
                    personnel = personnel.Where(s => s.DateOfBirth >= DateTime.Parse("1967/01/01")
                    && s.DateOfBirth <= DateTime.Parse("1979/12/31"));
                    generation = "Gen X (เกิดปี 2508 - 2522)";
                    break;
                case 2:
                    personnel = personnel.Where(s => s.DateOfBirth >= DateTime.Parse("1980/01/01"));
                    generation = "Gen Y (เกิดปี 2523 - 2540)";
                    break;
                case 3:
                    personnel = personnel.Where(s => s.DateOfBirth >= DateTime.Parse("1998/01/01"));
                    generation = "Gen Z (เกิดปี 2541 ขึ้นไป)";
                    break;
            }
            var result = new List<PersonnelGenderDataSourceViewModel>();

            var data = personnel
                .Select(s => new PersonnelDataSourceViewModel
                {
                    AdminPosition = s.AdminPosition,
                    AdminPositionType = s.AdminPositionType,
                    BloodType = s.BloodType,
                    Country = s.Country,
                    DateOfBirth = s.DateOfBirth,
                    Division = s.Division,
                    Education = s.Education,
                    EducationLevel = s.EducationLevel,
                    Faculty = s.Faculty,
                    Gender = s.Gender,
                    GraduateDate = s.GraduateDate,
                    IdCard = s.IdCard,
                    Major = s.Major,
                    Nation = s.Nation,
                    PersonName = string.Format("{0} {1} {2}", s.TitleName, s.FirstName, s.LastName),
                    PersonnelId = s.PersonnelId,
                    PersonnelType = s.PersonnelType,
                    Position = s.Position,
                    PositionLevel = s.PositionLevel,
                    PositionType = s.PositionType,
                    Province = s.Province,
                    RetiredDate = s.RetiredDate,
                    RetiredYear = s.RetiredYear,
                    Salary = s.Salary,
                    Section = s.Section,
                    StartDate = s.StartDate,
                    StartEducationDate = s.StartEducationDate,
                    TitleEducation = s.TitleEducation,
                    University = s.University,
                    ZipCode = s.ZipCode
                }).ToList();


            var model = new List<PersonnelDataGenderDataSource>
                {
                    new PersonnelDataGenderDataSource
                    {
                        Generetion = generation,
                        Person = data
                    }
                };

            var personDataSet = new PersonnelGenderDataSourceViewModel
            {
                GenderId = gender,
                Gender = genderName,
                PersonGenderGeneration = model
            };
            result.Add(personDataSet);

            return result;
        }
    }
}
