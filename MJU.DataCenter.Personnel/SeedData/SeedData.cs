using MJU.DataCenter.Personnel.Models;
using MJU.DataCenter.Personnel.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MJU.DataCenter.Personnel.SeedData
{
    public class SeedData
    {
        private readonly IPersonnelService _personnelService;

        public SeedData(IPersonnelService personnelService)
        {
            _personnelService = personnelService;
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
            var reusult = string.Format("{0}{1}", firstNumber, randomNumber);

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
        public static string RandomLastName()
        {
            Random random = new Random();
            StringBuilder str_build = new StringBuilder();
            string alphabet = "กขฃคฅฆงจฉชซฌญฎฏฐฑฒณดตถทธนบปผฝพฟภมยรลวศษสหฬอฮ";
            int size = random.Next(5, 15);
            var resualt = Enumerable.Range(0, size).Select(x => alphabet[random.Next(0, alphabet.Length)]);
            return new string(resualt.ToArray());
        }

        public static PersonData RandomTitleName()
        {
            var model = new PersonData();
            Random random = new Random();
            int TitleType = random.Next(0, 6);

            switch (TitleType)
            {
                case 0:
                    model.TitleNameEn = "Mr";
                    model.TitleName = "นาย";
                    model.GenderType = 1;
                    model.Gender = "ชาย";
                    break;
                case 1:
                    model.TitleNameEn = "Miss";
                    model.TitleName = "นางสาว";
                    model.GenderType = 2;
                    model.Gender = "หญิง";
                    break;
                case 2:
                    model.TitleNameEn = "Mrs";
                    model.TitleName = "นาง";
                    model.GenderType = 2;
                    model.Gender = "หญิง";
                    break;
                case 3:
                    model.TitleNameEn = "Miss";
                    model.TitleName = "ว่าที่ รต.หญิง";
                    model.GenderType = 2;
                    model.Gender = "หญิง";
                    break;
                case 4:
                    model.TitleNameEn = "Mrs";
                    model.TitleName = "ว่าที่ รต.หญิง";
                    model.GenderType = 2;
                    model.Gender = "หญิง";
                    break;
                case 5:
                    model.TitleNameEn = "Mr";
                    model.TitleName = "ว่าที่ รต.";
                    model.GenderType = 1;
                    model.Gender = "ชาย";
                    break;
            }
            return model;

        }

        public static string RandomFirstNameEn()
        {
            Random random = new Random();
            StringBuilder str_build = new StringBuilder();
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            int size = random.Next(5, 15);
            var resualt = Enumerable.Range(0, size).Select(x => alphabet[random.Next(0, alphabet.Length)]);
            return new string(resualt.ToArray());
        }
        public static string RandomLastNameEn()
        {
            Random random = new Random();
            StringBuilder str_build = new StringBuilder();
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            int size = random.Next(5, 15);
            var resualt = Enumerable.Range(0, size).Select(x => alphabet[random.Next(0, alphabet.Length)]);
            return new string(resualt.ToArray());
        }
        public static DateTime RandomDateTime()
        {
            Random random = new Random();
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(random.Next(range));
        }

        public static string BloodType()
        {
            Random random = new Random();
            var randomType = random.Next(0, 4);
            string result = "";
            switch (randomType)
            {
                case 0:
                    result = "A";
                    break;
                case 1:
                    result = "B";
                    break;
                case 2:
                    result = "O";
                    break;
                case 3:
                    result = "AB";
                    break;
            }
            return result;
        }

        public static PersonNationality RandomNationality()
        {
            Random random = new Random();
            var model = new PersonNationality();
            var randomType = random.Next(1, 3);
            switch (randomType)
            {
                case 1:
                    model.NationalityId = "TH";
                    model.Nationality = "ไทย";
                    break;
                case 2:
                    model.NationalityId = "CN";
                    model.Nationality = "จีน";
                    break;
            }
            return model;
        }

        public static Address RandomAddress()
        {
            Random random = new Random();
            StringBuilder str_build = new StringBuilder();

            var result = new Address
            {
                HomeNumber = HelpHomeNumber().ToString(),
                Moo = int.Parse(HelpHomeMoo()),
                Soi = HelpSoi(),
                SubDistrict = HelpAddress(),
                District = HelpAddress(),
                Street = HelpAddress(),
                Province = HelpAddress(),
                ZipCode = int.Parse(HelpHomeMoo())
            };

            return result;
        }
        public static string HelpAddress()
        {
            Random random = new Random();
            StringBuilder str_build = new StringBuilder();
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            int size = random.Next(5, 15);
            var resualt = Enumerable.Range(0, size).Select(x => alphabet[random.Next(0, alphabet.Length)]);
            return new string(resualt.ToArray());
        }
        public static string HelpHomeNumber()
        {
            Random random = new Random();
            StringBuilder str_build = new StringBuilder();
            string alphabet = "0123456789";
            int size = random.Next(2, 4);
            var resualt = Enumerable.Range(0, size)
                .Select(x => alphabet[random.Next(0, alphabet.Length)]);
            return new string(resualt.ToArray());
        }
        public static string HelpHomeMoo()
        {
            Random random = new Random();
            StringBuilder str_build = new StringBuilder();
            string alphabet = "0123456789";
            int size = random.Next(1, 2);
            var resualt = Enumerable.Range(0, size)
                .Select(x => alphabet[random.Next(0, alphabet.Length)]);
            return new string(resualt.ToArray());
        }

        public static string HelpSoi()
        {
            Random random = new Random();
            StringBuilder str_build = new StringBuilder();
            string alphabet = "123456789";
            int size = random.Next(1, 2);
            var resualt = Enumerable.Range(0, size).Select(x => alphabet[random.Next(0, alphabet.Length)]);
            return new string(resualt.ToArray());
        }

        public static string PositionCOde()
        {
            Random random = new Random();
            StringBuilder str_build = new StringBuilder();
            string alphabet = "123456789";
            int size = random.Next(4, 5);
            var resualt = Enumerable.Range(0, size).Select(x => alphabet[random.Next(0, alphabet.Length)]);
            return new string(resualt.ToArray());

        }
        public static string TypePersonCode()
        {
            Random random = new Random();
            var randomType = random.Next(1, 6);
            string result = "";
            switch (randomType)
            {
                case 1:
                    result = "P";
                    break;
                case 2:
                    result = "E";
                    break;
                case 3:
                    result = "M";
                    break;
                case 4:
                    result = "EG";
                    break;
            }

            return result;
        }

        public static string TypePerson()
        {
            Random random = new Random();
            var randomType = random.Next(1, 3);
            string result = "";
            switch (randomType)
            {
                case 1:
                    result = "ข้าราชกาล";
                    break;
                case 2:
                    result = "ลูกจ้างประจำ";
                    break;
            }

            return result;
        }
        public static string PositionRankId()
        {
            Random random = new Random();
            var randomType = random.Next(1, 3);
            string result = "";
            switch (randomType)
            {
                case 1:
                    result = "ก";
                    break;
                case 2:
                    result = "ค";
                    break;
            }
            return result;
        }

        public static string PositionRank()
        {
            Random random = new Random();
            var randomType = random.Next(1, 3);
            string result = "";
            switch (randomType)
            {
                case 1:
                    result = "ประเภทวิชาการ";
                    break;
                case 2:
                    result = "ประเภทสนับสนุน";
                    break;
            }
            return result;
        }


        public static string Position()
        {
            Random random = new Random();
            var randomType = random.Next(1, 3);
            string result = "";
            switch (randomType)
            {
                case 1:
                    result = "นักวิชาการศึกษา";
                    break;
                case 2:
                    result = "อาจารย์";
                    break;
            }
            return result;
        }
        public static string PositionLevelId()
        {
            Random random = new Random();
            var randomType = random.Next(1, 5);
            string result = "";
            switch (randomType)
            {
                case 1:
                    result = "34";
                    break;
                case 2:
                    result = "35";
                    break;
                case 3:
                    result = "36";
                    break;
                case 4:
                    result = "37";
                    break;
            }
            return result;
        }
        public static string PositionLevel()
        {
            Random random = new Random();
            var randomType = random.Next(1, 3);
            string result = "";
            switch (randomType)
            {
                case 1:
                    result = "ชำนาญการ";
                    break;
                case 2:
                    result = "ปฏิบัติการ";
                    break;
            }
            return result;
        }
        public static Section Section()
        {
            Random random = new Random();
            var randomType = random.Next(1, 4);
            var result = new Section();
            switch (randomType)
            {
                case 1:
                    result.SectionId = 20410;
                    result.SectionName = "กองกลาง";
                    break;
                case 2:
                    result.SectionId = 20420;
                    result.SectionName = "ผ่ายสื่อสารองค์กร";
                    break;
                case 3:
                    result.SectionId = 20430;
                    result.SectionName = "สำนักคณบดี";
                    break;
            }
            return result;

        }
    }
}
