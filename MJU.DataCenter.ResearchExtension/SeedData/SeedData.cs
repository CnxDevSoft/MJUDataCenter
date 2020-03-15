using MJU.DataCenter.ResearchExtension.Models;
using MJU.DataCenter.ResearchExtension.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace MJU.DataCenter.ResearchExtension.SeedData
{
    public class SeedData
    {
        private readonly IFundSeedDataService  _fundSeedDataService;
        private readonly IProjectSeedDataService _projectSeedDataService;
        public SeedData(IFundSeedDataService fundSeedService
            , IProjectSeedDataService projectSeedDataService)
        {
            _fundSeedDataService = fundSeedService;
            _projectSeedDataService = projectSeedDataService;
        }
        public static FundModel FundSeedData()
        {
            var result = new FundModel();
            Random random = new Random();
            var randomTypeA = random.Next(1, 5);
            switch (randomTypeA)
            {
                case 1:
                    result.FundCode = 1;
                    result.Fund = "กระทรวงวิทยาศาสตร์และเทคโนโลยี";
                    break;
                case 2:
                    result.FundCode = 2;
                    result.Fund = "กระทรวงการอุดมศึกษา";
                    break;
                case 3:
                    result.FundCode = 3;
                    result.Fund = "กระทรวงเกษตรและสหกรณ์";
                    break;
                case 4:
                    result.FundCode = 4;
                    result.Fund = "กระทรวงท่องเที่ยวและกีฬา";
                    break;
            }
            return result;
        }
        public static ProjectModel ProjectSeedData()
        {
            Random random = new Random();
            StringBuilder str_build = new StringBuilder();
            var result = new ProjectModel();

            return result;
        }
        public static string RandomProjectName()
        {
            Random random = new Random();
            StringBuilder str_build = new StringBuilder();
            string alphabet = "กขฃคฅฆงจฉชซฌญฎฏฐฑฒณดตถทธนบปผฝพฟภมยรลวศษสหฬอฮ";
            int size = random.Next(5, 15);
            var resualt = Enumerable.Range(0, size).Select(x => alphabet[random.Next(0, alphabet.Length)]);
            return new string(resualt.ToArray());
        }
        public static string RandomProjectLead()
        {
            Random random = new Random();
            StringBuilder str_build = new StringBuilder();
            string alphabet = "กขฃคฅฆงจฉชซฌญฎฏฐฑฒณดตถทธนบปผฝพฟภมยรลวศษสหฬอฮ";
            int size = random.Next(5, 10);
            var resualt = Enumerable.Range(0, size).Select(x => alphabet[random.Next(0, alphabet.Length)]);
            return new string(resualt.ToArray());
        }
        public static int RandomProjectCode()
        {
            Random random = new Random();
            StringBuilder str_build = new StringBuilder();
            string alphabet = "0123456789";
            int size = 3;
            var resualt = Enumerable.Range(0, size).Select(x => alphabet[random.Next(0, alphabet.Length)]);
            return int.Parse(resualt.ToArray());
        }
        public static YearMount RandomMountCode()
        {
            var result = new YearMount();
            Random random = new Random();
            var randomTypeA = random.Next(1, 6);
            switch (randomTypeA)
            {
                case 1:
                    result.MountCode = 1;
                    result.MountYear = "2558";
                    break;
                case 2:
                    result.MountCode = 2;
                    result.MountYear = "2559";
                    break;
                case 3:
                    result.MountCode = 3;
                    result.MountYear = "2560";
                    break;
                case 4:
                    result.MountCode = 4;
                    result.MountYear = "2561";
                    break;
                case 5:
                    result.MountCode = 5;
                    result.MountYear = "2562";
                    break;

            }
            return result;

        }
        public static int RandomDdpart()
        {
            Random random = new Random();
            int randomTypeA = random.Next(1, 10);

            return randomTypeA; 

        }
        public static decimal RandomBudget()
        {
            Random random = new Random();
            decimal randomTypeA = random.Next(300000, 1000000);
            return randomTypeA;
        }
        public static int TypeProject()
        {
            Random random = new Random();
            int randomTypeA = random.Next(1, 5);
            return randomTypeA;
        }
        public static int PlanCode()
        {
            Random random = new Random();
            int randomTypeA = random.Next(1, 7);
            return randomTypeA;
        }
        public static int ActiveCode()
        {
            Random random = new Random();
            int randomTypeA = random.Next(1, 13);
            return randomTypeA;
        }
        public static int StatusCode()
        {
            Random random = new Random();
            int randomTypeA = random.Next(1, 3);
            return randomTypeA;
        }


    }
}
