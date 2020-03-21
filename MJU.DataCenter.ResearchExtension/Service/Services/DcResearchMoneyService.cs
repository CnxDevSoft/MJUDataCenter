using MJU.DataCenter.ResearchExtension.Repository.Interface;
using MJU.DataCenter.ResearchExtension.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.ResearchExtension.Service.Services
{
    public class DcResearchMoneyService : IDcResearchMoneyService
    {
        private readonly IDcResearchMoneyRepository _dcResearchMoneyReoisitory;
        public DcResearchMoneyService(IDcResearchMoneyRepository dcResearchMoneyRepository)
        {
            _dcResearchMoneyReoisitory = dcResearchMoneyRepository;
        }

        // public object GetAllResearchMoney(int type)
        //{
        //    var researchMoney = _dcResearchMoneyReoisitory.GetAll();

        //}
    }
}
