using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopAppAPI.Application.Repositories;
using ShopAppAPI.Domain;
using ShopAppAPI.Domain.Entities;

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
        var existingBasket = await _readRepository.GetByFilter(b => b.UserId == request.UserId).FirstOrDefaultAsync();
        var product = await _productReadRepository.GetByFilter(p => p.Id == request.ProductId, true).FirstOrDefaultAsync();

        bool operationResult = false;

        if (existingBasket == null)
        {
            var newBasket = new Basket
            {
                UserId = request.UserId,
                Products = new List<Product> { product }
            };

            operationResult = await _writeRepository.CreateAsync(newBasket);

            if (!operationResult)
                return BaseResponse<AddBasketCommandResponse>.Fail(errorMessage);

            existingBasket = newBasket;
        }

        if (operationResult)
        {
            var response = new AddBasketCommandResponse { Id = existingBasket.Id };
            return BaseResponse<AddBasketCommandResponse>.Success(response);
        }

        return BaseResponse<AddBasketCommandResponse>.Fail(errorMessage);
    }
}
