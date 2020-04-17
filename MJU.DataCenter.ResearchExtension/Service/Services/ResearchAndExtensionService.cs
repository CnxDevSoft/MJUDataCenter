using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MJU.DataCenter.Personnel.ViewModels;
using MJU.DataCenter.ResearchExtension.Helper;
using MJU.DataCenter.ResearchExtension.Models;
using MJU.DataCenter.ResearchExtension.Repository.Interface;
using MJU.DataCenter.ResearchExtension.Service.Interface;
using MJU.DataCenter.ResearchExtension.ViewModels;

namespace MJU.DataCenter.ResearchExtension.Service.Services
{
    public class ResearchAndExtensionService : IResearchAndExtensionService
    {
        private readonly IDcResearchFacultyRepository _dcResearchFacultyRepository;
        private readonly IDcResearchGroupRepository _dcResearchGroupRepository;
        private readonly IDcResearchDataRepository _dcResearchDataRepository;
        private readonly IDcResearchMoneyRepository _dcResearchMoneyReoisitory;
        public ResearchAndExtensionService(IDcResearchGroupRepository dcResearchGroupRepository
            , IDcResearchDataRepository dcResearchDataRepository
            , IDcResearchMoneyRepository dcResearchMoneyRepository
            , IDcResearchFacultyRepository dcResearchFacultyRepository)
        {
            _dcResearchFacultyRepository = dcResearchFacultyRepository;
            _dcResearchGroupRepository = dcResearchGroupRepository;
            _dcResearchDataRepository = dcResearchDataRepository;
            _dcResearchMoneyReoisitory = dcResearchMoneyRepository;
            _dcResearchMoneyReoisitory = dcResearchMoneyRepository;

        }

        public object GetResearchDepartment(InputFilterGraphViewModel input, List<int> filter)
        {
            var startDate = input.StartDate.ToUtcDateTime();
            var endDate = input.EndDate.ToUtcDateTime();

            var researchDepartment = _dcResearchFacultyRepository.GetAll();

            if (filter.Any())
            {
                researchDepartment = researchDepartment.Where(x => filter.Contains(x.FacultyId.GetValueOrDefault()));
            }
            var distinctResearchDepartment = researchDepartment.Select(m => new { m.FacultyId, m.FacultyName }).Distinct().OrderBy(o => o.FacultyId);
            if (input.Type == 1)
            {
                var label = new List<string>();
                var data = new List<int>();
                var value = new List<int?>();
                var viewData = new List<ViewData>();
                var i = 0;
                foreach (var rd in distinctResearchDepartment)
                {
                    var researchDepartmentWithCondition = researchDepartment.Where(m => m.FacultyId == rd.FacultyId && m.FacultyName == rd.FacultyName
                    && (
                   input.StartDate != null && input.EndDate != null ? (m.ResearchStartDate >= startDate && m.ResearchEndDate <= endDate) ||
                    (m.ResearchStartDate >= startDate && m.ResearchStartDate <= endDate) : true
                    )).ToList();

                    label.Add(rd.FacultyName);
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
                var researchDepartmentWithDate = researchDepartment.Where(m => input.StartDate != null && input.EndDate != null ? (m.ResearchStartDate >= startDate && m.ResearchEndDate <= endDate) ||
                (m.ResearchStartDate >= startDate && m.ResearchStartDate <= endDate) : true).ToList();
                var list = new List<ResearchFacultyDataTableModel>();
                foreach (var rd in distinctResearchDepartment)
                {
                    var model = new ResearchFacultyDataTableModel
                    {
                        FacultyId = rd.FacultyId,
                        FacultyName = rd.FacultyName,
                        ResearchData = researchDepartment.Where(m => m.FacultyId == rd.FacultyId && m.FacultyName == rd.FacultyName).Count()
                    };
                    list.Add(model);
                }
                return list;
            }
        }

        public List<ResearchFacultyDataSourceModel> GetResearchFacultyDataSource(InputFilterDataSourceViewModel input, List<int> filter)
        {
            var startDate = input.StartDate.ToUtcDateTime();
            var endDate = input.EndDate.ToUtcDateTime();
            var researchDepartment = _dcResearchFacultyRepository.GetAll().Where(m => !string.IsNullOrEmpty(input.Type) ? m.FacultyName == input.Type : true);
            if (filter.Any())
            {
                researchDepartment = researchDepartment.Where(x => filter.Contains(x.FacultyId.GetValueOrDefault()));
            }
            var distinctResearchDepartment = researchDepartment.Select(m => new { m.FacultyId, m.FacultyName }).Distinct().OrderBy(o => o.FacultyId);

            var researchDepartmentWithDate = researchDepartment.Where(m => input.StartDate != null && input.EndDate != null ? (m.ResearchStartDate >= startDate && m.ResearchEndDate <= endDate) ||
            (m.ResearchStartDate >= startDate && m.ResearchStartDate <= endDate) : true).ToList();
            var list = new List<ResearchFacultyDataSourceModel>();
            foreach (var rd in distinctResearchDepartment)
            {
                var model = new ResearchFacultyDataSourceModel
                {
                    FacultyId = rd.FacultyId,
                    FacultyName = rd.FacultyName,
                    ResearchData = researchDepartment.Where(m => m.FacultyId == rd.FacultyId && m.FacultyName == rd.FacultyName).ToList()
                };
                list.Add(model);
            }
            return list;

        }

        public object GetResearchGroup(InputFilterGraphViewModel input, List<int> filter)
        {
            var startDate = input.StartDate.ToUtcDateTime();
            var endDate = input.EndDate.ToUtcDateTime();
            var researchGroup = _dcResearchGroupRepository.GetAll();
            if (filter.Any())
            {
                researchGroup = researchGroup.Where(x => filter.Contains(x.FacultyId.GetValueOrDefault()));
            }
            var distinctResearchGroup = researchGroup.Select(m => new { m.PersonGroupId, m.PersonGroupName }).Distinct().OrderBy(o => o.PersonGroupId);
            if (input.Type == 1)
            {
                var label = new List<string>();
                var data = new List<int>();
                var value = new List<int?>();
                var viewData = new List<ViewData>();
                var i = 0;
                foreach (var rg in distinctResearchGroup)
                {
                    var researchGroupWithCondition = researchGroup.Where(m => m.PersonGroupId == rg.PersonGroupId && m.PersonGroupName == rg.PersonGroupName
                    && (input.StartDate != null && input.EndDate != null ? (m.ResearchStartDate >= startDate && m.ResearchEndDate <= endDate) ||
                (m.ResearchStartDate >= startDate && m.ResearchStartDate <= endDate) : true));

                    var distinctResearcherGroupWithResearchId = researchGroupWithCondition.Select(s => new { s.ResearchId, s.ResearchNameEn, s.ResearchNameTh }).Distinct();
                    var researchGroupViewDataModelList = new List<ResearchGroupViewDataModel>();
                    foreach (var researchData in distinctResearcherGroupWithResearchId)
                    {
                        var firstResearchGroups = researchGroupWithCondition.FirstOrDefault(m => m.ResearchId == researchData.ResearchId);
                        var researchGroups = researchGroupWithCondition.Where(m => m.ResearchId == researchData.ResearchId)
                           .Select(s => new ResearcherViewModel
                           {
                               ResearcherId = s.ResearchId,
                               ResearcherName = s.ResearcherName
                           }).ToList();
                        var researchDepartmentView = new ResearchGroupViewDataModel
                        {
                            ResearchId = firstResearchGroups.ResearchId,
                            ResearchCode = firstResearchGroups.ResearchCode,
                            ResearchNameEn = firstResearchGroups.ResearchNameEn,
                            ResearchNameTh = firstResearchGroups.ResearchNameTh,
                            ResearchStartDate = firstResearchGroups.ResearchStartDate,
                            ResearchEndDate = firstResearchGroups.ResearchEndDate,
                            PersonGroupId = firstResearchGroups.PersonGroupId,
                            PersonGroupName = firstResearchGroups.PersonGroupName,
                            Researcher = researchGroups
                        };
                        researchGroupViewDataModelList.Add(researchDepartmentView);
                    }


                    viewData.Add(
                        new ViewData
                        {
                            index = i,
                            LisViewData = researchGroupViewDataModelList.OrderByDescending(o => o.ResearchId)
                        }

                    );

                    label.Add(rg.PersonGroupName);
                    data.Add(researchGroupViewDataModelList.Count());
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
                var researchGroupWithDate = researchGroup.Where(m => input.StartDate != null && input.EndDate != null ? (m.ResearchStartDate >= startDate && m.ResearchEndDate <= endDate) ||
                (m.ResearchStartDate >= startDate && m.ResearchStartDate <= endDate) : true).ToList();
                var list = new List<ResearchGroupDataTableModel>();
                foreach (var rg in distinctResearchGroup)
                {
                    var model = new ResearchGroupDataTableModel
                    {
                        PersonGroupId = rg.PersonGroupId,
                        PersonGroupName = rg.PersonGroupName,
                        ResearchData = researchGroupWithDate.Where(m => m.PersonGroupId == rg.PersonGroupId && m.PersonGroupName == rg.PersonGroupName).Count()
                    };
                    list.Add(model);
                }
                return list;
            }
        }

        public List<ResearchGroupDataSourceModel> GetResearchGroupDataSource(InputFilterDataSourceViewModel input, List<int> filter)
        {
            var startDate = input.StartDate.ToUtcDateTime();
            var endDate = input.EndDate.ToUtcDateTime();
            var researchGroup = _dcResearchGroupRepository.GetAll().Where(s => !string.IsNullOrEmpty(input.Type) ? s.PersonGroupName == input.Type : true);
            if (filter.Any())
            {
                researchGroup = researchGroup.Where(x => filter.Contains(x.FacultyId.GetValueOrDefault()));
            }
            var distinctResearchGroup = researchGroup.Select(m => new { m.PersonGroupId, m.PersonGroupName }).Distinct().OrderBy(o => o.PersonGroupId);

            var researchGroupWithDate = researchGroup.Where(m => input.StartDate != null && input.EndDate != null ? (m.ResearchStartDate >= startDate && m.ResearchEndDate <= endDate) ||
            (m.ResearchStartDate >= startDate && m.ResearchStartDate <= endDate) : true).ToList();
            var list = new List<ResearchGroupDataSourceModel>();
            foreach (var rg in distinctResearchGroup)
            {
                var model = new ResearchGroupDataSourceModel
                {
                    PersonGroupId = rg.PersonGroupId,
                    PersonGroupName = rg.PersonGroupName,
                    ResearchData = researchGroupWithDate.Where(m => m.PersonGroupId == rg.PersonGroupId && m.PersonGroupName == rg.PersonGroupName).ToList()
                };
                list.Add(model);
            }
            return list;

        }

        public object GetResearchData(InputFilterGraphViewModel input, List<int> filter)
        {
            var startDate = input.StartDate.ToUtcDateTime();
            var endDate = input.EndDate.ToUtcDateTime();
            var researchData = _dcResearchDataRepository.GetAll();
            if (filter.Any())
            {
                researchData = researchData.Where(x => filter.Contains(x.FacultyId.GetValueOrDefault()));
            }
            var distinctResearchData = researchData.Select(m => new { m.ResearchMoneyTypeId, m.MoneyTypeName }).Distinct().OrderBy(o => o.ResearchMoneyTypeId);
            if (input.Type == 1)
            {
                var label = new List<string>();
                var data = new List<int>();
                var value = new List<int?>();
                var viewData = new List<ViewData>();
                var i = 0;
                foreach (var rd in distinctResearchData)
                {
                    var researchDepartmentWithCondition = researchData.Where(m => m.ResearchMoneyTypeId == rd.ResearchMoneyTypeId && m.MoneyTypeName == rd.MoneyTypeName && (input.StartDate != null && input.EndDate != null ? (m.ResearchStartDate >= startDate && m.ResearchEndDate <= endDate) ||
                (m.ResearchStartDate >= startDate && m.ResearchStartDate <= endDate) : true));
                    //value.Add(researchDepartmentWithCondition.Sum(s => s.ResearchMoney));
                    var researchDataWithCondition = researchDepartmentWithCondition.Select(a => new { a.ResearchId, a.ResearchNameTh, a.ResearchNameEn }).Distinct();
                    var researchDataList = new List<ResearchDataListViewModel>();
                    foreach (var dataResearch in researchDataWithCondition)
                    {
                        var firstResearchData = researchDepartmentWithCondition.FirstOrDefault(a => a.ResearchId == dataResearch.ResearchId);
                        var researcherDataSub = researchDepartmentWithCondition.Where(c => c.ResearchId == dataResearch.ResearchId)
                            .Select(g => new ResearcherData
                            {
                                ResearcherId = g.ResearcherId,
                                ResearcherName = g.ResearcherName
                            }).ToList();
                        var researchDataViewModel = new ResearchDataListViewModel
                        {
                            ResearchId = firstResearchData.ResearchId,
                            ResearchNameTh = firstResearchData.ResearchNameTh,
                            ResearchNameEn = firstResearchData.ResearchNameEn,
                            ResearchCode = firstResearchData.ResearchCode,
                            ResearchMoneyTypeId = firstResearchData.ResearchMoneyTypeId,
                            MoneyTypeName = firstResearchData.MoneyTypeName,
                            ResearchMoney = firstResearchData.ResearchMoney,
                            ResearchStartDate = firstResearchData.ResearchStartDate,
                            ResearchEndDate = firstResearchData.ResearchEndDate,
                            Researcher = researcherDataSub

                        };
                        researchDataList.Add(researchDataViewModel);
                    }
                    viewData.Add(
                            new ViewData
                            {
                                index = i,
                                LisViewData = researchDataList.Distinct().OrderByDescending(o => o.ResearchId).ToList()
                            }
                        );

                    label.Add(rd.MoneyTypeName);
                    data.Add(researchDataList.Count());
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
                var researchDateWithDate = researchData.Where(m => input.StartDate != null && input.EndDate != null ? (m.ResearchStartDate >= startDate && m.ResearchEndDate <= endDate) ||
                (m.ResearchStartDate >= startDate && m.ResearchStartDate <= endDate) : true).ToList();

                var list = new List<ResearchDataDataTableModel>();
                foreach (var rd in distinctResearchData)
                {
                    var model = new ResearchDataDataTableModel
                    {
                        MoneyTypeId = rd.ResearchMoneyTypeId,
                        MoneyTypeName = rd.MoneyTypeName,
                        ResearchData = researchDateWithDate.Where(m => m.ResearchMoneyTypeId == rd.ResearchMoneyTypeId && m.MoneyTypeName == rd.MoneyTypeName).Count()
                    };
                    list.Add(model);
                }
                return list;
            }
        }

        public List<ResearchDataDataSourceModel> GetResearchDataDataSource(InputFilterDataSourceViewModel input, List<int> filter)
        {
            var startDate = input.StartDate.ToUtcDateTime();
            var endDate = input.EndDate.ToUtcDateTime();
            var researchData = _dcResearchDataRepository.GetAll().Where(s => !string.IsNullOrEmpty(input.Type) ? s.MoneyTypeName == input.Type : true);
            if (filter.Any())
            {
                researchData = researchData.Where(x => filter.Contains(x.FacultyId.GetValueOrDefault()));
            }
            var distinctResearchData = researchData.Select(m => new { m.ResearchMoneyTypeId, m.MoneyTypeName }).Distinct().OrderBy(o => o.ResearchMoneyTypeId);

            var researchDateWithDate = researchData.Where(m => input.StartDate != null && input.EndDate != null ? (m.ResearchStartDate >= startDate && m.ResearchEndDate <= endDate) ||
            (m.ResearchStartDate >= startDate && m.ResearchStartDate <= endDate) : true).ToList();

            var list = new List<ResearchDataDataSourceModel>();
            foreach (var rd in distinctResearchData)
            {
                var model = new ResearchDataDataSourceModel
                {
                    MoneyTypeId = rd.ResearchMoneyTypeId,
                    MoneyTypeName = rd.MoneyTypeName,
                    ResearchData = researchDateWithDate.Where(m => m.ResearchMoneyTypeId == rd.ResearchMoneyTypeId && m.MoneyTypeName == rd.MoneyTypeName).ToList()
                };
                list.Add(model);
            }
            return list;
        }

        public object GetAllResearchMoney(InputFilterGraphViewModel input, List<int> filter)
        {
            var startDate = input.StartDate.ToUtcDateTime();
            var endDate = input.EndDate.ToUtcDateTime();
            var researchMoney = _dcResearchMoneyReoisitory.GetAll().Where(m => input.StartDate != null && input.EndDate != null ? (m.ResearchStartDate >= startDate && m.ResearchEndDate <= endDate) ||
                (m.ResearchStartDate >= startDate && m.ResearchStartDate <= endDate) : true);
            if (filter.Any())
            {
                researchMoney = researchMoney.Where(x => filter.Contains(x.FacultyId.GetValueOrDefault()));
            }
            var distinctResearchMoney = researchMoney.Select(m => new { m.ResearchId, m.ResearchNameTh }).Distinct().OrderBy(o => o.ResearchId);
            if (input.Type == 1)
            {
                var list = new List<GraphDataSet>();
                var data = new List<int>();

                var label = new List<string> { "ตํ่ากว่า 100,000", "100,001 - 500,000","500,001 - 1,000,000"
                     ,"1,000,001 - 5,000,000","5,000,001 - 10,000,000","10,000,001 - 20,000,000","20,000,000 ขึ้นไป"
                };

                var lower100k = GetResearchMoneyViewDataModel(researchMoney.Where(m => m.ResearchMoney < 100000 && m.ResearchMoney > 0).ToList());
                var between100kTo500k = GetResearchMoneyViewDataModel(researchMoney.Where(m => m.ResearchMoney >= 100000 && m.ResearchMoney <= 500000).ToList());
                var between500kTo1m = GetResearchMoneyViewDataModel(researchMoney.Where(m => m.ResearchMoney >= 500000 && m.ResearchMoney <= 1000000).ToList());
                var between1mTo5m = GetResearchMoneyViewDataModel(researchMoney.Where(m => m.ResearchMoney >= 1000000 && m.ResearchMoney <= 5000000).ToList());
                var between5mTo10m = GetResearchMoneyViewDataModel(researchMoney.Where(m => m.ResearchMoney >= 5000000 && m.ResearchMoney <= 10000000).ToList());
                var between10mTo20m = GetResearchMoneyViewDataModel(researchMoney.Where(m => m.ResearchMoney > 100000000 && m.ResearchMoney < 20000000).ToList());
                var over20m = GetResearchMoneyViewDataModel(researchMoney.Where(m => m.ResearchMoney > 20000000).ToList());



                var viewData = new List<ViewData> {
                    new ViewData
                    {
                        index = 0,
                        LisViewData = lower100k
                    },
                    new ViewData
                    {
                        index = 1,
                        LisViewData = between100kTo500k
                    },
                    new ViewData
                    {
                        index = 2,
                        LisViewData = between500kTo1m
                    },
                    new ViewData
                    {
                        index = 3,
                        LisViewData = between1mTo5m
                    },
                    new ViewData
                    {
                        index = 4,
                        LisViewData = between5mTo10m
                    },
                    new ViewData
                    {
                        index = 5,
                        LisViewData = between10mTo20m
                    },
                    new ViewData
                    {
                        index = 6,
                        LisViewData = over20m
                    }
                };

                var graphDataSet = new GraphDataSet
                {

                    Data =
                     new List<int> {
                         lower100k.Count,
                         between100kTo500k.Count,
                         between500kTo1m.Count,
                         between1mTo5m.Count,
                         between5mTo10m.Count,
                         between10mTo20m.Count,
                         over20m.Count }
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
                var list = new List<RankResearchMoneyDataTableModel>();

                foreach (var aun in distinctResearchMoney)
                {
                    var model = new RankResearchMoneyDataTableModel
                    {
                        ResearchId = aun.ResearchId,
                        ResearchName = aun.ResearchNameTh,
                        ResearchMoney = researchMoney.Where(m => m.ResearchId == aun.ResearchId && m.ResearchNameTh == aun.ResearchNameTh).Count()

                    };
                    list.Add(model);
                }
                return list;
            }

        }

        public List<RankResearchRageMoneyDataSourceModel> GetAllResearchMoneyDataSource(InputFilterDataSourceViewModel input, List<int> filter)
        {
            var startDate = input.StartDate.ToUtcDateTime();
            var endDate = input.EndDate.ToUtcDateTime();
            var researchMoney = _dcResearchMoneyReoisitory.GetAll().Where(m => input.StartDate != null && input.EndDate != null ? (m.ResearchStartDate >= startDate && m.ResearchEndDate <= endDate) ||
                (m.ResearchStartDate >= startDate && m.ResearchStartDate <= endDate) : true);
            if (filter.Any())
            {
                researchMoney = researchMoney.Where(x => filter.Contains(x.FacultyId.GetValueOrDefault()));
            }
            var distinctResearchMoney = researchMoney.Select(m => new { m.ResearchId, m.ResearchNameTh }).Distinct().OrderBy(o => o.ResearchId);
            var result = new List<RankResearchRageMoneyDataSourceModel>();
            if(input.Type == null || input.Type == "0")
            {
                var Lower100k = researchMoney.Where(m => m.ResearchMoney < 100000 && m.ResearchMoney > 0).Select(s => new DataModelReserachMoney
                {
                    ResearchId = s.ResearchId,
                    ResearchCode = s.ResearchCode,
                    ResearchNameEn = s.ResearchNameEn,
                    ResearchNameTh = s.ResearchNameTh,
                    ResearchStartDate = s.ResearchStartDate,
                    ResearchEndDate = s.ResearchEndDate,
                    ResearchMoney = s.ResearchMoney,
                    MoneyTypeName = s.MoneyTypeName,
                    ResearcherId = s.ResearcherId,
                    ResearcherName = s.ResearcherName
                }).OrderBy(o => o.ResearchId).ToList();
                var modelLower100k = new RankResearchRageMoneyDataSourceModel
                {
                    ResearchRankMoneyName = "งบประมาณ ตํ่ากว่า 100,000",
                    DataResearchMoney = Lower100k
                };
                result.Add(modelLower100k);
            }
            if (input.Type == null || input.Type == "1")
            {
                var between100kTo500k = researchMoney.Where(m => m.ResearchMoney >= 100000 && m.ResearchMoney <= 500000).Select(s => new DataModelReserachMoney
                {
                    ResearchId = s.ResearchId,
                    ResearchCode = s.ResearchCode,
                    ResearchNameEn = s.ResearchNameEn,
                    ResearchNameTh = s.ResearchNameTh,
                    ResearchStartDate = s.ResearchStartDate,
                    ResearchEndDate = s.ResearchEndDate,
                    ResearchMoney = s.ResearchMoney,
                    MoneyTypeName = s.MoneyTypeName,
                    ResearcherId = s.ResearcherId,
                    ResearcherName = s.ResearcherName
                }).OrderBy(o => o.ResearchId).ToList();
                var modelBetween100kTo500k = new RankResearchRageMoneyDataSourceModel
                {
                    ResearchRankMoneyName = "งบประมาณ 100,001 - 500,000",
                    DataResearchMoney = between100kTo500k
                };
                result.Add(modelBetween100kTo500k);
            }
            if (input.Type == null || input.Type == "2")
            {
                var between500kTo1m = researchMoney.Where(m => m.ResearchMoney >= 500000 && m.ResearchMoney <= 1000000).Select(s => new DataModelReserachMoney
                {
                    ResearchId = s.ResearchId,
                    ResearchCode = s.ResearchCode,
                    ResearchNameEn = s.ResearchNameEn,
                    ResearchNameTh = s.ResearchNameTh,
                    ResearchStartDate = s.ResearchStartDate,
                    ResearchEndDate = s.ResearchEndDate,
                    ResearchMoney = s.ResearchMoney,
                    MoneyTypeName = s.MoneyTypeName,
                    ResearcherId = s.ResearcherId,
                    ResearcherName = s.ResearcherName
                }).OrderBy(o => o.ResearchId).ToList();
                var modelbetween500kTo1m = new RankResearchRageMoneyDataSourceModel
                {
                    ResearchRankMoneyName = "งบประมาณ 500,001 - 1,000,000",
                    DataResearchMoney = between500kTo1m
                };
                result.Add(modelbetween500kTo1m);
            }
            if (input.Type == null || input.Type == "3")
            {

                var between1mTo5m = researchMoney.Where(m => m.ResearchMoney >= 1000000 && m.ResearchMoney <= 5000000).Select(s => new DataModelReserachMoney
                {
                    ResearchId = s.ResearchId,
                    ResearchCode = s.ResearchCode,
                    ResearchNameEn = s.ResearchNameEn,
                    ResearchNameTh = s.ResearchNameTh,
                    ResearchStartDate = s.ResearchStartDate,
                    ResearchEndDate = s.ResearchEndDate,
                    ResearchMoney = s.ResearchMoney,
                    MoneyTypeName = s.MoneyTypeName,
                    ResearcherId = s.ResearcherId,
                    ResearcherName = s.ResearcherName
                }).OrderBy(o => o.ResearchId).ToList();
                var modelbetween1mTo5m = new RankResearchRageMoneyDataSourceModel
                {
                    ResearchRankMoneyName = "งบประมาณ 1,000,001 - 5,000,000",
                    DataResearchMoney = between1mTo5m
                };
                result.Add(modelbetween1mTo5m);
            }
            if (input.Type == null || input.Type == "4")
            {
                var between5mTo10m = researchMoney.Where(m => m.ResearchMoney >= 5000000 && m.ResearchMoney <= 10000000).Select(s => new DataModelReserachMoney
                {
                    ResearchId = s.ResearchId,
                    ResearchCode = s.ResearchCode,
                    ResearchNameEn = s.ResearchNameEn,
                    ResearchNameTh = s.ResearchNameTh,
                    ResearchStartDate = s.ResearchStartDate,
                    ResearchEndDate = s.ResearchEndDate,
                    ResearchMoney = s.ResearchMoney,
                    MoneyTypeName = s.MoneyTypeName,
                    ResearcherId = s.ResearcherId,
                    ResearcherName = s.ResearcherName
                }).OrderBy(o => o.ResearchId).ToList();
                var modelbetween5mTo10m = new RankResearchRageMoneyDataSourceModel
                {
                    ResearchRankMoneyName = "งบประมาณ 5,000,001 - 10,000,000",
                    DataResearchMoney = between5mTo10m
                };
                result.Add(modelbetween5mTo10m);
            }
            if (input.Type == null || input.Type == "5")
            {
                var between10mTo20m = researchMoney.Where(m => m.ResearchMoney > 100000000 && m.ResearchMoney < 20000000).Select(s => new DataModelReserachMoney
                {
                    ResearchId = s.ResearchId,
                    ResearchCode = s.ResearchCode,
                    ResearchNameEn = s.ResearchNameEn,
                    ResearchNameTh = s.ResearchNameTh,
                    ResearchStartDate = s.ResearchStartDate,
                    ResearchEndDate = s.ResearchEndDate,
                    ResearchMoney = s.ResearchMoney,
                    MoneyTypeName = s.MoneyTypeName,
                    ResearcherId = s.ResearcherId,
                    ResearcherName = s.ResearcherName
                }).OrderBy(o => o.ResearchId).ToList();
                var modelbetween10mTo20m = new RankResearchRageMoneyDataSourceModel
                {
                    ResearchRankMoneyName = "งบประมาณ 10,000,001 - 20,000,000",
                    DataResearchMoney = between10mTo20m
                };
                result.Add(modelbetween10mTo20m);
            }

            if (input.Type == null || input.Type == "6")
            {
                var over20m = researchMoney.Where(m => m.ResearchMoney > 20000000).Select(s => new DataModelReserachMoney
                {
                    ResearchId = s.ResearchId,
                    ResearchCode = s.ResearchCode,
                    ResearchNameEn = s.ResearchNameEn,
                    ResearchNameTh = s.ResearchNameTh,
                    ResearchStartDate = s.ResearchStartDate,
                    ResearchEndDate = s.ResearchEndDate,
                    ResearchMoney = s.ResearchMoney,
                    MoneyTypeName = s.MoneyTypeName,
                    ResearcherId = s.ResearcherId,
                    ResearcherName = s.ResearcherName
                }).OrderBy(o => o.ResearchId).ToList();
                var modelover20m = new RankResearchRageMoneyDataSourceModel
                {
                    ResearchRankMoneyName = "งบประมาณ 20,000,000 ขึ้นไป",
                    DataResearchMoney = over20m
                };
                result.Add(modelover20m);

            }




            return result;


        }

        private List<ResearchMoneyViewDataModel> GetResearchMoneyViewDataModel(List<DcResearchMoney> researchMoneyData)
        {
            var distinctMoney = researchMoneyData.Select(s => new { s.ResearchId, s.ResearchNameEn, s.ResearchNameTh }).Distinct();
            var researchMoneyViewDataModelList = new List<ResearchMoneyViewDataModel>();
            foreach (var researchData in distinctMoney)
            {
                var firstResearchMoney = researchMoneyData.FirstOrDefault(m => m.ResearchId == researchData.ResearchId);
                var researchMoney = researchMoneyData.Where(m => m.ResearchId == researchData.ResearchId)
                   .Select(s => new ResearcherViewModel
                   {
                       ResearcherId = s.ResearchId,
                       ResearcherName = s.ResearcherName
                   }).ToList();
                var researchLowerMoneyData = new ResearchMoneyViewDataModel
                {
                    ResearchId = firstResearchMoney.ResearchId,
                    ResearchCode = firstResearchMoney.ResearchCode,
                    ResearchNameEn = firstResearchMoney.ResearchNameEn,
                    ResearchNameTh = firstResearchMoney.ResearchNameTh,
                    ResearchStartDate = firstResearchMoney.ResearchStartDate,
                    ResearchEndDate = firstResearchMoney.ResearchEndDate,
                    ResearchMoney = firstResearchMoney.ResearchMoney,
                    MoneyTypeName = firstResearchMoney.MoneyTypeName,
                    Researcher = researchMoney
                };
                researchMoneyViewDataModelList.Add(researchLowerMoneyData);
            }



            return researchMoneyViewDataModelList;
        }

        public List<ResearcherResearchDataModel> GetDcResearcherByName(ResearcherInputDto input, List<int> filter)
        {
            var researcher = _dcResearchFacultyRepository.GetAll();
            if (filter.Any())
            {
                researcher = researcher.Where(x => filter.Contains(x.FacultyId.GetValueOrDefault()));
            }
            var distinc = researcher.Where(m => !string.IsNullOrEmpty(input.FirstName) ? m.ResearcherName.Contains(input.FirstName) : true)
                .Where(m => !string.IsNullOrEmpty(input.LastName) ? m.ResearcherName.Contains(input.LastName) : true)
                .Where(m => !string.IsNullOrEmpty(input.FacultyName) ? m.FacultyName.Contains(input.FacultyName) : true)
                .Select(s => new { s.ResearcherId, s.ResearcherName, s.FacultyName, s.FacultyId, s.FacultyCode, s.CitizenId }).Distinct();

            return distinc.Select(s => new ResearcherResearchDataModel
            {
                ResearcherId = s.ResearcherId,
                ResearcherName = s.ResearcherName,
                DepartmentCode = s.FacultyCode,
                DepartmentId = s.FacultyId,
                DepartmentNameTh = s.FacultyName,
                CitizenId = s.CitizenId

            }).ToList();
        }

        public ResearcherDetailModel GetResearcherDetail(int researcherId)
        {
            var researchDistinct = _dcResearchDataRepository.GetAll().Where(m => m.ResearcherId == researcherId).Select(s => s.ResearchId).Distinct();
            var researchDepartment = _dcResearchFacultyRepository.GetAll().FirstOrDefault(m => m.ResearcherId == researcherId);
            var researchDataModels = new List<ResearchDataModel>();
            foreach (var researchId in researchDistinct)
            {
                var researchData = _dcResearchDataRepository.GetAll().FirstOrDefault(m => m.ResearcherId == researcherId);
                var researchGroupData = _dcResearchGroupRepository.GetAll().FirstOrDefault(m => m.ResearchId == researchId);
                var researchGroupList = _dcResearchGroupRepository.GetAll().Where(m => m.ResearchId == researchId)
                    .Select(s => new ResearcherGroupModel
                    {
                        ResearcherId = s.ResearcherId,
                        ReseacherName = s.ResearcherName,
                    }).ToList();

                var researchGroup = new ResearchGroupModel
                {
                    ResearchGroupId = researchGroupData.PersonGroupId,
                    ResearchGroupName = researchGroupData.PersonGroupName,
                    ResearcherGroup = researchGroupList
                };

                var research = _dcResearchMoneyReoisitory.GetAll().Where(m => m.ResearchId == researchId).Select(s => new ResearchMoneyModel
                {
                    ResearchMoney = s.ResearchMoney,
                    MoneyTypeName = s.MoneyTypeName
                }).ToList();

                var researchDataModel = new ResearchDataModel
                {
                    ResearchId = researchData.ResearchId,
                    ResearchNameTh = researchData.ResearchNameTh,
                    ResearchNameEn = researchData.ResearchNameEn,
                    ResearchMoney = research,
                    ResearchGroup = researchGroup,
                    ResearchStartDate = researchData.ResearchStartDate,
                    ResearchEndDate = researchData.ResearchEndDate
                };
                researchDataModels.Add(researchDataModel);
            }

            var researcherDetail = new ResearcherDetailModel
            {
                ResearcherId = researchDepartment.ResearcherId,
                ResearcherName = researchDepartment.ResearcherName,
                DepartmentiId = researchDepartment.FacultyId,
                DepartmentNameTh = researchDepartment.FacultyName,
                ResearchData = researchDataModels
            };



            return researcherDetail;
        }


        public PersonResearchDetailModel GetPersonResearchDetail(string citizenId)
        {
            var research = _dcResearchDataRepository.GetAll().Where(m => m.CitizenId == citizenId);
            var firstPerson = research.Select(s => new { s.ResearcherId, s.ResearcherName }).FirstOrDefault();
            var list = new List<PersonResearchDetail>();
            foreach (var re in research)
            {
                var personResearch = _dcResearchDataRepository.GetAll().Where(m => m.ResearchId == re.ResearchId && m.CitizenId == citizenId)
                    .Select(s => new PersonResearch
                    {
                        ResearcherName = s.ResearcherName
                    });
                var personResearchDetail = new PersonResearchDetail
                {
                    PersonResearcher = personResearch.ToList(),
                    ResearchId = re.ResearchId,
                    ResearchNameTh = re.ResearchNameTh,
                    ResearchNameEn = re.ResearchNameEn,
                    ResearchMoney = re.ResearchMoney,
                    MoneyTypeName = re.MoneyTypeName,
                    ResearchStartDate = re.ResearchStartDate,
                    ResearchEndDate = re.ResearchEndDate
                };
                list.Add(personResearchDetail);
            }
            var result = new PersonResearchDetailModel
            {
                ResearcherId = firstPerson.ResearcherId,
                ResearcherName = firstPerson.ResearcherName,
                PersonResearchDetail = list
            };
            return result;
        }



    }
}
