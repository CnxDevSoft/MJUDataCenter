using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MJU.DataCenter.Core.Enums
{
    public class Faculty
    {

            public enum Office
            {
                [Description("สำนักงานมหาวิทยาลัย")]
                Office = 20001

            }
            public enum FacultyScience
            {
                [Description("คณะวิทยาศาสตร์")]
                Science = 20002

            }
            public enum FacultyEngineer
            {
                [Description("คณะวิศวกรรมและอุตสาหกรรมเกษตร")]
                Engineer = 20003
            }
            public enum FacultyBusinessAdministration
            {
                [Description("คณะบริหารธุรกิจ")]
                BusinessAdministration = 20004

            }
            public enum FacultyAgriculture
            {
                [Description("คณะผลิตกรรมการเกษตร")]
                Agriculture = 20005
            }
            public enum FacultyFisheriesTechnologyAndWaterResources
            {
                [Description("คณะเทคโนโลยีการประมงและทรัพยากรทางน้ำ")]
                 FisheriesTechnologyAndWaterResources = 20006
            }
            public enum FacultyTourismDevelopment
            {
                [Description("คณะพัฒนาการท่องเที่ยว")]
                TourismDevelopment = 20007
            }
            public enum FacultyLiberalArts
            {
                [Description("คณะศิลปศาสตร์")]
                LiberalArts = 20008
            }
            public enum FacultyEconomics
            {
                [Description("คณะเศรษฐศาสตร์")]
                Economics = 20009
            }
            public enum FacultyAnimalScienceAndTechnology
            {
                [Description("คณะสัตวศาสตร์และเทคโนโลยี")]
                AnimalScienceAndTechnology = 20010
            }
            public enum FacultyInformationAndCommunication
            {
                [Description("คณะสารสนเทศและการสื่อสาร")]
                InformationAndCommunication = 20011
            }
        }
}
