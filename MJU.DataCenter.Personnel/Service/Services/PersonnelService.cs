using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MJU.DataCenter.Personnel.Models;
using MJU.DataCenter.Personnel.Repository.Interface;
using MJU.DataCenter.Personnel.Service.Interface;

namespace MJU.DataCenter.Personnel.Service.Services
{
    public class PersonnelService : IPersonnelService
    {
        private readonly IPersonnelRepository _personnelRepository;

        public PersonnelService(IPersonnelRepository personnelRepository)
        {
            _personnelRepository = personnelRepository;
        }

        public async Task<IEnumerable<Person>> GetAllPersonnel()
        {
            var result = _personnelRepository.GetAllAsync();
            return await result;
        }

        public async Task<IEnumerable<Person>> GetPersonTest(int id)
        {
            
            var result = _personnelRepository.GetAllAsync();
            return await result;

        }

        public void AddPerson()
        {
            var TitleName = SeedData.SeedData.RandomTitleName();
            var Nationality = SeedData.SeedData.RandomNationality();
            var Address = SeedData.SeedData.RandomAddress();
            var Section = SeedData.SeedData.Section();
            int Loop = 1;
            var result = new Person
            {
                PersonnelId = 1 + Loop,
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
                PersonnelTypeId = SeedData.SeedData.TypePerson(),
                PersonnelType = SeedData.SeedData.TypePerson(),
                PositionRankId = SeedData.SeedData.PositionRankId(),
                PositionRank = SeedData.SeedData.PositionRank(),
                Position = SeedData.SeedData.Position(),
                PositionLevelId = SeedData.SeedData.PositionLevelId(),
                PositionLevel = SeedData.SeedData.PositionLevel(),
                StartDate = SeedData.SeedData.RandomDateTime(),
                RetiredDate = SeedData.SeedData.RandomDateTime(),
                RetiredYear = SeedData.SeedData.RandomDateTime().Year,
                SectionId = Section.SectionId,
                Section = Section.SectionName,


            };
            var test = result;
           // _personnelRepository.AddAsync(result);
        }
       
    }
}
