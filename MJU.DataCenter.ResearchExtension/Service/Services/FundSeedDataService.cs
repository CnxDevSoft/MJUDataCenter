using MJU.DataCenter.ResearchExtension.Models;
using MJU.DataCenter.ResearchExtension.Repository.Interface;
using MJU.DataCenter.ResearchExtension.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.ResearchExtension.Service.Services
{
    public class FundSeedDataService : IFundSeedDataService
    {
        private readonly IFundRepository _fundRepository;
        public FundSeedDataService(IFundRepository fundRepository)
        {
            _fundRepository = fundRepository;
        }

        public void AddFund()
        {         
            var list = new List<Fund>();

            for (var i =0;i<400;i++)
            {
                var FundData = SeedData.SeedData.FundSeedData();
                var result = new Fund
                {
                    Fund1 = FundData.Fund,
                    FundCode = FundData.FundCode
                };
                list.Add(result);
            }
            _fundRepository.AddRange(list);
        }
    }
}
