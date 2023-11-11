using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ShopAppAPI.Application;

public class DeleteBasketCommandHandler : IRequestHandler<DeleteBasketCommandRequest, BaseResponse<DeleteBasketCommandResponse>>
{
    private readonly IBasketWriteRepository _writeRepository;
    private readonly IBasketReadRepository _readRepository;

    public DeleteBasketCommandHandler(IBasketWriteRepository writeRepository, IBasketReadRepository readRepository)
    {
        _writeRepository = writeRepository;
        _readRepository = readRepository;
    }

    public async Task<BaseResponse<DeleteBasketCommandResponse>> Handle(DeleteBasketCommandRequest request, CancellationToken cancellationToken)
    {
        var basketByUserId = await _readRepository.GetByFilter(b => b.UserId == request.UserId, true, b => b.Products).FirstOrDefaultAsync();

        if (basketByUserId != null)
        {
            var deletedProduct = basketByUserId.Products
                                .Where(p => p.Id == request.ProductId)
                                .FirstOrDefault();

            if (deletedProduct != null)
            {
                basketByUserId.Products.Remove(deletedProduct);
                var operationResult = _writeRepository.Update(basketByUserId);

                if (operationResult)
                    return BaseResponse<DeleteBasketCommandResponse>.Success();
            }
        }

        return BaseResponse<DeleteBasketCommandResponse>.Fail("Delete basket operation failed!");
    }
}
