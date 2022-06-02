using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JagoRTT.Application.ViewModel
{
    public class CompanyVM
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string CNPJ { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
