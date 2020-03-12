using System;
using System.Collections.Generic;
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
    }
}
