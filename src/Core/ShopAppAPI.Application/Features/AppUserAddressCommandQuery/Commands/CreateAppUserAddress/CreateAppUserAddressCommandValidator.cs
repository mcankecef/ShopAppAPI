using FluentValidation;

namespace ShopAppAPI.Application.Features.AppUserAddressCommandQuery.Commands.CreateAppUserAddress;

public class CreateAppUserAddressCommandValidator : AbstractValidator<CreateAppUserAddressCommandRequest>
{
    public CreateAppUserAddressCommandValidator()
    {
        RuleFor(r => r.UserId).NotNull().NotEmpty();
        RuleFor(r => r.Description).NotNull().NotEmpty();
    }
}
