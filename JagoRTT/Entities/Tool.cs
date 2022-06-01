using JagoRTT.domain.Entities.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JagoRTT.domain.Entities
{
    public class Tool : IEntityTypeConfiguration<Tool>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public EBrand Brand { get; set; }
        public int QuantityInStock { get; set; }

        public Tool() { }

        public Tool(string name, string model, EBrand brand, int amount)
        {
            Name = name;
            Model = model;
            Brand = brand;
            QuantityInStock = amount;
        }

        public void Configure(EntityTypeBuilder<Tool>builder)
        {
            builder.HasKey(j => j.Id);
            builder.Property(j => j.Id).IsRequired();
            builder.Property(j => j.Name);
            builder.Property(j => j.Model).IsRequired();
            builder.Property(j => j.Brand).IsRequired();
            builder.Property(j =>j.QuantityInStock).IsRequired();
        }
    }
}
