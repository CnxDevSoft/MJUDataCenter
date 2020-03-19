using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.ResearchExtension.SeedData
{
    public class NewSeedData
    {
        public static ReasearchDataModelSeed RandomResearchData()
        {
            var result = new ReasearchDataModelSeed();
            result.ResearchId =  HelperSeedData.RandomResearchId();
            result.ResearchCode = HelperSeedData.RandomResearchCode();
            result.ResearchNameTH = HelperSeedData.RandomResearchNameTH();
            result.ResearchNameEN = HelperSeedData.RandomResearchNameEN();
            result.StartDateResearch = HelperSeedData.RandomDateTimeResearch();
            result.EndDateResearch = HelperSeedData.RandomDateTimeResearch();
            result.ResearchMoney = HelperSeedData.RandomResearchMoney();
                return result;
        }

        public static MoneyTypeModelSeed RandomMoneyType()
        {
            var result = new MoneyTypeModelSeed();
            result.ResearchMoneyTypeId = HelperSeedData.RandomResearchMoneyTypeId();
            result.ResearchMoneyTypeName = HelperSeedData.RandomResearchMoneyTypeName();
            return result;

        }

        public static ReasearchMoneyTypeModelSeed RandomResearchMoneyType()
        {
            var result = new ReasearchMoneyTypeModelSeed();
            result.ResearchMoneyTypeId = HelperSeedData.RandomResearchMoneyTypeId();
            result.ResearchId = HelperSeedData.RandomResearchId();
            return result;

        }


    }
}
