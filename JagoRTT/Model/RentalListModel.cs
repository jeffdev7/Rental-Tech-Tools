using JagoRTT.domain.Entities.Enum;

namespace JagoRTT.domain.Model
{
    public class RentalListModel
    {
        public Guid Id { get; set; }
       // public object Name { get; set; }
        public ETypeOfRental Type { get; set; }
    }
}
