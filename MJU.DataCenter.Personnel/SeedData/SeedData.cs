using MJU.DataCenter.Personnel.Models;
using MJU.DataCenter.Personnel.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MJU.DataCenter.Core.Enum;
using MJU.DataCenter.Core.HelperEnum;

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
        public static DateTime? RandomDateTime()
        {
            Random random = new Random();
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.UtcNow.AddYears(5) - start).Days;
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
        public static PersonnelType TypePersonCode()
        {
            Random random = new Random();
            var randomType = random.Next(1, 8);
            var result = new PersonnelType();
            switch (randomType)
            {
                case 1:
                    result.PersonTypeId = "P";
                    result.PersonType = "ข้าราชกาล";
                    break;
                case 2:
                    result.PersonTypeId = "E";
                    result.PersonType = "ลูกจ้างประจำ";
                    break;
                case 3:
                    result.PersonTypeId = "M";
                    result.PersonType = "พนักงานมหาวิทยาลัย";
                    break;
                case 4:
                    result.PersonTypeId = "EG";
                    result.PersonType = "พนักงานมหาวิทยาลัยเงินรายได้";
                    break;
                case 5:
                    result.PersonTypeId = "T";
                    result.PersonType = "พนักงานราชการ";
                    break;
                case 6:
                    result.PersonTypeId = "Y";
                    result.PersonType = "ลูกจ้างชั่วคราวเงินงบประมาณ";
                    break;
                case 7:
                    result.PersonTypeId = "O";
                    result.PersonType = "พนักงานส่วนงาน";
                    break;
            }

            return result;
        }

        //public static string TypePerson()
        //{
        //    Random random = new Random();
        //    var randomType = random.Next(1, 3);
        //    string result = "";
        //    switch (randomType)
        //    {
        //        case 1:
        //            result = "ข้าราชกาล";
        //            break;
        //        case 2:
        //            result = "ลูกจ้างประจำ";
        //            break;
        //        case 3:
        //            result = "พนักงานมหาวิทยาลัย";
        //            break;
        //        case 4:
        //            result = "พนักงานมหาวิทยาลัยเงินรายได้";
        //            break;

        //    }

        //    return result;
        //}
        //public static string PositionRankId()
        //{
        //    Random random = new Random();
        //    var randomType = random.Next(1, 3);
        //    string result = "";
        //    switch (randomType)
        //    {
        //        case 1:
        //            result = "ก";
        //            break;
        //        case 2:
        //            result = "ค";
        //            break;
        //    }
        //    return result;
        //}

        public static PositionType PositionType()
        {
            Random random = new Random();
            var randomType = random.Next(1, 3);
            var result = new PositionType();
            switch (randomType)
            {
                case 1:
                    result.PositionTypeName = "ประเภทวิชาการ";
                    result.PositionTypeId = "ก";
                    break;
                case 2:
                    result.PositionTypeName = "ประเภทสนับสนุน";
                    result.PositionTypeId = "ค";
                    break;
            }
            return result;
        }

        //public static PositionLevel PositionLevel()
        //{
        //    Random random = new Random();
        //    var randomType = random.Next(1, 3);
        //    var result = new PositionLevel();
        //    switch (randomType)
        //    {
        //        case 1:
        //            result.PositionLevelkId = "ประเภทวิชาการ";
        //            result.PositionLevelName = "ก";
        //            break;
        //        case 2:
        //            result.PositionLevelkId = "ประเภทสนับสนุน";
        //            result.PositionLevelName = "ค";
        //            break;
        //    }
        //    return result;
        //}


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
        public static PositionLevel PositionLevel()
        {
            Random random = new Random();
            var randomType = random.Next(1, 3);
            var result = new PositionLevel();
            switch (randomType)
            {
                case 1:
                    result.PositionLevelId = "34";
                    result.PositionLevelName = "ชำนาญการ";
                    break;
                case 2:
                    result.PositionLevelId = "35";
                    result.PositionLevelName = "ปฏิบัติการ";
                    break;
            }
            return result;
        }
        //public static string PositionLevel()
        //{
        //    Random random = new Random();
        //    var randomType = random.Next(1, 3);
        //    string result = "";
        //    switch (randomType)
        //    {
        //        case 1:
        //            result = "ชำนาญการ";
        //            break;
        //        case 2:
        //            result = "ปฏิบัติการ";
        //            break;
        //    }
        //    return result;
        //}
        public static Section Section()
        {
            Random random = new Random();
            var randomType = random.Next(1, 4);
            var result = new Section();
            switch (randomType)
            {
                case 1:
                    result.SectionId = 20411;
                    result.SectionName = "งานบริหารและธุรการ";
                    break;
                case 2:
                    result.SectionId = 20412;
                    result.SectionName = "";
                    break;
                case 3:
                    result.SectionId = 20413;
                    result.SectionName = "";
                    break;
            }
            return result;
        }
        public static Division Division()
        {
            Random random = new Random();
            var randomType = random.Next(1, 4);
            var result = new Division();
            switch (randomType)
            {
                case 1:
                    result.DivisionId = 20401;
                    result.DivisionName = "กองกลาง";
                    break;
                case 2:
                    result.DivisionId = 20402;
                    result.DivisionName = "ผ่ายสื่อสารองค์กร";
                    break;
                case 3:
                    result.DivisionId = 20403;
                    result.DivisionName = "สำนักคณบดี";
                    break;
            }
            return result;
        }
        public static Fact Fact()
        {
            Random random = new Random();
            var randomType = random.Next(1, 4);
            var result = new Fact();
            var test = EnumHelper.GetDescriptionFromEnumValue((int)Faculty.Office.Office);
            switch (randomType)
            {
                case 1:
                    
                    result.FactId = (int)Faculty.Office.Office;
                    result.FactName = EnumHelper.GetDescriptionFromEnumValue((int)Faculty.Office.Office);
                    break;
                case 2:
                    result.FactId = (int)Faculty.FacultyScience.Science;
                    result.FactName = "คณะวิทยาศาสตร์";
                    break;
                case 3:
                    result.FactId = (int)Faculty.FacultyEngineer.Engineer;
                    result.FactName = "คณะวิศวกรรมศาสตร์";
                    break;
                case 4:
                    result.FactId = (int)Faculty.FacultyBusinessAdministration.BusinessAdministration;
                    result.FactName = "คณะบริหารธุรกิจ";
                    break;
                case 5:
                    result.FactId = (int)Faculty.FacultyAgriculture.Agriculture;
                    result.FactName = Faculty.FacultyAgriculture.Agriculture.ToString();
                    break;
            }
            return result;
        }
        public static string Salary()
        {
            Random random = new Random();
            StringBuilder str_build = new StringBuilder();
            string alphabet = "123456789";
            int size = random.Next(5, 6);
            var resualt = Enumerable.Range(0, size).Select(x => alphabet[random.Next(0, alphabet.Length)]);
            return new string(resualt.ToArray());
        }
        public static AdminPosition AdminPosition()
        {
            Random random = new Random();
            var randomTypeA = random.Next(1, 4);
            var randomTypeB = random.Next(1, 3);
            var result = new AdminPosition();
            switch (randomTypeA)
            {
                case 1:
                    result.AdminPositionId = 10;
                    result.AdminPositionType = "อธิการบดี";
                    break;
                case 2:
                    result.AdminPositionId = 20;
                    result.AdminPositionType = "รองอธิการบดี";
                    break;
                case 3:
                    result.AdminPositionId = 30;
                    result.AdminPositionType = "คณบดี";
                    break;
            }
            switch (randomTypeB)
            {
                case 1:
                    result.AdminPositionName = "คณบดีคณะวิทยาศาสตร์";
                    break;
                case 2:
                    result.AdminPositionName = "ผู้อำนวยการกองคลัง";
                    break;
            }
            return result;
        }
        public static Education Education()
        {
            Random random = new Random();
            var randomTypeA = random.Next(1, 5);
            var randomTypeB = random.Next(1, 5);
            var randomTypeU = random.Next(1, 3);
            var result = new Education();
            switch (randomTypeA)
            {
                case 1:
                    result.EducationLevelId = 10;
                    result.EducationLevel = "ปริญญาตรี";
                    break;
                case 2:
                    result.EducationLevelId = 20;
                    result.EducationLevel = "ปริญญาโท";
                    break;
                case 3:
                    result.EducationLevelId = 30;
                    result.EducationLevel = "ปริญญาเอก";
                    break;
                case 4:
                    result.EducationLevelId = 00;
                    result.EducationLevel = "ตํ่ากว่า ปริญญาตรี";
                    break;
            }

            switch (randomTypeB)
            {
                case 1:
                    result.TitleEducation = "วท.บ. /B.Sc";
                    result.EducationName = "วิทยาศาสตรบัณฑิต";
                    if (randomTypeA == 1) 
                    {
                        result.Major = "วิทยาการคอมพิวเตอร์";
                        result.University = randomTypeU == 1 ? result.University = "มหาวิทยาลัยเชียงใหม่" : result.University = "มหาวิทยาลัยแม่โจ้";
                        result.CountryId = "TH";
                    }
                    else if (randomTypeA == 2)
                    {
                        result.Major = "สถิติประยุกต์";
                        result.University = randomTypeU == 1 ? result.University = "มหาวิทยาลัยเชียงใหม่" : result.University = "มหาวิทยาลัยแม่โจ้";
                        result.CountryId = "TH";
                    }
                    else if (randomTypeA == 3)
                    {
                        result.Major = "เคมี";
                        result.University = randomTypeU == 1 ? result.University = "มหาวิทยาลัยเชียงใหม่" : result.University = "มหาวิทยาลัยแม่โจ้";
                    }
                    else if (randomTypeA == 4)
                    {
                        result.Major = null;
                        result.University = null;
                    }
                    result.CountryId = "TH";
                    result.Country = "ไทย";
                    break;

                case 2:
                    result.TitleEducation = "วศ.บ. /B.Eng.";
                    result.EducationName = "วิศวกรรมศาสตรบัณฑิต";
                    if (randomTypeA == 1)
                    {
                        result.Major = "เกษตร";
                        result.University = randomTypeU == 1 ? result.University = "มหาวิทยาลัยเชียงใหม่" : result.University = "มหาวิทยาลัยแม่โจ้";
                        result.CountryId = "TH";
                    }
                    else if (randomTypeA == 2)
                    {
                        result.Major = "อุตสาหกรรมอาหาร";
                        result.University = randomTypeU == 1 ? result.University = "มหาวิทยาลัยเชียงใหม่" : result.University = "มหาวิทยาลัยแม่โจ้";
                    }
                    else if (randomTypeA == 3)
                    {
                        result.Major = "วิศวกรรมเครื่องกล";
                        result.University = randomTypeU == 1 ? result.University = "มหาวิทยาลัยเชียงใหม่" : result.University = "มหาวิทยาลัยแม่โจ้";
                    }
                    else if (randomTypeA == 4)
                    {
                        result.Major = null;
                        result.University = null;
                    }
                    result.CountryId = "TH";
                    result.Country = "ไทย";
                    break;

                case 3:
                    result.TitleEducation = "รป.บ. / B.P.A.";
                    result.EducationName = "รัฐประศาสนศาสตรบัณฑิต";
                    if (randomTypeA == 1)
                    {
                        result.Major = "รัฐประศาสนศาสตร์";
                        result.University = randomTypeU == 1 ? result.University = "มหาวิทยาลัยเชียงใหม่" : result.University = "มหาวิทยาลัยแม่โจ้";
                    }
                    else if (randomTypeA == 2)
                    {
                        result.Major = "รัฐประศาสนศาสตร์";
                        result.University = randomTypeU == 1 ? result.University = "มหาวิทยาลัยเชียงใหม่" : result.University = "มหาวิทยาลัยแม่โจ้";
                    }
                    else if (randomTypeA == 3)
                    {
                        result.Major = "รัฐประศาสนศาสตร์";
                        result.University = randomTypeU == 1 ? result.University = "มหาวิทยาลัยเชียงใหม่" : result.University = "มหาวิทยาลัยแม่โจ้";
                    }
                    else if (randomTypeA == 4)
                    {
                        result.Major = null;
                        result.University = null;
                    }
                    result.CountryId = "TH";
                    result.Country = "ไทย";
                    break;
                case 4:
                    result.TitleEducation = "บธ.บ. / B.B.A.";
                    result.EducationName = "ธุรกิจและบริหาร";
                    if (randomTypeA == 1)
                    {
                        result.Major = "วิชาผู้ประกอบการ";
                        result.University = randomTypeU == 1 ? result.University = "มหาวิทยาลัยเชียงใหม่" : result.University = "มหาวิทยาลัยแม่โจ้";
                    }
                    else if (randomTypeA == 2)
                    {
                        result.Major = "ธุรกิจศึกษา";
                        result.University = randomTypeU == 1 ? result.University = "มหาวิทยาลัยเชียงใหม่" : result.University = "มหาวิทยาลัยแม่โจ้";
                    }
                    else if (randomTypeA == 3)
                    {
                        result.Major = "การบัญชี";
                        result.University = randomTypeU == 1 ? result.University = "มหาวิทยาลัยเชียงใหม่" : result.University = "มหาวิทยาลัยแม่โจ้";
                    }
                    else if (randomTypeA == 4)
                    {
                        result.Major = null;
                        result.University = null;
                    }
                    if (randomTypeA == 4) 
                    { 
                    result.CountryId = "TH";
                    result.Country = "ไทย";
                    }
                    else
                    {
                        result.CountryId = "TW";
                        result.Country = "ไต้หวัน";
                    }
                    break;
            }
            return result;
        }


    }
}
