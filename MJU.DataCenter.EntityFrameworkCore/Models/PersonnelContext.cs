using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MJU.DataCenter.EntityFrameworkCore.Models
{
    public partial class PersonnelContext : DbContext
    {
        public PersonnelContext()
        {
        }

        public PersonnelContext(DbContextOptions<PersonnelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Personnel> Personnel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-QCPA044\\SQLEXPRESS;Database=Personnel;User Id=apichai_server;Password=Password#01;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personnel>(entity =>
            {
                entity.Property(e => e.PersonnelId).ValueGeneratedNever();

                entity.Property(e => e.AdminPosition).HasMaxLength(50);

                entity.Property(e => e.AdminPositionType).HasMaxLength(25);

                entity.Property(e => e.Amphur).HasMaxLength(25);

                entity.Property(e => e.BloodType).HasMaxLength(10);

                entity.Property(e => e.Country).HasMaxLength(20);

                entity.Property(e => e.CountryId).HasMaxLength(10);

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.District).HasMaxLength(50);

                entity.Property(e => e.Division).HasMaxLength(25);

                entity.Property(e => e.Education).HasMaxLength(50);

                entity.Property(e => e.EducationLevel).HasMaxLength(50);

                entity.Property(e => e.EducationMajor).HasMaxLength(50);

                entity.Property(e => e.Fact).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(25);

                entity.Property(e => e.FirstNameEn).HasMaxLength(25);

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.GraduateDate).HasColumnType("datetime");

                entity.Property(e => e.HomeNumber).HasMaxLength(10);

                entity.Property(e => e.IdCard).HasMaxLength(20);

                entity.Property(e => e.LastName).HasMaxLength(25);

                entity.Property(e => e.LastNameEn).HasMaxLength(25);

                entity.Property(e => e.Nation).HasMaxLength(20);

                entity.Property(e => e.PersonnelType).HasMaxLength(25);

                entity.Property(e => e.PersonnelTypeId).HasMaxLength(25);

                entity.Property(e => e.Position).HasMaxLength(25);

                entity.Property(e => e.PositionCode).HasMaxLength(10);

                entity.Property(e => e.PositionLeve).HasMaxLength(25);

                entity.Property(e => e.PositionLevelId).HasMaxLength(10);

                entity.Property(e => e.PositionRank).HasMaxLength(25);

                entity.Property(e => e.PositionRankId).HasMaxLength(10);

                entity.Property(e => e.Provine).HasMaxLength(50);

                entity.Property(e => e.ReitreDate).HasColumnType("datetime");

                entity.Property(e => e.Section).HasMaxLength(25);

                entity.Property(e => e.Soi).HasMaxLength(25);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.StartDateEducation).HasColumnType("datetime");

                entity.Property(e => e.Street).HasMaxLength(50);

                entity.Property(e => e.TitleEducation).HasMaxLength(25);

                entity.Property(e => e.TitleName).HasMaxLength(10);

                entity.Property(e => e.TitleNameEn).HasMaxLength(10);

                entity.Property(e => e.TitlePosition).HasMaxLength(10);

                entity.Property(e => e.University).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
