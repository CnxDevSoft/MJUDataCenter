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

        public object GetResearchFaculty(InputFilterGraphViewModel input, List<int> filter)
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
                var i = 0;
                foreach (var rd in distinctResearchDepartment)
                {
                    var researchDepartmentWithCondition = researchDepartment.Where(m => m.FacultyId == rd.FacultyId && m.FacultyName == rd.FacultyName
                    && (
                   input.StartDate != null && input.EndDate != null ? (m.ResearchStartDate >= startDate && m.ResearchEndDate <= endDate) ||
                    (m.ResearchStartDate >= startDate && m.ResearchStartDate <= endDate) : true
                    )).ToList();

                    label.Add(rd.FacultyName);
                    data.Add(researchDepartmentWithCondition.Select(s => s.ResearchId).Distinct().Count());
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
                        ResearchData = researchDepartment.Where(m => m.FacultyId == rd.FacultyId && m.FacultyName == rd.FacultyName).Select(s => s.ResearchId).Distinct().Count()
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
                var researchDepartmentWithDateCondition = researchDepartmentWithDate.Where(m => m.FacultyId == rd.FacultyId && m.FacultyName == rd.FacultyName);
                var distinctResearcherDepartmentWithResearchId = researchDepartmentWithDateCondition.Select(s => new { s.ResearchId, s.ResearchNameEn, s.ResearchNameTh }).Distinct();
                var researchDepartmentViewDataModelList = new List<ResearchFacultyViewDataModel>();
                foreach (var researchData in distinctResearcherDepartmentWithResearchId)
                {
                    var firstResearchDepartments = researchDepartmentWithDateCondition.FirstOrDefault(m => m.ResearchId == researchData.ResearchId);
                    var researchDepartments = researchDepartmentWithDateCondition.Where(m => m.ResearchId == researchData.ResearchId)
                       .Select(s => new ResearcherViewModel
                       {
                           ResearcherId = s.ResearcherId,
                           ResearcherName = s.ResearcherName,
                           CitizenId = s.CitizenId
                       }).ToList();
                    var researchDepartmentView = new ResearchFacultyViewDataModel
                    {
                        ResearchId = firstResearchDepartments.ResearchId,
                        ResearchCode = firstResearchDepartments.ResearchCode,
                        ResearchNameEn = firstResearchDepartments.ResearchNameEn,
                        ResearchNameTh = firstResearchDepartments.ResearchNameTh,
                        ResearchStartDate = firstResearchDepartments.ResearchStartDate,
                        ResearchEndDate = firstResearchDepartments.ResearchEndDate,
                        FacultyCode = firstResearchDepartments.FacultyCode,
                        FacultyId = firstResearchDepartments.FacultyId,
                        FacultyName = firstResearchDepartments.FacultyName,
                        Researcher = researchDepartments
                    };
                    researchDepartmentViewDataModelList.Add(researchDepartmentView);
                }
                var model = new ResearchFacultyDataSourceModel
                {
                    FacultyId = rd.FacultyId,
                    FacultyName = rd.FacultyName,
                    ResearchData = researchDepartmentViewDataModelList
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
                var i = 0;
                foreach (var rg in distinctResearchGroup)
                {
                    var researchGroupWithCondition = researchGroup.Where(m => m.PersonGroupId == rg.PersonGroupId && m.PersonGroupName == rg.PersonGroupName
                    && (input.StartDate != null && input.EndDate != null ? (m.ResearchStartDate >= startDate && m.ResearchEndDate <= endDate) ||
                (m.ResearchStartDate >= startDate && m.ResearchStartDate <= endDate) : true));
                    label.Add(rg.PersonGroupName);
                    data.Add(researchGroupWithCondition.Select(s => s.ResearchId).Distinct().Count());
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
                        ResearchData = researchGroupWithDate.Where(m => m.PersonGroupId == rg.PersonGroupId && m.PersonGroupName == rg.PersonGroupName).Select(s => s.ResearchId).Distinct().Count()
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

            var list = new List<ResearchGroupDataSourceModel>();

            foreach (var rg in distinctResearchGroup)
            {

                var researchGroupWithDate = researchGroup.Where(m => input.StartDate != null && input.EndDate != null ?
                (m.ResearchStartDate >= startDate && m.ResearchEndDate <= endDate) ||
(m.ResearchStartDate >= startDate && m.ResearchStartDate <= endDate) : true).Where(m =>
m.PersonGroupId == rg.PersonGroupId && m.PersonGroupName == rg.PersonGroupName).ToList();
                var distinctResearcherGroupWithResearchId = researchGroupWithDate.Select(s => new { s.ResearchId, s.ResearchNameEn, s.ResearchNameTh }).Distinct();
                var researchGroupViewDataModelList = new List<ResearchGroupViewDataModel>();
                foreach (var researchData in distinctResearcherGroupWithResearchId)
                {
                    var firstResearchGroups = researchGroupWithDate.FirstOrDefault(m => m.ResearchId == researchData.ResearchId);
                    var researchGroups = researchGroupWithDate.Where(m => m.ResearchId == researchData.ResearchId)
                       .Select(s => new ResearcherViewModel
                       {
                           ResearcherId = s.ResearchId,
                           ResearcherName = s.ResearcherName,
                           CitizenId = s.CitizenId
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
                var model = new ResearchGroupDataSourceModel
                {
                    PersonGroupId = rg.PersonGroupId,
                    PersonGroupName = rg.PersonGroupName,
                    ResearchData = researchGroupViewDataModelList
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
                var i = 0;
                foreach (var rd in distinctResearchData)
                {
                    var researchDepartmentWithCondition = researchData.Where(m => m.ResearchMoneyTypeId == rd.ResearchMoneyTypeId && m.MoneyTypeName == rd.MoneyTypeName && (input.StartDate != null && input.EndDate != null ? (m.ResearchStartDate >= startDate && m.ResearchEndDate <= endDate) ||
                (m.ResearchStartDate >= startDate && m.ResearchStartDate <= endDate) : true));
                    var researchDataWithCondition = researchDepartmentWithCondition.Select(a => new { a.ResearchId, a.ResearchNameTh, a.ResearchNameEn }).Distinct();


                    label.Add(rd.MoneyTypeName);
                    data.Add(researchDataWithCondition.Count());
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
                    Value = value

                };
                return result;

            }
            else
            {
                var researchDateWithDate = researchData.Where(m => input.StartDate != null && input.EndDate != null ? (m.ResearchStartDate >= startDate && m.ResearchEndDate <= endDate) ||
                (m.ResearchStartDate >= startDate && m.ResearchStartDate <= endDate) : true).ToList();
                var researchDataWithCondition = researchDateWithDate.Select(a => new { a.ResearchId, a.ResearchNameTh, a.ResearchNameEn }).Distinct();
                var list = new List<ResearchDataDataTableModel>();
                foreach (var rd in distinctResearchData)
                {
                    var model = new ResearchDataDataTableModel
                    {
                        MoneyTypeId = rd.ResearchMoneyTypeId,
                        MoneyTypeName = rd.MoneyTypeName,
                        ResearchData = researchDataWithCondition.Count()
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
                var researchDataWithCondition = researchDateWithDate.Select(a => new { a.ResearchId, a.ResearchNameTh, a.ResearchNameEn }).Distinct();
                var researchDataList = new List<ResearchDataListViewModel>();
                foreach (var dataResearch in researchDataWithCondition)
                {
                    var firstResearchData = researchDateWithDate.FirstOrDefault(a => a.ResearchId == dataResearch.ResearchId);
                    var researcherDataSub = researchDateWithDate.Where(c => c.ResearchId == dataResearch.ResearchId)
                        .Select(g => new ResearcherData
                        {
                            ResearcherId = g.ResearcherId,
                            ResearcherName = g.ResearcherName,
                            CitizenId = g.CitizenId
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
                var model = new ResearchDataDataSourceModel
                {
                    MoneyTypeId = rd.ResearchMoneyTypeId,
                    MoneyTypeName = rd.MoneyTypeName,
                    ResearchData = researchDataList
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
                var between100kTo500k = GetResearchMoneyViewDataModel(researchMoney.Where(m => m.ResearchMoney >= 100000 && m.ResearchMoney <= 500000).ToList()).Select(s => s.ResearchId).Distinct();
                var between500kTo1m = GetResearchMoneyViewDataModel(researchMoney.Where(m => m.ResearchMoney >= 500000 && m.ResearchMoney <= 1000000).ToList()).Select(s => s.ResearchId).Distinct();
                var between1mTo5m = GetResearchMoneyViewDataModel(researchMoney.Where(m => m.ResearchMoney >= 1000000 && m.ResearchMoney <= 5000000).ToList()).Select(s => s.ResearchId).Distinct();
                var between5mTo10m = GetResearchMoneyViewDataModel(researchMoney.Where(m => m.ResearchMoney >= 5000000 && m.ResearchMoney <= 10000000).ToList()).Select(s => s.ResearchId).Distinct();
                var between10mTo20m = GetResearchMoneyViewDataModel(researchMoney.Where(m => m.ResearchMoney > 100000000 && m.ResearchMoney < 20000000).ToList()).Select(s => s.ResearchId).Distinct();
                var over20m = GetResearchMoneyViewDataModel(researchMoney.Where(m => m.ResearchMoney > 20000000).ToList());

                var graphDataSet = new GraphDataSet
                {

                    Data =
                     new List<int> {
                         lower100k.Count,
                         between100kTo500k.Count(),
                         between500kTo1m.Count(),
                         between1mTo5m.Count(),
                         between5mTo10m.Count(),
                         between10mTo20m.Count(),
                         over20m.Count }
                };

                var result = new GraphData
                {
                    GraphDataSet = new List<GraphDataSet> {
                     graphDataSet
                    },
                    Label = label,
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

        public List<ResearchMoneyRangeViewDataModel> GetAllResearchMoneyDataSource(InputFilterDataSourceViewModel input, List<int> filter)
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
            var list = new List<ResearchMoneyRangeViewDataModel>();
            var result = new List<RankResearchRageMoneyDataSourceModel>();
            if (input.Type == null || input.Type == "0")
            {
                var lower100k = researchMoney.Where(m => m.ResearchMoney < 100000 && m.ResearchMoney > 0);
                var lower100kDistinct = lower100k.Select(s =>new { s.ResearchId,s.ResearchNameTh}).Distinct();
                var researchDataList100k = new List<DataModelReserachMoney>();
                foreach (var ld in lower100kDistinct)
                {
                    var firstLower100k = lower100k.FirstOrDefault(m => m.ResearchId == ld.ResearchId && m.ResearchNameTh == ld.ResearchNameTh);
                    var researcherDataSub = lower100k.Where(c => c.ResearchId == ld.ResearchId && c.ResearchNameTh == ld.ResearchNameTh)
                        .Select(g => new ResearcherData
                        {
                            ResearcherId = g.ResearcherId,
                            ResearcherName = g.ResearcherName,
                            CitizenId = g.CitizenId
                        }).ToList();
                    var researchDataViewModel = new DataModelReserachMoney
                    {
                        ResearchId = firstLower100k.ResearchId,
                        ResearchNameTh = firstLower100k.ResearchNameTh,
                        ResearchNameEn = firstLower100k.ResearchNameEn,
                        ResearchCode = firstLower100k.ResearchCode,
                        MoneyTypeName = firstLower100k.MoneyTypeName,
                        ResearchMoney = firstLower100k.ResearchMoney,
                        ResearchStartDate = firstLower100k.ResearchStartDate,
                        ResearchEndDate = firstLower100k.ResearchEndDate,
                        Researcher = researcherDataSub

                    };
                    researchDataList100k.Add(researchDataViewModel);
                }
                var modelLower100k = new RankResearchRageMoneyDataSourceModel
                {
                    ResearchRankMoneyName = "งบประมาณ ตํ่ากว่า 100,000",
                    ResearchData = researchDataList100k
                };
                result.Add(modelLower100k);
            }
            if (input.Type == null || input.Type == "1")
            {
                var between100kTo500k = researchMoney.Where(m => m.ResearchMoney >= 100000 && m.ResearchMoney <= 500000);
                var between100kTo500kDistinct = between100kTo500k.Select(s => new { s.ResearchId, s.ResearchNameTh }).Distinct();
                var researchDataListBetween100kTo500k = new List<DataModelReserachMoney>();
                foreach (var ld in between100kTo500kDistinct)
                {
                    var firstBetween100kTo500k = between100kTo500k.FirstOrDefault(m => m.ResearchId == ld.ResearchId && m.ResearchNameTh == ld.ResearchNameTh);
                    var researcherDataSub = between100kTo500k.Where(c => c.ResearchId == ld.ResearchId && c.ResearchNameTh == ld.ResearchNameTh)
                        .Select(g => new ResearcherData
                        {
                            ResearcherId = g.ResearcherId,
                            ResearcherName = g.ResearcherName,
                            CitizenId = g.CitizenId
                        }).ToList();
                    var researchDataViewModel = new DataModelReserachMoney
                    {
                        ResearchId = firstBetween100kTo500k.ResearchId,
                        ResearchNameTh = firstBetween100kTo500k.ResearchNameTh,
                        ResearchNameEn = firstBetween100kTo500k.ResearchNameEn,
                        ResearchCode = firstBetween100kTo500k.ResearchCode,
                        MoneyTypeName = firstBetween100kTo500k.MoneyTypeName,
                        ResearchMoney = firstBetween100kTo500k.ResearchMoney,
                        ResearchStartDate = firstBetween100kTo500k.ResearchStartDate,
                        ResearchEndDate = firstBetween100kTo500k.ResearchEndDate,
                        Researcher = researcherDataSub

                    };
                    researchDataListBetween100kTo500k.Add(researchDataViewModel);
                }
                var modelBetween100kTo500k = new RankResearchRageMoneyDataSourceModel
                {
                    ResearchRankMoneyName = "งบประมาณ 100,001 - 500,000",
                    ResearchData = researchDataListBetween100kTo500k
                };
                result.Add(modelBetween100kTo500k);
            }
            if (input.Type == null || input.Type == "2")
            {
                var between500kTo1m = researchMoney.Where(m => m.ResearchMoney >= 500000 && m.ResearchMoney <= 1000000);
                var between500kTo1mDistinct = between500kTo1m.Select(s => new { s.ResearchId, s.ResearchNameTh }).Distinct();
                var researchDataListBetween500kTo1m = new List<DataModelReserachMoney>();
                foreach (var ld in between500kTo1mDistinct)
                {
                    var firstBetween500kTo1m = between500kTo1m.FirstOrDefault(m => m.ResearchId == ld.ResearchId && m.ResearchNameTh == ld.ResearchNameTh);
                    var researcherDataSub = between500kTo1m.Where(c => c.ResearchId == ld.ResearchId && c.ResearchNameTh == ld.ResearchNameTh)
                        .Select(g => new ResearcherData
                        {
                            ResearcherId = g.ResearcherId,
                            ResearcherName = g.ResearcherName,
                            CitizenId = g.CitizenId
                        }).ToList();
                    var researchDataViewModel = new DataModelReserachMoney
                    {
                        ResearchId = firstBetween500kTo1m.ResearchId,
                        ResearchNameTh = firstBetween500kTo1m.ResearchNameTh,
                        ResearchNameEn = firstBetween500kTo1m.ResearchNameEn,
                        ResearchCode = firstBetween500kTo1m.ResearchCode,
                        MoneyTypeName = firstBetween500kTo1m.MoneyTypeName,
                        ResearchMoney = firstBetween500kTo1m.ResearchMoney,
                        ResearchStartDate = firstBetween500kTo1m.ResearchStartDate,
                        ResearchEndDate = firstBetween500kTo1m.ResearchEndDate,
                        Researcher = researcherDataSub

                    };
                    researchDataListBetween500kTo1m.Add(researchDataViewModel);
                }
                var modelbetween500kTo1m = new RankResearchRageMoneyDataSourceModel
                {
                    ResearchRankMoneyName = "งบประมาณ 500,001 - 1,000,000",
                    ResearchData = researchDataListBetween500kTo1m
                };
                result.Add(modelbetween500kTo1m);
            }
            if (input.Type == null || input.Type == "3")
            {

                var between1mTo5m = researchMoney.Where(m => m.ResearchMoney >= 1000000 && m.ResearchMoney <= 5000000);
                var between1mTo5mDistinct = between1mTo5m.Select(s => new { s.ResearchId, s.ResearchNameTh }).Distinct();
                var researchDataListBetween1mTo5m = new List<DataModelReserachMoney>();
                foreach (var ld in between1mTo5mDistinct)
                {
                    var firstBetween1mTo5m = between1mTo5m.FirstOrDefault(m => m.ResearchId == ld.ResearchId && m.ResearchNameTh == ld.ResearchNameTh);
                    var researcherDataSub = between1mTo5m.Where(c => c.ResearchId == ld.ResearchId && c.ResearchNameTh == ld.ResearchNameTh)
                        .Select(g => new ResearcherData
                        {
                            ResearcherId = g.ResearcherId,
                            ResearcherName = g.ResearcherName,
                            CitizenId = g.CitizenId
                        }).ToList();
                    var researchDataViewModel = new DataModelReserachMoney
                    {
                        ResearchId = firstBetween1mTo5m.ResearchId,
                        ResearchNameTh = firstBetween1mTo5m.ResearchNameTh,
                        ResearchNameEn = firstBetween1mTo5m.ResearchNameEn,
                        ResearchCode = firstBetween1mTo5m.ResearchCode,
                        MoneyTypeName = firstBetween1mTo5m.MoneyTypeName,
                        ResearchMoney = firstBetween1mTo5m.ResearchMoney,
                        ResearchStartDate = firstBetween1mTo5m.ResearchStartDate,
                        ResearchEndDate = firstBetween1mTo5m.ResearchEndDate,
                        Researcher = researcherDataSub

                    };
                    researchDataListBetween1mTo5m.Add(researchDataViewModel);
                }
                var modelbetween1mTo5m = new RankResearchRageMoneyDataSourceModel
                {
                    ResearchRankMoneyName = "งบประมาณ 1,000,001 - 5,000,000",
                    ResearchData = researchDataListBetween1mTo5m
                };
                result.Add(modelbetween1mTo5m);
            }
            if (input.Type == null || input.Type == "4")
            {
                var between5mTo10m = researchMoney.Where(m => m.ResearchMoney >= 5000000 && m.ResearchMoney <= 10000000);
                var between5mTo10mDistinct = between5mTo10m.Select(s => new { s.ResearchId, s.ResearchNameTh }).Distinct();
                var researchDataListBetween5mTo10m = new List<DataModelReserachMoney>();
                foreach (var ld in between5mTo10mDistinct)
                {
                    var firstBetween5mTo10m = between5mTo10m.FirstOrDefault(m => m.ResearchId == ld.ResearchId && m.ResearchNameTh == ld.ResearchNameTh);
                    var researcherDataSub = between5mTo10m.Where(c => c.ResearchId == ld.ResearchId && c.ResearchNameTh == ld.ResearchNameTh)
                        .Select(g => new ResearcherData
                        {
                            ResearcherId = g.ResearcherId,
                            ResearcherName = g.ResearcherName,
                            CitizenId = g.CitizenId
                        }).ToList();
                    var researchDataViewModel = new DataModelReserachMoney
                    {
                        ResearchId = firstBetween5mTo10m.ResearchId,
                        ResearchNameTh = firstBetween5mTo10m.ResearchNameTh,
                        ResearchNameEn = firstBetween5mTo10m.ResearchNameEn,
                        ResearchCode = firstBetween5mTo10m.ResearchCode,
                        MoneyTypeName = firstBetween5mTo10m.MoneyTypeName,
                        ResearchMoney = firstBetween5mTo10m.ResearchMoney,
                        ResearchStartDate = firstBetween5mTo10m.ResearchStartDate,
                        ResearchEndDate = firstBetween5mTo10m.ResearchEndDate,
                        Researcher = researcherDataSub

                    };
                    researchDataListBetween5mTo10m.Add(researchDataViewModel);
                }
                var modelbetween5mTo10m = new RankResearchRageMoneyDataSourceModel
                {
                    ResearchRankMoneyName = "งบประมาณ 5,000,001 - 10,000,000",
                    ResearchData = researchDataListBetween5mTo10m
                };
                result.Add(modelbetween5mTo10m);
            }
            if (input.Type == null || input.Type == "5")
            {
                var between10mTo20m = researchMoney.Where(m => m.ResearchMoney > 100000000 && m.ResearchMoney < 20000000);
                var between10mTo20mDistinct = between10mTo20m.Select(s => new { s.ResearchId, s.ResearchNameTh }).Distinct();
                var researchDataListBetween10mTo20m = new List<DataModelReserachMoney>();
                foreach (var ld in between10mTo20mDistinct)
                {
                    var firstBetween10mTo20m = between10mTo20m.FirstOrDefault(m => m.ResearchId == ld.ResearchId && m.ResearchNameTh == ld.ResearchNameTh);
                    var researcherDataSub = between10mTo20m.Where(c => c.ResearchId == ld.ResearchId && c.ResearchNameTh == ld.ResearchNameTh)
                        .Select(g => new ResearcherData
                        {
                            ResearcherId = g.ResearcherId,
                            ResearcherName = g.ResearcherName,
                            CitizenId = g.CitizenId
                        }).ToList();
                    var researchDataViewModel = new DataModelReserachMoney
                    {
                        ResearchId = firstBetween10mTo20m.ResearchId,
                        ResearchNameTh = firstBetween10mTo20m.ResearchNameTh,
                        ResearchNameEn = firstBetween10mTo20m.ResearchNameEn,
                        ResearchCode = firstBetween10mTo20m.ResearchCode,
                        MoneyTypeName = firstBetween10mTo20m.MoneyTypeName,
                        ResearchMoney = firstBetween10mTo20m.ResearchMoney,
                        ResearchStartDate = firstBetween10mTo20m.ResearchStartDate,
                        ResearchEndDate = firstBetween10mTo20m.ResearchEndDate,
                        Researcher = researcherDataSub

                    };
                    researchDataListBetween10mTo20m.Add(researchDataViewModel);
                }
                var modelbetween10mTo20m = new RankResearchRageMoneyDataSourceModel
                {
                    ResearchRankMoneyName = "งบประมาณ 10,000,001 - 20,000,000",
                    ResearchData = researchDataListBetween10mTo20m
                };
                result.Add(modelbetween10mTo20m);
            }

            if (input.Type == null || input.Type == "6")
            {
                var over20m = researchMoney.Where(m => m.ResearchMoney > 20000000);
                var over20mDistinct = over20m.Select(s => new { s.ResearchId, s.ResearchNameTh }).Distinct();
                var researchDataListOver20m = new List<DataModelReserachMoney>();
                foreach (var ld in over20mDistinct)
                {
                    var firstOver20m = over20m.FirstOrDefault(m => m.ResearchId == ld.ResearchId && m.ResearchNameTh == ld.ResearchNameTh);
                    var researcherDataSub = over20m.Where(c => c.ResearchId == ld.ResearchId && c.ResearchNameTh == ld.ResearchNameTh)
                        .Select(g => new ResearcherData
                        {
                            ResearcherId = g.ResearcherId,
                            ResearcherName = g.ResearcherName,
                            CitizenId = g.CitizenId
                        }).ToList();
                    var researchDataViewModel = new DataModelReserachMoney
                    {
                        ResearchId = firstOver20m.ResearchId,
                        ResearchNameTh = firstOver20m.ResearchNameTh,
                        ResearchNameEn = firstOver20m.ResearchNameEn,
                        ResearchCode = firstOver20m.ResearchCode,
                        MoneyTypeName = firstOver20m.MoneyTypeName,
                        ResearchMoney = firstOver20m.ResearchMoney,
                        ResearchStartDate = firstOver20m.ResearchStartDate,
                        ResearchEndDate = firstOver20m.ResearchEndDate,
                        Researcher = researcherDataSub

                    };
                    researchDataListOver20m.Add(researchDataViewModel);
                }
                var modelover20m = new RankResearchRageMoneyDataSourceModel
                {
                    ResearchRankMoneyName = "งบประมาณ 20,000,000 ขึ้นไป",
                    ResearchData = researchDataListOver20m
                };
                result.Add(modelover20m);

            }

            return list;

        

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
            var personResearch = _dcResearchDataRepository.GetAll().Where(m => m.ResearchId == re.ResearchId && m.CitizenId != citizenId)
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
