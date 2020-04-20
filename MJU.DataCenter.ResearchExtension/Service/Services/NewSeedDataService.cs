using MJU.DataCenter.ResearchExtension.Models;
using MJU.DataCenter.ResearchExtension.Repository.Interface;
using MJU.DataCenter.ResearchExtension.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            Help50GenerateResearchMoneyType();
            Help20GenerateResearchMoneyType();
            HelpGenerateResearchPersonnel();
        }

        private void GenerateMoneyType()
        {
            var list = new List<MoneyType>();
            for (var i = 1; i <= 10; i++)
            {
                var m = SeedData.HelperSeedData.RandomMoneyTypeSeed(i);
                var model = new MoneyType
                {
                    MoneyTypeName = m.ToString()
                };
                list.Add(model);
            }
            _moneyTypeRepository.AddRange(list);
        }
        private void GenerateReacher()
        {
            var list = new List<Researcher>();
            for (var i = 0; i <= 300; i++)
            {
               
                var idcrd = "1234567890000";
                var aStringBuilder = new StringBuilder(idcrd);
                aStringBuilder.Remove(13 - i.ToString().Length, i.ToString().Length);
                aStringBuilder.Insert(13 - i.ToString().Length, i.ToString());
                var depart = SeedData.HelperSeedData.RandomDepart(i);
                var model = new Researcher
                {
                    CitizenId = aStringBuilder.ToString(),
                    TitleTh = SeedData.NewSeedData.RandomTitleName(),
                    FirstNameTh = string.Format("Firstname{0}", i),
                    LastNameTh = string.Format("Lastname{0}", i),
                    FacultyCode = depart.DepartmentCode,
                    FacultyId = depart.DepartId,
                    FacultyName = depart.DepartmentName
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
                    StartDateResearch = rd1 > rd2 ? rd2 : rd1,
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
            for (var i = 1; i <= 100; i++)
            {
                Random random = new Random();
                var moneyType = random.Next(1, 11);
                var c = i % 10;
                var rd = random.Next(1, 101);

                var model = new ResearchMoney
                {
                    ResearchId = i,
                    ResearchMoneyTypeId = c ==0?10:c
                };
                list.Add(model);
            }
            _researchMoneyRepository.AddRange(list);
        }

        private void Help50GenerateResearchMoneyType()
        {
            var list = new List<ResearchMoney>();
            for (var i = 1; i <= 50; i++)
            {
                Random random = new Random();
                var moneyType = random.Next(1, 11);
                var c = i % 10;
                var x = i % 50;
                var rd = random.Next(1, 101);
                
                var model = new ResearchMoney
                {
                    ResearchId = i,
                    ResearchMoneyTypeId = c+1
                };
                list.Add(model);
            }
            _researchMoneyRepository.AddRange(list);
        }

        private void Help20GenerateResearchMoneyType()
        {
            var list = new List<ResearchMoney>();
            for (var i = 1; i <= 20; i++)
            {
                Random random = new Random();
                var moneyType = random.Next(1, 11);
                var c = i % 10;
                var rd = random.Next(1, 4);

                var model = new ResearchMoney
                {
                    ResearchId = i,
                    ResearchMoneyTypeId = c = c + 2 == 11 ? 1 : c+2
                };
                list.Add(model);
            }
            _researchMoneyRepository.AddRange(list);
        }

        private void GenerateResearchGroup()
        {
            var list = new List<ResearcherGroup>();
            for (var i = 0; i <= 300; i++)
            {
                var g = i % 10;
                Random random = new Random();
                var group = random.Next(1, 21);
                var researcher = random.Next(1, 21);

                var model = new ResearcherGroup
                {
                    PersonGroupId = g+1,
                    ResearcherId = i
                };
                list.Add(model);
            }
            _researchGroupRepository.AddRange(list);
        }
        private void GenerateResearchPaper()
        {
            var list = new List<ResearchPaper>();
            for (var i = 0; i <= 300; i++)
            {
                var x = i % 100;
                Random random = new Random();
                var research = random.Next(1, 101);
                var researcher = random.Next(1, 101);
                var magazine = SeedData.HelperSeedData.RandomResearchId();

                var model = new ResearchPaper
                {
                    ResearcherId = i,
                    PaperNameTh = string.Format("บทวิจัย{0}", x+1),
                    PaperNameEn = string.Format("Paper{0}", x+1),
                    Weigth = SeedData.HelperSeedData.RandomWeigthPaper(),
                    PaperCreateDate = SeedData.HelperSeedData.RandomDateTimeResearch(),
                    MagazineId = x+1,
                    MagazineName = string.Format("MagazineName{0}", x+1),
                    MagzineVolum = SeedData.HelperSeedData.RandomResearchId(),
                    ResearchId  = x+1
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
            for (var i = 0; i <= 300; i++)
            {
                var x = i % 100;
                Random random = new Random();
                var researcher = random.Next(1, 21);
                var paper = random.Next(1, 51);

                var model = new ResearcherPaper
                {
                    ResearcherId = i,
                    PaperId = x+1,
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
            for (var i = 0; i <= 300; i++)
            {
                var x = i % 100;
                Random random = new Random();
                var researcher = random.Next(1, 21);
                var Research = random.Next(1, 101);

                var model = new ResearchPersonnel
                {
                    ResearcherId = i,
                    ResearchId = x = x==0?100:x,
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
        private void HelpGenerateResearchPersonnel()
        {
            var list = new List<ResearchPersonnel>();
            for (var i = 0; i <= 100; i++)
            {
                var x = i % 100;
                Random random = new Random();
                var researcher = random.Next(1, 21);
                var Research = random.Next(1, 101);

                var model = new ResearchPersonnel
                {
                    ResearcherId = i,
                    ResearchId = x +1,
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
