using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopAppAPI.Application.Dtos.Product;

namespace ShopAppAPI.Application.Features.BasketCommandQuery.Queries.GetBasketByUserId;

public class GetBasketByUserIdQueryHandler : IRequestHandler<GetBasketByUserIdQueryRequest, BaseResponse<GetBasketByUserIdQueryResponse>>
{
    private readonly IBasketReadRepository _readRepository;
    private readonly IMapper _mapper;

    public GetBasketByUserIdQueryHandler(IBasketReadRepository readRepository, IMapper mapper)
    {
        _readRepository = readRepository;
        _mapper = mapper;
    }

    public async Task<BaseResponse<GetBasketByUserIdQueryResponse>> Handle(GetBasketByUserIdQueryRequest request, CancellationToken cancellationToken)
    {
        var basket = await _readRepository.GetByFilter(b => b.UserId == request.UserId, false, b => b.Products).FirstOrDefaultAsync();

        var productDtos = _mapper.Map<List<ProductDto>>(basket.Products);

        var response = new GetBasketByUserIdQueryResponse
        {
            Id = basket.Id,
            Products = productDtos
        };

        return BaseResponse<GetBasketByUserIdQueryResponse>.Success(response);
    }
}
