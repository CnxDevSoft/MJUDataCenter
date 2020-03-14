using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public object GetAllPersonnelGroup(int type)
        {
            
            var personnel = _dcPersonRepository.GetAll();

            var distinctPersonnelTypeId = personnel.Select(s=> s.PersonnelType
            ).Distinct();

           if (type == 1)
            {
                var label = new List<string>();
                var data = new List<int>();
                
                foreach (var personnelType in distinctPersonnelTypeId)
                {
                    label.Add(personnelType);
                    data.Add(personnel.Where(m => m.PersonnelType == personnelType).Count());
                }
                var graphDataSet = new GraphDataSet {
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
            else {
                var list = new List<PersonGroup>();
                foreach (var personnelType in distinctPersonnelTypeId)
                {
                    var personGroup = new PersonGroup
                    {
                        PersonGroupTypeName = personnelType,
                        Person = personnel.Where(m => m.PersonnelType == personnelType).Count()
                    };
                    list.Add(personGroup);
                }
                var result = new PersonGroupViewModel
                {
                    PersonGroup = list
                };
                return result;
            }

            
        }
        public object GetAllPersonnelPosition(int type)
        {
            var personnel = _dcPersonRepository.GetAll();

            var distinctPosition = personnel.Select(s => s.PositionType
            ).Distinct();

            if (type == 1)
            {
                var label = new List<string>();
                var data = new List<int>();

                foreach (var positionType in distinctPosition)
                {
                    label.Add(positionType);
                    data.Add(personnel.Where(m => m.PositionType == positionType).Count());
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
                var list = new List<PersonPostion>();
                foreach (var positionType in distinctPosition)
                {
                    var personPosition = new PersonPostion
                    {
                        PersonPosionTypeName = positionType,
                        Person = personnel.Where(m => m.PositionType == positionType).Count()
                    };
                    list.Add(personPosition);
                }
                var result = new PersonPostionViewModel
                {
                    PersonPostion = list
                };
                return result;
            }
        }

        public async Task<IEnumerable<Person>> GetAllPerson() {
            return await _personnelRepository.GetAllAsync();
        }
    }
}
