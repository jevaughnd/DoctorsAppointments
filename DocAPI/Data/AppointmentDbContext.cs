using Microsoft.EntityFrameworkCore;
using DoctorsAppointments.Models;


namespace DoctorsAppointments.Data
{
    public class AppointmentDbContext : DbContext
    {
        public AppointmentDbContext(DbContextOptions<AppointmentDbContext> options) : base(options)
        { }

		public DbSet<Doctor> Doctors { get; set; }
		public DbSet<Patient> Patients { get; set; }
        
        public DbSet<Parish> Parishes { get; set; }

		
		public DbSet<TimeSchedule> TimeSchedules { get; set; }
		public DbSet<Appointment> Appointments { get; set; }

        
      


	}
}
