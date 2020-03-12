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
<<<<<<< HEAD
        public Task<IEnumerable<Person>> GetAllPersonnel();

        public Task<IEnumerable<Person>> GetPersonTest(int id);

        public void AddPerson();
=======
        List<PersonGroupViewModel> GetAllPersonnel();
        Task<IEnumerable<DC_Person>> GetDcPerson();
>>>>>>> c5723f3... add view table and add method group graph
    }
}
