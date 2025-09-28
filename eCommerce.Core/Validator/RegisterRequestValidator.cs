using eCommerce.Core.DTO;
using FluentValidation;

namespace eCommerce.Core.Validator;

public class RegisterRequestValidator : AbstractValidator<UserRegisterRequest>
{
    public RegisterRequestValidator()
    {
        //Email
        RuleFor(temp => temp.Email).NotEmpty().WithMessage("Email is require").EmailAddress().WithMessage("Invalid email address format");

        //Password
        RuleFor(temp => temp).NotEmpty().WithMessage("Password is required");

        //Validate the PersonName property
        RuleFor(temp => temp.PersonName).NotEmpty().WithMessage("PersonName can't be blank").Length(1, 50).WithMessage("Person Name should be 1 to 50 characters long");

        //Validate the Gender property
        RuleFor(temp => temp.Gender).IsInEnum().WithMessage("Invalid gender option");

    }
}

