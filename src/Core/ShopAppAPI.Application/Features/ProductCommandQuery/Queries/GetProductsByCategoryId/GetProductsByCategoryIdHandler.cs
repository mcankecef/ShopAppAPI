using System.Linq.Expressions;
using AutoMapper;
using MediatR;
using ShopAppAPI.Application.Repositories;
using ShopAppAPI.Domain.Entities;

namespace ShopAppAPI.Application;

public class GetProductsByCategoryIdHandler : IRequestHandler<GetProductsByCategoryIdQueryRequest, BaseResponse<List<GetProductsByCategoryIdResponse>>>
{
    private readonly IProductReadRepository _productReadRepository;
    private readonly IMapper _mapper;

    public GetProductsByCategoryIdHandler(IProductReadRepository productReadRepository, IMapper mapper)
    {
        _productReadRepository = productReadRepository;
        _mapper = mapper;
    }

    public async Task<BaseResponse<List<GetProductsByCategoryIdResponse>>> Handle(GetProductsByCategoryIdQueryRequest request, CancellationToken cancellationToken)
    {

        var productsByCategoryId = await _productReadRepository.GetAllAsync(request.Page, request.PageSize, p => p.CategoryId == request.CategoryId, p => p.Category);

        var response = _mapper.Map<List<GetProductsByCategoryIdResponse>>(productsByCategoryId);

        return new BaseResponse<List<GetProductsByCategoryIdResponse>>(response, true);
    }
}
