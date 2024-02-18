﻿using Empathy.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Empathy.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<City> Cities { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Sede> Sedes { get; set; }
        public DbSet<Procedure> Procedures { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<HealthCondition> HealthConditions { get; set; }

        public DbSet<SedeAppointment>SedesAppointmets { get; set; }

        public DbSet<Professional>Professionals { get; set; }
       
        public DbSet<SedeProfessional>SedeProfessionals { get; set; }
        public DbSet<AppointmentUser>AppointmentUsers { get; set; }
        public DbSet<AppointmentProfessional> AppointmentProfessionals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique();
            //modelBuilder.Entity<Sede>().HasIndex(c => c.NameCampus).IsUnique();
            //modelBuilder.Entity<Procedure>().HasIndex(c => c.TypeProcedure).IsUnique();
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<State>().HasIndex("Name", "CountryId").IsUnique();
            modelBuilder.Entity<City>().HasIndex("Name", "StateId").IsUnique();
            modelBuilder.Entity<Appointment>().HasIndex(a => a.Id).IsUnique();
            modelBuilder.Entity<Professional>().HasIndex(p => p.Id).IsUnique();
            //modelBuilder.Entity<SedeProfessional>().HasIndex("SedeId", "ProfessionalId").IsUnique();
        }
}

}
