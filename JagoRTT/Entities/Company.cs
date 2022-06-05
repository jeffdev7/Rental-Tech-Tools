using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JagoRTT.domain.Entities
{
    public class Company: IEntityTypeConfiguration<Company>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CNPJ { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public Company() { }

        public Company(string name, string cnpj, string email, string phone)
        {
            Name = name;
            CNPJ = cnpj;
            Email = email;
            Phone = phone;
        }

        public void Configure(EntityTypeBuilder<Company>builder)
        {
            builder.HasKey(j => j.Id);
            builder.Property(j => j.Id).IsRequired();
            builder.Property(j => j.Name);
           builder.Property(j => j.CNPJ).IsRequired();
           builder.Property(j => j.Email).IsRequired();
           builder.Property(j => j.Phone).IsRequired();
        }
    }
}