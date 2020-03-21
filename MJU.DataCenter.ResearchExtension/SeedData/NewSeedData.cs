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

        public static ResearchPersonnelMOdelSeed RandomResearchResearchPersonnel()
        {
            var result = new ResearchPersonnelMOdelSeed();
            result.PersonId = HelperSeedData.RandomPersonnelId();
            result.ResearchId = HelperSeedData.RandomResearchId();
            result.ResearchMoney = HelperSeedData.RandomResearchMoney();
            result.ResearchWorkPercent = HelperSeedData.RandomPercent();
            return result;

        }

        public static ResearcherModelSeed RandomResearcher()
        {
            var result = new ResearcherModelSeed();
            result.PersonId = HelperSeedData.RandomPersonnelId();
            result.CitizenId = HelperSeedData.RandomCitizenId();
            result.TitleTH = HelperSeedData.RandomTitleNameTH();
            result.FirstNameTH = HelperSeedData.RandomResearchNameTH();
            result.LastNameTH = HelperSeedData.RandomResearchNameTH();
            result.DepartmentId = HelperSeedData.RandomResearchId();
            result.DepartmentCode = HelperSeedData.RandomResearchId();
            result.DepartmentNameTH = HelperSeedData.RandomResearchNameTH();
            return result;
        }
        public static ResearchPaperGroupModelSeed RandomResearchPaperGroup()
        {
            var result = new ResearchPaperGroupModelSeed();
            result.PersonId = HelperSeedData.RandomPersonnelId();
            result.PersonGroupId = HelperSeedData.RandomPersonnelId();
            return result;
        }
        public static PersonnelGroupModelSeed RandomPersonnelGroup()
        {
            var result = new PersonnelGroupModelSeed();       
            result.PersonGroupId = HelperSeedData.RandomPersonnelId();
            result.PersonGroupName = HelperSeedData.RandomResearchNameTH();
            return result;
        }

        public static ResearcherPaperModelSeed RandomResearcherPaper()
        {
            var result = new ResearcherPaperModelSeed();
            result.PersonId = HelperSeedData.RandomPersonnelId();
            result.PaperId = HelperSeedData.RandomPersonnelId();
            result.PaperPercent = HelperSeedData.RandomPercent();
            return result;
        }
        public static ResearchPaperModelSeed RandomResearchPaper()
        {
            var result = new ResearchPaperModelSeed();
            result.PaperId = HelperSeedData.RandomPersonnelId();
            result.PaperNameTH = HelperSeedData.RandomResearchNameTH();
            result.PaperNameEN = HelperSeedData.RandomResearchNameEN();
            result.Weigth = HelperSeedData.RandomWeigthPaper();
            result.PaperCreateData = HelperSeedData.RandomDateTimeResearch();
            result.MagazineId = HelperSeedData.RandomPersonnelId();
            result.MagazineName = HelperSeedData.RandomResearchNameTH();
            result.MagzineVolum = HelperSeedData.RandomPersonnelId();

            return result;

        }


        public static string RandomTitleName()
        {
            Random random = new Random();
            int TitleType = random.Next(0, 3);
            var TitleName =string.Empty;
            switch (TitleType)
            {
                case 0:
                    TitleName = "นาย";
                    break;
                case 1:
                    TitleName = "นาง";
                    break;
                case 2:
                    TitleName = "นส.";
                    break;


            }
            return TitleName;

        }
    }
}
