using Microsoft.EntityFrameworkCore;
using REST.Models;

namespace REST.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        public DbSet<JobDescription> JobDescriptions { get; set; }
        public DbSet<Placement> Placements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Placement>().HasOne(c => c.Customer).WithMany(p => p.Placements).HasForeignKey(fk => fk.CustomerId);

            modelBuilder.Entity<Interview>().HasOne(p => p.Placement).WithMany(i => i.Interviews).HasForeignKey(fk => fk.PlacementId);
            modelBuilder.Entity<Interview>().HasOne(p => p.JobDescription).WithMany(i => i.Interviews).HasForeignKey(fk => fk.JobDescriptionId);
            modelBuilder.Entity<Interview>().HasOne(p => p.Employee).WithMany(i => i.Interviews).HasForeignKey(fk => fk.EmployeeId);
        }
    }
}
