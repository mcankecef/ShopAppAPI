using MediatR;
using ShopAppAPI.Domain;

namespace ShopAppAPI.Application.Features.BrandCommandQuery.Commands.CreateBrand;

public class CreateBrandCommandRequest : IRequest<BaseResponse<CreateBrandCommandResponse>>
{
    public string Name { get; set; }
    public string? Description { get; set; } = null;
    public StatusTypeEnum Status { get; set; } = StatusTypeEnum.Active;
}
