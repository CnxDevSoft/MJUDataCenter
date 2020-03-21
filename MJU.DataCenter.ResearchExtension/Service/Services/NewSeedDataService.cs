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
        private readonly IResearchPaperGroupRepository _researchPaperGroupRepository;
        private readonly IResearchPaperRepository _researchPaperRepository;
        private readonly IResearchPersonnelRepository _researchPersonnelRepository;
        private readonly IResearchMoneyRepository _researchMoneyRepository;
        private readonly IMoneyTypeRepository _moneyTypeRepository;
        public NewSeedDataService(
            IPersonnelGroupRepository personnelGroupRepository,
            IResearchDataRepository researchDataRepository,
            IResearcherPaperRepository researcherPaperRepository,
            IResearcherRepository researcherRepository,
            IResearchPaperGroupRepository researchPaperGroupRepository,
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
            _researchPaperGroupRepository = researchPaperGroupRepository;
            _researchPaperRepository = researchPaperRepository;
            _researchPersonnelRepository = researchPersonnelRepository;
            _researchMoneyRepository = researchMoneyRepository;
            _moneyTypeRepository = moneyTypeRepository;

        }
        public void ResearchDataAdd()
        {
            var list = new List<ResearchData>();
            var list1 = new List<MoneyType>();
            var list2 = new List<ResearchMoney>();
            var list3 = new List<ResearchPersonnel>();
            var list4 = new List<Researcher>();
            var list5 = new List<ResearchPaperGroup>();
            var list6 = new List<PersonnelGroup>();
            var list7 = new List<ResearcherPaper>();
            var list8 = new List<ResearchPaper>();
            for (int i = 0;i<10;i++)
            {
                //ResearchData--------------------------------------------------------------------------------
                var ResearchData = SeedData.NewSeedData.RandomResearchData();
                var researchPersonnel = SeedData.NewSeedData.RandomResearchResearchPersonnel();
                var researcher = SeedData.NewSeedData.RandomResearcher();
                var researchPaperGroup = SeedData.NewSeedData.RandomResearchPaperGroup();
                var personnelGroup = SeedData.NewSeedData.RandomPersonnelGroup();
                var researcherPaper = SeedData.NewSeedData.RandomResearcherPaper();
                var researchPaper = SeedData.NewSeedData.RandomResearchPaper();
                var result = new ResearchData
                {
                    ResearchId = int.Parse(string.Format("{0}{1}", i, ResearchData.ResearchId)),
                    ResearchCode = int.Parse(string.Format("{0}{1}", i, ResearchData.ResearchCode)),
                    ResearchNameTh = ResearchData.ResearchNameTH,
                    ResearchNameEn = ResearchData.ResearchNameEN,
                    StartDataResearch = ResearchData.StartDateResearch,
                    EndDateResearch = ResearchData.EndDateResearch,
                    ResearchMoney = ResearchData.ResearchMoney,
                };
                list.Add(result);
                //MoneyType--------------------------------------------------------------------------------
                var moneyData = SeedData.NewSeedData.RandomMoneyType();
                var result1 = new MoneyType
                {
                    ResearchMoneyTypeId = int.Parse(string.Format("{0}{1}", i, moneyData.ResearchMoneyTypeId)),
                    ResearchMoneyTypeName = moneyData.ResearchMoneyTypeName
                };
                list1.Add(result1);
                //ResearchMoneyType--------------------------------------------------------------------------------
                var researchMoneyType = SeedData.NewSeedData.RandomResearchMoneyType();
                var result2 = new ResearchMoney
                {
                     ResearchMoneyTypeId = int.Parse(string.Format("{0}{1}", i, moneyData.ResearchMoneyTypeId)),
                     ResearchId = int.Parse(string.Format("{0}{1}", i, ResearchData.ResearchId)),
                };
                list2.Add(result2);
                //ResearchPersonnel--------------------------------------------------------------------------------
                var result3 = new ResearchPersonnel
                {
                    PersonId = researchPersonnel.PersonId,
                    ResearchId = int.Parse(string.Format("{0}{1}", i, ResearchData.ResearchId)),
                    ResearchMoney = ResearchData.ResearchMoney,
                    ResearchWorkPercent = researchPersonnel.ResearchWorkPercent
                };
                list3.Add(result3);
                //Researcher--------------------------------------------------------------------------------
                var result4 = new Researcher()
                {
                    PersonId = researchPersonnel.PersonId,
                    CitizenId = researcher.CitizenId,
                    TitleTh = researcher.TitleTH,
                    FirstNameTh = researcher.FirstNameTH,
                    LastNameTh = researcher.LastNameTH,
                    DepartmentId = int.Parse(string.Format("{0}{1}", i, researcher.DepartmentId)),
                    DepartmentCode = int.Parse(string.Format("{0}{1}", i, researcher.DepartmentCode)),
                    DepartmentNameTh = researcher.DepartmentNameTH
                };
                list4.Add(result4);
                //ResearchPaperGroup-----------------------------------------------------------------------
                var result5 = new ResearchPaperGroup()
                {
                    PersonId = int.Parse(string.Format("{0}{1}", i, researchPersonnel.PersonId)),
                    PersonGroupId = int.Parse(string.Format("{0}{1}", i, researchPaperGroup.PersonGroupId)),
                    
                };
                list5.Add(result5);
                //PersonnelGroup-----------------------------------------------------------------------------------
                var result6 = new PersonnelGroup()
                {
                    PersonGroupId = int.Parse(string.Format("{0}{1}", i, researchPaperGroup.PersonGroupId)),
                    PersonGroupName = personnelGroup.PersonGroupName
                };          
                list6.Add(result6);
                //ResearcherPaper------------------------------------------------------------------------------------
                var result7 = new ResearcherPaper()
                {
                    PaperId = int.Parse(string.Format("{0}{1}", i, researcherPaper.PaperId)),
                    PaperPercent = researcherPaper.PaperPercent,
                    PersonId = int.Parse(string.Format("{0}{1}", i, researchPersonnel.PersonId))
                };
                list7.Add(result7);
                //ResearchPaper---------------------------------------------------------------------------------------
                var result8 = new ResearchPaper()
                {
                  PaperId  = int.Parse(string.Format("{0}{1}", i, researcherPaper.PaperId)),
                  PaperNameTh = researchPaper.PaperNameTH,
                  PaperNameEn = researchPaper.PaperNameEN,
                  Weigth = researchPaper.Weigth,
                  PaperCreateData = researchPaper.PaperCreateData,
                  MagazineId = int.Parse(string.Format("{0}{1}", i, researchPaper.MagazineId)),
                  MagazineName = researchPaper.MagazineName,
                  MagzineVolum = researchPaper.MagzineVolum
                };
                list8.Add(result8);
            }

            _researchDataRepository.AddRange(list);
            _moneyTypeRepository.AddRange(list1);
            _researchMoneyRepository.AddRange(list2);
            _researchPersonnelRepository.AddRange(list3);
            _researcherRepository.AddRange(list4);
            _researchPaperGroupRepository.AddRange(list5);
            _personnelGroupRepository.AddRange(list6);
            _researcherPaperRepository.AddRange(list7);
            _researchPaperRepository.AddRange(list8);

        }
        public void MoneyTypeAdd() 
        {
            var list = new List<MoneyType>();

            for (int i = 0; i < 10; i++)
            {
    
                var moneyData = SeedData.NewSeedData.RandomMoneyType();
                var result1 = new MoneyType
                {
                    ResearchMoneyTypeId = int.Parse(string.Format("{0}{1}", i, moneyData.ResearchMoneyTypeId)),
                    ResearchMoneyTypeName = moneyData.ResearchMoneyTypeName
                };
                list.Add(result1);

            }
            _moneyTypeRepository.AddRange(list);
        }

    }
}
