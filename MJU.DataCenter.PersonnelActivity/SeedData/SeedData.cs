using MJU.DataCenter.Core.Enums;
using MJU.DataCenter.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.PersonnelActivity.SeedData
{
    public class SeedData
    {
        public static Fact Fact(int c)
        {
            var m = c % 11;
            Random random = new Random();
            var randomType = random.Next(1, 12);
            var result = new Fact();

            switch (m)
            {
                case 1:
                    result.FactId = (int)Faculty.FacultyEnum.Office;
                    result.FactName = EnumHelper.GetDescriptionFromEnumValue(Faculty.FacultyEnum.Office);
                    result.ActivityId = m;
                    break;
                case 2:
                    result.FactId = (int)Faculty.FacultyEnum.Science;
                    result.FactName = EnumHelper.GetDescriptionFromEnumValue(Faculty.FacultyEnum.Science);
                    result.ActivityId = m;
                    break;
                case 3:
                    result.FactId = (int)Faculty.FacultyEnum.Engineer;
                    result.FactName = EnumHelper.GetDescriptionFromEnumValue(Faculty.FacultyEnum.Engineer);
                    result.ActivityId = m;
                    break;
                case 4:
                    result.FactId = (int)Faculty.FacultyEnum.BusinessAdministration;
                    result.FactName = EnumHelper.GetDescriptionFromEnumValue(Faculty.FacultyEnum.BusinessAdministration);
                    result.ActivityId = m;
                    break;
                case 5:
                    result.FactId = (int)Faculty.FacultyEnum.Agriculture;
                    result.FactName = EnumHelper.GetDescriptionFromEnumValue(Faculty.FacultyEnum.Agriculture);
                    result.ActivityId = m;
                    break;
                case 6:
                    result.FactId = (int)Faculty.FacultyEnum.FisheriesTechnologyAndWaterResources;
                    result.FactName = EnumHelper.GetDescriptionFromEnumValue(Faculty.FacultyEnum.FisheriesTechnologyAndWaterResources);
                    result.ActivityId = m;
                    break;
                case 7:
                    result.FactId = (int)Faculty.FacultyEnum.TourismDevelopment;
                    result.FactName = EnumHelper.GetDescriptionFromEnumValue(Faculty.FacultyEnum.TourismDevelopment);
                    result.ActivityId = m;
                    break;
                case 8:
                    result.FactId = (int)Faculty.FacultyEnum.LiberalArts;
                    result.FactName = EnumHelper.GetDescriptionFromEnumValue(Faculty.FacultyEnum.LiberalArts);
                    result.ActivityId = m;
                    break;
                case 9:
                    result.FactId = (int)Faculty.FacultyEnum.Economics;
                    result.FactName = EnumHelper.GetDescriptionFromEnumValue(Faculty.FacultyEnum.Economics);
                    result.ActivityId = m;
                    break;
                case 10:
                    result.FactId = (int)Faculty.FacultyEnum.AnimalScienceAndTechnology;
                    result.FactName = EnumHelper.GetDescriptionFromEnumValue(Faculty.FacultyEnum.AnimalScienceAndTechnology);
                    result.ActivityId = m;
                    break;
                case 0:
                    result.FactId = (int)Faculty.FacultyEnum.InformationAndCommunication;
                    result.FactName = EnumHelper.GetDescriptionFromEnumValue(Faculty.FacultyEnum.InformationAndCommunication);
                    result.ActivityId = m;
                    break;
            }
            return result;
        }

        public static Fact Fact1(int c)
        {
            var m = c % 11;
            var x = m+1;
            Random random = new Random();
            var result = new Fact();

            switch (m)
            {
                case 1:
                    result.FactId = (int)Faculty.FacultyEnum.Office;
                    result.FactName = EnumHelper.GetDescriptionFromEnumValue(Faculty.FacultyEnum.Office);
                    result.ActivityId = x;
                    break;
                case 2:
                    result.FactId = (int)Faculty.FacultyEnum.Science;
                    result.FactName = EnumHelper.GetDescriptionFromEnumValue(Faculty.FacultyEnum.Science);
                    result.ActivityId = x;
                    break;
                case 3:
                    result.FactId = (int)Faculty.FacultyEnum.Engineer;
                    result.FactName = EnumHelper.GetDescriptionFromEnumValue(Faculty.FacultyEnum.Engineer);
                    result.ActivityId = x;
                    break;
                case 4:
                    result.FactId = (int)Faculty.FacultyEnum.BusinessAdministration;
                    result.FactName = EnumHelper.GetDescriptionFromEnumValue(Faculty.FacultyEnum.BusinessAdministration);
                    result.ActivityId = x;
                    break;
                case 5:
                    result.FactId = (int)Faculty.FacultyEnum.Agriculture;
                    result.FactName = EnumHelper.GetDescriptionFromEnumValue(Faculty.FacultyEnum.Agriculture);
                    result.ActivityId = x;
                    break;
                case 6:
                    result.FactId = (int)Faculty.FacultyEnum.FisheriesTechnologyAndWaterResources;
                    result.FactName = EnumHelper.GetDescriptionFromEnumValue(Faculty.FacultyEnum.FisheriesTechnologyAndWaterResources);
                    result.ActivityId = x;
                    break;
                case 7:
                    result.FactId = (int)Faculty.FacultyEnum.TourismDevelopment;
                    result.FactName = EnumHelper.GetDescriptionFromEnumValue(Faculty.FacultyEnum.TourismDevelopment);
                    result.ActivityId = x;
                    break;
                case 8:
                    result.FactId = (int)Faculty.FacultyEnum.LiberalArts;
                    result.FactName = EnumHelper.GetDescriptionFromEnumValue(Faculty.FacultyEnum.LiberalArts);
                    result.ActivityId = x;
                    break;
                case 9:
                    result.FactId = (int)Faculty.FacultyEnum.Economics;
                    result.FactName = EnumHelper.GetDescriptionFromEnumValue(Faculty.FacultyEnum.Economics);
                    result.ActivityId = x;
                    break;
                case 10:
                    result.FactId = (int)Faculty.FacultyEnum.AnimalScienceAndTechnology;
                    result.FactName = EnumHelper.GetDescriptionFromEnumValue(Faculty.FacultyEnum.AnimalScienceAndTechnology);
                    result.ActivityId = x;
                    break;
                case 0:
                    result.FactId = (int)Faculty.FacultyEnum.InformationAndCommunication;
                    result.FactName = EnumHelper.GetDescriptionFromEnumValue(Faculty.FacultyEnum.InformationAndCommunication);
                    result.ActivityId = x;
                    break;
            }
            return result;
        }

        public static ActivitySeed randomActivity(int c)
        {
            var result = new ActivitySeed();
            var time = RandomDateTimed();
            var m = c % 11;

            Random random = new Random();
            var randomType = random.Next(1, 12);
            var model = new ActivitySeed 
            { 
            StartDate = time.GetValueOrDefault(),
            EndDate = time.GetValueOrDefault().AddDays(1),
            };
            switch (m)
            {
                case 1:
                    result.FacultyId = (int)Faculty.FacultyEnum.Office;
                    result.FacultyName = EnumHelper.GetDescriptionFromEnumValue(Faculty.FacultyEnum.Office);
                    result.StartDate = time.GetValueOrDefault();
                    result.EndDate = time.GetValueOrDefault().AddDays(1);
                    result.ActivityTypeId = 01;
                    result.ActivityTypeName = "ประเภท 01";
                    result.IsAllDay = true;
                    result.Location = "สถานที่กิจกรรม 01";
                    result.WorkLoadQty = 6;         
                    break;
                case 2:
                    result.FacultyId = (int)Faculty.FacultyEnum.Science;
                    result.FacultyName = EnumHelper.GetDescriptionFromEnumValue(Faculty.FacultyEnum.Science);
                    result.StartDate = time.GetValueOrDefault();
                    result.EndDate = time.GetValueOrDefault().AddDays(1);
                    result.ActivityTypeId = 02;
                    result.ActivityTypeName = "ประเภท 02";
                    result.IsAllDay = false;
                    result.Location = "สถานที่กิจกรรม 02";
                    result.WorkLoadQty = 4;
                    break;
                case 3:
                    result.FacultyId = (int)Faculty.FacultyEnum.Engineer;
                    result.FacultyName = EnumHelper.GetDescriptionFromEnumValue(Faculty.FacultyEnum.Engineer);
                    result.StartDate = time.GetValueOrDefault();
                    result.EndDate = time.GetValueOrDefault().AddDays(1);
                    result.ActivityTypeId = 03;
                    result.ActivityTypeName = "ประเภท 03";
                    result.IsAllDay = false;
                    result.Location = "สถานที่กิจกรรม 03";
                    result.WorkLoadQty = 3;
                    break;
                case 4:
                    result.FacultyId = (int)Faculty.FacultyEnum.BusinessAdministration;
                    result.FacultyName = EnumHelper.GetDescriptionFromEnumValue(Faculty.FacultyEnum.BusinessAdministration);
                    result.StartDate = time.GetValueOrDefault();
                    result.EndDate = time.GetValueOrDefault().AddDays(1);
                    result.ActivityTypeId = 04;
                    result.ActivityTypeName = "ประเภท 04";
                    result.IsAllDay = true;
                    result.Location = "สถานที่กิจกรรม 04";
                    result.WorkLoadQty = 7;
                    break;
                case 5:
                    result.FacultyId = (int)Faculty.FacultyEnum.Agriculture;
                    result.FacultyName = EnumHelper.GetDescriptionFromEnumValue(Faculty.FacultyEnum.Agriculture);
                    result.StartDate = time.GetValueOrDefault();
                    result.EndDate = time.GetValueOrDefault().AddDays(1);
                    result.ActivityTypeId = 05;
                    result.ActivityTypeName = "ประเภท 05";
                    result.IsAllDay = true;
                    result.Location = "สถานที่กิจกรรม 05";
                    result.WorkLoadQty = 7;
                    break;
                case 6:
                    result.FacultyId = (int)Faculty.FacultyEnum.FisheriesTechnologyAndWaterResources;
                    result.FacultyName = EnumHelper.GetDescriptionFromEnumValue(Faculty.FacultyEnum.FisheriesTechnologyAndWaterResources);
                    result.StartDate = time.GetValueOrDefault();
                    result.EndDate = time.GetValueOrDefault().AddDays(1);
                    result.ActivityTypeId = 06;
                    result.ActivityTypeName = "ประเภท 06";
                    result.IsAllDay = false;
                    result.Location = "สถานที่กิจกรรม 06";
                    result.WorkLoadQty = 3;
                    break;
                case 7:
                    result.FacultyId = (int)Faculty.FacultyEnum.TourismDevelopment;
                    result.FacultyName = EnumHelper.GetDescriptionFromEnumValue(Faculty.FacultyEnum.TourismDevelopment);
                    result.StartDate = time.GetValueOrDefault();
                    result.EndDate = time.GetValueOrDefault().AddDays(1);
                    result.ActivityTypeId = 07;
                    result.ActivityTypeName = "ประเภท 07";
                    result.IsAllDay = false;
                    result.Location = "สถานที่กิจกรรม 07";
                    result.WorkLoadQty = 3;
                    break;
                case 8:
                    result.FacultyId = (int)Faculty.FacultyEnum.LiberalArts;
                    result.FacultyName = EnumHelper.GetDescriptionFromEnumValue(Faculty.FacultyEnum.LiberalArts);
                    result.StartDate = time.GetValueOrDefault();
                    result.EndDate = time.GetValueOrDefault().AddDays(1);
                    result.ActivityTypeId = 08;
                    result.ActivityTypeName = "ประเภท 08";
                    result.IsAllDay = true;
                    result.Location = "สถานที่กิจกรรม 08";
                    result.WorkLoadQty = 6;
                    break;
                case 9:
                    result.FacultyId = (int)Faculty.FacultyEnum.Economics;
                    result.FacultyName = EnumHelper.GetDescriptionFromEnumValue(Faculty.FacultyEnum.Economics);
                    result.StartDate = time.GetValueOrDefault();
                    result.EndDate = time.GetValueOrDefault().AddDays(1);
                    result.ActivityTypeId = 09;
                    result.ActivityTypeName = "ประเภท 09";
                    result.IsAllDay = true;
                    result.Location = "สถานที่กิจกรรม 09";
                    result.WorkLoadQty = 6;
                    break;
                case 10:
                    result.FacultyId = (int)Faculty.FacultyEnum.AnimalScienceAndTechnology;
                    result.FacultyName = EnumHelper.GetDescriptionFromEnumValue(Faculty.FacultyEnum.AnimalScienceAndTechnology);
                    result.StartDate = time.GetValueOrDefault();
                    result.EndDate = time.GetValueOrDefault().AddDays(1);
                    result.ActivityTypeId = 10;
                    result.ActivityTypeName = "ประเภท 10";
                    result.IsAllDay = false;
                    result.Location = "สถานที่กิจกรรม 10";
                    result.WorkLoadQty = 3;
                    break;
                case 0:
                    result.FacultyId = (int)Faculty.FacultyEnum.InformationAndCommunication;
                    result.FacultyName = EnumHelper.GetDescriptionFromEnumValue(Faculty.FacultyEnum.InformationAndCommunication);
                    result.StartDate = time.GetValueOrDefault();
                    result.EndDate = time.GetValueOrDefault().AddDays(1);
                    result.ActivityTypeId = 11;
                    result.ActivityTypeName = "ประเภท 14";
                    result.IsAllDay = false;
                    result.Location = "สถานที่กิจกรรม 11";
                    result.WorkLoadQty = 3;
                    break;
            }

            return result;
        }

        public static DateTime? RandomDateTimed()
        {
            Random random = new Random();
            DateTime start = new DateTime(2008, 1, 1);
            int range = (DateTime.UtcNow.AddYears(5) - start).Days;
            return start.AddDays(random.Next(range));
        }
    }
}
