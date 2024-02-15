using FluentValidation;

namespace ShopAppAPI.Application.Features.BasketCommandQuery.Commands.AddBasket;

public class AddBasketCommandValidator : AbstractValidator<AddBasketCommandRequest>
{
    public AddBasketCommandValidator()
    {
        RuleFor(b => b.UserId).NotEmpty();
        RuleFor(b => b.ProductId).NotEmpty();
    }
}
