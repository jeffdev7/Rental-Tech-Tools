using FluentValidation;
using JagoRTT.domain.Entities;

namespace JagoRTT.domain.Validator
{
    public class EmployeeValidator: AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(j => j.Id).NotEmpty();
            RuleFor(j => j.Name).NotEmpty();
            RuleFor(j => j.Name).NotNull();
        }

    }
}