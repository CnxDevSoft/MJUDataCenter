using System;
using System.Collections.Generic;
using System.Linq;
using MJU.DataCenter.Personnel.ViewModels;
using MJU.DataCenter.ResearchExtension.Repository.Interface;
using MJU.DataCenter.ResearchExtension.Service.Interface;
using MJU.DataCenter.ResearchExtension.ViewModels;

namespace MJU.DataCenter.ResearchExtension.Service.Services
{
    public class ResearchAndExtensionService : IResearchAndExtensionService
    {
        private readonly IDcResearchDepartmentRepository _dcResearchDepartmentRepository;
        private readonly IDcResearchGroupRepository _dcResearchGroupRepository;
        private readonly IDcResearchDataRepository _dcResearchDataRepository;
        private readonly IDcResearchMoneyRepository _dcResearchMoneyReoisitory;
        public ResearchAndExtensionService(IDcResearchGroupRepository dcResearchGroupRepository,
            IDcResearchDataRepository dcResearchDataRepository, IDcResearchDepartmentRepository dcResearchDepartmentRepository,
            IDcResearchMoneyRepository dcResearchMoneyRepository)
        {
            _dcResearchGroupRepository = dcResearchGroupRepository;
            _dcResearchDataRepository = dcResearchDataRepository;
            _dcResearchMoneyReoisitory = dcResearchMoneyRepository;
             _dcResearchMoneyReoisitory = dcResearchMoneyRepository;

        }

        public object GetResearchDepartment(int type)
        {
            var researchDepartment = _dcResearchDepartmentRepository.GetAll().ToList();
            var distinctResearchDepartment = researchDepartment.Select(m => new { m.DepartmentId ,m.DepartmentNameTh}).Distinct().OrderBy(o=>o.DepartmentId);
            if(type == 1)
            {
                var label = new List<string>();
                var data = new List<int>();
                var viewData = new List<ViewData>();
                var i = 0;
                foreach (var rd in distinctResearchDepartment)
                {
                    var researchDepartmentWithCondition = researchDepartment.Where(m => m.DepartmentId == rd.DepartmentId && m.DepartmentNameTh == rd.DepartmentNameTh);

                    viewData.Add(
                        new ViewData
                        {
                            index = i,
                            LisViewData = researchDepartmentWithCondition.ToList()
                        }

                    );

                    label.Add(rd.DepartmentNameTh);
                    data.Add(researchDepartmentWithCondition.Count());
                    i++;
                }
                var graphDataSet = new GraphDataSet
                {
                    Data = data
                };
                var result = new GraphData
                {
                    GraphDataSet = new List<GraphDataSet> {
                     graphDataSet
                    },
                    Label = label,
                    ViewData = viewData

                };
                return result;
               
            }
            else
            {
                var list = new List<ResearchDepartmentViewModel>();
                foreach (var rd in distinctResearchDepartment)
                {
                    var model = new ResearchDepartmentViewModel
                    {
                        DepartmentId = rd.DepartmentId,
                        DepartmentName = rd.DepartmentNameTh,
                        ResearchData = researchDepartment.Where(m => m.DepartmentId == rd.DepartmentId && m.DepartmentNameTh == rd.DepartmentNameTh).ToList()
                    };
                    list.Add(model);
                }
                return list;
            }
        }
        public object GetResearchGroup(int type)
        {
            var researchGroup = _dcResearchGroupRepository.GetAll().ToList();
            var distinctResearchGroup = researchGroup.Select(m => new { m.PersonGroupId, m.PersonGroupName }).Distinct().OrderBy(o => o.PersonGroupId);
            if (type == 1)
            {
                var label = new List<string>();
                var data = new List<int>();
                var viewData = new List<ViewData>();
                var i = 0;
                foreach (var rg in distinctResearchGroup)
                {
                    var researchDepartmentWithCondition = researchGroup.Where(m => m.PersonGroupId == rg.PersonGroupId && m.PersonGroupName == rg.PersonGroupName);

                    viewData.Add(
                        new ViewData
                        {
                            index = i,
                            LisViewData = researchDepartmentWithCondition.ToList()
                        }

                    );

                    label.Add(rg.PersonGroupName);
                    data.Add(researchDepartmentWithCondition.Count());
                    i++;
                }
                var graphDataSet = new GraphDataSet
                {
                    Data = data,

                };
                var result = new GraphData
                {
                    GraphDataSet = new List<GraphDataSet> {
                     graphDataSet
                    },
                    Label = label,
                    ViewData = viewData
                };
                return result;

            }
            else
            {
                var list = new List<ResearchGroupViewModel>();
                foreach (var rg in distinctResearchGroup)
                {
                    var model = new ResearchGroupViewModel
                    {
                        PersonGroupId = rg.PersonGroupId,
                        PersonGroupName = rg.PersonGroupName,
                        ResearchData = researchGroup.Where(m => m.PersonGroupId == rg.PersonGroupId && m.PersonGroupName == rg.PersonGroupName).ToList()
                    };
                    list.Add(model);
                }
                return list;
            }
        }

        public object GetResearchData(int type)
        {
            var researchData = _dcResearchDataRepository.GetAll().ToList();
            var distinctResearchData = researchData.Select(m => new { m.ResearchMoneyTypeId, m.MoneyName }).Distinct().OrderBy(o => o.ResearchMoneyTypeId);
            if (type == 1)
            {
                var label = new List<string>();
                var data = new List<int>();
                var viewData = new List<ViewData>();
                var i = 0;
                foreach (var rd in distinctResearchData)
                {
                    var researchDepartmentWithCondition = researchData.Where(m => m.ResearchMoneyTypeId == rd.ResearchMoneyTypeId && m.MoneyName == rd.MoneyName);

                    viewData.Add(
                        new ViewData
                        {
                            index = i,
                            LisViewData = researchDepartmentWithCondition.ToList()
                        }

                    );

                    label.Add(rd.MoneyName);
                    data.Add(researchDepartmentWithCondition.Count());
                    i++;
                }
                var graphDataSet = new GraphDataSet
                {
                    Data = data,
                };
                var result = new GraphData
                {
                    GraphDataSet = new List<GraphDataSet> {
                     graphDataSet
                    },
                    Label = label,
                    ViewData = viewData

                };
                return result;

            }
            else
            {
                var list = new List<ResearchDataViewModel>();
                foreach (var rd in distinctResearchData)
                {
                    var model = new ResearchDataViewModel
                    {
                        MoneyTypeId = rd.ResearchMoneyTypeId,
                        MoneyTypeName = rd.MoneyName,
                        ResearchData = researchData.Where(m => m.ResearchMoneyTypeId == rd.ResearchMoneyTypeId && m.MoneyName == rd.MoneyName).ToList()
                    };
                    list.Add(model);
                }
                return list;
            }
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
