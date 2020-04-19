using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MJU.DataCenter.ResearchExtension.SeedData
{
    public class HelperSeedData
    {
        public static int RandomResearchId()
        {
            Random random = new Random();
            var randomTypeA = random.Next(100,999);
            return randomTypeA;
        }
        public static int RandomResearchCode()
        {
            Random random = new Random();
            var randomTypeA = random.Next(100, 999);
            return randomTypeA;
        }
        public static string RandomResearchNameTH()
        {
            Random random = new Random();
            StringBuilder str_build = new StringBuilder();
            string alphabet = "กขฃคฅฆงจฉชซฌญฎฏฐฑฒณดตถทธนบปผฝพฟภมยรลวศษสหฬอฮ";
            int size = random.Next(5, 15);
            var resualt = Enumerable.Range(0, size).Select(x => alphabet[random.Next(0, alphabet.Length)]);
            return new string(resualt.ToArray());
        }
        public static string RandomResearchNameEN()
        {
            Random random = new Random();
            StringBuilder str_build = new StringBuilder();
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            int size = random.Next(5, 15);
            var resualt = Enumerable.Range(0, size).Select(x => alphabet[random.Next(0, alphabet.Length)]);
            return new string(resualt.ToArray());
        }

        public static DateTime RandomDateTimeResearch() 
        {
            Random random = new Random();
            DateTime start = new DateTime(1997, 1, 1);
            var range = DateTime.Now - start;
            //int range = (DateTime.Now().Days - new DateTime(2540, 1, 1)).Days;
            return start.AddDays(random.Next(range.Days));
        }
        public static int RandomResearchMoney()
        {
            Random random = new Random();
            var randomTypeA = random.Next(50000,40000000);
            return randomTypeA;
        }
        //********************************************************************EndResearchData
        public static int RandomResearchMoneyTypeId()
        {
            Random random = new Random();
            var randomTypeA = random.Next(100, 999);
            return randomTypeA;
        }

        public static string RandomResearchMoneyTypeName()
        {
            Random random = new Random();
            StringBuilder str_build = new StringBuilder();
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            int size = random.Next(10, 20);
            var resualt = Enumerable.Range(0, size).Select(x => alphabet[random.Next(0, alphabet.Length)]);
            return new string(resualt.ToArray());
        }

        public static int RandomPercent()
        {
            Random random = new Random();
            var randomTypeA = random.Next(1, 101);
            return randomTypeA;
        }
        public static int RandomPersonnelId()
        {
            Random random = new Random();
            var randomTypeA = random.Next(100, 999);
            return randomTypeA;
        }
        public static string RandomCitizenId()
        {
            Random random = new Random();
            StringBuilder str_build = new StringBuilder();
            string alphabet = "123456789";
            int size = 13;
            var resualt = Enumerable.Range(0, size).Select(x => alphabet[random.Next(0, alphabet.Length)]);
            return new string(resualt.ToArray());
        }

        public static string RandomTitleNameTH()
        {
            Random random = new Random();
            StringBuilder str_build = new StringBuilder();
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            int size = random.Next(5, 10);
            var resualt = Enumerable.Range(0, size).Select(x => alphabet[random.Next(0, alphabet.Length)]);
            return new string(resualt.ToArray());
        }

        public static int RandomWeigthPaper()
        {            
            Random random = new Random();
            var randomTypeA = random.Next(1, 6);
            int result = 0;
            switch (randomTypeA)
            {
                case 1:
                    result = 20;
                    break;
                case 2:
                    result = 40;
                    break;
                case 3:
                    result = 60;
                    break;
                case 4:
                    result = 80;
                    break;
                case 5:
                    result = 100;
                    break;
            }
            return result;

        }
        public static Depart RandomDepart(int c)
        {
            var x = c % 11;
            Random random = new Random();
            var randomTypeA = random.Next(1, 6);
            var result = new Depart();
            switch (x)
            {
                case 1:
                    result.DepartId = 20001;
                    result.DepartmentCode = 10;
                    result.DepartmentName = "สำนักงานมหาวิทยาลัย";
                    break;
                case 2:
                    result.DepartId = 20002;
                    result.DepartmentCode = 20;
                    result.DepartmentName = "คณะวิทยาศาสตร์";
                    break;
                case 3:
                    result.DepartId = 20003;
                    result.DepartmentCode = 30;
                    result.DepartmentName = "คณะวิศวกรรมและอุตสาหกรรมเกษตร";
                    break;
                case 4:
                    result.DepartId = 20004;
                    result.DepartmentCode = 40;
                    result.DepartmentName = "คณะบริหารธุรกิจ";
                    break;
                case 5:
                    result.DepartId = 20005;
                    result.DepartmentCode = 50;
                    result.DepartmentName = "คณะผลิตกรรมการเกษตร";
                    break;
                case 6:
                    result.DepartId = 20006;
                    result.DepartmentCode = 60;
                    result.DepartmentName = "คณะเทคโนโลยีการประมงและทรัพยากรทางน้ำ";
                    break;
                case 7:
                    result.DepartId = 20007;
                    result.DepartmentCode = 70;
                    result.DepartmentName = "คณะพัฒนาการท่องเที่ยว";
                    break;
                case 8:
                    result.DepartId = 20008;
                    result.DepartmentCode = 80;
                    result.DepartmentName = "คณะศิลปศาสตร์";
                    break;
                case 9:
                    result.DepartId = 20009;
                    result.DepartmentCode = 90;
                    result.DepartmentName = "คณะเศรษฐศาสตร์";
                    break;
                case 10:
                    result.DepartId = 20010;
                    result.DepartmentCode = 100;
                    result.DepartmentName = "คณะสัตวศาสตร์และเทคโนโลยี";
                    break;
                case 0:
                    result.DepartId = 20011;
                    result.DepartmentCode = 110;
                    result.DepartmentName = "คณะสารสนเทศและการสื่อสาร";
                    break;
            }
            return result;

        }
        public static PersonnelGroup RandomGroupPerson()
        {
            Random random = new Random();
            var randomTypeA = random.Next(1, 6);
            var result = new PersonnelGroup();
            switch (randomTypeA)
            {
                case 1:
                    
                    result.PersonGroupId = 1;
                    result.PersonGroupName = "A";
                    break;
                case 2:
                    
                    result.PersonGroupId = 2;
                    result.PersonGroupName = "B";
                    break;
                case 3:
                  
                    result.PersonGroupId = 3;
                    result.PersonGroupName = "C";
                    break;
                case 4:
                    
                    result.PersonGroupId = 4;
                    result.PersonGroupName = "D";
                    break;
                case 5:
                   
                    result.PersonGroupId = 5;
                    result.PersonGroupName = "E";
                    break;
            }
            return result;

        }

        public static MoneyTypeModel RandomMoneyTypeSeed(int i)
        {
           
            var result = new MoneyTypeModel();
            switch (i)
            {
                case 1:
                    result.MoneyTypeName = "สถาบันส่งเสริมการสอนวิทยาศาสตร์และเทคโนโลยี (สสวท.)";
                    break;
                case 2:
                    result.MoneyTypeName = "สำนักวิจัยและส่งเสริมวิชาการการเกษตร มหาวิทยาลัยแม่โจ้";
                    break;
                case 3:
                    result.MoneyTypeName = "สำนักงานคณะกรรมการการอุดมศึกษา (สกอ.)";
                    break;
                case 4:
                    result.MoneyTypeName = "สำนักงานกองทุนสนับสนุนการวิจัย (สกว.)";
                    break;
                case 5:
                    result.MoneyTypeName = "กระทรวงศึกษาธิการ";
                    break;
                case 6:
                    result.MoneyTypeName = "การท่องเที่ยวแห่งประเทศไทย";
                    break;
                case 7:
                    result.MoneyTypeName = "งบประมาณเงินรายได้คณะศิลปศาสตร์";
                    break;
                case 8:
                    result.MoneyTypeName = "สำนักงานคณะกรรมการป้องกันและปราบปรามการทุจริตแห่งชาติ";
                    break;
                case 9:
                    result.MoneyTypeName = "สถาบันสร้างสรรค์สื่อเพื่อการเรียนรู้ (สสร.)";
                    break;
                case 10:
                    result.MoneyTypeName = "UNESCO ร่วมกับ Third World Academy";
                    break;



            }

            return result;
        }


    }
}
