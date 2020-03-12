using MJU.DataCenter.Personnel.Models;
using MJU.DataCenter.Personnel.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MJU.DataCenter.Personnel.ZeedData
{
    public class ZeedData
    {
        private readonly IPersonnelService _personnelService;

        public ZeedData(IPersonnelService personnelService)
        {
            _personnelService = personnelService;
        }

        public static string RandomTitle()
        {
            StringBuilder str_build = new StringBuilder();
            Random random = new Random();
            int TitleType = random.Next(0, 3);
            string result = "";
            switch (TitleType)
            {
                case 0:
                    result = "นาย";
                    break;
                case 1:
                    result = "นาง";
                    break;
                case 2:
                    result = "นางสาว";
                    break;
                case 3:
                    result = "ว่าที่ รต.";
                    break;
            }
            return result;
        }
        public static string RandomString()
        {
            StringBuilder str_build = new StringBuilder();
            Random random = new Random();
            int length = 8;
            char letter;

            for (int i = 0; i < length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }
            string result = str_build.ToString();
            return result;
        }
        public static int RandomInt()
        {
            Random random = new Random();
            int result = 1;
            return result;
        }

        public static string RandomIdCard()
        {

            Random random = new Random();
            string firstNumber = random.Next(1, 9).ToString();
            string randomNumber = string.Join(string.Empty, Enumerable.Range(0, 12).Select(number => random.Next(0, 9).ToString()));
            var reusult = string.Format("{0},{1}", firstNumber, randomNumber);

            return reusult;

        }

        public static string RandomFirstName()
        {
            Random random = new Random();
            StringBuilder str_build = new StringBuilder();
            string alphabet = "กขฃคฅฆงจฉชซฌญฎฏฐฑฒณดตถทธนบปผฝพฟภมยรลวศษสหฬอฮ";
            int size = random.Next(5, 15);
            var resualt = Enumerable.Range(0, size).Select(x => alphabet[random.Next(0, alphabet.Length)]);
            return new string(resualt.ToArray());
        }
    }
}
