using AutoMapper;
using MediatR;
using ShopAppAPI.Application.Repositories.AppUserAddress;
using ShopAppAPI.Domain.Entities;

namespace ShopAppAPI.Application.Features.AppUserAddressCommandQuery.Commands.CreateAppUserAddress;

public class CreateAppUserAddressCommandHandler : IRequestHandler<CreateAppUserAddressCommandRequest, BaseResponse<CreateAppUserAddressCommandResponse>>
{
    private readonly IAppUserAddressWriteRepository _writeRepository;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public CreateAppUserAddressCommandHandler(IAppUserAddressWriteRepository writeRepository, IUserService userService, IMapper mapper)
    {
        _writeRepository = writeRepository;
        _userService = userService;
        _mapper = mapper;
    }

    public async Task<BaseResponse<CreateAppUserAddressCommandResponse>> Handle(CreateAppUserAddressCommandRequest request, CancellationToken cancellationToken)
    {
        var isUserExist = await _userService.UserExistAsync(request.UserId);

        if (!isUserExist)
            throw new UserNotFoundException($"{request.UserId} not found!");

        var createAppUserAddress = new AppUserAddress
        {
            AppUserId = request.UserId,
            Description = request.Description
        };

        var operationResult = await _writeRepository.CreateAsync(createAppUserAddress);

        if (operationResult)
            return BaseResponse<CreateAppUserAddressCommandResponse>
                .Success(_mapper.Map<CreateAppUserAddressCommandResponse>(createAppUserAddress));

        return BaseResponse<CreateAppUserAddressCommandResponse>
                .Fail("AppUserAddress addition failed!");
    }
}
