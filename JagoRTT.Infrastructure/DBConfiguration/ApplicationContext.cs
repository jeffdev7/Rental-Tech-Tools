using JagoRTT.domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JagoRTT.Infrastructure.DBConfiguration
{
    public interface IAppDbContext { }
    public class ApplicationContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Tool> Tools { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public ApplicationContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }   
    }
}
