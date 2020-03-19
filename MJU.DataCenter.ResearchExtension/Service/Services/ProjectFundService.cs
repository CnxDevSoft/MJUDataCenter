using MJU.DataCenter.ResearchExtension.Repository.Interface;
using MJU.DataCenter.ResearchExtension.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.ResearchExtension.Service.Services
{
    public class ProjectFundService : IProjectFundService
    {
        private readonly IProjectFundRepository _projectFundRepository;
        public ProjectFundService(IProjectFundRepository projectFundRepository)
        {
            _projectFundRepository = projectFundRepository;
        }


    }
    
}
