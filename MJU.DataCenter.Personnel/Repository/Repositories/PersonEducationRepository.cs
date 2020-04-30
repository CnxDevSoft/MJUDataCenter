using MJU.DataCenter.Personnel.IRepository.Common;
using MJU.DataCenter.Personnel.Models;
using MJU.DataCenter.Personnel.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.Personnel.Repository.Repositories
{
    public class PersonEducationRepository : Repository<PersonEducation>, IPersonEducationRepository
    {
        public PersonEducationRepository(PersonnelContext context)
            : base(context)
        {
        }
    }
}
