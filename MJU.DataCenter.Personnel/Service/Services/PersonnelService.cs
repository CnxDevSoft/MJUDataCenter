using System;
using System.Collections.Generic;
using System.Linq;
<<<<<<< HEAD
using System.Text;
=======
>>>>>>> c5723f3... add view table and add method group graph
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
<<<<<<< HEAD

        public async Task<IEnumerable<Person>> GetAllPersonnel()
=======
        public List<PersonGroupViewModel> GetAllPersonnel()
>>>>>>> c5723f3... add view table and add method group graph
        {
            var result = new List<PersonGroupViewModel>();
            var personnel = _personnelRepository.GetAll();

            var distinctPersonnelTypeId = personnel.Select(s => new PersonGroupViewModel{
                PersonGroupTypeId = Int32.Parse(s.PersonnelTypeId),
                PersonGroupTypeName =s.PersonnelType
            });


            foreach(var item in distinctPersonnelTypeId)
            {

                var personGroupView = new PersonGroupViewModel
                {
                    PersonGroupTypeId = item.PersonGroupTypeId,
                    PersonGroupTypeName = item.PersonGroupTypeName,
                    Person = personnel.Where(m => m.PersonnelTypeId == item.PersonGroupTypeId.ToString()).Count()
                };
                result.Add(personGroupView);
            }
            return result;
        }

<<<<<<< HEAD
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
       
=======
          
        

        public async Task<IEnumerable<DC_Person>> GetDcPerson() {
            return await _dcPersonRepository.GetAllAsync();
        }

>>>>>>> c5723f3... add view table and add method group graph
    }
}
