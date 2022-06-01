using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JagoRTT.domain.Entities
{
    public class Employee: IEntityTypeConfiguration<Employee>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public virtual Company Company { get; set; }
        public Guid CompanyId { get; set; }
        public virtual Tool Tool { get; set; }
        public Guid ToolId { get; set; }
        public virtual Rental Rental {get;set;}
        public Guid RentalId { get; set; }

        public Employee() { }

        public Employee(Guid id, string name, string cpf, string email, string phone, Guid companyId, Guid toolId, Guid rentalId)
        {
            Id = id;
            Name = name;
            CPF = cpf;
            Email = email;
            Phone = phone;
            CompanyId = companyId;
            ToolId = toolId;
            RentalId = rentalId;
        }

        public void Configure(EntityTypeBuilder<Employee>builder)
        {
            builder.HasKey(j => j.Id);
            builder.Property(j => j.Id).IsRequired();
            builder.Property(j => j.Name);
            builder.Property(j => j.CPF).IsRequired();
            builder.Property(j => j.Email).IsRequired();
            builder.Property(j => j.Phone).IsRequired();
        }
    }
}
