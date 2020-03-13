using System;
using Microsoft.EntityFrameworkCore;
using MJU.DataCenter.Personnel.IRepository.Common;
using MJU.DataCenter.Personnel.Models;
using MJU.DataCenter.Personnel.Repository.Interface;

namespace MJU.DataCenter.Personnel.Repository.Repositories
{
    public class PersonnelRepository : Repository<Person>, IPersonnelRepository
    {
        public PersonnelRepository(PersonnelContext context)
            : base(context)
        {
        }

        
    }
}
