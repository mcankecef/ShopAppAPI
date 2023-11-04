using MediatR;
using ShopAppAPI.Domain;

namespace ShopAppAPI.Application;

public class AddBasketCommandRequest : IRequest<BaseResponse<AddBasketCommandResponse>>
{
    public Guid ProductId { get; set; }
    public string UserId { get; set; }
    public StatusTypeEnum Status { get; set; } = StatusTypeEnum.Active;
}
