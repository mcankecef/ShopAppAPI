using MediatR;

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
        var basketByUserId = await _readRepository.GetByFilterAsync(b => b.UserId == request.UserId);

        if (basketByUserId != null)
        {
        }

        throw new NotImplementedException();
    }
}
