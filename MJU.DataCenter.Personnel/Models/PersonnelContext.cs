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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-QCPA044\\SQLEXPRESS;Database=Personnel;User Id=apichai_server;Password=Password#01;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.PersonnelId)
                    .HasName("PK__Person__CAFBCB4FDEEA1CC1");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.GraduateDate).HasColumnType("datetime");

                entity.Property(e => e.RetiredDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.StartEducationDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
