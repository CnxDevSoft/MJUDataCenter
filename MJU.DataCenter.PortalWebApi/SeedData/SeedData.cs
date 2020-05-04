using MJU.DataCenter.PortalWebApi.Models;
using MJU.DataCenter.PortalWebApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.PortalWebApi.SeedData
{
    public class SeedData
    {


        public void Run()
        {



        }

        public void UserSeedData()
        {
            using (var context = new DataCenterContext())
            {
                var departmentRole = context.DepartmentRole.ToList();
                if (!departmentRole.Any())
                {

                    //var general = departmentRole.FirstOrDefault(x => x.DepartmentRoleName == "General");
                    //if (general != null)
                    //{
                    //    general.DepartmentRoleName = "General";
                    //    general.DepartmentRoleNameTH = "ผู้บริหาร";
                    //    general.DepartmentApiActive = true;
                    //    context.DepartmentRole.Update(general);
                    //}
                    //else
                    //{

                    //    general.DepartmentRoleName = "General";
                    //    general.DepartmentRoleNameTH = "ผู้บริหาร";
                    //    general.DepartmentApiActive = true;
                    //    context.DepartmentRole.Add(general);
                    //} 
                }
                context.SaveChanges();
            }
        }
    }
}
