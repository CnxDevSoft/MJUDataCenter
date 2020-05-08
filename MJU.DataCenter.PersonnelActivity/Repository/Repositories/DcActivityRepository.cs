using MJU.DataCenter.PersonnelActivity.Models;
using MJU.DataCenter.PersonnelActivity.Repository.Common;
using MJU.DataCenter.PersonnelActivity.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.PersonnelActivity.Repository.Repositories
{
    public class DcActivityRepository : Repository<DcActivity>, IDcActivityRepository
    {
        public DcActivityRepository(PersonnelActivityContext context)
           : base(context)
        {
        }
    }
}
