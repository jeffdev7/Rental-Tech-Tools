using FluentValidation;
using JagoRTT.domain.Entities;

namespace JagoRTT.domain.Validator
{
    public class RentalValidator: AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(j => j.Id).NotEmpty();
            RuleFor(j => j.BeginDate).NotEmpty();
            RuleFor(j => j.EndDate).NotNull();
            RuleFor(j => j.Price).NotEmpty();
            RuleFor(j => j.Price).NotNull();
        }

    }
}
