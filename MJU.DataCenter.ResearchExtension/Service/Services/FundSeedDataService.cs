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
    }
}
