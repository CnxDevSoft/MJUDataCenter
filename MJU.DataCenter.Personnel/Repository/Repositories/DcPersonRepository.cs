using System;
using Microsoft.EntityFrameworkCore;
using MJU.DataCenter.Personnel.IRepository.Common;
using MJU.DataCenter.Personnel.Models;
using MJU.DataCenter.Personnel.Repository.Interface;

namespace MJU.DataCenter.Personnel.Repository.Repositories
{
    public class DcPersonRepository : Repository<DC_Person>, IDcPersonRepository
    {
        public DcPersonRepository(PersonnelContext context)
            : base(context)
        {
        }

        
    }
}
