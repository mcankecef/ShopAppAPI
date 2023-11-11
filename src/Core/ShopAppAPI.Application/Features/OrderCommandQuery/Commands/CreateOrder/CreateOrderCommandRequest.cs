using MediatR;
using ShopAppAPI.Application.Dtos.Product;

namespace ShopAppAPI.Application.Features.OrderCommandQuery.Commands.CreateOrder;

public class CreateOrderCommandRequest : IRequest<BaseResponse<CreateOrderCommandResponse>>
{
    public string Address { get; set; }
    public string CustomerId { get; set; }
    public List<Guid> ProductIds { get; set; }
}
