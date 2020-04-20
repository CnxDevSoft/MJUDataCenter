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

        public virtual DbSet<DcResearchData> DcResearchData { get; set; }
        public virtual DbSet<DcResearchFaculty> DcResearchFaculty { get; set; }
        public virtual DbSet<DcResearchGroup> DcResearchGroup { get; set; }
        public virtual DbSet<DcResearchMoney> DcResearchMoney { get; set; }
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
                optionsBuilder.UseSqlServer("Server=DESKTOP-OAG5O3P;Database=ResearchExtension;User Id=admin;Password=abc123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DcResearchData>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("DC_researchData");

                entity.Property(e => e.ResearchEndDate).HasColumnType("datetime");

                entity.Property(e => e.ResearchNameEn).HasColumnName("ResearchNameEN");

                entity.Property(e => e.ResearchNameTh).HasColumnName("ResearchNameTH");

                entity.Property(e => e.ResearchStartDate).HasColumnType("datetime");

                entity.Property(e => e.ResearcherName).IsRequired();
            });

            modelBuilder.Entity<DcResearchFaculty>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("DC_ResearchFaculty");

                entity.Property(e => e.ResearchEndDate).HasColumnType("datetime");

                entity.Property(e => e.ResearchNameEn).HasColumnName("ResearchNameEN");

                entity.Property(e => e.ResearchNameTh).HasColumnName("ResearchNameTH");

                entity.Property(e => e.ResearchStartDate).HasColumnType("datetime");

                entity.Property(e => e.ResearcherName).IsRequired();
            });

            modelBuilder.Entity<DcResearchGroup>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("DC_ResearchGroup");

                entity.Property(e => e.ResearchEndDate).HasColumnType("datetime");

                entity.Property(e => e.ResearchNameEn).HasColumnName("ResearchNameEN");

                entity.Property(e => e.ResearchNameTh).HasColumnName("ResearchNameTH");

                entity.Property(e => e.ResearchStartDate).HasColumnType("datetime");

                entity.Property(e => e.ResearcherName).IsRequired();
            });

            modelBuilder.Entity<DcResearchMoney>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("DC_ResearchMoney");

                entity.Property(e => e.ResearchEndDate).HasColumnType("datetime");

                entity.Property(e => e.ResearchNameEn).HasColumnName("ResearchNameEN");

                entity.Property(e => e.ResearchNameTh).HasColumnName("ResearchNameTH");

                entity.Property(e => e.ResearchStartDate).HasColumnType("datetime");

                entity.Property(e => e.ResearcherName).IsRequired();
            });

            modelBuilder.Entity<PersonnelGroup>(entity =>
            {
                entity.HasKey(e => e.PersonGroupId)
                    .HasName("PK__Personne__89466BB783313CB5");
            });

            modelBuilder.Entity<ResearchData>(entity =>
            {
                entity.HasKey(e => e.ResearchId)
                    .HasName("PK__Research__617A954ECFA5E328");

                entity.Property(e => e.EndDateResearch).HasColumnType("datetime");

                entity.Property(e => e.ResearchNameEn).HasColumnName("ResearchNameEN");

                entity.Property(e => e.ResearchNameTh).HasColumnName("ResearchNameTH");

                entity.Property(e => e.StartDateResearch).HasColumnType("datetime");
            });

            modelBuilder.Entity<ResearchMoney>(entity =>
            {
                entity.Property(e => e.ResearchMoney1).HasColumnName("ResearchMoney");
            });

            modelBuilder.Entity<ResearchPaper>(entity =>
            {
                entity.Property(e => e.PaperCreateDate).HasColumnType("datetime");

                entity.Property(e => e.PaperNameEn).HasColumnName("PaperNameEN");

                entity.Property(e => e.PaperNameTh).HasColumnName("PaperNameTH");
            });

            modelBuilder.Entity<ResearchPersonnel>(entity =>
            {
                entity.Property(e => e.ResearchWorkPercent).HasColumnType("decimal(5, 2)");
            });

            modelBuilder.Entity<Researcher>(entity =>
            {
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
