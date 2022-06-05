using FluentValidation;
using JagoRTT.domain.Entities;

namespace JagoRTT.domain.Validator
{
    public class CompanyValidator: AbstractValidator<Company>
    {
        public CompanyValidator()
        {
            RuleFor(j => j.Id).NotEmpty();
            RuleFor(j => j.Name).NotEmpty();
            RuleFor(j => j.Name).NotNull();
            RuleFor(j => j.CNPJ).NotEmpty();
           RuleFor(j => j.CNPJ).NotNull();
           RuleFor(j => j.Email).NotEmpty();
           RuleFor(j => j.Email).NotNull();
        }

    }
}