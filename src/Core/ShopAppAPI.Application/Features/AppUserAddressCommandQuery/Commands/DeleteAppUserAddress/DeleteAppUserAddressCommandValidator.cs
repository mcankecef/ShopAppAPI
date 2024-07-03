using FluentValidation;

namespace ShopAppAPI.Application.Features.AppUserAddressCommandQuery.Commands.DeleteAppUserAddress;

public class DeleteAppUserAddressCommandValidator : AbstractValidator<DeleteAppUserAddressCommandRequest>
{
    public DeleteAppUserAddressCommandValidator()
    {
        RuleFor(r => r.Id).NotNull().NotEmpty();
    }
}
