using FluentValidation;
using FluentValidations.Models;

namespace FluentValidations.Validators
{
    public class DeveloperValidator : AbstractValidator<Developer>
    {
        public DeveloperValidator()
        {
            RuleFor(x => x.FirstName)
                .NotNull().WithMessage("FirstName cannot be null.")
                .MinimumLength(2).WithMessage("FirstName must at least have 2 characters.");
            RuleFor(x => x.LastName)
                .NotNull().WithMessage("LastName cannot be null.")
                .MinimumLength(2).WithMessage("LastName must at least have 2 characters.");
            RuleFor(x => x.Age)
                .GreaterThan(0).WithMessage("Age must be a positive number")
                .InclusiveBetween(18,100).WithMessage("Age must be within the legal working age (18+)");
        }

    }
}
