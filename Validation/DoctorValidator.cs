using FluentValidation;
using HsptMS.Data.Models;

namespace HsptMS.Validation
{
    internal sealed class DoctorValidator : AbstractValidator<Doctor>
    {
        public DoctorValidator()
        {
            //RuleFor(x => x.Name)
            //    .MaximumLength(20)
            //    .WithMessage("Name should be a maximum of 20 characters");

            //RuleFor(x => x.Experience)
            //    .NotNull()
            //    .NotEmpty()
            //    .WithMessage("Experience is required");

            //RuleFor(x => x.ContactNumber)
            //    .NotNull()
            //    .NotEmpty()
            //    .WithMessage("Contact number is required");
        }
    }
}
