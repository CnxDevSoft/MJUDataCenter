using MJU.DataCenter.ResearchExtension.Models;
using MJU.DataCenter.ResearchExtension.Repository.Interface;
using MJU.DataCenter.ResearchExtension.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.ResearchExtension.Service.Services
{
    public class ProjectSeedDataService : IProjectSeedDataService
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectSeedDataService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public void AddProJect()
        {
            Random random = new Random();
            var list = new List<Project>();
            for (int i = 0; i < 100; i++)
            {
                var ProjectCode = SeedData.SeedData.RandomProjectCode();
                var Mount = SeedData.SeedData.RandomMountCode();
                var fund = SeedData.SeedData.FundSeedData();
                var result = new Project
                {
                    ProjectCode = int.Parse(string.Format("{0}{1}", i, ProjectCode)),
                    ProjectName = string.Format("{0} {1}", SeedData.SeedData.RandomProjectName(), string.Format("{0}{1}", i, ProjectCode)),
                    ProjectLead = SeedData.SeedData.RandomProjectLead(),
                    MountCode = Mount.MountCode,
                    DepartmentCode = SeedData.SeedData.RandomDdpart(),
                    FundCode = fund.FundCode,
                    Budget = SeedData.SeedData.RandomBudget(),
                    ProjectType = SeedData.SeedData.TypeProject(),
                    PlanCode = SeedData.SeedData.PlanCode(),
                    ActivityCode = SeedData.SeedData.ActiveCode(),
                    StatusCode = SeedData.SeedData.StatusCode()
                };
                list.Add(result);
            }
            _projectRepository.AddRange(list);
        }
    }
}
