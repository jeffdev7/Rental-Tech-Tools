using JagoRTT.domain.Entities.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JagoRTT.domain.Entities
{
    public class Rental : IEntityTypeConfiguration<Rental>
    {
        public Guid Id { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
        public ETypeOfRental Type { get; set; }
        public virtual Tool Tool { get; set; }
        public Guid ToolId { get; set; }
        public virtual Company Company { get; set; }
        public Guid CompanyId { get; set; }
        public object Name { get; set; }

        public Rental() { }

        public Rental(Guid id, DateTime beginDate, DateTime endDate, decimal price, ETypeOfRental type, Guid toolId, Guid companyId)
        {
            Id = id;
            BeginDate = beginDate;
            EndDate = endDate;
            Price = price;
            Type = type;
            ToolId = toolId;
            CompanyId = companyId;
        }

        public void Configure(EntityTypeBuilder<Rental>builder)
        {
            builder.HasKey(j => j.Id);
            builder.Property(j => j.Id).IsRequired();
            builder.Property(j => j.BeginDate).IsRequired();
            builder.Property(j => j.EndDate).IsRequired();
            builder.Property(j => j.Price).IsRequired();
        }
    }
}
