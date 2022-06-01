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
            //SEEDER
            modelBuilder.Entity<Company>().HasData(new Company
            {
                Id = Guid.NewGuid(),
                Name = "NCP",
                CNPJ = "32.654.744/0001-16",
                Email = "ncp@gmail.com",
                Phone = "11 0000-0999"
            });
            modelBuilder.Entity<Company>().HasData(new Company
            {
                Id = Guid.NewGuid(),
                Name = "New School",
                CNPJ = "60.446.716/0001-49",
                Email = "newschool@gmail.com",
                Phone = "11 7600-0779"
            });
            modelBuilder.Entity<Tool>().HasData(new Tool
            {
                Id = Guid.NewGuid(),
                Name = "laptop",
                Model= "i5",
                Brand = domain.Entities.Enum.EBrand.HP,
                QuantityInStock = 3
            });
            modelBuilder.Entity<Tool>().HasData(new Tool
            {
                Id = Guid.NewGuid(),
                Name = "laptop",
                Model = "i5",
                Brand = domain.Entities.Enum.EBrand.DELL,
                QuantityInStock= 3
            });
            modelBuilder.Entity<Tool>().HasData(new Tool
            {
                Id = Guid.NewGuid(),
                Name = "laptop",
                Model = "i5",
                Brand = domain.Entities.Enum.EBrand.LENOVO,
                QuantityInStock = 3
            });
            modelBuilder.Entity<Tool>().HasData(new Tool
            {
                Id = Guid.NewGuid(),
                Name = "laptop",
                Model = "i5",
                Brand = domain.Entities.Enum.EBrand.APPLE,
                QuantityInStock = 2
            });
            //base.OnModelCreating(modelBuilder);
        }   
    }
}
