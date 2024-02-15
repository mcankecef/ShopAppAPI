using FluentValidation;

namespace ShopAppAPI.Application.Features.OrderCommandQuery.Commands.CreateOrder;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommandRequest>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(o => o.Address).NotEmpty().MaximumLength(500);
        RuleFor(o => o.CustomerId).NotEmpty();
    }
}
