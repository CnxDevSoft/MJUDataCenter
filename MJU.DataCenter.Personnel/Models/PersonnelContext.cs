using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MJU.DataCenter.Personnel.Models
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

        public virtual DbSet<Person> Person { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-QCPA044\\SQLEXPRESS;Database=Personnel;User Id=apichai_server;Password=Password#01;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.PersonnelId)
                    .HasName("PK__Person__CAFBCB4F88437F96");

                entity.Property(e => e.AdminPosition).HasMaxLength(50);

                entity.Property(e => e.AdminPositionType).HasMaxLength(25);

                entity.Property(e => e.BloodType).HasMaxLength(10);

                entity.Property(e => e.Country).HasMaxLength(20);

                entity.Property(e => e.CountryId).HasMaxLength(10);

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.District).HasMaxLength(25);

                entity.Property(e => e.Division).HasMaxLength(25);

                entity.Property(e => e.Education).HasMaxLength(50);

                entity.Property(e => e.EducationLevel).HasMaxLength(50);

                entity.Property(e => e.Faculty).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(25);

                entity.Property(e => e.FirstNameEn).HasMaxLength(25);

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.GraduateDate).HasColumnType("datetime");

                entity.Property(e => e.HomeNumber).HasMaxLength(10);

                entity.Property(e => e.IdCard).HasMaxLength(20);

                entity.Property(e => e.LastName).HasMaxLength(25);

                entity.Property(e => e.LastNameEn).HasMaxLength(25);

                entity.Property(e => e.Major).HasMaxLength(50);

                entity.Property(e => e.Nation).HasMaxLength(20);

                entity.Property(e => e.PersonnelType).HasMaxLength(25);

                entity.Property(e => e.PersonnelTypeId).HasMaxLength(25);

                entity.Property(e => e.Position).HasMaxLength(25);

                entity.Property(e => e.PositionCode).HasMaxLength(10);

                entity.Property(e => e.PositionLeve).HasMaxLength(25);

                entity.Property(e => e.PositionLevelId).HasMaxLength(10);

                entity.Property(e => e.PositionRank).HasMaxLength(25);

                entity.Property(e => e.PositionRankId).HasMaxLength(10);

                entity.Property(e => e.Province).HasMaxLength(50);

                entity.Property(e => e.RetiredDate).HasColumnType("datetime");

                entity.Property(e => e.Section).HasMaxLength(25);

                entity.Property(e => e.Soi).HasMaxLength(25);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.StartEducationDate).HasColumnType("datetime");

                entity.Property(e => e.Street).HasMaxLength(50);

                entity.Property(e => e.SubDistrict).HasMaxLength(50);

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
