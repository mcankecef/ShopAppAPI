using FluentValidation;

namespace ShopAppAPI.Application.Features.ProductCommandQuery.Commands.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommandRequest>
{
    public CreateProductCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().MinimumLength(2);
        RuleFor(c => c.Price).NotEmpty().GreaterThan(0);
        RuleFor(c => c.CategoryId).NotEmpty();
    }
}
