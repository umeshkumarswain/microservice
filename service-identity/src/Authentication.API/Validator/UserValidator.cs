using Authentication.Domain.Models.User;
using FluentValidation;

namespace Service.Authentication.Validator
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.PhoneNumber)
                .Length(10)
                .WithMessage("The phone number should be at least of 10 digits.");
        }
    }
}