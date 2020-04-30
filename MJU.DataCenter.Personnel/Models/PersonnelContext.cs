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

        public virtual DbSet<DcPerson> DcPerson { get; set; }
        public virtual DbSet<DcPersonEducation> DcPersonEducation { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<PersonEducation> PersonEducation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-OAG5O3P;User Id=admin;Database=Personnel;Password=abc123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DcPerson>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("DC_Person");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.GraduateDate).HasColumnType("datetime");

                entity.Property(e => e.PersonnelId).ValueGeneratedOnAdd();

                entity.Property(e => e.RetiredDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.StartEducationDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<DcPersonEducation>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("DC_PersonEducation");

                entity.Property(e => e.CitizenId).HasMaxLength(25);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.CountryId).HasMaxLength(50);

                entity.Property(e => e.Education).HasMaxLength(50);

                entity.Property(e => e.EducationLevel).HasMaxLength(50);

                entity.Property(e => e.GraduateDate).HasColumnType("datetime");

                entity.Property(e => e.Major).HasMaxLength(50);

                entity.Property(e => e.StartEducationDate).HasColumnType("datetime");

                entity.Property(e => e.TitleEducation).HasMaxLength(50);

                entity.Property(e => e.University).HasMaxLength(50);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.PersonnelId)
                    .HasName("PK__Person__CAFBCB4F5A5A0C35");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.GraduateDate).HasColumnType("datetime");

                entity.Property(e => e.RetiredDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.StartEducationDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<PersonEducation>(entity =>
            {
                entity.Property(e => e.GraduateDate).HasColumnType("datetime");

                entity.Property(e => e.StartEducationDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
