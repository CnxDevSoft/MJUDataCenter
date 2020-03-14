using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MJU.DataCenter.Personnel.Models;
using MJU.DataCenter.Personnel.ViewModels;

namespace MJU.DataCenter.Personnel.Service.Interface
{
    public interface IPersonnelService
    {
        Task<IEnumerable<Person>> GetPersonTest(int id);

        void AddPerson();

        List<PersonGroupViewModel> GetAllPersonnel();

        Task<IEnumerable<Person>> GetAllPerson();
    }
}
