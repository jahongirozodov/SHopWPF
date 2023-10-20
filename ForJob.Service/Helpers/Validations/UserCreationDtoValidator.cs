using FluentValidation;
using FluentValidation.Validators;
using ForJob.Service.DTOs.Users;

namespace ForJob.Service.Helpers.Validations;

public class UserCreationDtoValidator : AbstractValidator<UserRegisterDto>
{
    public UserCreationDtoValidator()
    {
          RuleFor(u => u.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
            .Matches("[A-Za-z]").WithMessage("Password must contain at least one letter.")
            .Matches("[0-9]").WithMessage("Password must contain at least one digit.")
            .Matches("^[A-Z]").WithMessage("Password must start with an uppercase letter.");
    }
}
