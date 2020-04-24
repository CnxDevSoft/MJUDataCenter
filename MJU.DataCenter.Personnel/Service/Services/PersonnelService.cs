using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MJU.DataCenter.Core.Helpers;
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

        public object GetAllPersonnelGroup(int type, List<int> filter)
        {

            var personnel = _dcPersonRepository.GetAll();
            if (filter.Any())
            {
                personnel = personnel.Where(x => filter.Contains(x.FacultyId.GetValueOrDefault()));
            }
            personnel = personnel.OrderBy(o => o.PersonnelTypeId);
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

        public List<PersonGroupDataSourceModel> GetAllPersonnelGroupDataSource(string type, List<int> filter)
        {

            var personnel = _dcPersonRepository.GetAll().Where(m => !string.IsNullOrEmpty(type) ? m.PersonnelType == type : true);
            if (filter.Any())
            {
                personnel = personnel.Where(x => filter.Contains(x.FacultyId.GetValueOrDefault()));
            }
            personnel = personnel.OrderBy(o => o.PersonnelTypeId);
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
                        DateOfBirth = s.DateOfBirth.ToLocalDateTime(),
                        Division = s.Division,
                        Education = s.Education,
                        EducationLevel = s.EducationLevel,
                        Faculty = s.Faculty,
                        Gender = s.Gender,
                        GraduateDate = s.GraduateDate.ToLocalDateTime(),
                        CitizenId = s.CitizenId,
                        Major = s.Major,
                        Nation = s.Nation,
                        PersonName = string.Format("{0} {1} {2}", s.TitleName, s.FirstName, s.LastName),
                        PersonnelId = s.PersonnelId,
                        PersonnelType = s.PersonnelType,
                        Position = s.Position,
                        PositionLevel = s.PositionLevel,
                        PositionType = s.PositionType,
                        Province = s.Province,
                        RetiredDate = s.RetiredDate.ToLocalDateTime(),
                        RetiredYear = s.RetiredYear.GetValueOrDefault().ToLocalYear(),
                        Salary = s.Salary,
                        Section = s.Section,
                        StartDate = s.StartDate.ToLocalDateTime(),
                        StartEducationDate = s.StartEducationDate.ToLocalDateTime(),
                        TitleEducation = s.TitleEducation,
                        University = s.University,
                        ZipCode = s.ZipCode,
                        Address = string.Format("{0} ซอย {1} หมู่ {2} ต.{4} อ.{4} จ.{5}", s.HomeNumber, s.Soi, s.Moo, s.SubDistrict, s.District, s.Province)

                    }).ToList()
                };
                list.Add(personGroup);
            }

            return list;



        }

        public object GetAllPersonnelPosition(int type, List<int> filter)
        {
            var personnel = _dcPersonRepository.GetAll();
            if (filter.Any())
            {
                personnel = personnel.Where(x => filter.Contains(x.FacultyId.GetValueOrDefault()));
            }

            var distinctPosition = personnel.OrderBy(o => o.PositionTypeId).Select(s => new { s.PositionType, s.PositionTypeId }).Distinct();

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
                        PersonPositionTypeId = positionType.PositionTypeId,
                        PersonPositionTypeName = positionType.PositionType,
                        Person = personnel.Where(m => m.PositionType == positionType.PositionType && m.PositionTypeId == m.PositionTypeId).Count()
                    };
                    list.Add(personPosition);
                }
                return list;
            }
        }

        public List<PersonPostionDataSourceModel> GetAllPersonnelPositionDataSource(string type, List<int> filter)
        {
            var personnel = _dcPersonRepository.GetAll().Where(m => !string.IsNullOrEmpty(type) ? m.PositionType == type : true);
            if (filter.Any())
            {
                personnel = personnel.Where(x => filter.Contains(x.FacultyId.GetValueOrDefault()));
            }
            personnel = personnel.OrderBy(o => o.PositionTypeId);
            var distinctPosition = personnel.Select(s => new { s.PositionType, s.PositionTypeId }).Distinct();

            var list = new List<PersonPostionDataSourceModel>();
            foreach (var positionType in distinctPosition)
            {
                var personPosition = new PersonPostionDataSourceModel
                {
                    PersonPositionTypeId = positionType.PositionTypeId,
                    PersonPositionTypeName = positionType.PositionType,
                    Person = personnel.Where(m => m.PositionType == positionType.PositionType && m.PositionTypeId == m.PositionTypeId).
                    Select(s => new PersonnelDataSourceViewModel
                    {
                        AdminPosition = s.AdminPosition,
                        AdminPositionType = s.AdminPositionType,
                        BloodType = s.BloodType,
                        Country = s.Country,
                        DateOfBirth = s.DateOfBirth.ToLocalDateTime(),
                        Division = s.Division,
                        Education = s.Education,
                        EducationLevel = s.EducationLevel,
                        Faculty = s.Faculty,
                        Gender = s.Gender,
                        GraduateDate = s.GraduateDate.ToLocalDateTime(),
                        CitizenId = s.CitizenId,
                        Major = s.Major,
                        Nation = s.Nation,
                        PersonName = string.Format("{0} {1} {2}", s.TitleName, s.FirstName, s.LastName),
                        PersonnelId = s.PersonnelId,
                        PersonnelType = s.PersonnelType,
                        Position = s.Position,
                        PositionLevel = s.PositionLevel,
                        PositionType = s.PositionType,
                        Province = s.Province,
                        RetiredDate = s.RetiredDate.ToLocalDateTime(),
                        RetiredYear = s.RetiredYear.GetValueOrDefault().ToLocalYear(),
                        Salary = s.Salary,
                        Section = s.Section,
                        StartDate = s.StartDate.ToLocalDateTime(),
                        StartEducationDate = s.StartEducationDate.ToLocalDateTime(),
                        TitleEducation = s.TitleEducation,
                        University = s.University,
                        ZipCode = s.ZipCode,
                        Address = string.Format("{0} ซอย {1} หมู่ {2} ต.{4} อ.{4} จ.{5}", s.HomeNumber, s.Soi, s.Moo, s.SubDistrict, s.District, s.Province)
                    }).ToList()
                };
                list.Add(personPosition);
            }
            return list;

        }

        public object GetAllPersonnelEducation(int type, List<int> filter)
        {
            var educate = new List<string>() { "ปริญญาเอก", "ปริญญาตรี", "ปริญญาโท" };
            var personnel = _dcPersonRepository.GetAll().Where(m => educate.Contains(m.EducationLevel));
            if (filter.Any())
            {
                personnel = personnel.Where(x => filter.Contains(x.FacultyId.GetValueOrDefault()));
            }
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

        public List<PersonEducationDataSourceModel> GetAllPersonnelEducationDataSource(string type, List<int> filter)
        {
            var educate = new List<string>() { "ปริญญาเอก", "ปริญญาตรี", "ปริญญาโท" };
            var personnel = _dcPersonRepository.GetAll().Where(m => !string.IsNullOrEmpty(type) ? m.EducationLevel == type : educate.Contains(m.EducationLevel));
            if (filter.Any())
            {
                personnel = personnel.Where(x => filter.Contains(x.FacultyId.GetValueOrDefault()));
            }
            var distinctEducationLevel = personnel.Select(s => new { s.EducationLevel, s.EducationLevelId }
            ).Distinct();


            var list = new List<PersonEducationDataSourceModel>();
            if (personnel.Any())
            {
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
                            DateOfBirth = s.DateOfBirth.ToLocalDateTime(),
                            Division = s.Division,
                            Education = s.Education,
                            EducationLevel = s.EducationLevel,
                            Faculty = s.Faculty,
                            Gender = s.Gender,
                            GraduateDate = s.GraduateDate.ToLocalDateTime(),
                            CitizenId = s.CitizenId,
                            Major = s.Major,
                            Nation = s.Nation,
                            PersonName = string.Format("{0} {1} {2}", s.TitleName, s.FirstName, s.LastName),
                            PersonnelId = s.PersonnelId,
                            PersonnelType = s.PersonnelType,
                            Position = s.Position,
                            PositionLevel = s.PositionLevel,
                            PositionType = s.PositionType,
                            Province = s.Province,
                            RetiredDate = s.RetiredDate.ToLocalDateTime(),
                            RetiredYear = s.RetiredYear.GetValueOrDefault().ToLocalYear(),
                            Salary = s.Salary,
                            Section = s.Section,
                            StartDate = s.StartDate.ToLocalDateTime(),
                            StartEducationDate = s.StartEducationDate.ToLocalDateTime(),
                            TitleEducation = s.TitleEducation,
                            University = s.University,
                            ZipCode = s.ZipCode,
                            Address = string.Format("{0} ซอย {1} หมู่ {2} ต.{4} อ.{4} จ.{5}", s.HomeNumber, s.Soi, s.Moo, s.SubDistrict, s.District, s.Province)

                        }).ToList()
                    };
                    list.Add(personPosition);
                }
            }

            if (string.IsNullOrEmpty(type) || !educate.Contains(type))
            {
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
                 DateOfBirth = s.DateOfBirth.ToLocalDateTime(),
                 Division = s.Division,
                 Education = s.Education,
                 EducationLevel = s.EducationLevel,
                 Faculty = s.Faculty,
                 Gender = s.Gender,
                 GraduateDate = s.GraduateDate.ToLocalDateTime(),
                 CitizenId = s.CitizenId,
                 Major = s.Major,
                 Nation = s.Nation,
                 PersonName = string.Format("{0} {1} {2}", s.TitleName, s.FirstName, s.LastName),
                 PersonnelId = s.PersonnelId,
                 PersonnelType = s.PersonnelType,
                 Position = s.Position,
                 PositionLevel = s.PositionLevel,
                 PositionType = s.PositionType,
                 Province = s.Province,
                 RetiredDate = s.RetiredDate.ToLocalDateTime(),
                 RetiredYear = s.RetiredYear.GetValueOrDefault().ToLocalYear(),
                 Salary = s.Salary,
                 Section = s.Section,
                 StartDate = s.StartDate.ToLocalDateTime(),
                 StartEducationDate = s.StartEducationDate.ToLocalDateTime(),
                 TitleEducation = s.TitleEducation,
                 University = s.University,
                 ZipCode = s.ZipCode,
                 Address = string.Format("{0} ซอย {1} หมู่ {2} ต.{4} อ.{4} จ.{5}", s.HomeNumber, s.Soi, s.Moo, s.SubDistrict, s.District, s.Province)

             }).ToList()

                });
            }

            return list;

        }

        public object GetAllPersonnelPositionGeneration(int type, List<int> filter)
        {
            var personnel = _dcPersonRepository.GetAll();
            if (filter.Any())
            {
                personnel = personnel.Where(x => filter.Contains(x.FacultyId.GetValueOrDefault()));
            }
            personnel = personnel.OrderBy(o => o.PositionTypeId);
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

        public List<PersonPostionGenertionDataSourceViewModel> GetAllPersonnelPositionGenerationDataSource(string positionType, int? index, List<int> filter)
        {
            var personnel = _dcPersonRepository.GetAll().Where(m => !string.IsNullOrEmpty(positionType) ? m.PositionType == positionType : true);
            if (filter.Any())
            {
                personnel = personnel.Where(x => filter.Contains(x.FacultyId.GetValueOrDefault()));
            }
            personnel = personnel.OrderBy(o => o.PositionTypeId);
            var distinctPosition = personnel.Select(s => new { s.PositionType, s.PositionTypeId }).Distinct();


            var result = new List<PersonPostionGenertionDataSourceViewModel>();
            foreach (var positionTypeData in distinctPosition)
            {
                var personPostionGenertion = new List<PersonPostionGenertionDataSourceModel>();
                if (index == null || index == 0)
                {
                    var generationBabyBoomber = personnel.Where(s => s.DateOfBirth >= DateTime.Parse("1946/01/01") && s.DateOfBirth <= DateTime.Parse("1964/12/31"))
                    .Select(s => new PersonnelDataSourceViewModel
                    {
                        AdminPosition = s.AdminPosition,
                        AdminPositionType = s.AdminPositionType,
                        BloodType = s.BloodType,
                        Country = s.Country,
                        DateOfBirth = s.DateOfBirth.ToLocalDateTime(),
                        Division = s.Division,
                        Education = s.Education,
                        EducationLevel = s.EducationLevel,
                        Faculty = s.Faculty,
                        Gender = s.Gender,
                        GraduateDate = s.GraduateDate.ToLocalDateTime(),
                        CitizenId = s.CitizenId,
                        Major = s.Major,
                        Nation = s.Nation,
                        PersonName = string.Format("{0} {1} {2}", s.TitleName, s.FirstName, s.LastName),
                        PersonnelId = s.PersonnelId,
                        PersonnelType = s.PersonnelType,
                        Position = s.Position,
                        PositionLevel = s.PositionLevel,
                        PositionType = s.PositionType,
                        Province = s.Province,
                        RetiredDate = s.RetiredDate.ToLocalDateTime(),
                        RetiredYear = s.RetiredYear.GetValueOrDefault().ToLocalYear(),
                        Salary = s.Salary,
                        Section = s.Section,
                        StartDate = s.StartDate.ToLocalDateTime(),
                        StartEducationDate = s.StartEducationDate.ToLocalDateTime(),
                        TitleEducation = s.TitleEducation,
                        University = s.University,
                        ZipCode = s.ZipCode,
                        Address = string.Format("{0} ซอย {1} หมู่ {2} ต.{4} อ.{4} จ.{5}", s.HomeNumber, s.Soi, s.Moo, s.SubDistrict, s.District, s.Province)

                    }).ToList();
                    var model = new PersonPostionGenertionDataSourceModel
                    {
                        PersonGenertionName = "Baby Boomer (เกิดปี 2489 - 2507)",
                        Person = generationBabyBoomber
                    };
                    personPostionGenertion.Add(model);
                }

                if (index == null || index == 1)
                {
                    var generationGenX = personnel.Where(s => s.PositionType == positionTypeData.PositionType && s.PositionTypeId == positionTypeData.PositionTypeId && s.DateOfBirth >= DateTime.Parse("1967/01/01") && s.DateOfBirth <= DateTime.Parse("1979/12/31"))
                .Select(s => new PersonnelDataSourceViewModel
                {
                    AdminPosition = s.AdminPosition,
                    AdminPositionType = s.AdminPositionType,
                    BloodType = s.BloodType,
                    Country = s.Country,
                    DateOfBirth = s.DateOfBirth.ToLocalDateTime(),
                    Division = s.Division,
                    Education = s.Education,
                    EducationLevel = s.EducationLevel,
                    Faculty = s.Faculty,
                    Gender = s.Gender,
                    GraduateDate = s.GraduateDate.ToLocalDateTime(),
                    CitizenId = s.CitizenId,
                    Major = s.Major,
                    Nation = s.Nation,
                    PersonName = string.Format("{0} {1} {2}", s.TitleName, s.FirstName, s.LastName),
                    PersonnelId = s.PersonnelId,
                    PersonnelType = s.PersonnelType,
                    Position = s.Position,
                    PositionLevel = s.PositionLevel,
                    PositionType = s.PositionType,
                    Province = s.Province,
                    RetiredDate = s.RetiredDate.ToLocalDateTime(),
                    RetiredYear = s.RetiredYear.GetValueOrDefault().ToLocalYear(),
                    Salary = s.Salary,
                    Section = s.Section,
                    StartDate = s.StartDate.ToLocalDateTime(),
                    StartEducationDate = s.StartEducationDate.ToLocalDateTime(),
                    TitleEducation = s.TitleEducation,
                    University = s.University,
                    ZipCode = s.ZipCode,
                    Address = string.Format("{0} ซอย {1} หมู่ {2} ต.{4} อ.{4} จ.{5}", s.HomeNumber, s.Soi, s.Moo, s.SubDistrict, s.District, s.Province)
                }).ToList();
                    var model = new PersonPostionGenertionDataSourceModel
                    {
                        PersonGenertionName = "Gen X (เกิดปี 2508 - 2522)",
                        Person = generationGenX
                    };
                    personPostionGenertion.Add(model);
                }
                if (index == null || index == 2)
                {
                    var generationGenY = personnel.Where(s => s.PositionType == positionTypeData.PositionType && s.PositionTypeId == positionTypeData.PositionTypeId && s.DateOfBirth >= DateTime.Parse("1980/01/01") && s.DateOfBirth <= DateTime.Parse("1997/12/31"))
                    .Select(s => new PersonnelDataSourceViewModel
                    {
                        AdminPosition = s.AdminPosition,
                        AdminPositionType = s.AdminPositionType,
                        BloodType = s.BloodType,
                        Country = s.Country,
                        DateOfBirth = s.DateOfBirth.ToLocalDateTime(),
                        Division = s.Division,
                        Education = s.Education,
                        EducationLevel = s.EducationLevel,
                        Faculty = s.Faculty,
                        Gender = s.Gender,
                        GraduateDate = s.GraduateDate.ToLocalDateTime(),
                        CitizenId = s.CitizenId,
                        Major = s.Major,
                        Nation = s.Nation,
                        PersonName = string.Format("{0} {1} {2}", s.TitleName, s.FirstName, s.LastName),
                        PersonnelId = s.PersonnelId,
                        PersonnelType = s.PersonnelType,
                        Position = s.Position,
                        PositionLevel = s.PositionLevel,
                        PositionType = s.PositionType,
                        Province = s.Province,
                        RetiredDate = s.RetiredDate.ToLocalDateTime(),
                        RetiredYear = s.RetiredYear.GetValueOrDefault().ToLocalYear(),
                        Salary = s.Salary,
                        Section = s.Section,
                        StartDate = s.StartDate.ToLocalDateTime(),
                        StartEducationDate = s.StartEducationDate.ToLocalDateTime(),
                        TitleEducation = s.TitleEducation,
                        University = s.University,
                        ZipCode = s.ZipCode,
                        Address = string.Format("{0} ซอย {1} หมู่ {2} ต.{4} อ.{4} จ.{5}", s.HomeNumber, s.Soi, s.Moo, s.SubDistrict, s.District, s.Province)
                    }).ToList();
                    var model = new PersonPostionGenertionDataSourceModel
                    {
                        PersonGenertionName = "Gen Y (เกิดปี 2523 - 2540)",
                        Person = generationGenY
                    };
                    personPostionGenertion.Add(model);
                }
                if (index == null || index == 3)
                {
                    var generationGenZ = personnel.Where(s => s.PositionType == positionTypeData.PositionType && s.PositionTypeId == positionTypeData.PositionTypeId && s.DateOfBirth >= DateTime.Parse("1998/01/01"))
                    .Select(s => new PersonnelDataSourceViewModel
                    {
                        AdminPosition = s.AdminPosition,
                        AdminPositionType = s.AdminPositionType,
                        BloodType = s.BloodType,
                        Country = s.Country,
                        DateOfBirth = s.DateOfBirth.ToLocalDateTime(),
                        Division = s.Division,
                        Education = s.Education,
                        EducationLevel = s.EducationLevel,
                        Faculty = s.Faculty,
                        Gender = s.Gender,
                        GraduateDate = s.GraduateDate.ToLocalDateTime(),
                        CitizenId = s.CitizenId,
                        Major = s.Major,
                        Nation = s.Nation,
                        PersonName = string.Format("{0} {1} {2}", s.TitleName, s.FirstName, s.LastName),
                        PersonnelId = s.PersonnelId,
                        PersonnelType = s.PersonnelType,
                        Position = s.Position,
                        PositionLevel = s.PositionLevel,
                        PositionType = s.PositionType,
                        Province = s.Province,
                        RetiredDate = s.RetiredDate.ToLocalDateTime(),
                        RetiredYear = s.RetiredYear.GetValueOrDefault().ToLocalYear(),
                        Salary = s.Salary,
                        Section = s.Section,
                        StartDate = s.StartDate.ToLocalDateTime(),
                        StartEducationDate = s.StartEducationDate.ToLocalDateTime(),
                        TitleEducation = s.TitleEducation,
                        University = s.University,
                        ZipCode = s.ZipCode,
                        Address = string.Format("{0} ซอย {1} หมู่ {2} ต.{4} อ.{4} จ.{5}", s.HomeNumber, s.Soi, s.Moo, s.SubDistrict, s.District, s.Province)
                    }).ToList();
                    var model = new PersonPostionGenertionDataSourceModel
                    {
                        PersonGenertionName = "Gen Z (เกิดปี 2541 ขึ้นไป)",
                        Person = generationGenZ
                    };
                    personPostionGenertion.Add(model);
                }

                var personPostionGenertionViewModel = new PersonPostionGenertionDataSourceViewModel()
                {
                    PersonPositionTypeId = positionTypeData.PositionTypeId,
                    PersionPostionName = positionTypeData.PositionType,
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

        public List<RetiredPersonDataTableModel> GetDataTablePersonRetired(string year, int type, List<int> filter)
        {
            var currentDate = DateTime.Parse(string.Format("01/01/{0}", year)).AddYears(-543);
            var startOfYear = currentDate.StartOfYear();
            var endOfYear = currentDate.EndOfYear();
            var personnel = _dcPersonRepository.GetAll();
            if (filter.Any())
            {
                personnel = personnel.Where(x => filter.Contains(x.FacultyId.GetValueOrDefault()));
            }
            if (type == 0)
            {

                return personnel.Where(m => m.StartDate <= endOfYear && (m.RetiredDate < endOfYear || m.RetiredDate == null))
                    .Select(s => new RetiredPersonDataTableModel
                    {
                        PersonnelId = s.PersonnelId,
                        PersonnelName = string.Format("{0} {1} {2}", s.TitleName, s.FirstName, s.LastName),
                        DateOfBirth = s.DateOfBirth.ToLocalDateTime(),
                        Age = DateTime.UtcNow.Year - s.DateOfBirth.GetValueOrDefault().Year,
                        PersonnelType = s.PersonnelType,
                        Position = s.Position,
                        PositionType = s.Position,
                        PositionLevel = s.PositionLevel,
                        StartDate = s.StartDate,
                        RetiredDate = s.RetiredDate.ToLocalDateTime(),
                        RetiredYear = s.RetiredYear.GetValueOrDefault().ToLocalYear(),
                        Section = s.Section,
                        Division = s.Division,
                        Faculty = s.Faculty

                    }).ToList();

            }
            else if (type == 1)
            {
                var result = personnel.Where(m => (endOfYear.Year - m.DateOfBirth.GetValueOrDefault().Year) == 60)
                    .Select(s => new RetiredPersonDataTableModel
                    {
                        PersonnelId = s.PersonnelId,
                        PersonnelName = string.Format("{0} {1} {2}", s.TitleName, s.FirstName, s.LastName),
                        DateOfBirth = s.DateOfBirth.ToLocalDateTime(),
                        Age = DateTime.UtcNow.Year - s.DateOfBirth.GetValueOrDefault().Year,
                        PersonnelType = s.PersonnelType,
                        Position = s.Position,
                        PositionType = s.Position,
                        PositionLevel = s.PositionLevel,
                        StartDate = s.StartDate,
                        RetiredDate = s.RetiredDate.ToLocalDateTime(),
                        RetiredYear = s.RetiredYear.GetValueOrDefault().ToLocalYear(),
                        Section = s.Section,
                        Division = s.Division,
                        Faculty = s.Faculty

                    }).ToList();

                return result;

            }
            else
            {
                return personnel.Where(m => m.RetiredDate >= startOfYear && m.RetiredDate <= endOfYear)
                    .Select(s => new RetiredPersonDataTableModel
                    {
                        PersonnelId = s.PersonnelId,
                        PersonnelName = string.Format("{0} {1} {2}", s.TitleName, s.FirstName, s.LastName),
                        DateOfBirth = s.DateOfBirth.ToLocalDateTime(),
                        Age = DateTime.UtcNow.Year - s.DateOfBirth.GetValueOrDefault().Year,
                        PersonnelType = s.PersonnelType,
                        Position = s.Position,
                        PositionType = s.Position,
                        PositionLevel = s.PositionLevel,
                        StartDate = s.StartDate,
                        RetiredDate = s.RetiredDate.ToLocalDateTime(),
                        RetiredYear = s.RetiredYear.GetValueOrDefault().ToLocalYear(),
                        Section = s.Section,
                        Division = s.Division,
                        Faculty = s.Faculty

                    }).ToList();

            }
        }

        public object GetAllPersonnelRetired(int total, int type, List<int> filter)
        {
            var half = total / 2 - 1;
            var yearBack = DateTime.UtcNow.AddYears(-half);

            var personnel = _dcPersonRepository.GetAll();
            if (filter.Any())
            {
                personnel = personnel.Where(x => filter.Contains(x.FacultyId.GetValueOrDefault()));
            }
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

                    var personCount = personnel.Where(m => m.StartDate <= endOfYear && (m.RetiredDate < endOfYear || m.RetiredDate == null)).Count();
                    personData.Add(personCount);

                    var retiredPersonCount = personnel.Where(m => m.RetiredDate >= startOfYear && m.RetiredDate <= endOfYear).Count();
                    if (retiredPersonCount > 0) retiredPersonData.Add(retiredPersonCount);

                    var personRetiredPredict = personnel.Where(m => (endOfYear.Year - m.DateOfBirth.GetValueOrDefault().Year) == 60).Count();
                    if (personRetiredPredict > 0) predictRetiredPersondata.Add(personRetiredPredict);
                    if (currentDate.Year == DateTime.UtcNow.Year)
                    {
                        retiredPersonView.Person = personCount;
                        retiredPersonView.PersonStart = personnel.Where(m => m.StartDate >= startOfYear && m.StartDate <= endOfYear).Count();
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
                        Person = personnel.Where(m => m.StartDate <= endOfYear && (m.RetiredDate < endOfYear || m.RetiredDate == null)).ToList(),
                        RetiredPerson = personnel.Where(m => m.RetiredDate >= startOfYear && m.RetiredDate <= endOfYear).ToList(),
                        PredecitionRetiredPerson = personnel.Where(m => (endOfYear.Year - m.DateOfBirth.GetValueOrDefault().Year) > 60).ToList()
                    };
                    result.Add(model);

                }
                return result.OrderBy(o => o.Year);
            }
        }

        public object GetAllPersonnelGroupWorkDuration(int type, List<int> filter)
        {

            var personnel = _dcPersonRepository.GetAll();
            if (filter.Any())
            {
                personnel = personnel.Where(x => filter.Contains(x.FacultyId.GetValueOrDefault()));
            }
            personnel = personnel.OrderBy(o => o.PersonnelTypeId);
            var distinctPersonnelTypeId = personnel.Select(s => new { s.PersonnelType, s.PersonnelTypeId }).Distinct();

            if (type == 1)
            {
                var label = new List<string>();
                var dataCoutLessThanThree = new List<int>();
                var dataCoutThreeToFive = new List<int>();
                var dataCoutSixToNine = new List<int>();
                var dataCoutTenToFifteen = new List<int>();
                var dataCoutSixteenToTwenty = new List<int>();
                var dataCoutMorethanTwenty = new List<int>();
                var index = 0;
                foreach (var personnelType in distinctPersonnelTypeId)
                {


                    label.Add(personnelType.PersonnelType);

                    var count = personnel.Where(m => (DateTime.UtcNow.Year - m.StartDate.Value.Year) < 3 && m.PersonnelTypeId == personnelType.PersonnelTypeId && m.PersonnelType == personnelType.PersonnelType).Count();
                    dataCoutLessThanThree.Add(count);

                    count = personnel.Where(m => (DateTime.UtcNow.Year - m.StartDate.Value.Year) >= 3 && (DateTime.UtcNow.Year - m.StartDate.Value.Year) <= 5 && m.PersonnelTypeId == personnelType.PersonnelTypeId && m.PersonnelType == personnelType.PersonnelType).Count();
                    dataCoutThreeToFive.Add(count);

                    count = personnel.Where(m => (DateTime.UtcNow.Year - m.StartDate.Value.Year) >= 6 && (DateTime.UtcNow.Year - m.StartDate.Value.Year) <= 9 && m.PersonnelTypeId == personnelType.PersonnelTypeId && m.PersonnelType == personnelType.PersonnelType).Count();
                    dataCoutSixToNine.Add(count);

                    count = personnel.Where(m => (DateTime.UtcNow.Year - m.StartDate.Value.Year) >= 10 && (DateTime.UtcNow.Year - m.StartDate.Value.Year) <= 15 && m.PersonnelTypeId == personnelType.PersonnelTypeId && m.PersonnelType == personnelType.PersonnelType).Count();
                    dataCoutTenToFifteen.Add(count);

                    count = personnel.Where(m => (DateTime.UtcNow.Year - m.StartDate.Value.Year) >= 16 && (DateTime.UtcNow.Year - m.StartDate.Value.Year) <= 20 && m.PersonnelTypeId == personnelType.PersonnelTypeId && m.PersonnelType == personnelType.PersonnelType).Count();
                    dataCoutSixteenToTwenty.Add(count);

                    count = personnel.Where(m => (DateTime.UtcNow.Year - m.StartDate.Value.Year) > 20 && m.PersonnelTypeId == personnelType.PersonnelTypeId && m.PersonnelType == personnelType.PersonnelType).Count();
                    dataCoutMorethanTwenty.Add(count);


                }
                var dataLessThanThree = new GraphDataSet
                {
                    Label = "น้อยกว่า 3 ปี",
                    Data = dataCoutLessThanThree,
                    BackgroundColor = index.BackgroundColor(),
                    BorderColor = index.BorderColor()

                };
                index++;
                var dataSixToNine = new GraphDataSet
                {
                    Label = "6 - 9 ปี",
                    Data = dataCoutSixToNine,
                    BackgroundColor = index.BackgroundColor(),
                    BorderColor = index.BorderColor()

                };
                index++;
                var dataThreeToFive = new GraphDataSet
                {
                    Label = "3 - 5 ปี",
                    Data = dataCoutThreeToFive,
                    BackgroundColor = index.BackgroundColor(),
                    BorderColor = index.BorderColor()

                };
                index++;
                var dataTenToFifteen = new GraphDataSet
                {
                    Label = "10 - 15 ปี",
                    Data = dataCoutTenToFifteen,
                    BackgroundColor = index.BackgroundColor(),
                    BorderColor = index.BorderColor()

                };
                index++;
                var dataSixteenToTwenty = new GraphDataSet
                {
                    Label = "16 - 20 ปี",
                    Data = dataCoutSixteenToTwenty,
                    BackgroundColor = index.BackgroundColor(),
                    BorderColor = index.BorderColor()

                };
                index++;
                var dataMorethanTwenty = new GraphDataSet
                {
                    Label = "20 ปีขึ้นไป",
                    Data = dataCoutMorethanTwenty,
                    BackgroundColor = index.BackgroundColor(),
                    BorderColor = index.BorderColor()

                };

                var listGraphDataSet = new List<GraphDataSet>
                {
            dataLessThanThree,
            dataThreeToFive,
            dataSixToNine,
            dataTenToFifteen,
            dataSixteenToTwenty,
            dataMorethanTwenty
            };


                var result = new GraphData
                {
                    GraphDataSet = listGraphDataSet,
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

        public List<PersonGroupWorkDurationDataSourceModel> GetAllPersonnelGroupWorkDurationDataSource(string personType, int? index, List<int> filter)
        {

            var personnel = _dcPersonRepository.GetAll().Where(m => !string.IsNullOrEmpty(personType) ? m.PersonnelType == personType : true);
            if (filter.Any())
            {
                personnel = personnel.Where(x => filter.Contains(x.FacultyId.GetValueOrDefault()));
            }
            personnel = personnel.OrderBy(o => o.PersonnelTypeId);
            var distinctPersonnelTypeId = personnel.Select(s => new { s.PersonnelType, s.PersonnelTypeId }).Distinct();

            var list = new List<PersonGroupWorkDurationDataSourceModel>();
            foreach (var personnelType in distinctPersonnelTypeId)
            {
                var personData = personnel.Where(m => m.PersonnelType == personnelType.PersonnelType && m.PersonnelTypeId == personnelType.PersonnelTypeId);
                var asd = personData.Where(m => (DateTime.UtcNow.Year - m.StartDate.Value.Year) > 20).ToList();

                var listPerson = new List<PersonGroupWorkDurationDataSource>();
                if (index == 0 || index == null)
                {
                    var persons = new PersonGroupWorkDurationDataSource
                    {
                        WorkDuration = "น้อยกว่า 3 ปี",
                        Person = personData.Where(m => (DateTime.UtcNow.Year - m.StartDate.Value.Year) < 3).Select(s => new PersonnelDataSourceViewModel
                        {
                            AdminPosition = s.AdminPosition,
                            AdminPositionType = s.AdminPositionType,
                            BloodType = s.BloodType,
                            Country = s.Country,
                            DateOfBirth = s.DateOfBirth.ToLocalDateTime(),
                            Division = s.Division,
                            Education = s.Education,
                            EducationLevel = s.EducationLevel,
                            Faculty = s.Faculty,
                            Gender = s.Gender,
                            GraduateDate = s.GraduateDate.ToLocalDateTime(),
                            CitizenId = s.CitizenId,
                            Major = s.Major,
                            Nation = s.Nation,
                            PersonName = string.Format("{0} {1} {2}", s.TitleName, s.FirstName, s.LastName),
                            PersonnelId = s.PersonnelId,
                            PersonnelType = s.PersonnelType,
                            Position = s.Position,
                            PositionLevel = s.PositionLevel,
                            PositionType = s.PositionType,
                            Province = s.Province,
                            RetiredDate = s.RetiredDate.ToLocalDateTime(),
                            RetiredYear = s.RetiredYear.GetValueOrDefault().ToLocalYear(),
                            Salary = s.Salary,
                            Section = s.Section,
                            StartDate = s.StartDate.ToLocalDateTime(),
                            StartEducationDate = s.StartEducationDate.ToLocalDateTime(),
                            TitleEducation = s.TitleEducation,
                            University = s.University,
                            ZipCode = s.ZipCode,
                            Address = string.Format("{0} ซอย {1} หมู่ {2} ต.{4} อ.{4} จ.{5}", s.HomeNumber, s.Soi, s.Moo, s.SubDistrict, s.District, s.Province)

                        }).ToList()
                    };
                    listPerson.Add(persons);
                }
                if (index == 1 || index == null)
                {
                    var persons = new PersonGroupWorkDurationDataSource
                    {
                        WorkDuration = "3 - 5 ปี",
                        Person = personData.Where(m => (DateTime.UtcNow.Year - m.StartDate.Value.Year) >= 3 && (DateTime.UtcNow.Year - m.StartDate.Value.Year) <= 5).Select(s => new PersonnelDataSourceViewModel
                        {
                            AdminPosition = s.AdminPosition,
                            AdminPositionType = s.AdminPositionType,
                            BloodType = s.BloodType,
                            Country = s.Country,
                            DateOfBirth = s.DateOfBirth.ToLocalDateTime(),
                            Division = s.Division,
                            Education = s.Education,
                            EducationLevel = s.EducationLevel,
                            Faculty = s.Faculty,
                            Gender = s.Gender,
                            GraduateDate = s.GraduateDate.ToLocalDateTime(),
                            CitizenId = s.CitizenId,
                            Major = s.Major,
                            Nation = s.Nation,
                            PersonName = string.Format("{0} {1} {2}", s.TitleName, s.FirstName, s.LastName),
                            PersonnelId = s.PersonnelId,
                            PersonnelType = s.PersonnelType,
                            Position = s.Position,
                            PositionLevel = s.PositionLevel,
                            PositionType = s.PositionType,
                            Province = s.Province,
                            RetiredDate = s.RetiredDate.ToLocalDateTime(),
                            RetiredYear = s.RetiredYear.GetValueOrDefault().ToLocalYear(),
                            Salary = s.Salary,
                            Section = s.Section,
                            StartDate = s.StartDate.ToLocalDateTime(),
                            StartEducationDate = s.StartEducationDate.ToLocalDateTime(),
                            TitleEducation = s.TitleEducation,
                            University = s.University,
                            ZipCode = s.ZipCode,
                            Address = string.Format("{0} ซอย {1} หมู่ {2} ต.{4} อ.{4} จ.{5}", s.HomeNumber, s.Soi, s.Moo, s.SubDistrict, s.District, s.Province)

                        }).ToList()
                    };
                    listPerson.Add(persons);
                }
                if (index == 2 || index == null)
                {
                    var persons = new PersonGroupWorkDurationDataSource
                    {
                        WorkDuration = "6 - 9 ปี",
                        Person = personData.Where(m => (DateTime.UtcNow.Year - m.StartDate.Value.Year) >= 6 && (DateTime.UtcNow.Year - m.StartDate.Value.Year) <= 9).Select(s => new PersonnelDataSourceViewModel
                        {
                            AdminPosition = s.AdminPosition,
                            AdminPositionType = s.AdminPositionType,
                            BloodType = s.BloodType,
                            Country = s.Country,
                            DateOfBirth = s.DateOfBirth.ToLocalDateTime(),
                            Division = s.Division,
                            Education = s.Education,
                            EducationLevel = s.EducationLevel,
                            Faculty = s.Faculty,
                            Gender = s.Gender,
                            GraduateDate = s.GraduateDate.ToLocalDateTime(),
                            CitizenId = s.CitizenId,
                            Major = s.Major,
                            Nation = s.Nation,
                            PersonName = string.Format("{0} {1} {2}", s.TitleName, s.FirstName, s.LastName),
                            PersonnelId = s.PersonnelId,
                            PersonnelType = s.PersonnelType,
                            Position = s.Position,
                            PositionLevel = s.PositionLevel,
                            PositionType = s.PositionType,
                            Province = s.Province,
                            RetiredDate = s.RetiredDate.ToLocalDateTime(),
                            RetiredYear = s.RetiredYear.GetValueOrDefault().ToLocalYear(),
                            Salary = s.Salary,
                            Section = s.Section,
                            StartDate = s.StartDate.ToLocalDateTime(),
                            StartEducationDate = s.StartEducationDate.ToLocalDateTime(),
                            TitleEducation = s.TitleEducation,
                            University = s.University,
                            ZipCode = s.ZipCode,
                            Address = string.Format("{0} ซอย {1} หมู่ {2} ต.{4} อ.{4} จ.{5}", s.HomeNumber, s.Soi, s.Moo, s.SubDistrict, s.District, s.Province)

                        }).ToList()
                    };
                    listPerson.Add(persons);
                }
                if (index == 3 || index == null)
                {
                    var persons = new PersonGroupWorkDurationDataSource
                    {
                        WorkDuration = "10 - 15 ปี",
                        Person = personData.Where(m => (DateTime.UtcNow.Year - m.StartDate.Value.Year) >= 10 && (DateTime.UtcNow.Year - m.StartDate.Value.Year) <= 15).Select(s => new PersonnelDataSourceViewModel
                        {
                            AdminPosition = s.AdminPosition,
                            AdminPositionType = s.AdminPositionType,
                            BloodType = s.BloodType,
                            Country = s.Country,
                            DateOfBirth = s.DateOfBirth.ToLocalDateTime(),
                            Division = s.Division,
                            Education = s.Education,
                            EducationLevel = s.EducationLevel,
                            Faculty = s.Faculty,
                            Gender = s.Gender,
                            GraduateDate = s.GraduateDate.ToLocalDateTime(),
                            CitizenId = s.CitizenId,
                            Major = s.Major,
                            Nation = s.Nation,
                            PersonName = string.Format("{0} {1} {2}", s.TitleName, s.FirstName, s.LastName),
                            PersonnelId = s.PersonnelId,
                            PersonnelType = s.PersonnelType,
                            Position = s.Position,
                            PositionLevel = s.PositionLevel,
                            PositionType = s.PositionType,
                            Province = s.Province,
                            RetiredDate = s.RetiredDate.ToLocalDateTime(),
                            RetiredYear = s.RetiredYear.GetValueOrDefault().ToLocalYear(),
                            Salary = s.Salary,
                            Section = s.Section,
                            StartDate = s.StartDate.ToLocalDateTime(),
                            StartEducationDate = s.StartEducationDate.ToLocalDateTime(),
                            TitleEducation = s.TitleEducation,
                            University = s.University,
                            ZipCode = s.ZipCode,
                            Address = string.Format("{0} ซอย {1} หมู่ {2} ต.{4} อ.{4} จ.{5}", s.HomeNumber, s.Soi, s.Moo, s.SubDistrict, s.District, s.Province)

                        }).ToList()
                    };
                    listPerson.Add(persons);
                }
                if (index == 4 || index == null)
                {
                    var persons = new PersonGroupWorkDurationDataSource
                    {
                        WorkDuration = "16 - 20 ปี",
                        Person = personData.Where(m => (DateTime.UtcNow.Year - m.StartDate.Value.Year) >= 16 && (DateTime.UtcNow.Year - m.StartDate.Value.Year) <= 20).Select(s => new PersonnelDataSourceViewModel
                        {
                            AdminPosition = s.AdminPosition,
                            AdminPositionType = s.AdminPositionType,
                            BloodType = s.BloodType,
                            Country = s.Country,
                            DateOfBirth = s.DateOfBirth.ToLocalDateTime(),
                            Division = s.Division,
                            Education = s.Education,
                            EducationLevel = s.EducationLevel,
                            Faculty = s.Faculty,
                            Gender = s.Gender,
                            GraduateDate = s.GraduateDate.ToLocalDateTime(),
                            CitizenId = s.CitizenId,
                            Major = s.Major,
                            Nation = s.Nation,
                            PersonName = string.Format("{0} {1} {2}", s.TitleName, s.FirstName, s.LastName),
                            PersonnelId = s.PersonnelId,
                            PersonnelType = s.PersonnelType,
                            Position = s.Position,
                            PositionLevel = s.PositionLevel,
                            PositionType = s.PositionType,
                            Province = s.Province,
                            RetiredDate = s.RetiredDate.ToLocalDateTime(),
                            RetiredYear = s.RetiredYear.GetValueOrDefault().ToLocalYear(),
                            Salary = s.Salary,
                            Section = s.Section,
                            StartDate = s.StartDate.ToLocalDateTime(),
                            StartEducationDate = s.StartEducationDate.ToLocalDateTime(),
                            TitleEducation = s.TitleEducation,
                            University = s.University,
                            ZipCode = s.ZipCode,
                            Address = string.Format("{0} ซอย {1} หมู่ {2} ต.{4} อ.{4} จ.{5}", s.HomeNumber, s.Soi, s.Moo, s.SubDistrict, s.District, s.Province)

                        }).ToList()
                    };
                    listPerson.Add(persons);
                }
                if (index == 5 || index == null)
                {
                    var persons = new PersonGroupWorkDurationDataSource
                    {
                        WorkDuration = "20 ปีขึ้นไป",
                        Person = personData.Where(m => (DateTime.UtcNow.Year - m.StartDate.Value.Year) > 20).Select(s => new PersonnelDataSourceViewModel
                        {
                            AdminPosition = s.AdminPosition,
                            AdminPositionType = s.AdminPositionType,
                            BloodType = s.BloodType,
                            Country = s.Country,
                            DateOfBirth = s.DateOfBirth.ToLocalDateTime(),
                            Division = s.Division,
                            Education = s.Education,
                            EducationLevel = s.EducationLevel,
                            Faculty = s.Faculty,
                            Gender = s.Gender,
                            GraduateDate = s.GraduateDate.ToLocalDateTime(),
                            CitizenId = s.CitizenId,
                            Major = s.Major,
                            Nation = s.Nation,
                            PersonName = string.Format("{0} {1} {2}", s.TitleName, s.FirstName, s.LastName),
                            PersonnelId = s.PersonnelId,
                            PersonnelType = s.PersonnelType,
                            Position = s.Position,
                            PositionLevel = s.PositionLevel,
                            PositionType = s.PositionType,
                            Province = s.Province,
                            RetiredDate = s.RetiredDate.ToLocalDateTime(),
                            RetiredYear = s.RetiredYear.GetValueOrDefault().ToLocalYear(),
                            Salary = s.Salary,
                            Section = s.Section,
                            StartDate = s.StartDate.ToLocalDateTime(),
                            StartEducationDate = s.StartEducationDate.ToLocalDateTime(),
                            TitleEducation = s.TitleEducation,
                            University = s.University,
                            ZipCode = s.ZipCode,
                            Address = string.Format("{0} ซอย {1} หมู่ {2} ต.{4} อ.{4} จ.{5}", s.HomeNumber, s.Soi, s.Moo, s.SubDistrict, s.District, s.Province)

                        }).ToList()
                    };
                    listPerson.Add(persons);
                }

                var personGroup = new PersonGroupWorkDurationDataSourceModel
                {

                    PersonGroupTypeId = personnelType.PersonnelTypeId,
                    PersonGroupTypeName = personnelType.PersonnelType,
                    PersonGroupWorkDuration = listPerson
                };

                list.Add(personGroup);
            }

            return list;



        }

        public object GetAllPersonnelGroupAdminPositionType(int type, List<int> filter)
        {
            var personnel = _dcPersonRepository.GetAll();
            if (filter.Any())
            {
                personnel = personnel.Where(x => filter.Contains(x.FacultyId.GetValueOrDefault()));
            }
            personnel = personnel.OrderBy(o => o.AdminPositionType);
            if (type == 1)
            {

                var label = new List<string>();
                var distinctPersonnelType = personnel.Select(s => new { s.PersonnelTypeId, s.PersonnelType }).Distinct();
                var graphDatasetList = new List<GraphDataSet>();
                var distinctAdminPositionTypeByPersonnelType = personnel.Select(s => s.AdminPositionType).Distinct();

                foreach (var ap in distinctAdminPositionTypeByPersonnelType)
                {
                    label.Add(ap);
                }
                var index = 0;
                foreach (var p in distinctPersonnelType)
                {
                    var data = new List<int>();
                    var adminPositionTypeByPersonnelType = personnel.Where(m => m.PersonnelType == p.PersonnelType && m.PersonnelTypeId == p.PersonnelTypeId);
                    foreach (var ap in distinctAdminPositionTypeByPersonnelType)
                    {
                        data.Add(adminPositionTypeByPersonnelType.Where(m => m.AdminPositionType == ap).Count());
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
                    Label = label,
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
        public List<PersonGroupAdminPositionDataSourceModel> GetAllPersonnelGroupAdminPositionTypeDataSource(string adminPositionType, string personnelType, List<int> filter)
        {
            var personnel = _dcPersonRepository.GetAll().Where(m => !string.IsNullOrEmpty(adminPositionType) ? m.AdminPositionType == adminPositionType : true);
            if (filter.Any())
            {
                personnel = personnel.Where(x => filter.Contains(x.FacultyId.GetValueOrDefault()));
            }
            personnel = personnel.OrderBy(o => o.AdminPositionType);
            var adminPositionTypeBy = personnel.Select(s => s.AdminPositionType).Distinct();
            var datatableList = new List<PersonGroupAdminPositionDataSourceModel>();
            foreach (var ap in adminPositionTypeBy)
            {

                var personnelTypeData = personnel.Where(m => m.AdminPositionType == ap);
                var distinctPersonnelType = personnelTypeData.Where(m => !string.IsNullOrEmpty(personnelType) ? m.PersonnelType == personnelType : true).Select(s => new { s.PersonnelTypeId, s.PersonnelType }).Distinct();
                var dataList = new List<PersonGroupAdminPositionDataSource>();
                foreach (var p in distinctPersonnelType)
                {
                    var data = new PersonGroupAdminPositionDataSource
                    {
                        PersonGroupTypeId = p.PersonnelTypeId,
                        PersonGroupTypeName = p.PersonnelType,
                        Person = personnelTypeData.Where(m => m.PersonnelType == p.PersonnelType && m.PersonnelTypeId == p.PersonnelTypeId)
                         .Select(s => new PersonnelDataSourceViewModel
                         {
                             AdminPosition = s.AdminPosition,
                             AdminPositionType = s.AdminPositionType,
                             BloodType = s.BloodType,
                             Country = s.Country,
                             DateOfBirth = s.DateOfBirth.ToLocalDateTime(),
                             Division = s.Division,
                             Education = s.Education,
                             EducationLevel = s.EducationLevel,
                             Faculty = s.Faculty,
                             Gender = s.Gender,
                             GraduateDate = s.GraduateDate.ToLocalDateTime(),
                             CitizenId = s.CitizenId,
                             Major = s.Major,
                             Nation = s.Nation,
                             PersonName = string.Format("{0} {1} {2}", s.TitleName, s.FirstName, s.LastName),
                             PersonnelId = s.PersonnelId,
                             PersonnelType = s.PersonnelType,
                             Position = s.Position,
                             PositionLevel = s.PositionLevel,
                             PositionType = s.PositionType,
                             Province = s.Province,
                             RetiredDate = s.RetiredDate.ToLocalDateTime(),
                             RetiredYear = s.RetiredYear.GetValueOrDefault().ToLocalYear(),
                             Salary = s.Salary,
                             Section = s.Section,
                             StartDate = s.StartDate.ToLocalDateTime(),
                             StartEducationDate = s.StartEducationDate.ToLocalDateTime(),
                             TitleEducation = s.TitleEducation,
                             University = s.University,
                             ZipCode = s.ZipCode,
                             Address = string.Format("{0} ซอย {1} หมู่ {2} ต.{4} อ.{4} จ.{5}", s.HomeNumber, s.Soi, s.Moo, s.SubDistrict, s.District, s.Province)

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

        public object GetAllPersonnelGroupFaculty(int type, List<int> filter)
        {
            var personnel = _dcPersonRepository.GetAll();
            if (filter.Any())
            {
                personnel = personnel.Where(x => filter.Contains(x.FacultyId.GetValueOrDefault()));
            }
            personnel = personnel.OrderBy(o => o.FacultyId);
            if (type == 1)
            {

                var label = new List<string>();
                var distinctPersonnelType = personnel.Select(s => new { s.PersonnelTypeId, s.PersonnelType }).Distinct();
                var graphDatasetList = new List<GraphDataSet>();
                var distinctfacultyByPersonnelType = personnel.Select(s => new { s.FacultyId, s.Faculty }).Distinct();

                foreach (var fc in distinctfacultyByPersonnelType)
                {
                    label.Add(fc.Faculty);
                }
                var index = 0;
                foreach (var p in distinctPersonnelType)
                {
                    var data = new List<int>();
                    var facultyByPersonnelType = personnel.Where(m => m.PersonnelType == p.PersonnelType && m.PersonnelTypeId == p.PersonnelTypeId).OrderBy(o => o.PersonnelTypeId);

                    foreach (var fc in distinctfacultyByPersonnelType)
                    {
                        data.Add(facultyByPersonnelType.Where(m => m.Faculty == fc.Faculty && m.FacultyId == fc.FacultyId).Count());
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
                    Label = label,
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

        public List<PersonGroupFacultyDataSourceModel> GetAllPersonnelGroupFacultyDataSource(string faculty, string personnelType, List<int> filter)
        {
            var personnel = _dcPersonRepository.GetAll().Where(m => !string.IsNullOrEmpty(faculty) ? m.Faculty == faculty : true);
            if (filter.Any())
            {
                personnel = personnel.Where(x => filter.Contains(x.FacultyId.GetValueOrDefault()));
            }
            personnel = personnel.OrderBy(o => o.FacultyId);
            var facultyByPersonnelType = personnel.Select(s => new { s.Faculty, s.FacultyId }).Distinct();
            var datatableList = new List<PersonGroupFacultyDataSourceModel>();
            foreach (var fc in facultyByPersonnelType)
            {

                var personnelTypeData = personnel.Where(m => m.Faculty == fc.Faculty && m.FacultyId == fc.FacultyId).OrderBy(o => o.PersonnelTypeId);
                var distinctPersonnelType = personnelTypeData.Where(m => !string.IsNullOrEmpty(personnelType) ? m.PersonnelType == personnelType : true).Select(s => new { s.PersonnelTypeId, s.PersonnelType }).Distinct();
                var dataList = new List<PersonGroupFacultyDataSource>();
                foreach (var p in distinctPersonnelType)
                {
                    var data = new PersonGroupFacultyDataSource
                    {
                        PersonGroupTypeId = p.PersonnelTypeId,
                        PersonGroupTypeName = p.PersonnelType,
                        Person = personnelTypeData.Where(m => m.PersonnelType == p.PersonnelType && m.PersonnelTypeId == p.PersonnelTypeId)
                        .Select(s => new PersonnelDataSourceViewModel
                        {
                            AdminPosition = s.AdminPosition,
                            AdminPositionType = s.AdminPositionType,
                            BloodType = s.BloodType,
                            Country = s.Country,
                            DateOfBirth = s.DateOfBirth.ToLocalDateTime(),
                            Division = s.Division,
                            Education = s.Education,
                            EducationLevel = s.EducationLevel,
                            Faculty = s.Faculty,
                            Gender = s.Gender,
                            GraduateDate = s.GraduateDate.ToLocalDateTime(),
                            CitizenId = s.CitizenId,
                            Major = s.Major,
                            Nation = s.Nation,
                            PersonName = string.Format("{0} {1} {2}", s.TitleName, s.FirstName, s.LastName),
                            PersonnelId = s.PersonnelId,
                            PersonnelType = s.PersonnelType,
                            Position = s.Position,
                            PositionLevel = s.PositionLevel,
                            PositionType = s.PositionType,
                            Province = s.Province,
                            RetiredDate = s.RetiredDate.ToLocalDateTime(),
                            RetiredYear = s.RetiredYear.GetValueOrDefault().ToLocalYear(),
                            Salary = s.Salary,
                            Section = s.Section,
                            StartDate = s.StartDate.ToLocalDateTime(),
                            StartEducationDate = s.StartEducationDate.ToLocalDateTime(),
                            TitleEducation = s.TitleEducation,
                            University = s.University,
                            ZipCode = s.ZipCode,
                            Address = string.Format("{0} ซอย {1} หมู่ {2} ต.{4} อ.{4} จ.{5}", s.HomeNumber, s.Soi, s.Moo, s.SubDistrict, s.District, s.Province)

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

        public object GetAllPersonnelPositionFaculty(int type, List<int> filter)
        {
            var isSubGraphDataSet = false;
            var personnel = _dcPersonRepository.GetAll().Where(m => m.PositionTypeId == "ก" && m.PositionType == "ประเภทวิชาการ");
            if (filter.Any())
            {
                personnel = personnel.Where(x => filter.Contains(x.FacultyId.GetValueOrDefault()));
                isSubGraphDataSet = true;
            }
            personnel = personnel.OrderBy(o => o.FacultyId);
            if (type == 1)
            {
                var index = 0;
                if (isSubGraphDataSet)
                {
                    var label = new List<string>();
                    var data = new List<int>();
                    var groupByPosition = personnel.GroupBy(x => x.Position)
                        .ToList();
                    var graphDatasetList = new List<GraphDataSet>();
                    var listViewData = new List<ViewData>();
                    foreach (var item in groupByPosition)
                    {
                        data.Add(item.Count());
                        label.Add(item.Key);
                        index++;
                    }
                    var graphDataSet = new GraphDataSet
                    {
                        Data = data,
                        Label = personnel.LastOrDefault().Faculty
                    };

                    listViewData.Add(new ViewData
                    {
                        index = 0,
                        ListViewData = graphDataSet

                    });

                    var subGraphData = new GraphData
                    {
                        GraphDataSet = new List<GraphDataSet> { graphDataSet },
                        Label = label,
                        ViewData = listViewData,
                        IsSubGraphDataSet = isSubGraphDataSet
                    };

                    return subGraphData;
                }
                else
                {
                    var label = new List<string>();
                    var distinctPersonPosition = personnel.Select(s => s.Position).Distinct();
                    var graphDatasetList = new List<GraphDataSet>();
                    var distinctFacultyByPosition = personnel.Select(s => new { s.FacultyId, s.Faculty }).Distinct();

                    foreach (var fp in distinctFacultyByPosition)
                    {
                        label.Add(fp.Faculty);
                    }
                    foreach (var position in distinctPersonPosition)
                    {
                        var data = new List<int>();
                        var facultyByPosition = personnel.Where(m => m.Position == position);

                        foreach (var fp in distinctFacultyByPosition)
                        {
                            data.Add(facultyByPosition.Where(m => m.Faculty == fp.Faculty && m.FacultyId == fp.FacultyId).Count());
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
                        Label = label,
                        GraphDataSet = graphDatasetList
                    };

                    return graphData;

                }


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

        public List<PersonPositionFacultyDataSourceModel> GetAllPersonnelPositionFacultyDataSource(string faculty, string position, List<int> filter)
        {
            var personnel = _dcPersonRepository.GetAll().Where(m => m.PositionTypeId == "ก" && m.PositionType == "ประเภทวิชาการ").Where(m => !string.IsNullOrEmpty(faculty) ? m.Faculty == faculty : true);
            if (filter.Any())
            {
                personnel = personnel.Where(x => filter.Contains(x.FacultyId.GetValueOrDefault()));
            }
            personnel = personnel.OrderBy(o => o.FacultyId);
            var facultyByPersonnelType = personnel.Select(s => new { s.Faculty, s.FacultyId }).Distinct();
            var datatableList = new List<PersonPositionFacultyDataSourceModel>();
            foreach (var fc in facultyByPersonnelType)
            {

                var personnelType = personnel.Where(m => m.Faculty == fc.Faculty && m.FacultyId == fc.FacultyId);
                var distinctPosition = personnelType.Where(m => !string.IsNullOrEmpty(position) ? m.Position == position : true).Select(s => s.Position).Distinct();
                var dataList = new List<PersonPosiotionFacultyDataSource>();
                foreach (var positionData in distinctPosition)
                {
                    var data = new PersonPosiotionFacultyDataSource
                    {
                        PersonPosition = positionData,
                        Person = personnelType.Where(m => m.Position == positionData)
                        .Select(s => new PersonnelDataSourceViewModel
                        {
                            AdminPosition = s.AdminPosition,
                            AdminPositionType = s.AdminPositionType,
                            BloodType = s.BloodType,
                            Country = s.Country,
                            DateOfBirth = s.DateOfBirth.ToLocalDateTime(),
                            Division = s.Division,
                            Education = s.Education,
                            EducationLevel = s.EducationLevel,
                            Faculty = s.Faculty,
                            Gender = s.Gender,
                            GraduateDate = s.GraduateDate.ToLocalDateTime(),
                            CitizenId = s.CitizenId,
                            Major = s.Major,
                            Nation = s.Nation,
                            PersonName = string.Format("{0} {1} {2}", s.TitleName, s.FirstName, s.LastName),
                            PersonnelId = s.PersonnelId,
                            PersonnelType = s.PersonnelType,
                            Position = s.Position,
                            PositionLevel = s.PositionLevel,
                            PositionType = s.PositionType,
                            Province = s.Province,
                            RetiredDate = s.RetiredDate.ToLocalDateTime(),
                            RetiredYear = s.RetiredYear.GetValueOrDefault().ToLocalYear(),
                            Salary = s.Salary,
                            Section = s.Section,
                            StartDate = s.StartDate.ToLocalDateTime(),
                            StartEducationDate = s.StartEducationDate.ToLocalDateTime(),
                            TitleEducation = s.TitleEducation,
                            University = s.University,
                            ZipCode = s.ZipCode,
                            Address = string.Format("{0} ซอย {1} หมู่ {2} ต.{4} อ.{4} จ.{5}", s.HomeNumber, s.Soi, s.Moo, s.SubDistrict, s.District, s.Province)

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

        public object GetAllPersonnelGroupRetiredYear(RetiredGraphInputDto input, List<int> filter)
        {
            var personnel = _dcPersonRepository.GetAll().Where(m => input.StartDate != null && input.EndDate != null ?
            m.RetiredDate >= input.StartDate.ToUtcDateTime() && m.RetiredDate <= input.EndDate.ToUtcDateTime() &&
            m.RetiredYear >= input.StartDate.ToUtcRetiredYear() && m.RetiredYear <= input.EndDate.ToUtcRetiredYear()
            : m.RetiredYear <= DateTime.UtcNow.Year);
            if (filter.Any())
            {
                personnel = personnel.Where(x => filter.Contains(x.FacultyId.GetValueOrDefault()));
            }
            personnel = personnel.OrderBy(o => o.RetiredYear);
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

        public List<PersonGroupRetiredYearDataSourceModel> GetAllPersonnelGroupRetiredYearDataSource(RetiredInputDto input, List<int> filter)
        {
            var personnel = _dcPersonRepository.GetAll().Where(m => input.StartDate != null && input.EndDate != null ?
                        m.RetiredDate >= input.StartDate.ToUtcDateTime() && m.RetiredDate <= input.EndDate.ToUtcDateTime() &&
                        m.RetiredYear >= input.StartDate.ToUtcRetiredYear() && m.RetiredYear <= input.EndDate.ToUtcRetiredYear()
                        : m.RetiredYear <= DateTime.UtcNow.Year)
                .Where(m => !string.IsNullOrEmpty(input.RetiredYear) ? m.RetiredYear == Int32.Parse(input.RetiredYear) - 543 : true);
            if (filter.Any())
            {
                personnel = personnel.Where(x => filter.Contains(x.FacultyId.GetValueOrDefault()));
            }
            personnel = personnel.OrderBy(o => o.RetiredYear);
            var distinctretiredYear = personnel.Select(s => s.RetiredYear).Distinct();
            var datatableList = new List<PersonGroupRetiredYearDataSourceModel>();
            foreach (var ry in distinctretiredYear)
            {

                var personnelType = personnel.Where(m => m.RetiredYear == ry);
                var distinctPersonnelType = personnelType.Where(m => !string.IsNullOrEmpty(input.PersonnelType) ? m.PersonnelType == input.PersonnelType : true)
                    .Select(s => new { s.PersonnelTypeId, s.PersonnelType }).Distinct();
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
                             DateOfBirth = s.DateOfBirth.ToLocalDateTime(),
                             Division = s.Division,
                             Education = s.Education,
                             EducationLevel = s.EducationLevel,
                             Faculty = s.Faculty,
                             Gender = s.Gender,
                             GraduateDate = s.GraduateDate.ToLocalDateTime(),
                             CitizenId = s.CitizenId,
                             Major = s.Major,
                             Nation = s.Nation,
                             PersonName = string.Format("{0} {1} {2}", s.TitleName, s.FirstName, s.LastName),
                             PersonnelId = s.PersonnelId,
                             PersonnelType = s.PersonnelType,
                             Position = s.Position,
                             PositionLevel = s.PositionLevel,
                             PositionType = s.PositionType,
                             Province = s.Province,
                             RetiredDate = s.RetiredDate.ToLocalDateTime(),
                             RetiredYear = s.RetiredYear.GetValueOrDefault().ToLocalYear(),
                             Salary = s.Salary,
                             Section = s.Section,
                             StartDate = s.StartDate.ToLocalDateTime(),
                             StartEducationDate = s.StartEducationDate.ToLocalDateTime(),
                             TitleEducation = s.TitleEducation,
                             University = s.University,
                             ZipCode = s.ZipCode,
                             Address = string.Format("{0} ซอย {1} หมู่ {2} ต.{4} อ.{4} จ.{5}", s.HomeNumber, s.Soi, s.Moo, s.SubDistrict, s.District, s.Province)

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

        public object GetAllPersonnelGroupPositionLevel(int type, List<int> filter)
        {
            var isSubGraphDataSet = false;
            var personnel = _dcPersonRepository.GetAll().Where(m => m.PositionTypeId == "ค" && m.PositionType == "ประเภทสนับสนุน");
            if (filter.Any())
            {
                personnel = personnel.Where(x => filter.Contains(x.FacultyId.GetValueOrDefault()));
                isSubGraphDataSet = true;
            }
            personnel = personnel.OrderBy(o => o.PersonnelTypeId);
            if (type == 1)
            {
                var index = 0;
                //if (isSubGraphDataSet)
                //{
                //    var label = new List<string>();
                //    var data = new List<int>();
                //    var groupByPosition = personnel.GroupBy(x => x.Position)
                //        .ToList();
                //    var graphDatasetList = new List<GraphDataSet>();
                //    foreach (var item in groupByPosition)
                //    {
                //        data.Add(item.Count());

                //        var graphDataset = new GraphDataSet
                //        {
                //            Label = item.Key,
                //            Data = data,
                //            BackgroundColor = index.BackgroundColor(),
                //            BorderColor = index.BorderColor()
                //        };
                //        graphDatasetList.Add(graphDataset);
                //        index++;
                //    }

                //    var subGraphData = new GraphData
                //    {
                //       Label = graphDatasetList.GroupBy(x => x.Label).Select(x => x.Key).ToList(),
                //       GraphDataSet = graphDatasetList,
                //       IsSubGraphDataSet = isSubGraphDataSet
                //    };

                //    return subGraphData;
                //}
                //else
                //{


                //}


                var label = new List<string>();
                var distinctPositionLevel = personnel.Select(s => new { s.PositionLevelId, s.PositionLevel }).Distinct();
                var graphDatasetList = new List<GraphDataSet>();
                var distinctPersonnelTypeByPositionLevel = personnel.Select(s => new { s.PersonnelType, s.PersonnelTypeId }).Distinct();

                foreach (var pp in distinctPersonnelTypeByPositionLevel)
                {
                    label.Add(pp.PersonnelType);
                }
                foreach (var pl in distinctPositionLevel)
                {
                    var data = new List<int>();
                    var personnelTypeByPositionLevel = personnel.Where(m => m.PositionLevelId == pl.PositionLevelId && m.PositionLevel == pl.PositionLevel).OrderBy(o => o.PersonnelTypeId);
                    var ad = personnelTypeByPositionLevel.Count();
                    foreach (var pp in distinctPersonnelTypeByPositionLevel)
                    {
                        data.Add(personnelTypeByPositionLevel.Where(m => m.PersonnelTypeId == pp.PersonnelTypeId && m.PersonnelType == pp.PersonnelType).Count());
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
                    Label = label,
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

                    var positionLevelByPersonnelType = personnel.Where(m => m.PersonnelTypeId == pt.PersonnelTypeId && m.PersonnelType == pt.PersonnelType).OrderBy(o => o.PersonnelTypeId);
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

        public List<PersonGroupPositionLevelDataSourceModel> GetAllPersonnelGroupPositionLevelDataSource(string personnelType, string positionLevel, List<int> filter)
        {
            var personnel = _dcPersonRepository.GetAll().Where(m => m.PositionTypeId == "ค" && m.PositionType == "ประเภทสนับสนุน")
                .Where(m => !string.IsNullOrEmpty(personnelType) ? m.PersonnelType == personnelType : true);
            if (filter.Any())
            {
                personnel = personnel.Where(x => filter.Contains(x.FacultyId.GetValueOrDefault()));
            }
            personnel = personnel.OrderBy(o => o.PersonnelTypeId);
            var distinctPersonnelType = personnel.Select(s => new { s.PersonnelType, s.PersonnelTypeId }).Distinct();
            var datatableList = new List<PersonGroupPositionLevelDataSourceModel>();
            foreach (var pt in distinctPersonnelType)
            {

                var positionLevelByPersonnelType = personnel.Where(m => m.PersonnelTypeId == pt.PersonnelTypeId && m.PersonnelType == pt.PersonnelType);
                var distinctPositionLevelByPersonnelType = positionLevelByPersonnelType.Where(m => !string.IsNullOrEmpty(positionLevel) ? m.PositionLevel == positionLevel : true).Select(s => new { s.PositionLevelId, s.PositionLevel }).Distinct();
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
                             DateOfBirth = s.DateOfBirth.ToLocalDateTime(),
                             Division = s.Division,
                             Education = s.Education,
                             EducationLevel = s.EducationLevel,
                             Faculty = s.Faculty,
                             Gender = s.Gender,
                             GraduateDate = s.GraduateDate.ToLocalDateTime(),
                             CitizenId = s.CitizenId,
                             Major = s.Major,
                             Nation = s.Nation,
                             PersonName = string.Format("{0} {1} {2}", s.TitleName, s.FirstName, s.LastName),
                             PersonnelId = s.PersonnelId,
                             PersonnelType = s.PersonnelType,
                             Position = s.Position,
                             PositionLevel = s.PositionLevel,
                             PositionType = s.PositionType,
                             Province = s.Province,
                             RetiredDate = s.RetiredDate.ToLocalDateTime(),
                             RetiredYear = s.RetiredYear.GetValueOrDefault().ToLocalYear(),
                             Salary = s.Salary,
                             Section = s.Section,
                             StartDate = s.StartDate.ToLocalDateTime(),
                             StartEducationDate = s.StartEducationDate.ToLocalDateTime(),
                             TitleEducation = s.TitleEducation,
                             University = s.University,
                             ZipCode = s.ZipCode,
                             Address = string.Format("{0} ซอย {1} หมู่ {2} ต.{4} อ.{4} จ.{5}", s.HomeNumber, s.Soi, s.Moo, s.SubDistrict, s.District, s.Province)

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

        public object GetAllPersonnelPositionEducation(int type, List<int> filter)
        {
            var personnel = _dcPersonRepository.GetAll();
            if (filter.Any())
            {
                personnel = personnel.Where(x => filter.Contains(x.FacultyId.GetValueOrDefault()));
            }
            personnel = personnel.OrderBy(o => o.PositionTypeId);
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

        public List<PersonPostionEducationDataSourceModel> GetAllPersonnelPositionEducationDataSource(List<int> filter)
        {
            var personnel = _dcPersonRepository.GetAll();
            if (filter.Any())
            {
                personnel = personnel.Where(x => filter.Contains(x.FacultyId.GetValueOrDefault()));
            }
            personnel = personnel.OrderBy(o => o.PositionTypeId);
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
                              DateOfBirth = s.DateOfBirth.ToLocalDateTime(),
                              Division = s.Division,
                              Education = s.Education,
                              EducationLevel = s.EducationLevel,
                              Faculty = s.Faculty,
                              Gender = s.Gender,
                              GraduateDate = s.GraduateDate.ToLocalDateTime(),
                              CitizenId = s.CitizenId,
                              Major = s.Major,
                              Nation = s.Nation,
                              PersonName = string.Format("{0} {1} {2}", s.TitleName, s.FirstName, s.LastName),
                              PersonnelId = s.PersonnelId,
                              PersonnelType = s.PersonnelType,
                              Position = s.Position,
                              PositionLevel = s.PositionLevel,
                              PositionType = s.PositionType,
                              Province = s.Province,
                              RetiredDate = s.RetiredDate.ToLocalDateTime(),
                              RetiredYear = s.RetiredYear.GetValueOrDefault().ToLocalYear(),
                              Salary = s.Salary,
                              Section = s.Section,
                              StartDate = s.StartDate.ToLocalDateTime(),
                              StartEducationDate = s.StartEducationDate.ToLocalDateTime(),
                              TitleEducation = s.TitleEducation,
                              University = s.University,
                              ZipCode = s.ZipCode,
                              Address = string.Format("{0} ซอย {1} หมู่ {2} ต.{4} อ.{4} จ.{5}", s.HomeNumber, s.Soi, s.Moo, s.SubDistrict, s.District, s.Province)

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

        public List<PersonnelGenderDataTableViewModel> GetAllPersonnelGender(int type, List<int> filter)
        {
            var personnel = _dcPersonRepository.GetAll();
            if (filter.Any())
            {
                personnel = personnel.Where(x => filter.Contains(x.FacultyId.GetValueOrDefault()));
            }
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

        public List<PersonnelGenderDataSourceViewModel> GetAllPersonnelGenderDataSource(List<int> filter)
        {
            var personnel = _dcPersonRepository.GetAll();
            if (filter.Any())
            {
                personnel = personnel.Where(x => filter.Contains(x.FacultyId.GetValueOrDefault()));
            }
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
                        DateOfBirth = s.DateOfBirth.ToLocalDateTime(),
                        Division = s.Division,
                        Education = s.Education,
                        EducationLevel = s.EducationLevel,
                        Faculty = s.Faculty,
                        Gender = s.Gender,
                        GraduateDate = s.GraduateDate.ToLocalDateTime(),
                        CitizenId = s.CitizenId,
                        Major = s.Major,
                        Nation = s.Nation,
                        PersonName = string.Format("{0} {1} {2}", s.TitleName, s.FirstName, s.LastName),
                        PersonnelId = s.PersonnelId,
                        PersonnelType = s.PersonnelType,
                        Position = s.Position,
                        PositionLevel = s.PositionLevel,
                        PositionType = s.PositionType,
                        Province = s.Province,
                        RetiredDate = s.RetiredDate.ToLocalDateTime(),
                        RetiredYear = s.RetiredYear.GetValueOrDefault().ToLocalYear(),
                        Salary = s.Salary,
                        Section = s.Section,
                        StartDate = s.StartDate.ToLocalDateTime(),
                        StartEducationDate = s.StartEducationDate.ToLocalDateTime(),
                        TitleEducation = s.TitleEducation,
                        University = s.University,
                        ZipCode = s.ZipCode,
                        Address = string.Format("{0} ซอย {1} หมู่ {2} ต.{4} อ.{4} จ.{5}", s.HomeNumber, s.Soi, s.Moo, s.SubDistrict, s.District, s.Province)
                    }).ToList();
                var genderGenerationGenX = personnel.Where(s => s.DateOfBirth >= DateTime.Parse("1967/01/01")
                    && s.DateOfBirth <= DateTime.Parse("1979/12/31") && s.GenderId == personGender.GenderId && s.Gender == personGender.Gender)
                    .Select(s => new PersonnelDataSourceViewModel
                    {
                        AdminPosition = s.AdminPosition,
                        AdminPositionType = s.AdminPositionType,
                        BloodType = s.BloodType,
                        Country = s.Country,
                        DateOfBirth = s.DateOfBirth.ToLocalDateTime(),
                        Division = s.Division,
                        Education = s.Education,
                        EducationLevel = s.EducationLevel,
                        Faculty = s.Faculty,
                        Gender = s.Gender,
                        GraduateDate = s.GraduateDate.ToLocalDateTime(),
                        CitizenId = s.CitizenId,
                        Major = s.Major,
                        Nation = s.Nation,
                        PersonName = string.Format("{0} {1} {2}", s.TitleName, s.FirstName, s.LastName),
                        PersonnelId = s.PersonnelId,
                        PersonnelType = s.PersonnelType,
                        Position = s.Position,
                        PositionLevel = s.PositionLevel,
                        PositionType = s.PositionType,
                        Province = s.Province,
                        RetiredDate = s.RetiredDate.ToLocalDateTime(),
                        RetiredYear = s.RetiredYear.GetValueOrDefault().ToLocalYear(),
                        Salary = s.Salary,
                        Section = s.Section,
                        StartDate = s.StartDate.ToLocalDateTime(),
                        StartEducationDate = s.StartEducationDate.ToLocalDateTime(),
                        TitleEducation = s.TitleEducation,
                        University = s.University,
                        ZipCode = s.ZipCode,
                        Address = string.Format("{0} ซอย {1} หมู่ {2} ต.{4} อ.{4} จ.{5}", s.HomeNumber, s.Soi, s.Moo, s.SubDistrict, s.District, s.Province)
                    }).ToList();
                var genderGenerationGenY = personnel.Where(s => s.DateOfBirth >= DateTime.Parse("1980/01/01")
                   && s.DateOfBirth <= DateTime.Parse("1997/12/31") && s.GenderId == personGender.GenderId && s.Gender == personGender.Gender)
                    .Select(s => new PersonnelDataSourceViewModel
                    {
                        AdminPosition = s.AdminPosition,
                        AdminPositionType = s.AdminPositionType,
                        BloodType = s.BloodType,
                        Country = s.Country,
                        DateOfBirth = s.DateOfBirth.ToLocalDateTime(),
                        Division = s.Division,
                        Education = s.Education,
                        EducationLevel = s.EducationLevel,
                        Faculty = s.Faculty,
                        Gender = s.Gender,
                        GraduateDate = s.GraduateDate.ToLocalDateTime(),
                        CitizenId = s.CitizenId,
                        Major = s.Major,
                        Nation = s.Nation,
                        PersonName = string.Format("{0} {1} {2}", s.TitleName, s.FirstName, s.LastName),
                        PersonnelId = s.PersonnelId,
                        PersonnelType = s.PersonnelType,
                        Position = s.Position,
                        PositionLevel = s.PositionLevel,
                        PositionType = s.PositionType,
                        Province = s.Province,
                        RetiredDate = s.RetiredDate.ToLocalDateTime(),
                        RetiredYear = s.RetiredYear.GetValueOrDefault().ToLocalYear(),
                        Salary = s.Salary,
                        Section = s.Section,
                        StartDate = s.StartDate.ToLocalDateTime(),
                        StartEducationDate = s.StartEducationDate.ToLocalDateTime(),
                        TitleEducation = s.TitleEducation,
                        University = s.University,
                        ZipCode = s.ZipCode,
                        Address = string.Format("{0} ซอย {1} หมู่ {2} ต.{4} อ.{4} จ.{5}", s.HomeNumber, s.Soi, s.Moo, s.SubDistrict, s.District, s.Province)
                    }).ToList();
                var genderGenerationGenZ = personnel.Where(s => s.DateOfBirth >= DateTime.Parse("1998/01/01") && s.GenderId == personGender.GenderId
                    && s.Gender == personGender.Gender)
                    .Select(s => new PersonnelDataSourceViewModel
                    {
                        AdminPosition = s.AdminPosition,
                        AdminPositionType = s.AdminPositionType,
                        BloodType = s.BloodType,
                        Country = s.Country,
                        DateOfBirth = s.DateOfBirth.ToLocalDateTime(),
                        Division = s.Division,
                        Education = s.Education,
                        EducationLevel = s.EducationLevel,
                        Faculty = s.Faculty,
                        Gender = s.Gender,
                        GraduateDate = s.GraduateDate.ToLocalDateTime(),
                        CitizenId = s.CitizenId,
                        Major = s.Major,
                        Nation = s.Nation,
                        PersonName = string.Format("{0} {1} {2}", s.TitleName, s.FirstName, s.LastName),
                        PersonnelId = s.PersonnelId,
                        PersonnelType = s.PersonnelType,
                        Position = s.Position,
                        PositionLevel = s.PositionLevel,
                        PositionType = s.PositionType,
                        Province = s.Province,
                        RetiredDate = s.RetiredDate.ToLocalDateTime(),
                        RetiredYear = s.RetiredYear.GetValueOrDefault().ToLocalYear(),
                        Salary = s.Salary,
                        Section = s.Section,
                        StartDate = s.StartDate.ToLocalDateTime(),
                        StartEducationDate = s.StartEducationDate.ToLocalDateTime(),
                        TitleEducation = s.TitleEducation,
                        University = s.University,
                        ZipCode = s.ZipCode,
                        Address = string.Format("{0} ซอย {1} หมู่ {2} ต.{4} อ.{4} จ.{5}", s.HomeNumber, s.Soi, s.Moo, s.SubDistrict, s.District, s.Province)
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
        public List<PersonnelGenderDataSourceViewModel> GetAllPersonnelGenderDataSourceByType(int type, int gender, string genderName, List<int> filter)
        {
            var personnel = _dcPersonRepository.GetAll().Where(s => s.GenderId == gender);
            if (filter.Any())
            {
                personnel = personnel.Where(x => filter.Contains(x.FacultyId.GetValueOrDefault()));
            }
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
                    personnel = personnel.Where(s => s.DateOfBirth >= DateTime.Parse("1980/01/01")
                    && s.DateOfBirth <= DateTime.Parse("1997/12/31"));
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
                    DateOfBirth = s.DateOfBirth.ToLocalDateTime(),
                    Division = s.Division,
                    Education = s.Education,
                    EducationLevel = s.EducationLevel,
                    Faculty = s.Faculty,
                    Gender = s.Gender,
                    GraduateDate = s.GraduateDate.ToLocalDateTime(),
                    CitizenId = s.CitizenId,
                    Major = s.Major,
                    Nation = s.Nation,
                    PersonName = string.Format("{0} {1} {2}", s.TitleName, s.FirstName, s.LastName),
                    PersonnelId = s.PersonnelId,
                    PersonnelType = s.PersonnelType,
                    Position = s.Position,
                    PositionLevel = s.PositionLevel,
                    PositionType = s.PositionType,
                    Province = s.Province,
                    RetiredDate = s.RetiredDate.ToLocalDateTime(),
                    RetiredYear = s.RetiredYear.GetValueOrDefault().ToLocalYear(),
                    Salary = s.Salary,
                    Section = s.Section,
                    StartDate = s.StartDate.ToLocalDateTime(),
                    StartEducationDate = s.StartEducationDate.ToLocalDateTime(),
                    TitleEducation = s.TitleEducation,
                    University = s.University,
                    ZipCode = s.ZipCode,
                    Address = string.Format("{0} ซอย {1} หมู่ {2} ต.{4} อ.{4} จ.{5}", s.HomeNumber, s.Soi, s.Moo, s.SubDistrict, s.District, s.Province)
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

        public PersonnelDataSourceViewModel GetPersonDetailByCitizenId(string citizenId)
        {
            var personDetail = _dcPersonRepository.GetAll().Where(m => m.CitizenId == citizenId)
                .Select(s => new PersonnelDataSourceViewModel
                {
                    AdminPosition = s.AdminPosition,
                    AdminPositionType = s.AdminPositionType,
                    BloodType = s.BloodType,
                    Country = s.Country,
                    DateOfBirth = s.DateOfBirth.ToLocalDateTime(),
                    Division = s.Division,
                    Education = s.Education,
                    EducationLevel = s.EducationLevel,
                    Faculty = s.Faculty,
                    Gender = s.Gender,
                    GraduateDate = s.GraduateDate.ToLocalDateTime(),
                    CitizenId = s.CitizenId,
                    Major = s.Major,
                    Nation = s.Nation,
                    PersonName = string.Format("{0} {1} {2}", s.TitleName, s.FirstName, s.LastName),
                    PersonnelId = s.PersonnelId,
                    PersonnelType = s.PersonnelType,
                    Position = s.Position,
                    PositionLevel = s.PositionLevel,
                    PositionType = s.PositionType,
                    Province = s.Province,
                    RetiredDate = s.RetiredDate.ToLocalDateTime(),
                    RetiredYear = s.RetiredYear.GetValueOrDefault().ToLocalYear(),
                    Salary = s.Salary,
                    Section = s.Section,
                    StartDate = s.StartDate.ToLocalDateTime(),
                    StartEducationDate = s.StartEducationDate.ToLocalDateTime(),
                    TitleEducation = s.TitleEducation,
                    University = s.University,
                    ZipCode = s.ZipCode,
                    Address = string.Format("{0} ซอย {1} หมู่ {2} ต.{4} อ.{4} จ.{5}", s.HomeNumber, s.Soi, s.Moo, s.SubDistrict, s.District, s.Province)
                }).FirstOrDefault();

            return personDetail;

        }

        public PersonnelDashboard GetPersonnelDashboard()
        {
            var personnel = _dcPersonRepository.GetAll();

            var model = new PersonnelDashboard
            {
                PersonnelCount = personnel.Count(),
                Personnel = "ข้อมูลบุคลากร"
            };

            return model;
        }
    }
}
