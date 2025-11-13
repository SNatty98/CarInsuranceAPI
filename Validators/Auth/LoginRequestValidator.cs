using FluentValidation;
using InsuranceAPI.DTOs.Auth;

namespace InsuranceAPI.Validators.Auth
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email formatting.")
            .MaximumLength(50);

            RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.");
        }
    }
}