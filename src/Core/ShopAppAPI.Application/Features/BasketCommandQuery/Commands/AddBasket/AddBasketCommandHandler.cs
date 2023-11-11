using AutoMapper;
using MediatR;
using ShopAppAPI.Application.Repositories;
using ShopAppAPI.Domain;

namespace ShopAppAPI.Application;

public class AddBasketCommandHandler : IRequestHandler<AddBasketCommandRequest, BaseResponse<AddBasketCommandResponse>>
{
    private readonly IBasketWriteRepository _writeRepository;
    private readonly IBasketReadRepository _readRepository;
    private readonly IProductReadRepository _productReadRepository;

    public AddBasketCommandHandler(IBasketWriteRepository writeRepository,
     IBasketReadRepository readRepository,
     IProductReadRepository productReadRepository)
    {
        _writeRepository = writeRepository;
        _readRepository = readRepository;
        _productReadRepository = productReadRepository;
    }

    public async Task<BaseResponse<AddBasketCommandResponse>> Handle(AddBasketCommandRequest request, CancellationToken cancellationToken)
    {
        var errorMessage = "Basket add operation failed!";
        var existingBasket = await _readRepository.GetByFilterAsync(b => b.UserId == request.UserId);
        var product = await _productReadRepository.GetByFilterAsync(p => p.Id == request.ProductId);

        bool operationResult = false;

        if (existingBasket == null)
        {
            var newBasket = new Basket
            {
                UserId = request.UserId,
            };

            operationResult = await _writeRepository.CreateAsync(newBasket);

            if (!operationResult)
                return BaseResponse<AddBasketCommandResponse>.Fail(errorMessage);

            existingBasket = newBasket;
        }

        existingBasket.Products.Add(product);

        operationResult = _writeRepository.Update(existingBasket);

        if (operationResult)
        {
            var response = new AddBasketCommandResponse { Id = existingBasket.Id };
            return BaseResponse<AddBasketCommandResponse>.Success(response);
        }

        return BaseResponse<AddBasketCommandResponse>.Fail(errorMessage);
    }
}
