using FluentValidation;

namespace ShopAppAPI.Application.Features.BrandCommandQuery.Commands.CreateBrand;

public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommandRequest>
{
    public CreateBrandCommandValidator()
    {
        RuleFor(r => r.Name).NotNull().NotEmpty();
    }
}
