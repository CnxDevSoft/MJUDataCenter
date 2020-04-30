using MJU.DataCenter.Personnel.IRepository.Common;
using MJU.DataCenter.Personnel.Models;
using MJU.DataCenter.Personnel.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.Personnel.Repository.Repositories
{
    public class DcPersonEducationRepository : Repository<DcPersonEducation>, IDcPersonEducationRepository
    {
        public DcPersonEducationRepository(PersonnelContext context)
           : base(context)
        {
        }
    }
}
