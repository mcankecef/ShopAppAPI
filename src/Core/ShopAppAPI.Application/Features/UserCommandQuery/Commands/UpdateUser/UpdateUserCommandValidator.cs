using FluentValidation;

namespace ShopAppAPI.Application.Features.UserCommandQuery.Commands.UpdateUser;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommandRequest>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(u => u.Email).EmailAddress();
        RuleFor(u => u.UserId).NotEmpty();
    }
}
