using MJU.DataCenter.Personnel.Models;
using MJU.DataCenter.Personnel.Repository.Interface;
using MJU.DataCenter.Personnel.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.Personnel.Service.Services
{
    public class SeedDataPersonService : ISeedDataPersonService
    {
        private readonly IPersonnelRepository _personnelRepository;
        private readonly IDcPersonRepository _dcPersonRepository;

        public SeedDataPersonService(IPersonnelRepository personnelRepository,
            IDcPersonRepository dcPersonRepository)
        {
            _personnelRepository = personnelRepository;
            _dcPersonRepository = dcPersonRepository;
        }
        public void AddPerson()
        {
     
                var list = new List<Person>();

                for (var i = 0; i < 100; i++)
                {
                    var TitleName = SeedData.SeedData.RandomTitleName();
                    var Nationality = SeedData.SeedData.RandomNationality();
                    var Address = SeedData.SeedData.RandomAddress();
                    var Section = SeedData.SeedData.Section();
                    var Division = SeedData.SeedData.Division();
                    var Fact = SeedData.SeedData.Fact();
                    var AdminPosition = SeedData.SeedData.AdminPosition();
                    var Education = SeedData.SeedData.Education();
                    var PersonnelType = SeedData.SeedData.TypePersonCode();
                    var PositionType = SeedData.SeedData.PositionType();
                    var PositionLevel = SeedData.SeedData.PositionLevel();
                    var result = new Person
                    {
                        //PersonnelId = 3,
                        IdCard = SeedData.SeedData.RandomIdCard(),
                        TitleName = TitleName.TitleName,
                        FirstName = SeedData.SeedData.RandomFirstName(),
                        LastName = SeedData.SeedData.RandomLastName(),
                        TitleNameEn = TitleName.TitleNameEn,
                        FirstNameEn = SeedData.SeedData.RandomFirstNameEn(),
                        LastNameEn = SeedData.SeedData.RandomLastNameEn(),
                        DateOfBirth = SeedData.SeedData.RandomDateTime(),
                        BloodType = SeedData.SeedData.BloodType(),
                        GenderId = TitleName.GenderType,
                        Gender = TitleName.Gender.ToString(),
                        NationId = Nationality.NationalityId,
                        Nation = Nationality.Nationality,
                        HomeNumber = Address.HomeNumber,
                        Moo = Address.Moo,
                        Soi = Address.Soi,
                        Street = Address.Street,
                        SubDistrict = Address.SubDistrict,
                        District = Address.District,
                        Province = Address.Province,
                        ZipCode = Address.ZipCode,
                        PositionCode = SeedData.SeedData.PositionCOde(),
                        PersonnelTypeId = PersonnelType.PersonTypeId,
                        PersonnelType = PersonnelType.PersonType,
                        PositionTypeId = PositionType.PositionTypeId,
                        PositionType = PositionType.PositionTypeName,
                        Position = SeedData.SeedData.Position(),
                        PositionLevelId = PositionLevel.PositionLevelId,
                        PositionLevel = PositionLevel.PositionLevelName,
                        StartDate = SeedData.SeedData.RandomDateTime(),
                        RetiredDate = SeedData.SeedData.RandomDateTime() < DateTime.UtcNow ? SeedData.SeedData.RandomDateTime() : null,
                        RetiredYear = SeedData.SeedData.RandomDateTime().GetValueOrDefault().Year,
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
                        StartEducationDate = SeedData.SeedData.RandomDateTime(),
                        GraduateDate = SeedData.SeedData.RandomDateTime()
                    };

                    list.Add(result);

                }
                _personnelRepository.AddRange(list);
           
        }

    }
}
