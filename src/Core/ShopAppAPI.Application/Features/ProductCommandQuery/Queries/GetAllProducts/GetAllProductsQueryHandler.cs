using AutoMapper;
using MediatR;
using ShopAppAPI.Application.Extensions;
using ShopAppAPI.Application.Repositories;
using ShopAppAPI.Domain.Entities;

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
        var filter = FilterExtension.CreateProductFilter(request.Filter);

        var activeProducts = await _repository.GetAllAsync(request.Page, request.PageSize, filter, p => p.Category);

        var response = _mapper.Map<List<GetAllProductQueryResponse>>(activeProducts);

        return BaseResponse<List<GetAllProductQueryResponse>>.Success(response);
    }
}
