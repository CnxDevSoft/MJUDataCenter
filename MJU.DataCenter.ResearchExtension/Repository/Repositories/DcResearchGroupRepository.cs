using System;
using MJU.DataCenter.ResearchExtension.Models;
using MJU.DataCenter.ResearchExtension.Repository.Common;
using MJU.DataCenter.ResearchExtension.Repository.Interface;

namespace MJU.DataCenter.ResearchExtension.Repository.Repositories
{

    public class DcResearchGroupRepository : Repository<DcResearchGroup>, IDcResearchGroupRepository
    {
        public DcResearchGroupRepository(ResearchExtensionContext context)
            : base(context)
        {
        }
    }
}
