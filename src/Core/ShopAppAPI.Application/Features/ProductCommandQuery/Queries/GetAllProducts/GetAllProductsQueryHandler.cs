using AutoMapper;
using MediatR;
using ShopAppAPI.Application.Repositories;
using ShopAppAPI.Domain;

namespace ShopAppAPI.Application.Features.ProductCommandQuery.Queries.GetAllProducts;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, BaseResponse<List<GetAllProductQueryResponse>>>
{
    private readonly IProductReadRepository _repository;
    private readonly IMapper _mapper;

    public GetAllProductsQueryHandler(IProductReadRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<BaseResponse<List<GetAllProductQueryResponse>>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
    {
        var activeProducts = await _repository.GetAllByStatusAsync(StatusTypeEnum.Active);

        var response = _mapper.Map<List<GetAllProductQueryResponse>>(activeProducts);

        return new BaseResponse<List<GetAllProductQueryResponse>>("", true, response);
    }
}
