using FluentValidation;

namespace ShopAppAPI.Application.Features.AppUserAddressCommandQuery.Queries.GetAppUserAddresses;

public class GetAppUserAddressesQueryValidator : AbstractValidator<GetAppUserAddressesQueryRequest>
{
    public GetAppUserAddressesQueryValidator()
    {
        RuleFor(r => r.UserId).NotEmpty().NotNull();
    }
}
