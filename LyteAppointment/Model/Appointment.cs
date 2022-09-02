using Microsoft.EntityFrameworkCore;
using System;

namespace LyteAppointment.Models
{
    public class AppointmentSlot
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Doctor Doctor { get; set; }
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public string? PatientName { set; get; }
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public string? PatientId { set; get; }
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public string Status { get; set; } = "free";
        public int Resource { get { return Doctor.Id; } }

    }

    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class DoctorDbContext : DbContext
    {
        public DbSet<AppointmentSlot> Appointments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        public DoctorDbContext(DbContextOptions<DoctorDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(new Doctor { Id = 1, Name = "Doctor 1" });
            modelBuilder.Entity<Doctor>().HasData(new Doctor { Id = 2, Name = "Doctor 2" });
            modelBuilder.Entity<Doctor>().HasData(new Doctor { Id = 3, Name = "Doctor 3" });

        }
    }
}
