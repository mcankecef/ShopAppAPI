using MediatR;
using ShopAppAPI.Application.Repositories.AppUserAddress;

namespace ShopAppAPI.Application.Features.AppUserAddressCommandQuery.Commands.DeleteAppUserAddress;

public class DeleteAppUserAddressCommandHandler : IRequestHandler<DeleteAppUserAddressCommandRequest, BaseResponse<DeleteAppUserAddressCommandResponse>>
{
    private readonly IAppUserAddressWriteRepository _writeRepository;
    private readonly IAppUserAddressReadRepository _readRepository;

    public DeleteAppUserAddressCommandHandler(IAppUserAddressWriteRepository writeRepository,
        IAppUserAddressReadRepository readRepository)
    {
        _writeRepository = writeRepository;
        _readRepository = readRepository;
    }

    public async Task<BaseResponse<DeleteAppUserAddressCommandResponse>> Handle(DeleteAppUserAddressCommandRequest request, CancellationToken cancellationToken)
    {
        var appUserAddress = await _readRepository.GetByIdAsync(request.Id);

        if (appUserAddress is null)
            throw new ArgumentNullException(nameof(appUserAddress));

        var operationResult = _writeRepository.Remove(appUserAddress);

        if (operationResult)
            return BaseResponse<DeleteAppUserAddressCommandResponse>.Success();

        return BaseResponse<DeleteAppUserAddressCommandResponse>.Fail("Delete app user address operation failed!");
    }
}
