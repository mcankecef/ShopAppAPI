using MediatR;
using ShopAppAPI.Domain;

namespace ShopAppAPI.Application.Features.ProductCommandQuery.Commands.CreateProduct;

public class CreateProductCommandRequest : IRequest<BaseResponse<CreateProductCommandResponse>>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public StatusTypeEnum Status { get; set; } = StatusTypeEnum.Active;
}
