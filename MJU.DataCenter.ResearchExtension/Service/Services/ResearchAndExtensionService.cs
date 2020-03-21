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
        public ResearchAndExtensionService(IDcResearchGroupRepository dcResearchGroupRepository,
            IDcResearchDataRepository dcResearchDataRepository)
        {
            _dcResearchGroupRepository = dcResearchGroupRepository;
            _dcResearchDataRepository = dcResearchDataRepository;
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
                            LisViewData = researchDepartmentWithCondition.Select(s => new ResearchDataDepartment
                            {
                                ResearchId = s.ResearchId,
                                ResearchNameEN = s.ResearchNameEn,
                                ResearchNameTH = s.ResearchNameTh
                            }).ToList()
                        }

                    );

                    label.Add(rd.DepartmentNameTh);
                    data.Add(researchDepartmentWithCondition.Count());
                    i++;
                }
                var graphDataSet = new GraphDataSet
                {
                    Data = data,
                    ViewData = viewData
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
                var list = new List<ResearchDepartmentViewModel>();
                foreach (var rd in distinctResearchDepartment)
                {
                    var model = new ResearchDepartmentViewModel
                    {
                        DepartmentId = rd.DepartmentId,
                        DepartmentName = rd.DepartmentNameTh,
                        ResearchData = researchDepartment.Where(m => m.DepartmentId == rd.DepartmentId && m.DepartmentNameTh == rd.DepartmentNameTh)
                        .Select(s => new ResearchDataDepartment
                        {
                            ResearchId = s.ResearchId,
                            ResearchNameEN = s.ResearchNameEn,
                            ResearchNameTH = s.ResearchNameTh
                        }).ToList()
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
                            LisViewData = researchDepartmentWithCondition.Select(s => new ResearchDataGroup
                            {
                                ResearchId = s.ResearchId,
                                ResearchNameEN = s.ResearchNameEn,
                                ResearchNameTH = s.ResearchNameTh
                            }).ToList()
                        }

                    );

                    label.Add(rg.PersonGroupName);
                    data.Add(researchDepartmentWithCondition.Count());
                    i++;
                }
                var graphDataSet = new GraphDataSet
                {
                    Data = data,
                    ViewData = viewData
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
                var list = new List<ResearchGroupViewModel>();
                foreach (var rg in distinctResearchGroup)
                {
                    var model = new ResearchGroupViewModel
                    {
                        PersonGroupId = rg.PersonGroupId,
                        PersonGroupName = rg.PersonGroupName,
                        ResearchData = researchGroup.Where(m => m.PersonGroupId == rg.PersonGroupId && m.PersonGroupName == rg.PersonGroupName)
                        .Select(s => new ResearchDataGroup
                        {
                            ResearchId = s.ResearchId,
                            ResearchNameEN = s.ResearchNameEn,
                            ResearchNameTH = s.ResearchNameTh
                        }).ToList()
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
                            LisViewData = researchDepartmentWithCondition.Select(s => new ResearchData
                            {
                                ResearchId = s.ResearchId,
                                ResearchNameEN = s.ResearchNameEng,
                                ResearchNameTH = s.ResearchNameTh
                            }).ToList()
                        }

                    );

                    label.Add(rd.MoneyName);
                    data.Add(researchDepartmentWithCondition.Count());
                    i++;
                }
                var graphDataSet = new GraphDataSet
                {
                    Data = data,
                    ViewData = viewData
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
                var list = new List<ResearchDataViewModel>();
                foreach (var rd in distinctResearchData)
                {
                    var model = new ResearchDataViewModel
                    {
                        MoneyTypeId = rd.ResearchMoneyTypeId,
                        MoneyTypeName = rd.MoneyName,
                        ResearchData = researchData.Where(m => m.ResearchMoneyTypeId == rd.ResearchMoneyTypeId && m.MoneyName == rd.MoneyName)
                        .Select(s => new ResearchData
                        {
                            ResearchId = s.ResearchId,
                            ResearchNameEN = s.ResearchNameEng,
                            ResearchNameTH = s.ResearchNameTh
                        }).ToList()
                    };
                    list.Add(model);
                }
                return list;
            }
        }
    }
}
