using Empathy.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Empathy.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<City> Cities { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Campus> Campuses { get; set; }
        public DbSet<DateTimer> DateTimers { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Procedure> Procedures { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<HealthCondition> HealthConditions { get; set; }
        public DbSet<HistoryProcedure> HistoryProcedures { get; set; }
        public DbSet<AppointmentCampus>AppointmentCampuses { get; set; }
        public DbSet<AppointmentDoctor>AppointmentDoctors { get; set; }
        public DbSet<AppointmentDateTimer>AppointmentDateTimers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Procedure>().HasIndex(c => c.TypeProcedure).IsUnique();
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<State>().HasIndex("Name", "CountryId").IsUnique();
            modelBuilder.Entity<City>().HasIndex("Name", "StateId").IsUnique();
            modelBuilder.Entity<Campus>().HasIndex(ca => ca.Id).IsUnique();
            modelBuilder.Entity<Appointment>().HasIndex(a => a.Id).IsUnique();
        }
}

}
