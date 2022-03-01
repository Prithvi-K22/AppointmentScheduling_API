using AppointmentScheduling.Model;
using Microsoft.EntityFrameworkCore;

namespace AppointmentScheduling.Data
{
    public class ApplicationDbContext : DbContext
    {
        internal readonly object Appointmentss;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Appointment>Appointments { get; set; }
        public DbSet<Department>Departments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

    }
}
