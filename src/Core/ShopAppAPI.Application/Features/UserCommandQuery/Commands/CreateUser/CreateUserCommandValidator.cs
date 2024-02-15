using FluentValidation;

namespace ShopAppAPI.Application.Features.UserCommandQuery.Commands.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommandRequest>
{
    public CreateUserCommandValidator()
    {
        RuleFor(u => u.Email).EmailAddress().MaximumLength(100);
        RuleFor(u=>u.FullName).NotEmpty().MaximumLength(100);
        RuleFor(u => u.Password).NotEmpty();
        RuleFor(u => u.PasswordConfirm).NotEmpty();
    }
}
