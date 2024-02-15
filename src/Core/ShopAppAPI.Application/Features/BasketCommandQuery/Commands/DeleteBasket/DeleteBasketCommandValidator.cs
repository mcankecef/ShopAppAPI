using FluentValidation;

namespace ShopAppAPI.Application.Features.BasketCommandQuery.Commands.DeleteBasket;

public class DeleteBasketCommandValidator : AbstractValidator<DeleteBasketCommandRequest>
{
    public DeleteBasketCommandValidator()
    {
        RuleFor(b => b.ProductId).NotEmpty();
        RuleFor(b => b.UserId).NotEmpty();
    }
}
