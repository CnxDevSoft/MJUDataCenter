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
        public static Abstract Abstrack()
        {
            var model = new Abstract();
            model.AbstractEN = "Nowadays, many games can play on various devices. Multi-platform development in game can help us waste of resources and increase number of market share. That is reason of multi-platform game development if it is interesting. Action RPG is classic game genre, that still popular through years. It is so interesting to use Action RPG for multi-platform game case study. Monster In Thailand has story about invaded monster who make an disorder in tourist attractions. The stages are referred by famous tourist attractions in Thailand. Characters has mixed Thai style with SD scale. Players have to role as hero to get rid of monster in tourist attractions. Players also can improve their character by battle with monster. In the future, if we got fund or any support. We will develop more features in this game such as real-time PVP and in-app purchase.";
            model.AbstractTH = "ปัจจุบันเกมที่ผลิตออกมานั้นสามารถใช้งานได้บนหลากหลายระบบปฏิบัติการณ์ เนื่องจากเป็นการประหยัดทรัพยากรแล้วยังถือเป็นการขยายกลุ่มตลาดให้กว้างยิ่งขึ้นด้วย ผู้พัฒนาจึงได้เล็งเห็นถึงการพัฒนาเกมแบบหลายระบบปฏิบัติการณ์หรือมัลติแพลตฟอร์ม โดยการออกแบบเกมเพียงครั้งเดียว ซึ่งตั้งแต่อดีตจนปัจจุบันประเภทเกมแอ็กชั่นอาร์พีจีถือเป็นประเภทเกมที่ได้รับความนิยมอยู่เสมอ จึงน่าหยิบยกมาใช้เป็นกรณีศึกษาสำหรับการพัฒนาเกมแบบมัลติแพลตฟอร์ม โดยเนื้อหาของเกมจะอ้างอิงจากสถานที่ท่องเที่ยวต่างๆ ของไทยรวมทั้งตัวละครแบบ SD (Super Deformed) ที่ผสมผสานความเป็นไทย ภายในเกมผู้เล่นจะได้รับบทบาทเป็นฮีโร่ผู้พิทักษ์ภัยจากเหล่าสัตว์ประหลาดลึกลับ ซึ่งออกมาสร้างความปั่นปุวนให้แก่สถานที่ท่องเที่ยวต่างๆ ผู้เล่นสามารถพัฒนาความสามารถและทักษะต่างๆ ได้ ผ่านการเก็บค่าประสบการณ์ ในอนาคตหากผู้พัฒนาได้รับการสนับสนุนต่อยอด ผู้พัฒนาได้มีแผนการพัฒนาส่วนของการต่อสู้ระหว่างผู้เล่นแบบออนไลน์เรียลไทม์ หรือเพิ่มระบบ In-app purchase เป็นต้น";
            return model;
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
