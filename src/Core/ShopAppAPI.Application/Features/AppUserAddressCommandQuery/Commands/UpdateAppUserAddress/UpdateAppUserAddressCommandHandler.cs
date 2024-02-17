using MediatR;
using ShopAppAPI.Application.Repositories.AppUserAddress;

namespace ShopAppAPI.Application.Features.AppUserAddressCommandQuery.Commands.UpdateAppUserAddress;

public class UpdateAppUserAddressCommandHandler : IRequestHandler<UpdateAppUserAddressCommandRequest, BaseResponse<UpdateAppUserAddressCommandResponse>>
{
    private readonly IAppUserAddressWriteRepository _writeRepository;
    private readonly IAppUserAddressReadRepository _readRepository;

    public UpdateAppUserAddressCommandHandler(IAppUserAddressWriteRepository writeRepository,
        IAppUserAddressReadRepository readRepository)
    {
        _writeRepository = writeRepository;
        _readRepository = readRepository;
    }

    public async Task<BaseResponse<UpdateAppUserAddressCommandResponse>> Handle(UpdateAppUserAddressCommandRequest request, CancellationToken cancellationToken)
    {
        var appUserAddress = await _readRepository.GetByIdAsync(request.AppUserAddressId);

        if (appUserAddress == null)
            throw new ArgumentNullException(nameof(appUserAddress));

        appUserAddress.Description = request.Description;

        var operationResult = _writeRepository.Update(appUserAddress);

        if (operationResult)
            return BaseResponse<UpdateAppUserAddressCommandResponse>.Success();

        return BaseResponse<UpdateAppUserAddressCommandResponse>.Fail("The user's address update process failed!");
    }
}
