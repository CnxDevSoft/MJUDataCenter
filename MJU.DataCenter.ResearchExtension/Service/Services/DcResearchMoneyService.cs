using MJU.DataCenter.Personnel.ViewModels;
using MJU.DataCenter.ResearchExtension.Repository.Interface;
using MJU.DataCenter.ResearchExtension.Service.Interface;
using MJU.DataCenter.ResearchExtension.ViewModels;
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

        public object GetAllResearchMoney(int type)
        {
            var researchMoney = _dcResearchMoneyReoisitory.GetAll();
            if (type == 1)
            {
                var list = new List<GraphDataSet>();
                var label = new List<string> { "ตํ่ากว่า 100,000", "100,001 - 500,000","500,001 - 1,000,000"
                     ,"1,000,001 - 5,000,000","5,000,001 - 10,000,000","10,000,001 - 20,000,000","20,000,000 ขึ้นไป"
                };

                var lower100k = researchMoney.Where(m => m.ResearchMoney < 100000 && m.ResearchMoney > 0).Count();
                var between100kTo500k = researchMoney.Where(m => m.ResearchMoney >= 100001 && m.ResearchMoney <= 500001).Count();
                var between500kTo1m = researchMoney.Where(m => m.ResearchMoney >= 500001 && m.ResearchMoney <= 1000000).Count();
                var between1mTo5m = researchMoney.Where(m => m.ResearchMoney >= 1000001 && m.ResearchMoney <= 5000000).Count();
                var between5mTo10m = researchMoney.Where(m => m.ResearchMoney >= 5000001 && m.ResearchMoney <= 10000000).Count();
                var between10mTo20m = researchMoney.Where(m => m.ResearchMoney >= 100000001 && m.ResearchMoney <= 20000000).Count();
                var over20m = researchMoney.Where(m => m.ResearchMoney >= 20000000).Count();

                var graphDataSet = new GraphDataSet
                {
                    Data = new List<int>{
                              lower100k,
                              between100kTo500k,
                              between500kTo1m,
                              between1mTo5m,
                              between5mTo10m,
                              between10mTo20m,
                              over20m
                        }
                };
                list.Add(graphDataSet);
                var result = new GraphData
                {
                    GraphDataSet = list,
                    Label = label
                };
                return result;
            }
            else
            {
                var result = new List<RankResearchMoneyViewModel>();
                
                var lower100k = researchMoney.Where(m => m.ResearchMoney < 100000 && m.ResearchMoney > 0).Count();
                var between100kTo500k = researchMoney.Where(m => m.ResearchMoney >= 100001 && m.ResearchMoney <= 500001).Count();
                var between500kTo1m = researchMoney.Where(m => m.ResearchMoney >= 500001 && m.ResearchMoney <= 1000000).Count();
                var between1mTo5m = researchMoney.Where(m => m.ResearchMoney >= 1000001 && m.ResearchMoney <= 5000000).Count();
                var between5mTo10m = researchMoney.Where(m => m.ResearchMoney >= 5000001 && m.ResearchMoney <= 10000000).Count();
                var between10mTo20m = researchMoney.Where(m => m.ResearchMoney >= 100000001 && m.ResearchMoney <= 20000000).Count();
                var over20m = researchMoney.Where(m => m.ResearchMoney >= 20000000).Count();

                var rankResearchMoney = new List<RankResearchMoney>
            {
              new RankResearchMoney
              {
                  RankResearchName ="ตํ่ากว่า 100,000",
                  Money = lower100k
              },
              new RankResearchMoney
              {
                  RankResearchName ="100,001 - 500,000",
                  Money = between100kTo500k
              },
              new RankResearchMoney
              {
                  RankResearchName ="500,001 - 1,000,000",
                  Money = between500kTo1m
              },
              new RankResearchMoney
              {
                  RankResearchName ="1,000,001 - 5,000,000",
                  Money = between1mTo5m
              },
              new RankResearchMoney
              {
                  RankResearchName ="5,000,001 - 10,000,000",
                  Money = between5mTo10m
              },
              new RankResearchMoney
              {
                  RankResearchName ="10,000,001 - 20,000,000",
                  Money = between10mTo20m
              },
              new RankResearchMoney
              {
                  RankResearchName ="20,000,000 ขึ้นไป",
                  Money = over20m
              }
            };

                var rankResearchMoneyViewModel = new RankResearchMoneyViewModel
                {
                    RankResearchMoney = rankResearchMoney
                };
                result.Add(rankResearchMoneyViewModel);
                return result;
            }
            
        }
    }
}
