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
        public ResearchAndExtensionService(IDcResearchDepartmentRepository dcResearchDepartmentRepository)
        {
            _dcResearchDepartmentRepository = dcResearchDepartmentRepository;
        }

        public object GetResearchDepartment(int type)
        {
            var researchDepartment = _dcResearchDepartmentRepository.GetAll().ToList();
            var distinctResearchDepartment = researchDepartment.Select(m => new { m.DepartmentId ,m.DepartmentNameTh}).Distinct();
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
                            LisViewData = researchDepartmentWithCondition.Select(s => new ResaerchData
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
                    Data = data
                };
                var result = new GraphData
                {
                    GraphDataSet = new List<GraphDataSet> {
                     graphDataSet
                    },
                    Label = label
                };
                return result;
               
            }
            else
            {
                var list = new List<ResearchDepartment>();
                foreach (var rd in distinctResearchDepartment)
                {
                    var model = new ResearchDepartment
                    {
                        DepartmentId = rd.DepartmentId,
                        DepartmentName = rd.DepartmentNameTh,
                        ResaerchData = researchDepartment.Where(m => m.DepartmentId == rd.DepartmentId && m.DepartmentNameTh == rd.DepartmentNameTh)
                        .Select(s => new ResaerchData
                        {
                            ResearchId = s.ResearchId,
                            ResearchNameEN = s.ResearchNameEn,
                            ResearchNameTH = s.ResearchNameTh
                        }).ToList()
                    };
                    list.Add(model);
                }

            }
            

            return null;
        }
    }
}
