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
            for (int i = 0;i<10;i++)
            {
                //ResearchData
                var ResearchData = SeedData.NewSeedData.RandomResearchData();
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
                //MoneyType
                var moneyData = SeedData.NewSeedData.RandomMoneyType();
                var result1 = new MoneyType
                {
                    ResearchMoneyTypeId = int.Parse(string.Format("{0}{1}", i, moneyData.ResearchMoneyTypeId)),
                    ResearchMoneyTypeName = moneyData.ResearchMoneyTypeName
                };
                list1.Add(result1);
                //ResearchMoneyType
                var researchMoneyType = SeedData.NewSeedData.RandomResearchMoneyType();
                var result2 = new ResearchMoney
                {
                     ResearchMoneyTypeId = int.Parse(string.Format("{0}{1}", i, moneyData.ResearchMoneyTypeId)),
                     ResearchId = int.Parse(string.Format("{0}{1}", i, ResearchData.ResearchId)),
                };
                list2.Add(result2);
            }

            _researchDataRepository.AddRange(list);
            _moneyTypeRepository.AddRange(list1);
            _researchMoneyRepository.AddRange(list2);

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
