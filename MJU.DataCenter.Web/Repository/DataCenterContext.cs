using Microsoft.EntityFrameworkCore;
using MJU.DataCenter.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.Web.Repository
{
    public partial class DataCenterContext : DbContext
    {

        public DataCenterContext()
        {
        }

        public DataCenterContext(DbContextOptions<DataCenterContext> options)
            : base(options)
        {
        }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("User ID=admin;Password=abc123;Server=localhost\\SQLEXPRESS;Database=MJUDataCenter2; Pooling=true;integrated security=false;");
//            }
//        }

        public virtual DbSet<DepartmentRole> DepartmentRole { get; set; }
        public virtual DbSet<UserDepartmentRole> UserDepartmentRole { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<DepartmentRole>(entity =>
        //    {
        //        entity.Property(e => e.DepartmentRoleId);

        //        entity.Property(e => e.DepartmentRoleName);

        //        entity.Property(e => e.DepartmentKey);
        //    });

        //    modelBuilder.Entity<UserDepartmentRole>(entity =>
        //    {
        //        entity.Property(e => e.UserDepartmentRoleId);

        //        entity.Property(e => e.UserId);

        //        entity.Property(e => e.DepartmentRoleId);
        //    });

        //    base.OnModelCreating(modelBuilder);
        //}
        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
