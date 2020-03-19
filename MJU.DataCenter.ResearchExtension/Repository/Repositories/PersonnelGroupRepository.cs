using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MJU.DataCenter.ResearchExtension.Models;
using MJU.DataCenter.ResearchExtension.Repository.Common;
using MJU.DataCenter.ResearchExtension.Repository.Interface;

namespace MJU.DataCenter.ResearchExtension.Repository.Repositories
{
    public class PersonnelGroupRepository : Repository<PersonnelGroup>, IPersonnelGroupRepository
    {
        public PersonnelGroupRepository(ResearchExtensionContext context)
            : base(context)
        {
        }
    }
}
