using MediatR;

namespace ShopAppAPI.Application.Features.OrderCommandQuery.Queries.GetOrdersByUser;

public class GetOrdersByCustomerQueryRequest : IRequest<BaseResponse<List<GetOrdersByCustomerQueryResponse>>>
{
    public string CustomerId { get; set; }

    public GetOrdersByCustomerQueryRequest(string customerId) 
        => CustomerId = customerId;
}
