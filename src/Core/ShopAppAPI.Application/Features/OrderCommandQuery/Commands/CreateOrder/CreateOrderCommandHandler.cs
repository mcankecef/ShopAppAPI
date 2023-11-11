using MediatR;
using ShopAppAPI.Application.Repositories.Order;
using ShopAppAPI.Domain;
using ShopAppAPI.Domain.Entities;

namespace ShopAppAPI.Application.Features.OrderCommandQuery.Commands.CreateOrder;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, BaseResponse<CreateOrderCommandResponse>>
{
    private readonly IOrderWriteRepository _orderWriteRepository;
    private readonly IUserService _userService;

    public CreateOrderCommandHandler(IOrderWriteRepository orderWriteRepository, IUserService userService)
    {
        _orderWriteRepository = orderWriteRepository;
        _userService = userService;
    }

    public async Task<BaseResponse<CreateOrderCommandResponse>> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
    {
        bool userExist = await _userService.UserExistAsync(request.CustomerId);

        if (userExist)
        {
            var totalPrice = request.Products.Select(p => p.Price).Sum();

            var order = new Order
            {
                Address = request.Address,
                CustomerId = request.CustomerId,
                Status = StatusTypeEnum.Active,
                TotalPrice = totalPrice,
            };

            var operationResult = await _orderWriteRepository.CreateAsync(order);

            if (operationResult)
                return BaseResponse<CreateOrderCommandResponse>.Success(new CreateOrderCommandResponse { Id = order.Id });

            return BaseResponse<CreateOrderCommandResponse>.Fail("Order create operation failed!");
        }
        return BaseResponse<CreateOrderCommandResponse>.Fail("Order create operation failed!");
    }
}
