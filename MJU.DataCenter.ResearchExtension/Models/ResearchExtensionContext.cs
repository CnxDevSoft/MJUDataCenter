using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MJU.DataCenter.ResearchExtension.Models
{
    public partial class ResearchExtensionContext : DbContext
    {
        public ResearchExtensionContext()
        {
        }

        public ResearchExtensionContext(DbContextOptions<ResearchExtensionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Fund> Fund { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<ProjectFund> ProjectFund { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-QCPA044\\SQLEXPRESS;Database=ResearchExtension;User Id=apichai_server;Password=Password#01;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fund>(entity =>
            {
                entity.Property(e => e.Fund1).HasColumnName("Fund");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.Budget).HasColumnType("decimal(8, 2)");
            });

            modelBuilder.Entity<ProjectFund>().ToView("Project_Fund").HasNoKey();

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
