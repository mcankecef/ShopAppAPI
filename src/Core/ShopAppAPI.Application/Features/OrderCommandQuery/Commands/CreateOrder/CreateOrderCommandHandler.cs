using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopAppAPI.Application.Repositories;
using ShopAppAPI.Application.Repositories.Order;
using ShopAppAPI.Domain;
using ShopAppAPI.Domain.Entities;

namespace ShopAppAPI.Application.Features.OrderCommandQuery.Commands.CreateOrder;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, BaseResponse<CreateOrderCommandResponse>>
{
    private readonly IOrderWriteRepository _orderWriteRepository;
    private readonly IUserService _userService;
    private readonly IProductReadRepository _productReadRepository;

    public CreateOrderCommandHandler(IOrderWriteRepository orderWriteRepository,
    IUserService userService,
    IProductReadRepository productReadRepository)
    {
        _orderWriteRepository = orderWriteRepository;
        _userService = userService;
        _productReadRepository = productReadRepository;
    }

    public async Task<BaseResponse<CreateOrderCommandResponse>> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
    {
        bool userExist = await _userService.UserExistAsync(request.CustomerId);

        if (userExist)
        {
            var productQuery = _productReadRepository
                            .GetByFilter(p => request.ProductIds.Contains(p.Id),true);
            var totalPrice = await productQuery.Select(p => p.Price).SumAsync();
            var products = await productQuery.ToListAsync();

            var order = new Order
            {
                Address = request.Address,
                CustomerId = request.CustomerId,
                Status = StatusTypeEnum.Active,
                TotalPrice = totalPrice,
            };
            products.ForEach(p =>
            {
                order.Products.Add(p);
            });

            var operationResult = await _orderWriteRepository.CreateAsync(order);

            if (operationResult)
                return BaseResponse<CreateOrderCommandResponse>.Success(new CreateOrderCommandResponse { Id = order.Id });

            return BaseResponse<CreateOrderCommandResponse>.Fail("Order create operation failed!");
        }
        return BaseResponse<CreateOrderCommandResponse>.Fail("Order create operation failed!");
    }
}
