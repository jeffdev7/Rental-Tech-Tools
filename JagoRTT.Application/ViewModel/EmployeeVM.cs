using JagoRTT.domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JagoRTT.Application.ViewModel
{
    public class EmployeeVM
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Guid CompanyId { get; set; }
        public Guid ToolId { get; set; }
        public Guid RentalId { get; set; }
        public string CiaName { get; internal set; }
        public string ToolName { get; internal set; }
        public ETypeOfRental RentalType { get; internal set; }
    }
}
