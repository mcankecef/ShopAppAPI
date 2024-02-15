using FluentValidation;

namespace ShopAppAPI.Application.Features.AuthCommandQuery.LoginUser;

public class LoginUserCommandValidator : AbstractValidator<LoginUserCommandRequest>
{
    public LoginUserCommandValidator()
    {
        RuleFor(u => u.UsernameOrEmail).NotEmpty();
        RuleFor(u => u.Password).NotEmpty();
    }
}
