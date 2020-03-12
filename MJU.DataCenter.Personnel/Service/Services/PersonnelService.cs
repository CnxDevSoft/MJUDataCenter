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
            Random random = new Random();
            int Loop = 1;
            var result = new Person
            {
                PersonnelId = 1 + Loop,
                IdCard = ZeedData.ZeedData.RandomIdCard(),
                TitleName = ZeedData.ZeedData.RandomTitle(),



            };
            _personnelRepository.AddAsync(result);
        }
       
    }
}
