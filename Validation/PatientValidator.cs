using FluentValidation;
using HsptMS.Data.Models;

public class PatientValidator : AbstractValidator<Patient>
{
    public PatientValidator()
    {
        // Add your validation rules here
        RuleFor(patient => patient.Name)
            .NotEmpty()
            .MaximumLength(20)
            .WithMessage("Patient name is required.");
        // Add more rules as needed
        RuleFor(patient => patient.Email)
            .NotEmpty()
            .NotNull()
            .WithMessage("Email is required");
        RuleFor(patient => patient.Age)
            .NotNull()
            .NotEmpty()
            .WithMessage("Enter right Age");
        RuleFor(patient => patient.ContactNumber)
            .MaximumLength(20)
            .NotNull()
            .WithMessage("Enter right Contact");
    }
}

