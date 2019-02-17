using Microsoft.EntityFrameworkCore;
using RandevuTakip.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RandevuTakip.DAL.Concrete.EfCore
{
    public class AppointmentDbContext : DbContext
    {
        public AppointmentDbContext(DbContextOptions<AppointmentDbContext> options) : base(options)
        {
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Patient> Patients { get; set; }
    }
}
