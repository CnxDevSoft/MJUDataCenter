using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MJU.DataCenter.Core.Enums
{
    public class ResearchExtensionFaculty
    {
        public enum DepartmentEnum
        {
            [Description("สำนักงานมหาวิทยาลัย")]
            Office = 20001,
            [Description("คณะวิทยาศาสตร์")]
            Science = 20002,
            [Description("คณะวิศวกรรมและอุตสาหกรรมเกษตร")]
            Engineer = 20003,
            [Description("คณะบริหารธุรกิจ")]
            BusinessAdministration = 20004,
            [Description("คณะผลิตกรรมการเกษตร")]
            Agriculture = 20005,
            [Description("คณะเทคโนโลยีการประมงและทรัพยากรทางน้ำ")]
            FisheriesTechnologyAndWaterResources = 20006,
            [Description("คณะพัฒนาการท่องเที่ยว")]
            TourismDevelopment = 20007,
            [Description("คณะศิลปศาสตร์")]
            LiberalArts = 20008,
            [Description("คณะเศรษฐศาสตร์")]
            Economics = 20009,
            [Description("คณะสัตวศาสตร์และเทคโนโลยี")]
            AnimalScienceAndTechnology = 20010,
            [Description("คณะสารสนเทศและการสื่อสาร")]
            InformationAndCommunication = 20011
        }
    }
}
