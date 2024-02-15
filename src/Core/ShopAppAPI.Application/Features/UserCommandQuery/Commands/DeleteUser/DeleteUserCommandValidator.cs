using FluentValidation;

namespace ShopAppAPI.Application.Features.UserCommandQuery.Commands.DeleteUser;

public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommandRequest>
{
    public DeleteUserCommandValidator()
    {
        RuleFor(u => u.UserId).NotEmpty();
    }
}
