using System.ComponentModel.DataAnnotations;

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
