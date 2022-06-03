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
            //SEEDER FOR EMPLOYEES WITH 3 FK's
            //modelBuilder.Entity<Employee>().HasData(new Employee
            //{
            //    Id = Guid.NewGuid(),
            //    Name = "Jefferson",
            //    CPF = "666.788.370-00",
            //    Email = "jefferson@naughtydog.com",
            //    Phone = "11 92109-0212",
            //    CompanyId = Guid.Parse("30479b7b-fd49-4fa4-8a75-7849524e3e3b"),
            //    ToolId = Guid.Parse("38b82414-bd8f-4317-8440-d5329028989d"),
            //    RentalId = Guid.Parse("8959274b-907a-46e9-ae5b-8a2a4dafc795")

            //});
            //modelBuilder.Entity<Employee>().HasData(new Employee
            //{
            //    Id = Guid.NewGuid(),
            //    Name = "Carlos",
            //    CPF = "946.864.370-08",
            //    Email = "carlos@gmail.com",
            //    Phone = "11 0909-212",
            //    CompanyId = Guid.Parse("30479b7b-fd49-4fa4-8a75-7849524e3e3b"),
            //    ToolId = Guid.Parse("38b82414-bd8f-4317-8440-d5329028989d"),
            //    RentalId = Guid.Parse("8959274b-907a-46e9-ae5b-8a2a4dafc795")

            //});
            //modelBuilder.Entity<Employee>().HasData(new Employee
            //{
            //    Id = Guid.NewGuid(),
            //    Name = "Anne",
            //    CPF = "777.762.370-19",
            //    Email = "anne@gmail.com",
            //    Phone = "11 96909-212",
            //    CompanyId = Guid.Parse("30479b7b-fd49-4fa4-8a75-7849524e3e3b"),
            //    ToolId = Guid.Parse("38b82414-bd8f-4317-8440-d5329028989d"),
            //    RentalId = Guid.Parse("c0a91cbd-e47a-4942-9e7c-6395e7647760")

            //});

            //SEEDER FOR RENTAL WITH 2 FK's
            //modelBuilder.Entity<Rental>().HasData(new Rental
            //{
            //    Id = Guid.NewGuid(),
            //    BeginDate = DateTime.Now,
            //    EndDate = DateTime.Now,
            //    Price = new decimal(100.0),
            //    Type = domain.Entities.Enum.ETypeOfRental.Monthly,
            //    ToolId = Guid.Parse("38b82414-bd8f-4317-8440-d5329028989d"),
            //    CompanyId = Guid.Parse("30479b7b-fd49-4fa4-8a75-7849524e3e3b"),

            //});
            //modelBuilder.Entity<Rental>().HasData(new Rental
            //{
            //    Id = Guid.NewGuid(),
            //    BeginDate = DateTime.Now,
            //    EndDate = DateTime.Now,
            //    Price = new decimal(150.0),
            //    Type = domain.Entities.Enum.ETypeOfRental.Weekly,
            //    ToolId = Guid.Parse("60242ace-c5fe-4f48-9c90-a16b137d5ca5"),
            //    CompanyId = Guid.Parse("f72af8f4-3b32-45c4-a9e1-fc8cbcdafc0d"),

            //});

            //SEEDER FOR COMPANY AND TOOL - ONLY PK
            modelBuilder.Entity<Company>().HasData(new Company
            {
                Id = Guid.NewGuid(),
                Name = "Naughty Cat",
                CNPJ = "88.654.744/0001-43",
                Email = "naughtyat@naughtyact.com",
                Phone = "1 1 1380-0999"
            });
            //modelBuilder.Entity<Company>().HasData(new Company
            //{
            //    Id = Guid.NewGuid(),
            //    Name = "NCP",
            //    CNPJ = "32.654.744/0001-16",
            //    Email = "ncp@gmail.com",
            //    Phone = "11 0000-0999"
            //});
            //modelBuilder.Entity<Company>().HasData(new Company
            //{
            //    Id = Guid.NewGuid(),
            //    Name = "New School",
            //    CNPJ = "60.446.716/0001-49",
            //    Email = "newschool@gmail.com",
            //    Phone = "11 7600-0779"
            //});
            //modelBuilder.Entity<Tool>().HasData(new Tool
            //{
            //    Id = Guid.NewGuid(),
            //    Name = "laptop",
            //    Model= "i5",
            //    Brand = domain.Entities.Enum.EBrand.HP,
            //    QuantityInStock = 3
            //});
            //modelBuilder.Entity<Tool>().HasData(new Tool
            //{
            //    Id = Guid.NewGuid(),
            //    Name = "laptop",
            //    Model = "i5",
            //    Brand = domain.Entities.Enum.EBrand.DELL,
            //    QuantityInStock= 3
            //});
            //modelBuilder.Entity<Tool>().HasData(new Tool
            //{
            //    Id = Guid.NewGuid(),
            //    Name = "laptop",
            //    Model = "i5",
            //    Brand = domain.Entities.Enum.EBrand.LENOVO,
            //    QuantityInStock = 3
            //});
            //modelBuilder.Entity<Tool>().HasData(new Tool
            //{
            //    Id = Guid.NewGuid(),
            //    Name = "laptop",
            //    Model = "i5",
            //    Brand = domain.Entities.Enum.EBrand.APPLE,
            //    QuantityInStock = 2
            //});

            //base.OnModelCreating(modelBuilder);
        }
    }
}
