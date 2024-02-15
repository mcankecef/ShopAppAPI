using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopAppAPI.Application.Dtos.Product;
using ShopAppAPI.Application.Features.OrderCommandQuery.Queries.GetOrdersByUser;
using ShopAppAPI.Application.Repositories;

namespace ShopAppAPI.Application.Features.OrderCommandQuery.Queries.GetOrdersByCustomer;

public class GetOrdersByCustomerQueryHandler : IRequestHandler<GetOrdersByCustomerQueryRequest, BaseResponse<List<GetOrdersByCustomerQueryResponse>>>
{
    private readonly IOrderReadRepository _orderReadRepository;
    private readonly IMapper _mapper;

    public GetOrdersByCustomerQueryHandler(IOrderReadRepository orderReadRepository, IMapper mapper)
    {
        _orderReadRepository = orderReadRepository;
        _mapper = mapper;
    }

    public async Task<BaseResponse<List<GetOrdersByCustomerQueryResponse>>> Handle(GetOrdersByCustomerQueryRequest request, CancellationToken cancellationToken)
    {
        var orderQuery = _orderReadRepository.GetByFilter(o => o.CustomerId == request.CustomerId, false, o => o.Products);

        var orders = await orderQuery.Select(o => new GetOrdersByCustomerQueryResponse
        {
            Products = _mapper.Map<List<ProductDto>>(o.Products),
            Address = o.Address,
            TotalPrice = o.TotalPrice
        }).ToListAsync();

        return BaseResponse<List<GetOrdersByCustomerQueryResponse>>.Success(orders);
    }
}
