using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MJU.Datacenter.Core.Enum
{
    public class Faculty
    {
        public enum FacultyScience
        {
            [Description("คณะวิทยาศาสตร์")]
            FacultyId = 20001

        }
        public enum FacultyEngineer
        {
            [Description("คณะวิศวกรรมและอุตสาหกรรมเกษตร")]
            FacultyId = 20002
        }
        public enum FacultyBusinessAdministration
        {
            [Description("คณะบริหารธุรกิจ")]
            FacultyId = 20003

        }
        public enum FacultyAgriculture
        {
            [Description("คณะผลิตกรรมการเกษตร")]
            FacultyId = 20004
        }
        public enum FacultyFisheriesTechnologyAndWaterResources
        {
            [Description("คณะเทคโนโลยีการประมงและทรัพยากรทางน้ำ")]
            FacultyId = 20005
        }
        public enum FacultyTourismDevelopment
        {
            [Description("คณะพัฒนาการท่องเที่ยว")]
            FacultyId = 20006
        }
        public enum FacultyLiberalArts
        {
            [Description("คณะศิลปศาสตร์")]
            FacultyId = 20007
        }
        public enum FacultyEconomics
        {
            [Description("คณะเศรษฐศาสตร์")]
            FacultyId = 20008
        }
        public enum FacultyAnimalScienceAndTechnology
        {
            [Description("คณะสัตวศาสตร์และเทคโนโลยี")]
            FacultyId = 20009
        }
        public enum FacultyInformationAndCommunication
        {
            [Description("คณะสารสนเทศและการสื่อสาร")]
            FacultyId = 20010
        }
    }
}
