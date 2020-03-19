using MJU.DataCenter.ResearchExtension.Models;
using MJU.DataCenter.ResearchExtension.Repository.Common;
using MJU.DataCenter.ResearchExtension.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.ResearchExtension.Repository.Repositories
{
    public class ResearchPaperGroupRepository : Repository<ResearchPaperGroup>, IResearchPaperGroupRepository
    {
        public ResearchPaperGroupRepository(ResearchExtensionContext context)
          : base(context)
        {
        }
    }
}
