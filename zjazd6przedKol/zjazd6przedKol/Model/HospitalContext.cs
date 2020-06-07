using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw6.Model
{
    public class HospitalContext : DbContext
    {
        public HospitalContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(new Doctor
            {
                IdDoctor = 1,
                FirstName = "Denis",
                LastName = "Denisowiczowicz",
                Email = "dedede@gmail.com"
            });
            modelBuilder.Entity<Patient>().HasData(new Patient
            {
                IdPatient = 1,
                FirstName = "Artur",
                LastName = "Arturowicz",
                BirthDate = DateTime.Now
            });
            modelBuilder.Entity<Prescription>().HasData(new Prescription
            {
                IdPrescription = 1,
                IdDoctor = 1,
                IdPatient = 1,
                Date = DateTime.Now,
                DueDate = DateTime.Now.AddDays(2)
            });
        }
    }
}
