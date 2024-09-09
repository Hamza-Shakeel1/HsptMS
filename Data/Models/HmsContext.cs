using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HsptMS.Data.Models
{
    public partial class HmsContext : DbContext
    {
        public HmsContext()
        {
        }

        public HmsContext(DbContextOptions<HmsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<Appointment> Appointments { get; set; } = null!;
        public virtual DbSet<Billing> Billings { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Doctor> Doctors { get; set; } = null!;
        public virtual DbSet<Gender> Genders { get; set; } = null!;
        public virtual DbSet<Patient> Patients { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=HSM;Trusted_Connection=True;Integrated Security=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.City).HasMaxLength(100);

                entity.Property(e => e.Country).HasMaxLength(100);

                entity.Property(e => e.PostalCode).HasMaxLength(20);

                entity.Property(e => e.State).HasMaxLength(100);

                entity.Property(e => e.Street).HasMaxLength(255);
            });

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.AppointmentDate).HasColumnType("datetime");

                entity.Property(e => e.Purpose).HasMaxLength(255);

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK_Appointments_Doctor");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK_Appointments_Patient");
            });

            modelBuilder.Entity<Billing>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.BillingDate).HasColumnType("datetime");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Billings)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK_Billings_Doctor");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Billings)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK_Billings_Patient");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ContactNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.HeadOfDepartment)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ContactNumber).HasMaxLength(15);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_Doctors_Department");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.ToTable("Gender");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.AdmissionDate).HasColumnType("datetime");

                entity.Property(e => e.ContactNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DischargeDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_Patients_Address");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK_Patients_Doctor");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email, "UQ__Users__A9D1053444997E27")
                    .IsUnique();

                entity.HasIndex(e => e.UserName, "UQ__Users__C9F284562425AAC4")
                    .IsUnique();

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.PasswordHash).HasMaxLength(255);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
