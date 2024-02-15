using FluentValidation;

namespace ShopAppAPI.Application.Features.ProductCommandQuery.Commands.UpdateProduct;
 
public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommandRequest>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().MinimumLength(2);
        RuleFor(c => c.Price).NotEmpty().GreaterThan(0);
        RuleFor(c => c.Stock).NotEmpty().GreaterThan(0);
        RuleFor(c => c.CategoryId).NotEmpty();
    }
}
