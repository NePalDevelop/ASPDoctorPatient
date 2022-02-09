using System;
using Microsoft.EntityFrameworkCore;
using TestASPDoctorPatient.Data.Models;

namespace TestASPDoctorPatient.Data
{
    public class DPContext : DbContext
    {
        public DPContext(DbContextOptions<DPContext> options) : base(options)
        {
        }

        public DbSet<ServiceArea> Areas { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Cabinet> Cabinets { get; set; }
        public DbSet<Specialization> Specializations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cabinet>()
                .HasMany(c => c.Doctors)
                .WithOne(d => d.Cabinet);
        }

    }
}
