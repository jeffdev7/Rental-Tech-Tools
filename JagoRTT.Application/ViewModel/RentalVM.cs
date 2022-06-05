using JagoRTT.domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JagoRTT.Application.ViewModel
{
    public class RentalVM
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public DateTime BeginDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
        public ETypeOfRental Type { get; set; }
        public Guid ToolId { get; set; }
        public Guid CompanyId { get; set; }
        public string ToolName { get; internal set; }//only for UI
        public string CiaName { get; internal set; }//only for UI
    }
}
