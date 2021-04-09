using System;
using HeadstormSample.Model;
using Microsoft.EntityFrameworkCore;

namespace HeadstormSample.DataAccess
{
    public class HeadstormSampleContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = MSI; Database = Headstorm; Trusted_Connection = True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<SIG> SIGs { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
    }

}
