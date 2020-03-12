using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MJU.DataCenter.Personnel.Models;

namespace MJU.DataCenter.Personnel.Service.Interface
{
    public interface IPersonnelService
    {
        public Task<IEnumerable<Person>> GetAllPersonnel();

        public Task<IEnumerable<Person>> GetPersonTest(int id);
    }
}
