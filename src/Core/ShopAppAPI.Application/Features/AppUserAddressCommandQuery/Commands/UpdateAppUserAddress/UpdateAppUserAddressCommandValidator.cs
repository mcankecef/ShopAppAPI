using FluentValidation;

namespace ShopAppAPI.Application.Features.AppUserAddressCommandQuery.Commands.UpdateAppUserAddress;

public class UpdateAppUserAddressCommandValidator : AbstractValidator<UpdateAppUserAddressCommandRequest>
{
    public UpdateAppUserAddressCommandValidator()
    {
        RuleFor(r=>r.AppUserAddressId).NotNull().NotEmpty();
        RuleFor(r=>r.Description).NotNull().NotEmpty();
    }
}
