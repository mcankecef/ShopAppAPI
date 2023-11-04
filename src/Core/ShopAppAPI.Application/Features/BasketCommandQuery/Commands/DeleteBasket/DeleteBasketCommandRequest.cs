using MediatR;

namespace ShopAppAPI.Application;

public class DeleteBasketCommandRequest : IRequest<BaseResponse<DeleteBasketCommandResponse>>
{
    public Guid ProductId { get; set; }
    public string UserId { get; set; }
}
