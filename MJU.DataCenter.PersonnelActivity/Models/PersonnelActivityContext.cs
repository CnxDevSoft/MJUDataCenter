using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MJU.DataCenter.PersonnelActivity.Models
{
    public partial class PersonnelActivityContext : DbContext
    {
        public PersonnelActivityContext()
        {
        }

        public PersonnelActivityContext(DbContextOptions<PersonnelActivityContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Activity> Activity { get; set; }
        public virtual DbSet<DcActivity> DcActivity { get; set; }
        public virtual DbSet<DcPersonnelActivity> DcPersonnelActivity { get; set; }
        public virtual DbSet<PersonnelActivity> PersonnelActivity { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=PersonnelActivity;User Id=admin;Password=abc123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>(entity =>
            {
                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<DcActivity>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("DC_Activity");

                entity.Property(e => e.ActivityId).ValueGeneratedOnAdd();

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<DcPersonnelActivity>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("DC_PersonnelActivity");

                entity.Property(e => e.PersonnelActivity).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<PersonnelActivity>(entity =>
            {
                entity.HasKey(e => e.PersonnelActivity1)
                    .HasName("PK__Personne__9580D2EA2EE27208");

                entity.Property(e => e.PersonnelActivity1).HasColumnName("PersonnelActivity");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
