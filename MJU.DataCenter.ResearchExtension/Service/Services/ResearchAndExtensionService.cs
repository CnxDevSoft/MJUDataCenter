using System;
using System.Collections.Generic;
using System.Linq;
using MJU.DataCenter.Personnel.ViewModels;
using MJU.DataCenter.ResearchExtension.Models;
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
        public ResearchAndExtensionService(IDcResearchGroupRepository dcResearchGroupRepository
            ,IDcResearchDataRepository dcResearchDataRepository
            , IDcResearchMoneyRepository dcResearchMoneyRepository
            , IDcResearchDepartmentRepository dcResearchDepartmentRepository)
        {
            _dcResearchDepartmentRepository = dcResearchDepartmentRepository;
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
                var value = new List<int?>();
                var viewData = new List<ViewData>();
                var i = 0;
                foreach (var rd in distinctResearchDepartment)
                {
                    var researchDepartmentWithCondition = researchDepartment.Where(m => m.DepartmentId == rd.DepartmentId && m.DepartmentNameTh == rd.DepartmentNameTh);
                    //value.Add(researchDepartmentWithCondition.Sum(s => s.ResearchMoney));
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
                    ViewData = viewData,
                    Value = value

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
                var value = new List<int?>();
                var viewData = new List<ViewData>();
                var i = 0;
                foreach (var rg in distinctResearchGroup)
                {
                    var researchDepartmentWithCondition = researchGroup.Where(m => m.PersonGroupId == rg.PersonGroupId && m.PersonGroupName == rg.PersonGroupName);
                   // value.Add(researchDepartmentWithCondition.Sum(s => s.ResearchMoney));
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
                    ViewData = viewData,
                    Value = value
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
            var distinctResearchData = researchData.Select(m => new { m.ResearchMoneyTypeId, m.MoneyTypeName }).Distinct().OrderBy(o => o.ResearchMoneyTypeId);
            if (type == 1)
            {
                var label = new List<string>();
                var data = new List<int>();
                var value = new List<int?>();
                var viewData = new List<ViewData>();
                var i = 0;
                foreach (var rd in distinctResearchData)
                {
                    var researchDepartmentWithCondition = researchData.Where(m => m.ResearchMoneyTypeId == rd.ResearchMoneyTypeId && m.MoneyTypeName == rd.MoneyTypeName);
                    value.Add(researchDepartmentWithCondition.Sum(s => s.ResearchMoney));
                    viewData.Add(
                        new ViewData
                        {
                            index = i,
                            LisViewData = researchDepartmentWithCondition.ToList()
                        }

                    );

                    label.Add(rd.MoneyTypeName);
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
                    ViewData = viewData,
                    Value = value

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
                        MoneyTypeName = rd.MoneyTypeName,
                        ResearchData = researchData.Where(m => m.ResearchMoneyTypeId == rd.ResearchMoneyTypeId && m.MoneyTypeName == rd.MoneyTypeName).ToList()
                    };
                    list.Add(model);
                }
                return list;
            }
        }

        public object GetAllResearchMoney(int type)
        {
            var researchMoney = _dcResearchMoneyReoisitory.GetAll();
            var distinctResearchMoney = researchMoney.Select(m=> new {m.ResearchId,m.ResearchNameTh}).Distinct().OrderBy(o => o.ResearchId);
            if (type == 1)
            {
                var list = new List<GraphDataSet>();
                var data = new List<int>();
                
                var label = new List<string> { "ตํ่ากว่า 100,000", "100,001 - 500,000","500,001 - 1,000,000"
                     ,"1,000,001 - 5,000,000","5,000,001 - 10,000,000","10,000,001 - 20,000,000","20,000,000 ขึ้นไป"
                };
                
                var i = 0;
                var lower100k = researchMoney.Where(m => m.ResearchMoney < 100000 && m.ResearchMoney > 0);
                var between100kTo500k = researchMoney.Where(m => m.ResearchMoney >= 100000 && m.ResearchMoney <= 500000);
                var between500kTo1m = researchMoney.Where(m => m.ResearchMoney >= 500000 && m.ResearchMoney <= 1000000);
                var between1mTo5m = researchMoney.Where(m => m.ResearchMoney >= 1000000 && m.ResearchMoney <= 5000000);
                var between5mTo10m = researchMoney.Where(m => m.ResearchMoney >= 5000000 && m.ResearchMoney <= 10000000);
                var between10mTo20m = researchMoney.Where(m => m.ResearchMoney > 100000000 && m.ResearchMoney < 20000000);
                var over20m = researchMoney.Where(m => m.ResearchMoney > 20000000);

                //var researchMoneylower100k = researchMoney.Where(m => m.ResearchMoney < 100000 && m.ResearchMoney > 0).Distinct().OrderBy(a=>a.ResearchId);
                //var researchMoneybetween100kTo500kk = researchMoney.Where(m => m.ResearchMoney >= 500000 && m.ResearchMoney <= 1000000).Distinct().OrderBy(a => a.ResearchId);
                //var researchMoneybetween500kTo1m = researchMoney.Where(m => m.ResearchMoney > 5000000 && m.ResearchMoney < 100000000).Distinct().OrderBy(a => a.ResearchId);
                //var researchMoneybetween1mTo5m = researchMoney.Where(m => m.ResearchMoney >= 1000000 && m.ResearchMoney <= 5000000).Distinct().OrderBy(a => a.ResearchId);
                //var researchMoneybetween5mTo10m = researchMoney.Where(m => m.ResearchMoney >= 5000000 && m.ResearchMoney <= 10000000).Distinct().OrderBy(a => a.ResearchId);
                //var researchMoneybetween10mTo20m = researchMoney.Where(m => m.ResearchMoney > 100000000 && m.ResearchMoney < 20000000).Distinct().OrderBy(a => a.ResearchId);
                //var researchMoneyover20m = researchMoney.Where(m => m.ResearchMoney > 20000000).Distinct().OrderBy(a => a.ResearchId);
                var viewData = new List<ViewData> {
                    new ViewData
                    {
                        index = 0,
                        LisViewData = lower100k.ToList()
                    },
                    new ViewData
                    {
                        index = 1,
                        LisViewData = between100kTo500k.ToList()
                    },
                    new ViewData
                    {
                        index = 2,
                        LisViewData = between500kTo1m.ToList()
                    },
                    new ViewData
                    {
                        index = 3,
                        LisViewData = between1mTo5m.ToList()
                    },
                    new ViewData
                    {
                        index = 4,
                        LisViewData = between5mTo10m.ToList()
                    },
                    new ViewData
                    {
                        index = 5,
                        LisViewData = between10mTo20m.ToList()
                    },
                    new ViewData
                    {
                        index = 6,
                        LisViewData = over20m.ToList()
                    }
                };

                var graphDataSet = new GraphDataSet
                {

                    Data =
                     new List<int> {
                         lower100k.Count(),
                         between100kTo500k.Count(),
                         between500kTo1m.Count(),
                         between1mTo5m.Count(),
                         between5mTo10m.Count(),
                         between10mTo20m.Count(),
                         over20m.Count() }
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
                var list = new List<RankResearchMoneyViewModel>();

                    foreach(var aun in distinctResearchMoney)
                {
                    var model = new RankResearchMoneyViewModel
                    {
                        ResearchId = aun.ResearchId,
                        ResearchName = aun.ResearchNameTh,
                        ResearchMoney = researchMoney.Where(m => m.ResearchId == aun.ResearchId && m.ResearchNameTh == aun.ResearchNameTh).ToList()

                    };
                    list.Add(model);
                }      
                return list;
            }   

        }
    }
}
