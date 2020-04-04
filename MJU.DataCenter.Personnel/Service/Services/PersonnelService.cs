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
            foreach (var model in lessThanThree)
            {
                var count = personnel.Where(m => (DateTime.UtcNow.Year - m.StartDate.Value.Year) < 3 && m.PersonnelTypeId == model.PersonnelTypeId && m.PersonnelType == model.PersonnelType).Count();
                dataCoutLessThanThree.Add(count);
            }
            var dataLessThanThree = new GraphDataSet
            {
                Label = "น้อยกว่า 3 ปี",
                Data = dataCoutLessThanThree

            };

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
                Data = dataCoutThreeToFive

            };

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
                Data = dataCoutSixToNine

            };

            var tenToFifteen = personnel.Where(m => (DateTime.UtcNow.Year - m.StartDate.Value.Year) >= 10 && (DateTime.UtcNow.Year - m.StartDate.Value.Year) <= 15).Select(s => new { s.PersonnelType, s.PersonnelTypeId }).OrderBy(o => o.PersonnelTypeId).Distinct();
            var dataCoutTenToFifteen = new List<int>();
            foreach (var model in tenToFifteen)
            {
                var count = personnel.Where(m => (DateTime.UtcNow.Year - m.StartDate.Value.Year) >= 10 && (DateTime.UtcNow.Year - m.StartDate.Value.Year) <= 15 && m.PersonnelTypeId == model.PersonnelTypeId && m.PersonnelType == model.PersonnelType).Count();
                dataCoutTenToFifteen.Add(count);
                l4.Add(model.PersonnelType);
                if (model.PersonnelType == "ข้าราชกาล") a += count;
            }
            var dataTenToFifteen = new GraphDataSet
            {
                Label = "10 - 15 ปี",
                Data = dataCoutTenToFifteen

            };

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
                Data = dataCoutSixteenToTwenty

            };
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
                Data = dataCoutMorethanTwenty

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

        public List<PersonnelDataSourceViewModel> GetAllPersonnelGroupWorkDurationDataSourceByType(string personGroupType, int type)
        {

            var personnel = _dcPersonRepository.GetAll().Where(m => m.PersonnelType == personGroupType);

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
    }
}
