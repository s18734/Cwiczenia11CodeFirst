using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wyklad11.Models
{
    public class DoctorDbContext :DbContext
    {

        
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Medicament> Medicament { get; set; }
        public DbSet<Prescription> Prescription { get; set; }
        public DoctorDbContext()
        {

        }
        public DoctorDbContext(DbContextOptions options) : base(options)
        {
           

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //FluentAPI
            modelBuilder.Entity<Doctor>(e =>
            {
                e.HasKey(e => e.IdDoctor).HasName("Doctor_PK");
                e.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
                e.Property(e => e.LastName).HasMaxLength(100).IsRequired();
                e.Property(e => e.Email).HasMaxLength(100).IsRequired();

            });
            modelBuilder.Entity<Patient>(e =>
            {
                e.HasKey(e => e.IdPatient).HasName("Patient_PK");
                e.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
                e.Property(e => e.LastName).HasMaxLength(100).IsRequired();
                e.Property(e => e.BirthDate).IsRequired();

            });
            modelBuilder.Entity<Medicament>(e =>
            {
                e.HasKey(e => e.IdMedicament).HasName("Medicament_PK");
                e.Property(e => e.Name).HasMaxLength(100).IsRequired();
                e.Property(e => e.Description).HasMaxLength(100).IsRequired();
                e.Property(e => e.Type).HasMaxLength(100).IsRequired();

            });

            modelBuilder.Entity<Prescription>(e =>
            {
                e.HasKey(e => e.IdPrescription).HasName("Prescription_PK");
                e.Property(e => e.Date).IsRequired();
                e.Property(e => e.DueDate).IsRequired();


                e.HasOne(e => e.Patient)
                      .WithMany(b => b.Prescriptions)
                      .HasForeignKey(a => a.IdPatient)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("Prescription_Patient");

                e.HasOne(e => e.Doctor)
                      .WithMany(b => b.Prescriptions)
                      .HasForeignKey(a => a.IdDoctor)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("Prescription_Doctor");

            });

            modelBuilder.Entity<PrescriptionMedicament>(e =>
            {
                e.HasKey(e => e.IdMedicament).HasName("Medicament_PK");
                e.HasKey(e => e.IdPrescription).HasName("Prescription_PK");
                e.Property(e => e.Details).HasMaxLength(100).IsRequired();

                e.HasOne(a => a.Prescription)
                  .WithMany(b => b.PrescriptionMedicaments)
                  .HasForeignKey(b => b.IdPrescription)
                  .OnDelete(DeleteBehavior.ClientSetNull);

                e.HasOne(a => a.Medicament)
                  .WithMany(b => b.PrescriptionMedicaments)
                  .HasForeignKey(b => b.IdMedicament)
                  .OnDelete(DeleteBehavior.ClientSetNull);

            });


        }
        public static void SeedMethod(ModelBuilder modelb)
        {
            modelb.Entity<Doctor>().HasData(
                new Doctor
                {
                    IdDoctor = 1,
                    FirstName = "Julian",
                    LastName = "mikolajczyk",
                    Email = "mikolajczykJulian@gmail.com"
                },
                new Doctor
                {
                    IdDoctor = 2,
                    FirstName = "Robert",
                    LastName = "Biedron",
                    Email = "RobertBiedron@gmail.com"
                });
            modelb.Entity<Patient>().HasData(
                new Patient
                {
                    IdPatient = 1,
                    FirstName = "Asia",
                    LastName = "Basia",
                    BirthDate = DateTime.Parse("2010-07-15")
                },
                new Patient
                {
                    IdPatient = 2,
                    FirstName = "Michał",
                    LastName = "Melaniuk",
                    BirthDate = DateTime.Parse("1995-04-12")
                },
                new Patient
                {
                    IdPatient = 3,
                    FirstName = "Monika",
                    LastName = "Ośko",
                    BirthDate = DateTime.Parse("1876-07-22")
                });
            modelb.Entity<Medicament>().HasData(
                new Medicament
                {
                    IdMedicament = 1,
                    Name = "Abab Forte",
                    Description = "Ababbb",
                    Type = "painkiller"
                },
                new Medicament
                {
                    IdMedicament = 2,
                    Name = "Ibum max",
                    Description = "ccc",
                    Type = "ddd"
                },
                new Medicament
                {
                    IdMedicament = 3,
                    Name = "Marsjanki",
                    Description = "Michała ulubione",
                    Type = "element diety"
                });
            modelb.Entity<Prescription>().HasData(
                new Prescription
                {
                    IdPrescription = 1,
                    Date = DateTime.Parse("2020-02-11"),
                    DueDate = DateTime.Today.AddDays(7),
                    IdDoctor = 1,
                    IdPatient = 1
                },
                new Prescription
                {
                    IdPrescription = 2,
                    Date = DateTime.Today,
                    DueDate = DateTime.Today.AddDays(2),
                    IdDoctor = 1,
                    IdPatient = 2
                }
            );
            modelb.Entity<PrescriptionMedicament>().HasData(
                new PrescriptionMedicament
                {
                    IdMedicament = 1,
                    IdPrescription = 1,
                    Details = "123 test"
                }
            );
        }
    }
}
