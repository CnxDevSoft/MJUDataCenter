using MJU.DataCenter.Personnel.Models;
using MJU.DataCenter.Personnel.Repository.Interface;
using MJU.DataCenter.Personnel.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MJU.DataCenter.Personnel.Service.Services
{
    public class SeedDataPersonService : ISeedDataPersonService
    {
        private readonly IPersonnelRepository _personnelRepository;
        private readonly IDcPersonRepository _dcPersonRepository;
        private readonly IPersonEducationRepository _personEducationRepository;

        public SeedDataPersonService(IPersonnelRepository personnelRepository,
            IDcPersonRepository dcPersonRepository
            , IPersonEducationRepository personEducationRepository)
        {
            _personnelRepository = personnelRepository;
            _dcPersonRepository = dcPersonRepository;
            _personEducationRepository = personEducationRepository;
        }
        public void AddPerson()
        {
     
                var list = new List<Person>();

                for (var i = 0; i < 300; i++)
                {
                    var TitleName = SeedData.SeedData.RandomTitleName();
                    var Nationality = SeedData.SeedData.RandomNationality();
                    var Address = SeedData.SeedData.RandomAddress();
                    var Section = SeedData.SeedData.Section();
                    var Division = SeedData.SeedData.Division();
                    var Fact = SeedData.SeedData.Fact(i);
                    var AdminPosition = SeedData.SeedData.AdminPosition();
                    var Education = SeedData.SeedData.Education(i);
                    var PersonnelType = SeedData.SeedData.TypePersonCode();
                    var PositionType = SeedData.SeedData.PositionType();
                    var PositionLevel = SeedData.SeedData.PositionLevel();
                    var retired = SeedData.SeedData.RandomDateTimeRetired();
                    var idcrd = "1234567890000";
                    var randomAddress = SeedData.SeedData.RandomProvices();
                    var aStringBuilder = new StringBuilder(idcrd);
                    aStringBuilder.Remove(13 - i.ToString().Length, i.ToString().Length);
                    aStringBuilder.Insert(13 - i.ToString().Length, i.ToString());
                var result = new Person
                    {
                    //PersonnelId = 3,
                        CitizenId = aStringBuilder.ToString(),
                        TitleName = TitleName.TitleName,
                        FirstName = string.Format("Firstname{0}",i),
                        LastName = string.Format("LastName{0}", i),
                        TitleNameEn = TitleName.TitleNameEn,
                        FirstNameEn = string.Format("Firstname{0}", i),
                        LastNameEn = string.Format("LastName{0}", i),
                        DateOfBirth = SeedData.SeedData.RandomDateTimeDoB(),
                        BloodType = SeedData.SeedData.BloodType(),
                        GenderId = TitleName.GenderType,
                        Gender = TitleName.Gender.ToString(),
                        NationId = Nationality.NationalityId,
                        Nation = Nationality.Nationality,
                        HomeNumber = Address.HomeNumber,
                        Moo = Address.Moo,
                        Soi = Address.Soi,
                        Street = randomAddress.Street,
                        SubDistrict = randomAddress.SubDistrict,
                        District = randomAddress.District,
                        Province = randomAddress.Province,
                        ZipCode = 50200,
                        PositionCode = SeedData.SeedData.PositionCOde(),
                        PersonnelTypeId = PersonnelType.PersonTypeId,
                        PersonnelType = PersonnelType.PersonType,
                        PositionTypeId = PositionType.PositionTypeId,
                        PositionType = PositionType.PositionTypeName,
                        Position = SeedData.SeedData.Position(),
                        PositionLevelId = PositionLevel.PositionLevelId,
                        PositionLevel = PositionLevel.PositionLevelName,
                        StartDate = SeedData.SeedData.RandomDateWork(),
                        RetiredDate = retired,
                        RetiredYear = retired.GetValueOrDefault().Year,
                        SectionId = Section.SectionId,
                        Section = Section.SectionName,
                        DivisionId = Division.DivisionId,
                        Division = Division.DivisionName,
                        FacultyId = Fact.FactId,
                        Faculty = Fact.FactName,
                        Salary = int.Parse(SeedData.SeedData.Salary()),
                        AdminPositionId = AdminPosition.AdminPositionId,
                        AdminPositionType = AdminPosition.AdminPositionType,
                        AdminPosition = AdminPosition.AdminPositionName,
                        EducationLevel = Education.EducationLevel,
                        EducationLevelId = Education.EducationLevelId,
                        TitleEducation = Education.TitleEducation,
                        Education = Education.EducationName,
                        Major = Education.Major,
                        University = Education.University,
                        TitlePosition = Education.TitleEducation,
                        CountryId = Education.CountryId,
                        Country = Education.Country,
                        StartEducationDate = SeedData.SeedData.RandomDateTimeDoB(),
                        GraduateDate = SeedData.SeedData.RandomDateTimeDoB()
                    };
              
                    list.Add(result);

                }
                _personnelRepository.AddRange(list);
           
        }
        public void AddPersonEducation()
        {
            var list = new List<PersonEducation>();
           
            for (var i = 0; i < 300; i++)
            {
                var idcrd = "1234567890000";
                var aStringBuilder = new StringBuilder(idcrd);
                aStringBuilder.Remove(13 - i.ToString().Length, i.ToString().Length);
                aStringBuilder.Insert(13 - i.ToString().Length, i.ToString());
                var Education = SeedData.SeedData.Education(i+1);

                var result = new PersonEducation
                {
                    CitizenId = aStringBuilder.ToString(),
                    EducationLevel = Education.EducationLevel,
                    EducationLevelId = Education.EducationLevelId,
                    TitleEducation = Education.TitleEducation,
                    Education = Education.EducationName,
                    Major = Education.Major,
                    University = Education.University,
                    CountryId = Education.CountryId,
                    Country = Education.Country,
                    StartEducationDate = SeedData.SeedData.RandomDateTimeDoB(),
                    GraduateDate = SeedData.SeedData.RandomDateTimeDoB()

                };
                //_personEducationRepository.Add(result);
                list.Add(result);
            }

           _personEducationRepository.AddRange(list);
        }

    }
}
