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
            DateTime start = new DateTime(1996, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(random.Next(range));
        }
        public static int RandomResearchMoney()
        {
            Random random = new Random();
            var randomTypeA = random.Next(100000,1000000);
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


    }
}
