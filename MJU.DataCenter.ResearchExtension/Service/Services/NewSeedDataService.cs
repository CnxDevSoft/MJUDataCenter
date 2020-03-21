using MJU.DataCenter.ResearchExtension.Models;
using MJU.DataCenter.ResearchExtension.Repository.Interface;
using MJU.DataCenter.ResearchExtension.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.ResearchExtension.Service.Services
{
    public class NewSeedDataService : INewSeedDataService
    {
        private readonly IPersonnelGroupRepository _personnelGroupRepository;
        private readonly IResearchDataRepository _researchDataRepository;
        private readonly IResearcherPaperRepository _researcherPaperRepository;
        private readonly IResearcherRepository _researcherRepository;
        private readonly IResearchGroupRepository _researchGroupRepository;
        private readonly IResearchPaperRepository _researchPaperRepository;
        private readonly IResearchPersonnelRepository _researchPersonnelRepository;
        private readonly IResearchMoneyRepository _researchMoneyRepository;
        private readonly IMoneyTypeRepository _moneyTypeRepository;
        public NewSeedDataService(
            IPersonnelGroupRepository personnelGroupRepository,
            IResearchDataRepository researchDataRepository,
            IResearcherPaperRepository researcherPaperRepository,
            IResearcherRepository researcherRepository,
            IResearchGroupRepository researchGroupRepository,
            IResearchPaperRepository researchPaperRepository,
            IResearchPersonnelRepository researchPersonnelRepository,
            IResearchMoneyRepository researchMoneyRepository,
            IMoneyTypeRepository moneyTypeRepository
            )
        {
            _personnelGroupRepository = personnelGroupRepository;
            _researchDataRepository = researchDataRepository;
            _researcherPaperRepository = researcherPaperRepository;
            _researcherRepository = researcherRepository;
            _researchGroupRepository = researchGroupRepository;
            _researchPaperRepository = researchPaperRepository;
            _researchPersonnelRepository = researchPersonnelRepository;
            _researchMoneyRepository = researchMoneyRepository;
            _moneyTypeRepository = moneyTypeRepository;

        }

        public void GenerateSeed()
        {
            GenerateMoneyType();
            GenerateReacher();
            GeneratePersonnelGroup();
            GenerateResearchData();
            GenerateResearchMoneyType();
            GenerateResearchGroup();
            GenerateResearchPaper();
            GenerateResearcherPaper();
            GenerateResearchPersonnel();
        }

        private void GenerateMoneyType()
        {
            var list = new List<MoneyType>();
            for (var i = 1; i <= 10; i++)
            {
                var model = new MoneyType
                {
                    MoneyTypeName = string.Format("MoneyType {0}", i)
                };
                list.Add(model);
            }
            _moneyTypeRepository.AddRange(list);
        }
        private void GenerateReacher()
        {
            var list = new List<Researcher>();
            for (var i = 1; i <= 20; i++)
            {
                var depart = SeedData.HelperSeedData.RandomDepart();
                var model = new Researcher
                {
                    CitizenId = SeedData.HelperSeedData.RandomCitizenId(),
                    TitleTh = SeedData.NewSeedData.RandomTitleName(),
                    FirstNameTh = string.Format("Firstname{0}", i),
                    LastNameTh = string.Format("Lastname{0}", i),
                    DepartmentCode = depart.DepartmentCode,
                    DepartmentId = depart.DepartId,
                    DepartmentNameTh = depart.DepartmentName
                };
                list.Add(model);
            }
            _researcherRepository.AddRange(list);
        }
        private void GeneratePersonnelGroup()
        {
            var list = new List<PersonnelGroup>();
            for (var i = 1; i <= 10; i++)
            {
                var model = new PersonnelGroup
                {
                    PersonGroupName = string.Format("Group {0}", i)
                };
                list.Add(model);
            }
            _personnelGroupRepository.AddRange(list);
        }
        private void GenerateResearchData()
        {
            var list = new List<ResearchData>();
            for (var i = 1; i <= 100; i++)
            {

                var rd1 = SeedData.HelperSeedData.RandomDateTimeResearch();
                var rd2 = SeedData.HelperSeedData.RandomDateTimeResearch();
                var model = new ResearchData
                {
                    ResearchCode = i,
                    ResearchNameEn = string.Format("Research {0}", i),
                    ResearchNameTh = string.Format("งานวิจัย {0}", i),
                    StartDataResearch = rd1 > rd2 ? rd2 : rd1,
                    EndDateResearch = rd1 < rd2 ? rd2 : rd1,
                    ResearchMoney = SeedData.HelperSeedData.RandomResearchMoney()
                };
                list.Add(model);
            }
            _researchDataRepository.AddRange(list);
        }

        private void GenerateResearchMoneyType()
        {
            var list = new List<ResearchMoney>();
            for (var i = 1; i <= 200; i++)
            {
                Random random = new Random();
                var moneyType = random.Next(1, 11);

                var rd = random.Next(1, 101);

                var model = new ResearchMoney
                {
                    ResearchId = rd,
                    ResearchMoneyTypeId = moneyType
                };
                list.Add(model);
            }
            _researchMoneyRepository.AddRange(list);
        }

        private void GenerateResearchGroup()
        {
            var list = new List<ResearcherGroup>();
            for (var i = 1; i <= 50; i++)
            {
                Random random = new Random();
                var group = random.Next(1, 21);
                var researcher = random.Next(1, 21);

                var model = new ResearcherGroup
                {
                    PersonGroupId = group,
                    ResearcherId = researcher
                };
                list.Add(model);
            }
            _researchGroupRepository.AddRange(list);
        }
        private void GenerateResearchPaper()
        {
            var list = new List<ResearchPaper>();
            for (var i = 1; i <= 80; i++)
            {
                Random random = new Random();
                var research = random.Next(1, 101);
                var researcher = random.Next(1, 101);
                var magazine = SeedData.HelperSeedData.RandomResearchId();

                var model = new ResearchPaper
                {
                    ResearcherId = researcher,
                    PaperNameTh = string.Format("บทวิจัย{0}",i),
                    PaperNameEn = string.Format("Paper{0}", i),
                    Weigth = SeedData.HelperSeedData.RandomWeigthPaper(),
                    PaperCreateData = SeedData.HelperSeedData.RandomDateTimeResearch(),
                    MagazineId = magazine,
                    MagazineName = string.Format("MagazineName{0}", magazine),
                    MagzineVolum = SeedData.HelperSeedData.RandomResearchId(),
                    ResearchId  = research
                };
                if (!list.Where(m=>m.ResearchId==model.ResearchId&&m.ResearcherId==model.ResearcherId).Any())
                {
                    list.Add(model);
                }
                
            }
            _researchPaperRepository.AddRange(list);
        }

        private void GenerateResearcherPaper()
        {
            var list = new List<ResearcherPaper>();
            for (var i = 1; i <= 80; i++)
            {
                Random random = new Random();
                var researcher = random.Next(1, 21);
                var paper = random.Next(1, 51);

                var model = new ResearcherPaper
                {
                    ResearcherId = researcher,
                    PaperId = paper,
                    PaperPercent = SeedData.HelperSeedData.RandomPercent()
                };
                if (!list.Where(m => m.PaperId == model.PaperId && m.ResearcherId == model.ResearcherId).Any())
                {
                    list.Add(model);
                }

            }
            _researcherPaperRepository.AddRange(list);
        }

        private void GenerateResearchPersonnel()
        {
            var list = new List<ResearchPersonnel>();
            for (var i = 1; i <= 50; i++)
            {
                Random random = new Random();
                var researcher = random.Next(1, 21);
                var Research = random.Next(1, 101);

                var model = new ResearchPersonnel
                {
                    ResearcherId = researcher,
                    ResearchId = Research,
                    ResearchWorkPercent = SeedData.HelperSeedData.RandomPercent(),
                    ResearchMoney = SeedData.HelperSeedData.RandomResearchMoney()
                };
                if (!list.Where(m => m.ResearchId == model.ResearchId && m.ResearcherId == model.ResearcherId).Any())
                {
                    list.Add(model);
                }

            }
            _researchPersonnelRepository.AddRange(list);
        }




    }
}
