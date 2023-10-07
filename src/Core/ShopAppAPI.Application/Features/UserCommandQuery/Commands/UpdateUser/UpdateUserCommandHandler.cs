using AutoMapper;
using MediatR;

namespace ShopAppAPI.Application.Features.UserCommandQuery.Commands.UpdateUser;
public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, BaseResponse<UpdateUserCommandResponse>>
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UpdateUserCommandHandler(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    public async Task<BaseResponse<UpdateUserCommandResponse>> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
    {
        var updateUserDto = _mapper.Map<UpdateUserDto>(request);

        await _userService.UpdateUser(updateUserDto);

        return BaseResponse<UpdateUserCommandResponse>.Success(default);
    }
}
