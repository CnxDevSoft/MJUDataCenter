﻿using System;
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

        public virtual DbSet<DcResearchData> DcResearchData { get; set; }
        public virtual DbSet<DcResearchPaper> DcResearchPaper { get; set; }
        public virtual DbSet<DcResearchPaperPerson> DcResearchPaperPerson { get; set; }
        public virtual DbSet<DcResearcher> DcResearcher { get; set; }
        public virtual DbSet<MoneyType> MoneyType { get; set; }
        public virtual DbSet<PersonnelGroup> PersonnelGroup { get; set; }
        public virtual DbSet<ResearchData> ResearchData { get; set; }
        public virtual DbSet<ResearchMoney> ResearchMoney { get; set; }
        public virtual DbSet<ResearchPaper> ResearchPaper { get; set; }
        public virtual DbSet<ResearchPersonnel> ResearchPersonnel { get; set; }
        public virtual DbSet<Researcher> Researcher { get; set; }
        public virtual DbSet<ResearcherGroup> ResearcherGroup { get; set; }
        public virtual DbSet<ResearcherPaper> ResearcherPaper { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-QCPA044\\SQLEXPRESS;Database=ResearchExtension;User Id=apichai_server;Password=Password#01;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DcResearchData>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("DC_researchData");

                entity.Property(e => e.MoneyName).HasColumnName("money_name");

                entity.Property(e => e.ResearchDateEnd)
                    .HasColumnName("research_date_end")
                    .HasColumnType("datetime");

                entity.Property(e => e.ResearchDateStart)
                    .HasColumnName("research_date_start")
                    .HasColumnType("datetime");

                entity.Property(e => e.ResearchId).HasColumnName("research_id");

                entity.Property(e => e.ResearchMoney).HasColumnName("research_money");

                entity.Property(e => e.ResearchMoneyTypeId).HasColumnName("research_money_type_id");

                entity.Property(e => e.ResearchNameEng).HasColumnName("research_name_eng");

                entity.Property(e => e.ResearchNameTh).HasColumnName("research_name_th");

                entity.Property(e => e.ResearchRefCode).HasColumnName("research_ref_code");
            });

            modelBuilder.Entity<DcResearchPaper>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("DC_research_Paper");

                entity.Property(e => e.ActicleNameEng).HasColumnName("acticle_nameEng");

                entity.Property(e => e.ActicleNameTh).HasColumnName("acticle_nameTH");

                entity.Property(e => e.MagId).HasColumnName("mag_id");

                entity.Property(e => e.MagazineName).HasColumnName("magazine_name");

                entity.Property(e => e.MagazineVolum).HasColumnName("magazine_volum");

                entity.Property(e => e.PaperId).HasColumnName("paper_id");

                entity.Property(e => e.PrintingDate)
                    .HasColumnName("printing_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ResearchId).HasColumnName("research_id");

                entity.Property(e => e.Weigth).HasColumnName("weigth");
            });

            modelBuilder.Entity<DcResearchPaperPerson>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("DC_researchPaperPerson");

                entity.Property(e => e.PaperId).HasColumnName("paper_ID");

                entity.Property(e => e.PaperPercent)
                    .HasColumnName("paperPercent")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.PersonGroupId).HasColumnName("personGroupID");

                entity.Property(e => e.PersonGroupName).HasColumnName("personGroupName");

                entity.Property(e => e.PersonId).HasColumnName("personID");
            });

            modelBuilder.Entity<DcResearcher>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("DC_researcher");

                entity.Property(e => e.DepartmentCode).HasColumnName("departmentCode");

                entity.Property(e => e.DepartmentId).HasColumnName("departmentID");

                entity.Property(e => e.DepartmentNameTh).HasColumnName("departmentNameTH");

                entity.Property(e => e.NameTh).HasColumnName("nameTH");

                entity.Property(e => e.PersonGroupId).HasColumnName("personGroupID");

                entity.Property(e => e.PersonId).HasColumnName("personID");

                entity.Property(e => e.PersonMoney)
                    .HasColumnName("personMoney")
                    .HasColumnType("decimal(8, 2)");

                entity.Property(e => e.PrefixNameTh).HasColumnName("prefixNameTH");

                entity.Property(e => e.ResearchWorkPercent)
                    .HasColumnName("research_work_percent")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.SirNameTh).HasColumnName("sirNameTH");
            });

            modelBuilder.Entity<PersonnelGroup>(entity =>
            {
                entity.HasKey(e => e.PersonGroupId)
                    .HasName("PK__Personne__89466BB7BCF6A780");
            });

            modelBuilder.Entity<ResearchData>(entity =>
            {
                entity.HasKey(e => e.ResearchId)
                    .HasName("PK__Research__617A954E074B9D5A");

                entity.Property(e => e.EndDateResearch).HasColumnType("datetime");

                entity.Property(e => e.ResearchNameEn).HasColumnName("ResearchNameEN");

                entity.Property(e => e.ResearchNameTh).HasColumnName("ResearchNameTH");

                entity.Property(e => e.StartDataResearch).HasColumnType("datetime");
            });

            modelBuilder.Entity<ResearchPaper>(entity =>
            {
                entity.Property(e => e.PaperCreateData).HasColumnType("datetime");

                entity.Property(e => e.PaperNameEn).HasColumnName("PaperNameEN");

                entity.Property(e => e.PaperNameTh).HasColumnName("PaperNameTH");
            });

            modelBuilder.Entity<ResearchPersonnel>(entity =>
            {
                entity.Property(e => e.ResearchMoney).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.ResearchWorkPercent).HasColumnType("decimal(5, 2)");
            });

            modelBuilder.Entity<Researcher>(entity =>
            {
                entity.Property(e => e.DepartmentNameTh).HasColumnName("DepartmentNameTH");

                entity.Property(e => e.FirstNameTh).HasColumnName("FirstNameTH");

                entity.Property(e => e.LastNameTh).HasColumnName("LastNameTH");

                entity.Property(e => e.TitleTh).HasColumnName("TitleTH");
            });

            modelBuilder.Entity<ResearcherPaper>(entity =>
            {
                entity.Property(e => e.PaperPercent).HasColumnType("decimal(5, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
