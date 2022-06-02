using JagoRTT.domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JagoRTT.Application.ViewModel
{
    public class ToolVM
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Model { get; set; }
        public EBrand Brand { get; set; }
        public int QuantityInStock { get; set; }
    }
}
