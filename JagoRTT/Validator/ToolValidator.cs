using FluentValidation;
using JagoRTT.domain.Entities;

namespace JagoRTT.domain.Validator
{
    public class ToolValidator: AbstractValidator<Tool>
    {
        public ToolValidator()
        {
            RuleFor(j => j.Id).NotEmpty();
            RuleFor(j => j.Name).NotEmpty();
            RuleFor(j => j.Name).NotNull();
            RuleFor(j => j.Brand).NotEmpty();
            RuleFor(j => j.Brand).NotNull();
        }

    }
}